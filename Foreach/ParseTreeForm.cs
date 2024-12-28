using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Grammar
{
    public partial class ParseTreeForm : Form
    {
        public ParseTreeForm(TreeView tr,string tilte, Size size)
        {
           this.Text = tilte;
           this.Size = size;
           treeView1 = tr;
        }

        
    }
}
