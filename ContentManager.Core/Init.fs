module ContentManager.Core.Init

open System
open ContentManager.Core
open Model

let init () =
    { State = String.Empty
      Input = String.Empty
      Items = []
      Total = 0.0 }, []
