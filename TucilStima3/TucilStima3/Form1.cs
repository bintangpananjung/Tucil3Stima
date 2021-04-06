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
    }
}
