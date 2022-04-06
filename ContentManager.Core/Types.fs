module ContentManager.Core.Types

open System.Data
open Microsoft.FSharp.Core

type ItemLeft =
    {
        Name: string
        Value: float
        Sum: float
    }