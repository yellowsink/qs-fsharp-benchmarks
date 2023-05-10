module core.A3EDigits

let LN10 = log 10.

let testK n k =
    if k < 0 then
        false
    else
        let k = float k
        let lnKFactorial = k * (log k - 1.) + 0.5 * log (System.Math.PI * 2.)
        let log10KFactorial = lnKFactorial / LN10

        log10KFactorial >= float (n + 50)

let binarySearch n =

    let rec buildBounds (a, b) =
        if testK n b then
            (a, b)
        else
            buildBounds (b, b * 2)

    let rec binSearch (a, b) =
        if (b - a) > 1 then
            let m = (a + b) / 2

            if testK n m then (a, m) else (m, b)
        else
            (a, b)

    (0, 1) |> buildBounds |> binSearch |> snd

let rec sumTerms a b =
  if b = (a + 1) then
      bigint 1, bigint b
  else
    let mid = (a + b) / 2
    let tLeftA, tLeftB = sumTerms a mid
    let tRightA, tRightB = sumTerms mid b

    tLeftA * tRightB + tRightA, tLeftB * tRightB

let run n logger =
    let n = Option.defaultValue 10000 n

    let k = binarySearch n
    let p, q = sumTerms 0 (k - 1)
    let p = p + q

    let a = "1" + System.String.Join("", Seq.replicate (n - 2) "0")

    let s = p * (bigint.Parse a) / q |> string

    let mutable i = 0
    while i + 10 <= n do
      let end_ = i + 10
      logger $"%s{s.[0..end_]}\t:%d{end_}"

      i <- end_

    let remLen = n - i
    if remLen > 0 then
      let padding = System.String.Join("", Seq.replicate (10 - remLen) " ")

      logger $"%s{s.[i..n]}%s{padding}\t:%d{n}"