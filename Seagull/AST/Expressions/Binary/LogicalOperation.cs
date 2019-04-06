namespace Seagull.AST.Expressions.Binary
{
	public class LogicalOperation : BinaryOperation
	{
		public LogicalOperation(string op, IExpression left, IExpression right) 
			: base(op, left, right)
		{
		}
	}
}