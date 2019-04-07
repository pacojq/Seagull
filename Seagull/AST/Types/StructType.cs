using System.Collections.Generic;
using Seagull.AST.Statements.Definitions;

namespace Seagull.AST.Types
{
    public class StructType : AbstractType
    {

        public IEnumerable<VariableDefinition> Fields;
        
        public StructType(int line, int column, IEnumerable<VariableDefinition> fields)
            : base(line, column)
        {
            Fields = new List<VariableDefinition>(fields);
        }
    }
}