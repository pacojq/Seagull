using Seagull.Visitor;

namespace Seagull.AST.Expressions.Literals
{
	public class DoubleLiteral : Literal<double>
	{
		public DoubleLiteral(int line, int column, double value)
			: base(line, column, value)
		{
		}
		
		
		public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
		{
			return visitor.Visit(this, p);
		}
	}
}