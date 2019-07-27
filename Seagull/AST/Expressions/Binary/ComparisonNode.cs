using Seagull.Visitor;

namespace Seagull.AST.Expressions.Binary
{
	public class ComparisonNode : BinaryOperation
	{
		public ComparisonNode(string op, IExpression left, IExpression right) 
			: base(op, left, right)
		{
		}
		
		public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
		{
			return visitor.Visit(this, p);
		}
	}
}