#include <stdio.h>
#include <stdlib.h>
int *dizi;
int boyut = 2;
int tepe = 0; //0.eleman
int pop(){
		printf("\n tepe:[%d]::    boyut: [%d]\n",tepe, boyut);
	if(tepe<=boyut/4 && boyut > 2){
		int *dizi2 = (int *)malloc(sizeof(int)*boyut/2);
		for(int i=0; i<tepe;i++){
			dizi2[i] = dizi[i];
		}
		free(dizi);
		dizi = dizi2;
		printf("\n boyut:::%d\n",boyut);
		boyut /= 2;
		printf("\n boyut:::%d\n",boyut);
	}
	return dizi[--tepe];
}

void push(int a){
	if(tepe>=boyut){
		int *dizi2 = (int *)malloc(sizeof(int)*boyut*2);
		for(int i=0; i<boyut;i++){
			dizi2[i] = dizi[i];
		}
		free(dizi);
		dizi = dizi2;
		boyut *=2;
	}
	dizi[tepe++] = a;
}

void yazdir(){
	printf("\nboyut: [%d]", boyut);
	for(int i=0;i<tepe;i++){
		printf("%d ",dizi[i]);
	}
}
int main(){
	dizi = (int *)malloc(sizeof(int)*2);
	push(10);
	push(21);
	push(211);
	push(251);
	push(221);
	yazdir();
	printf("popped %d", pop());
	printf("popped %d", pop());
	printf("popped %d", pop());
	printf("popped %d", pop());
 	yazdir();
	push(10);
	push(21);
	push(211);
	push(251);
	push(221);
	push(10);
	push(21);
	push(211);
	push(251);
	push(221);
	yazdir();
} 
