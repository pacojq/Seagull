using Seagull.Visitor;

namespace Seagull.AST.AccessModifiers
{
	public class ProtectedAccessModifier : AbstractAstNode, IAccessModifier
	{
		public ProtectedAccessModifier(int line, int column) : base(line, column)
		{
		}

		public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
		{
			throw new System.NotImplementedException();
		}
	}
}