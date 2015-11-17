using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW2
{
    class Pert
    {
        private int n;
        private Arc []arcArr;
        int[] inDegree;

        public Pert(int n)
        {
            this.n = n;
            inDegree = new int[n];
            arcArr = new Arc[n];
        }
        public void prerequisite(int i, int j)
        {
            Arc temp = arcArr[i];
            arcArr[i] = new Arc();
            arcArr[i].j = j;
            arcArr[i].next = temp;
            inDegree[j]++;
        }
        public void printStages()
        {
         
            int[] stage_list = new int[n];
            int[] new_stage_list = new int[n]; 

            int flag = 0;

            for(int i=0; i<this.n;i++)
            {
                if (inDegree[i]==0)
                {
                    stage_list[i]++;
                    flag = 1;
                    
                }
            }
            int count = 1;
            while (flag == 1)
            {
                flag = 0;
                Console.Out.WriteLine("stage {0}:",count++);
                for (int i = 0; i < this.n; i++)
                {
                   
                    if (stage_list[i] > 0)
                    {
                        show_assignment(i);
                        Arc temp1 = arcArr[i];
                        while (temp1 != null)
                        {
                            if ((--inDegree[temp1.j]) == 0)
                            {
                                new_stage_list[temp1.j]++;
                                flag = 1;
                            }
                            temp1 = temp1.next;
                        }
                        stage_list[i] = 0;
                    }
                }
                int[] temp = stage_list;
                stage_list = new_stage_list;
                new_stage_list = temp;
                Console.Out.WriteLine();
            }
            
        }
       virtual protected void show_assignment(int i)
        {
            Console.Out.WriteLine(i);
            
        }
    }

  
}
