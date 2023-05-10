module App

open Browser.Performance
open core

Runner.runAll
    performance.now
    (fun sw -> performance.now() - sw)
    ignore
    (printfn "%s")