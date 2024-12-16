open FSharp.Text.Lexing
// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"
let fromFile (filename : string) =
    use reader = new System.IO.StreamReader(filename)
    let lexbuf = (*Lexing.*)LexBuffer<char>.FromTextReader reader
    try 
      Par.Main Lex.Token lexbuf
    with 
      | exn -> let pos = lexbuf.EndPos 
               failwithf "%s in file %s near line %d, column %d\n" 
                  (exn.Message) filename (pos.Line+1) pos.Column

[<EntryPoint>]
let main a = 
    let prog = (a,0) ||> Array.get |> fromFile
    printfn $"%A{prog}"
    0