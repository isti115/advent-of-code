open System.Text.RegularExpressions

let input = System.IO.File.ReadAllText("./2024/day-01/input")

let example =
    """
3   4
4   3
2   5
1   3
3   9
3   3
"""

// let data = example.Trim()
let data = input.Trim()

let lines = data.Split('\n')

let pairs = lines |> Seq.map (fun l -> Regex.Matches(l, "(\d+)\s+(\d+)"))

let numpairs =
    pairs |> Seq.map (Seq.head >> _.Groups >> Seq.tail >> Seq.map (_.Value >> int))

let numtups = numpairs |> Seq.map (fun p -> (Seq.head p, p |> Seq.tail |> Seq.head))

let (ls, rs) =
    numtups |> Seq.fold (fun (ls, rs) (l, r) -> (l :: ls, r :: rs)) ([], [])

let sls = ls |> Seq.sort
let srs = rs |> Seq.sort

sls

let grs =
    srs
    |> Seq.groupBy (fun r -> r)
    |> Seq.map (fun (n, ns) -> (n, Seq.length ns))
    |> Map

grs

let gls = ls |> Seq.map (fun l -> l * (Map.tryFind l grs |> Option.defaultValue 0))
gls |> Seq.sum
