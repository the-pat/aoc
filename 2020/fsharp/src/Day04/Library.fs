module Day04

open FsToolkit.ErrorHandling
open System
open System.IO

type PassportType =
    | Normal
    | NorthPole

let (|Digits|_|) length (text: string) =
    if text.Length = length
       && Seq.forall Char.IsDigit text then
        Some Digits
    else
        None

let (|AtLeast|_|) min (text: string) =
    if int text >= min then Some AtLeast else None

let (|AtMost|_|) max (text: string) =
    if int text <= max then Some AtMost else None

let (|Between|_|) min max =
    function
    | AtLeast min & AtMost max -> Some Between
    | _ -> None

let (|Hexadecimal|_|) c =
    if Char.IsDigit c
       || Array.contains c [| 'a' .. 'f' |] then
        Some Hexadecimal
    else
        None

let (|HasHeight|) (text: string) =
    match Seq.tryFindIndex (Char.IsDigit >> not) text with
    | Some position ->
        let numbers = text.[..position - 1]
        let unit = text.[position..]
        HasHeight(numbers, unit)
    | None -> HasHeight(text, "")

let (|Chars|) (text: string) = Chars(Seq.toList text)

type PassportField =
    | BirthYear
    | IssueYear
    | ExpirationYear
    | Height
    | HairColour
    | EyeColour
    | PassportId
    | CountryId

    static member ParseSimple(text: string) =
        match List.ofArray (text.Split ':') with
        | [ "byr"; _ ] -> Ok BirthYear
        | [ "iyr"; _ ] -> Ok IssueYear
        | [ "eyr"; _ ] -> Ok ExpirationYear
        | [ "hgt"; _ ] -> Ok Height
        | [ "hcl"; _ ] -> Ok HairColour
        | [ "ecl"; _ ] -> Ok EyeColour
        | [ "pid"; _ ] -> Ok PassportId
        | [ "cid"; _ ] -> Ok CountryId
        | header -> Error(sprintf "Invalid %A" header)

    static member Parse(text: string) =
        match List.ofArray (text.Split ':') with
        | [ "byr"; Digits 4 & Between 1920 2002 ] -> Ok BirthYear
        | [ "iyr"; Digits 4 & Between 2010 2020 ] -> Ok IssueYear
        | [ "eyr"; Digits 4 & Between 2020 2030 ] -> Ok ExpirationYear
        | [ "hgt";
            HasHeight (Between 150 193, "cm"
            | Between 59 76, "in") ] -> Ok Height
        | [ "hcl"; Chars [ '#'; Hexadecimal; Hexadecimal; Hexadecimal; Hexadecimal; Hexadecimal; Hexadecimal ] ] ->
            Ok HairColour
        | [ "ecl";
            ("amb"
            | "blu"
            | "brn"
            | "gry"
            | "grn"
            | "hzl"
            | "oth") ] -> Ok EyeColour
        | [ "pid"; Digits 9 ] -> Ok PassportId
        | [ "cid"; _ ] -> Ok CountryId
        | header -> Error(sprintf "Invalid %A" header)

let private groupByLines (file: string) =
    file.Split([| Environment.NewLine + Environment.NewLine |], StringSplitOptions.RemoveEmptyEntries)
    |> Array.map (fun group ->
        group.Split([| Environment.NewLine |], StringSplitOptions.RemoveEmptyEntries)
        |> Array.toList)
    |> Array.toList

let private passports path = path |> File.ReadAllText |> groupByLines

let private parseFile parser lines =
    lines
    |> List.collect (fun (line: string) -> line.Split ' ' |> Array.toList)
    |> List.traverseResultA parser

let private validate (file: PassportField list) =
    let file = Set file

    if file.Count = 8 then Ok Normal
    elif file.Count = 7 && not (file.Contains CountryId) then Ok NorthPole
    else Error [ "bad fields" ]

let private parseFiles parser path =
    path
    |> passports
    |> List.map (fun group -> group |> parseFile parser |> Result.bind validate)

let private countOk results =
    results |> List.filter Result.isOk |> List.length

let validPassportCount path =
    path
    |> parseFiles PassportField.ParseSimple
    |> countOk

let validPassportCount2 path =
    path |> parseFiles PassportField.Parse |> countOk
