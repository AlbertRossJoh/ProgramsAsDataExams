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
  | PIPE
  | ENUM
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
    | TOKEN_PIPE
    | TOKEN_ENUM
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
  | PIPE  -> 28 
  | ENUM  -> 29 
  | CSTBOOL _ -> 30 
  | NAME _ -> 31 
  | CSTINT _ -> 32 

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
  | 28 -> TOKEN_PIPE 
  | 29 -> TOKEN_ENUM 
  | 30 -> TOKEN_CSTBOOL 
  | 31 -> TOKEN_NAME 
  | 32 -> TOKEN_CSTINT 
  | 35 -> TOKEN_end_of_input
  | 33 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startMain 
    | 1 -> NONTERM_Main 
    | 2 -> NONTERM_ExprLst 
    | 3 -> NONTERM_ExprLst 
    | 4 -> NONTERM_ExprLst 
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
    | 22 -> NONTERM_AtExpr 
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

let _fsyacc_endOfInputTag = 35 
let _fsyacc_tagOfErrorTerminal = 33

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
  | PIPE  -> "PIPE" 
  | ENUM  -> "ENUM" 
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
  | PIPE  -> (null : System.Object) 
  | ENUM  -> (null : System.Object) 
  | CSTBOOL _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | NAME _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | CSTINT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us;65535us;1us;65535us;0us;1us;2us;65535us;5us;6us;63us;64us;23us;65535us;0us;2us;9us;10us;11us;12us;13us;14us;15us;16us;35us;17us;36us;18us;37us;19us;38us;20us;39us;21us;40us;22us;41us;23us;42us;24us;43us;25us;44us;26us;45us;27us;46us;28us;54us;29us;55us;30us;58us;31us;59us;32us;65us;33us;67us;34us;25us;65535us;0us;7us;7us;69us;8us;70us;9us;7us;11us;7us;13us;7us;15us;7us;35us;7us;36us;7us;37us;7us;38us;7us;39us;7us;40us;7us;41us;7us;42us;7us;43us;7us;44us;7us;45us;7us;46us;7us;54us;7us;55us;7us;58us;7us;59us;7us;65us;7us;67us;7us;23us;65535us;0us;8us;9us;8us;11us;8us;13us;8us;15us;8us;35us;8us;36us;8us;37us;8us;38us;8us;39us;8us;40us;8us;41us;8us;42us;8us;43us;8us;44us;8us;45us;8us;46us;8us;54us;8us;55us;8us;58us;8us;59us;8us;65us;8us;67us;8us;25us;65535us;0us;50us;7us;50us;8us;50us;9us;50us;11us;50us;13us;50us;15us;50us;35us;50us;36us;50us;37us;50us;38us;50us;39us;50us;40us;50us;41us;50us;42us;50us;43us;50us;44us;50us;45us;50us;46us;50us;54us;50us;55us;50us;58us;50us;59us;50us;65us;50us;67us;50us;|]
