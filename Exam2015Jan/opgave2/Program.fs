
open HigherFun
open Parse

printfn $"%A{ex1 |> run}"
printfn $"%A{ex2 |> run}"
printfn $"%A{ex3 |> run}"
printfn $"%A{ex4 |> run}"
printfn "\n"
printfn $"%A{exs1 |> fromString |> run}"
printfn $"%A{exs2 |> fromString |> run}"
printfn $"%A{exs3 |> fromString |> run}"
printfn $"%A{exs4 |> fromString |> run}"
