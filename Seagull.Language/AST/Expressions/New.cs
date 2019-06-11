using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Expressions
{
    public class New : AbstractExpression
    {
        public string Id { get; }
        
        public New(int line, int column, string id) : base(line, column)
        {
            Id = id;
        }

        
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}