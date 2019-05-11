using System;
using System.Collections.Generic;
using System.Linq;
using Seagull.AST.Statements.Definitions;
using Seagull.Errors;
using Seagull.Visitor;

namespace Seagull.AST.Types
{
    public class FunctionType : AbstractType
    {
        
        public override int NumberOfBytes => ReturnType.NumberOfBytes;
        
        
        public IType ReturnType { get; internal set; }

        private readonly List<VariableDefinition> _params;
        public IEnumerable<VariableDefinition> Parameters => _params;
      
        
        
        public FunctionType(IType returnType, IEnumerable<VariableDefinition> parameters)
            : base(returnType.Line, returnType.Column) // TODO use other line and column
        {
            ReturnType = returnType;
            _params = new List<VariableDefinition>(parameters);
        }
        
        
        
        public override IType ParenthesesOperator(int line, int column, IEnumerable<IType> arguments)
        {
            var args = arguments.ToList();
		
            if (args.Count != _params.Count) {
                return ErrorHandler.Instance.RaiseError(
                    line, column,
                    $"Invalid number of arguments in function call. Actual: {args.Count}; Expected: {_params.Count}");
            }		
            for (int i = 0; i < args.Count; i ++) {
			
                IType arg = args[i];
                IType param = _params[i].Type;
                if (!arg.IsEquivalent(param))
                {
                    return ErrorHandler.Instance.RaiseError(
                        line, column,
                        $"Invalid argument type in function call. Actual: {arg}; Expected: {param}");
                }
            }
            return this.ReturnType;
        }
        
        
        
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}