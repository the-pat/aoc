module Common.Tests

open FsUnit.Xunit
open System.IO
open Xunit

open Common

[<Theory>]
[<InlineData("one-group", 1)>]
[<InlineData("two-groups", 2)>]
[<InlineData("three-groups", 3)>]
let ``Should have the correct number of groups`` (file, expected: int) =
    file
    |> (sprintf "data/%s.txt")
    |> File.ReadAllText
    |> groupByLines
    |> List.length
    |> should equal expected

[<Fact>]
let ``Should have the correct lines in the groups`` () =
    let expected =
        [ [ "a b c" ]
          [ "def" ]
          [ "g"; "h"; "i" ] ]

    "data/three-groups.txt"
    |> File.ReadAllText
    |> groupByLines
    |> should equal expected

[<Theory>]
[<InlineData(1, "data/1.txt")>]
[<InlineData("input", "data/input.txt")>]
let ``Should output the correct file path`` (file, expected) = Files.[file] |> should equal expected
