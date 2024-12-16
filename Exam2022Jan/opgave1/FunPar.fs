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
  | COMMA
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
  | UNION
  | ELSE
  | END
  | FALSE
  | IF
  | IN
  | LET
  | NOT
  | THEN
  | TRUE
  | CSTBOOL of (bool)
  | NAME of (string)
  | CSTINT of (int)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_COMMA
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
    | TOKEN_UNION
    | TOKEN_ELSE
    | TOKEN_END
    | TOKEN_FALSE
    | TOKEN_IF
    | TOKEN_IN
    | TOKEN_LET
    | TOKEN_NOT
    | TOKEN_THEN
    | TOKEN_TRUE
    | TOKEN_CSTBOOL
    | TOKEN_NAME
    | TOKEN_CSTINT
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startMain
    | NONTERM_Main
    | NONTERM_Expr
    | NONTERM_Lst
    | NONTERM_AtExpr
    | NONTERM_AppExpr
    | NONTERM_Const

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | COMMA  -> 1 
  | LPAR  -> 2 
  | RPAR  -> 3 
  | LBRA  -> 4 
  | RBRA  -> 5 
  | EQ  -> 6 
  | NE  -> 7 
  | GT  -> 8 
  | LT  -> 9 
  | GE  -> 10 
  | LE  -> 11 
  | PLUS  -> 12 
  | MINUS  -> 13 
  | TIMES  -> 14 
  | DIV  -> 15 
  | MOD  -> 16 
  | UNION  -> 17 
  | ELSE  -> 18 
  | END  -> 19 
  | FALSE  -> 20 
  | IF  -> 21 
  | IN  -> 22 
  | LET  -> 23 
  | NOT  -> 24 
  | THEN  -> 25 
  | TRUE  -> 26 
  | CSTBOOL _ -> 27 
  | NAME _ -> 28 
  | CSTINT _ -> 29 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_COMMA 
  | 2 -> TOKEN_LPAR 
  | 3 -> TOKEN_RPAR 
  | 4 -> TOKEN_LBRA 
  | 5 -> TOKEN_RBRA 
  | 6 -> TOKEN_EQ 
  | 7 -> TOKEN_NE 
  | 8 -> TOKEN_GT 
  | 9 -> TOKEN_LT 
  | 10 -> TOKEN_GE 
  | 11 -> TOKEN_LE 
  | 12 -> TOKEN_PLUS 
  | 13 -> TOKEN_MINUS 
  | 14 -> TOKEN_TIMES 
  | 15 -> TOKEN_DIV 
  | 16 -> TOKEN_MOD 
  | 17 -> TOKEN_UNION 
  | 18 -> TOKEN_ELSE 
  | 19 -> TOKEN_END 
  | 20 -> TOKEN_FALSE 
  | 21 -> TOKEN_IF 
  | 22 -> TOKEN_IN 
  | 23 -> TOKEN_LET 
  | 24 -> TOKEN_NOT 
  | 25 -> TOKEN_THEN 
  | 26 -> TOKEN_TRUE 
  | 27 -> TOKEN_CSTBOOL 
  | 28 -> TOKEN_NAME 
  | 29 -> TOKEN_CSTINT 
  | 32 -> TOKEN_end_of_input
  | 30 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startMain 
    | 1 -> NONTERM_Main 
    | 2 -> NONTERM_Expr 
    | 3 -> NONTERM_Expr 
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
    | 19 -> NONTERM_Lst 
    | 20 -> NONTERM_Lst 
    | 21 -> NONTERM_AtExpr 
    | 22 -> NONTERM_AtExpr 
    | 23 -> NONTERM_AtExpr 
    | 24 -> NONTERM_AtExpr 
    | 25 -> NONTERM_AtExpr 
    | 26 -> NONTERM_AppExpr 
    | 27 -> NONTERM_AppExpr 
    | 28 -> NONTERM_Const 
    | 29 -> NONTERM_Const 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 32 
