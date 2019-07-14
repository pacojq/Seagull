using System.IO;
using Antlr4.Runtime;

namespace Seagull.Errors
{
    public class ErrorListener : BaseErrorListener, IAntlrErrorListener<int>
    {
        public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine,
            string msg, RecognitionException e)
        {
            ErrorHandler.Instance.RaiseError(line, charPositionInLine+1, "Syntax error: " + msg);
        }


        public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine,
            string msg, RecognitionException e)
        {
            ErrorHandler.Instance.RaiseError(line, charPositionInLine+1, "Lexical error: " + msg);
        }
    }
}