using Seagull.Visitor;

namespace Seagull.AST.Statements
{
    public class Read : AbstractStatement
    {
        public IExpression Expression { get; }
        
        
        public Read(int line, int column, IExpression expression) : base(line, column)
        {
            Expression = expression;
        }
        
        
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}