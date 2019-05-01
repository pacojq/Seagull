using System.Collections.Generic;
using Antlr4.Runtime.Misc;
using Seagull.AST.Types;
using Seagull.Visitor;

namespace Seagull.AST.Statements.Definitions
{
    public class NamespaceDefinition : AbstractNamespaceDefinition
    {



        public NamespaceDefinition(int line, int column, string name, NamespaceType type)
            : base(line, column, name, type)
        {
        }


        public override string ToString()
        {
            return Namespace.ToString();
        }


        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }

        
    }
}