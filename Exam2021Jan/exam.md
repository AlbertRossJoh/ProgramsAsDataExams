# Opgave 1

## Opgave 1.1

### Block

Block er en kodeblock der holder scope af variable og assignments. Altså vil
lokale variable oprettet inde i blokken ikke være gyldige uden for blokken.

### Dec

Oprettelse af ny variabel, dvs `int i;`.

### Stmt

Statments indeholder alle high level statements som vi har. Altså while, if,
return.

### Expr

Expressions er den funktionelle del af koden, den der gør at vi kan lægge tal
sammen eller kalde funktioner.

### Assign

Assign gør at vi kan gemme resultater i variable.

### Access

Access gør at vi kan have variable, altså sørger for at håndtere stak offsets,
og det at hente og gemme værdier i "variable".

### AccVar

AccVar er den specifikke del af access der sørger for at hente en variabels
værdi og sætte den på stakken til brug.

## Opgave 1.2

`int i;`

```fsharp
Dec(TypI, "x")
```

`x=1;`

```fsharp
Assign(AccVar "x", CstI 1)
```

`(x < y ? x : y) = 4`

```fsharp
Assign(
    CondExpAccess(
        Prim2 ("<",
            Access (AccVar "x"),
            Access (AccVar "y")
        ),
        AccVar "x",
        AccVar "y"
    ),
    CstI 4
)
```

## Opgave 1.3

### Lexer

Der er blevet tilføjet to nye tokens til lexeren så vi kan understøtte `?` og
`:`.

```fsharp
rule Token = parse
  ...
  | "?"             { COND }
  | ':'             { COLON }
  ...
  | eof             { EOF }
  | _               { failwith "Lexer error: illegal symbol" }
```

### Parser

I parseren er der tilføjet de nye tokens som vi parser i lexeren, vi skal også
sørge for at `?` operatoren har præcedens da det er den der skal evaluerer et
expression. Til sidst er der blevet tilføjet endnu et case til `Access`.

```fsharp
%token COND COLON

%right ASSIGN             /* lowest precedence */
%nonassoc PRINT
%left COND
%left SEQOR
%left SEQAND
%left EQ NE 
%left GT LT GE LE
%left PLUS MINUS
%left TIMES DIV MOD 
%nonassoc NOT AMP 
%nonassoc LBRACK          /* highest precedence  */

Access:
    NAME                                { AccVar $1           }
  ...
  | Expr COND Access COLON Access       { CondExpAccess($1, $3, $5) }
;
```

## Opgave 1.4

```
A[e1 ? ae1 : ae2 ] = 
            [e1]
            IFZERO lab1
            A[ae1]
            GOTO lab2
    lab1:   A[ae2]
    lab2:   ...
```

## Opgave 1.5

Casen er blevet implementeret ud fra mit oversætterskema.

```fsharp
and cAccess access varEnv funEnv : instr list =
    match access with 
    ...
    | CondExpAccess(e, a1, a2) -> 
      let labend  = newLabel()
      let labfalse = newLabel()
      cExpr e varEnv funEnv
      @ [IFZERO labfalse]
      @ cAccess a1 varEnv funEnv
      @ [
          GOTO labend; 
          Label labfalse
        ]
      @ cAccess a2 varEnv funEnv
      @ [Label labend]
```

De resulterende bytekode instruktioner er givet ved.

```
[
    LDARGS; 
    CALL (0, "L1"); 
    STOP; 
    Label "L1"; 
        INCSP 1;    [0 0 0]
        GETBP;      [0 0 0 2]
        CSTI 0;     [0 0 0 2 0]
        ADD;        [0 0 0 2]
        CSTI 1;     [0 0 0 2 1]
        STI;        [0 0 1 2]
        INCSP -1;   [0 0 1]
        INCSP 1;    [0 0 1 2]
        GETBP;      [0 0 1 2]
        CSTI 1; 
        ADD; 
        CSTI 2; 
        STI; 
        INCSP -1; 
        GETBP;
        CSTI 0; 
        ADD; 
        LDI; 
        GETBP; 
        CSTI 1; 
        ADD; 
        LDI; 
        LT; 
        IFZERO "L3"; 
        GETBP; 
        CSTI 0; 
        ADD;
        GOTO "L2"; 
    Label "L3"; 
        GETBP; 
        CSTI 1; 
        ADD; 
    Label "L2"; 
        CSTI 3; 
        STI; 
        INCSP -1;
        GETBP; 
        CSTI 0; 
        ADD; 
        LDI; 
        GETBP; 
        CSTI 1; 
        ADD; 
        LDI; 
        LT; 
        IFZERO "L5"; 
        GETBP;
        CSTI 0; 
        ADD; 
        GOTO "L4"; 
    Label "L5"; 
        GETBP; 
        CSTI 1; 
        ADD; 
    Label "L4"; 
        CSTI 4; 
        STI;
        INCSP -1; 
        GETBP; 
        CSTI 0; 
        ADD; 
        LDI; 
        PRINTI; 
        INCSP -1; 
        CSTI 10; 
        PRINTC; 
        INCSP -1;
        GETBP; 
        CSTI 1; 
        ADD; 
        LDI; 
        PRINTI; 
        INCSP -1; 
        CSTI 10; 
        PRINTC; 
        INCSP -1; 
        INCSP -2;
        RET -1
]
```

