module SimpLex

open (*Microsoft.*) FSharp.Text.Lexing
open Util
open SimpPar/// Rule Token
val Token: lexbuf: LexBuffer<char> -> token
