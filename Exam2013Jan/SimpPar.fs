// Implementation file for parser generated by fsyacc
module SimpPar
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open FSharp.Text.Lexing
open FSharp.Text.Parsing.ParseHelpers
# 1 "SimpPar.fsy"

(*	File ListC/CPar.fsy 
	Parser specification for list-C, a small imperative language with lists
	sestoft@itu.dk * 2009-10-18
	No (real) shift/reduce conflicts thanks to Niels Kokholm.
*)

open Absyn;


# 17 "SimpPar.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | LPAR
  | RPAR
  | AND
  | NOT
  | OR
  | EQ
  | NE
  | LT
  | PLUS
  | MINUS
  | IF
  | GOTO
  | SLEEP
  | FALSE
  | TRUE
  | COLON
  | SEMI
  | COLONEQUAL
  | CSTINT of (int)
  | INANA of (int)
  | INDIGI of (int)
  | INCOUNT of (int)
  | OUTANA of (int)
  | OUTDIGI of (int)
  | NAME of (string)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_LPAR
    | TOKEN_RPAR
    | TOKEN_AND
    | TOKEN_NOT
    | TOKEN_OR
    | TOKEN_EQ
    | TOKEN_NE
    | TOKEN_LT
    | TOKEN_PLUS
    | TOKEN_MINUS
    | TOKEN_IF
    | TOKEN_GOTO
    | TOKEN_SLEEP
    | TOKEN_FALSE
    | TOKEN_TRUE
    | TOKEN_COLON
    | TOKEN_SEMI
    | TOKEN_COLONEQUAL
    | TOKEN_CSTINT
    | TOKEN_INANA
    | TOKEN_INDIGI
    | TOKEN_INCOUNT
    | TOKEN_OUTANA
    | TOKEN_OUTDIGI
    | TOKEN_NAME
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startMain
    | NONTERM_Main
    | NONTERM_Labels
    | NONTERM_Label
    | NONTERM_Block
    | NONTERM_Cmd
    | NONTERM_Output
    | NONTERM_Expr
    | NONTERM_Input

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | LPAR  -> 1 
  | RPAR  -> 2 
  | AND  -> 3 
  | NOT  -> 4 
  | OR  -> 5 
  | EQ  -> 6 
  | NE  -> 7 
  | LT  -> 8 
  | PLUS  -> 9 
  | MINUS  -> 10 
  | IF  -> 11 
  | GOTO  -> 12 
  | SLEEP  -> 13 
  | FALSE  -> 14 
  | TRUE  -> 15 
  | COLON  -> 16 
  | SEMI  -> 17 
  | COLONEQUAL  -> 18 
  | CSTINT _ -> 19 
  | INANA _ -> 20 
  | INDIGI _ -> 21 
  | INCOUNT _ -> 22 
  | OUTANA _ -> 23 
  | OUTDIGI _ -> 24 
  | NAME _ -> 25 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_LPAR 
  | 2 -> TOKEN_RPAR 
  | 3 -> TOKEN_AND 
  | 4 -> TOKEN_NOT 
  | 5 -> TOKEN_OR 
  | 6 -> TOKEN_EQ 
  | 7 -> TOKEN_NE 
  | 8 -> TOKEN_LT 
  | 9 -> TOKEN_PLUS 
  | 10 -> TOKEN_MINUS 
  | 11 -> TOKEN_IF 
  | 12 -> TOKEN_GOTO 
  | 13 -> TOKEN_SLEEP 
  | 14 -> TOKEN_FALSE 
  | 15 -> TOKEN_TRUE 
  | 16 -> TOKEN_COLON 
  | 17 -> TOKEN_SEMI 
  | 18 -> TOKEN_COLONEQUAL 
  | 19 -> TOKEN_CSTINT 
  | 20 -> TOKEN_INANA 
  | 21 -> TOKEN_INDIGI 
  | 22 -> TOKEN_INCOUNT 
  | 23 -> TOKEN_OUTANA 
  | 24 -> TOKEN_OUTDIGI 
  | 25 -> TOKEN_NAME 
  | 28 -> TOKEN_end_of_input
  | 26 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startMain 
    | 1 -> NONTERM_Main 
    | 2 -> NONTERM_Labels 
    | 3 -> NONTERM_Labels 
    | 4 -> NONTERM_Label 
    | 5 -> NONTERM_Block 
    | 6 -> NONTERM_Block 
    | 7 -> NONTERM_Cmd 
    | 8 -> NONTERM_Cmd 
    | 9 -> NONTERM_Cmd 
    | 10 -> NONTERM_Cmd 
    | 11 -> NONTERM_Output 
    | 12 -> NONTERM_Output 
    | 13 -> NONTERM_Expr 
    | 14 -> NONTERM_Expr 
    | 15 -> NONTERM_Expr 
    | 16 -> NONTERM_Expr 
    | 17 -> NONTERM_Expr 
    | 18 -> NONTERM_Expr 
    | 19 -> NONTERM_Expr 
    | 20 -> NONTERM_Expr 
    | 21 -> NONTERM_Expr 
    | 22 -> NONTERM_Expr 
    | 23 -> NONTERM_Expr 
    | 24 -> NONTERM_Expr 
    | 25 -> NONTERM_Expr 
    | 26 -> NONTERM_Input 
    | 27 -> NONTERM_Input 
    | 28 -> NONTERM_Input 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 28 
