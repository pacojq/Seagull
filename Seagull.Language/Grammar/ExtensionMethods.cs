using Antlr4.Runtime;

namespace Seagull.Language.Grammar
{
    public static class ExtensionMethods
    {
        public static int GetLine(this IToken token)
        {
            return token.Line;
        }
        
        public static int GetCol(this IToken token)
        {
            return token.Column+1;
        }
        
        public static string GetText(this IToken token)
        {
            return token.Text;
        }
        
    }
}