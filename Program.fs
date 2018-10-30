// Learn more about F# at http://fsharp.org
open Recipes

type ItemRecipe =
| Item of Itemq
| Recipe of Recipeq

let check ((item, _)) (recipe: Recipe) = recipe.Output
                                         |> fst = item

let deduplicate (list:('a * int) list) =
    list
    |> List.groupBy fst
    |> List.map (fun (i,q) -> (i,q |> List.sumBy snd))

let graphItem item =
    let n = (item |> fst)
    sprintf "\"%s\" [label=\"%s X %i\",shape=box];" n n ((item |> snd))

let graphItems times items output =
    items
    |> List.collect
           (fun item -> 
           [            
            sprintf "\"%s\" -> \"%s\" [label=\"%i\"];" (item |> fst) output 
                (times * snd item)])

let graph(irs: ItemRecipe list) =
  [ yield! irs
    |> List.choose (function |Item i -> Some i | _ -> None)
    |> List.groupBy fst
    |> List.map (fun (i,q) -> (i,q |> List.sumBy snd))
    |> List.map graphItem
    yield! irs
    |> List.choose (function |Recipe r -> Some r | _ -> None) 
    |> List.groupBy fst
    |> List.map (fun (i,q) -> (i,q |> List.sumBy snd))
    |> List.collect(fun (recipe, times) -> 
           [yield! (graphItems times recipe.Input (recipe.Output |> fst))])
  ]
let rec recipes rs itemq :ItemRecipe list=
    match rs |> List.tryFind(check itemq) with
    | Some recipe -> 
        let times = (itemq |> snd) / (recipe.Output |> snd)
        Recipe (recipe, times) :: (recipe.Input
                            |> List.map
                                   (fun (item, amount) -> (item, amount * times))
                            |> List.collect(recipes rs))
    | None -> [Item itemq]

[<EntryPoint>]
let main argv =
    let r = recipes Recipes.recipes BasicChemicalReactor
    printfn "digraph G {"
    graph r |> List.iter(printfn "%O")
    printfn "}"
    0
