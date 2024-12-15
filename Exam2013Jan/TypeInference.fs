module TypeInference

open Absyn

let failifne actual expected =
    if actual <> expected then failwith $"Expected typeof %A{expected} but got %A{actual}"
    else expected

let failmsg t op =
    failwith $"Type %A{t} was not expected with operator %s{op}"
let rec exprType e =
    match e with
    | Ia _ -> BYTE
    | Id _ -> BOOL
    | Cd _ -> WORD
    | False -> BOOL
    | True -> BOOL
    | CstI _ -> BYTE
    | Prim1(s, expr) ->
        match s with
        | "not" -> failifne (exprType expr) BOOL
        | _ -> failwith "unknown primitive"
    | Prim2(s, expr, expr1) ->
        let type1 = exprType expr
        let type2 = exprType expr1
        let resType = failifne type1 type2
        match s, resType with
        | a, BOOL when a = "+" || a = "-" -> failmsg BOOL "+"
        | a, _ when a = "+" || a = "-"-> resType
        | "and", t -> failifne t BOOL
        | "or", t -> failifne t BOOL
        | "=", _ -> resType
        | "<>", _ -> resType
        | "<", _ -> resType
        | _ -> failwith "unknown primitive"


let cmdType c =
    match c with
    | Sleep _ -> true
    | Set(Oa _, expr) ->
        failifne (exprType expr) BYTE |> ignore
        true
    | Set(Od _, expr) ->
        failifne (exprType expr) BOOL |> ignore
        true
    | Goto _ -> true
    | If(expr, _) ->
        failifne (exprType expr) BOOL |> ignore
        true
        
let labelCheck (p: program) =
    let labs = p |> List.map fst
    ([], p)
    ||> List.fold (fun acc (_, cmds) -> cmds @ acc)
    |> List.fold (fun acc cmd ->
        match cmd with
        | Goto lab -> acc && (List.contains lab labs)
        | If(_, lab) -> acc && (List.contains lab labs)
        | _ -> acc
        ) true