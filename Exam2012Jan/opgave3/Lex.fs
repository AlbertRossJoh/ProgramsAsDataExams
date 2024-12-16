
# 1 "Lex.fsl"
 
 (* 
    SimpLex a lexer specification for SIMPLC
    Albert Ross Johannessen
    2024
  *)

module Lex
open (*Microsoft.*) FSharp.Text.Lexing
open Util
open Par

let lexemeAsString lexbuf = 
    LexBuffer<char>.LexemeString lexbuf

(* Distinguish keywords from identifiers: *)

let keyword s =
    match s with
    | "STATES"  -> STATES
    | "TRANSITIONS"  -> TRANSITIONS
    | "PAYMENTS"  -> PAYMENTS
    | "WHILE"  -> WHILE
    | "UPON"  -> UPON
    | "RECEIVE"  -> RECEIVE
    | "PAY"  -> PAY
    | "YEAR"  -> YEAR
    | "MONTH"  -> MONTH
    | "PER"  -> PER
    | _       -> NAME s


# 35 "Lex.fs"
let trans : uint16[] array = 
    [| 
    (* State 0 *)
     [| 9us;9us;9us;9us;9us;9us;9us;9us;9us;1us;2us;9us;9us;1us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;1us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;6us;7us;9us;9us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;5us;9us;9us;9us;9us;9us;9us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;9us;9us;9us;9us;9us;9us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;4us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;9us;8us;|];
    (* State 1 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    (* State 2 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    (* State 3 *)
     [| 13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;14us;14us;14us;14us;14us;14us;14us;14us;14us;14us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;65535us;|];
    (* State 4 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;65535us;65535us;65535us;65535us;65535us;65535us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    (* State 5 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    (* State 6 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    (* State 7 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;10us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    (* State 8 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    (* State 9 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    (* State 10 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;11us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    (* State 11 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    (* State 12 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;65535us;65535us;65535us;65535us;65535us;65535us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;12us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    (* State 13 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;15us;15us;15us;15us;15us;15us;15us;15us;15us;15us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    (* State 14 *)
     [| 13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;18us;18us;18us;18us;18us;18us;18us;18us;18us;18us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;65535us;|];
    (* State 15 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;16us;16us;16us;16us;16us;16us;16us;16us;16us;16us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    (* State 16 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;17us;17us;17us;17us;17us;17us;17us;17us;17us;17us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    (* State 17 *)
     [| 13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;65535us;|];
    (* State 18 *)
     [| 13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;19us;19us;19us;19us;19us;19us;19us;19us;19us;19us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;65535us;|];
    (* State 19 *)
     [| 65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;20us;20us;20us;20us;20us;20us;20us;20us;20us;20us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;|];
    (* State 20 *)
     [| 13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;21us;21us;21us;21us;21us;21us;21us;21us;21us;21us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;65535us;|];
    (* State 21 *)
     [| 13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;22us;22us;22us;22us;22us;22us;22us;22us;22us;22us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;65535us;|];
    (* State 22 *)
     [| 13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;19us;19us;19us;19us;19us;19us;19us;19us;19us;19us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;13us;65535us;|];
    |] 
let actions : uint16[] = [|65535us;0us;1us;2us;3us;4us;5us;8us;7us;8us;65535us;6us;3us;65535us;2us;65535us;65535us;2us;2us;65535us;2us;2us;2us;|]
let _fslex_tables = FSharp.Text.Lexing.UnicodeTables.Create(trans,actions)
let rec _fslex_dummy () = _fslex_dummy() 
// Rule Token
and Token  lexbuf =
  match _fslex_tables.Interpret(0,lexbuf) with
  | 0 -> ( 
# 35 "Lex.fsl"
                                     Token lexbuf 
# 94 "Lex.fs"
          )
  | 1 -> ( 
# 36 "Lex.fsl"
                                     lexbuf.EndPos <- lexbuf.EndPos.NextLine; Token lexbuf 
# 99 "Lex.fs"
          )
  | 2 -> ( 
# 37 "Lex.fsl"
                                                                                                                    
                     CSTINT (System.Int32.Parse (lexemeAsString lexbuf |> filterUnderscore)) 
                     
# 106 "Lex.fs"
          )
  | 3 -> ( 
# 40 "Lex.fsl"
                                                             keyword (lexemeAsString lexbuf) 
# 111 "Lex.fs"
          )
  | 4 -> ( 
# 41 "Lex.fsl"
                                     COLON 
# 116 "Lex.fs"
          )
  | 5 -> ( 
# 42 "Lex.fsl"
                                     COMMA 
# 121 "Lex.fs"
          )
  | 6 -> ( 
# 43 "Lex.fsl"
                                      TO 
# 126 "Lex.fs"
          )
  | 7 -> ( 
# 44 "Lex.fsl"
                                     EOF 
# 131 "Lex.fs"
          )
  | 8 -> ( 
# 45 "Lex.fsl"
                                     failwith ("Lexer error: illegal symbol "+(lexemeAsString lexbuf)) 
# 136 "Lex.fs"
          )
  | _ -> failwith "Token"

# 3000000 "Lex.fs"
