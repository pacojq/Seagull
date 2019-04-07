namespace Seagull.AST.Statements
{
    public class Print : AbstractStatement
    {
        public IExpression Expression { get; }
        
        
        public Print(int line, int column, IExpression expression) : base(line, column)
        {
            Expression = expression;
        }
    }
}