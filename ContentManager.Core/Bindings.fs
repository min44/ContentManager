module ContentManager.Core.Bindings

open Elmish.WPF
open Messages
open Model

let bindings(): Binding<Model, Msg> list =
    [
        "Rendered"              |> Binding.cmd Rendered
        "State"                 |> Binding.oneWay(fun m -> m.State)
        "Input"                 |> Binding.twoWayOpt((fun m -> m.Input), SetInput)
    ]
