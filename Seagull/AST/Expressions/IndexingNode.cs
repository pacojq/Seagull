using Seagull.Visitor;

namespace Seagull.AST.Expressions
{
	public class IndexingNode : AbstractExpression
	{
		public IExpression Operand { get; }
		public IExpression Index { get; }

		public IndexingNode(IExpression op, IExpression index)
			: base(op.Line, op.Column)
		{
			Operand = op;
			Index = index;
		}

		public override string ToString()
		{
			return $"{Operand}[{Index}]";
		}
		
		
		public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
		{
			return visitor.Visit(this, p);
		}
	}
}