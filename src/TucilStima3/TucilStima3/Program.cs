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
            Graph graph = new Graph();
            graph.LoadFile("itb.txt");
            //graph.PrintadjacencyList();
            Node A = graph.adjacencyList.Find(v => v.node.name == "KebunBinatang").node;
            Node D = graph.adjacencyList.Find(v => v.node.name == "BebekAliBorme").node;
            graph.shortestPath(A, D);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        
    }
}
