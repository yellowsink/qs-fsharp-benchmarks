module App

open Fable.Python.Time
open benchmarks

let timer = time.monotonic >> (*) 1000.

Runner.runAll
    timer
    (fun sw -> timer() - sw)
    ignore
    (printfn "%s")