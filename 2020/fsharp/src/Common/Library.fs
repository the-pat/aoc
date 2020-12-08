module Common

open System

let groupByLines (file: string) =
    file.Split([| Environment.NewLine + Environment.NewLine |], StringSplitOptions.RemoveEmptyEntries)
    |> Array.map (fun group ->
        group.Split([| Environment.NewLine |], StringSplitOptions.RemoveEmptyEntries)
        |> Array.toList)
    |> Array.toList

type Files() =
    member _.Item
        with get file = sprintf "data/%s.txt" file

let Files = Files()
