// For more information see https://aka.ms/fsharp-console-apps

open Icon
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
