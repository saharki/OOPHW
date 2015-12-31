namespace HW5
{
	template <class type>
	class Priority : SortedArr<type>
	{
	public:
		Priority(bool(*iG) (void *, void *), bool(*iE)(void *, void *)) : SortedArr<type>(iG, iE)
		{

		}

		inline void add(type v)
		{
			SortedArr<type>::add(v);
		}
		inline int getN()
		{
			return SortedArr<type>::getN();
		}




		inline type removeMax()
		{
			type temp = Geti(indexer - 1);
			SortedArr<type>::delete_member(temp);
			return temp;
		}
	};
};