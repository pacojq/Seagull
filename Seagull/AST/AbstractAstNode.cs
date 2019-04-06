namespace Seagull.AST
{
    public abstract class AbstractAstNode : IAstNode
    {
        public int Line { get; private set; }
        public int Column { get; private set; }


        public AbstractAstNode(int line, int column)
        {
            Line = line;
            Column = column;
        }
        
    }
}