open System.Diagnostics
open core

Runner.runAll
    Stopwatch.StartNew
    (fun sw ->
        sw.Stop()
        sw.Elapsed.TotalMilliseconds)
    ignore
    (printf "%s")