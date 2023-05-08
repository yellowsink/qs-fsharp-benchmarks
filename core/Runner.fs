module core.Runner

let inline avgAfter amount arr =
    let sum = arr |> Seq.skip amount |> Seq.sum
    let len = float <| Array.length arr - 1
    sum / len

let inline logTime log name times =
    Array.append times [|avgAfter 1 times|]
    |> Array.map (fun f -> sprintf $"\t%9.3f{f}μs")
    |> String.concat ""
    |> (fun s -> sprintf $"%s{name}%s{s}\n")
    |> log

let benchmarks =
    [|"binary tree", A1BinaryTrees.run
      "coro sieve ", A2CoroSieve.run
      "e digits   ", A3EDigits.run|]

let runAll timerStart timerEnd logOut logBench =
    [|"benchmark"; "warmup"; "run 1"; "run 2"; "run 3"; "run 4"; "run 5"; "mean"|]
    // curried sprintf doesnt work with nativeaot
    |> Array.map (fun s -> sprintf $"%9s{s}")
    |> String.concat "\t"
    |> logBench
    
    logBench "\n"
    
    for name, runBenchmark in benchmarks do
        let results =
            [|0..5|]
            |> Array.map (fun _ ->
                let start = timerStart ()
                runBenchmark None logOut
                let res = timerEnd start

                res)

        logTime logBench name results