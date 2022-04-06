module ContentManager.Core.Update

open ContentManager.Core
open ContentManager.Utils
open Elmish
open Model
open Messages


let update msg m =
    Logger.Debug($"msg: {msg}")
    match msg with
    | Rendered              -> { m with State = "Hello!" }, Cmd.none
    | SetInput v            -> m, Cmd.none