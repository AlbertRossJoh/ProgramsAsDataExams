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
  | Find of string * string
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
    | Find(pat, str) ->
      let rec loop (xs: string) (i: int) = 
        if i >= xs.Length then econt ()
        else 
          let idx = xs.IndexOf(pat, i)
          if idx = -1 then econt ()
          else cont (Int idx) (fun () -> loop xs (idx+1))
      loop str 0
      //eval str (fun v ->
      //  match v with
      //  | Str s -> loop s 0
      //  | _ -> failwith "You can only use find with string values") econt
    | Fail -> econt ();;

let run e = eval e (fun v -> fun _ -> v) (fun () -> (printfn "Failed"; Int 0));;


(* Examples in abstract syntax *)

// (write(1 to 3)) ; fail
let ex1 = Seq(Write (FromTo(1, 3)), Fail);;

// (write(1 to 3)) & fail
let ex2 = And(Write (FromTo(1, 3)), Fail);;

// (write((1 to 3) & (4 to 6))) & fail
let ex3and = And(Write(And(FromTo(1, 3), FromTo(4, 6))), Fail);;

// (write((1 to 3) | (4 to 6))) & fail
let ex3or  = And(Write(Or(FromTo(1, 3), FromTo(4, 6))), Fail);;

// (write((1 to 3) ; (4 to 6))) & fail
let ex3seq = And(Write(Seq(FromTo(1, 3), FromTo(4, 6))), Fail);;

// write((1 to 3) & ((4 to 6) & "found"))
let ex4 = Write(And(FromTo(1, 3), And(FromTo(4, 6), CstS "found")));;

// every(write(1 to 3))
let ex5 = Every (Write (FromTo(1, 3)));;

// (every(write(1 to 3)) & (4 to 6))
let ex6 = And(Every (Write (FromTo(1, 3))), FromTo(4, 6));;

// every(write((1 to 3) + (4 to 6)))
let ex7 = Every(Write(Prim("+", FromTo(1,3), FromTo(4, 6))));;

// write(4 < (1 to 10))
let ex8 = Write(Prim("<", CstI 4, FromTo(1, 10)));;

// every(write(4 < (1 to 10)))
let ex9 = Every(Write(Prim("<", CstI 4, FromTo(1, 10))));;

let iconEx1 = Every(Write(Prim("<", CstI 7, FromTo(1,10))));; (* 1.1 *)

let iconEx2 = 
  Every(                        // For every result
    Write(                      // Write
        Prim(
          "*",                  // Multiply sequence
          FromTo(1,4),          // This is enumerated first
          And(                  // This is emitted after the enumeration above
            Write(CstS "\n"),   // Newline is printed
            FromTo(1,4)         // This is enumerated and returned
          )                     // The result is 1*1 1*2 1*3 1*4\n 2*1 2*2 ...
        )
    )
  );;

let str = "Hi there - if there are anyone";;
let iconEx3 = Every(Write(Find("there", str)));;

let iconEx4 = Every(Write(Find("e", str)));;
let iconEx5 = Every(Write(Prim("<", CstI 10, Find("e", str))));;

