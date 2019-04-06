namespace Seagull.AST.Expressions.Binary
{
	public class Arithmetic : BinaryOperation
	{
		public Arithmetic(string op, IExpression left, IExpression right) 
			: base(op, left, right)
		{
		}
	}
}