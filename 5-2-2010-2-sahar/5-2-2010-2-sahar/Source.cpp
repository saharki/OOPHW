#include<iostream>
using namespace std;

class node
{
public:
	node *next, *prev;
	double data;
};
class fifo
{
private:
	node *head=NULL,*tail=NULL;
	node *cursor;
public:
	fifo()
	{
		head=NULL;
		tail=NULL;
		cursor=NULL;
	}
	fifo(const fifo& src)
	{
		node *temp=src.head,*temp2=NULL;
		
		while(temp!=NULL)
		{
			if(temp2==NULL)
			{
				head = temp2 = new node;
				temp2->next=NULL;
				temp2->prev=NULL;
				temp2->data=temp->data;
				tail=temp2;
			}
			else
			{
				temp2->next=new node;
				temp2->next->prev=temp2;
				temp2=temp2->next;
				temp2->next=NULL;
				temp2->data=temp->data;
				
			}
			temp = temp->next;
		}
	}
	fifo& operator=(const fifo& rhs)
	{
		if(this==&rhs) 
			return *this;
		
		
		node *temp=head,*temp2=NULL;
		while(temp!=NULL)
		{
			temp2=temp->next;
			delete temp;
			temp=temp2;
		}
		temp=rhs.head;
		while(temp!=NULL)
		{
			if(temp2==NULL)
			{
				temp2 = new node;
				temp2->next=NULL;
				temp2->prev=NULL;
				temp2->data=temp->data;
				tail=temp2;
				head = temp2;
			}
			else
			{
				temp2->next=new node;
				temp2->next->prev=temp2;
				temp2=temp2->next;
				temp2->next=NULL;
				temp2->data=temp->data;
				tail=temp2;
			}
			temp = temp->next;
		}
		
		return *this;
	}
	void add(double newinfo)
	{
		node *temp;
		temp= new node;
		temp->data = newinfo;
		temp->prev = NULL;
		temp->next = NULL;
		if (head==NULL)
		{
			head = temp;
			tail = temp;
		}
		else
		{
			temp->next=NULL;
			temp->prev=tail;
			tail->next = temp;
			tail=temp;
		}
	}
	
	bool remove(double& info)
	{
		if(tail==NULL)
			return false;
		info=head->data;
		node *temp=head;
		head=head->next;
		if(head==NULL)
			tail=NULL;
		else
			head->prev=NULL;
		delete temp;
		return true;
			
		
	}
	
	void iterator_init()
	{
		cursor=head;
	}
	void iterator_next()
	{
		if(cursor!=NULL)
			cursor=cursor->next;
	}
	double iterator_info()
	{
		return cursor->data;
	}
	bool iterator_is_end()
	{
		return (cursor==NULL);
	}
};



void print_fifo(fifo parm)
{
	for (parm.iterator_init(); parm.iterator_is_end() != true; parm.iterator_next())
	{
		cout << parm.iterator_info() << " ";
	}
	cout << endl;
}
int main()
{
	double d;
	int i;
	fifo myfifo1, myfifo2;

	for (i = 0; i < 10; i++)
	myfifo1.add(i*1.1);
	cout << "myfifo:\n";
	print_fifo(myfifo1);

	myfifo2 = myfifo1;

	cout << "myfifo2.remove(d)=" << myfifo2.remove(d) << endl;
	cout << "d=" << d << endl;
	cout << "myfifo2.remove(d)=" << myfifo2.remove(d) << endl;
	cout << "d=" << d << endl;

	cout << "myfifo1:\n";
	print_fifo(myfifo1);

	cout << "myfifo2:\n";
	print_fifo(myfifo2);
}