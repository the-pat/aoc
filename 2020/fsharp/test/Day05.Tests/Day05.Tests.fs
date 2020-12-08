module Day05.Tests

open Common
open FsUnit.Xunit
open Xunit

[<Theory>]
[<InlineData("small", 357)>]
[<InlineData("medium", 820)>]
[<InlineData("large", 926)>]
let ``Part 1: Find the highest seat ID`` (file, expected) =
    Files.[file]
    |> findHighestSeatId
    |> should equal expected

[<Fact>]
let ``Part 2: Find your seat id`` () =
    let expected = 657

    Files.["large"]
    |> findMissingSeatId
    |> should equal expected
