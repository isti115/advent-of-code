open System.Text.RegularExpressions

let input = System.IO.File.ReadAllText("2024/day-03/input")

let example =
    """
xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))
"""

// let data = example.Trim()
let data = input.Trim()

let inst = Regex.Matches(data, "mul\((\d+),(\d+)\)")

let nums =
    inst |> Seq.map (_.Groups >> Seq.tail >> Seq.map (_.Value >> int) >> Seq.toList)

nums

nums |> Seq.map (fun [ l; r ] -> l * r) |> Seq.sum
