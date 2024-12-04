open System.Text.RegularExpressions

let input = System.IO.File.ReadAllText("2024/day-03/input")

let example =
    """
xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))
"""

// let example2 =
//     """
// xmul(2,4)&mul[3,7]!^don't()_mul(5,5)don't()+mul(32,64](mul(11,8)undo()?mul(8,5))
// """
//
// example2.Split("don't()")

// let data = example.Trim()
let data = input.Trim()

data.Split("don't()")
let joined = Regex.Replace(data, "\n", "")
let pre = Regex.Replace(joined, "don't\(\).*?do\(\)", "")
let post = Regex.Replace(pre, "don't\(\).*?$", "")

let inst = Regex.Matches(post, "mul\((\d+),(\d+)\)")

let nums =
    inst |> Seq.map (_.Groups >> Seq.tail >> Seq.map (_.Value >> int) >> Seq.toList)

nums

nums |> Seq.map (fun [ l; r ] -> l * r) |> Seq.sum

// Too high:
// 94286334

// Answer:
// 74838033
