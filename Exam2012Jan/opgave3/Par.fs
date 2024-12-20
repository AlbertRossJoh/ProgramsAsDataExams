// Implementation file for parser generated by fsyacc
module Par
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open FSharp.Text.Lexing
open FSharp.Text.Parsing.ParseHelpers
# 1 "Par.fsy"

(*	File ListC/CPar.fsy 
	Parser specification for list-C, a small imperative language with lists
	sestoft@itu.dk * 2009-10-18
	No (real) shift/reduce conflicts thanks to Niels Kokholm.
*)

open Absyn;


# 17 "Par.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | PER
  | YEAR
  | MONTH
  | WHILE
  | UPON
  | RECEIVE
  | PAY
  | STATES
  | TRANSITIONS
  | PAYMENTS
  | EOF
  | COLON
  | TO
  | COMMA
  | CSTINT of (int)
  | NAME of (string)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_PER
    | TOKEN_YEAR
    | TOKEN_MONTH
    | TOKEN_WHILE
    | TOKEN_UPON
    | TOKEN_RECEIVE
    | TOKEN_PAY
    | TOKEN_STATES
    | TOKEN_TRANSITIONS
    | TOKEN_PAYMENTS
    | TOKEN_EOF
    | TOKEN_COLON
    | TOKEN_TO
    | TOKEN_COMMA
    | TOKEN_CSTINT
    | TOKEN_NAME
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startMain
    | NONTERM_Main
    | NONTERM_States
    | NONTERM_Transitions
    | NONTERM_Dir
    | NONTERM_Time
    | NONTERM_Payments

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | PER  -> 0 
  | YEAR  -> 1 
  | MONTH  -> 2 
  | WHILE  -> 3 
  | UPON  -> 4 
  | RECEIVE  -> 5 
  | PAY  -> 6 
  | STATES  -> 7 
  | TRANSITIONS  -> 8 
  | PAYMENTS  -> 9 
  | EOF  -> 10 
  | COLON  -> 11 
  | TO  -> 12 
  | COMMA  -> 13 
  | CSTINT _ -> 14 
  | NAME _ -> 15 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_PER 
  | 1 -> TOKEN_YEAR 
  | 2 -> TOKEN_MONTH 
  | 3 -> TOKEN_WHILE 
  | 4 -> TOKEN_UPON 
  | 5 -> TOKEN_RECEIVE 
  | 6 -> TOKEN_PAY 
  | 7 -> TOKEN_STATES 
  | 8 -> TOKEN_TRANSITIONS 
  | 9 -> TOKEN_PAYMENTS 
  | 10 -> TOKEN_EOF 
  | 11 -> TOKEN_COLON 
  | 12 -> TOKEN_TO 
  | 13 -> TOKEN_COMMA 
  | 14 -> TOKEN_CSTINT 
  | 15 -> TOKEN_NAME 
  | 18 -> TOKEN_end_of_input
  | 16 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startMain 
    | 1 -> NONTERM_Main 
    | 2 -> NONTERM_States 
    | 3 -> NONTERM_States 
    | 4 -> NONTERM_States 
    | 5 -> NONTERM_Transitions 
    | 6 -> NONTERM_Transitions 
    | 7 -> NONTERM_Dir 
    | 8 -> NONTERM_Dir 
    | 9 -> NONTERM_Time 
    | 10 -> NONTERM_Time 
    | 11 -> NONTERM_Payments 
    | 12 -> NONTERM_Payments 
    | 13 -> NONTERM_Payments 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 18 
