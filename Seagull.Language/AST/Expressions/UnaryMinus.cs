using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Expressions
{
	public class UnaryMinus : AbstractExpression
	{
		public IExpression Operand { get; }

		
		public UnaryMinus(int line, int column, IExpression op)
			: base(line, column)
		{
			Operand = op;
		}
		
		
		public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
		{
			return visitor.Visit(this, p);
		}
	}
}