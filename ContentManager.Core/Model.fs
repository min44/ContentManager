module ContentManager.Core.Model

open ContentManager.Core
open ContentManager.Core.Types
open Types

type Model =
    { State: string
      Input: string
      Items: Item list
      Total: float }
