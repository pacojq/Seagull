using System.Collections.Generic;
using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Statements
{
    public class ForLoop : AbstractStatement
    {
        
        public IStatement Initialization { get; }
        public IExpression Condition { get; }
        
        public IStatement Increment { get; }
        
        
        public IEnumerable<IStatement> Statements { get; }
        
        
        public ForLoop(int line, int column, IStatement initialization, 
            IExpression condition, IStatement increment, IEnumerable<IStatement> statements) 
            : base(line, column)
        {
            Initialization = initialization;
            Condition = condition;
            Increment = increment;
            Statements = new List<IStatement>(statements);
        }


        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}