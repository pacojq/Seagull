using Seagull.Visitor;

namespace Seagull.AST.Expressions
{
    public class New : AbstractExpression
    {
        public New(int line, int column, IType type) : base(line, column)
        {
            Type = type;
        }

        
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}