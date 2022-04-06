module ContentManager.Core.Init

open ContentManager.Core
open Model

let init () =
    { State = "Hello!"
      Resent = []
      DataPath = None
      Context = None
      Sheets = []
    }, []
