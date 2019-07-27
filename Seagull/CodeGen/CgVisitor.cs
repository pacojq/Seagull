using System;
using Seagull.AST;
using Seagull.AST.Expressions;
using Seagull.AST.Expressions.Binary;
using Seagull.AST.Expressions.Literals;
using Seagull.AST.Statements;
using Seagull.AST.Statements.Definitions;
using Seagull.AST.Types;
using Seagull.Errors;
using Seagull.Visitor;

namespace Seagull.CodeGeneration
{
    public class CgVisitor<TR, TP> : IVisitor<TR, TP>
    {
        
        private string GetMsg(IAstNode node)
        {
            return $"[{node.Line} : {node.Column}] - {this.GetType().Name} should not visit {node.ToString()}";
        }
        
        
        
        
        public virtual TR Visit(Program program, TP p)
        {
            throw new InvalidOperationException(GetMsg(program));
        }

        public virtual TR Visit(ErrorType error, TP p)
        {
            throw new InvalidOperationException(GetMsg(error));
        }

        public virtual TR Visit(ArrayType arrayType, TP p)
        {
            throw new InvalidOperationException(GetMsg(arrayType));
        }

        public virtual TR Visit(BooleanType booleanType, TP p)
        {
            throw new InvalidOperationException(GetMsg(booleanType));
        }

        public virtual TR Visit(ByteType byteType, TP p)
        {
            throw new InvalidOperationException(GetMsg(byteType));
        }

        public virtual TR Visit(CharType charType, TP p)
        {
            throw new InvalidOperationException(GetMsg(charType));
        }

        public virtual TR Visit(DoubleType doubleType, TP p)
        {
            throw new InvalidOperationException(GetMsg(doubleType));
        }

        public virtual TR Visit(EnumType enumType, TP p)
        {
            throw new InvalidOperationException(GetMsg(enumType));
        }

        public virtual TR Visit(FunctionType functionType, TP p)
        {
            throw new InvalidOperationException(GetMsg(functionType));
        }

        public virtual TR Visit(IntType intType, TP p)
        {
            throw new InvalidOperationException(GetMsg(intType));
        }

        public virtual TR Visit(LongType longType, TP p)
        {
            throw new InvalidOperationException(GetMsg(longType));
        }

        public virtual TR Visit(PointerType pointerType, TP p)
        {
            throw new InvalidOperationException(GetMsg(pointerType));
        }

        public virtual TR Visit(StringType stringType, TP p)
        {
            throw new InvalidOperationException(GetMsg(stringType));
        }

        public virtual TR Visit(StructType structType, TP p)
        {
            throw new InvalidOperationException(GetMsg(structType));
        }

        public virtual TR Visit(VoidType voidType, TP p)
        {
            throw new InvalidOperationException(GetMsg(voidType));
        }

        public virtual TR Visit(UnknownType unknown, TP p)
        {
            throw new InvalidOperationException(GetMsg(unknown));
        }

        public virtual TR Visit(Assignment assignment, TP p)
        {
            throw new InvalidOperationException(GetMsg(assignment));
        }

        public virtual TR Visit(Break br, TP p)
        {
            throw new InvalidOperationException(GetMsg(br));
        }

        public virtual TR Visit(Continue cont, TP p)
        {
            throw new InvalidOperationException(GetMsg(cont));
        }

        public virtual TR Visit(ForeachLoop foreachLoop, TP p)
        {
            throw new InvalidOperationException(GetMsg(foreachLoop));
        }

        public virtual TR Visit(ForLoop forLoop, TP p)
        {
            throw new InvalidOperationException(GetMsg(forLoop));
        }

        public virtual TR Visit(IfStatement ifStatement, TP p)
        {
            throw new InvalidOperationException(GetMsg(ifStatement));
        }

        public virtual TR Visit(Print print, TP p)
        {
            throw new InvalidOperationException(GetMsg(print));
        }

        public virtual TR Visit(Read read, TP p)
        {
            throw new InvalidOperationException(GetMsg(read));
        }

        public virtual TR Visit(Return ret, TP p)
        {
            throw new InvalidOperationException(GetMsg(ret));
        }

