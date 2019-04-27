using System.Collections.Generic;
using Seagull.AST;
using Seagull.AST.Statements.Definitions;

namespace Seagull.Semantics.Symbols
{
    public class SymbolsManager
    {
        
        private static SymbolsManager _instance;
        public static SymbolsManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SymbolsManager();
                return _instance;
            }
        }
        
        
        
        private Dictionary<string, SymbolTable> _symbols;
        private Dictionary<string, NamespaceDefinition> _namespaces;




        private SymbolsManager()
        {
            _symbols = new Dictionary<string, SymbolTable>();
            _namespaces = new Dictionary<string, NamespaceDefinition>();
        }
        
        
        
        

        /// <summary>
        /// Adds a namespace.
        /// It it already exists, it just takes the existent one and
        /// returns it.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="column"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public NamespaceDefinition AddNamespace(int line, int column, string id, NamespaceDefinition parent = null)
        {
            if (parent != null)
                id = parent.Name + "." +  id;
            
            if (!_namespaces.ContainsKey(id))
            {
                var ns = new NamespaceDefinition(line, column, id, parent, new List<IStatement>());
                _namespaces.Add(id, ns);
                return ns;
            }

            return _namespaces[id];
        }


    }
}