module ContentManager.Core.Messages

open Types

type Msg =
    | Rendered
    | SetInput of string option