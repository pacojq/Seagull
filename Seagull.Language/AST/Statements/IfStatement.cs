
using System.Collections.Generic;
using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Statements
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
            Else = new List<IStatement>();
        }
        
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
        
    }
}