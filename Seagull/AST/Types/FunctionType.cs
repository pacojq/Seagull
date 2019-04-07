using System.Collections.Generic;
using Seagull.AST.Statements.Definitions;

namespace Seagull.AST.Types
{
    public class FunctionType : AbstractType
    {
        
        public IType ReturnType { get; }
        public IEnumerable<VariableDefinition> Parameters { get; }
      
        
        
        public FunctionType(IType returnType, IEnumerable<VariableDefinition> parameters)
            : base(returnType.Line, returnType.Column)
        {
            ReturnType = returnType;
            Parameters = new List<VariableDefinition>(parameters);
        }
    }
}