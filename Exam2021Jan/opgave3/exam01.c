

void main(){
    dynamic t;
    t = createTable(3);
    updateTable(t, 0, 42);
    updateTable(t, 1, 43);
    updateTable(t, 2, 44);

    print indexTable(t, 0);
    print indexTable(t, 1);
    print indexTable(t, 2);

    printTable(t);
    print indexTable(t, 0);
}
