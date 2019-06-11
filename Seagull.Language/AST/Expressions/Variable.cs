using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Expressions
{
	public class Variable : AbstractExpression
	{
		
		public string Name { get; }
		public IDefinition Definition { get; set; }
		
		public Variable(int line, int column, string name) : base(line, column)
		{
			Name = name;
		}
		
		
		
		public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
		{
			return visitor.Visit(this, p);
		}
	}
}