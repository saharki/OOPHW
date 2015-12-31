#include "SortedArr.h"
#include "Prio.h"
#include <iostream>
using namespace std;
using namespace HW5;
bool doubleIsGreater(void *x, void *y)
{
	double *u, *v;

	u = (double *)x; 
	v = (double *)y;

	return (*u > *v);
}// doubleIsGreater 

bool doubleIsEqual(void *x, void *y)  
{
	double *u, *v;

	u = (double *)x;
	v = (double *)y;

	return (*u == *v);
}// doubleIsEqual 

bool intIsGreater(void * x, void *y)
{
	int *u, *v;

	u = (int *)x;
	v = (int *)y;

	return (*u > *v);
}// doubleIsGreater 

bool intIsEqual(void *x, void *y)
{
	int *u, *v;

	u = (int *)x;
	v = (int *)y;

	return (*u == *v);
}// intIsEqual 

int main(int argc, char *argv[])
{
	int i;
	SortedArr<double>  srt1(doubleIsGreater, doubleIsEqual);

	srt1.add(22.2);
	srt1.add(66.6);
	srt1.add(22.2);
	srt1.add(33.3);
	srt1.add(55.5);
	srt1.add(77.7);
	srt1.add(11.1);
	srt1.add(44.4);
	srt1.delete_member(55.5);

	cout << "\nsrt1:\n";
	for (i = 0; i < srt1.getN(); i++)
		cout << srt1.Geti(i) << endl;
	
	Priority<int> pri1(intIsGreater, intIsEqual);
	pri1.add(11);
	pri1.add(33);
	pri1.add(77);
	pri1.add(44);
	pri1.add(55);
	pri1.add(66);
	pri1.add(22);

	cout << "\npri1:\n";
	while (pri1.getN() > 0)
		cout << pri1.removeMax() << endl;


} // main
