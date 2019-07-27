using Seagull.Visitor;

namespace Seagull.AST.Expressions
{
	public class VariableNode : AbstractExpression
	{
		
		public string Name { get; }
		public IDefinition Definition { get; set; }
		
		public VariableNode(int line, int column, string name) : base(line, column)
		{
			Name = name;
		}
		
		
		
		public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
		{
			return visitor.Visit(this, p);
		}
	}
}