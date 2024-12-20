// Implementation file for parser generated by fsyacc
module FunPar
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open FSharp.Text.Lexing
open FSharp.Text.Parsing.ParseHelpers
# 1 "FunPar.fsy"

 (* File Fun/FunPar.fsy 
    Parser for micro-ML, a small functional language; one-argument functions.
    sestoft@itu.dk * 2009-10-19
  *)

 open Absyn;

# 15 "FunPar.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | LPAR
  | RPAR
  | LBRA
  | RBRA
  | EQ
  | NE
  | GT
  | LT
  | GE
  | LE
  | PLUS
  | MINUS
  | TIMES
  | DIV
  | MOD
  | ELSE
  | END
  | FALSE
  | IF
  | IN
  | LET
  | NOT
  | THEN
  | TRUE
  | PRINT
  | SEMI
  | DOT
  | CSTBOOL of (bool)
  | NAME of (string)
  | CSTINT of (int)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_LPAR
    | TOKEN_RPAR
    | TOKEN_LBRA
    | TOKEN_RBRA
    | TOKEN_EQ
    | TOKEN_NE
    | TOKEN_GT
    | TOKEN_LT
    | TOKEN_GE
    | TOKEN_LE
    | TOKEN_PLUS
    | TOKEN_MINUS
    | TOKEN_TIMES
    | TOKEN_DIV
    | TOKEN_MOD
    | TOKEN_ELSE
    | TOKEN_END
    | TOKEN_FALSE
    | TOKEN_IF
    | TOKEN_IN
    | TOKEN_LET
    | TOKEN_NOT
    | TOKEN_THEN
    | TOKEN_TRUE
    | TOKEN_PRINT
    | TOKEN_SEMI
    | TOKEN_DOT
    | TOKEN_CSTBOOL
    | TOKEN_NAME
    | TOKEN_CSTINT
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startMain
    | NONTERM_Main
    | NONTERM_ExprLst
    | NONTERM_Expr
    | NONTERM_AtExpr
    | NONTERM_AppExpr
    | NONTERM_Const

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | LPAR  -> 1 
  | RPAR  -> 2 
  | LBRA  -> 3 
  | RBRA  -> 4 
  | EQ  -> 5 
  | NE  -> 6 
  | GT  -> 7 
  | LT  -> 8 
  | GE  -> 9 
  | LE  -> 10 
  | PLUS  -> 11 
  | MINUS  -> 12 
  | TIMES  -> 13 
  | DIV  -> 14 
  | MOD  -> 15 
  | ELSE  -> 16 
  | END  -> 17 
  | FALSE  -> 18 
  | IF  -> 19 
  | IN  -> 20 
  | LET  -> 21 
  | NOT  -> 22 
  | THEN  -> 23 
  | TRUE  -> 24 
  | PRINT  -> 25 
  | SEMI  -> 26 
  | DOT  -> 27 
  | CSTBOOL _ -> 28 
  | NAME _ -> 29 
  | CSTINT _ -> 30 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_LPAR 
  | 2 -> TOKEN_RPAR 
  | 3 -> TOKEN_LBRA 
  | 4 -> TOKEN_RBRA 
  | 5 -> TOKEN_EQ 
  | 6 -> TOKEN_NE 
  | 7 -> TOKEN_GT 
  | 8 -> TOKEN_LT 
  | 9 -> TOKEN_GE 
  | 10 -> TOKEN_LE 
  | 11 -> TOKEN_PLUS 
  | 12 -> TOKEN_MINUS 
  | 13 -> TOKEN_TIMES 
  | 14 -> TOKEN_DIV 
  | 15 -> TOKEN_MOD 
  | 16 -> TOKEN_ELSE 
  | 17 -> TOKEN_END 
  | 18 -> TOKEN_FALSE 
  | 19 -> TOKEN_IF 
  | 20 -> TOKEN_IN 
  | 21 -> TOKEN_LET 
  | 22 -> TOKEN_NOT 
  | 23 -> TOKEN_THEN 
  | 24 -> TOKEN_TRUE 
  | 25 -> TOKEN_PRINT 
  | 26 -> TOKEN_SEMI 
  | 27 -> TOKEN_DOT 
  | 28 -> TOKEN_CSTBOOL 
  | 29 -> TOKEN_NAME 
  | 30 -> TOKEN_CSTINT 
  | 33 -> TOKEN_end_of_input
  | 31 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startMain 
    | 1 -> NONTERM_Main 
    | 2 -> NONTERM_ExprLst 
    | 3 -> NONTERM_ExprLst 
    | 4 -> NONTERM_Expr 
    | 5 -> NONTERM_Expr 
    | 6 -> NONTERM_Expr 
    | 7 -> NONTERM_Expr 
    | 8 -> NONTERM_Expr 
    | 9 -> NONTERM_Expr 
    | 10 -> NONTERM_Expr 
    | 11 -> NONTERM_Expr 
    | 12 -> NONTERM_Expr 
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
    | 23 -> NONTERM_AtExpr 
    | 24 -> NONTERM_AtExpr 
    | 25 -> NONTERM_AtExpr 
    | 26 -> NONTERM_AtExpr 
    | 27 -> NONTERM_AtExpr 
    | 28 -> NONTERM_AppExpr 
    | 29 -> NONTERM_AppExpr 
    | 30 -> NONTERM_Const 
    | 31 -> NONTERM_Const 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 33 
