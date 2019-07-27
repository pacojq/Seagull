using Seagull.Visitor;

namespace Seagull.AST.Expressions
{
    public class NewNode : AbstractExpression
    {
        public NewNode(int line, int column, IType type) : base(line, column)
        {
            Type = type;
        }

        
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}