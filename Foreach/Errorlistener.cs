using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;




namespace Graammar
{


    public class MyErrorListener : BaseErrorListener
    {

        RichTextBox errorTextBox;

        public MyErrorListener(RichTextBox _textBox)
        {
            errorTextBox = _textBox;

        }


        public virtual void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        
        {


            errorTextBox.AppendText(msg + " line : " + line + " possotisn : " + charPositionInLine + " \n");


        }



    }




    public class ErrorListener : IAntlrErrorListener<IToken>
    {
        private readonly Form1 form;
        public bool HasError { get; private set; } = false;

        public ErrorListener(Form1 form)
        {
            this.form = form;
        }



        public void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            HasError = true;
            Tools.HighlightError(form.RichInput,offendingSymbol.StartIndex, offendingSymbol.StopIndex);
            string mssg = $"Error at line {line}, position {charPositionInLine}: {msg}";

            //MessageBox.Show(mssg);
            //Clipboard.SetText(mssg);
        }
    }


}
