using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Expressions
{
    public class TernaryOperator : AbstractExpression
    {
        
        public IExpression Condition { get; }
        public IExpression ThenExpr { get; }
        public IExpression ElseExpr { get; }
        
        
        public TernaryOperator(IExpression condition, IExpression thenExpr, IExpression elseExpr) 
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