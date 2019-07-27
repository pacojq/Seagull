using Seagull.Visitor;

namespace Seagull.AST.Statements
{
    public class ContinueNode : AbstractStatement
    {
        public ContinueNode(int line, int column) : base(line, column)
        {
        }

        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}