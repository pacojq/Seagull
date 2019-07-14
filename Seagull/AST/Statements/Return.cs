using Seagull.Visitor;

namespace Seagull.AST.Statements
{
    public class Return : AbstractStatement
    {
        
        public IExpression Value { get; }
        
        
        public Return(int line, int column, IExpression value) : base(line, column)
        {
            Value = value;
        }
        
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}