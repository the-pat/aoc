module Day02.Tests

open FsUnit.Xunit
open Xunit

open Day02

let private input path = path |> System.IO.File.ReadLines

[<Fact>]
let ``Should return the correct number of valid passwords based on limits`` () =
    let expected: int = 2

    validPasswordCount [ "1-3 a: abcde"
                         "1-3 b: cdefg"
                         "2-9 c: ccccccccc" ]
    |> should equal expected

[<Fact>]
let ``Should return the correct number of valid passwords based on limits for day 2`` () =
    let expected: int = 515

    "input.txt"
    |> input
    |> validPasswordCount
    |> should equal expected

[<Fact>]
let ``Should return the correct number of valid passwords based on position`` () =
    let expected: int = 1

    validPasswordCount2 [ "1-3 a: abcde"
                          "1-3 b: cdefg"
                          "2-9 c: ccccccccc" ]
    |> should equal expected

[<Fact>]
let ``Should return the correct number of valid passwords based on position for day 2`` () =
    let expected: int = 711

    "input.txt"
    |> input
    |> validPasswordCount2
    |> should equal expected
