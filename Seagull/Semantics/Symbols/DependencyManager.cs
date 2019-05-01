using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Seagull.AST;
using Seagull.AST.Statements.Definitions;
using Seagull.AST.Types;
using Seagull.Errors;

namespace Seagull.Semantics.Symbols
{
    
    /*namespace*/ class DependencyManager
    {

        private readonly object _findLock = new object();

        
        private Dictionary<string, UnknownType> _dependencies;
	
	
        public DependencyManager()
        {
            Initialize();
        }

        public void Initialize()
        {
            _dependencies = new Dictionary<string, UnknownType>();
        }


        /// <summary>
        /// Adds a dependency that will be later checked.
        /// If at the time we check a dependency we cannot find it in any scope,
        /// we'll raise an error.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="column"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public IType AddType(int line, int column, string id)
        {
            UnknownType dependency;
            if (!_dependencies.ContainsKey(id))
            {
                dependency = new UnknownType(line, column, id);
                _dependencies.Add(id, dependency);
            }
            else dependency = _dependencies[id];

            return dependency;
        }
        
        
        
        
        
        public void SolveDependencies()
        {
            Parallel.ForEach(_dependencies, pair =>
            {
                string id = pair.Key;
                UnknownType depType = pair.Value;

                IDefinition def;
                lock (_findLock)
                    def = SymbolManager.Instance.Find(id);
                
                /*
                if (def == null)
                {
                    depType.SetWrappedType(ErrorHandler.Instance.RaiseError(
                        depType.Line,
                        depType.Column,
                        "Trying to use an undefined symbol: " + id)
                    );
                }
                else depType.SetWrappedType(def.Type);
                */
            });
            /*
            foreach (var pair in _dependencies)
            {
                string id = pair.Key;
                TypeWrapper depType = pair.Value;

                IDefinition def = SymbolTable.Instance.Find(id);
                if (def == null)
                {
                    depType.SetWrappedType(ErrorHandler.Instance.RaiseError(
                            depType.Line,
                            depType.Column,
                            "Trying to use an undefined symbol: " + id)
                        );
                }
                else depType.SetWrappedType(def.Type);
            }
            */
        }


        public void SolveDependency()
        {
            
        }
        
        
        
    }
}