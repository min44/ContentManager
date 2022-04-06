module ContentManager.Utils.Debugs


let PrintSeq source = source |> Seq.iteri(fun i x -> Logger.Debug($"{i}: {x}"))