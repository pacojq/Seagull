using System.Text;
using Seagull.AST;

namespace Seagull.SymTable
{
    public abstract class BaseSymbol : ISymbol
    {
        public string Name { get; }
        public IScope Scope { get; set; }
        public int IndexInScope { get; set; }
        
        public IDefinition Definition { get; set; }


        public BaseSymbol(string name)
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