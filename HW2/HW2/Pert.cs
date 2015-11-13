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

        public Pert(int n)
        {
            // TODO: Complete member initialization
            this.n = n;
            arcArr = new Arc[n];
        }
        public void prerequisite(int p1, int p2)
        {
            throw new NotImplementedException();
        }
        public void printStages()
        {

        }
    }
}
