using Seagull.AST;
using Seagull.AST.Expressions;
using Seagull.AST.Expressions.Binary;
using Seagull.AST.Expressions.Literals;
using Seagull.AST.Statements;
using Seagull.AST.Statements.Definitions;
using Seagull.AST.Types;
using Seagull.Errors;

namespace Seagull.Visitor
{
    public class AbstractVisitor<TR, TP> : IVisitor<TR, TP>
    {
        
        
        
		public virtual TR Visit(ProgramNode program, TP p) {
			
			foreach (NamespaceNode ns in program.Namespaces)
				ns.Accept(this, p);
			
			foreach (IDefinition def in program.Definitions)
				def.Accept(this, p);
			
			return default(TR);
		}
	
	
		
		public virtual TR Visit(ErrorType error, TP p)
		{
			return default(TR);
		}
	
	
	
	
	
		
		
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		/*														 */
		/*						  TYPES							 */
		/*														 */
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		
	
		
		public virtual TR Visit(ArrayType arrayType, TP p)
		{
			arrayType.TypeOf.Accept(this, p);
			return default(TR);
		}


		public virtual TR Visit(ByteType byteType, TP p)
		{
			return default(TR);
		}

		public virtual TR Visit(CharType charType, TP p)
		{
			return default(TR);
		}

		public virtual TR Visit(DoubleType doubleType, TP p)
		{
			return default(TR);
		}

		public virtual TR Visit(EnumType enumType, TP p)
		{
			foreach (EnumElementDefinition def in enumType.Elements)
				def.Accept(this, p);
			return default(TR);
		}


		public virtual TR Visit(FunctionType functionType, TP p)
		{
			functionType.ReturnType.Accept(this, p);
			foreach (VariableDefinition def in functionType.Parameters)
				def.Accept(this, p);
			return default(TR);
		}
	
		
		public virtual TR Visit(IntType intType, TP p)
		{
			return default(TR);
		}

		public virtual TR Visit(LongType longType, TP p)
		{
			return default(TR);
		}


		public virtual TR Visit(PointerType pointerType, TP p)
		{
			return default(TR);
		}


		public virtual TR Visit(StructType structType, TP p)
		{
			foreach (IDefinition def in structType.Fields)
				def.Accept(this, p);
			return default(TR);
		}
	
		
		public virtual TR Visit(VoidType voidType, TP p)
		{
			return default(TR);
		}
	
		
		public virtual TR Visit(StringType stringType, TP p)
		{
			return default(TR);
		}
		
		
		public virtual TR Visit(BooleanType booleanType, TP p)
		{
			return default(TR);
		}

		public virtual TR Visit(UnknownType unknown, TP p)
		{
			return default(TR);
		}


		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		/*														 */
		/*					   STATEMENTS						 */
		/*														 */
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		
		
		
		public virtual TR Visit(AssignmentNode assignment, TP p)
		{
			assignment.Left.Accept(this, p);
			assignment.Right.Accept(this, p);
			return default(TR);
		}

		public virtual TR Visit(BreakNode br, TP p)
		{
			return default(TR);
		}

		public virtual TR Visit(ContinueNode cont, TP p)
		{
			return default(TR);
		}

		public virtual TR Visit(ForeachLoopNode foreachLoop, TP p)
		{
			foreachLoop.Element.Accept(this, p);
			foreachLoop.Collection.Accept(this, p);
			foreach (IStatement st in foreachLoop.Statements)
				st.Accept(this, p);
			return default(TR);
		}

		public virtual TR Visit(ForLoopNode forLoop, TP p)
		{
			forLoop.Initialization.Accept(this, p);
			forLoop.Condition.Accept(this, p);
			forLoop.Increment.Accept(this, p);
			foreach (IStatement st in forLoop.Statements)
				st.Accept(this, p);
			return default(TR);
		}


		public virtual TR Visit(IfNode ifNode, TP p)
		{
			ifNode.Condition.Accept(this, p);
			foreach (IStatement st in ifNode.Then)
				st.Accept(this, p);
			foreach (IStatement st in ifNode.Else)
				st.Accept(this, p);
			return default(TR);
		}
		
		
		public virtual TR Visit(ReadNode read, TP p)
		{
			read.Expression.Accept(this, p);
			return default(TR);
		}
		
		
		public virtual TR Visit(ReturnNode returnNode, TP p)
		{
			returnNode.Value.Accept(this, p);
			return default(TR);
		}

		
		public virtual TR Visit(WhileLoopNode whileLoop, TP p)
		{
			whileLoop.Condition.Accept(this, p);
			foreach (IStatement st in whileLoop.Statements)
				st.Accept(this, p);
			return default(TR);
		}
	
		
		public virtual TR Visit(PrintNode print, TP p)
		{
			print.Expression.Accept(this, p);
			return default(TR);
		}


		public virtual TR Visit(MainFunctionDefinition mainFunctionDefinition, TP p)
		{
			return this.Visit((FunctionDefinition) mainFunctionDefinition, p);
		}

