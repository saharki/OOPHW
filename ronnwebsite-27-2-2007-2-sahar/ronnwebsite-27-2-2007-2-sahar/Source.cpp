#include<iostream>
using namespace std;
/*ronn's algorithm doesn't work, everything else is OK*/
struct element_rec
{

	int key;
	char info[80];

}; // element_rec

int compare(element_rec x, element_rec y)
{

	return x.key - y.key;
} // compare

template<class ELEMENT_TYPE>
 class heap_template 
{
private:
	int maxSize,size;
	ELEMENT_TYPE *arr;
public:
	heap_template(int n)
	{
		maxSize = n;
		arr = new ELEMENT_TYPE[n];
		size = 0;
	}
	~heap_template()
	{
		delete arr;
	}
	void insert(ELEMENT_TYPE x)
	{
		arr[size] = x;
		size++;
		int i = size - 1, j;
		ELEMENT_TYPE temp;
		while (i != 0)
		{
			if (i % 2 == 1)
			{
				j = i / 2;
			}
			else
				j = i / 2 - 1;
			if (compare(arr[j], arr[i]) >= 0)
				return;
			else
			{
				temp = arr[i];
				arr[i] = arr[j];
				temp = arr[j];
				i = j;
			}
		}
	}
		ELEMENT_TYPE remove()
		{
			ELEMENT_TYPE d = ELEMENT_TYPE();
			if (size == 0)
				return d;
			ELEMENT_TYPE temp = arr[0];
			arr[0] = arr[size - 1];
			int i = 0,j;
			ELEMENT_TYPE temp2;
			while (true)
			{
				if ((2 * i + 2 )> size)
				{
					if ((2 * i + 1) >= size)
					{
						return temp;
					}
					else
					{
						j = 2 * i + 1;
					}
				}
				else if (compare(arr[2 * i + 1] , arr[2 * i + 2])>=0)
				{
					j = 2 * i + 1;
				}
				else
				{
					j = 2 * i + 2;
				}

				if (j <= i)
				{
					return temp;
				}
				else
				{
					temp2 = arr[i];
					arr[i] = arr[j];
					temp2 = arr[j];
					i = j;
				}
			}
		}
	
};


class  priority_queue
{
protected:
	heap_template<element_rec> *heap;

public:

	priority_queue(int size)
	{
		heap = new  heap_template<element_rec>(size);
	} // priority_queue 

	void enqueue(element_rec x)
	{
		heap->insert(x);
	} // insert  
	element_rec dequeue()
	{
		return heap->remove();
	} // insert 


};


int main()
{
	int i, n;
	element_rec e;

	cout << "How many elements ? " << endl;
	cin >> n;
	priority_queue pq(n);

	for (i = 0; i < n; i++)
	{
		cout << "Enter Name:" << endl;
		cin >> e.info;
		cout << "Enter Key:" << endl;
		cin >> e.key;
		pq.enqueue(e);
	}//for

	cout << "Elenents in sorted order:" << endl;

	for (i = 0; i < n; i++)
	{
		e = pq.dequeue();
		cout << "Name = " << e.info << ", Key = " << e.key << endl;
	} // for

	return 0;

} // main