let _fsyacc_tagOfErrorTerminal = 30

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | COMMA  -> "COMMA" 
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
  | UNION  -> "UNION" 
  | ELSE  -> "ELSE" 
  | END  -> "END" 
  | FALSE  -> "FALSE" 
  | IF  -> "IF" 
  | IN  -> "IN" 
  | LET  -> "LET" 
  | NOT  -> "NOT" 
  | THEN  -> "THEN" 
  | TRUE  -> "TRUE" 
  | CSTBOOL _ -> "CSTBOOL" 
  | NAME _ -> "NAME" 
  | CSTINT _ -> "CSTINT" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | COMMA  -> (null : System.Object) 
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
  | UNION  -> (null : System.Object) 
  | ELSE  -> (null : System.Object) 
  | END  -> (null : System.Object) 
  | FALSE  -> (null : System.Object) 
  | IF  -> (null : System.Object) 
  | IN  -> (null : System.Object) 
  | LET  -> (null : System.Object) 
  | NOT  -> (null : System.Object) 
  | THEN  -> (null : System.Object) 
  | TRUE  -> (null : System.Object) 
  | CSTBOOL _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | NAME _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | CSTINT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us;65535us;1us;65535us;0us;1us;24us;65535us;0us;2us;6us;7us;8us;9us;10us;11us;12us;13us;32us;14us;33us;15us;34us;16us;35us;17us;36us;18us;37us;19us;38us;20us;39us;21us;40us;22us;41us;23us;42us;24us;43us;25us;44us;26us;47us;26us;53us;27us;54us;28us;57us;29us;58us;30us;60us;31us;2us;65535us;44us;45us;47us;48us;26us;65535us;0us;4us;4us;62us;5us;63us;6us;4us;8us;4us;10us;4us;12us;4us;32us;4us;33us;4us;34us;4us;35us;4us;36us;4us;37us;4us;38us;4us;39us;4us;40us;4us;41us;4us;42us;4us;43us;4us;44us;4us;47us;4us;53us;4us;54us;4us;57us;4us;58us;4us;60us;4us;24us;65535us;0us;5us;6us;5us;8us;5us;10us;5us;12us;5us;32us;5us;33us;5us;34us;5us;35us;5us;36us;5us;37us;5us;38us;5us;39us;5us;40us;5us;41us;5us;42us;5us;43us;5us;44us;5us;47us;5us;53us;5us;54us;5us;57us;5us;58us;5us;60us;5us;26us;65535us;0us;49us;4us;49us;5us;49us;6us;49us;8us;49us;10us;49us;12us;49us;32us;49us;33us;49us;34us;49us;35us;49us;36us;49us;37us;49us;38us;49us;39us;49us;40us;49us;41us;49us;42us;49us;43us;49us;44us;49us;47us;49us;53us;49us;54us;49us;57us;49us;58us;49us;60us;49us;|]
