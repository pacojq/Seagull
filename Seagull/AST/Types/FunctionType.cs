using System.Collections.Generic;
using Seagull.AST.Statements.Definitions;
using Seagull.Visitor;

namespace Seagull.AST.Types
{
    public class FunctionType : AbstractType
    {
        
        public IType ReturnType { get; }
        public IEnumerable<VariableDefinition> Parameters { get; }
      
        
        
        public FunctionType(IType returnType, IEnumerable<VariableDefinition> parameters)
            : base(returnType.Line, returnType.Column) // TODO use other line and column
        {
            ReturnType = returnType;
            Parameters = new List<VariableDefinition>(parameters);
        }
        
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}