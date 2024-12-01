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

let pairs = lines |> Seq.map (fun l -> Regex.Match(l, "(\d+)\s+(\d+)"))

let numpairs = pairs |> Seq.map (_.Groups >> Seq.tail >> Seq.map (_.Value >> int))

let numtups = numpairs |> Seq.map (Seq.toList >> (fun [ l; r ] -> (l, r)))

let (ls, rs) = numtups |> Seq.toList |> List.unzip

let sls = ls |> Seq.sort
let srs = rs |> Seq.sort

Seq.zip sls srs |> Seq.map (fun (l, r) -> abs (l - r)) |> Seq.sum
