#include <iostream>
using namespace std;
class screen
{
protected:
	char *parr[25];
public:
	virtual void change_line(int line_no, char str[]) = 0;
	virtual void print_line(int i) = 0;
	virtual void print_screen() = 0;
};

class sparce_screen :screen
{

public:
	

	sparce_screen()
	{
		for (int i = 0; i < 25; i++)
		{
			parr[i] = NULL;
		}
	}
	~sparce_screen()
	{
		for (int i = 0; i < 25; i++)
		{
			if (parr[i] != NULL)
			{
				delete parr[i];
				parr[i] = NULL;
			}
		}
	}
	sparce_screen(const sparce_screen& src)
	{

		int i, n;

		for (i = 0; i < 25; i++)
		{
			if (src.parr[i] == NULL)
				parr[i] = NULL;
			else
			{
				n = strlen(src.parr[i]) + 1;
				parr[i] = new char[n];
				strcpy(parr[i], src.parr[i]);
			} // else
		} // for

	}

	sparce_screen& operator=(const sparce_screen& src)
	{
		for (int i = 0; i < 25; i++)
		{
			if (parr[i] != NULL)
			{
				delete []parr[i];
			}
		}
		for (int i = 0; i < 25; i++)
		{
			if (src.parr[i] != NULL)
			{
				parr[i] = new char[strlen(src.parr[i])+1];
				strcpy(parr[i], src.parr[i]);
			}
			else parr[i] = NULL;
		}
		return *this;
	}
	void change_line(int line_no, char str[])
	{
		if (line_no >= 25 || line_no < 0)
			return;
		if (parr[line_no] == NULL)
			delete [] parr[line_no];
		if (str == NULL)
			parr[line_no] = NULL;
		else
		{
			parr[line_no] = new char[strlen(str) + 1];
			strcpy(parr[line_no], str);
		}

	}
	void print_line(int i)
	{
		if(parr[i]!=NULL)
		cout << parr[i] << endl;
		else cout << endl;

	}
	void print_screen()
	{
		for (int i = 0; i < 25; i++)
		{
			if (parr[i] != NULL)
				cout << parr[i] << endl;
			else cout << endl;
		}
	}
};

typedef class one_line_screen : public sparce_screen
{
private:
	int nonblank_index;

public:
	one_line_screen() :sparce_screen()
	{
		nonblank_index = -1;
	} // one_line_screen

	void change_line(int line_no, char str[])
	{

		if ((nonblank_index != -1) && (nonblank_index != line_no))
		{
			sparce_screen::change_line(nonblank_index, NULL);
		} // if 

		sparce_screen::change_line(line_no, str);
		nonblank_index = line_no;
	} // change_line


} ONE_LINE;




void dolittle(sparce_screen dummy)
{

} // dolittle

int main()
{
	int x;
	sparce_screen spsc1, spsc2;
	one_line_screen olsc1;

	spsc1.change_line(10, "Screen 1");
	spsc1.change_line(15, "Screen 1");

	spsc2 = spsc1;
	spsc1.change_line(8, "Screen 2");

	dolittle(spsc2);
	spsc1.print_screen();
	spsc2.print_screen();
	spsc1.change_line(10, "Screen 1");
	spsc1.change_line(15, "Screen 1");
	
	olsc1.change_line(8, "One Line screen 1");
	olsc1.change_line(5, "One Line screen 2");
	olsc1.change_line(15, "One Line screen 3");

	olsc1.print_screen();
	
} // main


