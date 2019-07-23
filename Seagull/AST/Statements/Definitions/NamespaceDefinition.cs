using System.Collections.Generic;
using Seagull.AST.Types;
using Seagull.SymTable.Scopes;
using Seagull.Visitor;

namespace Seagull.AST.Statements.Definitions
{
    public class NamespaceDefinition : AbstractDefinition
    {

        public NamespaceScope Scope { get; set; }
        
        public IEnumerable<IDefinition> Definitions => _definitions;

        private List<IDefinition> _definitions;
        

        public NamespaceDefinition(int line, int column, string name, NamespaceType type)
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