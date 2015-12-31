
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

		SortedArr(bool(*isGreaterr)(void *, void *), bool(*isEquall)(void *, void *)) //constructor
		{
			isGreater = isGreaterr;
			isEqual = isEquall;
		}


		~SortedArr()
		{
			for (int i = 0; i < indexer; i++)
			{
				delete arr[i];
			}
			delete[]arr;
		}


		void add(type v) // add an element to array + increase array size by 1
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


		bool delete_member(type v) // remove element v from array and decrease array size by 1
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


		type Geti(int i) //get the i-th element in array
		{
			return *((type*)arr[i]);
		}


		int getN() //get array size
		{
			return indexer;
		}
	};

};


