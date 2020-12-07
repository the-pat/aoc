module Day02

open System.IO

let private policies path =
    path
    |> File.ReadLines
    |> Seq.map (fun line ->
        let items = line.Split ' '
        let range = items.[0].Split '-'
        int range.[0], int range.[1], items.[1].[0], items.[2])

let private isValid (min, max, letter, password) =
    let occurances =
        password
        |> String.filter ((=) letter)
        |> String.length

    occurances >= min && occurances <= max

let validPasswordCount path =
    path
    |> policies
    |> Seq.filter isValid
    |> Seq.length

let private isValid2 (first, second, letter, password: string) =
    match password.[first - 1] = letter, password.[second - 1] = letter with
    | true, false
    | false, true -> true
    | _ -> false

let validPasswordCount2 path =
    path
    |> policies
    |> Seq.filter isValid2
    |> Seq.length