let _fsyacc_tagOfErrorTerminal = 16

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | PER  -> "PER" 
  | YEAR  -> "YEAR" 
  | MONTH  -> "MONTH" 
  | WHILE  -> "WHILE" 
  | UPON  -> "UPON" 
  | RECEIVE  -> "RECEIVE" 
  | PAY  -> "PAY" 
  | STATES  -> "STATES" 
  | TRANSITIONS  -> "TRANSITIONS" 
  | PAYMENTS  -> "PAYMENTS" 
  | EOF  -> "EOF" 
  | COLON  -> "COLON" 
  | TO  -> "TO" 
  | COMMA  -> "COMMA" 
  | CSTINT _ -> "CSTINT" 
  | NAME _ -> "NAME" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | PER  -> (null : System.Object) 
  | YEAR  -> (null : System.Object) 
  | MONTH  -> (null : System.Object) 
  | WHILE  -> (null : System.Object) 
  | UPON  -> (null : System.Object) 
  | RECEIVE  -> (null : System.Object) 
  | PAY  -> (null : System.Object) 
  | STATES  -> (null : System.Object) 
  | TRANSITIONS  -> (null : System.Object) 
  | PAYMENTS  -> (null : System.Object) 
  | EOF  -> (null : System.Object) 
  | COLON  -> (null : System.Object) 
  | TO  -> (null : System.Object) 
  | COMMA  -> (null : System.Object) 
  | CSTINT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | NAME _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us;65535us;1us;65535us;0us;1us;2us;65535us;2us;3us;9us;10us;2us;65535us;4us;5us;15us;16us;2us;65535us;22us;23us;29us;30us;1us;65535us;25us;26us;3us;65535us;6us;7us;26us;27us;31us;32us;|]
let _fsyacc_sparseGotoTableRowOffsets = [|0us;1us;3us;6us;9us;12us;14us;|]
let _fsyacc_stateToProdIdxsTableElements = [| 1us;0us;1us;0us;1us;1us;1us;1us;1us;1us;1us;1us;1us;1us;1us;1us;2us;3us;4us;1us;3us;1us;3us;1us;6us;1us;6us;1us;6us;1us;6us;1us;6us;1us;6us;1us;7us;1us;8us;1us;9us;1us;10us;1us;12us;1us;12us;1us;12us;1us;12us;1us;12us;1us;12us;1us;12us;1us;13us;1us;13us;1us;13us;1us;13us;1us;13us;|]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us;2us;4us;6us;8us;10us;12us;14us;16us;19us;21us;23us;25us;27us;29us;31us;33us;35us;37us;39us;41us;43us;45us;47us;49us;51us;53us;55us;57us;59us;61us;63us;65us;|]
let _fsyacc_action_rows = 33
let _fsyacc_actionTableElements = [|1us;32768us;7us;2us;0us;49152us;1us;16386us;15us;8us;1us;32768us;8us;4us;1us;16389us;15us;11us;1us;32768us;9us;6us;2us;16395us;3us;21us;4us;28us;0us;16385us;1us;16388us;13us;9us;1us;16386us;15us;8us;0us;16387us;1us;32768us;11us;12us;1us;32768us;15us;13us;1us;32768us;12us;14us;1us;32768us;15us;15us;1us;16389us;15us;11us;0us;16390us;0us;16391us;0us;16392us;0us;16393us;0us;16394us;1us;32768us;15us;22us;2us;32768us;5us;18us;6us;17us;1us;32768us;14us;24us;1us;32768us;0us;25us;2us;32768us;1us;20us;2us;19us;2us;16395us;3us;21us;4us;28us;0us;16396us;1us;32768us;15us;29us;2us;32768us;5us;18us;6us;17us;1us;32768us;14us;31us;2us;16395us;3us;21us;4us;28us;0us;16397us;|]
let _fsyacc_actionTableRowOffsets = [|0us;2us;3us;5us;7us;9us;11us;14us;15us;17us;19us;20us;22us;24us;26us;28us;30us;31us;32us;33us;34us;35us;37us;40us;42us;44us;47us;50us;51us;53us;56us;58us;61us;|]
let _fsyacc_reductionSymbolCounts = [|1us;6us;0us;3us;1us;0us;6us;1us;1us;1us;1us;0us;7us;5us;|]
let _fsyacc_productionToNonTerminalTable = [|0us;1us;2us;2us;2us;3us;3us;4us;4us;5us;5us;6us;6us;6us;|]
let _fsyacc_immediateActions = [|65535us;49152us;65535us;65535us;65535us;65535us;65535us;16385us;65535us;65535us;16387us;65535us;65535us;65535us;65535us;65535us;16390us;16391us;16392us;16393us;16394us;65535us;65535us;65535us;65535us;65535us;65535us;16396us;65535us;65535us;65535us;65535us;16397us;|]
let _fsyacc_reductions = lazy [|
# 181 "Par.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.pension in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : 'gentype__startMain));
# 190 "Par.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> 'gentype_States in
            let _4 = parseState.GetInput(4) :?> 'gentype_Transitions in
            let _6 = parseState.GetInput(6) :?> 'gentype_Payments in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 29 "Par.fsy"
                                                                                       (_2, _4, _6) 
                   )
