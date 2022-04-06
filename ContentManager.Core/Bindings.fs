module ContentManager.Core.Bindings

open Elmish.WPF
open Messages
open Model

let bindings(): Binding<Model, Msg> list =
    [
        "Rendered"              |> Binding.cmd Rendered
        "State"                 |> Binding.oneWay(fun m -> m.State)
        "SetState"              |> Binding.cmd (SetState "Hello")
        "CreateDataFileCommand" |> Binding.cmd CreateDataFileCommand
        "OpenDataFileCommand"   |> Binding.cmd OpenDataFileCommand
        "SaveDataFileCommand"   |> Binding.cmd SaveDataFileCommand
        "Resent"                |> Binding.oneWay(fun x -> x.Resent)
        "DataPath"              |> Binding.twoWayOpt((fun x -> x.DataPath), SetDataPath)
        "Sheets"                |> Binding.oneWay(fun x -> x.Sheets)
        "ElementsViewModel"     |> Binding.oneWay(fun m -> m.State)
        "Context"               |> Binding.twoWayOpt((fun m -> m.Context), SetContext)
    ]
