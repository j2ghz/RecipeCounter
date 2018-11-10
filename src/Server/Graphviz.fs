module Graphviz
open System.Diagnostics

let toSvg graph =
    match FsDot.Invocation.Call(FsDot.Algo.Dot, FsDot.OutputType.Svg,graph) with
    | FsDot.CommandResult.SuccessText s -> s
    | _ -> failwith "Expected string"