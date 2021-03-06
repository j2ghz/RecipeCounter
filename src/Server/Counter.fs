module Counter

// Learn more about F# at http://fsharp.org
open Serilog
open Shared
open System

type ItemRecipe =
    | Item of Itemq
    | Recipe of Recipeq

let check ((item, _)) (recipe: Recipe) = recipe.Output
                                         |> fst = item

let deduplicate(list: ('a * int) list) =
    list
    |> List.groupBy fst
    |> List.map(fun (i, q) -> (i, q |> List.sumBy snd))

let graphItem item =
    let n = (item |> fst)
    sprintf 
        "\"%s\" [label=\"%s: %i\", style=filled, fillcolor=\"cornflowerblue\"];" 
        n n ((item |> snd))

let graphRecipe times items output =
    sprintf "\"%s\"[shape=record, label=\"{{%s}|%s ⨉ %i|%i}\"];" (output |> fst) 
        (items
         |> List.map(fun (i, q) -> sprintf "<%s>%i" i q)
         |> String.concat "|")
         (output |> fst) times ((output |> snd) * times) 
    :: (items 
        |> List.collect
               (fun item -> 
               [sprintf "\"%s\" -> \"%s\":\"%s\" [label=\"%i\"];" (item |> fst) 
                    (output |> fst) (item |> fst) (times * snd item)]))

let graph(irs: ItemRecipe list) =
    [yield! irs
            |> List.choose(function 
                   | Item i -> Some i
                   | _ -> None)
            |> List.groupBy fst
            |> List.map(fun (i, q) -> (i, q |> List.sumBy snd))
            |> List.map graphItem
     
     yield! irs
            |> List.choose(function 
                   | Recipe r -> Some r
                   | _ -> None)
            |> List.groupBy fst
            |> List.map(fun (i, q) -> (i, q |> List.sumBy snd))
            |> List.collect
                   (fun (recipe, times) -> 
                   [yield! (graphRecipe times recipe.Input recipe.Output)])]

let divideRoundUp a b =
    (a / b) + (if a % b = 0 then 0
               else 1)

let rec recipes rs items: ItemRecipe list =
    items
    |> List.collect(fun itemq -> 
           match rs |> List.tryFind(check itemq) with
           | Some recipe -> 
               let times = divideRoundUp (itemq |> snd) (recipe.Output |> snd)
               Recipe(recipe, times) :: (recipe.Input
                                         |> List.map
                                                (fun (item, amount) -> 
                                                (item, amount * times))
                                         |> recipes rs)
           | None -> [Item itemq])

let getDotGraph(items: Items) =
    Log.Information("Getting graph for {items}", items)
    String.concat "" [yield "digraph G {"
                      yield! recipes Recipes.recipes items |> graph
                      yield "}"]
