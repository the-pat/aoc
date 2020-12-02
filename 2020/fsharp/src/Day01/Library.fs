module Day01

let rec expenseReport entries =
    match entries with
    | a :: tail ->
        match List.tryFind (fun otherEntry -> otherEntry = (2020 - a)) tail with
        | Some b -> Ok(a * b)
        | None -> expenseReport tail
    | [] -> Error "No entry found"

let rec private loop a tail =
    match tail with
    | b :: otherTail ->
        match List.tryFind (fun c -> c = (2020 - a - b)) otherTail with
        | Some c -> Some(b, c)
        | None -> loop a otherTail
    | [] -> None

let rec expenseReport2 entries =
    match entries with
    | a :: tail ->
        match loop a tail with
        | Some (b, c) -> Ok(a * b * c)
        | None -> expenseReport2 tail
    | [] -> Error "No entry found"
