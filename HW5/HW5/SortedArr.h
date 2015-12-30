namespace HW5
{
	template <class type>
	class SortedArr
	{
	private:

		bool(*isEqual) (void *, void *);
		bool(*isGreater) (void *, void *);
		(void *)[] arr;  // our queue
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




}