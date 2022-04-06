module ContentManager.Core.Messages

open Types

type Msg =
    | Rendered
    | SetInput of string
    | SetValue of int * int * float