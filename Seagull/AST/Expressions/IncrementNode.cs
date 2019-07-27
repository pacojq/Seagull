using Seagull.Visitor;

namespace Seagull.AST.Expressions
{
	public class IncrementNode : AbstractExpression, IStatement
	{
		public bool IsPrefixIncrement { get; }
		
		public bool IsPositive { get; }
		
		public IExpression Operand { get; }
		
		
		public string CgExecute { get; set; }
		
		
		public IncrementNode(int line, int column, bool isPrefix, bool isPositive, IExpression operand) : base(line, column)
		{
			IsPrefixIncrement = isPrefix;
			IsPositive = isPositive;
			Operand = operand;
		}

		public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
		{
			return visitor.Visit(this, p);
		}

	}
}