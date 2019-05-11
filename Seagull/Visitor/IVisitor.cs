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
        TR Visit(Program program, TP p);
	
		TR Visit(ErrorType error, TP p);
		
		
		
		
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		/*														 */
		/*						  TYPES							 */
		/*														 */
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		
		TR Visit(ArrayType arrayType, TP p);
		TR Visit(CharType charType, TP p);
		TR Visit(DoubleType doubleType, TP p);
		TR Visit(FunctionType functionType, TP p);
		TR Visit(IntType intType, TP p);
		TR Visit(StructType structType, TP p);
		TR Visit(VoidType voidType, TP p);
		TR Visit(StringType stringType, TP p);
		TR Visit(BooleanType booleanType, TP p);


		TR Visit(UnknownType unknown, TP p);
		
		
		
		
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		/*														 */
		/*					   STATEMENTS						 */
		/*														 */
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		
		TR Visit(Assignment assignment, TP p);
		TR Visit(IfStatement ifStatement, TP p);
		TR Visit(Read read, TP p);
		TR Visit(Return returnStmnt, TP p);
		TR Visit(WhileLoop whileLoop, TP p);
		TR Visit(Print print, TP p);


		// Definitions
		TR Visit(NamespaceDefinition namespaceDefinition, TP p);
		TR Visit(StructDefinition structDefinition, TP p);
		TR Visit(VariableDefinition variableDefinition, TP p);
		TR Visit(FunctionDefinition functionDefinition, TP p);
		
		TR Visit(DelegateDefinition delegateDefinition, TP p);
		
		
		
		
		
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		/*														 */
		/*					   EXPRESSIONS						 */
		/*														 */
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		
		TR Visit(Arithmetic arithmetic, TP p);
		TR Visit(Comparison comparison, TP p);
		TR Visit(LogicalOperation logicalOperation, TP p);
		TR Visit(Indexing indexing, TP p);
		TR Visit(AttributeAccess attributeAccess, TP p);
		TR Visit(Cast cast, TP p);
		TR Visit(New newExpr, TP p);
		TR Visit(CharLiteral charLiteral, TP p);
		TR Visit(DoubleLiteral doubleLiteral, TP p);
		TR Visit(FunctionInvocation functionInvocation, TP p);
		TR Visit(IntLiteral intLiteral, TP p);
		TR Visit(Negation negation, TP p);
		TR Visit(UnaryMinus unaryMinus, TP p);
		TR Visit(Variable variable, TP p);

		TR Visit(StringLiteral stringLiteral, TP p);
		TR Visit(BooleanLiteral booleanLiteral, TP p);
		
    }
}