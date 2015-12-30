/*
#include <iostream>
#include "SortedArr.h"
using namespace std;
using namespace HW5;


	template <class type>
	SortedArr<type>::SortedArr(bool(*isGreater)(void *, void *), bool(*isEqual)(void *, void *))// constructor
	{
		this.isGreater = isGreater;
		this.isEqual = isEqual;
	}

	template <class type>
	SortedArr<type>::~SortedArr()// destructor
	{
		for (int i; i < indexer; i++)
		{
			delete arr[i];
		}
		delete[]arr;
	}

	template <class type>
	void SortedArr<type>::add(type v) // add v to the queue
	{

		indexer++;
		(void*)[]tmp = new (void*)[indexer];


		if (indexer == 1)
		{
			tmp[0] = &(new type);
			(type)(*tmp[0]) = v;
			arr = tmp;
			return;
		}
		bool placed = false;
		int i = 0;
		while (!placed)
		{

			if (i < indexer - 1 && isGreater(&v, arr[i]))
			{
				tmp[i] = arr[i];
			}
			else
			{
				tmp[i] = &(new type);
				(type)(*tmp[i]) = v;


				placed = true;
			}
			i++;
		}
		while (i < indexer)
		{
			tmp[i] = arr[i - 1];
			i++;
		}

		arr = tmp;


	}


	template <class type>
	bool SortedArr<type>::delete_member(type v)  // delete v from the queue
	{
		if (indexer <= 0)
		{
			return false;
		}
		int found = 0;
		for (int i = 0; i < indexer; i++)
		{
			if (isEqual(arr[i], &v) && (found == 0))
			{
				found = 1;
				delete arr[i];
			}
			else if (found == 1)
			{
				arr[i - 1] = arr[i];

			}
		}
		 
		if (found == 0)
			return false;
		

		indexer--;
		type ** tmp = new type* [indexer];
		for (int i = 0; i < indexer; i++)
		tmp[i] = arr[i];
		delete []arr;
		arr = tmp;
		return true;

	}




	template <class type>
	type SortedArr<type>::Geti(int i) // return the value of index i from the queue
	{
		return (type)arr[i];
	}

	template <class type>
	int SortedArr<type>::getN() { return indexer; } // getter for size
	*/
