// For more information see https://aka.ms/fsharp-console-apps

open Icon
let examEx41 = 
    Every(
        Write(
                FromTo(1, 10)
        )
    )

printfn $"%A{examEx41 |> run}"
printfn "\n"
let examEx42 = 
    Every(
        Write(
            Prim("*",
                FromTo(1, 10),
                FromTo(1, 10)
            )
        )
    )

printfn $"%A{examEx42 |> run}"
printfn "\n"
let examEx43 = 
    Every(
        Write(
            Prim("*",
                FromTo(1, 10),
                And(
                    Write(CstS "\n"), 
                    FromTo(1, 10)
                )
            )
        )
    )

printfn $"%A{examEx43 |> run}"
printfn "\n"
let examEx44 = 
    Every(
        Write(
            Random(1, 10, 3)
        )
    )

printfn $"%A{examEx44 |> run}"
printfn "\n"



