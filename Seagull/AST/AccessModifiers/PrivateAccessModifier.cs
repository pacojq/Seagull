using Seagull.Visitor;

namespace Seagull.AST.AccessModifiers
{
	public class PrivateAccessModifier : AbstractAstNode, IAccessModifier
	{
		public PrivateAccessModifier(int line, int column) : base(line, column)
		{
		}

		public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
		{
			throw new System.NotImplementedException();
		}
	}
}