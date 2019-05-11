using System;
using System.Collections.Generic;
using Seagull.AST;
using Seagull.AST.Statements.Definitions;
using Seagull.Errors;

namespace Seagull.Semantics.Symbols
{
    public class SymbolManager
    {
        
        private static SymbolManager _instance;
        public static SymbolManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SymbolManager();
                return _instance;
            }
        }


        
        private SymbolTable CurrentSymbolTable => _symbolTables[CurrentNamespace];

        private string CurrentNamespace
        {
            get
            {
                if (_namespaces.Count == 0)
                    return "";
                return _namespaces.Peek().Fullname;
            }
        }



        
        
        
        /// <summary>
        /// Here we store the SymbolTable for each Namespace
        /// </summary>
        private readonly Dictionary<string, SymbolTable> _symbolTables;

        
        private readonly Stack<INamespaceDefinition> _namespaces;


        


        private SymbolManager()
        {
            _symbolTables = new Dictionary<string, SymbolTable>();
            _namespaces = new Stack<INamespaceDefinition>();

            PushNamespace(NamespaceManager.DefaultNamespace);
        }
        
        
        
        
        // ================== NAMESPACES STUFF ================== //
        
        
        public void PushNamespace(INamespaceDefinition ns)
        {
            _namespaces.Push(ns);
            
            if (!_symbolTables.ContainsKey(ns.Fullname))
                _symbolTables.Add(ns.Fullname, new SymbolTable());
        }
        
        public void PopNamespace()
        {
            if (_namespaces.Count == 1)
                throw new InvalidOperationException("Cannot pop the Default Namespace.");
            _namespaces.Pop();
        }
        
        
        
        
        
        // ================== SYMBOL TABLE FACADE ================== //


        public void Set()
        {
            CurrentSymbolTable.Set();
        }
        
        public void Reset()
        {
            CurrentSymbolTable.Reset();
        }
        
        
        
        
        
        public bool Insert(IDefinition definition)
        {
            INamespaceDefinition ns = _namespaces.Peek();
            Console.WriteLine("inserting definition '{0}' in namespace '{1}'", definition.Name, ns.Fullname);
            if (CurrentSymbolTable.Insert(definition))
            {
                definition.Namespace = ns;
                return true;
            }
            return false;
        }
        
        
        public IDefinition Find(string id)
        {
            // Find in current namespace
            INamespaceDefinition ns = _namespaces.Peek();
            return FindInNamespace(id, ns);
            
            // TODO find in imported namespaces
            
            // TODO find in default namespace ?
            
            return null;
        }
        
        
        /// <summary>
        /// Finds a definition for a given <see cref="id"/> in the wished namespace.
        /// If we cannot find it there, we'll look for it in the parent namespaces. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ns"></param>
        /// <returns></returns>
        private IDefinition FindInNamespace(string id, INamespaceDefinition ns)
        {
            if (ns == null) // Not found in the Default namespace.
                return null;

            Console.WriteLine("Looking for {0} in namespace '{1}'", id, ns.Fullname);
            
            // Find in current namespace
            if (!_symbolTables.ContainsKey(ns.Fullname))
            {
                Console.WriteLine("Key {0} not found.", ns.Fullname);
                return FindInNamespace(id, ns.Namespace);
            }
            
            
            IDefinition result = _symbolTables[ns.Fullname].Find(id);
            if (result != null)
            {
                Console.WriteLine("Result found: {0}", result);
                return result;
            }

            // ... and in parent namespaces
            return FindInNamespace(id, ns.Namespace);
        }

        
    }
}