module Tests

open FsUnit.Xunit
open Xunit

open Day06

[<Theory>]
[<InlineData("small", 6)>]
[<InlineData("medium", 11)>]
[<InlineData("large", 6809)>]
let ``Part 1: Find the sum of the distinct "yes" questions per group`` (file, expected: int) =
    file
    |> sprintf "data/%s.txt"
    |> countYesesPerGroup
    |> should equal expected

[<Theory>]
[<InlineData("small", 3)>]
[<InlineData("medium", 6)>]
[<InlineData("large", 3394)>]
let ``Part 2: Find the sum of the questions that everyone answered "yes" to per group`` (file, expected: int) =
    file
    |> sprintf "data/%s.txt"
    |> countAllYesesPerGroup
    |> should equal expected
