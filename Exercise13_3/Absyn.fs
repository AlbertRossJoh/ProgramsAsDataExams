(* Fun/Absyn.fs * Abstract syntax for micro-SML, a functional language *)

module Absyn

type expr<'a> = 
  | CstI of int * 'a option
  | CstB of bool * 'a option
  | CstN of 'a option
  | Var of string * 'a option
  | AndAlso of expr<'a> * expr<'a> * 'a option
  | OrElse of expr<'a> * expr<'a> * 'a option
  | Seq of expr<'a> * expr<'a> * 'a option
  | Prim2 of string * expr<'a> * expr<'a> * 'a option
  | Prim1 of string * expr<'a> * 'a option
  | If of expr<'a> * expr<'a> * expr<'a>
  | Fun of string * expr<'a> * 'a option 
  | Call of expr<'a> * expr<'a> * bool option * 'a option
  | Let of valdec<'a> list * expr<'a>
  | Raise of expr<'a> * 'a option
  | TryWith of expr<'a> * exnvar * expr<'a>
  | Pair of expr<'a> * expr<'a> * 'a option
and valdec<'a> =
  | Fundecs of (string * string * expr<'a>) list  (* Top level mutual recursive function declarations *)
  | Valdec of string * expr<'a>
  | Exn of exnvar * 'a option
and exnvar =
  | ExnVar of string    
and program<'a> =
  | Prog of valdec<'a> list * expr<'a> (* A program is a list of top level declarations and an expression *)

let exprToProg e = Prog([],e)
let progToExpr = function
  Prog(_,e) -> e
let progToTopdec = function
  Prog(t,_) -> t

let ppProg fPP p : string =
  let ppTail = function
    None -> " "
  | Some true -> "_tail "
  | Some false -> " "
  let indent i = String.replicate i " "
  let rec ppExpr' i e =
    match e with
    | CstI (i,aOpt) -> sprintf "%d" i + (fPP aOpt)
    | CstB (b,aOpt) -> sprintf "%b" b + (fPP aOpt)
    | CstN aOpt     -> sprintf "nil" + (fPP aOpt)
    | Var (x,aOpt)  -> sprintf "%s" x + (fPP aOpt)
    | AndAlso(e1,e2,aOpt) -> "(" + (ppExpr' i e1) + " && " + (ppExpr' i e2) + ")" + (fPP aOpt)
    | OrElse (e1,e2,aOpt) -> "(" + (ppExpr' i e1) + " || " + (ppExpr' i e2) + ")" + (fPP aOpt)
    | Seq(e1,e2,aOpt) -> "(" + (ppExpr' i e1) + " ; " + (ppExpr' i e2) + ")" + (fPP aOpt)
    | Let(valdecs,letBody) ->
      "\n" + (indent (i+2)) + "let\n" + (ppValdecs (i+4) valdecs) + "\n" + (indent (i+2)) + "in\n" +
        (indent (i+4)) + (ppExpr' (i+2) letBody) + "\n" + (indent (i+2)) + "end"
    | Prim2(ope,e1,e2,aOpt) -> "(" + (ppExpr' i e1) + " " + ope + " " + (ppExpr' i e2) + ")" +
                               (fPP aOpt)
    | Prim1(ope,e,aOpt) -> ope + "(" + (ppExpr' i e) + ")" + (fPP aOpt)
    | If(e1,e2,e3) -> "if " + (ppExpr' i e1) + " then " + (ppExpr' i e2) + " else " + (ppExpr' i e3)
    | Fun(x,e,aOpt) -> "fn " + x + " -> " + (ppExpr' i e) + (fPP aOpt)
    | Call(e1,e2,tOpt,aOpt) -> (ppExpr' i e1) + (ppTail tOpt) + (ppExpr' i e2) + (fPP aOpt)
    | Raise(e,aOpt) -> "raise " + (ppExpr' i e) + (fPP aOpt)
    | TryWith(e1,exn,e2) -> "\n" + (indent (i+2)) + "(try " + (ppExpr' (i+4) e1) +
                            "\n" + (indent (i+2)) + "with " + (ppExnVar exn) + " -> " + (ppExpr' (i+4) e2) + ")"
  and ppExnVar = function
    | ExnVar exn -> exn      
  and ppValDec' i = function
    | Fundecs fs -> ppFundec i fs
    | Valdec(x,eRhs) -> ppValdec i (x,eRhs)
    | Exn(ExnVar x,aOpt) -> (indent i) + "exception " + x + (fPP aOpt)
  and ppProg' i = function
    | Prog(valdecs,e) ->
      ppValdecs i valdecs + "\n" + (indent i) + "begin\n" +
        (indent 2) + (ppExpr' (i+2) e) + "\n" + (indent i) + "end"
  and ppValdecs i valdecs = String.concat "\n" (List.map (ppValDec' i) valdecs)
  and ppFundec i fs = 
    let fsPP = List.map (fun (f,x,body) -> f + " " + x + " = " + (ppExpr' i body)) fs
    (indent i) + "fun " + (String.concat ("\n" + (indent i) + "and ") fsPP) 
  and ppValdec i (x,eRhs) =
    (indent i) + "val " + x + " = " + (ppExpr' i eRhs)
  ppProg' 0 p

let ppExpr fPP e : string = ppProg fPP (Prog([],e))

let rec getOptExpr e : 'a Option =
  match e with
  | CstI (i,aOpt) -> aOpt
  | CstB (b,aOpt) -> aOpt
  | CstN aOpt -> aOpt
  | Var (x,aOpt)  -> aOpt
  | AndAlso(_,_,aOpt) -> aOpt
  | OrElse(_,_,aOpt) -> aOpt
  | Seq(_,_,aOpt) -> aOpt
  | Prim2(ope,e1,e2,aOpt) -> aOpt
  | Prim1(ope,e,aOpt) -> aOpt
  | If(e1,e2,e3) -> getOptExpr e3       (* e2 and e3 has same type *)
  | Fun(x,e,aOpt) -> aOpt
  | Call(e1,e2,t,aOpt) -> aOpt
  | Raise(e,aOpt) -> aOpt
  | TryWith(e1,exn,e2) -> getOptExpr e1 (* e1 and e3 has same type *)
  | Let(_,letBody) -> getOptExpr letBody
  | Pair(_, _, aOpt) -> aOpt

let tailcalls p : program<'a> =
  let rec tc' tPos e =
    match e with
    | CstI _ -> e
    | CstB _ -> e
    | CstN _ -> e
    | Var _ -> e
    | AndAlso(e1,e2,aOpt) -> AndAlso(tc' false e1,tc' tPos e2,aOpt)
    | OrElse(e1,e2,aOpt) -> OrElse(tc' false e1,tc' tPos e2,aOpt)
    | Seq(e1,e2,aOpt) -> Seq(tc' false e1,tc' tPos e2,aOpt)
    | Prim2(ope,e1,e2,aOpt) -> Prim2(ope,tc' false e1,tc' false e2,aOpt)
    | Prim1(ope,e,aOpt) -> Prim1(ope,tc' false e,aOpt)
    | If(e1,e2,e3) -> If(tc' false e1,tc' tPos e2,tc' tPos e3)
    | Fun(x,e,aOpt) -> Fun(x,tc' true e,aOpt)
    | Call(e1,e2,_,aOpt) -> Call(tc' false e1,tc' false e2,Some tPos,aOpt)
    | Let(valdecs,letBody) -> Let(List.map (tcValdec' false) valdecs,tc' tPos letBody)
    | Raise(e1,aOpt) -> e
      (* an exception handler must be popped after e1 *)    
    | TryWith(e1,exn,e2) -> TryWith(tc' false e1, exn, tc' tPos e2)
    | Pair(a, b, opt) -> Pair(tc' tPos a, tc' tPos b, opt)
  and tcValdec' tPos = function
    | Valdec(x,eRhs) -> Valdec(x,tc' tPos eRhs)
    | Fundecs(fs) -> Fundecs(List.map (fun (f,x,e) -> (f,x,tc' true e)) fs)
    | Exn(x,aOpt) -> Exn(x,aOpt)
  and tcProg' = function
    | Prog (valdecs,body) -> Prog(List.map (tcValdec' false) valdecs,tc' true body)
  tcProg' p

let ppFreevars fvs =
  "\nFreevars = [ " + (String.concat "," fvs) + " ]\n"
    
let rec freevars e : string Set =
  match e with 
  | CstI (i,_) -> Set.empty
  | CstB (b,_) -> Set.empty
  | CstN _     -> Set.empty
  | Var (x,_)  -> set [x]
  | Prim1(ope,e1,_) -> freevars e1
  | Prim2(ope,e1,e2,_) -> (freevars e1) + (freevars e2)
  | AndAlso(e1,e2,_) -> (freevars e1) + (freevars e2)
  | OrElse(e1,e2,_) -> (freevars e1) + (freevars e2)
  | Seq(e1,e2,_) -> (freevars e1) + (freevars e2)
  | Let(valdecs,letBody) ->
    (* Below (... +fvs - bvs) assumes alpha conversion. See ex11.sml for an example where
       it fails. Alpha conversion is covered as an exercise. *)  
    let (fvs,bvs) = List.fold freevarsValdec (Set.empty, Set.empty) valdecs
    (freevars letBody) + fvs - bvs 
  | If(e1, e2, e3) -> (freevars e1) + (freevars e2) + (freevars e3)
  | Fun(x,fBody,_) -> freevars fBody - (set [x])
  | Call(eFun, eArg,_,_) -> freevars eFun + (freevars eArg)
  | Raise(e1,_) -> freevars e1
  | TryWith(e1,ExnVar exn,e2) -> (freevars e1) + (set [exn]) + (freevars e2)
  | Pair(_, _, _) -> failwith "Not Implemented" (* exn is also free *)
and freevarsValdec (fvs, bvs) = function (* bvs are bound variables, either globally or in locally. *)
    Valdec(x,eRhs) -> (fvs + ((freevars eRhs) - set [x]),bvs + set [x]) 
  | Exn (ExnVar exn,aOpt) -> (fvs,bvs + set [exn])
  | Fundecs(fs) -> 
    let fEnv = Set.ofList (List.map (fun (f,_,_) -> f) fs) (* fBody may recursively call f *)
    let funFree = List.foldBack (fun (_,x,fBody) acc -> (acc + (freevars fBody - fEnv - set [x]))) fs fvs 
    (funFree, bvs + fEnv)

(* Alpha conversion is implemented as an exercise.
   Example ex11.sml does not work without alpha conversion. *)
let alphaConv p : program<'a> = 
  let varNo = ref 0
  let freshVar (x: string) = (varNo.Value <- varNo.Value+1; x + varNo.Value.ToString())

  let lookup (v: string) env : string option =
      List.tryFind (fun (x, _ ) -> x = v) env 
      |> Option.map snd
  let genNewEnv env x =
    let newVar = freshVar x
    (newVar, (x, newVar)::env)
  
  let rec aExpr env e =
      match e with
      | Var (x, opt) -> 
        lookup x env 
        |> Option.map (fun v -> Var(v, opt))
        |> Option.defaultValue (Var(x, opt)) 
      | Fun(f, body, opt) ->
        let f' = lookup f env
        if f'.IsSome then
          let newVar, newEnv = genNewEnv env f'.Value
          Fun(newVar, aExpr newEnv body, opt)
        else 
          Fun(f, aExpr env body, opt)
      | Let(valdecs, body) ->
        let newDecs, env = 
          (([], env), valdecs) 
          ||> List.fold (fun (decs, env) dec -> 
            let newDec, newEnv = aValdec' env dec
            [newDec]@decs, newEnv)
        Let(newDecs, aExpr env body)
      | CstI(_, _) | CstB(_, _) | CstN(_) -> e
      | AndAlso(e1, e2, opt) -> AndAlso(aExpr env e1, aExpr env e2, opt)
      | OrElse(e1, e2, opt) -> OrElse(aExpr env e1, aExpr env e2, opt)
      | Seq(e1, e2, opt) -> Seq(aExpr env e1, aExpr env e2, opt)
      | Prim2(op, e1, e2, opt) -> Prim2(op, aExpr env e1, aExpr env e2, opt)
      | Prim1(op, e1, opt) -> Prim1(op, aExpr env e1, opt)
      | If(e1, e2, e3) -> If(aExpr env e1, aExpr env e2,aExpr env e3)
      | Call(e1, e2, opt1, opt2) -> Call(aExpr env e1, aExpr env e2, opt1, opt2)
      | Raise(e1, opt) -> Raise(aExpr env e1, opt)
      | TryWith(e1, exn, e2) -> TryWith(aExpr env e1, exn, aExpr env e2)
      | Pair(a, b, opt) -> Pair(aExpr env a, aExpr env b, opt)
  and aValdec' env = function
    | Valdec(x, eRhs)-> 
      let newVar, newEnv = genNewEnv env x
      Valdec(newVar, aExpr newEnv eRhs), newEnv
    | Fundecs(decs) ->
      let decs, env = 
        (([], env), decs)
        ||> List.fold (
            fun (acc, env) (f, x, eRhs) ->
                let f', newEnv = genNewEnv env f
                let x', newEnv = genNewEnv newEnv x
                [(f', x', aExpr newEnv eRhs)]@acc, newEnv
        )
      Fundecs(decs), env
    | a -> a,env
  and aProg' = function
    | Prog(valdecs, body) -> 
      let newDecs, env = 
        (([], []), valdecs) 
        ||> List.fold (fun (decs, env) dec -> 
          let newDec, newEnv = aValdec' env dec
          [newDec]@decs, newEnv)
      Prog(newDecs, aExpr env body)

  aProg' p
