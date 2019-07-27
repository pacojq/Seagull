using Seagull.Visitor;

namespace Seagull.AST.Expressions
{
	public class AttributeAccessNode : AbstractExpression
	{
		public IExpression Operand { get; }
		public string AttributeName { get; }

		
		public AttributeAccessNode(IExpression op, string attributeName)
			: base(op.Line, op.Column)
		{
			Operand = op;
			AttributeName = attributeName;
		}

		public override string ToString()
		{
			return $"{Operand}.{AttributeName}";
		}
		
		
		
		public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
		{
			return visitor.Visit(this, p);
		}
	}
}