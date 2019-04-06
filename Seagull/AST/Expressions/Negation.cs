namespace Seagull.AST.Expressions
{
	public class Negation : AbstractExpression
	{
		public IExpression Operand { get; }

		
		public Negation(int line, int column, IExpression op)
			: base(line, column)
		{
			Operand = op;
		}
	}
}