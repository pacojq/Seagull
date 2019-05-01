using System;
using System.Collections.Generic;
using Seagull.AST;

namespace Seagull.Semantics.Symbols
{
    public class SymbolTable
    {

        public int Scope { get; private set; }
        private List<Dictionary<string, IDefinition>> _table;
	
	
        public SymbolTable()
        {
            Initialize();
        }

        public void Initialize()
        {
            Scope = 0;
            _table = new List<Dictionary<string, IDefinition>>();
            _table.Add(new Dictionary<string, IDefinition>());
        }
        
        
        
        
        

        public void Set()
        {
            Scope ++;
            if (_table.Count >= Scope)
                _table.Add(new Dictionary<string, IDefinition>());
        }
	
        public void Reset()
        {
            if (Scope == 0)
                throw new Exception("Don't you fool dare to set the Scope to -1.");
            _table[Scope].Clear();
            Scope --;
        }
	
        public bool Insert(IDefinition definition)
        {
            string key = definition.Name;
            if (CurrentMap().ContainsKey(key))
                return false;
		
            CurrentMap().Add(key, definition);
            definition.Scope = Scope;
            return true;
        }
	
	
        public IDefinition Find(string id)
        {
            IDefinition def;
            for (int s = Scope; s >= 0; s --) {
                def = FindInScope(s, id);
                if (def != null)
                    return def;
            }
            return null;
        }
	

        public IDefinition FindInCurrentScope(string id)
        {
            return FindInScope(Scope, id);
        }



	
	
        private Dictionary<string, IDefinition> CurrentMap()
        {
            return _table[Scope];
        }
	
        private IDefinition FindInScope(int scope, string id)
        {
            if (!_table[scope].ContainsKey(id))
                return null;
            return _table[scope][id];
        }



    }
}