using System.Collections.Generic;

namespace Seagull.AST.Statements
{
    public class WhileLoop : AbstractStatement
    {
        
        public IExpression Condition { get; }
        public IEnumerable<IStatement> Statements { get; }
        
        
        public WhileLoop(int line, int column, IExpression condition, IEnumerable<IStatement> statements) 
            : base(line, column)
        {
            Condition = condition;
            Statements = new List<IStatement>(statements);
        }
    }
}