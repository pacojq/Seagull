using System;
using Seagull.SymTable.Scopes;

namespace Seagull.SymTable
{
    public class SymbolTable
    {
        public static SymbolTable Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SymbolTable();
                return _instance;
            }
        }
        private static SymbolTable _instance;

        
        public static readonly IScope GlobalScope = new GlobalScope();



        public IScope CurrentScope { get; set; }
        
        private SymbolTable()
        {
            CurrentScope = GlobalScope;
        }


        public void Set(IScope scope)
        {
            CurrentScope.Nest(scope);
            CurrentScope = scope;
        }
        
        public void Reset()
        {
            if (CurrentScope == GlobalScope)
                throw new Exception("Cannot reset from the global scope.");
            
            if (CurrentScope.ParentScope == null)
                throw new Exception($"Something went wrong. {CurrentScope.Name} parent scope is null.");

            CurrentScope = CurrentScope.ParentScope;
        }



        /// <summary>
        /// Finds a symbol recursively: if the symbol is
        /// not in this scope, we'll look in our parent scopes.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ISymbol Solve(string name)
        {
            return CurrentScope.Solve(name);
        }


        /// <summary>
        /// Looks for a symbol in the current scope.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ISymbol GetSymbol(string name)
        {
            return CurrentScope.Solve(name);
        }


        /// <summary>
        /// Define a <see cref="ISymbol"/> in the current scope.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns>Whether we succeed defining the symbol.</returns>
        public bool Define(ISymbol symbol)
        {
            return CurrentScope.Define(symbol);
        }


        /// <summary>
        /// Just like <see cref="Define"/>, but with scopes.
        /// </summary>
        /// <param name="scope"></param>
        public bool Nest(IScope scope)
        {
            return CurrentScope.Nest(scope);
        }

    }
}