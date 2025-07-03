#include <stdio.h>
#include <stdlib.h>

int * dizi = NULL;
int sira = 0, sirabasi = 0, boyut = 2;


int deque(){
	if(sira == sirabasi){
		printf("Sýra boþ");
	}	
	
	if(sira-sirabasi<boyut/4){
		int * dizi2 = (int *)malloc(sizeof(int)*boyut/2);
		for(int i=0;i<=sira-sirabasi && boyut >= 0;i++){
			dizi2[i] = dizi[sirabasi+i];
		}
		sira -= sirabasi;
		sirabasi = 0;
		free(dizi);
		boyut /= 2;
		dizi = dizi2;
		
	}
	
	return dizi[sirabasi++];
}

int enque(int a){
	if(dizi == NULL){
		dizi = (int *)malloc(sizeof(int)*2);
	}
	
	if(sira>=boyut){
		boyut *= 2;
		int * dizi2 = (int *)malloc(sizeof(int)*boyut);
		for(int i=0; i<boyut/2; i++){ //üstte boyutu 2 ile çarptýðýmýz için bu satýrda boyutu 2'ye böldük çünkü orijinal boyut zaten bu þekilde
		dizi2[i] = dizi[i];
		}
		free(dizi);
		dizi = dizi2;
	}
	dizi[sira++] = a;
}


void yazdir(){
	printf("\nBoyut: %d, sira: %d, sirabasi: %d \n", boyut, sira, sirabasi);
	for(int i=0; i<boyut; i++){
		printf("[%d]  ", dizi[i]);
	}
}

void toparla(){
	if(sirabasi == 0){
		return ;
	}
	
	for(int i=0; i<boyut; i++){
		dizi[i] = dizi[i+sirabasi];
	}
	
	sira -= sirabasi;
	sirabasi = 0;
	
}

int main(){

	enque(1);
	printf(" -%d- ",deque());
	yazdir();


}
