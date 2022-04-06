module ContentManager.Core.App

open Elmish
open Elmish.WPF
open Init
open Update
open Bindings

let Run window =
    Program.mkProgramWpf
        init
        update
        bindings
    |> Program.startElmishLoop ElmConfig.Default window