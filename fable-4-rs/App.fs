module App

open System
open core

[<EntryPoint>]
let main _ =
    Runner.runAll
        (fun() -> DateTime.Now.Ticks)
        (fun sw -> float (DateTime.Now.Ticks - sw) / 10_000.)
        ignore
        (printfn "%s")
    
    0