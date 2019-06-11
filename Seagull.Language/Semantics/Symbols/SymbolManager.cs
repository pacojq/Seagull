using System;
using System.Collections.Generic;
using Seagull.Language.AST.Statements.Definitions;
using Seagull.Language.AST.Types;
using Seagull.Language.Errors;
using Seagull.Language.AST;
using Seagull.Language.AST.Statements.Definitions.Namespaces;
using Seagull.Language.AST.Types.Namespaces;
using Seagull.Language.Logging;

namespace Seagull.Language.Semantics.Symbols
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


        
        //private SymbolTable CurrentSymbolTable => _symbolTables[CurrentNamespace];

       /* private string CurrentNamespace
        {
            get
            {
                if (_namespaces.Count == 0)
                    return "";
                return ((INamespaceType) _namespaces.Peek().Type).Fullname;
            }
        }
*/


        
        
        
        /// <summary>
        /// Here we store the SymbolTable for each Namespace
        /// </summary>
        private Dictionary<INamespaceType, SymbolTable> _symbolTables;
        //private Stack<INamespaceDefinition> _namespaces;


        private SymbolManager()
        {
        }

        public void Init()
        {
            _symbolTables = new Dictionary<INamespaceType, SymbolTable>();
            //_namespaces = new Stack<INamespaceDefinition>();

            AddNamespace(NamespaceManager.DefaultNamespace);
            // PushNamespace(NamespaceManager.DefaultNamespace);
        }
        
        
        
        
        // ================== NAMESPACES STUFF ================== //
        
        
        public void AddNamespace(INamespaceDefinition definition)
        {
            INamespaceType t = (INamespaceType) definition.Type;
            if (!_symbolTables.ContainsKey(t))
                _symbolTables.Add(t, new SymbolTable());
        }


        private SymbolTable GetSymbolTable(INamespaceDefinition ns)
        {
            INamespaceType t = (INamespaceType) ns.Type;
            return _symbolTables[t];
        }
        
        
        
        
        // ================== SYMBOL TABLE FACADE ================== //


        public void Set(INamespaceDefinition inNamespace)
        {
            GetSymbolTable(inNamespace).Set();
        }
        
        public void Reset(INamespaceDefinition inNamespace)
        {
            GetSymbolTable(inNamespace).Reset();
        }

        public int GetCurrentScope(INamespaceDefinition inNamespace)
        {
            return GetSymbolTable(inNamespace).Scope;
        }
        
        
        
        
        
        public bool Insert(IDefinition definition, INamespaceDefinition inNamespace)
        {
            INamespaceType t = (INamespaceType) inNamespace.Type;
            SymbolTable st = _symbolTables[t];
            
            if (st.Insert(definition))
            {
                definition.Namespace = inNamespace;
                t.AddDefinition(definition);
                
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
        
        
        public IDefinition Find(string id, INamespaceDefinition inNamespace)
        {
            return Find(id, (INamespaceType) inNamespace.Type);
        }
        
        public IDefinition Find(string id, INamespaceType inNamespace)
        {
            IDefinition result = null;
            
            // Find in current namespace
            result = FindInNamespace(id, inNamespace);
            
            if (result != null)
                return result;
            
            // TODO find in imported namespaces
            
            // TODO check if the namespace is partial
            // F.E.:
            //
            //    namespace People.Jumping {
            //        struct Jumper { }
            //    }
            //    ...
            //
            //    import People;
            //    a : Jumping.Jumper;
            
            
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
            if (!_symbolTables.ContainsKey(ns))
            {
                Logger.Instance.LogDebug("Key {0} not found.", ns.Fullname);
                return FindInNamespace(id, ns.ParentNamespace);
            }
            
            
            IDefinition result = _symbolTables[ns].Find(id);
            if (result != null)
            {
                Logger.Instance.LogDebug("Result found =>\t{0}", result);
                return result;
            }

            // ... and in parent namespaces
            Logger.Instance.LogWarning("{0} was not in namespace '{1}'. Let's look in '{2}'", id, ns.Fullname, ns.ParentNamespace);
            return FindInNamespace(id, ns.ParentNamespace);
        }

        
    }
}