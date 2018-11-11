module Graphviz
open System.Diagnostics
open Serilog

let toSvg graph : string =
    Log.Information "Converting graph to SVG"
    match FsDot.Invocation.Call(FsDot.Algo.Dot, FsDot.OutputType.Svg,graph) with
    | FsDot.CommandResult.SuccessText s -> s
    | _ -> failwith "Expected string"