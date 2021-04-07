﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tucil3Stima
{
    class Program
    {
        static public void Main()
        {
            /*Node A = new Node("A", 10, 20);
            Node B = new Node("B", 21, 21);
            Node C = new Node("C", 2, 10);
            Node D = new Node("D", 0, 20);
            Node E = new Node("E", 10, 0);
            Node F = new Node("F", 15, 40);
            Node G = new Node("G", 1, 2);*/
            Graph graph = new Graph();
            /*graph.AddNode(A);
            graph.AddNode(B);
            graph.AddNode(C);
            graph.AddNode(D);
            graph.AddNode(E);
            graph.AddNode(F);
            graph.AddNode(G);
            graph.AddEdge(A, B);
            graph.AddEdge(E, F);
            graph.AddEdge(E, A);
            graph.AddEdge(G, F);
            graph.AddEdge(D, E);
            graph.AddEdge(B, C);
            graph.AddEdge(C, G);*/
            graph.LoadFile("itb.txt");
            //graph.PrintadjacencyList();
            Node A = graph.adjacencyList.Find(v => v.node.name == "KebunBinatang").node;
            Node D = graph.adjacencyList.Find(v => v.node.name == "BebekAliBorme").node;
            graph.shortestPath(A, D);
        }
        
    }
}
