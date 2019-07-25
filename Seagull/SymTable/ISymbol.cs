using Seagull.AST;

namespace Seagull.SymTable
{
    public interface ISymbol
    {
        string Name { get; }
        
        IScope Scope { get; set; }
        
        int IndexInScope { get; set; }
        
        
        IDefinition Definition { get; set; }


        string GetFullName();
        
        bool Equals(ISymbol other);
    }
}