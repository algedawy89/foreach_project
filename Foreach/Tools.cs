using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graammar
{
    static public  class Tools
    {


        static public void print(string msg) { 
        MessageBox.Show(msg);
        }

       static public void HighlightError(RichTextBox RichInput, int startIndex, int endIndex)
        {

            
            RichInput.Select(startIndex, endIndex - startIndex + 1);
            RichInput.SelectionColor = Color.Red;
        }


        static public Type GetTypeFromString(string type)
        {

            switch (type)
            {
                case "int": return typeof(int);
                case "double": return typeof(double);
                case "string": return typeof(string);
                case "bool": return typeof(bool);
                case "object": return typeof(object);
                default: throw new ArgumentException("Unknown type: " + type);


            }


        }

        static public  void updateLines(RichTextBox RichInput,RichTextBox richTextBox1, int current)
        {
            int newLineCount = RichInput.Lines.Count();

            if (current != newLineCount)
            {
                current = newLineCount - 1;

                richTextBox1.Clear();

                for (int i = 0; i < current; i++)
                {
                    richTextBox1.AppendText((i + 1).ToString() + ":\n");
                }

                richTextBox1.AppendText((current + 1).ToString() + ": ");
            }
        }



       static private TreeNode CreateTreeNode(IParseTree tree, GrammarParser parser)
        {
            string nodeText = tree is ParserRuleContext context
                ? parser.RuleNames[context.RuleIndex]
                : tree.ToString();
            TreeNode node = new TreeNode(nodeText);

            for (int i = 0; i < tree.ChildCount; i++)
            {
                node.Nodes.Add(CreateTreeNode(tree.GetChild(i), parser));
            }

            return node;
        }


        static public string[] KEYWORDS = { "void", "foreach", "if", "else", "for", "while", "do", "print", "return", "true", "false", "int", "string", "bool", "double", "object", "var", "and", "or" };

        static public void HighlightErrorSyntax(RichTextBox RichInput, string id, string msg)
        {
            var pattern = $@"\b{Regex.Escape(id)}\b";

            foreach (Match match in Regex.Matches(RichInput.Text, pattern))
            {
                RichInput.Select(match.Index, match.Length);
                RichInput.SelectionColor = Color.Red;

                MessageBox.Show(msg);

                RichInput.SelectionStart = RichInput.TextLength;
                RichInput.SelectionLength = 0;
                RichInput.SelectionColor = RichInput.ForeColor;
            }

            RichInput.Refresh();
        }

        static public void show(Form parent, string title, string message)
        {
            showmsg msg = new showmsg(title, message);

         
            msg.Location = new Point(
                (parent.ClientSize.Width - msg.Width) / 2, 
                (parent.ClientSize.Height - msg.Height) / 2 
            );

      
            parent.Controls.Add(msg);
            msg.BringToFront(); 
        }


        static public void  HighlightSyntax(RichTextBox RichInput)
        {
            string[] keywords = { "void", "foreach","main", "if", "else", "for", "while", "do", "print", "return", "true", "false", "int", "string", "bool", "double", "object", "var", "in", "==", "!=", "<", ">", "<=", ">=", "and", "or", "&&", "||" };

            
            int selectionStart = RichInput.SelectionStart;
            int selectionLength = RichInput.SelectionLength;

            RichInput.SelectAll();
            RichInput.SelectionColor = SystemColors.Window;

            // نستخدم Regular Expression للتأكد من أننا نبحث عن الكلمة بالكامل فقط
            foreach (var keyword in keywords)
            {
                var pattern = $@"\b{Regex.Escape(keyword)}\b"; // \b تعني حد الكلمة

                foreach (Match match in Regex.Matches(RichInput.Text, pattern))
                {
                    RichInput.Select(match.Index, match.Length);

                    if (new[] { "void", "if", "else", "for", "while","foreach","main", "do" }.Contains(keyword))
                        RichInput.SelectionColor = Color.FromArgb(216, 160, 223);
                    else if (new[] { "true", "false" }.Contains(keyword))
                        RichInput.SelectionColor = Color.FromArgb(142, 221, 164);
                    else if (keyword == "return")
                        RichInput.SelectionColor = Color.FromArgb(205, 157, 133);
                    else if (new[] { "or", "and" }.Contains(keyword))
                        RichInput.SelectionColor = Color.FromArgb(216, 160, 223);
                    else if (keyword == "print")
                        RichInput.SelectionColor = Color.FromArgb(134, 198, 145);
                    else if (new[] { "int", "string", "bool", "double", "object", "var" }.Contains(keyword))
                        RichInput.SelectionColor = Color.FromArgb(62, 128, 199);
                    else
                        RichInput.SelectionColor = Color.FromArgb(62, 128, 199);
                }
            }

            // تلوين الرموز { ( ) }
            string[] symbols = { "{", "}", "(", ")" };

            foreach (var symbol in symbols)
            {
                var pattern = $@"{Regex.Escape(symbol)}"; 

                foreach (Match match in Regex.Matches(RichInput.Text, pattern))
                {
                    RichInput.Select(match.Index, match.Length);

                    if (symbol == "{")
                        RichInput.SelectionColor = Color.Orange;
                    else if (symbol == "}")
                        RichInput.SelectionColor = Color.Orange;
                    else if (symbol == "(")
                        RichInput.SelectionColor = Color.Yellow;
                    else if (symbol == ")")
                        RichInput.SelectionColor = Color.Yellow;
                }
            }


           


            bool insideQuotes = false;
            for (int i = 0; i < RichInput.Text.Length; i++)
            {
                if (RichInput.Text[i] == '"')
                    insideQuotes = !insideQuotes;

                if (insideQuotes)
                {
                    RichInput.Select(i, 2);
                    RichInput.SelectionColor = Color.FromArgb(205, 157, 133);
                }
            }

            string[] commentPatterns = { @"//.*", @"#.*" };

            foreach (var pattern in commentPatterns)
            {
                foreach (Match match in Regex.Matches(RichInput.Text, pattern))
                {
                    RichInput.Select(match.Index, match.Length);
                    RichInput.SelectionColor = Color.Green;
                }
            }
            RichInput.Select(selectionStart, selectionLength);




        }

        internal static void show(object encode, string message, Form1 form)
        {
            throw new NotImplementedException();
        }
    }
}