let _fsyacc_sparseGotoTableRowOffsets = [|0us;1us;3us;6us;30us;56us;80us;|]
let _fsyacc_stateToProdIdxsTableElements = [| 1us;0us;1us;0us;12us;1us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;19us;1us;1us;2us;3us;4us;1us;4us;1us;4us;2us;5us;28us;2us;6us;29us;1us;7us;12us;7us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;19us;1us;7us;12us;7us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;19us;1us;7us;12us;7us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;19us;1us;8us;12us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;19us;12us;9us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;19us;12us;9us;10us;10us;11us;12us;13us;14us;15us;16us;17us;18us;19us;12us;9us;10us;11us;11us;12us;13us;14us;15us;16us;17us;18us;19us;12us;9us;10us;11us;12us;12us;13us;14us;15us;16us;17us;18us;19us;12us;9us;10us;11us;12us;13us;13us;14us;15us;16us;17us;18us;19us;12us;9us;10us;11us;12us;13us;14us;14us;15us;16us;17us;18us;19us;12us;9us;10us;11us;12us;13us;14us;15us;15us;16us;17us;18us;19us;12us;9us;10us;11us;12us;13us;14us;15us;16us;16us;17us;18us;19us;12us;9us;10us;11us;12us;13us;14us;15us;16us;17us;17us;18us;19us;12us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;18us;19us;12us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;19us;19us;12us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;19us;20us;12us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;19us;24us;12us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;19us;24us;12us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;19us;25us;12us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;19us;25us;12us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;19us;26us;12us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;19us;27us;1us;9us;1us;10us;1us;11us;1us;12us;1us;13us;1us;14us;1us;15us;1us;16us;1us;17us;1us;18us;1us;19us;1us;20us;2us;21us;23us;1us;21us;1us;21us;1us;22us;1us;23us;2us;24us;25us;2us;24us;25us;1us;24us;1us;24us;1us;24us;1us;25us;1us;25us;1us;25us;1us;25us;1us;26us;1us;26us;1us;26us;1us;26us;1us;26us;1us;26us;1us;27us;1us;27us;1us;28us;1us;29us;1us;30us;1us;31us;|]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us;2us;4us;17us;19us;22us;24us;26us;29us;32us;34us;47us;49us;62us;64us;77us;79us;92us;105us;118us;131us;144us;157us;170us;183us;196us;209us;222us;235us;248us;261us;274us;287us;300us;313us;326us;328us;330us;332us;334us;336us;338us;340us;342us;344us;346us;348us;350us;353us;355us;357us;359us;361us;364us;367us;369us;371us;373us;375us;377us;379us;381us;383us;385us;387us;389us;391us;393us;395us;397us;399us;401us;403us;|]
let _fsyacc_action_rows = 73
let _fsyacc_actionTableElements = [|9us;32768us;1us;67us;12us;15us;19us;9us;21us;52us;25us;46us;29us;61us;30us;72us;31us;47us;32us;71us;0us;49152us;12us;32768us;0us;3us;5us;40us;6us;41us;7us;42us;8us;43us;9us;44us;10us;45us;11us;35us;12us;36us;13us;37us;14us;38us;15us;39us;0us;16385us;1us;16387us;28us;5us;1us;16386us;31us;4us;0us;16388us;6us;16389us;1us;67us;21us;52us;29us;61us;30us;72us;31us;51us;32us;71us;6us;16390us;1us;67us;21us;52us;29us;61us;30us;72us;31us;51us;32us;71us;9us;32768us;1us;67us;12us;15us;19us;9us;21us;52us;25us;46us;29us;61us;30us;72us;31us;47us;32us;71us;12us;32768us;5us;40us;6us;41us;7us;42us;8us;43us;9us;44us;10us;45us;11us;35us;12us;36us;13us;37us;14us;38us;15us;39us;23us;11us;9us;32768us;1us;67us;12us;15us;19us;9us;21us;52us;25us;46us;29us;61us;30us;72us;31us;47us;32us;71us;12us;32768us;5us;40us;6us;41us;7us;42us;8us;43us;9us;44us;10us;45us;11us;35us;12us;36us;13us;37us;14us;38us;15us;39us;16us;13us;9us;32768us;1us;67us;12us;15us;19us;9us;21us;52us;25us;46us;29us;61us;30us;72us;31us;47us;32us;71us;11us;16391us;5us;40us;6us;41us;7us;42us;8us;43us;9us;44us;10us;45us;11us;35us;12us;36us;13us;37us;14us;38us;15us;39us;9us;32768us;1us;67us;12us;15us;19us;9us;21us;52us;25us;46us;29us;61us;30us;72us;31us;47us;32us;71us;3us;16392us;13us;37us;14us;38us;15us;39us;3us;16393us;13us;37us;14us;38us;15us;39us;3us;16394us;13us;37us;14us;38us;15us;39us;0us;16395us;0us;16396us;0us;16397us;9us;16398us;7us;42us;8us;43us;9us;44us;10us;45us;11us;35us;12us;36us;13us;37us;14us;38us;15us;39us;9us;16399us;7us;42us;8us;43us;9us;44us;10us;45us;11us;35us;12us;36us;13us;37us;14us;38us;15us;39us;5us;16400us;11us;35us;12us;36us;13us;37us;14us;38us;15us;39us;5us;16401us;11us;35us;12us;36us;13us;37us;14us;38us;15us;39us;5us;16402us;11us;35us;12us;36us;13us;37us;14us;38us;15us;39us;5us;16403us;11us;35us;12us;36us;13us;37us;14us;38us;15us;39us;11us;16404us;5us;40us;6us;41us;7us;42us;8us;43us;9us;44us;10us;45us;11us;35us;12us;36us;13us;37us;14us;38us;15us;39us;12us;32768us;5us;40us;6us;41us;7us;42us;8us;43us;9us;44us;10us;45us;11us;35us;12us;36us;13us;37us;14us;38us;15us;39us;20us;55us;12us;32768us;5us;40us;6us;41us;7us;42us;8us;43us;9us;44us;10us;45us;11us;35us;12us;36us;13us;37us;14us;38us;15us;39us;17us;56us;12us;32768us;5us;40us;6us;41us;7us;42us;8us;43us;9us;44us;10us;45us;11us;35us;12us;36us;13us;37us;14us;38us;15us;39us;20us;59us;12us;32768us;5us;40us;6us;41us;7us;42us;8us;43us;9us;44us;10us;45us;11us;35us;12us;36us;13us;37us;14us;38us;15us;39us;17us;60us;12us;32768us;5us;40us;6us;41us;7us;42us;8us;43us;9us;44us;10us;45us;11us;35us;12us;36us;13us;37us;14us;38us;15us;39us;17us;66us;12us;32768us;2us;68us;5us;40us;6us;41us;7us;42us;8us;43us;9us;44us;10us;45us;11us;35us;12us;36us;13us;37us;14us;38us;15us;39us;9us;32768us;1us;67us;12us;15us;19us;9us;21us;52us;25us;46us;29us;61us;30us;72us;31us;47us;32us;71us;9us;32768us;1us;67us;12us;15us;19us;9us;21us;52us;25us;46us;29us;61us;30us;72us;31us;47us;32us;71us;9us;32768us;1us;67us;12us;15us;19us;9us;21us;52us;25us;46us;29us;61us;30us;72us;31us;47us;32us;71us;9us;32768us;1us;67us;12us;15us;19us;9us;21us;52us;25us;46us;29us;61us;30us;72us;31us;47us;32us;71us;9us;32768us;1us;67us;12us;15us;19us;9us;21us;52us;25us;46us;29us;61us;30us;72us;31us;47us;32us;71us;9us;32768us;1us;67us;12us;15us;19us;9us;21us;52us;25us;46us;29us;61us;30us;72us;31us;47us;32us;71us;9us;32768us;1us;67us;12us;15us;19us;9us;21us;52us;25us;46us;29us;61us;30us;72us;31us;47us;32us;71us;9us;32768us;1us;67us;12us;15us;19us;9us;21us;52us;25us;46us;29us;61us;30us;72us;31us;47us;32us;71us;9us;32768us;1us;67us;12us;15us;19us;9us;21us;52us;25us;46us;29us;61us;30us;72us;31us;47us;32us;71us;9us;32768us;1us;67us;12us;15us;19us;9us;21us;52us;25us;46us;29us;61us;30us;72us;31us;47us;32us;71us;9us;32768us;1us;67us;12us;15us;19us;9us;21us;52us;25us;46us;29us;61us;30us;72us;31us;47us;32us;71us;9us;32768us;1us;67us;12us;15us;19us;9us;21us;52us;25us;46us;29us;61us;30us;72us;31us;47us;32us;71us;1us;16407us;27us;48us;1us;32768us;31us;49us;0us;16405us;0us;16406us;0us;16407us;1us;32768us;31us;53us;2us;32768us;5us;54us;31us;57us;9us;32768us;1us;67us;12us;15us;19us;9us;21us;52us;25us;46us;29us;61us;30us;72us;31us;47us;32us;71us;9us;32768us;1us;67us;12us;15us;19us;9us;21us;52us;25us;46us;29us;61us;30us;72us;31us;47us;32us;71us;0us;16408us;1us;32768us;5us;58us;9us;32768us;1us;67us;12us;15us;19us;9us;21us;52us;25us;46us;29us;61us;30us;72us;31us;47us;32us;71us;9us;32768us;1us;67us;12us;15us;19us;9us;21us;52us;25us;46us;29us;61us;30us;72us;31us;47us;32us;71us;0us;16409us;1us;32768us;31us;62us;1us;32768us;5us;63us;1us;16386us;31us;4us;1us;32768us;20us;65us;9us;32768us;1us;67us;12us;15us;19us;9us;21us;52us;25us;46us;29us;61us;30us;72us;31us;47us;32us;71us;0us;16410us;9us;32768us;1us;67us;12us;15us;19us;9us;21us;52us;25us;46us;29us;61us;30us;72us;31us;47us;32us;71us;0us;16411us;0us;16412us;0us;16413us;0us;16414us;0us;16415us;|]
let _fsyacc_actionTableRowOffsets = [|0us;10us;11us;24us;25us;27us;29us;30us;37us;44us;54us;67us;77us;90us;100us;112us;122us;126us;130us;134us;135us;136us;137us;147us;157us;163us;169us;175us;181us;193us;206us;219us;232us;245us;258us;271us;281us;291us;301us;311us;321us;331us;341us;351us;361us;371us;381us;391us;393us;395us;396us;397us;398us;400us;403us;413us;423us;424us;426us;436us;446us;447us;449us;451us;453us;455us;465us;466us;476us;477us;478us;479us;480us;|]
let _fsyacc_reductionSymbolCounts = [|1us;2us;0us;1us;3us;1us;1us;6us;2us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;2us;3us;1us;1us;7us;8us;7us;3us;2us;2us;1us;1us;|]
let _fsyacc_productionToNonTerminalTable = [|0us;1us;2us;2us;2us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;4us;4us;4us;4us;4us;4us;5us;5us;6us;6us;|]
let _fsyacc_immediateActions = [|65535us;49152us;65535us;16385us;65535us;65535us;16388us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;16405us;16406us;16407us;65535us;65535us;65535us;65535us;16408us;65535us;65535us;65535us;16409us;65535us;65535us;65535us;65535us;65535us;16410us;65535us;16411us;16412us;16413us;16414us;16415us;|]
let _fsyacc_reductions = lazy [|
# 299 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : 'gentype__startMain));
# 308 "FunPar.fs"
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
# 319 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 39 "FunPar.fsy"
                                                               []                     
                   )