let _fsyacc_tagOfErrorTerminal = 31

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | LPAR  -> "LPAR" 
  | RPAR  -> "RPAR" 
  | LBRA  -> "LBRA" 
  | RBRA  -> "RBRA" 
  | EQ  -> "EQ" 
  | NE  -> "NE" 
  | GT  -> "GT" 
  | LT  -> "LT" 
  | GE  -> "GE" 
  | LE  -> "LE" 
  | PLUS  -> "PLUS" 
  | MINUS  -> "MINUS" 
  | TIMES  -> "TIMES" 
  | DIV  -> "DIV" 
  | MOD  -> "MOD" 
  | ELSE  -> "ELSE" 
  | END  -> "END" 
  | FALSE  -> "FALSE" 
  | IF  -> "IF" 
  | IN  -> "IN" 
  | LET  -> "LET" 
  | NOT  -> "NOT" 
  | THEN  -> "THEN" 
  | TRUE  -> "TRUE" 
  | PRINT  -> "PRINT" 
  | SEMI  -> "SEMI" 
  | DOT  -> "DOT" 
  | CSTBOOL _ -> "CSTBOOL" 
  | NAME _ -> "NAME" 
  | CSTINT _ -> "CSTINT" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | LPAR  -> (null : System.Object) 
  | RPAR  -> (null : System.Object) 
  | LBRA  -> (null : System.Object) 
  | RBRA  -> (null : System.Object) 
  | EQ  -> (null : System.Object) 
  | NE  -> (null : System.Object) 
  | GT  -> (null : System.Object) 
  | LT  -> (null : System.Object) 
  | GE  -> (null : System.Object) 
  | LE  -> (null : System.Object) 
  | PLUS  -> (null : System.Object) 
  | MINUS  -> (null : System.Object) 
  | TIMES  -> (null : System.Object) 
  | DIV  -> (null : System.Object) 
  | MOD  -> (null : System.Object) 
  | ELSE  -> (null : System.Object) 
  | END  -> (null : System.Object) 
  | FALSE  -> (null : System.Object) 
  | IF  -> (null : System.Object) 
  | IN  -> (null : System.Object) 
  | LET  -> (null : System.Object) 
  | NOT  -> (null : System.Object) 
  | THEN  -> (null : System.Object) 
  | TRUE  -> (null : System.Object) 
  | PRINT  -> (null : System.Object) 
  | SEMI  -> (null : System.Object) 
  | DOT  -> (null : System.Object) 
  | CSTBOOL _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | NAME _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | CSTINT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us;65535us;1us;65535us;0us;1us;2us;65535us;7us;8us;48us;50us;23us;65535us;0us;2us;5us;6us;11us;12us;13us;14us;15us;16us;17us;18us;36us;19us;37us;20us;38us;21us;39us;22us;40us;23us;41us;24us;42us;25us;43us;26us;44us;27us;45us;28us;46us;29us;47us;30us;58us;31us;59us;32us;62us;33us;63us;34us;65us;35us;25us;65535us;0us;9us;5us;9us;9us;67us;10us;68us;11us;9us;13us;9us;15us;9us;17us;9us;36us;9us;37us;9us;38us;9us;39us;9us;40us;9us;41us;9us;42us;9us;43us;9us;44us;9us;45us;9us;46us;9us;47us;9us;58us;9us;59us;9us;62us;9us;63us;9us;65us;9us;23us;65535us;0us;10us;5us;10us;11us;10us;13us;10us;15us;10us;17us;10us;36us;10us;37us;10us;38us;10us;39us;10us;40us;10us;41us;10us;42us;10us;43us;10us;44us;10us;45us;10us;46us;10us;47us;10us;58us;10us;59us;10us;62us;10us;63us;10us;65us;10us;25us;65535us;0us;54us;5us;54us;9us;54us;10us;54us;11us;54us;13us;54us;15us;54us;17us;54us;36us;54us;37us;54us;38us;54us;39us;54us;40us;54us;41us;54us;42us;54us;43us;54us;44us;54us;45us;54us;46us;54us;47us;54us;58us;54us;59us;54us;62us;54us;63us;54us;65us;54us;|]
