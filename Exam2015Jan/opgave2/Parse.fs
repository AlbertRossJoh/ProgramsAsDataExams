(* Lexing and parsing of micro-ML programs using fslex and fsyacc *)

module Parse

open System
open System.IO
open System.Text
open (*Microsoft.*)FSharp.Text.Lexing
open Absyn

(* Plain parsing from a string, with poor error reporting *)

let fromString (str : string) : expr =
    let lexbuf = (*Lexing. insert if using old PowerPack *)LexBuffer<char>.FromString(str)
    try 
      FunPar.Main FunLex.Token lexbuf
    with 
      | exn -> let pos = lexbuf.EndPos 
               failwithf "%s near line %d, column %d\n" 
                  (exn.Message) (pos.Line+1) pos.Column
             
(* Parsing from a file *)

let fromFile (filename : string) =
    use reader = new StreamReader(filename)
    let lexbuf = (* Lexing. insert if using old PowerPack *) LexBuffer<char>.FromTextReader reader
    try 
      FunPar.Main FunLex.Token lexbuf
    with 
      | exn -> let pos = lexbuf.EndPos 
               failwithf "%s in file %s near line %d, column %d\n" 
                  (exn.Message) filename (pos.Line+1) pos.Column

