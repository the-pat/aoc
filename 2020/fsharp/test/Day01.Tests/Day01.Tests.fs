module Day01.Tests

open FsUnit.Xunit
open Xunit


[<Fact>]
let ``Should find the product of the two entries whose sum equals 2020`` () =
    let expected: Result<int, string> = Ok 514579

    expenseReport [ 1721
                    979
                    366
                    299
                    675
                    1456 ]
    |> should equal expected

[<Fact>]
let ``Should find the product of the two entries for day 1`` () =
    let expected: Result<int, string> = Ok 605364

    Input.entries ()
    |> expenseReport
    |> should equal expected

[<Fact>]
let ``Should find the product of the three entries whose sum equals 2020`` () =
    let expected: Result<int, string> = Ok 241861950

    expenseReport2 [ 1721
                     979
                     366
                     299
                     675
                     1456 ]
    |> should equal expected

[<Fact>]
let ``Should find the product of the three entries for day 1`` () =
    let expected: Result<int, string> = Ok 128397680

    Input.entries ()
    |> expenseReport2
    |> should equal expected
