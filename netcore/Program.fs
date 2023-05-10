open System.Diagnostics
open benchmarks

Runner.runAll
    Stopwatch.StartNew
    (fun sw ->
        sw.Stop()
        sw.Elapsed.TotalMilliseconds)
    ignore
    (printfn "%s")