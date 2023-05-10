module core.A1BinaryTrees

let MIN_DEPTH = 4

type TreeNode =
    { left: TreeNode option
      right: TreeNode option }

let rec check node =
    (node.left |> Option.map check |> Option.defaultValue 1)
    + (node.right |> Option.map check |> Option.defaultValue 1)

let rec createNode depth =
    if depth = 0 then
        { left = None; right = None }
    else
        let d = depth - 1

        { left = Some(createNode d)
          right = Some(createNode d) }

let run n logger =
    let n = Option.defaultValue 10 n

    let maxDepth = max (MIN_DEPTH + 2) n
    let stretchDepth = maxDepth + 1

    let stretchTree = createNode stretchDepth

    logger $"stretch tree of depth %d{stretchDepth}\tcheck: %d{check stretchTree}"

    let longLivedTree = createNode maxDepth

    for depth in seq { MIN_DEPTH..2 .. maxDepth + 1 } do

        let iterations = 1 <<< (maxDepth - depth + MIN_DEPTH)

        let sum =
            seq { 1..iterations }
            |> Seq.sumBy (fun _ -> createNode depth |> check)

        logger $"%d{iterations}\ttrees of depth %d{depth}\tcheck: %d{sum}"

    logger $"long lived tree of depth %d{maxDepth}\tcheck: %d{check longLivedTree}"