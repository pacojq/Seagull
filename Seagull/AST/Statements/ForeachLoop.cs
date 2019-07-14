using System.Collections.Generic;
using Seagull.Visitor;

namespace Seagull.AST.Statements
{
    public class ForeachLoop : AbstractStatement
    {
        
        public IExpression Element { get; }
        
        public IExpression Collection { get; }
        
        public IEnumerable<IStatement> Statements { get; }
        
        
        public ForeachLoop(int line, int column, IExpression element,  IExpression collection, 
                IEnumerable<IStatement> statements) 
            : base(line, column)
        {
            Element = element;
            Collection = collection;
            Statements = new List<IStatement>(statements);
        }


        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}