let _fsyacc_tagOfErrorTerminal = 26

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | LPAR  -> "LPAR" 
  | RPAR  -> "RPAR" 
  | AND  -> "AND" 
  | NOT  -> "NOT" 
  | OR  -> "OR" 
  | EQ  -> "EQ" 
  | NE  -> "NE" 
  | LT  -> "LT" 
  | PLUS  -> "PLUS" 
  | MINUS  -> "MINUS" 
  | IF  -> "IF" 
  | GOTO  -> "GOTO" 
  | SLEEP  -> "SLEEP" 
  | FALSE  -> "FALSE" 
  | TRUE  -> "TRUE" 
  | COLON  -> "COLON" 
  | SEMI  -> "SEMI" 
  | COLONEQUAL  -> "COLONEQUAL" 
  | CSTINT _ -> "CSTINT" 
  | INANA _ -> "INANA" 
  | INDIGI _ -> "INDIGI" 
  | INCOUNT _ -> "INCOUNT" 
  | OUTANA _ -> "OUTANA" 
  | OUTDIGI _ -> "OUTDIGI" 
  | NAME _ -> "NAME" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | LPAR  -> (null : System.Object) 
  | RPAR  -> (null : System.Object) 
  | AND  -> (null : System.Object) 
  | NOT  -> (null : System.Object) 
  | OR  -> (null : System.Object) 
  | EQ  -> (null : System.Object) 
  | NE  -> (null : System.Object) 
  | LT  -> (null : System.Object) 
  | PLUS  -> (null : System.Object) 
  | MINUS  -> (null : System.Object) 
  | IF  -> (null : System.Object) 
  | GOTO  -> (null : System.Object) 
  | SLEEP  -> (null : System.Object) 
  | FALSE  -> (null : System.Object) 
  | TRUE  -> (null : System.Object) 
  | COLON  -> (null : System.Object) 
  | SEMI  -> (null : System.Object) 
  | COLONEQUAL  -> (null : System.Object) 
  | CSTINT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | INANA _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | INDIGI _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | INCOUNT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | OUTANA _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | OUTDIGI _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | NAME _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us;65535us;1us;65535us;0us;1us;2us;65535us;0us;2us;4us;5us;2us;65535us;0us;4us;4us;4us;2us;65535us;7us;8us;10us;11us;2us;65535us;7us;9us;10us;9us;2us;65535us;7us;12us;10us;12us;11us;65535us;13us;14us;17us;18us;35us;26us;36us;27us;37us;28us;38us;29us;39us;30us;40us;31us;41us;32us;45us;33us;46us;34us;11us;65535us;13us;44us;17us;44us;35us;44us;36us;44us;37us;44us;38us;44us;39us;44us;40us;44us;41us;44us;45us;44us;46us;44us;|]
