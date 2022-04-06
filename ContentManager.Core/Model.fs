module ContentManager.Core.Model

open ContentManager.Core
open Types

type Model =
    { State: string
      Resent: string list
      Someprop: string
      DataPath: string option
      Context: Context option
      Sheets: Sheet list }
