namespace Seagull.AST.Expressions
{
	public class UnaryMinus : AbstractExpression
	{
		public IExpression Operand { get; }

		
		public UnaryMinus(int line, int column, IExpression op)
			: base(line, column)
		{
			Operand = op;
		}
	}
}