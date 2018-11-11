module Client

open Elmish
open Elmish.React

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.PowerPack.Fetch
open Fable.Core.JsInterop

open Thoth.Json

open Shared


open Fulma

open Fulma.FontAwesome

// The model holds data that you want to keep track of while the application is running
// in this case, we are keeping track of a counter
// we mark it as optional, because initially it will not be available from the client
// the initial value will be requested from server
type Model = { 
    Items : (string * int) list option;
    Graph : string option }

// The Msg type defines what events/actions can occur while the application is running
// the state of the application changes *only* in reaction to these events
type Msg =
| ItemsLoaded of Result<(string * int) list,exn>
| GraphReceived of Result<string,exn>
| ItemAmountChanged of (string * int)

module Server =

    open Shared
    open Fable.Remoting.Client

    /// A proxy you can use to talk to server directly
    let api : IRecipeApi =
      Remoting.createApi()
      |> Remoting.withRouteBuilder Route.builder
      |> Remoting.buildProxy<IRecipeApi>

let initialItems() = async{
        let! items = Server.api.items
        return items |> List.map (fun i -> (i,0))
    }

// defines the initial state and initial command (= side-effect) of the application
let init () : Model * Cmd<Msg> =
    let initialModel = { Items = None; Graph = None }
    let loadCountCmd =
        Cmd.ofAsync
            initialItems
            ()
            (Ok >> ItemsLoaded)
            (Error >> ItemsLoaded)
    initialModel, loadCountCmd



// The update function computes the next state of the application based on the current state and the incoming events/messages
// It can also run side-effects (encoded as commands) like calling the server via Http.
// these commands in turn, can dispatch messages to which the update function will react.
let update (msg : Msg) (currentModel : Model) : Model * Cmd<Msg> =
    match currentModel.Items, msg with
    | _,ItemsLoaded (Ok items) ->
        let nextModel = { currentModel with Items = Some items }
        nextModel, Cmd.none

    | _,ItemsLoaded (Error exn) ->
        eprintfn "%O" exn
        currentModel, Cmd.none

    | _,GraphReceived (Ok graph) ->
        {currentModel with Graph = Some graph} , Cmd.none 

    | _,GraphReceived (Error exn) ->
        eprintfn "%O" exn
        currentModel, Cmd.none

    | Some citems,ItemAmountChanged (i,a) ->
        let items = citems |> List.map (fun (i',a') -> if i=i' then (i,a) else (i',a'))
        { currentModel with Items = Some items; Graph = None }, Cmd.ofAsync 
            (Server.api.chart)
            (items |> List.where (fun (_,a) -> a > 0))
            (Ok >> GraphReceived)
            (Error >> GraphReceived)

    | _ -> currentModel, Cmd.none

let ifSomeMap mapper = function
    | Some x -> List.map mapper x
    | None -> []

let onTextChanged doSomethingWith =
    OnChange <| fun (ev : Fable.Import.React.FormEvent) -> 
        let inputTextValue : string = !!ev.target?value
        doSomethingWith inputTextValue

let menu (model:Model) (dispatch : Msg -> unit) =
    Menu.menu [ ]
        [ Menu.label [ ]
              [ str "Items" ]
          Menu.list [ ]
            (model.Items
            |> ifSomeMap (fun i -> Menu.Item.li [ ] [ 
                i |> fst |> str
                Input.number [ Input.Option.DefaultValue (snd i |> string); Input.Option.OnChange (fun event -> (fst i, event.Value |> int) |> ItemAmountChanged |> dispatch) ]
                ]))
        ]



let columns (model : Model) (dispatch : Msg -> unit) =
    Columns.columns [ ]
        [ Column.column [ Column.Width (Screen.All, Column.IsFull) ]
              [ Card.card [ ]
                    [ Card.header [ ]
                        [ Card.Header.title [ ]
                              [ model.Items |> Option.defaultValue [] |> List.where (fun (_,a) -> a > 0) |> sprintf "%A" |> str ] ]
                      Card.content [ ]
                        [ Content.content [ [Style [Overflow "auto"] :> IHTMLProp ] |> Content.Props ]
                            [ 
                                yield match model.Graph with
                                        | None -> str "Loading"
                                        | Some svg -> div [{__html = svg} |> DangerouslySetInnerHTML] []
                             ] ] ]   ] ]

let navBrand =
    Navbar.navbar [ Navbar.Color IsWhite ]
        [ Container.container [ ]
            [ Navbar.Brand.div [ ]
                [ Navbar.Item.a [ Navbar.Item.CustomClass "brand-text" ]
                      [ str "Recipe Counter" ]
                  Navbar.burger [ ]
                      [ span [ ] [ ]
                        span [ ] [ ]
                        span [ ] [ ] ] ]
              Navbar.menu [ ]
                  [ Navbar.Start.div [ ]
                      [ ] ] ] ]

let view (model : Model) (dispatch : Msg -> unit) =
    div [ ]
        [   navBrand
            Container.container [ Container.IsFluid ]
              [ Columns.columns [ ]
                  [ Column.column [ Column.Width (Screen.All, Column.Is2);  ]
                      [ menu model dispatch ]
                    Column.column [ Column.Width (Screen.All, Column.Is10) ]
                      [ columns model dispatch ] ] ] ]

#if DEBUG
open Elmish.Debug
open Elmish.HMR
#endif

Program.mkProgram init update view
#if DEBUG
|> Program.withConsoleTrace
|> Program.withHMR
#endif
|> Program.withReact "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run
