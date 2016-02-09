#include <iostream>
using namespace std;
class pyramid
{
private:
	double **arr;
	int size, h;
	
public:
	pyramid(int n)
	{
		size = n;
		h = 0;
		
		for (int i = n; i > 0;i/=2)
		{
			h++;
		}
		arr = new double*[h];
		int j = 1;
		for (int i = 0; i < h; i++)
		{
			arr[i] = new double[j];
			for (int p = 0; p < j; p++)
				arr[i][p] = 0.0;
			j *= 2;
		}
	}
	~pyramid()
	{
		for (int i = 0; i < h; i++)
		{
			delete arr[i];	
		}
		delete arr;
	}
	pyramid(const pyramid& src)
	{
		arr = new double*[src.h];
		size = src.size;
		h = src.h;
		int j = 1;
		for (int i = 0; i < src.h; i++)
		{
			arr[i] = new double[j];
			for (int p = 0; p < j; p++)
				arr[i][p] = src.arr[i][p];
			j *= 2;
		}
	}
	pyramid pyramid::operator =(const pyramid& rhs)
	{
		if (this == &rhs) return *this;

		for (int i = 0; i < h; i++)
		{
			delete arr[i];
		}
		delete arr;

		arr = new double*[rhs.h];
		h = rhs.h;
		size = rhs.size;
		int j = 1;
		for (int i = 0; i < rhs.h; i++)
		{
			arr[i] = new double[j];
			for (int p = 0; p < j; p++)
				arr[i][p] = rhs.arr[i][p];
			j *= 2;
		}
		return *this;
	}
	friend std::ostream& operator<<(std::ostream& stream,const pyramid& pyr)
	{
		int j = 1;
		for (int i = 0; i < pyr.h; i++)
		{
			for (int p = 0; p < j; p++)
				stream << pyr.arr[i][p]<<" ";
			stream << endl;
			j *= 2;
		} 
		return stream;
	} 

	void set(int i, double value)
	{
		double dif = value - arr[h - 1][i];
		for (int j = h-1; j >= 0; j--)
		{
			arr[j][i] += dif;
			i /= 2;
		}
	}
};

void print(pyramid src)
{
	cout << src;

} // cout
int main()
{
	int i, j, n;
	double d;

	n = 8;
	pyramid p1(n);
	pyramid p2(2 * n);

	for (i = 0; i < n; i++)
		p1.set(i, 100.1*i);


	cout << "p1 " << endl;
	print(p1);


	p2 = p1;
	cout << "p2 " << endl;
	print(p2);



	p1.set(5, 1.0);

	cout << "p1 " << endl;
	print(p1);

} // main

