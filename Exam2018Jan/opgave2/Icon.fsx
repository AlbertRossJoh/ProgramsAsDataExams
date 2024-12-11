(* File Cont/Icon.fs 

   Abstract syntax and interpreter for micro-Icon, a language where an 
   expression can produce more than one result.  

   sestoft@itu.dk * 2010-05-18

   ---

   For a description of micro-Icon, see Chapter 11: Continuations, in
   Programming Language Concepts for Software Developers.

   As described there, the interpreter (eval e cont econt) has two
   continuations:

      * a success continuation cont, that is called on the result v of
        the expression e, in case it has one;

      * a failure continuation econt, that is called on () in case the
        expression e has no result.
 *)

module Icon

(* Micro-Icon abstract syntax *)

type expr = 
  | CstI of int
  | CstS of string
  | FromTo of int * int
  | FromToBy of int * int * int
  | Write of expr
  | If of expr * expr * expr
  | Prim of string * expr * expr 
  | And of expr * expr
  | Or  of expr * expr
  | Seq of expr * expr
  | Every of expr 
  | Bang of string
  | BangN of string * int
  | Fail;;

(* Runtime values and runtime continuations *)

type value = 
  | Int of int
  | Str of string;;

type econt = unit -> value;;

type cont = value -> econt -> value;;

(* Print to console *)

let write v =
    match v with 
    | Int i -> printf "%d " i
    | Str s -> printf "%s " s;;

(* Expression evaluation with backtracking *)

let rec eval (e : expr) (cont : cont) (econt : econt) = 
    match e with
    | CstI i -> cont (Int i) econt
    | CstS s  -> cont (Str s) econt
    | FromTo(i1, i2) -> 
      let rec loop i = 
          if i <= i2 then 
              cont (Int i) (fun () -> loop (i+1))
          else 
              econt ()
      loop i1
    | FromToBy(fromi, toi, byi) -> 
      let rec loop i = 
          if i <= toi then 
              cont (Int i) (fun () -> loop (i+byi))
          else 
              econt ()
      loop fromi
    | Write e -> 
      eval e (fun v -> fun econt1 -> (write v; cont v econt1)) econt
    | If(e1, e2, e3) -> 
      eval e1 (fun _ -> fun _ -> eval e2 cont econt)
              (fun () -> eval e3 cont econt)
    | Prim(ope, e1, e2) -> 
      eval e1 (fun v1 -> fun econt1 ->
          eval e2 (fun v2 -> fun econt2 -> 
              match (ope, v1, v2) with
              | ("+", Int i1, Int i2) -> 
                  cont (Int(i1+i2)) econt2 
              | ("*", Int i1, Int i2) -> 
                  cont (Int(i1*i2)) econt2
              | ("<", Int i1, Int i2) -> 
                  if i1<i2 then 
                      cont (Int i2) econt2
                  else
                      econt2 ()
              | _ -> Str "unknown prim2")
              econt1)
          econt
    | And(e1, e2) -> 
      eval e1 (fun _ -> fun econt1 -> eval e2 cont econt1) econt
    | Or(e1, e2) -> 
      eval e1 cont (fun () -> eval e2 cont econt)
    | Seq(e1, e2) -> 
      eval e1 (fun _ -> fun econt1 -> eval e2 cont econt)
              (fun () -> eval e2 cont econt)
    | Every e -> 
      eval e (fun _ -> fun econt1 -> econt1 ())
             (fun () -> cont (Int 0) econt)
    | Fail -> econt ()
    | Bang str -> 
      let rec loop =
        function
        | [] -> econt ()
        | x::xs -> cont (Str x) (fun () -> loop xs)
      str 
      |> Seq.toList 
      |> List.map _.ToString()
      |> loop
    | BangN(str, iters) ->
      
      let strLst = 
        str 
        |> Seq.toList 
        |> List.map _.ToString()
      let rec loop i =
        function
        | _ when i <= 0 -> econt ()
        | [] when i <= 1 -> econt ()
        | [] -> loop (i-1) strLst
        | x::xs -> cont (Str x) (fun () -> loop i xs)
      loop iters strLst

let run e = eval e (fun v -> fun _ -> v) (fun () -> (printfn "Failed"; Int 0));;


let iconEx1 = Every(Write(Or(FromTo(1,2), FromTo(3,4))));;
let iconEx2_1 = Every(Write(Or(FromTo(3,4), FromTo(3,4))));;
let iconEx2_2 = Every(Write(Or(CstS "I", Or(CstS "c", Or(CstS "o", CstS "n")))));;
let iconEx2_3 = Every(Write(Bang("Icon")));;
let iconEx2_4 = Every(Write(BangN("Icon", 1)));;
