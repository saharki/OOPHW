namespace HW5
{
	template <class type>
	class Priority : SortedArr<type>
	{
	public:
		Priority(bool(*iG) (void *, void *), bool(*iE)(void *, void *)) : SortedArr<type>(iG, iE)
		{

		}
		 
		void add(type v)
		{
			SortedArr<type>::add(v); 
		}
		int getN()
		{
			return SortedArr<type>::getN();
		}




		type removeMax()
		{
			type temp = Geti(indexer - 1);
			SortedArr<type>::delete_member(temp);
			return temp;
		}
	};
};