#include<iostream>
using namespace std;
/*Doesnt work, some constructor issue*/
 double triple(double x)
{
	return x*x*x;
}
class bisection
{
protected:
	double(*f)(double);
public:
	bisection(double(*ff)(double))
	{
		f = ff;
	}
	virtual double halfroot(double a, double b, double interval)=0;
};


class cubic_root_10 : public bisection
{
public:
	double start, end, inter;

	cubic_root_10(double a, double b, double interval) : base(triple)
	{
		start = a;
		end = b;
		inter = interval;
	}
	double halfroot(double a, double b, double interval)
	{
		double mid;
		while (f(mid) < 0.1)
		{
			mid = a / 2 + b / 2;
			if (f(mid)*f(b) < 0)
				a = mid;
			else
				b = mid;
		}
			return mid;
		
	}

	double evaluate()
	{
		return  halfroot(start, end, inter);
	}
};

int main()
{

	double x;
	int i;

	cubic_root_10 cr10(0.0, 5.0, 0.0000000001);

	x = cr10.evaluate();
	cout << x << " * " << x << " * " << x << " = " << x*x*x << endl;


} /* main */

