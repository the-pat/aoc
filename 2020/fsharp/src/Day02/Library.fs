module Day02

type Policy = int * int * char * string

let private parse (str: string): Policy =
    match str.Split [| ' '; ':'; '-' |] with
    | [| min; max; c; _; password |] -> ((int min), (int max), (char c), password)
    | _ -> (0, 0, ' ', "")

let private validate (min, max, c, password: string) =
    let amount =
        password
        |> Seq.filter (fun element -> element = c)
        |> Seq.length

    amount >= min && amount <= max

let validPasswordCount passwords =
    passwords
    |> Seq.map parse
    |> Seq.filter validate
    |> Seq.length

let private validate2 (p1, p2, c, password: string) =
    (password.[p1 - 1] = c) <> (password.[p2 - 1] = c)

let validPasswordCount2 passwords =
    passwords
    |> Seq.map parse
    |> Seq.filter validate2
    |> Seq.length
