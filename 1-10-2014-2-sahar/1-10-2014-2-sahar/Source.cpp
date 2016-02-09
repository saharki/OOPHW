#include <iostream>
#define N 20
#define NBITS 32
using namespace std;

class splitter
{
	private:
	unsigned long int *arr;
	unsigned long int *parr[32];
	int len[32];
	int size;
	public:
	splitter()
	{

	}
	splitter(unsigned long int *arr,int n)
	{
		int temp_sizes[NBITS];
		unsigned long int power, *ptr;
		int found;
		int i, j;
		splitter::arr = new unsigned long int[n];
		for (i = 0; i < n; i++)
			splitter::arr[i] = arr[i];
		for (i = 0; i < NBITS; i++)
			temp_sizes[i] = len[i] = 0;
		for (i = 0; i < n; i++)
		{
			power = 1;
			found = 0;
			for (j = 0; (j < NBITS) && (found == 0); j++)
			{
				if (arr[i] < power)
				{
					len[j]++;
					found = 1;
				} // if
				power *= 2;
			} // for
		} // for
		for (i = 0; i < NBITS; i++)
			if (len[i] != 0)
				parr[i] = new unsigned long int[len[i]];
		for (i = 0; i < n; i++)
		{
			power = 1;
			found = 0;
			for (j = 0; (j < NBITS) && (found == 0); j++)
			{
				if (arr[i] < power)
				{
					
					ptr = parr[j];
					ptr[temp_sizes[j]] = arr[i];
					temp_sizes[j]++;
					found = 1;
				} // if
				power = power * 2;
			}// for
		} // for
	}
	~splitter()
	{
		delete arr;
		for (int i = 0; i < NBITS; i++)
			delete parr[i];
	}
	splitter(splitter& src)
	{
		size = src.size;
		arr = new unsigned long int[src.size];
		for (int i = 0; i < src.size; i++)
			arr[i] = src.arr[i];
		for (int i = 0; i < NBITS; i++)
		{
			len[i] = src.len[i];
			if (src.len[i] != 0)
			{
				parr[i] = new unsigned long int[src.len[i]];
				for (int j = 0; j < len[i]; j++)
				{
					parr[i][j] = src.parr[i][j];
				}
			}
			else
			{
				parr[i] = NULL;
			}
		}
	}
	splitter& operator=(splitter& rhs)
	{
		if (this == &rhs) return *this;

		
		for (int i = 0; i < NBITS; i++)
		{
			if (len[i] != 0)
			{
				delete parr[i];
			}
			len[i] = 0;
		}
		delete arr;
		arr = new unsigned long int[rhs.size];
		size = rhs.size;

		for (int i = 0; i < rhs.size; i++)
			arr[i] = rhs.arr[i];
		for (int i = 0; i < NBITS; i++)
		{
			len[i] = rhs.len[i];
			if (rhs.len[i] != 0)
			{
				parr[i] = new unsigned long int[rhs.len[i]];
				for (int j = 0; j < len[i]; j++)
				{
					parr[i][j] = rhs.parr[i][j];
				}
			}
			else
			{
				parr[i] = NULL;
			}
		}
		return *this;
	}
	friend static ostream& operator <<(ostream& stream, splitter& src)
	{
		for (int i = 0; i < NBITS; i++)
		{
			if (src.len[i] > 0)
			{
				stream << i << ": ";
				for (int j = 0; j < src.len[i]; j++)
				{
					stream << src.parr[i][j] << " ";
				}
				stream << endl;
			}
		}
		return stream;
	}
	const unsigned long int& operator[](int i)
	{
		return arr[i];
	} 

};




void print(splitter src)
{
	cout << src;
} // print

int main()
{
	unsigned long int arr[N] =
	{ 10001, 2002, 30003, 40004, 6006, 7007, -8008,
		90009, 10010, -1111, 12012, 13013,
		14014,15015,
		16016, 170017, -18018, 19019, 20020, 21021 };
	int i, j;


	splitter spl1(arr, 20);
	splitter spl2;

	cout << "spl1:" << endl;
	print(spl1);

	spl2 = spl1;

	cout << "spl2:" << endl;
	print(spl2);

	cout << "\nspl1[2] = " << spl1[2] << endl;

} // main
