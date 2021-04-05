using System;
using System.Collections.Generic;
using System.Text;

namespace TucilStima3
{
    class Graph
    {
        public List<Vertex> adjacencyList;

        public Graph()
        {
            adjacencyList = new List<Vertex>();
        }
        public void AddEdge(Node node1, Node node2)
        {
            adjacencyList.Find(v => v.node.name == node1.name).edges.Add(new Edge(node1,node2));
            adjacencyList.Find(v => v.node.name == node2.name).edges.Add(new Edge(node2,node1));
        }
        public void AddNode(Node newNode)
        {
            if (adjacencyList.Find(v => v.node == newNode) == null)
            {
                adjacencyList.Add(new Vertex(newNode));
            }
        }
        public void PrintadjacencyList()
        {
            if (adjacencyList.Count != 0)
            {
                foreach (var v in adjacencyList)
                    v.PrintEdge();
            }
        }
        /*public void LoadFile(string filename)
        {
            string[] lines = System.IO.File.ReadAllLines(filename);
            for (int idx = 1; idx < lines.Length; idx++)
            {
                string node1 = "";
                string node2 = "";
                bool parse = false;
                for (int i = 0; i < lines[idx].Length; i++)
                {
                    if (lines[idx][i] != ' ' && !parse)
                    {
                        node1 += lines[idx][i];
                    }
                    if (lines[idx][i] != ' ' && parse)
                    {
                        node2 += lines[idx][i];
                    }
                    if (lines[idx][i] == ' ')
                    {
                        parse = true;
                    }
                }
                AddNode(node1);
                AddNode(node2);
                AddEdge(node1, node2);
            }
        }*/
    }
    
}