let _fsyacc_sparseGotoTableRowOffsets = [|0us;1us;3us;6us;30us;56us;80us;|]
let _fsyacc_stateToProdIdxsTableElements = [| 1us;0us;1us;0us;13us;1us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;22us;1us;1us;2us;2us;3us;2us;2us;3us;14us;2us;3us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;22us;1us;3us;1us;3us;2us;4us;28us;2us;5us;29us;1us;6us;13us;6us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;22us;1us;6us;13us;6us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;22us;1us;6us;13us;6us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;22us;1us;7us;13us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;22us;13us;8us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;22us;13us;8us;9us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;22us;13us;8us;9us;10us;10us;11us;12us;13us;14us;15us;16us;17us;18us;22us;13us;8us;9us;10us;11us;11us;12us;13us;14us;15us;16us;17us;18us;22us;13us;8us;9us;10us;11us;12us;12us;13us;14us;15us;16us;17us;18us;22us;13us;8us;9us;10us;11us;12us;13us;13us;14us;15us;16us;17us;18us;22us;13us;8us;9us;10us;11us;12us;13us;14us;14us;15us;16us;17us;18us;22us;13us;8us;9us;10us;11us;12us;13us;14us;15us;15us;16us;17us;18us;22us;13us;8us;9us;10us;11us;12us;13us;14us;15us;16us;16us;17us;18us;22us;13us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;17us;18us;22us;13us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;18us;22us;13us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;19us;22us;13us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;22us;25us;13us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;22us;25us;13us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;22us;26us;13us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;22us;26us;13us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;22us;27us;1us;8us;1us;9us;1us;10us;1us;11us;1us;12us;1us;13us;1us;14us;1us;15us;1us;16us;1us;17us;1us;18us;1us;19us;2us;20us;21us;1us;20us;1us;21us;1us;21us;1us;22us;1us;22us;1us;23us;1us;24us;2us;25us;26us;2us;25us;26us;1us;25us;1us;25us;1us;25us;1us;26us;1us;26us;1us;26us;1us;26us;1us;27us;1us;27us;1us;28us;1us;29us;1us;30us;1us;31us;|]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us;2us;4us;18us;20us;23us;26us;41us;43us;45us;48us;51us;53us;67us;69us;83us;85us;99us;101us;115us;129us;143us;157us;171us;185us;199us;213us;227us;241us;255us;269us;283us;297us;311us;325us;339us;353us;355us;357us;359us;361us;363us;365us;367us;369us;371us;373us;375us;377us;380us;382us;384us;386us;388us;390us;392us;394us;397us;400us;402us;404us;406us;408us;410us;412us;414us;416us;418us;420us;422us;424us;|]
let _fsyacc_action_rows = 71
let _fsyacc_actionTableElements = [|9us;32768us;1us;65us;3us;48us;12us;17us;19us;11us;21us;56us;25us;47us;28us;70us;29us;55us;30us;69us;0us;49152us;13us;32768us;0us;3us;5us;41us;6us;42us;7us;43us;8us;44us;9us;45us;10us;46us;11us;36us;12us;37us;13us;38us;14us;39us;15us;40us;27us;52us;0us;16385us;1us;32768us;5us;5us;9us;32768us;1us;65us;3us;48us;12us;17us;19us;11us;21us;56us;25us;47us;28us;70us;29us;55us;30us;69us;13us;16386us;5us;41us;6us;42us;7us;43us;8us;44us;9us;45us;10us;46us;11us;36us;12us;37us;13us;38us;14us;39us;15us;40us;26us;7us;27us;52us;1us;32768us;29us;4us;0us;16387us;5us;16388us;1us;65us;21us;56us;28us;70us;29us;55us;30us;69us;5us;16389us;1us;65us;21us;56us;28us;70us;29us;55us;30us;69us;9us;32768us;1us;65us;3us;48us;12us;17us;19us;11us;21us;56us;25us;47us;28us;70us;29us;55us;30us;69us;13us;32768us;5us;41us;6us;42us;7us;43us;8us;44us;9us;45us;10us;46us;11us;36us;12us;37us;13us;38us;14us;39us;15us;40us;23us;13us;27us;52us;9us;32768us;1us;65us;3us;48us;12us;17us;19us;11us;21us;56us;25us;47us;28us;70us;29us;55us;30us;69us;13us;32768us;5us;41us;6us;42us;7us;43us;8us;44us;9us;45us;10us;46us;11us;36us;12us;37us;13us;38us;14us;39us;15us;40us;16us;15us;27us;52us;9us;32768us;1us;65us;3us;48us;12us;17us;19us;11us;21us;56us;25us;47us;28us;70us;29us;55us;30us;69us;12us;16390us;5us;41us;6us;42us;7us;43us;8us;44us;9us;45us;10us;46us;11us;36us;12us;37us;13us;38us;14us;39us;15us;40us;27us;52us;9us;32768us;1us;65us;3us;48us;12us;17us;19us;11us;21us;56us;25us;47us;28us;70us;29us;55us;30us;69us;4us;16391us;13us;38us;14us;39us;15us;40us;27us;52us;4us;16392us;13us;38us;14us;39us;15us;40us;27us;52us;4us;16393us;13us;38us;14us;39us;15us;40us;27us;52us;1us;16394us;27us;52us;1us;16395us;27us;52us;1us;16396us;27us;52us;10us;16397us;7us;43us;8us;44us;9us;45us;10us;46us;11us;36us;12us;37us;13us;38us;14us;39us;15us;40us;27us;52us;10us;16398us;7us;43us;8us;44us;9us;45us;10us;46us;11us;36us;12us;37us;13us;38us;14us;39us;15us;40us;27us;52us;6us;16399us;11us;36us;12us;37us;13us;38us;14us;39us;15us;40us;27us;52us;6us;16400us;11us;36us;12us;37us;13us;38us;14us;39us;15us;40us;27us;52us;6us;16401us;11us;36us;12us;37us;13us;38us;14us;39us;15us;40us;27us;52us;6us;16402us;11us;36us;12us;37us;13us;38us;14us;39us;15us;40us;27us;52us;12us;16403us;5us;41us;6us;42us;7us;43us;8us;44us;9us;45us;10us;46us;11us;36us;12us;37us;13us;38us;14us;39us;15us;40us;27us;52us;13us;32768us;5us;41us;6us;42us;7us;43us;8us;44us;9us;45us;10us;46us;11us;36us;12us;37us;13us;38us;14us;39us;15us;40us;20us;59us;27us;52us;13us;32768us;5us;41us;6us;42us;7us;43us;8us;44us;9us;45us;10us;46us;11us;36us;12us;37us;13us;38us;14us;39us;15us;40us;17us;60us;27us;52us;13us;32768us;5us;41us;6us;42us;7us;43us;8us;44us;9us;45us;10us;46us;11us;36us;12us;37us;13us;38us;14us;39us;15us;40us;20us;63us;27us;52us;13us;32768us;5us;41us;6us;42us;7us;43us;8us;44us;9us;45us;10us;46us;11us;36us;12us;37us;13us;38us;14us;39us;15us;40us;17us;64us;27us;52us;13us;32768us;2us;66us;5us;41us;6us;42us;7us;43us;8us;44us;9us;45us;10us;46us;11us;36us;12us;37us;13us;38us;14us;39us;15us;40us;27us;52us;9us;32768us;1us;65us;3us;48us;12us;17us;19us;11us;21us;56us;25us;47us;28us;70us;29us;55us;30us;69us;9us;32768us;1us;65us;3us;48us;12us;17us;19us;11us;21us;56us;25us;47us;28us;70us;29us;55us;30us;69us;9us;32768us;1us;65us;3us;48us;12us;17us;19us;11us;21us;56us;25us;47us;28us;70us;29us;55us;30us;69us;9us;32768us;1us;65us;3us;48us;12us;17us;19us;11us;21us;56us;25us;47us;28us;70us;29us;55us;30us;69us;9us;32768us;1us;65us;3us;48us;12us;17us;19us;11us;21us;56us;25us;47us;28us;70us;29us;55us;30us;69us;9us;32768us;1us;65us;3us;48us;12us;17us;19us;11us;21us;56us;25us;47us;28us;70us;29us;55us;30us;69us;9us;32768us;1us;65us;3us;48us;12us;17us;19us;11us;21us;56us;25us;47us;28us;70us;29us;55us;30us;69us;9us;32768us;1us;65us;3us;48us;12us;17us;19us;11us;21us;56us;25us;47us;28us;70us;29us;55us;30us;69us;9us;32768us;1us;65us;3us;48us;12us;17us;19us;11us;21us;56us;25us;47us;28us;70us;29us;55us;30us;69us;9us;32768us;1us;65us;3us;48us;12us;17us;19us;11us;21us;56us;25us;47us;28us;70us;29us;55us;30us;69us;9us;32768us;1us;65us;3us;48us;12us;17us;19us;11us;21us;56us;25us;47us;28us;70us;29us;55us;30us;69us;9us;32768us;1us;65us;3us;48us;12us;17us;19us;11us;21us;56us;25us;47us;28us;70us;29us;55us;30us;69us;2us;32768us;4us;49us;29us;4us;0us;16404us;1us;32768us;4us;51us;0us;16405us;1us;32768us;29us;53us;0us;16406us;0us;16407us;0us;16408us;1us;32768us;29us;57us;2us;32768us;5us;58us;29us;61us;9us;32768us;1us;65us;3us;48us;12us;17us;19us;11us;21us;56us;25us;47us;28us;70us;29us;55us;30us;69us;9us;32768us;1us;65us;3us;48us;12us;17us;19us;11us;21us;56us;25us;47us;28us;70us;29us;55us;30us;69us;0us;16409us;1us;32768us;5us;62us;9us;32768us;1us;65us;3us;48us;12us;17us;19us;11us;21us;56us;25us;47us;28us;70us;29us;55us;30us;69us;9us;32768us;1us;65us;3us;48us;12us;17us;19us;11us;21us;56us;25us;47us;28us;70us;29us;55us;30us;69us;0us;16410us;9us;32768us;1us;65us;3us;48us;12us;17us;19us;11us;21us;56us;25us;47us;28us;70us;29us;55us;30us;69us;0us;16411us;0us;16412us;0us;16413us;0us;16414us;0us;16415us;|]
let _fsyacc_actionTableRowOffsets = [|0us;10us;11us;25us;26us;28us;38us;52us;54us;55us;61us;67us;77us;91us;101us;115us;125us;138us;148us;153us;158us;163us;165us;167us;169us;180us;191us;198us;205us;212us;219us;232us;246us;260us;274us;288us;302us;312us;322us;332us;342us;352us;362us;372us;382us;392us;402us;412us;422us;425us;426us;428us;429us;431us;432us;433us;434us;436us;439us;449us;459us;460us;462us;472us;482us;483us;493us;494us;495us;496us;497us;|]
let _fsyacc_reductionSymbolCounts = [|1us;2us;3us;5us;1us;1us;6us;2us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;2us;2us;3us;3us;1us;1us;7us;8us;3us;2us;2us;1us;1us;|]
let _fsyacc_productionToNonTerminalTable = [|0us;1us;2us;2us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;4us;4us;4us;4us;4us;5us;5us;6us;6us;|]
let _fsyacc_immediateActions = [|65535us;49152us;65535us;16385us;65535us;65535us;65535us;65535us;16387us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;16404us;65535us;16405us;65535us;16406us;16407us;16408us;65535us;65535us;65535us;65535us;16409us;65535us;65535us;65535us;16410us;65535us;16411us;16412us;16413us;16414us;16415us;|]
let _fsyacc_reductions = lazy [|
# 287 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : 'gentype__startMain));
# 296 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 35 "FunPar.fsy"
                                                               _1 
                   )
