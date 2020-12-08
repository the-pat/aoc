module Day01.Tests

open Common
open FsUnit.Xunit
open Xunit

open Day01

[<Theory>]
[<InlineData("small", 514579)>]
[<InlineData("large", 605364)>]
let ``Part 1: Find the product of 2 entries that sum to equal 2020`` (file, expected: int) =
    Files.[file]
    |> expenseReport
    |> should equal (Some expected)

[<Theory>]
[<InlineData("small", 241861950)>]
[<InlineData("large", 128397680)>]
let ``Part 2: Find the product of 3 entries that sum to equal 2020`` (file, expected: int) =
    Files.[file]
    |> expenseReport2
    |> should equal (Some expected)