		public virtual TR Visit(NamespaceNode namespaceNode, TP p)
		{
			foreach (var def in namespaceNode.Definitions)
				def.Accept(this, p);
			return default(TR);
		}


		public virtual TR Visit(StructDefinition structDefinition, TP p)
		{
			structDefinition.Type.Accept(this, p);
			return default(TR);
		}

		public virtual TR Visit(VariableDefinition variableDefinition, TP p)
		{
			variableDefinition.Type.Accept(this, p);
			if (variableDefinition.Initialization != null)
				variableDefinition.Initialization.Accept(this, p);
			return default(TR);
		}


		public virtual TR Visit(EnumElementDefinition enumElementDefinition, TP p)
		{
			enumElementDefinition.Type.Accept(this, p);
			enumElementDefinition.Value.Accept(this, p);
			return default(TR);
		}

		public virtual TR Visit(FunctionDefinition functionDefinition, TP p)
		{
			functionDefinition.Type.Accept(this, p);
			foreach (IStatement st in functionDefinition.Statements)
				st.Accept(this, p);
			return default(TR);
		}

		public virtual TR Visit(DelegateDefinition delegateDefinition, TP p)
		{
			delegateDefinition.Type.Accept(this, p);
			return default(TR);
		}

		public virtual TR Visit(EnumDefinition enumDefinition, TP p)
		{
			enumDefinition.Type.Accept(this, p);
			return default(TR);
		}


		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		/*														 */
		/*					   EXPRESSIONS						 */
		/*														 */
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		
		
		
		public virtual TR Visit(ArithmeticNode arithmetic, TP p)
		{
			arithmetic.Left.Accept(this, p);
			arithmetic.Right.Accept(this, p);
			return default(TR);
		}
	
		
		public virtual TR Visit(ComparisonNode comparison, TP p)
		{
			comparison.Left.Accept(this, p);
			comparison.Right.Accept(this, p);
			return default(TR);
		}
	
		
		public virtual TR Visit(LogicalOperationNode logicalOperation, TP p)
		{
			logicalOperation.Left.Accept(this, p);
			logicalOperation.Right.Accept(this, p);
			return default(TR);
		}


		public virtual TR Visit(IncrementNode increment, TP p)
		{
			increment.Operand.Accept(this, p);
			return default(TR);
		}

		public virtual TR Visit(IndexingNode indexing, TP p)
		{
			indexing.Operand.Accept(this, p);
			indexing.Index.Accept(this, p);
			return default(TR);
		}
	
		
		public virtual TR Visit(AttributeAccessNode attributeAccess, TP p)
		{
			attributeAccess.Operand.Accept(this, p);
			return default(TR);
		}
	
		
		public virtual TR Visit(CastNode cast, TP p)
		{
			cast.TargetType.Accept(this, p);
			cast.Operand.Accept(this, p);
			return default(TR);
		}

		public virtual TR Visit(DefaultNode def, TP p)
		{
			def.Type.Accept(this, p);
			return default(TR);
		}


		public virtual TR Visit(NewNode newExpr, TP p)
		{
			return default(TR);
		}

		public virtual TR Visit(TernaryOperatorNode ternary, TP p)
		{
			ternary.Condition.Accept(this, p);
			ternary.ThenExpr.Accept(this, p);
			ternary.ElseExpr.Accept(this, p);
			return default(TR);
		}


		public virtual TR Visit(CharLiteral charLiteral, TP p)
		{
			charLiteral.Type.Accept(this, p);
			return default(TR);
		}
	
		
		public virtual TR Visit(DoubleLiteral doubleLiteral, TP p)
		{
			doubleLiteral.Type.Accept(this, p);
			return default(TR);
		}
	
		
		public virtual TR Visit(FunctionInvocation functionInvocation, TP p)
		{
			functionInvocation.Function.Accept(this, p);
			foreach (IExpression expr in functionInvocation.Arguments)
				expr.Accept(this, p);
			return default(TR);
		}
	
		
		public virtual TR Visit(IntLiteral intLiteral, TP p)
		{
			intLiteral.Type.Accept(this, p);
			return default(TR);
		}
	
		
		public virtual TR Visit(NegationNode negation, TP p)
		{
			negation.Operand.Accept(this, p);
			return default(TR);
		}
	
		
		public virtual TR Visit(UnaryMinusNode unaryMinus, TP p)
		{
			unaryMinus.Operand.Accept(this, p);
			return default(TR);
		}
	
		
		public virtual TR Visit(VariableNode variable, TP p)
		{
			return default(TR);
		}
		

		public virtual TR Visit(StringLiteral stringLiteral, TP p)
		{
			stringLiteral.Type.Accept(this, p);
			return default(TR);
		}

		public virtual TR Visit(BooleanLiteral booleanLiteral, TP p)
		{
			booleanLiteral.Type.Accept(this, p);
			return default(TR);
		}
		
		
		
		
    }
}