using Seagull.AST.Types;
using Seagull.Visitor;

namespace Seagull.AST.Expressions.Literals
{
	public class DoubleLiteral : AbstractLiteral<double>
	{
		public DoubleLiteral(int line, int column, double value)
			: base(line, column, value)
		{
			Type = new DoubleType(line, column);
		}
		
		
		public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
		{
			return visitor.Visit(this, p);
		}
	}
}