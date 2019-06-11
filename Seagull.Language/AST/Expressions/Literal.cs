namespace Seagull.Language.AST.Expressions
{
	public abstract class Literal<T> : AbstractExpression
	{
		public T Value { get; }

		public Literal(int line, int column, T value) : base(line, column)
		{
			Value = value;
		}


		public override string ToString()
		{
			return Value.ToString();
		}
	}
}