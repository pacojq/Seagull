using Seagull.Visitor;

namespace Seagull.AST.Statements
{
    public class Continue : AbstractStatement
    {
        public Continue(int line, int column) : base(line, column)
        {
        }

        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            throw new System.NotImplementedException();
        }
    }
}