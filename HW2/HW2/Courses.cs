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
      
        public Courses(int n) : base(n) //constructor
        {
            this.n = n;
            name = new string[n];
        }

       public void addCourse(string str) //add course n by its name
        {
            this.name[--n] = str;
        }

       public void prerequisite(string str1, string str2) //course 1 will be the prerequisite of course 2 - by name
        {
            int i = Array.IndexOf(name, str1);
            int j = Array.IndexOf(name, str2);
            base.prerequisite(i, j);
        }

       override protected void show_assignment(int i) //print course by name
        {
            Console.Out.WriteLine(name[i]);
        }

    }
}
