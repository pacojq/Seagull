using Seagull.Language.Visitor;

namespace Seagull.Language.AST
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


        public abstract TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p);


    }
}