module Day01.Tests

open FsUnit.Xunit
open Xunit

open Day01

[<Fact>]
let ``Should find the product of the two entries whose sum equals 2020`` () =
    let expected = Some 514579

    "test-input.txt"
    |> expenseReport
    |> should equal expected

[<Fact>]
let ``Should find the product of the two entries for day 1`` () =
    let expected = Some 605364

    "input.txt"
    |> expenseReport
    |> should equal expected

[<Fact>]
let ``Should find the product of the three entries whose sum equals 2020`` () =
    let expected = Some 241861950

    "test-input.txt"
    |> expenseReport2
    |> should equal expected

[<Fact>]
let ``Should find the product of the three entries for day 1`` () =
    let expected = Some 128397680

    "input.txt"
    |> expenseReport2
    |> should equal expected