let _fsyacc_sparseGotoTableRowOffsets = [|0us;1us;3us;28us;31us;58us;83us;|]
let _fsyacc_stateToProdIdxsTableElements = [| 1us;0us;1us;0us;13us;1us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;1us;1us;2us;2us;26us;2us;3us;27us;1us;4us;13us;4us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;1us;4us;13us;4us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;1us;4us;13us;4us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;1us;5us;13us;5us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;13us;6us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;13us;6us;7us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;13us;6us;7us;8us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;13us;6us;7us;8us;9us;9us;10us;11us;12us;13us;14us;15us;16us;17us;13us;6us;7us;8us;9us;10us;10us;11us;12us;13us;14us;15us;16us;17us;13us;6us;7us;8us;9us;10us;11us;11us;12us;13us;14us;15us;16us;17us;13us;6us;7us;8us;9us;10us;11us;12us;12us;13us;14us;15us;16us;17us;13us;6us;7us;8us;9us;10us;11us;12us;13us;13us;14us;15us;16us;17us;13us;6us;7us;8us;9us;10us;11us;12us;13us;14us;14us;15us;16us;17us;13us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;15us;16us;17us;13us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;16us;17us;13us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;17us;14us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;19us;20us;13us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;23us;13us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;23us;13us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;24us;13us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;24us;13us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;25us;1us;6us;1us;7us;1us;8us;1us;9us;1us;10us;1us;11us;1us;12us;1us;13us;1us;14us;1us;15us;1us;16us;1us;17us;1us;18us;1us;18us;1us;18us;1us;20us;1us;20us;1us;21us;1us;22us;2us;23us;24us;2us;23us;24us;1us;23us;1us;23us;1us;23us;1us;24us;1us;24us;1us;24us;1us;24us;1us;25us;1us;25us;1us;26us;1us;27us;1us;28us;1us;29us;|]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us;2us;4us;18us;20us;23us;26us;28us;42us;44us;58us;60us;74us;76us;90us;104us;118us;132us;146us;160us;174us;188us;202us;216us;230us;244us;258us;273us;287us;301us;315us;329us;343us;345us;347us;349us;351us;353us;355us;357us;359us;361us;363us;365us;367us;369us;371us;373us;375us;377us;379us;381us;384us;387us;389us;391us;393us;395us;397us;399us;401us;403us;405us;407us;409us;411us;|]
let _fsyacc_action_rows = 66
let _fsyacc_actionTableElements = [|8us;32768us;2us;60us;4us;44us;13us;12us;21us;6us;23us;51us;27us;65us;28us;50us;29us;64us;0us;49152us;13us;32768us;0us;3us;6us;38us;7us;39us;8us;40us;9us;41us;10us;42us;11us;43us;12us;32us;13us;34us;14us;35us;15us;36us;16us;37us;17us;33us;0us;16385us;5us;16386us;2us;60us;23us;51us;27us;65us;28us;50us;29us;64us;5us;16387us;2us;60us;23us;51us;27us;65us;28us;50us;29us;64us;8us;32768us;2us;60us;4us;44us;13us;12us;21us;6us;23us;51us;27us;65us;28us;50us;29us;64us;13us;32768us;6us;38us;7us;39us;8us;40us;9us;41us;10us;42us;11us;43us;12us;32us;13us;34us;14us;35us;15us;36us;16us;37us;17us;33us;25us;8us;8us;32768us;2us;60us;4us;44us;13us;12us;21us;6us;23us;51us;27us;65us;28us;50us;29us;64us;13us;32768us;6us;38us;7us;39us;8us;40us;9us;41us;10us;42us;11us;43us;12us;32us;13us;34us;14us;35us;15us;36us;16us;37us;17us;33us;18us;10us;8us;32768us;2us;60us;4us;44us;13us;12us;21us;6us;23us;51us;27us;65us;28us;50us;29us;64us;12us;16388us;6us;38us;7us;39us;8us;40us;9us;41us;10us;42us;11us;43us;12us;32us;13us;34us;14us;35us;15us;36us;16us;37us;17us;33us;8us;32768us;2us;60us;4us;44us;13us;12us;21us;6us;23us;51us;27us;65us;28us;50us;29us;64us;3us;16389us;14us;35us;15us;36us;16us;37us;3us;16390us;14us;35us;15us;36us;16us;37us;3us;16391us;14us;35us;15us;36us;16us;37us;3us;16392us;14us;35us;15us;36us;16us;37us;0us;16393us;0us;16394us;0us;16395us;10us;16396us;8us;40us;9us;41us;10us;42us;11us;43us;12us;32us;13us;34us;14us;35us;15us;36us;16us;37us;17us;33us;10us;16397us;8us;40us;9us;41us;10us;42us;11us;43us;12us;32us;13us;34us;14us;35us;15us;36us;16us;37us;17us;33us;6us;16398us;12us;32us;13us;34us;14us;35us;15us;36us;16us;37us;17us;33us;6us;16399us;12us;32us;13us;34us;14us;35us;15us;36us;16us;37us;17us;33us;6us;16400us;12us;32us;13us;34us;14us;35us;15us;36us;16us;37us;17us;33us;6us;16401us;12us;32us;13us;34us;14us;35us;15us;36us;16us;37us;17us;33us;13us;16403us;1us;47us;6us;38us;7us;39us;8us;40us;9us;41us;10us;42us;11us;43us;12us;32us;13us;34us;14us;35us;15us;36us;16us;37us;17us;33us;13us;32768us;6us;38us;7us;39us;8us;40us;9us;41us;10us;42us;11us;43us;12us;32us;13us;34us;14us;35us;15us;36us;16us;37us;17us;33us;22us;54us;13us;32768us;6us;38us;7us;39us;8us;40us;9us;41us;10us;42us;11us;43us;12us;32us;13us;34us;14us;35us;15us;36us;16us;37us;17us;33us;19us;55us;13us;32768us;6us;38us;7us;39us;8us;40us;9us;41us;10us;42us;11us;43us;12us;32us;13us;34us;14us;35us;15us;36us;16us;37us;17us;33us;22us;58us;13us;32768us;6us;38us;7us;39us;8us;40us;9us;41us;10us;42us;11us;43us;12us;32us;13us;34us;14us;35us;15us;36us;16us;37us;17us;33us;19us;59us;13us;32768us;3us;61us;6us;38us;7us;39us;8us;40us;9us;41us;10us;42us;11us;43us;12us;32us;13us;34us;14us;35us;15us;36us;16us;37us;17us;33us;8us;32768us;2us;60us;4us;44us;13us;12us;21us;6us;23us;51us;27us;65us;28us;50us;29us;64us;8us;32768us;2us;60us;4us;44us;13us;12us;21us;6us;23us;51us;27us;65us;28us;50us;29us;64us;8us;32768us;2us;60us;4us;44us;13us;12us;21us;6us;23us;51us;27us;65us;28us;50us;29us;64us;8us;32768us;2us;60us;4us;44us;13us;12us;21us;6us;23us;51us;27us;65us;28us;50us;29us;64us;8us;32768us;2us;60us;4us;44us;13us;12us;21us;6us;23us;51us;27us;65us;28us;50us;29us;64us;8us;32768us;2us;60us;4us;44us;13us;12us;21us;6us;23us;51us;27us;65us;28us;50us;29us;64us;8us;32768us;2us;60us;4us;44us;13us;12us;21us;6us;23us;51us;27us;65us;28us;50us;29us;64us;8us;32768us;2us;60us;4us;44us;13us;12us;21us;6us;23us;51us;27us;65us;28us;50us;29us;64us;8us;32768us;2us;60us;4us;44us;13us;12us;21us;6us;23us;51us;27us;65us;28us;50us;29us;64us;8us;32768us;2us;60us;4us;44us;13us;12us;21us;6us;23us;51us;27us;65us;28us;50us;29us;64us;8us;32768us;2us;60us;4us;44us;13us;12us;21us;6us;23us;51us;27us;65us;28us;50us;29us;64us;8us;32768us;2us;60us;4us;44us;13us;12us;21us;6us;23us;51us;27us;65us;28us;50us;29us;64us;8us;32768us;2us;60us;4us;44us;13us;12us;21us;6us;23us;51us;27us;65us;28us;50us;29us;64us;1us;32768us;5us;46us;0us;16402us;8us;32768us;2us;60us;4us;44us;13us;12us;21us;6us;23us;51us;27us;65us;28us;50us;29us;64us;0us;16404us;0us;16405us;0us;16406us;1us;32768us;28us;52us;2us;32768us;6us;53us;28us;56us;8us;32768us;2us;60us;4us;44us;13us;12us;21us;6us;23us;51us;27us;65us;28us;50us;29us;64us;8us;32768us;2us;60us;4us;44us;13us;12us;21us;6us;23us;51us;27us;65us;28us;50us;29us;64us;0us;16407us;1us;32768us;6us;57us;8us;32768us;2us;60us;4us;44us;13us;12us;21us;6us;23us;51us;27us;65us;28us;50us;29us;64us;8us;32768us;2us;60us;4us;44us;13us;12us;21us;6us;23us;51us;27us;65us;28us;50us;29us;64us;0us;16408us;8us;32768us;2us;60us;4us;44us;13us;12us;21us;6us;23us;51us;27us;65us;28us;50us;29us;64us;0us;16409us;0us;16410us;0us;16411us;0us;16412us;0us;16413us;|]
let _fsyacc_actionTableRowOffsets = [|0us;9us;10us;24us;25us;31us;37us;46us;60us;69us;83us;92us;105us;114us;118us;122us;126us;130us;131us;132us;133us;144us;155us;162us;169us;176us;183us;197us;211us;225us;239us;253us;267us;276us;285us;294us;303us;312us;321us;330us;339us;348us;357us;366us;375us;384us;386us;387us;396us;397us;398us;399us;401us;404us;413us;422us;423us;425us;434us;443us;444us;453us;454us;455us;456us;457us;|]
let _fsyacc_reductionSymbolCounts = [|1us;2us;1us;1us;6us;2us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;1us;3us;1us;1us;7us;8us;3us;2us;2us;1us;1us;|]
let _fsyacc_productionToNonTerminalTable = [|0us;1us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;3us;3us;4us;4us;4us;4us;4us;5us;5us;6us;6us;|]
let _fsyacc_immediateActions = [|65535us;49152us;65535us;16385us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;16402us;65535us;16404us;16405us;16406us;65535us;65535us;65535us;65535us;16407us;65535us;65535us;65535us;16408us;65535us;16409us;16410us;16411us;16412us;16413us;|]
let _fsyacc_reductions = lazy [|
# 279 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : 'gentype__startMain));
# 288 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 34 "FunPar.fsy"
                                                               _1 
                   )
