using Seagull.Language.AST.Types;
using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Expressions.Literals
{
	public class DoubleLiteral : Literal<double>
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