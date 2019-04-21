using Seagull.Visitor;

namespace Seagull.AST.Expressions.Literals
{
	public class CharLiteral : Literal<char>
	{
		public CharLiteral(int line, int column, char value)
			: base(line, column, value)
		{
		}
		
		
		public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
		{
			return visitor.Visit(this, p);
		}
	}
}