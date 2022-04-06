module ContentManager.Core.Bindings

open ContentManager.Core.Types
open Elmish.WPF
open Messages
open Model

let bindings(): Binding<Model, Msg> list =
    [
        "Rendered"  |> Binding.cmd Rendered
        "State"     |> Binding.oneWay(fun m -> m.State)
        "Input"     |> Binding.twoWay((fun m -> m.Input), SetInput)
        "Total"     |> Binding.oneWay(fun m -> m.Total)
        "Items"     |> Binding.subModelSeq((fun m -> m.Items), (fun s -> s.Id), (fun () -> [
            "Name"   |> Binding.oneWay (fun (_, e) -> e.Name)
            "Value1" |> Binding.twoWay ((fun (_, e) -> e.Value1), (fun v (_, e) -> SetValue (1, e.Id, v)))
            "Value2" |> Binding.twoWay ((fun (_, e) -> e.Value2), (fun v (_, e) -> SetValue (2, e.Id, v)))
            "Sum"    |> Binding.oneWay (fun (_, e) -> e.Sum) ] ))
    ]
