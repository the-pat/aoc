module Day03.Tests

open FsUnit.Xunit
open Xunit

[<Fact>]
let ``My test`` () =
    let expected = true

    true |> should equal expected
