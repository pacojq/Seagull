using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Expressions.Binary
{
	public class LogicalOperation : BinaryOperation
	{
		public LogicalOperation(string op, IExpression left, IExpression right) 
			: base(op, left, right)
		{
		}
		
		
		public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
		{
			return visitor.Visit(this, p);
		}
	}
}