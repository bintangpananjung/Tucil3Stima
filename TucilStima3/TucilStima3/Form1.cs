using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TucilStima3
{
    public partial class Form1 : Form
    {
        string iniNamaFile;

        public Form1()
        {
            InitializeComponent();
        }

        public void LoadFileVis(string filename, Microsoft.Msagl.Drawing.Graph graph, List<string> path)
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
                int x;
                for (x = 0; x < path.Count - 1; x++)
                {
                    if ((node1 == path[x] && node2 == path[(x + 1)]) || (node2 == path[x] && node1 == path[(x + 1)]))
                    {
                        break;
                    }
                }
                if (x == path.Count - 1)
                {
                    graph.AddEdge(node1, node2);
                }
                else
                {
                    graph.AddEdge(node1, node2).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                }
                graph.FindNode(node1).Attr.Shape = Microsoft.Msagl.Drawing.Shape.Circle;
                graph.FindNode(node2).Attr.Shape = Microsoft.Msagl.Drawing.Shape.Circle;
            }
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open file";
            openFileDialog1.ShowDialog();
            
            iniNamaFile = System.IO.Path.GetFileName(openFileDialog1.FileName);
            labelFileName.Text = iniNamaFile;
        }

        private void startNode_TextChanged(object sender, EventArgs e)
        {

        }

        private void destNode_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            panelGraf.Controls.Clear();
            Graph filenyaNi = new Graph();
            filenyaNi.LoadFile(iniNamaFile);

            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            LoadFileVis(iniNamaFile, graph, path);
            viewer.Graph = graph;
            panelGraf.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            panelGraf.Controls.Add(viewer);
            viewer.ResumeLayout();
        }
    }
}
