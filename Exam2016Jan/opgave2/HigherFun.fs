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
  | RefVal of value ref

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
    | Ref e -> 
      eval e env |> ref |>  RefVal
    | Deref e -> 
      match eval e env with
      | RefVal v -> v.Value
      | _ -> failwith "You can only dereference reference types"
    | UpdRef(e1, e2) ->
      match eval e1 env with
      | RefVal v -> 
        let other = eval e2 env
        v.Value <- other
        other
      | _ -> failwith "You you tried to update a non reference type"

let run e = eval e []
let exam2_1 = 
  Let("x", Ref(CstI 1),
    If(
      Prim("=", Deref(Var "x"), CstI 1),
      UpdRef(Var "x", CstI 2),
      CstI 42
    )
  )

let exam2_2 = 
  Let("x", Ref(CstI 2),
      Prim("+", UpdRef(Var "x", CstI 3), CstI 3)
  )

let exam2_3 = 
  Let("x", Ref(CstI 2),
    Let("y", Var "x",
      Let("z", UpdRef(Var "y", CstI 42),
          Deref(Var "x")
      )
    )
  )

let examStr2_3 =
  @"
    let x = ref 2 in
      let y = x in
        let z = y := 42 in
          !x
        end
      end
    end
  "

let exam2_4 = 
  Let("x", Ref(CstB true),
    Deref(Var "x")
  )

let examStr2_4 =
  @"
    let x = ref true in
      !x
    end
  "



let exam2_5 = 
  Let("x", Ref(CstI 10),
    Let("y", Ref(CstI 32),
      Letfun("loop", "i",
        If(
          Prim("=", Deref(Var "x"), CstI 0),
          Deref(Var "y"),
          Let("z", 
            UpdRef(Var "y", 
              Prim("+",
                Deref(Var "y"), 
                CstI 1)
            ),
            Call(Var "loop", UpdRef(Var "x", Prim("-",Deref(Var "x"), CstI 1)))
          )
        ),
        Call(Var "loop", Deref(Var "x"))
      )
    )
  )

let examStr2_5 =
  @"
    let x = ref 10 in 
      let y = ref 32 in
        let loop i =  
            if !x = 0 then !y
            else 
              let z = y := !y+1 in
                loop (x:=!x-1)
              end
          in loop (!x)
        end
      end
    end
  "



let exam2_6 = 
  Let("x", Ref(CstI 1),
    Let("y", Ref(CstI 1),
      UpdRef(Var "x", Prim("+", Deref(Var "x"), Deref(Var "y")))
    )
  )

let examStr2_6 =
  @"
    let x = ref 1 in 
      let y = ref 1 in
        x := !x+!y
      end
    end
  "



