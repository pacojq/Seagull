using System.Collections.Generic;
using Antlr4.Runtime.Misc;
using Seagull.AST.Types;
using Seagull.Visitor;

namespace Seagull.AST.Statements.Definitions
{
    public class NamespaceDefinition : AbstractDefinition
    {

        private readonly List<IDefinition> _definitions;
        public IEnumerable<IDefinition> Definitions => _definitions;

        
        
        public NamespaceDefinition(int line, int column, string name, NamespaceType type) 
            : base(line, column, name, type)
        {
            _definitions = new List<IDefinition>();
        }


        public void AddDefinition(IDefinition def)
        {
            _definitions.Add(def);
            def.Namespace = this;
        }


        public override string ToString()
        {
            return Namespace.ToString();
        }


        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }

        
    }
}