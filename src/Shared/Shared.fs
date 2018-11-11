namespace Shared

module Route =
    /// Defines how routes are generated on server and mapped from client
    let builder typeName methodName =
        sprintf "/api/%s/%s" typeName methodName

type Item = string

type Itemq = Item * int

type Items = Itemq list

type Recipe =
    {Input: Items
     Output: Itemq}

type Recipeq = Recipe * int

/// A type that specifies the communication protocol between client and server
/// to learn more, read the docs at https://zaid-ajaj.github.io/Fable.Remoting/src/basics.html
type IRecipeApi = {
    items : Item list Async
    chart : Items -> string Async
}