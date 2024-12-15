
open Icon

let iconEx1 = Every(Write(FromTo(1,6)))
printf $"%A{iconEx1 |> run}"
printf "\n"
let iconEx2 = 
    Every(
        Write(
            Prim("+", 
                Prim("*", 
                    CstI 10, 
                    FromTo(3,6)
                ),
                FromTo(3,4)
            )
        )
    )
printf $"%A{iconEx2 |> run}"
printf "\n"
let iconEx3 = 
    Every(
        Write(
            FromToBy(1, 10, 3)
        )
    )
printf $"%A{iconEx3 |> run}"
printf "\n"
let iconEx4 = 
    Every(
        Write(
            Prim("+", 
                FromToBy(30, 60, 10),
                FromTo(3,4)
            )
        )
    )
printf $"%A{iconEx4 |> run}"
printf "\n"
let iconEx5 = 
    Every(
        Write(
            FromToBy(10, 11, 0)
        )
    )
//printf $"%A{iconEx5 |> run}"
printf "\n"