let _fsyacc_sparseGotoTableRowOffsets = [|0us;1us;3us;6us;9us;12us;15us;18us;30us;|]
let _fsyacc_stateToProdIdxsTableElements = [| 1us;0us;1us;0us;1us;1us;1us;1us;1us;3us;1us;3us;1us;4us;1us;4us;1us;4us;1us;6us;1us;6us;1us;6us;1us;7us;1us;7us;8us;7us;14us;15us;16us;17us;18us;19us;20us;1us;8us;1us;8us;1us;9us;8us;9us;14us;15us;16us;17us;18us;19us;20us;1us;9us;1us;9us;1us;10us;1us;10us;1us;11us;1us;12us;1us;13us;8us;14us;14us;15us;16us;17us;18us;19us;20us;8us;14us;15us;15us;16us;17us;18us;19us;20us;8us;14us;15us;16us;16us;17us;18us;19us;20us;8us;14us;15us;16us;17us;17us;18us;19us;20us;8us;14us;15us;16us;17us;18us;18us;19us;20us;8us;14us;15us;16us;17us;18us;19us;19us;20us;8us;14us;15us;16us;17us;18us;19us;20us;20us;8us;14us;15us;16us;17us;18us;19us;20us;24us;8us;14us;15us;16us;17us;18us;19us;20us;25us;1us;14us;1us;15us;1us;16us;1us;17us;1us;18us;1us;19us;1us;20us;1us;21us;1us;22us;1us;23us;1us;24us;1us;25us;1us;25us;1us;26us;1us;27us;1us;28us;|]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us;2us;4us;6us;8us;10us;12us;14us;16us;18us;20us;22us;24us;26us;28us;37us;39us;41us;43us;52us;54us;56us;58us;60us;62us;64us;66us;75us;84us;93us;102us;111us;120us;129us;138us;147us;149us;151us;153us;155us;157us;159us;161us;163us;165us;167us;169us;171us;173us;175us;177us;|]
let _fsyacc_action_rows = 51
let _fsyacc_actionTableElements = [|1us;16386us;25us;6us;0us;49152us;1us;32768us;0us;3us;0us;16385us;1us;16386us;25us;6us;0us;16387us;1us;32768us;16us;7us;5us;16389us;11us;17us;12us;15us;13us;21us;23us;24us;24us;23us;0us;16388us;1us;32768us;17us;10us;5us;16389us;11us;17us;12us;15us;13us;21us;23us;24us;24us;23us;0us;16390us;1us;32768us;18us;13us;8us;32768us;1us;46us;4us;45us;14us;43us;15us;42us;19us;25us;20us;48us;21us;49us;22us;50us;7us;16391us;3us;40us;5us;41us;6us;37us;7us;38us;8us;39us;9us;35us;10us;36us;1us;32768us;25us;16us;0us;16392us;8us;32768us;1us;46us;4us;45us;14us;43us;15us;42us;19us;25us;20us;48us;21us;49us;22us;50us;8us;32768us;3us;40us;5us;41us;6us;37us;7us;38us;8us;39us;9us;35us;10us;36us;12us;19us;1us;32768us;25us;20us;0us;16393us;1us;32768us;19us;22us;0us;16394us;0us;16395us;0us;16396us;0us;16397us;0us;16398us;0us;16399us;3us;16400us;8us;39us;9us;35us;10us;36us;3us;16401us;8us;39us;9us;35us;10us;36us;3us;16402us;8us;39us;9us;35us;10us;36us;5us;16403us;6us;37us;7us;38us;8us;39us;9us;35us;10us;36us;6us;16404us;3us;40us;6us;37us;7us;38us;8us;39us;9us;35us;10us;36us;5us;16408us;6us;37us;7us;38us;8us;39us;9us;35us;10us;36us;8us;32768us;2us;47us;3us;40us;5us;41us;6us;37us;7us;38us;8us;39us;9us;35us;10us;36us;8us;32768us;1us;46us;4us;45us;14us;43us;15us;42us;19us;25us;20us;48us;21us;49us;22us;50us;8us;32768us;1us;46us;4us;45us;14us;43us;15us;42us;19us;25us;20us;48us;21us;49us;22us;50us;8us;32768us;1us;46us;4us;45us;14us;43us;15us;42us;19us;25us;20us;48us;21us;49us;22us;50us;8us;32768us;1us;46us;4us;45us;14us;43us;15us;42us;19us;25us;20us;48us;21us;49us;22us;50us;8us;32768us;1us;46us;4us;45us;14us;43us;15us;42us;19us;25us;20us;48us;21us;49us;22us;50us;8us;32768us;1us;46us;4us;45us;14us;43us;15us;42us;19us;25us;20us;48us;21us;49us;22us;50us;8us;32768us;1us;46us;4us;45us;14us;43us;15us;42us;19us;25us;20us;48us;21us;49us;22us;50us;0us;16405us;0us;16406us;0us;16407us;8us;32768us;1us;46us;4us;45us;14us;43us;15us;42us;19us;25us;20us;48us;21us;49us;22us;50us;8us;32768us;1us;46us;4us;45us;14us;43us;15us;42us;19us;25us;20us;48us;21us;49us;22us;50us;0us;16409us;0us;16410us;0us;16411us;0us;16412us;|]
let _fsyacc_actionTableRowOffsets = [|0us;2us;3us;5us;6us;8us;9us;11us;17us;18us;20us;26us;27us;29us;38us;46us;48us;49us;58us;67us;69us;70us;72us;73us;74us;75us;76us;77us;78us;82us;86us;90us;96us;103us;109us;118us;127us;136us;145us;154us;163us;172us;181us;182us;183us;184us;193us;202us;203us;204us;205us;|]
let _fsyacc_reductionSymbolCounts = [|1us;2us;0us;2us;3us;0us;3us;3us;2us;4us;2us;1us;1us;1us;3us;3us;3us;3us;3us;3us;3us;1us;1us;1us;2us;3us;1us;1us;1us;|]
let _fsyacc_productionToNonTerminalTable = [|0us;1us;2us;2us;3us;4us;4us;5us;5us;5us;5us;6us;6us;7us;7us;7us;7us;7us;7us;7us;7us;7us;7us;7us;7us;7us;8us;8us;8us;|]
let _fsyacc_immediateActions = [|65535us;49152us;65535us;16385us;65535us;16387us;65535us;65535us;16388us;65535us;65535us;16390us;65535us;65535us;65535us;65535us;16392us;65535us;65535us;65535us;16393us;65535us;16394us;16395us;16396us;16397us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;16405us;16406us;16407us;65535us;65535us;16409us;16410us;16411us;16412us;|]
let _fsyacc_reductions = lazy [|
# 258 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.program in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : 'gentype__startMain));
# 267 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_Labels in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 37 "SimpPar.fsy"
                                               _1 
                   )
