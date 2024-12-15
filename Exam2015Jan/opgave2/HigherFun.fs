(* A functional language with integers and higher-order functions 
   sestoft@itu.dk 2009-09-11

   The language is higher-order because the value of an expression may
   be a function (and therefore a function can be passed as argument
   to another function).

   A function definition can have only one parameter, but a
   multiparameter (curried) function can be defined using nested
   function definitions:

      let f x = let g y = x + y in g end in f 6 7 end
 *)

module HigherFun

open Absyn

(* Environment operations *)

type 'v env = (string * 'v) list

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

(* A runtime value is an integer or a function closure *)

type value = 
  | Int of int
  | Closure of string * string * expr * value env       (* (f, x, fBody, fDeclEnv) *)
  | PairV of value * value

let rec eval (e : expr) (env : value env) : value =
    match e with
    | CstI i -> Int i
    | CstB b -> Int (if b then 1 else 0)
    | Var x  -> lookup env x
    | Prim(ope, e1, e2) -> 
      let v1 = eval e1 env
      let v2 = eval e2 env
      match (ope, v1, v2) with
      | ("*", Int i1, Int i2) -> Int (i1 * i2)
      | ("+", Int i1, Int i2) -> Int (i1 + i2)
      | ("-", Int i1, Int i2) -> Int (i1 - i2)
      | ("=", Int i1, Int i2) -> Int (if i1 = i2 then 1 else 0)
      | ("<", Int i1, Int i2) -> Int (if i1 < i2 then 1 else 0)
      |  _ -> failwith "unknown primitive or wrong type"
    | Let(x, eRhs, letBody) -> 
      let xVal = eval eRhs env
      let letEnv = (x, xVal) :: env 
      eval letBody letEnv
    | If(e1, e2, e3) -> 
      match eval e1 env with
      | Int 0 -> eval e3 env
      | Int _ -> eval e2 env
      | _     -> failwith "eval If"
    | Letfun(f, x, fBody, letBody) -> 
      let bodyEnv = (f, Closure(f, x, fBody, env)) :: env
      eval letBody bodyEnv
    | Call(eFun, eArg) -> 
      let fClosure = eval eFun env  (* Different from Fun.fs - to enable first class functions *)
      match fClosure with
      | Closure (f, x, fBody, fDeclEnv) ->
        let xVal = eval eArg env
        let fBodyEnv = (x, xVal) :: (f, fClosure) :: fDeclEnv
        in eval fBody fBodyEnv
      | _ -> failwith "eval Call: not a function"
    | Pair(e1, e2) -> PairV(eval e1 env, eval e2 env)
    | Fst(e) -> 
      match eval e env with
      | PairV(v1, _) -> v1
      | _ -> failwith "Fst only works on pairs!!"
    | Snd(e) ->
      match eval e env with
      | PairV(_, v2) -> v2
      | _ -> failwith "Snd only works on pairs!!";;

(* Evaluate in empty environment: program must have no free variables: *)

let run e = eval e [];;

let ex1 = Let("x" , CstI 1, Fst(Pair(CstI 1, CstB true)))
let exs1 = 
  @"
    let x = 1 in
      fst (1, true)
    end
  "
let ex2 = Let("x" , Pair(CstB false, CstI 2), Snd(Var "x"))
let exs2 = 
  @"
    let x = (false, 2) in
      snd x
    end
  "
let ex3 = Let("x" , Pair(CstI 1, Pair(CstI 2, Pair(CstI 3, CstI 4))), Fst(Snd(Var "x")))
let exs3 = 
  @"
    let x = (1, (2, (3, 4))) in
      fst snd x
    end
  "
let ex4 = 
    Letfun("loop", "i",
      If(
        Prim("<", Var "i", CstI 10),
        Pair(Var "i", Call(Var "loop", Prim("+", Var "i", CstI 1))),
        Var "i"
      ),
      Call(Var "loop", CstI 0)
    )

let exs4 = 
  @"
    let loop i =
      if i < 10 then (i, loop(i+1))
      else i in
      loop(0)
    end
  "
