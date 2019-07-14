using Seagull.Visitor;

namespace Seagull.AST.Statements.Definitions
{
    public class EnumElementDefinition : AbstractDefinition
    {
        public IExpression Value { get; }
        
        public EnumElementDefinition(int line, int column, string name, IExpression value, IType type) : base(line, column, name, type)
        {
            Value = value;
        }

        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}