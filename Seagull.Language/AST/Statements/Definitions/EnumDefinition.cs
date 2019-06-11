using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Statements.Definitions
{
    public class EnumDefinition : AbstractDefinition
    {
        public EnumDefinition(int line, int column, string name, IType type) : base(line, column, name, type)
        {
        }

        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}