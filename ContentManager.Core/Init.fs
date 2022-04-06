module ContentManager.Core.Init

open System
open ContentManager.Core
open Model

let init (): Model * 'b list =
    { State = String.Empty
      Input = None }, []
