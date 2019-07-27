using Seagull.AST;
using Seagull.AST.Expressions;
using Seagull.AST.Expressions.Binary;
using Seagull.AST.Expressions.Literals;
using Void = Seagull.Visitor.Void;

namespace Seagull.CodeGeneration.Mapl
{
	public class ValueVisitor : CgVisitor<Void, Void>
	{
		private MaplCodeGenerator cg = MaplCodeGenerator.Instance;
		public AddressVisitor addressVisitor;
	
	
	
		// WE ONLY DEAL WITH EXPRESSIONS //
	
	
		public override Void Visit(Arithmetic arithmetic, Void p)
		{
			arithmetic.Left.Accept(this, p);
			arithmetic.Right.Accept(this, p);		
		
			arithmetic.CgValue = cg.Arithmetic(arithmetic);
		
			return null;
		}

	
		public override Void Visit(Comparison comparison, Void p)
		{
			comparison.Left.Accept(this, p);
			comparison.Right.Accept(this, p);		
		
			comparison.CgValue = cg.Comparison(comparison);
		
			return null;
		}
	

		public override Void Visit(LogicalOperation logicalOperation, Void p)
		{
			logicalOperation.Left.Accept(this, p);
			logicalOperation.Right.Accept(this, p);
		
			logicalOperation.CgValue = cg.LogicalOperation(logicalOperation);
		
			return null;
		}
	

		public override Void Visit(Indexing indexing, Void p)
		{
			indexing.Accept(addressVisitor, null);
			indexing.CgValue = indexing.CgAddress;
		
			indexing.CgValue += cg.Load(indexing.Type);
		
			return null;
		}

		public override Void Visit(AttributeAccess attributeAccess, Void p)
		{
		
			attributeAccess.Accept(addressVisitor, null);
			attributeAccess.CgValue = attributeAccess.CgAddress;
		
			attributeAccess.CgValue += cg.Load(attributeAccess.Type);
		
		 	return null;
		}

		public override Void Visit(Cast cast, Void p)
		{
			IExpression operand = cast.Operand;
		
			operand.Accept(this, p);
			cast.CgValue = operand.CgValue;
			cast.CgValue += operand.Type.CgConvert(cast.TargetType);
		
			return null;
		}

	
	
		public override Void Visit(CharLiteral charLiteral, Void p)
		{
			charLiteral.CgValue = cg.Push(charLiteral.Type, charLiteral.Value);
			return null;
		}
	
		public override Void Visit(IntLiteral intLiteral, Void p)
		{
			intLiteral.CgValue = cg.Push(intLiteral.Type, intLiteral.Value);
			return null;
		}
	
		public override Void Visit(DoubleLiteral doubleLiteral, Void p)
		{
			doubleLiteral.CgValue = cg.Push(doubleLiteral.Type, doubleLiteral.Value);
			return null;
		}
	
	
	

		public override Void Visit(FunctionInvocation functionInvocation, Void p)
		{
		
			functionInvocation.CgValue = cg.Line(functionInvocation);
		
			foreach (IExpression arg in functionInvocation.Arguments)
			{
				arg.Accept(this, null);
				functionInvocation.CgValue += arg.CgValue;
			}
		
			functionInvocation.CgValue += cg.Call(functionInvocation);		
			return null;
		}

	

		public override Void Visit(Negation negation, Void p)
		{
		
			IExpression operand = negation.Operand;
			operand.Accept(this, null);
			negation.CgValue = operand.CgValue;
			negation.CgValue += cg.Not();
		
			return null;
		}
	

		public override Void Visit(UnaryMinus unaryMinus, Void p)
		{
			IType t = unaryMinus.Type;
		
			unaryMinus.CgValue = cg.Push(t, 0);
		
			unaryMinus.Operand.Accept(this, p);
			unaryMinus.CgValue += unaryMinus.Operand.CgValue;
		
			unaryMinus.CgValue += cg.Sub(t);
		
			return null;
		}

	
	
		public override Void Visit(Variable variable, Void p)
		{

			variable.Accept(addressVisitor, null);
			IDefinition def = variable.Definition;
		
			variable.CgValue = variable.CgAddress;
			variable.CgValue += cg.Load(def.Type);
		
			return null;
		}
	
	}
}