using System;
using System.Collections.Generic;
using System.Text;

namespace TucilStima3
{
    class Edge
    {
        public Node node1;
        public Node node2;
        public double weight;
        public Edge(Node node1, Node node2)
        {
            this.node1 = node1;
            this.node2 = node2;
            this.weight = Math.Sqrt(Math.Pow((node1.x - node2.x),2) + Math.Pow((node1.y - node2.y),2));
        }
    }
}
