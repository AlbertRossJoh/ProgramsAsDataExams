
void printArray(int a[]){
    int i;
    i = 0;
    while (i<5){
        print(a[i]);
        i=i+1;
    }
}

void main(){
    int a[5];
    int i;
    i = 0;
    while(i<5){
        a[i] = 42;
        i = i+1;
    }

    printArray(a);
    //print 43;
}
