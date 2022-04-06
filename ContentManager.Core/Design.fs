module ContentManager.Core.Design

open Elmish.WPF
open Init
open Bindings

let designVm = ViewModel.designInstance (init () |> fst) (bindings ())
