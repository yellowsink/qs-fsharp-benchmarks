open System.Diagnostics
open core

Runner.runAll
    Stopwatch.StartNew
    (fun sw ->
        sw.Stop()
        sw.Elapsed.TotalMicroseconds)
    ignore
    (printf "%s")