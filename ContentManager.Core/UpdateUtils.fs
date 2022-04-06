module ContentManager.Core.UpdateUtils

open ContentManager.Core
open Constructors
open Types
open Model
let GetItems() = [0..100] |> List.map(fun _ -> ItemConstructor.Default())

let SetValue model valueIndex id value =

    let setValue item =
        match valueIndex with
        | 1 -> { item with Value1 = value }
        | 2 -> { item with Value2 = value }
        | _ -> item
        
    let map item = if item.Id = id then setValue item else item
    let model = { model with Items = List.map map model.Items }
    let sum item = { item with Sum = item.Value2 + (model.Items |> Seq.sumBy(fun x -> x.Value1)) }
    let model = { model with Items = model.Items |> List.map sum }
    { model with Total = model.Items |> Seq.sumBy(fun x -> x.Sum) }