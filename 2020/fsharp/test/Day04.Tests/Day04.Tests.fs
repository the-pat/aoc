module Day04.Tests

open FsUnit.Xunit
open Xunit

open Day04

[<Theory>]
[<InlineData("small", 2)>]
[<InlineData("large", 170)>]
let ``Part 1: Should find the correct number of valid passports`` (file, expected: int) =
    file
    |> sprintf "data/%s.txt"
    |> validPassportCount
    |> should equal expected

[<Theory>]
[<InlineData("invalid", 0)>]
[<InlineData("valid", 4)>]
[<InlineData("large", 103)>]
let ``Part 2: Should find the correct number of valid passports`` (file, expected: int) =
    file
    |> sprintf "data/%s.txt"
    |> validPassportCount2
    |> should equal expected
