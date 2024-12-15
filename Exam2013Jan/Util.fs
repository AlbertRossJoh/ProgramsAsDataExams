
module Util

let parseThirdInt (s: string) =
    match [for c in s do c] with
    | _::_::a::_ when System.Char.IsAsciiDigit(a) -> System.Int32.Parse(a.ToString())
    | _ -> failwith "Not enough elements"
