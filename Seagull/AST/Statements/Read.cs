namespace Seagull.AST.Statements
{
    public class Read : AbstractStatement
    {
        public IExpression Expression { get; }
        
        
        public Read(int line, int column, IExpression expression) : base(line, column)
        {
            Expression = expression;
        }
    }
}