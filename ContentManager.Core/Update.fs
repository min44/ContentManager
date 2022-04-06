module ContentManager.Core.Update

open ContentManager.Core
open ContentManager.Utils
open Elmish
open Model
open Messages
open UpdateUtils
open Commands

let update msg m =
    Logger.Debug($"msg: {msg}")
    match msg with
    | Rendered                 -> { m with State = "Hello!"; Items = GetItems() }, Cmd.none
    | SetInput v               -> { m with Input = v }, Cmd.none
    | SetValue (vn, id, v)     -> SetValue m vn id v , [ CalculateTotalCmd m]