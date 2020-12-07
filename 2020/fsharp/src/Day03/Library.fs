module Day03

open System.IO

let private slope path =
    path
    |> File.ReadAllLines
    |> Array.map (fun line ->
        seq {
            while true do
                yield! line
        })

let private run (slope: seq<char> []) (right, down) =
    let rows =
        List.indexed [ 0 .. down .. (slope.Length - 1) ]

    [ for (yCoordinate, row) in rows do
        let xCoordinate = yCoordinate * right
        (yCoordinate, row, xCoordinate), slope.[row] |> Seq.item xCoordinate ]
    |> List.filter (snd >> (=) '#')
    |> List.length

let runs path =
    let slope = slope path

    run slope (3, 1)

let runs2 path =
    let slope = slope path

    [ (1, 1)
      (3, 1)
      (5, 1)
      (7, 1)
      (1, 2) ]
    |> List.map (run slope)
    |> List.reduce (*)
