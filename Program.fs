// Learn more about F# at http://fsharp.org
open Recipes

let deduplicate(inv: ('a * int) list) =
    inv
    |> List.groupBy fst
    |> List.map(fun (i, q) -> (i, List.sumBy snd q))
    |> List.sortBy fst

let check ((item, _)) (recipe: Recipe) = recipe.Output
                                         |> fst = item

let format item =
    item
    |> fst
    |> sprintf "\"%s\""

let graphItem times item =
    let n = (item |> fst)
    sprintf "\"%s\" [label=\"%s X %i\"]" n n ((item |> snd) * times)

let graphItems times items output =
    items
    |> List.collect
           (fun item -> 
           [graphItem times item
            
            sprintf "\"%s\" -> \"%s\" [label=\"%i\"]" (item |> fst) output 
                (times * snd item)])

let graph(recipes: Recipeq list) =
    recipes
    |> List.collect(fun (recipe, times) -> 
           [yield (graphItem times recipe.Output)
            yield! (graphItems times recipe.Input (recipe.Output |> fst))])

let rec recipes rs itemq: Recipeq list =
    match rs |> List.tryFind(check itemq) with
    | Some recipe -> 
        let times = (itemq |> snd) / (recipe.Output |> snd)
        (recipe, times) :: (recipe.Input
                            |> List.map
                                   (fun (item, amount) -> (item, amount * times))
                            |> List.collect(recipes rs))
    | None -> []

[<EntryPoint>]
let main argv =
    let r = recipes Recipes.recipes (ConveyorModule 1) |> deduplicate
    graph r |> List.iter(printfn "%O")
    0 // return an integer exit code
