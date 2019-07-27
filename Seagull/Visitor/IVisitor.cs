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
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TR">Param type (inherited attributes)</typeparam>
    /// <typeparam name="TP">Return type (synthesized attributes)</typeparam>
    public interface IVisitor<TR, TP>
    {
        TR Visit(ProgramNode program, TP p);
	
		TR Visit(ErrorType error, TP p);
		
		
		
		
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		/*														 */
		/*						  TYPES							 */
		/*														 */
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		
		TR Visit(ArrayType arrayType, TP p);
		TR Visit(BooleanType booleanType, TP p);
		TR Visit(ByteType byteType, TP p);
		TR Visit(CharType charType, TP p);
		TR Visit(DoubleType doubleType, TP p);
		TR Visit(EnumType enumType, TP p);
		TR Visit(FunctionType functionType, TP p);
		TR Visit(IntType intType, TP p);
		TR Visit(LongType longType, TP p);
		TR Visit(PointerType pointerType, TP p);
		TR Visit(StringType stringType, TP p);
		TR Visit(StructType structType, TP p);
		TR Visit(VoidType voidType, TP p);


		TR Visit(UnknownType unknown, TP p);
		
		
		
		
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		/*														 */
		/*					   STATEMENTS						 */
		/*														 */
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		
		TR Visit(AssignmentNode assignment, TP p);
		TR Visit(BreakNode br, TP p);
		TR Visit(ContinueNode cont, TP p);
		TR Visit(ForeachLoopNode foreachLoop, TP p);
		TR Visit(ForLoopNode forLoop, TP p);
		TR Visit(IfNode ifNode, TP p);
		TR Visit(PrintNode print, TP p);
		TR Visit(ReadNode read, TP p);
		TR Visit(ReturnNode ret, TP p);
		TR Visit(WhileLoopNode whileLoop, TP p);


		// Definitions //
		TR Visit(DelegateDefinition delegateDefinition, TP p);
		TR Visit(EnumDefinition enumDefinition, TP p);
		TR Visit(EnumElementDefinition enumElementDefinition, TP p);
		TR Visit(FunctionDefinition functionDefinition, TP p);
		TR Visit(MainFunctionDefinition mainFunctionDefinition, TP p);
		TR Visit(NamespaceNode namespaceNode, TP p);
		TR Visit(StructDefinition structDefinition, TP p);
		TR Visit(VariableDefinition variableDefinition, TP p);
		
		
		
		
		
		
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		/*														 */
		/*					   EXPRESSIONS						 */
		/*														 */
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		
		
		// Binary
		TR Visit(ArithmeticNode arithmetic, TP p);
		TR Visit(ComparisonNode comparison, TP p);
		TR Visit(LogicalOperationNode logicalOperation, TP p);
		
		
		// Literals
		TR Visit(BooleanLiteral booleanLiteral, TP p);
		TR Visit(CharLiteral charLiteral, TP p);
		TR Visit(DoubleLiteral doubleLiteral, TP p);
		TR Visit(IntLiteral intLiteral, TP p);
		TR Visit(StringLiteral stringLiteral, TP p);
		
		
		// All expressions
		TR Visit(AttributeAccessNode attributeAccess, TP p);
		TR Visit(CastNode cast, TP p);
		TR Visit(DefaultNode def, TP p);
		TR Visit(FunctionInvocation functionInvocation, TP p);
		TR Visit(IncrementNode increment, TP p);
		TR Visit(IndexingNode indexing, TP p);
		TR Visit(NegationNode negation, TP p);
		TR Visit(NewNode newExpr, TP p);
		TR Visit(TernaryOperatorNode ternary, TP p);
		TR Visit(UnaryMinusNode unaryMinus, TP p);
		TR Visit(VariableNode variable, TP p);


		
    }
}