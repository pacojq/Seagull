using Seagull.Language.Visitor;

namespace Seagull.Language.AST.AccessModifiers
{
	public class PublicAccessModifier : AbstractAstNode, IAccessModifier
	{
		public PublicAccessModifier(int line, int column) : base(line, column)
		{
		}

		public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
		{
			throw new System.NotImplementedException();
		}
	}
}