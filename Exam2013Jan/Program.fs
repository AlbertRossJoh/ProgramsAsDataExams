// For more information see https://aka.ms/fsharp-console-apps
open FSharp.Text.Lexing
open System.IO
open Absyn
open TypeInference



let fromFile (filename : string) =
    use reader = new StreamReader(filename)
    let lexbuf = (*Lexing.*)LexBuffer<char>.FromTextReader reader
    try 
      SimpPar.Main SimpLex.Token lexbuf
    with 
      | exn -> let pos = lexbuf.EndPos 
               failwithf "%s in file %s near line %d, column %d\n" 
                  (exn.Message) filename (pos.Line+1) pos.Column

[<EntryPoint>]
let main a = 
    let prog = (a,0) ||> Array.get |> fromFile
    ([], prog)
    ||> List.fold (fun acc (_, cmd) -> acc@cmd)
    |> List.iter (fun cmd -> if cmdType cmd then () else printfn $"Cmd %A{cmd} is not well typed")
    printfn $"Does program have correct labels: %b{prog |> labelCheck}"
    0