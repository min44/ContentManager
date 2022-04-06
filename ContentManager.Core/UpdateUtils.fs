module ContentManager.Core.UpdateUtils

open ContentManager.Core
open Model

let SetDataPath m =
    function
    | Some path ->
        let index = List.findIndex((=) path) m.Resent
        { m with
              DataPath = Some path
              Resent = path :: List.removeAt index m.Resent }
    | None -> m