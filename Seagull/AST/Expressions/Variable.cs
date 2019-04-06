namespace Seagull.AST.Expressions
{
	public class Variable : AbstractExpression
	{
		
		public string Name { get; }
		public IDefinition Definition { get; set; }
		
		public Variable(int line, int column, string name) : base(line, column)
		{
			Name = name;
		}
	}
}