using System;
using System.Collections.Generic;
using Seagull.AST;
using Seagull.AST.Statements.Definitions;
using Seagull.AST.Types;
using Seagull.Errors;

namespace Seagull.Semantics.Symbols
{
    public class DependencyManager
    {

        private static DependencyManager _instance;
        public static DependencyManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DependencyManager();
                return _instance;
            }
        }



        private Dictionary<string, TypeWrapper> _dependencies;
	
	
        private DependencyManager()
        {
            Initialize();
        }

        public void Initialize()
        {
            _dependencies = new Dictionary<string, TypeWrapper>();
        }


        public void SolveDependencies()
        {
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
        }
        
        


        /// <summary>
        /// Adds a dependency that will be later checked.
        /// If at the time we check a dependency we cannot find it in any scope,
        /// we'll raise an error.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IType AddType(int line, int column, string id)
        {
            TypeWrapper dependency;
            if (!_dependencies.ContainsKey(id))
            {
                dependency = new TypeWrapper(line, column);
                _dependencies.Add(id, dependency);
            }
            else dependency = _dependencies[id];

            return dependency;
        }
        
        
    }
}