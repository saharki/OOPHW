using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_7_2014_1_sahar
{
    class ditree_node
    {
        public ditree_node(double d)
        {
            this.data = d;
            this.left = null;
            this.right = null;
        }
        public double data;
        public ditree_node left;
        public ditree_node right;
    }
}
