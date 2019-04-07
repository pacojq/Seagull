namespace Seagull.AST.Statements
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
    }
}