using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Expressions.Increments
{
	public class Increment : AbstractExpression, IIncrement
	{
		public bool IsPrefixIncrement { get; }
		
		public IExpression Operand { get; }
		
		
		public string CgExecute { get; set; }
		
		
		public Increment(int line, int column, bool isPrefix, IExpression operand) : base(line, column)
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