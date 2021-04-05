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
        public void AddEdge(string node1, string node2)
        {
            Node firstNode = adjacencyList.Find(v => v.node.name == node1).node;
            Node secondNode = adjacencyList.Find(v => v.node.name == node2).node;
            adjacencyList.Find(v => v.node.name == node1).edges.Add(new Edge(firstNode, secondNode));
            adjacencyList.Find(v => v.node.name == node2).edges.Add(new Edge(secondNode, firstNode));
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
        public void LoadFile(string filename)
        {
            string[] lines = System.IO.File.ReadAllLines(filename);
            for (int idx = 1; idx < lines.Length; idx++)
            {
                string node1 = "";
                string node2 = "";
                bool parse = false;
                int space = 0;
                bool edge = false;
                if (!edge)
                {
                    string xtemp ="";
                    string ytemp ="";
                    for (int i = 0; i < lines[idx].Length; i++)
                    {
                        if (lines[idx][i] == '~')
                        {
                            edge = true;
                            break;
                        }
                        else
                        {
                            if (lines[idx][i] != ' ' && space == 0)
                            {
                                node1 += lines[idx][i];
                            }
                            if (lines[idx][i] != ' ' && space == 1)
                            {
                                xtemp += lines[idx][i];
                            }
                            if (lines[idx][i] != ' ' && space == 2)
                            {
                                ytemp += lines[idx][i];
                            }
                            if (lines[idx][i] != ' ')
                            {
                                space++;
                            }
                        }
                    }
                     AddNode(new Node(node1, Convert.ToDouble(xtemp), Convert.ToDouble(ytemp)));
                }
                else
                {
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
                    AddEdge(node1, node2);
                }
            }
        }
    }
    
}
