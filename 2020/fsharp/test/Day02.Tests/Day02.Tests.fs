module Day02.Tests

open Common
open FsUnit.Xunit
open Xunit

open Day02

[<Theory>]
[<InlineData("small", 2)>]
[<InlineData("large", 515)>]
let ``Part 1: Find the correct number of valid passwords`` (file, expected: int) =
    Files.[file]
    |> validPasswordCount
    |> should equal expected

[<Theory>]
[<InlineData("small", 1)>]
[<InlineData("large", 711)>]
let ``Part 2: Find the correct number of valid passwords`` (file, expected: int) =
    Files.[file]
    |> validPasswordCount2
    |> should equal expected
