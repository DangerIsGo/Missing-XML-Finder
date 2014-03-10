using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MissingXMLFinder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_go_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("Output.txt", false);

            DirectoryInfo di = new DirectoryInfo("Z:\\HD Movies");

            this.ParseFolders(di.FullName, sw);

            sw.Close();
        }

        private void ParseFolders(string path, StreamWriter sw)
        {
            if (Directory.GetFiles(path, "*.mkv").Count() > 0)
            {
                if ((Directory.GetFiles(path, "*.xml").Count() == 0) && (Directory.GetFiles(path, "*.jpg").Count() == 0))
                {
                    sw.WriteLine(new DirectoryInfo(path).Name);
                    return;
                }
            }

            foreach (string dir in Directory.GetDirectories(path))
            {
                this.ParseFolders(dir, sw);
            }
        }
    }
}
