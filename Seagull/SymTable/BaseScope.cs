using System;
using System.Collections.Generic;

namespace Seagull.SymTable
{
    public abstract class BaseScope : IScope
    {
        public string Name { get; protected set; }
        
        public IScope ParentScope { get; set; }
        
        public IEnumerable<IScope> NestedScopes => _nestedScopes;



        private List<IScope> _nestedScopes;
        
        private Dictionary<string, ISymbol> _symbols;



        private BaseScope()
        {
            _nestedScopes = new List<IScope>();
            _symbols = new Dictionary<string, ISymbol>();
        }
        
        public BaseScope(IScope parent) : this()
        {
            ParentScope = parent;
        }
        
        
        
        
        public ISymbol Solve(string name)
        {
            ISymbol s = GetSymbol(name);
            if (s != null)
                return s;

            if (ParentScope == null)
                return null;

            return ParentScope.Solve(name);
        }

        public ISymbol GetSymbol(string name)
        {
            if (!_symbols.ContainsKey(name))
                return null;
            return _symbols[name];
        }

        
        public bool Define(ISymbol symbol)
        {
            if (_symbols.ContainsKey(symbol.Name))
                return false;

            symbol.Scope = this;
            symbol.IndexInScope = _symbols.Count;
            _symbols.Add(symbol.Name, symbol);
            
            if (symbol is SymbolWithScope)
                _nestedScopes.Add((SymbolWithScope) symbol);
            
            return true;
        }
        
        
        public bool Nest(IScope scope)
        {
            if (scope is SymbolWithScope)
                throw new ArgumentException($"SymbolWithScope {scope.Name} must be added with Define()");

            if (_nestedScopes.Contains(scope))
                return false;
            
            _nestedScopes.Add(scope);
            return true;
        }
    }
}