#include <iostream>
using namespace std;

class Bound
{
private:
	float *arr;
	int size, first, last;
	int cursor;
public:
	int sizee()
	{
		return size;
	}
	Bound::Bound()
	{
		size = -1;
		arr = nullptr;
	}
	 Bound::Bound(int n)
	{
		size = n;
		first = 0;
		last = n - 1;
		arr = new float[n];
	}



	 Bound::Bound(int first, int last)
	{
		Bound::first = first;
		Bound::last = last;
		size = last - first + 1;
		arr = new float[size];
	}

	~Bound()
	{
		delete arr;
	}

	 Bound::Bound(const Bound& src)
	{
		size = src.size;
		first = src.first;
		last = src.last;
		arr = new float[size];
		for (int i = 0; i < size; i++)
			arr[i] = src.arr[i];
	}

	 Bound& operator=(const Bound&rhs)
	 {
		 if (this == &rhs)
			 return *this;
		 delete arr;
		 size = rhs.size;
		 first = rhs.first;
		 last = rhs.last;
		 arr = new float[size];
		 for (int i = 0; i < size; i++)
			 arr[i] = rhs.arr[i];
	 }

	 float & Bound::operator[](int i)
	{
		if (size==-1||size==0)
			throw -1;
		if (i<first || i>last)
			throw 1;
		return arr[i-first];
	}

	 int in_init()
	 {
		 cursor = 0;
		 return first;
	 }

	 int in_last()
	 {
		 return last;
	 }

	 int in_next()
	 {
		 cursor++;
		 return cursor + first;
	 }

	friend ostream &operator<<(ostream &stream, Bound vect);
	friend float Bound_length(Bound vect);
	friend istream& operator>>(istream &stream, Bound vect)
	{
		
		return stream;
	}
};


float Bound_length(Bound vect)
{
	int i, len;
	float sum = 0.0;
	len = vect.sizee();
	for (i = vect.in_init(); i <= vect.in_last(); i = vect.in_next())
	{
		sum = sum + vect[i] * vect[i];
	}
	return (sqrt(sum));
}
ostream &operator<<(ostream &stream, Bound vect)
{
	int i;
	for (i = vect.in_init(); i <= vect.in_last(); i = vect.in_next())
		cout << i << ": " << vect[i] << " ";
	return stream;
}

int main()
{
	int i, size, first;
	float vlength;
	cout << "How many numbers?\n";
	cin >> size;
	cout << "First index?\n";
	cin >> first;

	cout << "Enter" << size << " numbers:" << "\n";
	Bound v(first, first + size - 1), u, w(4);

	try
	{
		for (i = v.in_init(); i <= v.in_last(); i = v.in_next())
			cin >> v[i];
	}
	catch (int e)
	{
		cout << "Exception = " << e << endl;
	}
	u = w = v;
	vlength = Bound_length(u);
	cout << " The Bound:\n";
	cout << w << "\n";
	cout << "\nBound lenght: ";
	cout << vlength << "\n";

}