module ContentManager.Core.Types

open Microsoft.FSharp.Core

type Item =
    {
        Id: int
        Name: string
        Value1: float
        Value2: float
        Sum: float
    }