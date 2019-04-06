namespace Seagull.AST.Expressions.Literals
{
	public class IntLiteral : Literal<int>
	{
		public IntLiteral(int line, int column, int value)
			: base(line, column, value)
		{
		}
	}
}