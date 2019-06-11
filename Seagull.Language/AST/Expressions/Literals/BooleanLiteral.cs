using Seagull.Language.AST.Types;
using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Expressions.Literals
{
	public class BooleanLiteral : Literal<bool>
	{
		public BooleanLiteral(int line, int column, bool value)
			: base(line, column, value)
		{
			Type = new BooleanType(line, column);
		}
		
		
		public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
		{
			return visitor.Visit(this, p);
		}
	}
}