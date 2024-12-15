

module Absyn

type expr =
  | Ia of int
  | Id of int
  | Cd of int
  | False
  | True
  | CstI of int
  | Prim1 of string * expr
  | Prim2 of string * expr * expr

type output =
  | Oa of int
  | Od of int

type lab = string

type cmd =
  | Set of output * expr
  | Goto of lab
  | If of expr * lab
  | Sleep of int

type program = (lab * cmd list) list

type typ = BOOL | BYTE | WORD

