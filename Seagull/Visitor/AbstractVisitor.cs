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
        
        
        
		public TR Visit(Program program, TP p){
			foreach (IDefinition def in program.Definitions)
				def.Accept(this, p);
			return default(TR);
		}
	
	
		
		public TR Visit(ErrorType error, TP p)
		{
			return default(TR);
		}
	
	
	
	
	
		
		
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		/*														 */
		/*						  TYPES							 */
		/*														 */
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		
	
		
		public TR Visit(ArrayType arrayType, TP p)
		{
			arrayType.TypeOf.Accept(this, p);
			return default(TR);
		}
	
		
		public TR Visit(CharType charType, TP p)
		{
			return default(TR);
		}
	
		
		public TR Visit(DoubleType doubleType, TP p)
		{
			return default(TR);
		}
	
		
		public TR Visit(FunctionType functionType, TP p)
		{
			functionType.ReturnType.Accept(this, p);
			foreach (VariableDefinition def in functionType.Parameters)
				def.Accept(this, p);
			return default(TR);
		}
	
		
		public TR Visit(IntType intType, TP p)
		{
			return default(TR);
		}
	
		
		public TR Visit(StructType structType, TP p)
		{
			foreach (VariableDefinition def in structType.Fields)
				def.Accept(this, p);
			return default(TR);
		}
	
		
		public TR Visit(VoidType voidType, TP p)
		{
			return default(TR);
		}
	
		
		
		
		
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		/*														 */
		/*					   STATEMENTS						 */
		/*														 */
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		
		
		
		public TR Visit(Assignment assignment, TP p)
		{
			assignment.Left.Accept(this, p);
			assignment.Right.Accept(this, p);
			return default(TR);
		}
	
		
		public TR Visit(FunctionDefinition functionDefinition, TP p)
		{
			functionDefinition.Type.Accept(this, p);
			foreach (IStatement st in functionDefinition.Statements)
				st.Accept(this, p);
			return default(TR);
		}
	
		
		public TR Visit(IfStatement ifStatement, TP p)
		{
			ifStatement.Condition.Accept(this, p);
			foreach (IStatement st in ifStatement.Then)
				st.Accept(this, p);
			foreach (IStatement st in ifStatement.Else)
				st.Accept(this, p);
			return default(TR);
		}
		
		
		public TR Visit(Read read, TP p)
		{
			read.Expression.Accept(this, p);
			return default(TR);
		}
		
		
		public TR Visit(Return returnStmnt, TP p)
		{
			returnStmnt.Value.Accept(this, p);
			return default(TR);
		}
	
		
		public TR Visit(VariableDefinition variableDefinition, TP p)
		{
			variableDefinition.Type.Accept(this, p);
			return default(TR);
		}
	
		
		public TR Visit(WhileLoop whileLoop, TP p)
		{
			whileLoop.Condition.Accept(this, p);
			foreach (IStatement st in whileLoop.Statements)
				st.Accept(this, p);
			return default(TR);
		}
	
		
		public TR Visit(Print print, TP p)
		{
			print.Expression.Accept(this, p);
			return default(TR);
		}
		
		
		
		
		
		
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		/*														 */
		/*					   EXPRESSIONS						 */
		/*														 */
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		
		
		
		public TR Visit(Arithmetic arithmetic, TP p)
		{
			arithmetic.Left.Accept(this, p);
			arithmetic.Right.Accept(this, p);
			return default(TR);
		}
	
		
		public TR Visit(Comparison comparison, TP p)
		{
			comparison.Left.Accept(this, p);
			comparison.Right.Accept(this, p);
			return default(TR);
		}
	
		
		public TR Visit(LogicalOperation logicalOperation, TP p)
		{
			logicalOperation.Left.Accept(this, p);
			logicalOperation.Right.Accept(this, p);
			return default(TR);
		}
	
		
		public TR Visit(Indexing indexing, TP p)
		{
			indexing.Operand.Accept(this, p);
			indexing.Index.Accept(this, p);
			return default(TR);
		}
	
		
		public TR Visit(AttributeAccess attributeAccess, TP p)
		{
			attributeAccess.Operand.Accept(this, p);
			return default(TR);
		}
	
		
		public TR Visit(Cast cast, TP p)
		{
			cast.TargetType.Accept(this, p);
			cast.Operand.Accept(this, p);
			return default(TR);
		}
	
		
		public TR Visit(CharLiteral charLiteral, TP p)
		{
			return default(TR);
		}
	
		
		public TR Visit(DoubleLiteral doubleLiteral, TP p)
		{
			return default(TR);
		}
	
		
		public TR Visit(FunctionInvocation functionInvocation, TP p)
		{
			functionInvocation.Function.Accept(this, p);
			foreach (IExpression expr in functionInvocation.Arguments)
				expr.Accept(this, p);
			return default(TR);
		}
	
		
		public TR Visit(IntLiteral intLiteral, TP p)
		{
			return default(TR);
		}
	
		
		public TR Visit(Negation negation, TP p)
		{
			negation.Operand.Accept(this, p);
			return default(TR);
		}
	
		
		public TR Visit(UnaryMinus unaryMinus, TP p)
		{
			unaryMinus.Operand.Accept(this, p);
			return default(TR);
		}
	
		
		public TR Visit(Variable variable, TP p)
		{
			return default(TR);
		}
        
		
        
    }
}