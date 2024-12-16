// For more information see https://aka.ms/fsharp-console-apps
open ParseAndRun

let examEx1 = 
    @"
        let s1 = {2, 3} in
            let s2 = s1++{1, 4} in
                s1 ++ s2 = {2, 4, 3, 1}
            end
        end
    "
let examEx2 = 
    @"
        let s = {} in
            s
        end
    "


printfn $"%A{examEx1}"
printfn "\n"
printfn $"%A{examEx1 |> fromString}"
printfn "\n"
printfn $"%A{examEx1 |> fromString |> run}"
printfn "\n"
printfn $"%A{examEx2 |> fromString}"
