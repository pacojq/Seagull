using Seagull.Visitor;

namespace Seagull.AST.Expressions
{
    public class Default : AbstractExpression
    {
        
        public Default(int line, int column, IType type) : base(line, column)
        {
            Type = type;
        }

        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            throw new System.NotImplementedException();
        }
        
    }
}