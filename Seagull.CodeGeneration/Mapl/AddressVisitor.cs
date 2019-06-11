
using Seagull.Language.AST;
using Seagull.Language.AST.Expressions;
using Seagull.Language.AST.Types;
using Seagull.Language.AST.Types.Namespaces;
using Seagull.Language.Visitor;

namespace Seagull.CodeGeneration.Mapl
{
	public class AddressVisitor : CgVisitor<Void, Void>
	{
		private MaplCodeGenerator cg = MaplCodeGenerator.Instance;
		public ValueVisitor valueVisitor;
		
		
		// - - - - - - - - WE ONLY DEAL WITH L-VALUE IExpressionS - - - - - - - - //
	
	
		public override Void Visit(Variable variable, Void p)
		{
			IDefinition def = variable.Definition;		
		
			// Global
			if (def.Scope == 0) {
				variable.CgAddress = cg.Push("a", def.CgOffset);
			}
			// Local
			else {
				variable.CgAddress = cg.PushBp();
				variable.CgAddress += cg.Push("i", def.CgOffset);
				variable.CgAddress += cg.Add("i");
			}
			return null;
		}
	
	
		public override Void Visit(Indexing arrayAccess, Void p)
		{
			IExpression array = arrayAccess.Operand;
			IExpression index = arrayAccess.Index;
			IType typeOf = arrayAccess.Type;
		
			// First take the address of the whole array
			array.Accept(this, null);
			arrayAccess.CgAddress = array.CgAddress;
		
		
			// Now calculate the offset
			// offset = index * numberOfBytes
			index.Accept(valueVisitor, null);
			arrayAccess.CgAddress += index.CgValue;
		
			arrayAccess.CgAddress +=  index.Type.CgConvert(new IntType(0, 0));
			arrayAccess.CgAddress +=  cg.Push("i", typeOf.CgNumberOfBytes);
		
			arrayAccess.CgAddress += cg.Mul("i");
		
		
			// Now, add it all up
			arrayAccess.CgAddress += cg.Add("i");
		
			return null;
		}
	
	
		public override Void Visit(AttributeAccess attributeAccess, Void p)
		{
			IExpression s = attributeAccess.Operand;
		
			StructType t = (StructType) s.Type;
			int offset = t.FindDefinition(attributeAccess.AttributeName).CgOffset;
		
				s.Accept(this, null);
			attributeAccess.CgAddress = s.CgAddress;
			attributeAccess.CgAddress += cg.Push("i", offset);
			attributeAccess.CgAddress += cg.Add("i");
		
			return null;
		}

	}
}