using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Expressions
{
    public class Default : AbstractExpression
    {
        
        public Default(int line, int column, IType type) : base(line, column)
        {
            Type = type;
        }

        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
        
    }
}