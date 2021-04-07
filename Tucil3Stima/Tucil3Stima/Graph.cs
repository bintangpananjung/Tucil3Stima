using System;
using System.Collections.Generic;
using System.Text;

namespace Tucil3Stima
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
            bool edge = false;
            for (int idx = 0; idx < lines.Length; idx++)
            {
                string node1 = "";
                string node2 = "";
                bool parse = false;
                int space = 0;
                if (!edge)
                {
                    string xtemp ="";
                    string ytemp ="";
                    for (int i = 0; i < lines[idx].Length; i++)
                    {
                        if (lines[idx][i] == '~')
                        {
                            edge = true;
                            //Console.WriteLine(edge);
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
                            if (lines[idx][i] == ' ')
                            {
                                space++;
                            }
                        }
                    }
                    /*Console.WriteLine(lines[idx]);
                    Console.WriteLine(node1);
                    Console.WriteLine(xtemp);
                    Console.WriteLine(ytemp);
                    Console.WriteLine(space);*/
                    if (!edge)
                    {
                        AddNode(new Node(node1, Convert.ToDouble(xtemp), Convert.ToDouble(ytemp)));
                    }
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
        public double euclideanDistance(double a, double b)
        {
            return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        }
        public double SumCostCount(Node tempStart, Node tempAdjacent, Node destination)
        {
            return euclideanDistance(tempStart.x - tempAdjacent.x, tempStart.y - tempAdjacent.y) + euclideanDistance(tempAdjacent.x - destination.x, tempAdjacent.y - destination.y);
        }
        public void printListNodeSumCost(List<NodeSumCost> listsum)
        {
            for(int i = 0; i < listsum.Count; i++)
            {
                Console.Write(listsum[i].tempNode.name + "(" + (listsum[i].sumCost).ToString() + ") ");
            }
            Console.WriteLine("");
            Console.WriteLine("");
        }
        public void BFSSearch(List<NodeSumCost> queue, Queue<Node> visited, Node start, Node destination, ListVertex result)
        {
            Node node;
            bool found = false;
            Node adjacentnode;
            while (queue.Count != 0 && !found)
            {
                queue.Sort((a, b) => Convert.ToInt32(a.sumCost) - Convert.ToInt32(b.sumCost));
                //printListNodeSumCost(queue);
                node = queue[0].tempNode;
                queue.RemoveAt(0);
                result.addNodeList(node);
                for (int i = 0; i < adjacencyList.Find(v => v.node.name == node.name).edges.Count; i++)
                {
                    adjacentnode = adjacencyList.Find(v => v.node.name == node.name).edges[i].node2;
                    if (!visited.Contains(adjacentnode) )
                    {
                        queue.Add(new NodeSumCost(adjacentnode,SumCostCount(start,adjacentnode,destination)));
                        if (adjacentnode == destination)
                        {
                            queue.Sort((a, b) => Convert.ToInt32(a.sumCost) - Convert.ToInt32(b.sumCost));
                            if (queue[0].tempNode == destination)
                            {
                                visited.Enqueue(adjacentnode);
                                result.addEdgeList(node, adjacentnode);
                                found = true;
                                break;
                            }
                        }
                        else
                        {
                            visited.Enqueue(adjacentnode);
                            result.addEdgeList(node, adjacentnode);
                        }
                    }
                }

            }
        }
        public void shortestPath(Node start, Node destination)
        {
            List<NodeSumCost> queue = new List<NodeSumCost>();
            ListVertex result = new ListVertex();
            Queue<Node> visited = new Queue<Node>();
            queue.Add(new NodeSumCost(start, SumCostCount(start, start, destination)));
            BFSSearch(queue, visited, start, destination, result);
            bool foundDest = false;
            /*for(int i=0; i < result.edgeList.Count; i++)
            {
                if (result.edgeList[i].edges.Find(e => e.node2 == destination)!=null)
                {
                    foundDest = true;
                    break;
                }
            }*/
            if (result.edgeList[(result.edgeList.Count-1)].edges.Find(e => e.node2==destination)!=null)
            {
                List<Node> path = new List<Node>();
                List<double> pathCost = new List<double>();
                result.findPath(path, start, destination);
                for(int i=0; i < path.Count - 1; i++)
                {
                    pathCost.Add(euclideanDistance(path[i].x - path[(i + 1)].x, path[i].y - path[(i + 1)].y));
                }
                result.printPath(path,pathCost);
            }
            else
            {
                Console.WriteLine("Tidak ada jalur koneksi yang tersedia");
                Console.WriteLine("Anda harus memulai koneksi baru itu sendiri.");
            }
        }
    }
    
}
