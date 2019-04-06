namespace Seagull.AST.Expressions.Binary
{
	public class Comparison : BinaryOperation
	{
		public Comparison(string op, IExpression left, IExpression right) 
			: base(op, left, right)
		{
		}
	}
}