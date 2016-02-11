#include <iostream>
using namespace std;

//The comparision is not good due to String cases.
//The array are not sorted therefore , I will not use binary search (the code is on the buttom of the page).

class Dict
{
private:
	int maxsize,size;
	int *arri;
	char **arrs;
public:
	template <typename T,typename C>
	friend inline static int gbin_search(T  arr, C x, int n);
	Dict(int n)
	{
		size=0;
		maxsize=n;
		arri=new int[n];
		arrs=new char*[n];
	}
	~Dict()
	{
		for (int i = 0; i < size; i++)
		{
			delete arrs[i];
		}
		delete arrs;
		delete arri;
	}
	int add(int key,char str[])
	{
		if(size>=maxsize)
			return -1;
		arri[size]=key;
		arrs[size]=new char[strlen(str)+1];
		strcpy(arrs[size], str);

		size++;
	}
	void Get_by_key(int key, char str[])
	{
		int j = gbin_search(arri,key,size);
		if (j >= 0)
		{
			strcpy(str,arrs[j] );

		}
		else
		{

				str[0] = '\0';
			
		}

	}

	int Get_by_str(char str[])
	{
		return arri[gbin_search(arrs,str,size)];
	}

};

int main()
{
	Dict dict(32);
	char str[16];

	dict.add(22, "022222");
		dict.add(33, "533333") ;
			dict.add(11, "411111");
				dict.add(55, "855555");
					dict.add(44, "644444");
	dict.add(66, "166666");

	dict.Get_by_key(33, str);
	cout << "Get_by_key(33)" << " = " << str << endl;
	cout << "Get_by_str(411111)" << " = " << dict.Get_by_str("411111") << endl;

	dict.Get_by_key(55, str);
	cout << "Get_by_key(55)" << " = " << str << endl;
	cout << "Get_by_str(644444)" << " = " << dict.Get_by_str("644444") << endl;

	return 0;
} // main

template <typename T, typename C>
inline int gbin_search(T  arr, C x, int n)
{
	for (int i = 0; i < n; i++)
	{
	
			if (arr[i]==x)
				return i;
		
	}
	return -1;
	/*int first, last, mid;
	first = 0;
	last = n - 1;
	while (last > first)
	{
		mid = first / 2 + last / 2;
		if (arr[mid] == x)
			return mid;
		if (arr[mid]>x)
		{
			last = mid - 1;
		}
		else
			first = mid + 1;
	}
	return -1;*/
}