# 35 "FunPar.fsy"
                 : Absyn.expr));
# 307 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 39 "FunPar.fsy"
                                                               [(_1, _3)]             
                   )
# 39 "FunPar.fsy"
                 : 'gentype_ExprLst));
# 319 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            let _5 = parseState.GetInput(5) :?> 'gentype_ExprLst in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 40 "FunPar.fsy"
                                                               (_1, _3) :: _5         
                   )
# 40 "FunPar.fsy"
                 : 'gentype_ExprLst));
# 332 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 44 "FunPar.fsy"
                                                               _1                     
                   )
# 44 "FunPar.fsy"
                 : Absyn.expr));
# 343 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 45 "FunPar.fsy"
                                                               _1                     
                   )
# 45 "FunPar.fsy"
                 : Absyn.expr));
# 354 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            let _4 = parseState.GetInput(4) :?> Absyn.expr in
            let _6 = parseState.GetInput(6) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 46 "FunPar.fsy"
                                                               If(_2, _4, _6)         
                   )
# 46 "FunPar.fsy"
                 : Absyn.expr));
# 367 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 47 "FunPar.fsy"
                                                               Prim("-", CstI 0, _2)  
                   )
# 47 "FunPar.fsy"
                 : Absyn.expr));
# 378 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 48 "FunPar.fsy"
                                                               Prim("+",  _1, _3)     
                   )
