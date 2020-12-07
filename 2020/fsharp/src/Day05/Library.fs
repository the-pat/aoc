module Day05

open System.IO

let (|LowerHalf|UpperHalf|) =
    function
    | 'F'
    | 'L' -> UpperHalf
    | 'B'
    | 'R' -> LowerHalf
    | c -> failwithf "Bad indicator: %c" c

let private tickets path = File.ReadAllLines path

let binarySpaceParition (max: int) (indicators: string) =
    let row =
        ({| Min = 0; Max = max |}, indicators)
        ||> Seq.fold (fun row indicator ->
                let diff = (row.Max - row.Min) / 2 + 1

                match indicator with
                | UpperHalf -> {| row with Max = row.Max - diff |}
                | LowerHalf -> {| row with Min = row.Min + diff |})

    row.Min

let private findSeatId (ticket: string) =
    let row = binarySpaceParition 127 ticket.[..6]
    let column = binarySpaceParition 7 ticket.[7..]

    row * 8 + column

let private allSeats tickets = tickets |> Array.map findSeatId

let findHighestSeatId path = path |> tickets |> allSeats |> Array.max

let findMissingSeatId path =
    path
    |> tickets
    |> allSeats
    |> Array.sort
    |> Array.pairwise
    |> Array.find (fun (seatA, seatB) -> seatB - seatA > 1)
    |> fun (seatA, _) -> seatA + 1
