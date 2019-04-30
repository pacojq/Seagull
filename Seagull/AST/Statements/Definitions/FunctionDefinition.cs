using System.Collections.Generic;
using Seagull.AST.Types;
using Seagull.Visitor;

namespace Seagull.AST.Statements.Definitions
{
    public class FunctionDefinition : AbstractDefinition
    {

        private List<IStatement> _statements;
        public IEnumerable<IStatement> Statements => _statements;
        
        
        public FunctionDefinition(int line, int column, string name, IType functionType, 
            IEnumerable<IStatement> statements) : base(line, column, name, functionType)
        {
            _statements = new List<IStatement>();
            if (statements != null)
                _statements.AddRange(statements);
        }
        
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }

    }
}