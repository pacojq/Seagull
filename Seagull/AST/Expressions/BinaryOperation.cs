namespace Seagull.AST.Expressions
{
	public abstract class BinaryOperation : AbstractExpression
	{
		
		public string Operator { get; }
		public IExpression Left { get; }
		public IExpression Right { get; }
		
		
		protected BinaryOperation(string op, IExpression left, IExpression right) 
			: base(left.Line, left.Column)
		{
			Operator = op;
			Left = left;
			Right = right;
		}
		
		
		public override string ToString()
		{
			return $"{Left} {Operator} {Right}";
		}
	}
}