using Seagull.AST.Types;
using Seagull.Visitor;

namespace Seagull.AST.Expressions.Literals
{
	public class IntLiteral : AbstractLiteral<int>
	{
		public IntLiteral(int line, int column, int value)
			: base(line, column, value)
		{
			Type = new IntType(line, column);
		}
		
		
		public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
		{
			return visitor.Visit(this, p);
		}
	}
}