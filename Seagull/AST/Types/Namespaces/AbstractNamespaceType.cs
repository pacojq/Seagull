using System;
using System.Collections.Generic;

namespace Seagull.AST.Types.Namespaces
{
    public abstract class AbstractNamespaceType : AbstractType, INamespaceType
    {
        
        public abstract string Name { get; set; }

        public string Fullname
        {
            get
            {
                if (ParentNamespace == null)
                    return Name;
                if (ParentNamespace.Fullname.Length == 0)
                    return Name;
                return ParentNamespace.Fullname + "." + Name;
            }
        }
        
        
        
        
        private INamespaceType _parentNamespace;
        public INamespaceType ParentNamespace
        {
            get => _parentNamespace; 
            set
            {
                if (_parentNamespace != null)
                    throw new InvalidOperationException("Cannot change a NamespaceType Parent once it's set.");
                _parentNamespace = value;
            }
        }
        
        
        
        
        public IEnumerable<IDefinition> Definitions => _definitions.Values;
        
        private readonly Dictionary<string, IDefinition> _definitions;
        
        
        protected AbstractNamespaceType(int line, int column) : base(line, column)
        {
            _definitions = new Dictionary<string, IDefinition>();
        }

        
        
        public bool AddDefinition(IDefinition definition)
        {
            if (definition == null)
                throw new ArgumentNullException(nameof(definition));
                
            if (_definitions.ContainsKey(definition.Name))
                return false;
            _definitions.Add(definition.Name, definition);
            return true;
        }
        
        public IDefinition FindDefinition(string name)
        {
            if (_definitions.ContainsKey(name))
                return _definitions[name];
            return null;
        }
    }
}