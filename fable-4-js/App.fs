module App

open Browser.Performance
open benchmarks

Runner.runAll
    performance.now
    (fun sw -> performance.now() - sw)
    ignore
    (printfn "%s")