using Seagull.Visitor;

namespace Seagull.AST.Statements.Definitions
{
    public class StructDefinition : AbstractDefinition
    {
        public StructDefinition(int line, int column, string name, IType type) : base(line, column, name, type)
        {
        }

        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}