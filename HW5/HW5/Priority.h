
namespace HW5
{
	template <class type>
	class Priority : SortedArr<type> 
	{

	public:

		Priority(bool(*iG)(void *, void*), bool (*iE)(void *, void *)) : SortedArr<type>(iG, iE);
		~Priority();
		void add(type v);
		int getN();
		type removeMax();
	};


	template<class type>
	inline Priority<type>::Priority(bool(*iG)(void *, void *), bool(*iE)(void *, void *)): SortedArr<type>(iG, iE)
	{
	}

	template <class type>
	inline Priority<type>::~Priority()
	{
		~base();
	}

	template <class type>
	inline type Priority<type>::removeMax() //remove the max 
	{
		type temp = Geti(indexer - 1);

		SortedArr<type>::delete_member(temp);
		return temp;
	}

};
