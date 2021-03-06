using Seagull.AST.Types;
using Seagull.Visitor;

namespace Seagull.AST.Expressions.Literals
{
	public class CharLiteral : AbstractLiteral<char>
	{
		public CharLiteral(int line, int column, char value)
			: base(line, column, value)
		{
			Type = new CharType(line, column);
		}
		
		
		public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
		{
			return visitor.Visit(this, p);
		}
	}
}