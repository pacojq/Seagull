using System.Collections.Generic;
using Seagull.AST.Types;

namespace Seagull.AST.Statements.Definitions
{
    public class FunctionDefinition : AbstractDefinition
    {

        public IEnumerable<IStatement> Statements;
        
        
        public FunctionDefinition(int line, int column, string name, FunctionType functionType, 
            IEnumerable<IStatement> statements) : base(line, column, name, functionType)
        {
            Statements = new List<IStatement>(statements);
        }

    }
}