# 48 "FunPar.fsy"
                 : Absyn.expr));
# 390 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 49 "FunPar.fsy"
                                                               Prim("-",  _1, _3)     
                   )
# 49 "FunPar.fsy"
                 : Absyn.expr));
# 402 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 50 "FunPar.fsy"
                                                               Prim("*",  _1, _3)     
                   )
# 50 "FunPar.fsy"
                 : Absyn.expr));
# 414 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 51 "FunPar.fsy"
                                                               Prim("/",  _1, _3)     
                   )
# 51 "FunPar.fsy"
                 : Absyn.expr));
# 426 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 52 "FunPar.fsy"
                                                               Prim("%",  _1, _3)     
                   )
# 52 "FunPar.fsy"
                 : Absyn.expr));
# 438 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 53 "FunPar.fsy"
                                                               Prim("=",  _1, _3)     
                   )
# 53 "FunPar.fsy"
                 : Absyn.expr));
# 450 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 54 "FunPar.fsy"
                                                               Prim("<>", _1, _3)     
                   )
# 54 "FunPar.fsy"
                 : Absyn.expr));
# 462 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 55 "FunPar.fsy"
                                                               Prim(">",  _1, _3)     
                   )
# 55 "FunPar.fsy"
                 : Absyn.expr));
# 474 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 56 "FunPar.fsy"
                                                               Prim("<",  _1, _3)     
                   )
