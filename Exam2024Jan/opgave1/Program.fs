
open Icon
let examEx1 = Write(FromTo(1, 10))

printfn "%A" (examEx1 |> run)
printfn "\n"
let examEx2 = Every(Write(Prim("+", CstI 4, FromTo(1, 10))))
printfn "%A" (examEx2 |> run)
printfn "\n"
let examEx3 = And(Every(Write(FromTo(1,5))), Every(Write(FromTo(6,10))))
printfn "%A" (examEx3 |> run)
printfn "\n"

let examEx4 = Every(Write(FromList([1..5])))
printfn "%A" (examEx4 |> run)
printfn "\n"

let examEx5 = And(Every(Write(FromList([1..5]))), Every(Write(FromList([6..10]))))
printfn "%A" (examEx5 |> run)
printfn "\n"

let examEx6 = Every(Write(FromMergeList([1..5],[6..12])))
printfn "%A" (examEx6 |> run)
printfn "\n"