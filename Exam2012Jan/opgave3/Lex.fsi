
module Lex
open (*Microsoft.*) FSharp.Text.Lexing
open Util
open Par/// Rule Token
val Token: lexbuf: LexBuffer<char> -> token
