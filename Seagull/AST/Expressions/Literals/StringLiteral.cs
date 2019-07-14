using Seagull.AST.Types;
using Seagull.Visitor;

namespace Seagull.AST.Expressions.Literals
{
	public class StringLiteral : Literal<string>
	{
		public StringLiteral(int line, int column, string value)
			: base(line, column, value)
		{
			Type = new StringType(line, column);
		}
		
		
		public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
		{
			return visitor.Visit(this, p);
		}
	}
}