
namespace HW5
{

	template <class type>
	class SortedArr {


	private:

		bool(*isEqual) (void *, void *);
		bool(*isGreater) (void *, void *);
		type ** arr = nullptr;  // our queue
	protected:
		int indexer = 0;
	public:

		SortedArr(bool(*isGreater)(void *, void *), bool(*isEqual)(void *, void *));
		~SortedArr();

		void add(type v);

		bool delete_member(type v);

		type Geti(int i);
		int getN();

	};






	template<class type>
	inline SortedArr<type>::SortedArr(bool(*isGreaterr)(void *, void *), bool(*isEquall)(void *, void *))
	{
		isGreater = isGreaterr;
		isEqual = isEquall;
	}

	template<class type>
	inline SortedArr<type>::~SortedArr()
	{
		for (int i=0; i < indexer; i++) 
		{
			delete arr[i];
		}
		delete[]arr;
	}

	template<class type>
	inline void SortedArr<type>::add(type v)
	{
		indexer++;
	type**tmp = new type*[indexer];


	if (indexer == 1)
	{
		tmp[0] = new type;
		*tmp[0] = v;
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
			tmp[i] = new type;
			*tmp[i] = v;


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

	template<class type>
	inline bool SortedArr<type>::delete_member(type v)
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
		type ** tmp = new type*[indexer];
		for (int i = 0; i < indexer; i++)
			tmp[i] = arr[i];
		delete[]arr;
		arr = tmp;
		return true;
	}
	 
	template<class type>
	inline type SortedArr<type>::Geti(int i)
	{
		return *((type*)arr[i]);
	}

	template<class type>
	inline int SortedArr<type>::getN()
	{
		return indexer;
	}

};


