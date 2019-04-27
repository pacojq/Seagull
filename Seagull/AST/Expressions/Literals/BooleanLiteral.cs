using Seagull.Visitor;

namespace Seagull.AST.Expressions.Literals
{
	public class BooleanLiteral : Literal<bool>
	{
		public BooleanLiteral(int line, int column, bool value)
			: base(line, column, value)
		{
		}
		
		
		public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
		{
			return visitor.Visit(this, p);
		}
	}
}