module Counter
// Learn more about F# at http://fsharp.org
open Recipes

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
    sprintf "\"%s\"[shape=record, label=\"{{%s}|%s}\"];" output 
        (items
         |> List.map(fun (i, q) -> sprintf "<%s>%s: %i" i i q)
         |> String.concat "|") output 
    :: (items 
        |> List.collect
               (fun item -> 
               [sprintf "\"%s\" -> \"%s\":\"%s\" [label=\"%i\"];" (item |> fst) 
                    output (item |> fst) (times * snd item)]))

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
                   [yield! (graphRecipe times recipe.Input 
                                (recipe.Output |> fst))])]
let divideRoundUp a b =
    (a / b) + (if a % b = 0 then 0 else 1)

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

let main argv =
    let r = recipes Recipes.recipes [TinRotor .*2; LVPump]
    printfn "digraph G {"
    graph r |> List.iter(printfn "%O")
    printfn "}"
    0
