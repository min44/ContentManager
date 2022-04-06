module ContentManager.Core.Model

open ContentManager.Core
open Types

type Model =
    { State: string
      Input: string option }
