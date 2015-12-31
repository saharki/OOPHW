
namespace HW5
{
	template <class type>
	class Priority : SortedArr<type>
	{

	public:

		Priority(bool(*isGreater)(void *, void *), bool(*isEqual)(void *, void *)) : base(isGreater, isEqual); // runs the father constructor	
		~Priority();
		void add(type v);
		int getN();
		type removeMax();

	};

	template <class type>
	inline Priority(bool(*isGreater)(void *, void *), bool(*isEqual)(void *, void *)) : base(isGreater, isEqual) // runs the father constructor
	{
	}

	template <class type>
	inline ~Priority()
	{
		~base();
	}

	template <class type>
	inline type removeMax() //remove the max 
	{
		type temp = Geti(indexer - 1);

		base.delete_member(temp);
		return temp;
	}
	template<class type>
	inline type Priority<type>::removeMax()
	{
		return type();
	}
};
