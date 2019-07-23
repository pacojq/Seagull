using System.Collections.Generic;

namespace Seagull.SymTable
{
    public interface IScope
    {
        string Name { get; }
        
        
        IScope ParentScope { get; set; }

        
        IEnumerable<IScope> NestedScopes { get; }
        
        
        
        
        /// <summary>
        /// Finds a symbol recursively: if the symbol is
        /// not in this scope, we'll look in our parent scopes.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ISymbol Solve(string name);


        /// <summary>
        /// Looks for a symbol in the current scope.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ISymbol GetSymbol(string name);


        /// <summary>
        /// Define a <see cref="ISymbol"/> in the current scope.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>Whether we succeed defining the symbol.</returns>
        bool Define(ISymbol symbol);
        

        /// <summary>
        /// Just like <see cref="Define"/>, but with scopes.
        /// </summary>
        /// <param name="scope"></param>
        /// /// <returns>Whether we succeed defining the new scope.</returns>
        bool Nest(IScope scope);
    }
}