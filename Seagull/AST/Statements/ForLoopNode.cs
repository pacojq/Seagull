using System.Collections.Generic;
using Seagull.Visitor;

namespace Seagull.AST.Statements
{
    public class ForLoopNode : AbstractStatement
    {
        
        public IStatement Initialization { get; }
        public IExpression Condition { get; }
        
        public IExpression Increment { get; }
        
        
        public IEnumerable<IStatement> Statements { get; }
        
        
        public ForLoopNode(int line, int column, IStatement initialization, 
            IExpression condition, IExpression increment, IEnumerable<IStatement> statements) 
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