# 29 "Par.fsy"
                 : Absyn.pension));
# 203 "Par.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 34 "Par.fsy"
                                               [] 
                   )
# 34 "Par.fsy"
                 : 'gentype_States));
# 213 "Par.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            let _3 = parseState.GetInput(3) :?> 'gentype_States in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 35 "Par.fsy"
                                               _1 :: _3
                   )
# 35 "Par.fsy"
                 : 'gentype_States));
# 225 "Par.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 36 "Par.fsy"
                                               [_1] 
                   )
# 36 "Par.fsy"
                 : 'gentype_States));
# 236 "Par.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 40 "Par.fsy"
                                                               [] 
                   )
# 40 "Par.fsy"
                 : 'gentype_Transitions));
# 246 "Par.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            let _3 = parseState.GetInput(3) :?> string in
            let _5 = parseState.GetInput(5) :?> string in
            let _6 = parseState.GetInput(6) :?> 'gentype_Transitions in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 41 "Par.fsy"
                                                               (_1, (_3, _5)) :: _6
                   )
# 41 "Par.fsy"
                 : 'gentype_Transitions));
# 260 "Par.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 45 "Par.fsy"
                                                               Pay 
                   )
# 45 "Par.fsy"
                 : 'gentype_Dir));
# 270 "Par.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 46 "Par.fsy"
                                                               Receive 
                   )
# 46 "Par.fsy"
                 : 'gentype_Dir));
# 280 "Par.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 50 "Par.fsy"
                                                               PerMonth 
                   )
# 50 "Par.fsy"
                 : 'gentype_Time));
# 290 "Par.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 51 "Par.fsy"
                                                               PerYear 
                   )
# 51 "Par.fsy"
                 : 'gentype_Time));
# 300 "Par.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 55 "Par.fsy"
                                                               [] 
                   )
# 55 "Par.fsy"
                 : 'gentype_Payments));
# 310 "Par.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> string in
            let _3 = parseState.GetInput(3) :?> 'gentype_Dir in
            let _4 = parseState.GetInput(4) :?> int in
            let _6 = parseState.GetInput(6) :?> 'gentype_Time in
            let _7 = parseState.GetInput(7) :?> 'gentype_Payments in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 56 "Par.fsy"
                                                                   Stream(_2, _3, _4, _6) :: _7 
                   )
# 56 "Par.fsy"
                 : 'gentype_Payments));
# 325 "Par.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> string in
            let _3 = parseState.GetInput(3) :?> 'gentype_Dir in
            let _4 = parseState.GetInput(4) :?> int in
            let _5 = parseState.GetInput(5) :?> 'gentype_Payments in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 57 "Par.fsy"
                                                               Lumpsum(_2, _3, _4) :: _5 
                   )
# 57 "Par.fsy"
                 : 'gentype_Payments));
|]
# 340 "Par.fs"
let tables : FSharp.Text.Parsing.Tables<_> = 
  { reductions = _fsyacc_reductions.Value;
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 19;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = tables.Interpret(lexer, lexbuf, startState)
let Main lexer lexbuf : Absyn.pension =
    engine lexer lexbuf 0 :?> _
