module ContentManager.Core.Commands

open System
open ContentManager.Core
open ContentManager.Utils
open CommandUtils
open Messages
open Model

let GetDataCmd (m: Model) loadType =
    let context = m.Context
    let param = m.Context.Value.Parameters.Head
    fun dispatch ->
        async {
            try
                let path = GetFile loadType
                if String.IsNullOrWhiteSpace path then Logger.Debug("Canceled") else    
                    LoadData dispatch path
                    if m.Resent |> List.contains path |> not then
                        m.Resent |> List.append [ path ] |> SetResent |> dispatch
                    path |> Some |> SetDataPath |> dispatch
            with | ex -> Logger.Debug($"GetDataCmd Error: {ex}")
        } |> Async.StartImmediate


let SetDataPathCmd (path: string option) =
    fun dispatch ->
        async {
            if path.IsNone then ()
            else LoadData dispatch path.Value
        } |> Async.StartImmediate
