#include<iostream>
#include"Header.h"
using namespace std;

class OLARR
{
private:
	double *value_arr;
	int *next_arr;
	int first;
	int current;
	int max;
	int size;

public:
	OLARR::OLARR()
	{
		size = 0;
		first = -1;
		current = -1;
		next_arr = nullptr;
		value_arr = nullptr;
		max = 0;
		
	}
	OLARR::OLARR(int n)
	{
		size = n;
		first = -1;
		current = -1;
		next_arr = new int[n];
		value_arr = new double[n];
		for (int i = 0; i < n; i++)
		{
			next_arr[i] = -1;
			value_arr[i] = -1;
		}
		max = 0;
	}
	OLARR::~OLARR()
	{
		delete next_arr;
		delete value_arr;
	}

	int OLARR::in_init()
	{
		current = first;
		return current;
	}
	int OLARR::in_last()
	{
		return max;
	}
	int OLARR::in_next()
	{
		current = next_arr[current];
		return current;
	}
	friend ostream& OLARR::operator <<(ostream &s, OLARR& x)
	{
		for (int i = x.in_init(); i <= x.in_last(); i = x.in_next())
		{
			s << x[i] << " ";
		}
		s << endl;
		return s;
	}

	double& OLARR::operator[](int i)
	{
		int curr;
		curr = first;
		if (i > max)
			max = i;
		if (curr == -1)
		{
			first = i;
			next_arr[i] = -1;
			return value_arr[first];
		}
		while (next_arr[curr] != -1 && next_arr[curr] <= i)
		{
			curr = next_arr[curr];
		}
		if (curr == i)
			return value_arr[curr];
		else
		{
			int temp;
			temp = next_arr[curr];
			next_arr[curr] = i;
			next_arr[i] = temp;
			return value_arr[i];
		}
	}
	OLARR& operator=(const OLARR& x)
	{
		if (this == &x) return *this;
		delete value_arr;
		delete next_arr;
		first = x.first;
		current = x.current;
		max = x.max;
		size = x.size;
		value_arr = new double[size];
		next_arr = new int[size];
		for (int i = 0; i < size; i++)
		{
			next_arr[i] = x.next_arr[i];
			value_arr[i] = x.value_arr[i];
		}
		return *this;
	}
};


int main()
{
	int i, size, first;
	float vlength;
	OLARR v(40), u, w(4);
	v[11] = 11.11;
	v[8] = 8.8;
	v[10] = 10.1;
	v[6] = 6.6;
	v[14] = 14.14;
	v[9] = 9.9;
	w[0] = 0;
	w[2] = 20.2;
	w[1] = 10.1;
	w[3] = 30.3;
	cout << " The OLARR v:\n";
	cout << v << "\n";
	cout << " The OLARR w:\n";
	cout << w << "\n";
	u = w = v;
	// buff[] would be destroyed
	cout << " The OLARR w:\n";
	cout << w << "\n";
	v[0] = 100.1;
	w[0] = 200.2;
	u[0] = 300.3;
	v[0] = 100.1;
	w[0] = 200.2;
	u[0] = 300.3;
	cout << " v = " << v << endl;
	cout << " w = " << w << endl;
	cout << " u = " << u << endl;

	return 0;
}