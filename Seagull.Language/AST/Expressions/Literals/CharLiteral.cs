using Seagull.Language.AST.Types;
using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Expressions.Literals
{
	public class CharLiteral : Literal<char>
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