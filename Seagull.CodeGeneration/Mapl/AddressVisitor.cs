
using Seagull.Language.Visitor;

namespace Seagull.CodeGeneration.Mapl
{
	public class AddressVisitor : CgVisitor<Void, Void>
	{
		private MaplCodeGenerator cg = MaplCodeGenerator.Instance;
		public ValueVisitor valueVisitor;
	}
}