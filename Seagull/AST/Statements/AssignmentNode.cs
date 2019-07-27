using Seagull.Visitor;

namespace Seagull.AST.Statements
{
    public class AssignmentNode : AbstractStatement
    {
        
        public IExpression Left { get; }
        public IExpression Right { get; }
        
        public AssignmentNode(IExpression left, IExpression right)
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