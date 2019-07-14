namespace Seagull.AST.Expressions
{
	public abstract class AbstractExpression : AbstractAstNode, IExpression
	{
		
		public IType Type { get; set; }
		public bool LValue { get; set; }
		
		
		// Code generation
		
		public string CgAddress { get; set; }
		public string CgValue { get; set; }


		public AbstractExpression(int line, int column) : base(line, column)
		{
			LValue = false;
			Type = null;

			CgAddress = "CG-ADDRESS-PLACEHOLDER";
			CgValue = "CG-VALUE-PLACEHOLDER";
		}

	}
}