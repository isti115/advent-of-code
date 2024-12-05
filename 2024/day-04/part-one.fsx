let input = System.IO.File.ReadAllText("2024/day-04/input")

let example =
    """
MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX
"""

// let data = example.Trim()
let data = input.Trim()

let matrix = data.Split('\n') |> Array.map (Seq.toArray)

let shapes =
    seq {
        for x in -1 .. 1 do
            for y in -1 .. 1 do
                for i in 0..3 do
                    yield (i * x, i * y)
    }
    |> Seq.toList
    |> List.chunkBySize (4)
    |> List.toArray

shapes |> Array.map (fun s -> printfn "%A" s)

let getAt x y (m: char array array) s =
    try
        (s |> List.map (fun ((xo, yo)) -> m[x + xo][y + yo]))
    with _ ->
        []

let tryAt x y (m: char array array) s =
    try
        (s |> List.map (fun ((xo, yo)) -> m[x + xo][y + yo])) = [ 'X'; 'M'; 'A'; 'S' ]
    with _ ->
        false


// tryAt 6 0 matrix shapes[5]
shapes |> Array.map (fun s -> getAt 0 5 matrix s)

let positions =
    seq {
        for x in 0 .. matrix.Length do
            for y in 0 .. matrix[0].Length do
                yield (x, y)
    }

let results =
    seq {
        for x in 0 .. matrix.Length do
            for y in 0 .. matrix[0].Length do
                for s in shapes do
                    yield (tryAt x y matrix s)
    }

results |> Seq.filter id |> Seq.length
