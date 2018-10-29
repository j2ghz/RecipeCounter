// Learn more about F# at http://fsharp.org
open System
open Recipes

let deduplicate(inv: Inventory): Inventory =
    inv
    |> List.groupBy fst
    |> List.map(fun (i,q) -> (i,List.sumBy snd q))
    |> List.sortBy fst

let check ((item,_)) (recipe:Recipe) = recipe.Output |> fst = item

let rec compute' (recipes:Recipe list) (req: Itemq) =
    match recipes |> List.tryFind (check req) with
    | Some recipe ->
        recipe.Input
        |> List.map (fun (items,i) -> (items, i * snd req))
        |> List.collect (compute' recipes)
    | None -> [req]
    
let compute (recipes: Recipe list) (req:Itemq list) =
    req
    |> List.collect (compute' recipes)
    |> deduplicate

[<EntryPoint>]
let main argv =
    (compute Recipes.recipes [ConveyorModule 1]) |> List.iter (printfn "%O")
    0 // return an integer exit code
