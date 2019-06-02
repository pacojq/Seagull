using Seagull.AST.Statements.Definitions;
using Seagull.AST.Statements.Definitions.Namespaces;
using Seagull.AST.Types;

namespace Seagull.AST.Statements
{
    public abstract class AbstractDefinition : AbstractStatement, IDefinition
    {
        
        public string Name { get; }
        
        public IType Type { get; internal set; }

        public int Scope { get; set; }
        
        public int CgOffset { get; set; }
        
        public virtual INamespaceDefinition Namespace { get; set; }

        public AbstractDefinition(int line, int column, string name, IType type) : base(line, column)
        {
            Name = name;
            Type = type;
        }
    }
}