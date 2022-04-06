module ContentManager.Core.Update

open ContentManager.Core
open ContentManager.Utils
open Elmish
open Model
open Messages
open Commands
open Abstract
open UpdateUtils

let update msg m =
    Logger.Debug($"msg: {msg}")
    match msg with
    | Rendered              -> { m with State = "___" }, Cmd.none
    | SetState v            -> { m with State = v }, Cmd.none
    | CreateDataFileCommand -> m, [ GetDataCmd m Create]
    | OpenDataFileCommand   -> m, [ GetDataCmd m Open ]
    | SaveDataFileCommand   -> m, Cmd.none
    | SetDataPath p         -> SetDataPath m p, Cmd.none
    | SetResent v           -> { m with Resent = v }, Cmd.none
    | SetContext c          -> { m with Context = c }, Cmd.none