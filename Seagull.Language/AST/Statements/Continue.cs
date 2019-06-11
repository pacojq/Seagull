using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Statements
{
    public class Continue : AbstractStatement
    {
        public Continue(int line, int column) : base(line, column)
        {
        }

        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}