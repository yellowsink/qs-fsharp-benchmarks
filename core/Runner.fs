module core.Runner

let OVERHEAD_N = 10_000
let WARMUP_N = 1_000
let RESULTS_N = 5_000

let benchmarks =
    [|"binary tree", A1BinaryTrees.run
      //"coro sieve ", A2CoroSieve.run
      "e digits   ", A3EDigits.run
      "fannkuch   ", A4FannkuchRedux.run|]

let benchmarkNoOp _ _ = ()

let benchmark timerStart timerEnd log n func =
    let start = timerStart()
    
    for _ = 1 to n do
        func None log
    
    (timerEnd start) / (float n)

let runAll timerStart timerEnd logOut logBench =
    let inline benchmark n func = benchmark timerStart timerEnd logOut n func
    
    // measure overhead
    ignore <| benchmark WARMUP_N benchmarkNoOp
    let overhead = benchmark OVERHEAD_N benchmarkNoOp
    
    logBench $"benchmark overhead (x{OVERHEAD_N}): %.6f{overhead}μs\n\n"
    
    logBench $"benchmark\tresults (x{RESULTS_N})\n"
    
    for name, runBenchmark in benchmarks do
        ignore <|  benchmark WARMUP_N runBenchmark
        let results = benchmark RESULTS_N runBenchmark

        logBench $"{name}\t%9.3f{results - overhead}μs\n"