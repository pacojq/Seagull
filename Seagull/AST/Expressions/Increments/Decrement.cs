using Seagull.Visitor;

namespace Seagull.AST.Expressions.Increments
{
	public class Decrement : AbstractExpression, IIncrement
	{
		public bool IsPrefixIncrement { get; }
		
		public IExpression Operand { get; }
		
		
		public string CgExecute { get; set; }
		
		
		public Decrement(int line, int column, bool isPrefix, IExpression operand) : base(line, column)
		{
			IsPrefixIncrement = isPrefix;
			Operand = operand;
		}

		public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
		{
			throw new System.NotImplementedException();
		}

	}
}