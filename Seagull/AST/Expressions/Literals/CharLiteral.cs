namespace Seagull.AST.Expressions.Literals
{
	public class CharLiteral : Literal<char>
	{
		public CharLiteral(int line, int column, char value)
			: base(line, column, value)
		{
		}
	}
}