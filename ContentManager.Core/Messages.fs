module ContentManager.Core.Messages

open Types

type Msg =
    | Rendered
    | SetState of string
    | CreateDataFileCommand
    | OpenDataFileCommand
    | SaveDataFileCommand
    | SetDataPath of string option
    | SetResent of string list
    | SetContext of Context option