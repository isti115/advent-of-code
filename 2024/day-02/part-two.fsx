let input = System.IO.File.ReadAllText("2024/day-02/input")

let example =
    """
7 6 4 2 1
1 2 7 8 9
9 7 6 2 1
1 3 2 4 5
8 6 4 4 1
1 3 6 7 9
"""

// let data = example.Trim()
let data = input.Trim()

// let reports = data.Split('\n') |> Seq.map (_.Split(' ') >> Seq.map int >> Seq.toList)
let reports = data.Split('\n') |> Seq.map (_.Split(' ') >> Seq.map int)
reports

let isSafe (rs: int seq) =
    let r = rs |> Seq.toList
    let diffs = r |> List.windowed 2 |> List.map (fun [ l; r ] -> r - l)
    diffs |> List.forall (fun d -> abs d <= 3 && sign d = sign (diffs |> List.head))

let dampen (r: int seq) =
    r
    |> Seq.mapi (fun i _ -> (Seq.take i r |> Seq.toList) @ (Seq.skip (i + 1) r |> Seq.toList))

reports |> Seq.map dampen |> Seq.filter (Seq.exists isSafe) |> Seq.length
