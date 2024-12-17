
void main(){
    int x[1]; x[0] = 10;
    int y[1]; y[0] = 20;
    (x[0] < y[0] ? x[0] : y[0]) = 30;
    (x[0] < y[0] ? x[0] : y[0]) = 40;
    print x[0]; println;
    print y[0]; println;
}
