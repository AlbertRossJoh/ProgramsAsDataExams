
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
