using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Statements
{
    public class Assignment : AbstractStatement
    {
        
        public IExpression Left { get; }
        public IExpression Right { get; }
        
        public Assignment(IExpression left, IExpression right)
            : base(left.Line, left.Column)
        {
            Left = left;
            Right = right;
        }
        
        
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}