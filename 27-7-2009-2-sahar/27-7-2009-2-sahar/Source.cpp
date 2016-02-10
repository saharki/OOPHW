#include<iostream>
using namespace std;

class graph_interface
{
public:

	virtual int add_edge(int i, int j)=0 ;
	virtual int delete_edge(int i,int j)=0;
	virtual int is_edge(int i,int j)=0;
};

class graph : public graph_interface
{
private:
	int **M;
	int n;
public:

	int getn()
	{
		return n;
	}
	int getM(int i, int j)
	{
		return M[i][j];
	}
	graph(int n) 
	{
		graph::n=n;
		M=new int*[n];
		for(int i=0;i<n;i++)
		{
			M[i]=new int[n];
			for(int j=0;j<n;j++)
				M[i][j]=0;
		}
	}
	
	 int add_edge(int i, int j)
	{
		int temp =M[i][j];
		M[i][j]=1;
		return temp;
	}
	
	 int delete_edge(int i, int j)
	{
		int temp = M[i][j];
		M[i][j]=0;
		return temp;
	}
	 int is_edge(int i, int j)
	{
		int temp = M[i][j];
	
		return temp;
	}
	

};
static void bfs(graph& g, int v)
{
	int *queue;
	queue = new int[g.getn()];
	int size = 0;
	int *mark = new int[g.getn()];
	for (int i = 0; i<g.getn(); i++)
		mark[i] = 0;
	size++;
	queue[size - 1] = v;
	mark[v] = 1;

	cout << v << endl;
	while (size>0)
	{
		int u = queue[0];
		size--;
		for (int i = 0; i<size; i++)
		{
			queue[i] = queue[i + 1];
		}
		for (int i = 0; i<g.getn(); i++)
		{
			if (g.getM(u,i) == 1 && mark[i] == 0)
			{
				size++;
				queue[size - 1] = i;
				mark[i] = 1;
				cout << i << " ";
			}
		}
		cout << endl;
	}



}

 
void read_input(graph g, FILE * f, int size)
{
	int i, j;
	while(EOF!= fscanf(f, "%d,%d", &i, &j))
		g.add_edge(i, j);
}
int main(void)
{
	int i;
	int st_vertex;
	FILE *source;
	int size;

	if ((source = fopen("graph.txt", "rt")) == NULL)
	{
		perror("fopen");
		exit(1);
	}
	fscanf(source, "%d", &size);
	graph My_graph(size);

	read_input(My_graph, source, size);
	puts("Enter start vertex");
		scanf("%d", &st_vertex);
	fflush(stdin);
	printf("BFS visits the nodes of the graph, starting from %d, in the following order:\n", st_vertex);
	bfs(My_graph, st_vertex);
	putchar('\n');

		return 0;
}//main


