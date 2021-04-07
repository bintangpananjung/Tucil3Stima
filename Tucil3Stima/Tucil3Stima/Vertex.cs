using System;
using System.Collections.Generic;

namespace Tucil3Stima
{
    class Vertex
    {
        public List<Edge> edges;
        public Node node;

        public Vertex(Node node)
        {
            this.node = node;
            this.edges = new List<Edge>();
        }
        public void PrintEdge()
        {
            Console.Write(node.name + " | ");
            foreach (var e in edges)
                Console.Write(e.node2.name +"("+ e.weight +")"+ " ");
            Console.Write('\n');
        }

    }
}
