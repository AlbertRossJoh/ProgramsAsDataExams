

module Absyn

type direction =
    | Pay
    | Receive

type timeunit = 
    | PerMonth 
    | PerYear

type payment =
    | Stream of string * direction * int * timeunit
    | Lumpsum of string * direction * int

type state =  string

type transition = string * (state * state)

type pension = state list * transition list * payment list