# 56 "FunPar.fsy"
                 : Absyn.expr));
# 486 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 57 "FunPar.fsy"
                                                               Prim(">=", _1, _3)     
                   )
# 57 "FunPar.fsy"
                 : Absyn.expr));
# 498 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 58 "FunPar.fsy"
                                                               Prim("<=", _1, _3)     
                   )
# 58 "FunPar.fsy"
                 : Absyn.expr));
# 510 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 59 "FunPar.fsy"
                                                               Print(_2)              
                   )
# 59 "FunPar.fsy"
                 : Absyn.expr));
# 521 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 60 "FunPar.fsy"
                                                               Record([])             
                   )
# 60 "FunPar.fsy"
                 : Absyn.expr));
# 531 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> 'gentype_ExprLst in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 61 "FunPar.fsy"
                                                               Record(_2)             
                   )
# 61 "FunPar.fsy"
                 : Absyn.expr));
# 542 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 62 "FunPar.fsy"
                                                               Field(_1, _3)          
                   )
# 62 "FunPar.fsy"
                 : Absyn.expr));
# 554 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 69 "FunPar.fsy"
                                                               _1                     
                   )
# 69 "FunPar.fsy"
                 : Absyn.expr));
# 565 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 70 "FunPar.fsy"
                                                               Var _1                 
                   )
