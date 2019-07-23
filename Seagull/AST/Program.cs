using System;
using System.Collections.Generic;
using System.Linq;
using Seagull.AST.Statements.Definitions;
using Seagull.Visitor;

namespace Seagull.AST
{
    public class Program : IAstNode
    {
        public int Line { get; private set; }
        public int Column { get; private set; }


        // Code generation
        public string CgCode { get; set; }

        
        private readonly List<IDefinition> _definitions;
        public IEnumerable<IDefinition> Definitions => _definitions;
        

        public IDefinition MainFunction => _definitions.Find(def => def.Name.Equals("main") && def is FunctionDefinition);
        
        
        /// <summary>
        /// Imported files
        /// </summary>
        private readonly List<string> _loads;
        public IEnumerable<string> Loads => _loads;
        
        
        /// <summary>
        /// Imported namespaces
        /// </summary>
        private readonly List<string> _imports;
        public IEnumerable<string> Imports => _imports;


        public Program(int line, int column, IEnumerable<string> loads, IEnumerable<string> imports, IEnumerable<IDefinition> definitions)
        {
            Line = line;
            Column = column;
            _loads = new List<string>();
            _imports = new List<string>();
            _definitions = new List<IDefinition>();
            
            _loads.AddRange(loads);
            _imports.AddRange(imports);
            
            AddDefinitions(definitions);
        }
	
        
        public TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }

        public void AddDefinitions(IEnumerable<IDefinition> definitions)
        {
            foreach (var def in definitions)
            {
                if (def == null)
                    throw new Exception("Cannot add null definitions to a Program.");
                _definitions.Insert(0, def);
            }
        }
    }
}