module ContentManager.Core.Types

open System.Data
open Microsoft.FSharp.Core

type ItemElement =
    { mutable Article: string
      mutable TypeId: int
      mutable Type: string
      mutable Name: string }

type ItemParameter =
    { mutable ParameterId: string
      mutable ValueType: string
      mutable DisplayName: string
      mutable RevitName: string }

type ItemType =
    { mutable TypeId: int
      mutable Name: string
      mutable Parameters: ItemParameter list }

type TypeParameter =
    { mutable Id: int
      mutable TypeId: int
      mutable ParameterId: string }

type ParameterValue =
    { mutable Id: int
      mutable Article: string
      mutable ParameterId: string
      mutable SomeProp: string
      mutable Value: string }
    static member Default() = ()

type Context =
    { mutable Elements: ItemElement list
      mutable Parameters: ItemParameter list
      mutable Types: ItemType list
      mutable TypeParameters: TypeParameter list
      mutable ParameterValues: ParameterValue list }
    
type Sheet =
    { Name: string
      DataTable: DataTable }