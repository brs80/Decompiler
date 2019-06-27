using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System;
using System.Reflection;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "C# Corner Open File Dialog";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fdlg.FileName;
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }


        private void Button2_Click(object sender, EventArgs e)
        {
            
            String fileName = Path.GetFileName(textBox1.Text); // gets the filename 
            String[] fileNameTokens = fileName.Split('.');
            
            String[] types = new String[1000];
            int i = 0;


            if ((string.Compare(fileNameTokens[1], "exe") == 0) || (string.Compare(fileNameTokens[1], "dll") == 0))
            { 
                var DLL = Assembly.LoadFile(@"C:\Users\bytes\source\WindowsFormsApp1\WindowsFormsApp1\bin\Debug\Math.dll");
                foreach (Type type in DLL.GetExportedTypes())
                {
                    var c = Activator.CreateInstance(type);
                    types[++i] = type.ToString();
                }

                TreeNode mainNode = new TreeNode();
                mainNode.Name = "mainNode";
                mainNode.Text = types[1];
                this.treeView1.Nodes.Add(mainNode);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Not a .exe or .dll file!");
                textBox1.Text = "";
                return;
            }
        }


    }
}
