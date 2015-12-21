#include <iostream>
using namespace std;

int main()
{
	float f;
	long double ld;
	int i;
	mystack stack1(40);
	int size;

	cout << "\nstack1:\n\n";

	for (i = 1; i <= 6; i++)
	{
		f = i*10.0 / 1.1;;
		stack1.push((char *)&f, sizeof(float));
	} // for

	for (i = 1; i <= 4; i++)
	{
		stack1.read_top_info((char *)&f);
		stack1.pop();
		cout << f << endl;
	} // for


	for (i = 7; i <= 9; i++)
	{
		ld = ((long double)i*10.0) / 1.1;
		stack1.push((char *)&ld, sizeof(long double));
	} // for	

	cout << "\nstack1 sizes:\n\n";
	print_mystack_sizes(stack1);

	mystack stack2(80);

	stack2 = stack1;
	cout << "\nmore stack1:\n\n";

	for (i = 1; i <= 5; i++)
	{
		size = stack1.top_info_size();
		if (size == sizeof(float))
		{
			stack1.read_top_info((char *)&f);
			cout << "f = " << f << endl;
		}
		else
			if (size == sizeof(long double))
			{
				stack1.read_top_info((char *)&ld);
				cout << "ld = " << ld << endl;
			}
		stack1.pop();
	} // for

	cout << "\nstack2:\n\n";
	for (i = 1; i <= 5; i++)
	{
		size = stack2.top_info_size();
		if (size == sizeof(float))
		{
			stack2.read_top_info((char *)&f);
			cout << "f = " << f << endl;
		}
		else
			if (size == sizeof(long double))
			{
				stack2.read_top_info((char *)&ld);
				cout << "ld = " << ld << endl;
			}
		stack2.pop();
	} // for

} // main
