using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System.Drawing;
using System.IO;



namespace Graammar
{
    public partial class Form1 : Form
    {
        int current = 0;

        public Form1()
        {
            InitializeComponent();
            init();
        }

     

        void init()
        {
            Color c = Color.FromArgb(31, 31, 31);
            HeadrPanel.BackColor = c;
            this.BackColor = c;
            FilePanel.BackColor = c;
            RichConsole.BackColor = c;
        }



        private void RunBtn_Click(object sender, EventArgs e)
        {

            RichConsole.Clear();

            string input = RichInput.Text;

            AntlrInputStream inputStream = new AntlrInputStream(input);
            GrammarLexer lexer = new GrammarLexer(inputStream);
            CommonTokenStream tokenStream = new CommonTokenStream(lexer);
            GrammarParser parser = new GrammarParser(tokenStream);
            ErrorListener2 errorListener = new ErrorListener2(this,Errorsbox);

            Errorsbox.Clear();
            parser.RemoveErrorListeners();
            parser.AddErrorListener(errorListener);

            IParseTree tree = parser.program();
        
            
            try
            {

                parser.program();

                if (!errorListener.HasErrors)
                {



                }
                else
                {
                    foreach (var s in errorListener.Errors)
                    {
                        Errorsbox.Text += s.ToUpper();
                    }

                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show($"Error: {ex.Message}");
            }

            GrammarVisitor visitor = new GrammarVisitor(RichConsole,RichInput,this);
            visitor.Visit(tree);
        }


        private void RichInput_TextChanged(object sender, EventArgs e)
        {
            Tools.updateLines(RichInput, richTextBox1, current);
            Tools.HighlightSyntax(RichInput);
        }







        public class ErrorListener2 : IAntlrErrorListener<IToken>
        {

            private readonly Form1 form;
            RichTextBox rich;

            public ErrorListener2(Form1 from,RichTextBox r)
            {
                rich = r;
                this.form = from;
            }
            public List<string> Errors { get; } = new List<string>();
            public bool HasErrors = false;



            public void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
            {
                rich.AppendText($"Error at line {line}, column {charPositionInLine}: {msg}");
                HasErrors = Errors.Count > 0;
                Errors.Add($"Error at line {line}, column {charPositionInLine}: {msg}");
            }
        }






    }

 
}

