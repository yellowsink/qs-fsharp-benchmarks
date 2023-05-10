module App

open Fable.Core
open benchmarks

[<Erase>]
type IDateTimeApi = abstract now: unit -> {| microsecondsSinceEpoch: int |}

[<Global>]
let private DateTime: IDateTimeApi = nativeOnly

let private timer() = DateTime.now().microsecondsSinceEpoch

[<Global>]
let private print = nativeOnly

[<EntryPoint>]
let main _ =
    Runner.runAll
        timer
        (fun sw -> float (timer() - sw) / 1000.)
        ignore
        print
    
    0