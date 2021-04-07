using System;
using System.Collections.Generic;
using System.Text;

namespace TucilStima3
{
    public class ListVertex
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
            int i;
            for (i = path.Count - 1; i > 0; i--)
            {
                Console.Write(path[i].name + "-("+pathCost[(i-1)].ToString()+")>");
            }
            Console.WriteLine(path[i].name);
        }
    }
}
