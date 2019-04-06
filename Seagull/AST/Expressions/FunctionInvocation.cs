using System.Collections.Generic;

namespace Seagull.AST.Expressions
{
	public class FunctionInvocation : AbstractExpression, IStatement
	{
		public Variable Function { get; }
		public IEnumerable<IExpression> Arguments { get; }
		
		public FunctionInvocation(Variable function, IEnumerable<IExpression> args)
			: base(function.Line, function.Column)
		{
			Function = function;
			Arguments = args;
		}
	}
}