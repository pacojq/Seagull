using System.Collections.Generic;
using Seagull.Semantics.Symbols;
using Seagull.Visitor;

namespace Seagull.AST.Statements.Definitions
{
    public abstract class AbstractNamespaceDefinition : AbstractDefinition, INamespaceDefinition
    {

        public string Fullname
        {
            get
            {
                if (Namespace == null || Namespace == NamespaceManager.DefaultNamespace)
                    return Name;
                return Namespace.Fullname + "." + Name;
            }
        }
        

        private readonly List<IDefinition> _definitions;
        public IEnumerable<IDefinition> Definitions => _definitions;
        
        
        public AbstractNamespaceDefinition(int line, int column, string name, IType type) : base(line, column, name, type)
        {
            _definitions = new List<IDefinition>();
        }


        public void AddDefinition(IDefinition def)
        {
            _definitions.Add(def);
        }
    }
}