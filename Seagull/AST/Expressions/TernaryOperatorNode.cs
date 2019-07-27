using Seagull.Visitor;

namespace Seagull.AST.Expressions
{
    public class TernaryOperatorNode : AbstractExpression
    {
        
        public IExpression Condition { get; }
        public IExpression ThenExpr { get; }
        public IExpression ElseExpr { get; }
        
        
        public TernaryOperatorNode(IExpression condition, IExpression thenExpr, IExpression elseExpr) 
            : base(condition.Line, condition.Column)
        {
            Condition = condition;
            ThenExpr = thenExpr;
            ElseExpr = elseExpr;
        }
        
        
        

        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}