using System;
using System.Collections.Generic;
using System.Text;

namespace TucilStima3
{
    public class Node
    {
        public string name;
        public double x;
        public double y;
        public Node(string name, double xCor, double yCor)
        {
            this.name = name;
            this.x = xCor;
            this.y = yCor;
        }
    }
}
