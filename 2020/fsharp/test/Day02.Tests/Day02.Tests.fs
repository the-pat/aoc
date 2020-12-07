module Day02.Tests

open FsUnit.Xunit
open Xunit

open Day02

[<Fact>]
let ``Should return the correct number of valid passwords based on limits`` () =
    let expected: int = 2

    "data/test-input.txt"
    |> validPasswordCount
    |> should equal expected

[<Fact>]
let ``Should return the correct number of valid passwords based on limits for day 2`` () =
    let expected: int = 515

    "data/input.txt"
    |> validPasswordCount
    |> should equal expected

[<Fact>]
let ``Should return the correct number of valid passwords based on position`` () =
    let expected: int = 1

    "data/test-input.txt"
    |> validPasswordCount2
    |> should equal expected

[<Fact>]
let ``Should return the correct number of valid passwords based on position for day 2`` () =
    let expected: int = 711

    "data/input.txt"
    |> validPasswordCount2
    |> should equal expected
