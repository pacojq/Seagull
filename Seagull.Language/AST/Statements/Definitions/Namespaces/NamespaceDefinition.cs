using Seagull.Language.AST.Types.Namespaces;
using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Statements.Definitions.Namespaces
{
    public class NamespaceDefinition : AbstractDefinition, INamespaceDefinition
    {



        public NamespaceDefinition(int line, int column, string name, INamespaceType type)
            : base(line, column, name, type)
        {
        }


        public override string ToString()
        {
            return Type.ToString() + " definition";
        }


        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }

        
    }
}