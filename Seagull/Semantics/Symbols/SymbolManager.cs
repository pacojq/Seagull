using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Seagull.AST;
using Seagull.AST.Statements.Definitions;
using Seagull.AST.Types;
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



        private readonly DependencyManager _dependencyManager;
        


        private SymbolManager()
        {
            _symbolTables = new Dictionary<string, SymbolTable>();
            _namespaces = new Stack<INamespaceDefinition>();
            
            PushNamespace(NamespaceManager.DefaultNamespace);
            
            _dependencyManager = new DependencyManager();
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
        
        
        
        // ================== USER DEFINED SYMBOLS ================== //

        public IType AddUserDefined(int line, int column, string id)
        {
            return _dependencyManager.AddType(line, column, id);
        }

        public void SolveDependencies()
        {
            _dependencyManager.SolveDependencies();
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
            INamespaceDefinition ns = _namespaces.Peek();
            while (ns != null)
            {
                IDefinition result = _symbolTables[ns.Fullname].Find(id);
                if (result != null)
                    return result;
                ns = ns.Namespace;
            }
            return null;
        }

        
    }
}