# 39 "FunPar.fsy"
                 : 'gentype_ExprLst));
# 329 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 40 "FunPar.fsy"
                                                               [_1]                   
                   )
# 40 "FunPar.fsy"
                 : 'gentype_ExprLst));
# 340 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            let _3 = parseState.GetInput(3) :?> 'gentype_ExprLst in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 41 "FunPar.fsy"
                                                               _1 :: _3         
                   )
# 41 "FunPar.fsy"
                 : 'gentype_ExprLst));
# 352 "FunPar.fs"
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
# 363 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 46 "FunPar.fsy"
                                                               _1                     
                   )
# 46 "FunPar.fsy"
                 : Absyn.expr));
# 374 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            let _4 = parseState.GetInput(4) :?> Absyn.expr in
            let _6 = parseState.GetInput(6) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 47 "FunPar.fsy"
                                                               If(_2, _4, _6)         
                   )
# 47 "FunPar.fsy"
                 : Absyn.expr));
# 387 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 48 "FunPar.fsy"
                                                               Prim("-", CstI 0, _2)  
                   )
# 48 "FunPar.fsy"
                 : Absyn.expr));
# 398 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 49 "FunPar.fsy"
                                                               Prim("+",  _1, _3)     
                   )
# 49 "FunPar.fsy"
                 : Absyn.expr));
