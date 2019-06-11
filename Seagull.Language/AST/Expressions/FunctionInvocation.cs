using System.Collections.Generic;
using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Expressions
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
		
		
		public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
		{
			return visitor.Visit(this, p);
		}
	}
}