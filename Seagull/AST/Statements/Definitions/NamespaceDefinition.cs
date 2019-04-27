using System.Collections.Generic;
using Seagull.AST.Types;
using Seagull.Visitor;

namespace Seagull.AST.Statements.Definitions
{
    public class NamespaceDefinition : AbstractDefinition
    {

        public NamespaceDefinition Parent { get; }
        public IEnumerable<IStatement> Statements => _statements;


        private readonly List<IStatement> _statements;
        
        
        public NamespaceDefinition(int line, int column, string name, NamespaceDefinition parent, IEnumerable<IStatement> statements) 
            : base(line, column, name, null)
        {
            Parent = parent;
            _statements = new List<IStatement>(statements);
        }
        
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }

    }
}