# 410 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 50 "FunPar.fsy"
                                                               Prim("-",  _1, _3)     
                   )
# 50 "FunPar.fsy"
                 : Absyn.expr));
# 422 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 51 "FunPar.fsy"
                                                               Prim("*",  _1, _3)     
                   )
# 51 "FunPar.fsy"
                 : Absyn.expr));
# 434 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 52 "FunPar.fsy"
                                                               Prim("/",  _1, _3)     
                   )
# 52 "FunPar.fsy"
                 : Absyn.expr));
# 446 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 53 "FunPar.fsy"
                                                               Prim("%",  _1, _3)     
                   )
# 53 "FunPar.fsy"
                 : Absyn.expr));
# 458 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 54 "FunPar.fsy"
                                                               Prim("=",  _1, _3)     
                   )
# 54 "FunPar.fsy"
                 : Absyn.expr));
# 470 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 55 "FunPar.fsy"
                                                               Prim("<>", _1, _3)     
                   )
# 55 "FunPar.fsy"
                 : Absyn.expr));
# 482 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 56 "FunPar.fsy"
                                                               Prim(">",  _1, _3)     
                   )
# 56 "FunPar.fsy"
                 : Absyn.expr));
# 494 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 57 "FunPar.fsy"
                                                               Prim("<",  _1, _3)     
                   )
