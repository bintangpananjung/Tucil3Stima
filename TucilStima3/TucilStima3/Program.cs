using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TucilStima3
{
    class Program
    {
        [STAThread]
        static public void Main()
        {
            Node A = new Node("A", 10, 20);
            Node B = new Node("B", 21, 21);
            Node C = new Node("C", 2, 10);
            Node D = new Node("D", 0, 20);
            Node E = new Node("E", 10, 0);
            Node F = new Node("F", 15, 40);
            Node G = new Node("G", 1, 2);
            Graph graph = new Graph();
            graph.AddNode(A);
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
            graph.AddEdge(C, G);
            graph.PrintadjacencyList();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        
    }
}