# 37 "SimpPar.fsy"
                 : Absyn.program));
# 278 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 41 "SimpPar.fsy"
                                               [] 
                   )
# 41 "SimpPar.fsy"
                 : 'gentype_Labels));
# 288 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_Label in
            let _2 = parseState.GetInput(2) :?> 'gentype_Labels in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 42 "SimpPar.fsy"
                                               _1 :: _2 
                   )
# 42 "SimpPar.fsy"
                 : 'gentype_Labels));
# 300 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            let _3 = parseState.GetInput(3) :?> 'gentype_Block in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 45 "SimpPar.fsy"
                                                 (lab _1, _3) 
                   )
# 45 "SimpPar.fsy"
                 : 'gentype_Label));
# 312 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 49 "SimpPar.fsy"
                                               [] 
                   )
# 49 "SimpPar.fsy"
                 : 'gentype_Block));
# 322 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_Cmd in
            let _3 = parseState.GetInput(3) :?> 'gentype_Block in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 50 "SimpPar.fsy"
                                            _1 :: _3
                   )
# 50 "SimpPar.fsy"
                 : 'gentype_Block));
# 334 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_Output in
            let _3 = parseState.GetInput(3) :?> 'gentype_Expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 54 "SimpPar.fsy"
                                                    Set(_1, _3)
                   )
# 54 "SimpPar.fsy"
                 : 'gentype_Cmd));
# 346 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 55 "SimpPar.fsy"
                                                    Goto(_2)
                   )
# 55 "SimpPar.fsy"
                 : 'gentype_Cmd));
# 357 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> 'gentype_Expr in
            let _4 = parseState.GetInput(4) :?> string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 56 "SimpPar.fsy"
                                                    If(_2, _4)
                   )
