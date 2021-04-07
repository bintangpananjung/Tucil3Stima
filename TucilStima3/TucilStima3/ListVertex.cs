using System;
using System.Collections.Generic;
using System.Text;

namespace TucilStima3
{
    class ListVertex
    {
        public List<Vertex> edgeList;
        public ListVertex()
        {
            edgeList = new List<Vertex>();
        }
        public void addEdgeList(Node node1, Node node2)
        {
            edgeList.Find(v => v.node.name == node1.name).edges.Add(new Edge(node1,node2));
        }
        public void addNodeList(Node newNode)
        {
            if (edgeList.Find(v => v.node.name == newNode.name) == null)
            {
                edgeList.Add(new Vertex(newNode));
            }
        }
        /*public void printListNode()
        {
            if (edgeList.Count != 0)
            {
                foreach (var v in edgeList)
                    v.printEdge();
            }
        }*/
        public void findPath(List<Node> path, Node name, Node other)
        {
            Node tempPath = other;
            for (int i = edgeList.Count - 1; i >= 0; i--)
            {
                if (edgeList[i].edges.Find(v => v.node2.name==tempPath.name)!=null)
                {
                    path.Add(tempPath);
                    tempPath = edgeList[i].node;
                }
            }
            path.Add(name);
        }
        public void printPath(List<Node> path, List<double> pathCost)
        {
            //Console.Write("(");
            int i;
            for (i = path.Count - 1; i > 0; i--)
            {
                Console.Write(path[i].name + "-("+pathCost[(i-1)].ToString()+")>");
            }
            Console.WriteLine(path[i].name);
            /*Console.Write(path[i].name + ", " + (path.Count - 2).ToString());
            if (path.Count - 2 == 1)
            {
                Console.Write("st");
            }
            else if (path.Count - 2 == 2)
            {
                Console.Write("nd");
            }
            else if (path.Count - 2 == 3)
            {
                Console.Write("rd");
            }
            else
            {
                Console.Write("th");
            }*/
            //Console.Write(" Degree)\n");
        }
    }
}
