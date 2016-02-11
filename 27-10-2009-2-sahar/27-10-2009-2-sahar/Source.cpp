#include<iostream>
using namespace std;

class analyzer
{
	private:
	double(*f)(double);
	double(*df)(double);
	public:
	analyzer(double(*fun)(double))
	{
		f = fun;
		df=NULL;
	}
	analyzer(double(*fun)(double),double(*dfun)(double))
	{
		f = fun;
		df=dfun;
	}	
	
	double evaluate(double x)
	{
		return f(x);
	}
	double evaluate_derivative(double x)
	{
		if(df!=NULL)
			return df(x);
		double h=x/65536.0;
		return (evaluate(x+h)-evaluate(x-h))/(2*h);
	}	
	
	double solve(double x0)
	{
		double eps=1.0/65536.0;
		while(f(x0)>eps)
			x0=x0-(evaluate(x0)/evaluate_derivative(x0));
		return x0;
	}
};

class polynom_analyzer
{
	private:
	double *arr;
	int n;
	public:
	polynom_analyzer(double *ar,int n)
	{
		polynom_analyzer::n=n;
		arr=new double[n+1];
		for(int i=0;i<=n;i++)
			arr[i]=ar[i];
		
	}
	
	~polynom_analyzer()
	{
		delete arr;
	}
	
	double evaluate(double x)
	{
		double t=1;
		double sum=0;
		for(int i=0;i<=n;i++)
		{
			sum=t*arr[i];
			t*=x;
		}
		return sum;
	}
	double evaluate_derivative(double x)
	{
		double h=x/65536.0;
		return (evaluate(x+h)-evaluate(x-h))/(2*h);
	}	
	
	double solve(double x0)
	{
		double eps=1.0/65536.0;
		while(evaluate(x0)>eps)
			x0=x0-(evaluate(x0)/evaluate_derivative(x0));
		return x0;
	}
	
};


int main()
{
	analyzer a1(sin);
	analyzer a2(sin, cos);

	cout << "a1.evaluate(1.5) = " << a1.evaluate(1.5) << endl;
	cout << "a1.evaluate_derivative(1.5) = " << a1.evaluate_derivative(1.5) << endl;
	cout << "a1.solve(1.5) = " << a2.solve(1.5) << endl;

	cout << "a2.evaluate(1.5) = " << a2.evaluate(1.5) << endl;
	cout << "a2.evaluate_derivative(1.5) = " << a2.evaluate_derivative(1.5) << endl;
	cout << "a2.solve(1.5) = " << a2.solve(1.5) << endl;

	double coefs[4] = { 1.0,-2.0,-1.0,2.0 };
	polynom_analyzer da(coefs, 3);

	cout << "da.evaluate(1.5) = " << da.evaluate(1.5) << endl;
	cout << "da.evaluate_derivative(1.5) = " << da.evaluate_derivative(1.5) << endl;
	cout << "da.solve(1.5) = " << da.solve(1.5) << endl;

}