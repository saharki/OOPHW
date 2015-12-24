namespace ms
{
	class mystack
	{
	private:
		int arrSize, index;
		int *sizes;
		char **parr;
	public:
		mystack(int n);
		~mystack();
		void push(void *info, int data_size);
		void read_top_info(char *dest);
		int top_info_size();
		void pop();
		mystack(const mystack & src);
		int getSize();
		mystack& mystack::operator = (const mystack& src);
	};
	 extern void print_mystack_sizes(mystack src);

}