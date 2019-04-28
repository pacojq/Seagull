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

import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link SeagullParser}.
 */
public interface SeagullParserListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link SeagullParser#program}.
	 * @param ctx the parse tree
	 */
	void enterProgram(SeagullParser.ProgramContext ctx);
	/**
	 * Exit a parse tree produced by {@link SeagullParser#program}.
	 * @param ctx the parse tree
	 */
	void exitProgram(SeagullParser.ProgramContext ctx);
	/**
	 * Enter a parse tree produced by {@link SeagullParser#load}.
	 * @param ctx the parse tree
	 */
	void enterLoad(SeagullParser.LoadContext ctx);
	/**
	 * Exit a parse tree produced by {@link SeagullParser#load}.
	 * @param ctx the parse tree
	 */
	void exitLoad(SeagullParser.LoadContext ctx);
	/**
	 * Enter a parse tree produced by {@link SeagullParser#type}.
	 * @param ctx the parse tree
	 */
	void enterType(SeagullParser.TypeContext ctx);
	/**
	 * Exit a parse tree produced by {@link SeagullParser#type}.
	 * @param ctx the parse tree
	 */
	void exitType(SeagullParser.TypeContext ctx);
	/**
	 * Enter a parse tree produced by {@link SeagullParser#functionType}.
	 * @param ctx the parse tree
	 */
	void enterFunctionType(SeagullParser.FunctionTypeContext ctx);
	/**
	 * Exit a parse tree produced by {@link SeagullParser#functionType}.
	 * @param ctx the parse tree
	 */
	void exitFunctionType(SeagullParser.FunctionTypeContext ctx);
	/**
	 * Enter a parse tree produced by {@link SeagullParser#parameters}.
	 * @param ctx the parse tree
	 */
	void enterParameters(SeagullParser.ParametersContext ctx);
	/**
	 * Exit a parse tree produced by {@link SeagullParser#parameters}.
	 * @param ctx the parse tree
	 */
	void exitParameters(SeagullParser.ParametersContext ctx);
	/**
	 * Enter a parse tree produced by {@link SeagullParser#structType}.
	 * @param ctx the parse tree
	 */
	void enterStructType(SeagullParser.StructTypeContext ctx);
	/**
	 * Exit a parse tree produced by {@link SeagullParser#structType}.
	 * @param ctx the parse tree
	 */
	void exitStructType(SeagullParser.StructTypeContext ctx);
	/**
	 * Enter a parse tree produced by {@link SeagullParser#primitive}.
	 * @param ctx the parse tree
	 */
	void enterPrimitive(SeagullParser.PrimitiveContext ctx);
	/**
	 * Exit a parse tree produced by {@link SeagullParser#primitive}.
	 * @param ctx the parse tree
	 */
	void exitPrimitive(SeagullParser.PrimitiveContext ctx);
	/**
	 * Enter a parse tree produced by {@link SeagullParser#voidType}.
	 * @param ctx the parse tree
	 */
	void enterVoidType(SeagullParser.VoidTypeContext ctx);
	/**
	 * Exit a parse tree produced by {@link SeagullParser#voidType}.
	 * @param ctx the parse tree
	 */
	void exitVoidType(SeagullParser.VoidTypeContext ctx);
	/**
	 * Enter a parse tree produced by {@link SeagullParser#protectionLevel}.
	 * @param ctx the parse tree
	 */
	void enterProtectionLevel(SeagullParser.ProtectionLevelContext ctx);
	/**
	 * Exit a parse tree produced by {@link SeagullParser#protectionLevel}.
	 * @param ctx the parse tree
	 */
	void exitProtectionLevel(SeagullParser.ProtectionLevelContext ctx);
	/**
	 * Enter a parse tree produced by {@link SeagullParser#definition}.
	 * @param ctx the parse tree
	 */
	void enterDefinition(SeagullParser.DefinitionContext ctx);
	/**
	 * Exit a parse tree produced by {@link SeagullParser#definition}.
	 * @param ctx the parse tree
	 */
	void exitDefinition(SeagullParser.DefinitionContext ctx);
	/**
	 * Enter a parse tree produced by {@link SeagullParser#namespaceDef}.
	 * @param ctx the parse tree
	 */
	void enterNamespaceDef(SeagullParser.NamespaceDefContext ctx);
	/**
	 * Exit a parse tree produced by {@link SeagullParser#namespaceDef}.
	 * @param ctx the parse tree
	 */
	void exitNamespaceDef(SeagullParser.NamespaceDefContext ctx);
	/**
	 * Enter a parse tree produced by {@link SeagullParser#variableDef}.
	 * @param ctx the parse tree
	 */
	void enterVariableDef(SeagullParser.VariableDefContext ctx);
	/**
	 * Exit a parse tree produced by {@link SeagullParser#variableDef}.
	 * @param ctx the parse tree
	 */
	void exitVariableDef(SeagullParser.VariableDefContext ctx);
	/**
	 * Enter a parse tree produced by {@link SeagullParser#fuctionDef}.
	 * @param ctx the parse tree
	 */
	void enterFuctionDef(SeagullParser.FuctionDefContext ctx);
	/**
	 * Exit a parse tree produced by {@link SeagullParser#fuctionDef}.
	 * @param ctx the parse tree
	 */
	void exitFuctionDef(SeagullParser.FuctionDefContext ctx);
	/**
	 * Enter a parse tree produced by {@link SeagullParser#structDef}.
	 * @param ctx the parse tree
	 */
	void enterStructDef(SeagullParser.StructDefContext ctx);
	/**
	 * Exit a parse tree produced by {@link SeagullParser#structDef}.
	 * @param ctx the parse tree
	 */
	void exitStructDef(SeagullParser.StructDefContext ctx);
	/**
	 * Enter a parse tree produced by {@link SeagullParser#delegate}.
	 * @param ctx the parse tree
	 */
	void enterDelegate(SeagullParser.DelegateContext ctx);
	/**
	 * Exit a parse tree produced by {@link SeagullParser#delegate}.
	 * @param ctx the parse tree
	 */
	void exitDelegate(SeagullParser.DelegateContext ctx);
	/**
	 * Enter a parse tree produced by {@link SeagullParser#funcInvocation}.
	 * @param ctx the parse tree
	 */
	void enterFuncInvocation(SeagullParser.FuncInvocationContext ctx);
	/**
	 * Exit a parse tree produced by {@link SeagullParser#funcInvocation}.
	 * @param ctx the parse tree
	 */
	void exitFuncInvocation(SeagullParser.FuncInvocationContext ctx);
	/**
	 * Enter a parse tree produced by {@link SeagullParser#block}.
	 * @param ctx the parse tree
	 */
	void enterBlock(SeagullParser.BlockContext ctx);
	/**
	 * Exit a parse tree produced by {@link SeagullParser#block}.
	 * @param ctx the parse tree
	 */
	void exitBlock(SeagullParser.BlockContext ctx);
	/**
	 * Enter a parse tree produced by {@link SeagullParser#fnBlock}.
	 * @param ctx the parse tree
	 */
	void enterFnBlock(SeagullParser.FnBlockContext ctx);
	/**
	 * Exit a parse tree produced by {@link SeagullParser#fnBlock}.
	 * @param ctx the parse tree
	 */
	void exitFnBlock(SeagullParser.FnBlockContext ctx);
	/**
	 * Enter a parse tree produced by {@link SeagullParser#statement}.
	 * @param ctx the parse tree
	 */
	void enterStatement(SeagullParser.StatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link SeagullParser#statement}.
	 * @param ctx the parse tree
	 */
	void exitStatement(SeagullParser.StatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link SeagullParser#readPrint}.
	 * @param ctx the parse tree
	 */
	void enterReadPrint(SeagullParser.ReadPrintContext ctx);
	/**
	 * Exit a parse tree produced by {@link SeagullParser#readPrint}.
	 * @param ctx the parse tree
	 */
	void exitReadPrint(SeagullParser.ReadPrintContext ctx);
	/**
	 * Enter a parse tree produced by {@link SeagullParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterExpression(SeagullParser.ExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link SeagullParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitExpression(SeagullParser.ExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link SeagullParser#variable}.
	 * @param ctx the parse tree
	 */
	void enterVariable(SeagullParser.VariableContext ctx);
	/**
	 * Exit a parse tree produced by {@link SeagullParser#variable}.
	 * @param ctx the parse tree
	 */
	void exitVariable(SeagullParser.VariableContext ctx);
	/**
	 * Enter a parse tree produced by {@link SeagullParser#literal}.
	 * @param ctx the parse tree
	 */
	void enterLiteral(SeagullParser.LiteralContext ctx);
	/**
	 * Exit a parse tree produced by {@link SeagullParser#literal}.
	 * @param ctx the parse tree
	 */
	void exitLiteral(SeagullParser.LiteralContext ctx);
}