module Day01

open System.IO

let private entries path =
    path
    |> File.ReadLines
    |> Seq.map int
    |> Seq.toArray

let rec private findAndProduct value items =
    items
    |> Seq.tryFind (List.sum >> (=) value)
    |> Option.map (List.reduce (*))

let expenseReport path =
    let values = entries path

    seq {
        for a in values do
            for b in values do
                [ a; b ]
    }
    |> findAndProduct 2020

let expenseReport2 path =
    let values = entries path

    seq {
        for a in values do
            for b in values do
                for c in values do
                    [ a; b; c ]
    }
    |> findAndProduct 2020
