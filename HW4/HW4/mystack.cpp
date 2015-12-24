#include <iostream>
#include <string.h>
#include "mystack.h"
using namespace std;
using namespace ms;
		mystack::mystack(int n)
		{
			arrSize = n;
			sizes = new int[n];
			parr = new char*[n];
			index = 0;
		}
		mystack::~mystack()
		{
			delete []sizes;
			for (int i = 0; i < index; i++)
			{
				delete [](parr[i]);
			}
			delete []parr;
		}
		void mystack::push(void *info, int data_size)
		{
			if (index >= arrSize)
			{
				return;
			}
			sizes[index] = data_size;
			parr[index] = new char[data_size];
			memcpy(parr[index], info, data_size);
			index++;
		}
		void mystack::read_top_info(char *dest)
		{
			if (index <= 0)
				return;
			memcpy(dest, parr[index - 1], sizes[index - 1]);
		}
		int mystack::top_info_size()
		{
			if (index <= 0)
				return -1;
			return sizes[index - 1];
		}
		void mystack::pop()
		{
			if (index <= 0)
				return;
			delete []parr[index - 1];
			index--;
		}

		int ms::mystack::getSize()
		{
			return arrSize;
		}

		mystack::mystack(const mystack&src)
		{
			parr = new char*[src.arrSize];
			sizes = new int[src.arrSize];
			arrSize = src.arrSize;
			index = src.index;
			for (int i = 0; (i < src.index && i < arrSize); i++)
			{
				parr[i] = new char[src.sizes[i]];
				memcpy(parr[i], src.parr[i], src.sizes[i]);
				sizes[i] = src.sizes[i];
			}
		}

		mystack& mystack::mystack::operator = (const mystack& src)
		{
			index = src.index;
			for (int i = 0; (i < src.index && i < arrSize); i++)
			{
				parr[i] = new char[src.sizes[i]];
				memcpy(parr[i], src.parr[i], src.sizes[i]);
				sizes[i] = src.sizes[i];
			}
			return *this;
		}

		 void ms::print_mystack_sizes(mystack src)
		 {
			 if (src.top_info_size() == -1)
				 return;
			 int n = src.top_info_size();
			 src.pop();
			 print_mystack_sizes(src);
			 cout << n << endl;
		 }
