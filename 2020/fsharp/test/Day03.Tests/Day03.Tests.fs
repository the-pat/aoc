module Day03.Tests

open Common
open FsUnit.Xunit
open Xunit

open Day03

[<Theory>]
[<InlineData("small", 7)>]
[<InlineData("large", 282)>]
let ``Part 1: Find the number of trees encountered on a single run`` (file, expected: int) =
    Files.[file] |> runs |> should equal expected

[<Theory>]
[<InlineData("small", 336)>]
[<InlineData("large", 958815792)>]
let ``Part 1: Find the product of trees encountered on multiple runs`` (file, expected: int) =
    Files.[file] |> runs2 |> should equal expected
