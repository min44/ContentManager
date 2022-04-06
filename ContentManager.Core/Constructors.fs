module ContentManager.Core.Constructors

open System
open ContentManager.Core
open Types

[<RequireQualifiedAccess>]
module ItemConstructor =
    let Create name value1 value2 sum: Item =
        { Id = Random().Next(1000, 9999)
          Name = name
          Value1 = value1
          Value2 = value2
          Sum = sum }
    let Default() =
        { Id = Random().Next(1000, 9999)
          Name = "Default"
          Value1 = 0.0
          Value2 = 0.0
          Sum = 0.0 }
