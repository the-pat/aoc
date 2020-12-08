module Day06

open Common
open System
open System.IO

let private answers path = path |> File.ReadAllText |> groupByLines

let countYesesPerGroup path =
    path
    |> answers
    |> List.map (fun group ->
        group
        |> List.collect (fun line -> line.ToCharArray() |> List.ofArray)
        |> Set)
    |> List.sumBy Set.count

let countAllYesesPerGroup path =
    path
    |> answers
    |> List.sumBy (fun group ->
        group
        |> List.map (fun line -> line.ToCharArray())
        |> Array.concat
        |> Array.countBy id
        |> Array.filter (snd >> (=) group.Length)
        |> Array.length)
