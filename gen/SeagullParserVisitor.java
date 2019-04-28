// Generated from D:/Dev/Seagull/Seagull/Grammar\SeagullParser.g4 by ANTLR 4.7.2


    using System.Collections.Generic;
    
	using Seagull.AST;
	using Seagull.Grammar;
	
	using Seagull.Semantics.Symbols;
	
	using Seagull.AST.Expressions;
	using Seagull.AST.Expressions.Binary;
	using Seagull.AST.Expressions.Literals;
	
	using Seagull.AST.Statements;
	using Seagull.AST.Statements.Definitions;
	
	using Seagull.AST.Types;

import org.antlr.v4.runtime.tree.ParseTreeVisitor;

/**
 * This interface defines a complete generic visitor for a parse tree produced
 * by {@link SeagullParser}.
 *
 * @param <T> The return type of the visit operation. Use {@link Void} for
 * operations with no return type.
 */
public interface SeagullParserVisitor<T> extends ParseTreeVisitor<T> {
	/**
	 * Visit a parse tree produced by {@link SeagullParser#program}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitProgram(SeagullParser.ProgramContext ctx);
	/**
	 * Visit a parse tree produced by {@link SeagullParser#load}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLoad(SeagullParser.LoadContext ctx);
	/**
	 * Visit a parse tree produced by {@link SeagullParser#type}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitType(SeagullParser.TypeContext ctx);
	/**
	 * Visit a parse tree produced by {@link SeagullParser#functionType}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitFunctionType(SeagullParser.FunctionTypeContext ctx);
	/**
	 * Visit a parse tree produced by {@link SeagullParser#parameters}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitParameters(SeagullParser.ParametersContext ctx);
	/**
	 * Visit a parse tree produced by {@link SeagullParser#structType}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitStructType(SeagullParser.StructTypeContext ctx);
	/**
	 * Visit a parse tree produced by {@link SeagullParser#primitive}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitPrimitive(SeagullParser.PrimitiveContext ctx);
	/**
	 * Visit a parse tree produced by {@link SeagullParser#voidType}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitVoidType(SeagullParser.VoidTypeContext ctx);
	/**
	 * Visit a parse tree produced by {@link SeagullParser#protectionLevel}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitProtectionLevel(SeagullParser.ProtectionLevelContext ctx);
	/**
	 * Visit a parse tree produced by {@link SeagullParser#definition}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitDefinition(SeagullParser.DefinitionContext ctx);
	/**
	 * Visit a parse tree produced by {@link SeagullParser#namespaceDef}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitNamespaceDef(SeagullParser.NamespaceDefContext ctx);
	/**
	 * Visit a parse tree produced by {@link SeagullParser#variableDef}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitVariableDef(SeagullParser.VariableDefContext ctx);
	/**
	 * Visit a parse tree produced by {@link SeagullParser#fuctionDef}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitFuctionDef(SeagullParser.FuctionDefContext ctx);
	/**
	 * Visit a parse tree produced by {@link SeagullParser#structDef}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitStructDef(SeagullParser.StructDefContext ctx);
	/**
	 * Visit a parse tree produced by {@link SeagullParser#delegate}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitDelegate(SeagullParser.DelegateContext ctx);
	/**
	 * Visit a parse tree produced by {@link SeagullParser#funcInvocation}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitFuncInvocation(SeagullParser.FuncInvocationContext ctx);
	/**
	 * Visit a parse tree produced by {@link SeagullParser#block}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitBlock(SeagullParser.BlockContext ctx);
	/**
	 * Visit a parse tree produced by {@link SeagullParser#fnBlock}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitFnBlock(SeagullParser.FnBlockContext ctx);
	/**
	 * Visit a parse tree produced by {@link SeagullParser#statement}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitStatement(SeagullParser.StatementContext ctx);
	/**
	 * Visit a parse tree produced by {@link SeagullParser#readPrint}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitReadPrint(SeagullParser.ReadPrintContext ctx);
	/**
	 * Visit a parse tree produced by {@link SeagullParser#expression}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitExpression(SeagullParser.ExpressionContext ctx);
	/**
	 * Visit a parse tree produced by {@link SeagullParser#variable}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitVariable(SeagullParser.VariableContext ctx);
	/**
	 * Visit a parse tree produced by {@link SeagullParser#literal}.
	 * @param ctx the parse tree
	 * @return the visitor result
	 */
	T visitLiteral(SeagullParser.LiteralContext ctx);
}