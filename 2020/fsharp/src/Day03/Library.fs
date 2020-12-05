module Day03

let encounterTrees (slopeX, slopeY) (slope: string seq) =
    let hasTree (slopeX, slopeY) (index: int, landscape: string): bool =
        let down = (index / slopeY)
        let right = (down * slopeX) % landscape.Length

        index % slopeY = 0 && landscape.[right] = '#'

    slope
    |> Seq.indexed
    |> Seq.skip (1)
    |> Seq.filter (hasTree (slopeX, slopeY))
    |> Seq.length
