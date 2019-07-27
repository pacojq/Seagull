namespace Seagull.AST.Expressions
{
	public abstract class AbstractLiteral<T> : AbstractExpression
	{
		public T Value { get; }

		public AbstractLiteral(int line, int column, T value) : base(line, column)
		{
			Value = value;
		}


		public override string ToString()
		{
			return Value.ToString();
		}
	}
}