using Seagull.Visitor;

namespace Seagull.AST.Statements
{
    public class ReturnNode : AbstractStatement
    {
        
        public IExpression Value { get; }
        
        
        public ReturnNode(int line, int column, IExpression value) : base(line, column)
        {
            Value = value;
        }
        
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}