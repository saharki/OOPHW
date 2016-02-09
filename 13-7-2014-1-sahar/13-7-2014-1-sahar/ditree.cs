using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_7_2014_1_sahar
{
    class ditree
    {
        private ditree_node head;
        private int size;
        private int[] iarr;
        public ditree()
        {
            head = null;
            size = 0;
            iarr = null;
        }
        public void add(double d)
        {
            size++;
            if(size==1)
            {
                head = new ditree_node(d);     
                iarr = new int[size];
                iarr[0] = size % 2;
                return;
            }
            int []temp=new int[size];
            
            int i;
            for (i = 0; i < size-1; i++)
            {
                temp[i] = iarr[i];
            }
            i = size;
            
            while (i>1)
            {
                temp[i - 1] = i % 2;
                i /= 2;
            }
            iarr = temp;
            ditree_node t = head;
            i = size-1;
            while (i > 1)
            {
                if (iarr[i] == 0)
                    t = t.left;
                else
                    t = t.right;
                i--;
            }
            if (iarr[0] == 0) t.left = new ditree_node(d);
            else t.right = new ditree_node(d);

        }
        public void inorder_print()
        {
            if (head == null) return;
            ditree_node temp = head;
            head = temp.left;
            inorder_print();
            System.Console.WriteLine(temp.data);
            head = temp.right;
            inorder_print();
            head = temp; 
        }
    }
}
