namespace Seagull.AST.Expressions.Literals
{
	public class DoubleLiteral : Literal<double>
	{
		public DoubleLiteral(int line, int column, double value)
			: base(line, column, value)
		{
		}
	}
}