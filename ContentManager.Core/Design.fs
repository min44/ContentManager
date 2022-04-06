module ContentManager.Core.Design

open Elmish.WPF
open Bindings
open Model

let initVm =
    { State = "Initial State"
      Input = "Hello world"
      Items = []
      Total = 0.0 }
let designVm = ViewModel.designInstance initVm (bindings ())
