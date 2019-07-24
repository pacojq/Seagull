using System.Collections.Generic;
using Seagull.AST.Types;
using Seagull.SymTable.Scopes;
using Seagull.Visitor;

namespace Seagull.AST.Statements.Definitions
{
    public class NamespaceNode : AbstractStatement
    {

        public NamespaceScope Scope { get; set; }
        
        public string Name { get; }
        
        public List<string> Parents { get; }
        
        public IEnumerable<IDefinition> Definitions => _definitions;

        private List<IDefinition> _definitions;
        

        public NamespaceNode(int line, int column, string name, 
                IEnumerable<string> parents, IEnumerable<IDefinition> definitions) : base(line, column)
        {
            Name = name;
            Parents = new List<string>(parents);
            _definitions = new List<IDefinition>(definitions);
        }


        public override string ToString()
        {
            return Name + " namespace";
        }


        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }

        
    }
}