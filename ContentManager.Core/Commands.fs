module ContentManager.Core.Commands

open ContentManager.Core
open Model

let GetDataCmd (m: Model) =
    fun dispatch ->
        async {
                ()
        } |> Async.StartImmediate