# 56 "SimpPar.fsy"
                 : 'gentype_Cmd));
# 369 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 57 "SimpPar.fsy"
                                                    Sleep(_2)
                   )
# 57 "SimpPar.fsy"
                 : 'gentype_Cmd));
# 380 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 61 "SimpPar.fsy"
                                                    Od _1
                   )
# 61 "SimpPar.fsy"
                 : 'gentype_Output));
# 391 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 62 "SimpPar.fsy"
                                                    Oa _1
                   )
# 62 "SimpPar.fsy"
                 : 'gentype_Output));
# 402 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 66 "SimpPar.fsy"
                                                    CstI _1
                   )
# 66 "SimpPar.fsy"
                 : 'gentype_Expr));
# 413 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_Expr in
            let _3 = parseState.GetInput(3) :?> 'gentype_Expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 67 "SimpPar.fsy"
                                                     Prim2("+", _1, _3) 
                   )
# 67 "SimpPar.fsy"
                 : 'gentype_Expr));
# 425 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_Expr in
            let _3 = parseState.GetInput(3) :?> 'gentype_Expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 68 "SimpPar.fsy"
                                                     Prim2("-", _1, _3) 
                   )
# 68 "SimpPar.fsy"
                 : 'gentype_Expr));
# 437 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_Expr in
            let _3 = parseState.GetInput(3) :?> 'gentype_Expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 69 "SimpPar.fsy"
                                                     Prim2("=", _1, _3) 
                   )
# 69 "SimpPar.fsy"
                 : 'gentype_Expr));
# 449 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_Expr in
            let _3 = parseState.GetInput(3) :?> 'gentype_Expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 70 "SimpPar.fsy"
                                                    Prim2("<>", _1, _3) 
                   )
# 70 "SimpPar.fsy"
                 : 'gentype_Expr));
# 461 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_Expr in
            let _3 = parseState.GetInput(3) :?> 'gentype_Expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 71 "SimpPar.fsy"
                                                    Prim2("<", _1, _3) 
                   )
# 71 "SimpPar.fsy"
                 : 'gentype_Expr));
# 473 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_Expr in
            let _3 = parseState.GetInput(3) :?> 'gentype_Expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 72 "SimpPar.fsy"
                                                     Prim2("and", _1, _3) 
                   )
# 72 "SimpPar.fsy"
                 : 'gentype_Expr));
# 485 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_Expr in
            let _3 = parseState.GetInput(3) :?> 'gentype_Expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 73 "SimpPar.fsy"
                                                    Prim2("or", _1, _3) 
                   )
# 73 "SimpPar.fsy"
                 : 'gentype_Expr));
# 497 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 74 "SimpPar.fsy"
                                                     True 
                   )
# 74 "SimpPar.fsy"
                 : 'gentype_Expr));
# 507 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 75 "SimpPar.fsy"
                                                     False 
                   )
# 75 "SimpPar.fsy"
                 : 'gentype_Expr));
# 517 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_Input in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 76 "SimpPar.fsy"
                                                     _1 
                   )
# 76 "SimpPar.fsy"
                 : 'gentype_Expr));
# 528 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> 'gentype_Expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 77 "SimpPar.fsy"
                                                     Prim1("not", _2)
                   )
# 77 "SimpPar.fsy"
                 : 'gentype_Expr));
# 539 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> 'gentype_Expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 78 "SimpPar.fsy"
                                                    _2
                   )
# 78 "SimpPar.fsy"
                 : 'gentype_Expr));
# 550 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 82 "SimpPar.fsy"
                                                     Ia _1 
                   )
# 82 "SimpPar.fsy"
                 : 'gentype_Input));
# 561 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 83 "SimpPar.fsy"
                                                     Id _1 
                   )
# 83 "SimpPar.fsy"
                 : 'gentype_Input));
# 572 "SimpPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 84 "SimpPar.fsy"
                                                     Cd _1 
                   )
# 84 "SimpPar.fsy"
                 : 'gentype_Input));
|]
# 584 "SimpPar.fs"
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
    numTerminals = 29;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = tables.Interpret(lexer, lexbuf, startState)
let Main lexer lexbuf : Absyn.program =
    engine lexer lexbuf 0 :?> _
