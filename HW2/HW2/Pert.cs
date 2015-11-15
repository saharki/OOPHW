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
        int[] stage_list;
        int[] new_stage_list;

        public Pert(int n)
        {
            // TODO: Complete member initialization
            this.n = n;
            inDegree = new int[n];
            arcArr = new Arc[n];
            stage_list = new int[n];
            new_stage_list = new int[n];
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
            int flag = 0;

            for(int i=0; i<this.n;i++)
            {
                if (inDegree[i]==0)
                {
                    stage_list[i]++;
                    flag = 1;
                    
                }
            }
    while(flag==1)
                
            for (int i = 0; i < this.n; i++)
            {
                if (stage_list[i] > 0)
                {
                    Console.Out.Write(i +" ");
                    while (arcArr[i] != null)
                    {
                        if((--inDegree[arcArr[i].j])==0)
                        {
                            new_stage_list[arcArr[i].j]++;
                        }

                    }
                    stage_list[i] = 0;
                }
            }
            int[] temp=stage_list;
            stage_list = new_stage_list;
            new_stage_list = temp;
        }
    }
}
