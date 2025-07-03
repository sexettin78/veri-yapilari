#include <stdio.h>
#include <stdlib.h>
struct n{
	int data;
	n * sol; 
	n * sag;
};
typedef n node;
node * ekle(node *agac, int x){
	if(agac == NULL){
		node * root = (node *)(malloc(sizeof(node)));
		root -> sol = NULL;
		root -> sag = NULL;
		root -> data = x;
		return root;
	}
	
	if(agac -> data <x){
		agac -> sag = ekle(agac->sag,x);
		return agac;
	}
	if(agac -> data >x){
		agac ->sol = ekle(agac->sol,x);
		return agac;
	}
}


void lnr(node *agac){
	if(agac == NULL){return;}
	lnr(agac->sol);
	printf("%d ", agac -> data);
	lnr(agac->sag);
}

void rnl(node *agac){
	if(agac == NULL){return;}
	rnl(agac->sag);
	printf("%d ", agac -> data);
	rnl(agac->sol);
}

void nlr(node *agac){
	if(agac == NULL){return;}
	printf("%d ", agac -> data);
	nlr(agac->sol);
	nlr(agac->sag);
}

int bul(node * agac, int aranan){
	if(agac == NULL){return -1;}
	if(agac->data == aranan){return 1;}
	if(bul(agac->sag, aranan)==1){return 1;}
	if(bul(agac->sol, aranan)==1){return 1;}
	return -1;
	}

int max(node *agac){
	while(agac->sag!=NULL){
		agac=agac->sag;
	}
	return agac->data;
}

int min(node *agac){
	while(agac->sol!=NULL){
		agac=agac->sol;
	}
	return agac->data;
}

node * sil(node *agac, int x){
	if(agac==NULL){return NULL;}
	if(agac->data == x){
		if(agac->sol==NULL && agac->sag==NULL){
			return NULL;
		}
		if(agac->sol!=NULL){
			agac->data = max(agac->sol);
			agac->sol = sil(agac->sol, max(agac->sol));
			return agac;	
		}
		
		agac->data = min(agac->sag);
		agac->sag = sil(agac->sag, min(agac->sag));
		return agac;
	}
	
	if(agac->data < x){
		agac->sag = sil(agac->sag,x);
		return agac;
	}
	agac->sol = sil(agac->sol, x);
	return agac;
	
}


int main(){
	node * agac = NULL;
	agac = ekle(agac, 10);
	agac = ekle(agac, 8);
	agac = ekle(agac, 12);
	agac = ekle(agac, 7);
	agac = ekle(agac, 9);
	agac = ekle(agac, 11);
	agac = ekle(agac, 13);

	
	//printf("arama sonucu: %d", bul(agac,24));
	//printf("min: %d", min(agac));
	//printf("max: %d", max(agac));
	
	agac = sil(agac, 10);
	nlr(agac);
	
}
