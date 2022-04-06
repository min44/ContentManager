module ContentManager.Core.Commands

open ContentManager.Core
open Model
open Messages

let CalculateTotalCmd (m: Model) = fun dispatch ->
    async {
        let action() = dispatch <| SetInput "Some string"
        
        
        ()
    } |> Async.StartImmediate