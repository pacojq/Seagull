
using System.Collections.Generic;

namespace Seagull.AST.Statements
{
    public class IfStatement : AbstractStatement
    {
        
        public IExpression Condition { get; }
        public IEnumerable<IStatement> Then { get; }
        public IEnumerable<IStatement> Else { get; set; }
        
        
        public IfStatement(int line, int column, IExpression condition, IEnumerable<IStatement> thenPart)
            : base(line, column)
        {
            Condition = condition;
            Then = thenPart;
        }
        
        
    }
}