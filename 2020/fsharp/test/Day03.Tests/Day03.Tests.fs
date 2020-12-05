module Day03.Tests

open FsUnit.Xunit
open Xunit

open Day03

let private input path = path |> System.IO.File.ReadLines

[<Fact>]
let ``Should encounter 7 trees on the given slope while going right 3 and down 1`` () =
    let expected = 7

    encounterTrees
        (3, 1)
        [ "..##......."
          "#...#...#.."
          ".#....#..#."
          "..#.#...#.#"
          ".#...##..#."
          "..#.##....."
          ".#.#.#....#"
          ".#........#"
          "#.##...#..."
          "#...##....#"
          ".#..#...#.#" ]
    |> should equal expected

[<Fact>]
let ``Should encounter 282 trees on the given slope while going right 3 and down 1`` () =
    let expected = 282

    "input.txt"
    |> input
    |> (encounterTrees (3, 1))
    |> should equal expected


[<Fact>]
let ``Should encounter 336 trees on the given slope while traversing at different angles`` () =
    let expected = 336

    [ (1, 1)
      (3, 1)
      (5, 1)
      (7, 1)
      (1, 2) ]
    |> Seq.map (fun angle ->
        encounterTrees
            angle
            [ "..##......."
              "#...#...#.."
              ".#....#..#."
              "..#.#...#.#"
              ".#...##..#."
              "..#.##....."
              ".#.#.#....#"
              ".#........#"
              "#.##...#..."
              "#...##....#"
              ".#..#...#.#" ])
    |> Seq.fold (*) 1
    |> should equal expected

[<Fact>]
let ``Should encounter 958815792 trees on the given slope while traversing at different angles`` () =
    let expected = 958815792

    [ (1, 1)
      (3, 1)
      (5, 1)
      (7, 1)
      (1, 2) ]
    |> Seq.map (fun angle -> encounterTrees angle (input "input.txt"))
    |> Seq.fold (*) 1
    |> should equal expected