# 34 "FunPar.fsy"
                 : Absyn.expr));
# 299 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 38 "FunPar.fsy"
                                                               _1                     
                   )
# 38 "FunPar.fsy"
                 : Absyn.expr));
# 310 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 39 "FunPar.fsy"
                                                               _1                     
                   )
# 39 "FunPar.fsy"
                 : Absyn.expr));
# 321 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            let _4 = parseState.GetInput(4) :?> Absyn.expr in
            let _6 = parseState.GetInput(6) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 40 "FunPar.fsy"
                                                               If(_2, _4, _6)         
                   )
# 40 "FunPar.fsy"
                 : Absyn.expr));
# 334 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 41 "FunPar.fsy"
                                                               Prim("-", CstI 0, _2)  
                   )
# 41 "FunPar.fsy"
                 : Absyn.expr));
# 345 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 42 "FunPar.fsy"
                                                               Prim("+",  _1, _3)     
                   )
# 42 "FunPar.fsy"
                 : Absyn.expr));
# 357 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 43 "FunPar.fsy"
                                                               Prim("++",  _1, _3)    
                   )
# 43 "FunPar.fsy"
                 : Absyn.expr));
# 369 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 44 "FunPar.fsy"
                                                               Prim("-",  _1, _3)     
                   )
# 44 "FunPar.fsy"
                 : Absyn.expr));