        public virtual TR Visit(WhileLoop whileLoop, TP p)
        {
            throw new InvalidOperationException(GetMsg(whileLoop));
        }

        public virtual TR Visit(DelegateDefinition delegateDefinition, TP p)
        {
            throw new InvalidOperationException(GetMsg(delegateDefinition));
        }

        public virtual TR Visit(EnumDefinition enumDefinition, TP p)
        {
            throw new InvalidOperationException(GetMsg(enumDefinition));
        }

        public virtual TR Visit(EnumElementDefinition enumElementDefinition, TP p)
        {
            throw new InvalidOperationException(GetMsg(enumElementDefinition));
        }

        public virtual TR Visit(FunctionDefinition functionDefinition, TP p)
        {
            throw new InvalidOperationException(GetMsg(functionDefinition));
        }

        public TR Visit(MainFunctionDefinition mainFunctionDefinition, TP p)
        {
            return this.Visit((FunctionDefinition) mainFunctionDefinition, p);
        }

        public virtual TR Visit(NamespaceNode namespaceNode, TP p)
        {
            throw new InvalidOperationException(GetMsg(namespaceNode));
        }

        public virtual TR Visit(StructDefinition structDefinition, TP p)
        {
            throw new InvalidOperationException(GetMsg(structDefinition));
        }

        public virtual TR Visit(VariableDefinition variableDefinition, TP p)
        {
            throw new InvalidOperationException(GetMsg(variableDefinition));
        }

        public virtual TR Visit(Arithmetic arithmetic, TP p)
        {
            throw new InvalidOperationException(GetMsg(arithmetic));
        }

        public virtual TR Visit(Comparison comparison, TP p)
        {
            throw new InvalidOperationException(GetMsg(comparison));
        }

        public virtual TR Visit(LogicalOperation logicalOperation, TP p)
        {
            throw new InvalidOperationException(GetMsg(logicalOperation));
        }

        public virtual TR Visit(BooleanLiteral booleanLiteral, TP p)
        {
            throw new InvalidOperationException(GetMsg(booleanLiteral));
        }

        public virtual TR Visit(CharLiteral charLiteral, TP p)
        {
            throw new InvalidOperationException(GetMsg(charLiteral));
        }

        public virtual TR Visit(DoubleLiteral doubleLiteral, TP p)
        {
            throw new InvalidOperationException(GetMsg(doubleLiteral));
        }

        public virtual TR Visit(IntLiteral intLiteral, TP p)
        {
            throw new InvalidOperationException(GetMsg(intLiteral));
        }

        public virtual TR Visit(StringLiteral stringLiteral, TP p)
        {
            throw new InvalidOperationException(GetMsg(stringLiteral));
        }

        public virtual TR Visit(AttributeAccess attributeAccess, TP p)
        {
            throw new InvalidOperationException(GetMsg(attributeAccess));
        }

        public virtual TR Visit(Cast cast, TP p)
        {
            throw new InvalidOperationException(GetMsg(cast));
        }

        public virtual TR Visit(Default def, TP p)
        {
            throw new InvalidOperationException(GetMsg(def));
        }

        public virtual TR Visit(FunctionInvocation functionInvocation, TP p)
        {
            throw new InvalidOperationException(GetMsg(functionInvocation));
        }

        public TR Visit(Increment increment, TP p)
        {
            throw new InvalidOperationException(GetMsg(increment));
        }

        public virtual TR Visit(Indexing indexing, TP p)
        {
            throw new InvalidOperationException(GetMsg(indexing));
        }

        public virtual TR Visit(Negation negation, TP p)
        {
            throw new InvalidOperationException(GetMsg(negation));
        }

        public virtual TR Visit(New newExpr, TP p)
        {
            throw new InvalidOperationException(GetMsg(newExpr));
        }

        public virtual TR Visit(TernaryOperator ternary, TP p)
        {
            throw new InvalidOperationException(GetMsg(ternary));
        }

        public virtual TR Visit(UnaryMinus unaryMinus, TP p)
        {
            throw new InvalidOperationException(GetMsg(unaryMinus));
        }

        public virtual TR Visit(Variable variable, TP p)
        {
            throw new InvalidOperationException(GetMsg(variable));
        }
    }
}