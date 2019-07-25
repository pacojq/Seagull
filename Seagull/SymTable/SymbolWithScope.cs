using System.Text;
using Seagull.AST;

namespace Seagull.SymTable
{
    
    /// <summary>
    /// For symbols like Structs or functions, that are both
    /// <see cref="ISymbol"/> and <see cref="IScope"/>
    /// </summary>
    public abstract class SymbolWithScope : BaseScope, ISymbol
    {
        public IScope Scope { get; set; }
        public int IndexInScope { get; set; }
        
        public IDefinition Definition { get; set; }


        public SymbolWithScope(string name, IScope parent) : base(parent)
        {
            Name = name;
        }
        
        

        
        public string GetFullName()
        {
            StringBuilder str = new StringBuilder();
            
            IScope scope = Scope;
            while (scope != null)
            {
                str.Append(scope.Name);
                str.Append(".");
                scope = scope.ParentScope;
            }

            str.Append(Name);

            return str.ToString();
        }

        public bool Equals(ISymbol other)
        {
            if (other == this)
                return true;
            return Name.Equals(other.Name);
        }
    }
}