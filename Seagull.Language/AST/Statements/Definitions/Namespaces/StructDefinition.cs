using Seagull.Language.AST.Types.Namespaces;
using Seagull.Language.Semantics.Symbols;
using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Statements.Definitions.Namespaces
{
    public class StructDefinition : AbstractDefinition, INamespaceDefinition
    {
        
        public StructDefinition(int line, int column, string name, IType type) : base(line, column, name, type)
        {
            
        }

        
        public override string ToString()
        {
            string ns = "";
            if (this.Namespace != NamespaceManager.DefaultNamespace)
                ns = this.Namespace.Name + ".";

            return "struct " + ns + Name;
        }

        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}