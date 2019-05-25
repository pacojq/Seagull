using System;
using System.Collections.Generic;
using Seagull.AST;
using Seagull.AST.Statements.Definitions;
using Seagull.AST.Statements.Definitions.Namespaces;
using Seagull.AST.Types;
using Seagull.AST.Types.Namespaces;
using Seagull.Errors;
using Seagull.Logging;

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
                return ((INamespaceType) _namespaces.Peek().Type).Fullname;
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

            INamespaceType t = (INamespaceType) ns.Type;
            if (!_symbolTables.ContainsKey(t.Fullname))
                _symbolTables.Add(t.Fullname, new SymbolTable());
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
            INamespaceType t = (INamespaceType) ns.Type;
            
            
            if (CurrentSymbolTable.Insert(definition))
            {
                Logger.Instance.LogDebug(
                    "Definition '{0}' inserted in namespace '{1}'. Scope = {2}", 
                    definition.Name, 
                    t.Fullname,
                    definition.Scope);
                
                return true;
            }
            
            Logger.Instance.LogDebug(
                "Could not insert definition '{0}' in namespace '{1}'", 
                definition.Name, 
                t.Fullname);
            
            return false;
        }
        
        
        public IDefinition Find(string id)
        {
            IDefinition result;
            
            // Find in current namespace
            INamespaceType t = (INamespaceType) _namespaces.Peek().Type;
            result = FindInNamespace(id, t);
            
            if (result != null)
                return result;
            
            // TODO find in imported namespaces
            
            
            return null;
        }
        
        
        /// <summary>
        /// Finds a definition for a given <see cref="id"/> in the wished namespace.
        /// If we cannot find it there, we'll look for it in the parent namespaces. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ns"></param>
        /// <returns></returns>
        private IDefinition FindInNamespace(string id, INamespaceType ns)
        {
            if (ns == null) // Not found in the Default namespace.
                return null;

            Logger.Instance.LogDebug("Looking for {0} in namespace '{1}'", id, ns.Fullname);
            
            // Find in current namespace
            if (!_symbolTables.ContainsKey(ns.Fullname))
            {
                Logger.Instance.LogDebug("Key {0} not found.", ns.Fullname);
                return FindInNamespace(id, ns.ParentNamespace);
            }
            
            
            IDefinition result = _symbolTables[ns.Fullname].Find(id);
            if (result != null)
            {
                Logger.Instance.LogDebug("Result found =>\t{0}", result);
                return result;
            }

            // ... and in parent namespaces
            return FindInNamespace(id, ns.ParentNamespace);
        }

        
    }
}