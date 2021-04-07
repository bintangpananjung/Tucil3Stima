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

        public void LoadFileVis(string filename, Microsoft.Msagl.Drawing.Graph graph, List<Node> path, List<double> pathCost, Graph thisGraph)
        {
            string pathFile = @"..\..\..\..\test\" + filename;
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
                    string xtemp = "";
                    string ytemp = "";
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
                    if (!edge)
                    {
                        graph.AddNode(node1);
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
                    var e = graph.AddEdge(node1, node2);
                    e.Attr.ArrowheadAtSource = Microsoft.Msagl.Drawing.ArrowStyle.None;
                    e.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
                    e.LabelText= (thisGraph.euclideanDistance(thisGraph.findNode(node1).x - thisGraph.findNode(node2).x, thisGraph.findNode(node1).y - thisGraph.findNode(node2).y)).ToString("#.##");
                    int x;
                    for (x = 0; x < path.Count - 1; x++)
                    {
                        if ((node1 == path[x].name && node2 == path[(x + 1)].name) || (node2 == path[x].name && node1 == path[(x + 1)].name))
                        {
                            break;
                        }
                    }   
                    if (x == path.Count - 1)
                    {
                        
                    }
                    else
                    {
                        e.Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                    }
                }
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
            string startPlace = startNode.Text;
            string destPlace = destNode.Text;
            Node start = filenyaNi.findNode(startPlace);
            Node destination = filenyaNi.findNode(destPlace);
            ListVertex result = filenyaNi.shortestPath(start, destination);
            List<Node> path = new List<Node>();
            List<double> pathCost = new List<double>();
            if (result.edgeList[(result.edgeList.Count - 1)].edges.Find(e => e.node2 == destination) != null)
            {
                result.findPath(path, start, destination);
                for (int i = 0; i < path.Count - 1; i++)
                {
                    pathCost.Add(filenyaNi.euclideanDistance(path[i].x - path[(i + 1)].x, path[i].y - path[(i + 1)].y));
                }
                //result.printPath(path, pathCost);
            }
            else
            {
                string msgtext = "Tidak ada jalur koneksi yang tersedia, Anda harus memulai koneksi baru itu sendiri.";
                MessageBox.Show(msgtext);
            }


            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            LoadFileVis(iniNamaFile, graph, path, pathCost, filenyaNi);
            viewer.Graph = graph;
            panelGraf.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            panelGraf.Controls.Add(viewer);
            viewer.ResumeLayout();
        }
    }
}
