using Seagull.Visitor;

namespace Seagull.AST.Expressions
{
    public class New : AbstractExpression, IStatement
    {
        public IExpression Expression { get; }
        
        public New(int line, int column, IExpression expression) : base(line, column)
        {
            Expression = expression;
        }

        
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            throw new System.NotImplementedException();
        }
    }
}