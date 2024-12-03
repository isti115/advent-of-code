let input = System.IO.File.ReadAllText("2024/day-02/input")

let example =
    """
7 6 4 2 1
1 2 7 8 9
9 7 6 2 1
1 3 2 4 5
1 3 2 4 5
8 6 4 4 1
1 3 6 7 9
"""

// let data = example.Trim()
let data = input.Trim()

// let reports = data.Split('\n') |> Seq.map (_.Split(' ') >> Seq.map int >> Seq.toList)
let reports = data.Split('\n') |> Seq.map (_.Split(' ') >> Seq.map int)
reports

let isSafe (r: int seq) =
    let diffs = r |> Seq.windowed 2 |> Seq.map (fun [| l; r |] -> r - l)
    diffs |> Seq.forall (fun d -> abs d <= 3 && sign d = sign (diffs |> Seq.head))

reports |> Seq.filter isSafe |> Seq.length
