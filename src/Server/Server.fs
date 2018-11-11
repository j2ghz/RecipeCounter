open System.IO
open System.Threading.Tasks

open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open FSharp.Control.Tasks.V2
open Giraffe
open Saturn
open Shared
open Fable.Remoting.Server
open Fable.Remoting.Giraffe
open Serilog

let publicPath = Path.GetFullPath "../Client/public"
let port = 8085us

let recipeApi : IRecipeApi = {
    items = Recipes.recipes |> Recipes.getAllItems |> async.Return
    chart = Counter.getDotGraph >> Graphviz.toSvg >> async.Return
}

let webApp =
    Remoting.createApi()
    |> Remoting.withRouteBuilder Route.builder
    //|> Remoting.fromValue counterApi
    |> Remoting.fromValue recipeApi
    |> Remoting.buildHttpHandler

let app = (application {
    url ("http://0.0.0.0:" + port.ToString() + "/")
    use_router webApp
    memory_cache
    use_static publicPath
    use_gzip
})

let createLogger =
    LoggerConfiguration()
        .MinimumLevel.Debug()
        //.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .CreateLogger();

Log.Logger <- createLogger
run (app.UseSerilog())
 