using System.Collections.Generic;
using Seagull.AST.Statements.Definitions;
using Seagull.Visitor;

namespace Seagull.AST
{
    public class Program : IAstNode
    {
        public int Line { get; private set; }
        public int Column { get; private set; }

        
        private readonly List<IDefinition> _definitions;
        public IEnumerable<IDefinition> Definitions => _definitions;
        

        public IDefinition MainFunction => _definitions.Find(def => def.Name.Equals("main") && def is FunctionDefinition);
        
        
        private readonly List<string> _imports;
        public IEnumerable<string> Imports => _imports;


        public Program(int line, int column, IEnumerable<string> imports, IEnumerable<IDefinition> definitions)
        {
            Line = line;
            Column = column;
            _imports = new List<string>();
            _definitions = new List<IDefinition>();
            
            _imports.AddRange(imports);
            _definitions.AddRange(definitions);
        }
	
        
        public TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }

        public void AddDefinitions(IEnumerable<IDefinition> definitions)
        {
            foreach (var def in definitions)
                _definitions.Insert(0, def);
        }
    }
}