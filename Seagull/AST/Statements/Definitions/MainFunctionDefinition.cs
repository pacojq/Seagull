using System.Collections.Generic;
using Seagull.Visitor;

namespace Seagull.AST.Statements.Definitions
{
	public class MainFunctionDefinition : FunctionDefinition
	{
		public MainFunctionDefinition(int line, int column, IType functionType, IEnumerable<IStatement> statements) 
			: base(line, column, "main", functionType, statements)
		{
		}
		
		
		public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
		{
			return visitor.Visit(this, p);
		}
	}
}