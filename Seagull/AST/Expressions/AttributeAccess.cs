namespace Seagull.AST.Expressions
{
	public class AttributeAccess : AbstractExpression
	{
		public IExpression Operand { get; }
		public string AttributeName { get; }

		
		public AttributeAccess(IExpression op, string attributeName)
			: base(op.Line, op.Column)
		{
			Operand = op;
			AttributeName = attributeName;
		}

		public override string ToString()
		{
			return $"{Operand}.{AttributeName}";
		}
	}
}