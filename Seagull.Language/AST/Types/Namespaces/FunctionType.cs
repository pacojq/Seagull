using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seagull.Language.AST.Types.Namespaces;
using Seagull.Language.AST.Statements.Definitions;
using Seagull.Language.Errors;
using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Types
{
    public class FunctionType : AbstractType
    {
        
        public override int CgNumberOfBytes => ReturnType.CgNumberOfBytes;
        
        
        public IType ReturnType { get; internal set; }

        private readonly List<VariableDefinition> _params;
        public IEnumerable<VariableDefinition> Parameters => _params;
      
        
        
        public FunctionType(IType returnType, IEnumerable<VariableDefinition> parameters)
            : base(returnType.Line, returnType.Column) // TODO use other line and column
        {
            ReturnType = returnType;
            _params = new List<VariableDefinition>(parameters);
        }
        
        
        
        public override IType TypeCheckParentheses(int line, int column, IEnumerable<IType> arguments)
        {
            var args = arguments.ToList();
		
            if (args.Count != _params.Count)
            {
                return ErrorHandler.Instance.RaiseError(
                    line, column,
                    $"Invalid number of arguments in function call. Actual: {args.Count}; Expected: {_params.Count}");
            }	
            
            for (int i = 0; i < args.Count; i ++)
            {
                IType arg = args[i];
                if (arg is ErrorType)
                    return arg;
                
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


        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            
            str.Append("(");

            if (_params.Count > 0)
                str.Append(_params[0].Type.ToString());
            for (int i = 1; i < _params.Count; i ++)
                str.Append(_params[i].Type.ToString());
            
            str.Append(") -> ");

            str.Append(ReturnType.ToString());
            
            return str.ToString();
        }

        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }

        
    }
}