# 381 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 45 "FunPar.fsy"
                                                               Prim("*",  _1, _3)     
                   )
# 45 "FunPar.fsy"
                 : Absyn.expr));
# 393 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 46 "FunPar.fsy"
                                                               Prim("/",  _1, _3)     
                   )
# 46 "FunPar.fsy"
                 : Absyn.expr));
# 405 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 47 "FunPar.fsy"
                                                               Prim("%",  _1, _3)     
                   )
# 47 "FunPar.fsy"
                 : Absyn.expr));
# 417 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 48 "FunPar.fsy"
                                                               Prim("=",  _1, _3)     
                   )
# 48 "FunPar.fsy"
                 : Absyn.expr));
# 429 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 49 "FunPar.fsy"
                                                               Prim("<>", _1, _3)     
                   )
# 49 "FunPar.fsy"
                 : Absyn.expr));
# 441 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 50 "FunPar.fsy"
                                                               Prim(">",  _1, _3)     
                   )
# 50 "FunPar.fsy"
                 : Absyn.expr));
# 453 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 51 "FunPar.fsy"
                                                               Prim("<",  _1, _3)     
                   )
# 51 "FunPar.fsy"
                 : Absyn.expr));
# 465 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 52 "FunPar.fsy"
                                                               Prim(">=", _1, _3)     
                   )
# 52 "FunPar.fsy"
                 : Absyn.expr));
# 477 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 53 "FunPar.fsy"
                                                               Prim("<=", _1, _3)     
                   )
# 53 "FunPar.fsy"
                 : Absyn.expr));
# 489 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> 'gentype_Lst in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 54 "FunPar.fsy"
                                                               Set(_2)                
                   )
# 54 "FunPar.fsy"
                 : Absyn.expr));
# 500 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 58 "FunPar.fsy"
                                                              [_1] 
                   )
# 58 "FunPar.fsy"
                 : 'gentype_Lst));
# 511 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> 'gentype_Lst in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 59 "FunPar.fsy"
                                                              _1 :: _3
                   )
# 59 "FunPar.fsy"
                 : 'gentype_Lst));
# 523 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 63 "FunPar.fsy"
                                                               _1                     
                   )
# 63 "FunPar.fsy"
                 : Absyn.expr));
# 534 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 64 "FunPar.fsy"
                                                               Var _1                 
                   )
# 64 "FunPar.fsy"
                 : Absyn.expr));
# 545 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> string in
            let _4 = parseState.GetInput(4) :?> Absyn.expr in
            let _6 = parseState.GetInput(6) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 65 "FunPar.fsy"
                                                               Let(_2, _4, _6)        
                   )
# 65 "FunPar.fsy"
                 : Absyn.expr));
# 558 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> string in
            let _3 = parseState.GetInput(3) :?> string in
            let _5 = parseState.GetInput(5) :?> Absyn.expr in
            let _7 = parseState.GetInput(7) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 66 "FunPar.fsy"
                                                               Letfun(_2, _3, _5, _7) 
                   )
# 66 "FunPar.fsy"
                 : Absyn.expr));
# 572 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 67 "FunPar.fsy"
                                                               _2                     
                   )
# 67 "FunPar.fsy"
                 : Absyn.expr));
# 583 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 71 "FunPar.fsy"
                                                               Call(_1, _2)           
                   )
# 71 "FunPar.fsy"
                 : Absyn.expr));
# 595 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 72 "FunPar.fsy"
                                                               Call(_1, _2)           
                   )
# 72 "FunPar.fsy"
                 : Absyn.expr));
# 607 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 76 "FunPar.fsy"
                                                               CstI(_1)               
                   )
# 76 "FunPar.fsy"
                 : Absyn.expr));
# 618 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> bool in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 77 "FunPar.fsy"
                                                               CstB(_1)               
                   )
# 77 "FunPar.fsy"
                 : Absyn.expr));
|]
# 630 "FunPar.fs"
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
    numTerminals = 33;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = tables.Interpret(lexer, lexbuf, startState)
let Main lexer lexbuf : Absyn.expr =
    engine lexer lexbuf 0 :?> _