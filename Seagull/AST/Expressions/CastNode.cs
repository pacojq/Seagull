using Seagull.Visitor;

namespace Seagull.AST.Expressions
{
	public class CastNode : AbstractExpression
	{
		public IType TargetType { get; internal set; }
		public IExpression Operand { get; }
		
		public CastNode(int line, int column, IType targetType, IExpression op)
			: base(line, column)
		{
			TargetType = targetType;
			Operand = op;
		}


		public override string ToString()
		{
			return $"({TargetType}) {Operand}";
		}
		
		
		public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
		{
			return visitor.Visit(this, p);
		}
	}
}