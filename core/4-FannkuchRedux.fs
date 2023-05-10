module core.A4FannkuchRedux

let flip n (a: _[]) =
    for i = 0 to n / 2 do
        let t = a[i]
        let k = n - i
        a[i] <- a[k]
        a[k] <- t

let rec count c (ary: _[]) =
    let z = ary[0]
    if z <> 0 then
        flip z ary
        count (c + 1) ary
    else
        c

let rotate n (a: _[]) =
    let t = a[0]
    let m = n - 1
    
    for i = 1 to m do
        a[i-1] <- a[i]
        
    a[m] <- t

let iter_perms n f =
    let rec do_iter (num: _ ref) (perm: _[]) (copy: _[]) f ht =
        if ht = 1 then
            for i = 0 to n - 1 do
                copy[i] <- perm[i]

            f num.Value copy
            // ew mutation
            num.Value <- num.Value + 1

        else
            for _ = 1 to ht do
                do_iter num perm copy f (ht - 1)
                rotate ht perm

    let perm = [|0 .. n - 1|]
    let copy = Array.replicate n 0

    do_iter (ref 0) perm copy f n

let run n logger =
    let n = Option.defaultValue 8 n

    let mutable csum = 0
    let mutable m = 0

    iter_perms n (fun num a ->
        let c = count 0 a
        csum <- csum + c * (1 - (num &&& 1) <<< 1)
        if c > m then m <- c)
    
    logger $"{csum}nPfannkuchen({n}) = {m}"