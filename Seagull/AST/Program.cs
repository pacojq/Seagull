using System.Collections.Generic;
using Antlr4.Runtime.Misc;
using Seagull.Visitor;

namespace Seagull.AST
{
    public class Program : IAstNode
    {
        public int Line { get; private set; }
        public int Column { get; private set; }
        

        public IEnumerable<IDefinition> Definitions { get; private set; }

	
	
        public Program(int line, int column, IEnumerable<IDefinition> definitions)
        {
            Line = line;
            Column = column;
            Definitions = new List<IDefinition>(definitions);
        }
	
        
        public TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}