using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW2
{
    class Courses : Pert
    {
        private int n;
        private string []name;
      
        public Courses(int n) : base(n)
        {
            this.n = n;
            name = new string[n];
        }

       public void addCourse(string str)
        {
            this.name[--n] = str;
        }

       public void prerequisite(string str1, string str2)
        {
            int i = Array.IndexOf(name, str1);
            int j = Array.IndexOf(name, str2);
            base.prerequisite(i, j);
        }

       override protected void show_assignment(int i)
        {
            Console.Out.WriteLine(name[i]);
        }

    }
}
