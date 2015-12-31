namespace HW5
{
	template <class type>
	class Priority : SortedArr<type>
	{
	public:
		Priority(bool(*iG) (void *, void *), bool(*iE)(void *, void *)) : SortedArr<type>(iG, iE) //consturctor + father constructor
		{

		}

		void add(type v) //add an ekement to array using parent's method 
		{
			SortedArr<type>::add(v);
		}
		int getN() //get array size using parent's method
		{
			return SortedArr<type>::getN();
		}




		type removeMax() // remove maxinmum element
		{
			type temp = Geti(indexer - 1);
			SortedArr<type>::delete_member(temp);
			return temp;
		}
	};
};