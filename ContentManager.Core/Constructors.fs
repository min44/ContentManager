module ContentManager.Core.Constructors

open System
open ContentManager.Core
open ContentManager.Core.Types
open Types

[<RequireQualifiedAccess>]
module ItemElementConstructor =
    let Create name value sum: ListItemLeft =
        { Name = name
          Value = value
          Sum = sum }
    let Default(): ListItemLeft =
        { Name = ""
          Value = 0.0
          Sum = 0.0 }