# 57 "FunPar.fsy"
                 : Absyn.expr));
# 506 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 58 "FunPar.fsy"
                                                               Prim(">=", _1, _3)     
                   )
# 58 "FunPar.fsy"
                 : Absyn.expr));
# 518 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 59 "FunPar.fsy"
                                                               Prim("<=", _1, _3)     
                   )
# 59 "FunPar.fsy"
                 : Absyn.expr));
# 530 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 60 "FunPar.fsy"
                                                               Print(_2)              
                   )
# 60 "FunPar.fsy"
                 : Absyn.expr));
# 541 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            let _3 = parseState.GetInput(3) :?> string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 61 "FunPar.fsy"
                                                               EnumVal(_1, _3)        
                   )
# 61 "FunPar.fsy"
                 : Absyn.expr));
# 553 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 68 "FunPar.fsy"
                                                               _1                     
                   )
# 68 "FunPar.fsy"
                 : Absyn.expr));
# 564 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 69 "FunPar.fsy"
                                                               Var _1                 
                   )
# 69 "FunPar.fsy"
                 : Absyn.expr));
# 575 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> string in
            let _4 = parseState.GetInput(4) :?> Absyn.expr in
            let _6 = parseState.GetInput(6) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 70 "FunPar.fsy"
                                                               Let(_2, _4, _6)        
                   )
# 70 "FunPar.fsy"
                 : Absyn.expr));
# 588 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> string in
            let _3 = parseState.GetInput(3) :?> string in
            let _5 = parseState.GetInput(5) :?> Absyn.expr in
            let _7 = parseState.GetInput(7) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 71 "FunPar.fsy"
                                                               Letfun(_2, _3, _5, _7) 
                   )
# 71 "FunPar.fsy"
                 : Absyn.expr));
# 602 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> string in
            let _4 = parseState.GetInput(4) :?> 'gentype_ExprLst in
            let _6 = parseState.GetInput(6) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 72 "FunPar.fsy"
                                                               Enum(_2, _4, _6)       
                   )
# 72 "FunPar.fsy"
                 : Absyn.expr));
# 615 "FunPar.fs"
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
# 626 "FunPar.fs"
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
# 638 "FunPar.fs"
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
# 650 "FunPar.fs"
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
# 661 "FunPar.fs"
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
# 673 "FunPar.fs"
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
    numTerminals = 36;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = tables.Interpret(lexer, lexbuf, startState)
let Main lexer lexbuf : Absyn.expr =
    engine lexer lexbuf 0 :?> _