Resultatet af at køre programmet er følgende.

```
java Machine exam.out
3 
4 

Ran 0.007 seconds
```

Dette er det forventede resultat da `x` starter med at være mindre en `y`
hvorefter det bliver assignet til 3, nu hvor `y` er mindre en `x` bliver `y`
assignet til 4. Herefter bliver de printet ud hvilket resulterer i 3 og
herefter 4.

## Opgave 1.6

```c
void main(){
    int x; x = 10;
    int y; y = 20;
    t(&x, &y);
    print x; println;
    print y; println;
}

void t(int *a, int *b){
    (*a < *b ? *a : *b) = 30;
    (*a < *b ? *a : *b) = 40;
}
```

```c
void main(){
    int x[1]; x[0] = 10;
    int y[1]; y[0] = 20;
    (x[0] < y[0] ? x[0] : y[0]) = 30;
    (x[0] < y[0] ? x[0] : y[0]) = 40;
    print x[0]; println;
    print y[0]; println;
}
```

# Opgave 2

## Opgave 2.1

### CLex

```fsharp
let keyword s =
    match s with
    ...
    | "alias"   -> ALIAS
    | "as"   -> AS
    | _         -> NAME s
```

### CPar

```fsharp
%token ALIAS AS

StmtOrDecSeq:
    /* empty */                         { [] }
  | Stmt StmtOrDecSeq                   { Stmt $1 :: $2 }
  | Vardec SEMI StmtOrDecSeq            { Dec (fst $1, snd $1) :: $3 }
  | ALIAS NAME AS NAME SEMI StmtOrDecSeq{ Alias($2, $4) :: $6}
;
```

### Absyn

```fsharp
and stmtordec =                                                    
  ...
  | Alias of string * string
```

## Opgave 2.2

Forstår ikke

## Opgave 2.3

Vi behøver kun at lave et alias compile time da vi blot behandler det som den
samme variabel. Dette vil sige at vi henter addressen samt typen for den
variabel som vi referer til, hvor vi blot sætter vores alias til den værdi og
sætter den på varEnv stakken.

```fsharp
and cStmtOrDec stmtOrDec (varEnv : varEnv) (funEnv : funEnv) : varEnv * instr list = 
    match stmtOrDec with 
    ...
    | Alias(alias, actual) -> 
      let actual' = lookup (fst varEnv) actual
      (((alias, actual')::(fst varEnv), snd varEnv), [])
```

```
[LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; ADD; CSTI 0;
 STI; INCSP -1; GOTO "L3"; Label "L2"; GETBP; CSTI 1; ADD; LDI; PRINTI; INCSP -1;
 GETBP; CSTI 1; ADD; GETBP; CSTI 1; ADD; LDI; CSTI 1; ADD; STI; INCSP -1;
 INCSP 0; Label "L3"; GETBP; CSTI 1; ADD; LDI; GETBP; CSTI 0; ADD; LDI; LT;
 IFNZRO "L2"; INCSP -1; RET 0]
```

```
java Machine exam01.out 10
0 1 2 3 4 5 6 7 8 9 
Ran 0.009 seconds
```

## Opgave 2.4

```c
int i;
void main(int n){
    i = 0;
    alias j as i;
    while (j < n){
        print j;
        i = i+1;
    }
}
```

```
[INCSP 1; LDARGS; CALL (1, "L1"); STOP; Label "L1"; CSTI 0; CSTI 0; STI;
 INCSP -1; GOTO "L3"; Label "L2"; CSTI 0; LDI; PRINTI; INCSP -1; CSTI 0; CSTI 0;
 LDI; CSTI 1; ADD; STI; INCSP -1; INCSP 0; Label "L3"; CSTI 0; LDI; GETBP;
 CSTI 0; ADD; LDI; LT; IFNZRO "L2"; INCSP 0; RET 0]
```

```
java Machine exam05.out 10
0 1 2 3 4 5 6 7 8 9 
Ran 0.008 seconds
```
