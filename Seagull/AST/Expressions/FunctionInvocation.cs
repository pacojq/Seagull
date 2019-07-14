using System.Collections.Generic;
using Seagull.Visitor;

namespace Seagull.AST.Expressions
{
	public class FunctionInvocation : AbstractExpression, IStatement
	{
		// Code generation
		public string CgExecute { get; set; }
		
		
		
		public Variable Function { get; }
		public IEnumerable<IExpression> Arguments { get; }
		
		public FunctionInvocation(Variable function, IEnumerable<IExpression> args)
			: base(function.Line, function.Column)
		{
			Function = function;
			Arguments = args;

			CgExecute = "CG-EXECUTE-PLACEHOLDER";
		}
		
		
		public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
		{
			return visitor.Visit(this, p);
		}

		
	}
}