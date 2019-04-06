using System.Collections.Generic;
using Antlr4.Runtime.Misc;

namespace Seagull.AST
{
    public class Program
    {
        public int Line { get; private set; }
        public int Column { get; private set; }
	
        private readonly List<IDefinition> _definitions;

	
	
        public Program(int line, int column, IEnumerable<IDefinition> definitions)
        {
            Line = line;
            Column = column;
            _definitions = new List<IDefinition>(definitions);
        }
	
	
        public IEnumerable<IDefinition> GetDefinitions()
        {
            return _definitions;
        }
	
    }
}