# 70 "FunPar.fsy"
                 : Absyn.expr));
# 576 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> string in
            let _4 = parseState.GetInput(4) :?> Absyn.expr in
            let _6 = parseState.GetInput(6) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 71 "FunPar.fsy"
                                                               Let(_2, _4, _6)        
                   )
# 71 "FunPar.fsy"
                 : Absyn.expr));
# 589 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> string in
            let _3 = parseState.GetInput(3) :?> string in
            let _5 = parseState.GetInput(5) :?> Absyn.expr in
            let _7 = parseState.GetInput(7) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 72 "FunPar.fsy"
                                                               Letfun(_2, _3, _5, _7) 
                   )
# 72 "FunPar.fsy"
                 : Absyn.expr));
# 603 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 73 "FunPar.fsy"
                                                               _2                     
                   )
# 73 "FunPar.fsy"
                 : Absyn.expr));
# 614 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 77 "FunPar.fsy"
                                                               Call(_1, _2)           
                   )
# 77 "FunPar.fsy"
                 : Absyn.expr));
# 626 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 78 "FunPar.fsy"
                                                               Call(_1, _2)           
                   )
# 78 "FunPar.fsy"
                 : Absyn.expr));
# 638 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 82 "FunPar.fsy"
                                                               CstI(_1)               
                   )
# 82 "FunPar.fsy"
                 : Absyn.expr));
# 649 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> bool in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 83 "FunPar.fsy"
                                                               CstB(_1)               
                   )
# 83 "FunPar.fsy"
                 : Absyn.expr));
|]
# 661 "FunPar.fs"
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
    numTerminals = 34;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = tables.Interpret(lexer, lexbuf, startState)
let Main lexer lexbuf : Absyn.expr =
    engine lexer lexbuf 0 :?> _
