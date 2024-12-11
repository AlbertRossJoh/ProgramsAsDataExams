
#load "../opgave4/Machine.fs"
open Machine

let withPrint =
    [
        LDARGS; 
        CALL (0, "main");       // [ 4 -999 ] sp = 1 bp = 2
        STOP; 
        Label "printArray"; 
            INCSP 1; 
            GETBP; 
            CSTI 1; 
            ADD;
            CSTI 0; 
            STI; 
            INCSP -1; 
            GOTO "L2"; 
            Label "L1"; 
            GETBP; 
            LDI; 
            GETBP; 
            CSTI 1; 
            ADD;
            LDI; 
            ADD; 
            LDI; 
            PRINTI; 
            INCSP -1; 
            GETBP; 
            CSTI 1; 
            ADD; 
            GETBP; 
            CSTI 1; 
            ADD; 
            LDI;
            CSTI 1; 
            ADD; 
            STI; 
            INCSP -1; 
            Label "L2"; 
            GETBP; 
            CSTI 1; 
            ADD; 
            LDI; 
            CSTI 5; 
            LT;
            IFNZRO "L1"; 
            RET 1; 
        Label "main"; 
            INCSP 5;        // sp = 6
            GETSP;          // [4 -999 0 0 0 0 0 6]
            CSTI 4;         // [4 -999 0 0 0 0 0 6 4]
            SUB;            // [4 -999 0 0 0 0 0 2]
            INCSP 1;        // sp = 7 [4 -999 0 0 0 0 0 2 4]
            GETBP;          // [4 -999 0 0 0 0 0 2 4 2]
            CSTI 6;         // [4 -999 0 0 0 0 0 2 4 2 6]
            ADD;            // [4 -999 0 0 0 0 0 2 4 8]
            CSTI 0;         // [4 -999 0 0 0 0 0 2 4 8 0]
            STI;            // [4 -999 0 0 0 0 0 2 0 0]
            INCSP -1;       // sp = 6 [4 -999 0 0 0 0 0 2 0]
            GOTO "L4"; 
            Label "L3"; 
            GETBP; 
            CSTI 5; 
            ADD;
            LDI; 
            GETBP; 
            CSTI 6; 
            ADD; 
            LDI; 
            ADD; 
            CSTI 42; 
            STI; 
            INCSP -1; 
            GETBP; 
            CSTI 6; 
            ADD;
            GETBP; 
            CSTI 6; 
            ADD; 
            LDI; 
            CSTI 1; 
            ADD; 
            STI; 
            INCSP -1; 
            Label "L4"; 
            GETBP; 
            CSTI 6;
            ADD; 
            LDI; 
            CSTI 5; 
            LT; 
            IFNZRO "L3"; 
            GETBP; 
            CSTI 5; 
            ADD; 
            LDI;
            CALL (1, "printArray"); 
            INCSP -1; 
            CSTI 43; 
            PRINTI; 
            RET 7];;

let withoutPrint = [
    LDARGS; 
    CALL (0, "main"); 
    STOP; 
    Label "printArray"; 
        INCSP 1; 
        GETBP; 
        CSTI 1; 
        ADD;
        CSTI 0; 
        STI; 
        INCSP -1; 
        GOTO "L2"; 
        Label "L1"; 
        GETBP; 
        LDI; 
        GETBP; 
        CSTI 1; 
        ADD;
        LDI; 
        ADD; 
        LDI; 
        PRINTI; 
        INCSP -1; 
        GETBP; 
        CSTI 1; 
        ADD; 
        GETBP; 
        CSTI 1; 
        ADD; 
        LDI;
        CSTI 1; 
        ADD; 
        STI; 
        INCSP -1; 
        Label "L2"; 
        GETBP; 
        CSTI 1; 
        ADD; 
        LDI; 
        CSTI 5; 
        LT;
        IFNZRO "L1"; 
        RET 1; 
    Label "main"; 
        INCSP 5; 
        GETSP; 
        CSTI 4; 
        SUB; 
        INCSP 1; 
        GETBP;
        CSTI 6; 
        ADD; 
        CSTI 0; 
        STI; 
        INCSP -1; 
        GOTO "L4"; 
        Label "L3"; 
        GETBP; 
        CSTI 5; 
        ADD;
        LDI; 
        GETBP; 
        CSTI 6; 
        ADD; 
        LDI; 
        ADD; 
        CSTI 42; 
        STI; 
        INCSP -1; 
        GETBP; 
        CSTI 6; 
        ADD;
        GETBP; 
        CSTI 6; 
        ADD; LDI; 
        CSTI 1; 
        ADD; 
        STI; 
        INCSP -1; 
        Label "L4"; 
        GETBP; 
        CSTI 6;
        ADD; 
        LDI; 
        CSTI 5; 
        LT; 
        IFNZRO "L3"; 
        GETBP; 
        CSTI 5; 
        ADD; 
        LDI;
        TCALL (1, 7, "printArray")]
