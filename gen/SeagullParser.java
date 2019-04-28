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

import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class SeagullParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.7.2", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		SHARP=1, VOID=2, INT=3, CHAR=4, DOUBLE=5, STRING=6, STRUCT=7, ENUM=8, 
		DELEGATE=9, TRUE=10, FALSE=11, IF=12, ELSE=13, WHILE=14, FOR=15, NEW=16, 
		DELETE=17, RETURN=18, PRINT=19, READ=20, ASSERT=21, DELAY=22, PUBLIC=23, 
		PRIVATE=24, LOAD=25, IMPORT=26, NAMESPACE=27, USING=28, DOT=29, COMMA=30, 
		COL=31, SEMI_COL=32, ASSIGN=33, STAR=34, SLASH=35, PERCENT=36, ARROW=37, 
		PLUS=38, MINUS=39, NOT=40, AND=41, OR=42, L_BRACKET=43, R_BRACKET=44, 
		L_PAR=45, R_PAR=46, L_CURL=47, R_CURL=48, EQUAL=49, NOT_EQUAL=50, LESS_THAN=51, 
		GREATER_THAN=52, LESS_EQ_THAN=53, GREATER_EQ_THAN=54, ID=55, INT_CONSTANT=56, 
		REAL_CONSTANT=57, CHAR_CONSTANT=58, STRING_CONSTANT=59, BOOLEAN_CONSTANT=60, 
		SL_COMMENT=61, ML_COMMENT=62, BLANKS=63, DIR_DEFINE=64, DIR_IF=65, DIR_ELIF=66, 
		DIR_ELSE=67, DIR_WHITESPACE=68, DIR_ML_COMMENT=69, DIR_NEWLINE=70;
	public static final int
		RULE_program = 0, RULE_load = 1, RULE_type = 2, RULE_functionType = 3, 
		RULE_parameters = 4, RULE_structType = 5, RULE_primitive = 6, RULE_voidType = 7, 
		RULE_protectionLevel = 8, RULE_definition = 9, RULE_namespaceDef = 10, 
		RULE_variableDef = 11, RULE_fuctionDef = 12, RULE_structDef = 13, RULE_delegate = 14, 
		RULE_funcInvocation = 15, RULE_block = 16, RULE_fnBlock = 17, RULE_statement = 18, 
		RULE_readPrint = 19, RULE_expression = 20, RULE_variable = 21, RULE_literal = 22;
	private static String[] makeRuleNames() {
		return new String[] {
			"program", "load", "type", "functionType", "parameters", "structType", 
			"primitive", "voidType", "protectionLevel", "definition", "namespaceDef", 
			"variableDef", "fuctionDef", "structDef", "delegate", "funcInvocation", 
			"block", "fnBlock", "statement", "readPrint", "expression", "variable", 
			"literal"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'#'", "'void'", "'int'", "'char'", "'double'", "'string'", "'struct'", 
			"'enum'", "'delegate'", "'true'", "'false'", null, null, "'while'", "'for'", 
			"'new'", "'delete'", "'return'", "'print'", "'read'", "'assert'", "'delay'", 
			"'public'", "'private'", "'load'", "'import'", "'namespace'", "'using'", 
			"'.'", "','", "':'", "';'", "'='", "'*'", "'/'", "'%'", "'->'", "'+'", 
			"'-'", "'!'", "'&&'", "'||'", "'['", "']'", "'('", "')'", "'{'", "'}'", 
			"'=='", "'!='", "'<'", "'>'", "'<='", "'>='", null, null, null, null, 
			null, null, null, null, null, "'define'", null, "'elif'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "SHARP", "VOID", "INT", "CHAR", "DOUBLE", "STRING", "STRUCT", "ENUM", 
			"DELEGATE", "TRUE", "FALSE", "IF", "ELSE", "WHILE", "FOR", "NEW", "DELETE", 
			"RETURN", "PRINT", "READ", "ASSERT", "DELAY", "PUBLIC", "PRIVATE", "LOAD", 
			"IMPORT", "NAMESPACE", "USING", "DOT", "COMMA", "COL", "SEMI_COL", "ASSIGN", 
			"STAR", "SLASH", "PERCENT", "ARROW", "PLUS", "MINUS", "NOT", "AND", "OR", 
			"L_BRACKET", "R_BRACKET", "L_PAR", "R_PAR", "L_CURL", "R_CURL", "EQUAL", 
			"NOT_EQUAL", "LESS_THAN", "GREATER_THAN", "LESS_EQ_THAN", "GREATER_EQ_THAN", 
			"ID", "INT_CONSTANT", "REAL_CONSTANT", "CHAR_CONSTANT", "STRING_CONSTANT", 
			"BOOLEAN_CONSTANT", "SL_COMMENT", "ML_COMMENT", "BLANKS", "DIR_DEFINE", 
			"DIR_IF", "DIR_ELIF", "DIR_ELSE", "DIR_WHITESPACE", "DIR_ML_COMMENT", 
			"DIR_NEWLINE"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "SeagullParser.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public SeagullParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	public static class ProgramContext extends ParserRuleContext {
		public Program Ast;
		public List<string> Loads = new List<string>();
		public List<IDefinition> Def = new List<IDefinition>();
		public LoadContext l;
		public DefinitionContext d;
		public TerminalNode EOF() { return getToken(SeagullParser.EOF, 0); }
		public List<LoadContext> load() {
			return getRuleContexts(LoadContext.class);
		}
		public LoadContext load(int i) {
			return getRuleContext(LoadContext.class,i);
		}
		public List<DefinitionContext> definition() {
			return getRuleContexts(DefinitionContext.class);
		}
		public DefinitionContext definition(int i) {
			return getRuleContext(DefinitionContext.class,i);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_program; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).enterProgram(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).exitProgram(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof SeagullParserVisitor ) return ((SeagullParserVisitor<? extends T>)visitor).visitProgram(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ProgramContext program() throws RecognitionException {
		ProgramContext _localctx = new ProgramContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_program);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(51);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==LOAD) {
				{
				{
				setState(46);
				((ProgramContext)_localctx).l = load();
				 _localctx.Loads.Add(((ProgramContext)_localctx).l.File); 
				}
				}
				setState(53);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(59);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << PUBLIC) | (1L << PRIVATE) | (1L << NAMESPACE) | (1L << ID))) != 0)) {
				{
				{
				setState(54);
				((ProgramContext)_localctx).d = definition();
				 _localctx.Def.Add(((ProgramContext)_localctx).d.Ast); 
				}
				}
				setState(61);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(62);
			match(EOF);
			 ((ProgramContext)_localctx).Ast =  new Program(0, 0, _localctx.Loads, _localctx.Def); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class LoadContext extends ParserRuleContext {
		public string File;
		public Token p;
		public TerminalNode LOAD() { return getToken(SeagullParser.LOAD, 0); }
		public TerminalNode STRING_CONSTANT() { return getToken(SeagullParser.STRING_CONSTANT, 0); }
		public LoadContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_load; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).enterLoad(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).exitLoad(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof SeagullParserVisitor ) return ((SeagullParserVisitor<? extends T>)visitor).visitLoad(this);
			else return visitor.visitChildren(this);
		}
	}

	public final LoadContext load() throws RecognitionException {
		LoadContext _localctx = new LoadContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_load);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(65);
			match(LOAD);
			setState(66);
			((LoadContext)_localctx).p = match(STRING_CONSTANT);
			 ((LoadContext)_localctx).File =  (((LoadContext)_localctx).p!=null?((LoadContext)_localctx).p.getText():null); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class TypeContext extends ParserRuleContext {
		public IType Ast;
		public TypeContext t;
		public PrimitiveContext primitive;
		public FunctionTypeContext functionType;
		public StructTypeContext structType;
		public Token userDefined;
		public Token i;
		public Token i2;
		public PrimitiveContext primitive() {
			return getRuleContext(PrimitiveContext.class,0);
		}
		public FunctionTypeContext functionType() {
			return getRuleContext(FunctionTypeContext.class,0);
		}
		public StructTypeContext structType() {
			return getRuleContext(StructTypeContext.class,0);
		}
		public TerminalNode ID() { return getToken(SeagullParser.ID, 0); }
		public List<TerminalNode> L_BRACKET() { return getTokens(SeagullParser.L_BRACKET); }
		public TerminalNode L_BRACKET(int i) {
			return getToken(SeagullParser.L_BRACKET, i);
		}
		public List<TerminalNode> R_BRACKET() { return getTokens(SeagullParser.R_BRACKET); }
		public TerminalNode R_BRACKET(int i) {
			return getToken(SeagullParser.R_BRACKET, i);
		}
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public List<TerminalNode> INT_CONSTANT() { return getTokens(SeagullParser.INT_CONSTANT); }
		public TerminalNode INT_CONSTANT(int i) {
			return getToken(SeagullParser.INT_CONSTANT, i);
		}
		public TypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_type; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).enterType(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).exitType(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof SeagullParserVisitor ) return ((SeagullParserVisitor<? extends T>)visitor).visitType(this);
			else return visitor.visitChildren(this);
		}
	}

	public final TypeContext type() throws RecognitionException {
		return type(0);
	}

	private TypeContext type(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		TypeContext _localctx = new TypeContext(_ctx, _parentState);
		TypeContext _prevctx = _localctx;
		int _startState = 4;
		enterRecursionRule(_localctx, 4, RULE_type, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(81);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case INT:
			case CHAR:
			case DOUBLE:
			case STRING:
				{
				setState(70);
				((TypeContext)_localctx).primitive = primitive();
				 ((TypeContext)_localctx).Ast =  ((TypeContext)_localctx).primitive.Ast; 
				}
				break;
			case L_PAR:
				{
				setState(73);
				((TypeContext)_localctx).functionType = functionType();
				 ((TypeContext)_localctx).Ast =  ((TypeContext)_localctx).functionType.Ast; 
				}
				break;
			case STRUCT:
				{
				setState(76);
				((TypeContext)_localctx).structType = structType();
				 ((TypeContext)_localctx).Ast =  ((TypeContext)_localctx).structType.Ast; 
				}
				break;
			case ID:
				{
				setState(79);
				((TypeContext)_localctx).userDefined = match(ID);
				 ((TypeContext)_localctx).Ast =  DependencyManager.Instance.AddType(((TypeContext)_localctx).userDefined.GetLine(), ((TypeContext)_localctx).userDefined.GetCol(), ((TypeContext)_localctx).userDefined.GetText()); 
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			_ctx.stop = _input.LT(-1);
			setState(99);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,4,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new TypeContext(_parentctx, _parentState);
					_localctx.t = _prevctx;
					_localctx.t = _prevctx;
					pushNewRecursionContext(_localctx, _startState, RULE_type);
					setState(83);
					if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
					setState(84);
					match(L_BRACKET);
					setState(85);
					((TypeContext)_localctx).i = match(INT_CONSTANT);
					setState(86);
					match(R_BRACKET);
					 ((TypeContext)_localctx).Ast =  ArrayType.BuildArray(int.Parse((((TypeContext)_localctx).i!=null?((TypeContext)_localctx).i.getText():null)), ((TypeContext)_localctx).t.Ast); 
					setState(94);
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,3,_ctx);
					while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
						if ( _alt==1 ) {
							{
							{
							setState(88);
							match(L_BRACKET);
							setState(89);
							((TypeContext)_localctx).i2 = match(INT_CONSTANT);
							setState(90);
							match(R_BRACKET);
							 ((TypeContext)_localctx).Ast =  ArrayType.BuildArray( int.Parse((((TypeContext)_localctx).i2!=null?((TypeContext)_localctx).i2.getText():null)), _localctx.Ast); 
							}
							} 
						}
						setState(96);
						_errHandler.sync(this);
						_alt = getInterpreter().adaptivePredict(_input,3,_ctx);
					}
					}
					} 
				}
				setState(101);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,4,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public static class FunctionTypeContext extends ParserRuleContext {
		public FunctionType Ast;
		public List<VariableDefinition> Params = new List<VariableDefinition>();
		public IType Rt;
		public ParametersContext p;
		public Token par;
		public TypeContext t;
		public VoidTypeContext vt;
		public TerminalNode L_PAR() { return getToken(SeagullParser.L_PAR, 0); }
		public TerminalNode R_PAR() { return getToken(SeagullParser.R_PAR, 0); }
		public TerminalNode ARROW() { return getToken(SeagullParser.ARROW, 0); }
		public ParametersContext parameters() {
			return getRuleContext(ParametersContext.class,0);
		}
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public VoidTypeContext voidType() {
			return getRuleContext(VoidTypeContext.class,0);
		}
		public FunctionTypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionType; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).enterFunctionType(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).exitFunctionType(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof SeagullParserVisitor ) return ((SeagullParserVisitor<? extends T>)visitor).visitFunctionType(this);
			else return visitor.visitChildren(this);
		}
	}

	public final FunctionTypeContext functionType() throws RecognitionException {
		FunctionTypeContext _localctx = new FunctionTypeContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_functionType);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(102);
			match(L_PAR);
			setState(106);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ID) {
				{
				setState(103);
				((FunctionTypeContext)_localctx).p = parameters();
				 ((FunctionTypeContext)_localctx).Params =  ((FunctionTypeContext)_localctx).p.Ast;
				}
			}

			setState(108);
			((FunctionTypeContext)_localctx).par = match(R_PAR);
			 ((FunctionTypeContext)_localctx).Rt = new VoidType(((FunctionTypeContext)_localctx).par.GetLine(), ((FunctionTypeContext)_localctx).par.GetCol()); 
			setState(119);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,7,_ctx) ) {
			case 1:
				{
				setState(110);
				match(ARROW);
				setState(117);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case INT:
				case CHAR:
				case DOUBLE:
				case STRING:
				case STRUCT:
				case L_PAR:
				case ID:
					{
					{
					setState(111);
					((FunctionTypeContext)_localctx).t = type(0);
					 ((FunctionTypeContext)_localctx).Rt = ((FunctionTypeContext)_localctx).t.Ast; 
					}
					}
					break;
				case VOID:
					{
					{
					setState(114);
					((FunctionTypeContext)_localctx).vt = voidType();
					 ((FunctionTypeContext)_localctx).Rt = ((FunctionTypeContext)_localctx).vt.Ast; 
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				break;
			}
			 ((FunctionTypeContext)_localctx).Ast =  new FunctionType(_localctx.Rt, _localctx.Params); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ParametersContext extends ParserRuleContext {
		public List<VariableDefinition> Ast = new List<VariableDefinition>();
		public Token id1;
		public TypeContext t1;
		public Token id2;
		public TypeContext t2;
		public LiteralContext l;
		public List<TerminalNode> COL() { return getTokens(SeagullParser.COL); }
		public TerminalNode COL(int i) {
			return getToken(SeagullParser.COL, i);
		}
		public List<TerminalNode> ID() { return getTokens(SeagullParser.ID); }
		public TerminalNode ID(int i) {
			return getToken(SeagullParser.ID, i);
		}
		public List<TypeContext> type() {
			return getRuleContexts(TypeContext.class);
		}
		public TypeContext type(int i) {
			return getRuleContext(TypeContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(SeagullParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SeagullParser.COMMA, i);
		}
		public List<TerminalNode> ASSIGN() { return getTokens(SeagullParser.ASSIGN); }
		public TerminalNode ASSIGN(int i) {
			return getToken(SeagullParser.ASSIGN, i);
		}
		public List<LiteralContext> literal() {
			return getRuleContexts(LiteralContext.class);
		}
		public LiteralContext literal(int i) {
			return getRuleContext(LiteralContext.class,i);
		}
		public ParametersContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_parameters; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).enterParameters(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).exitParameters(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof SeagullParserVisitor ) return ((SeagullParserVisitor<? extends T>)visitor).visitParameters(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ParametersContext parameters() throws RecognitionException {
		ParametersContext _localctx = new ParametersContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_parameters);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(123);
			((ParametersContext)_localctx).id1 = match(ID);
			setState(124);
			match(COL);
			setState(125);
			((ParametersContext)_localctx).t1 = type(0);
			 _localctx.Ast.Add(new VariableDefinition(((ParametersContext)_localctx).id1.GetLine(), ((ParametersContext)_localctx).id1.GetCol(), ((ParametersContext)_localctx).id1.GetText(), ((ParametersContext)_localctx).t1.Ast, null)); 
			setState(135);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,8,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(127);
					match(COMMA);
					setState(128);
					((ParametersContext)_localctx).id2 = match(ID);
					setState(129);
					match(COL);
					setState(130);
					((ParametersContext)_localctx).t2 = type(0);
					 _localctx.Ast.Add(new VariableDefinition(((ParametersContext)_localctx).id2.GetLine(), ((ParametersContext)_localctx).id2.GetCol(), ((ParametersContext)_localctx).id2.GetText(), ((ParametersContext)_localctx).t2.Ast, null)); 
					}
					} 
				}
				setState(137);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,8,_ctx);
			}
			setState(148);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(138);
				match(COMMA);
				setState(139);
				((ParametersContext)_localctx).id2 = match(ID);
				setState(140);
				match(COL);
				setState(141);
				((ParametersContext)_localctx).t2 = type(0);
				setState(142);
				match(ASSIGN);
				setState(143);
				((ParametersContext)_localctx).l = literal();
				 _localctx.Ast.Add(new VariableDefinition(((ParametersContext)_localctx).id2.GetLine(), ((ParametersContext)_localctx).id2.GetCol(), ((ParametersContext)_localctx).id2.GetText(), ((ParametersContext)_localctx).t2.Ast, ((ParametersContext)_localctx).l.Ast)); 
				}
				}
				setState(150);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StructTypeContext extends ParserRuleContext {
		public StructType Ast;
		public List<VariableDefinition> Fields = new List<VariableDefinition>();
		public Token s;
		public VariableDefContext f;
		public TerminalNode L_CURL() { return getToken(SeagullParser.L_CURL, 0); }
		public TerminalNode R_CURL() { return getToken(SeagullParser.R_CURL, 0); }
		public TerminalNode STRUCT() { return getToken(SeagullParser.STRUCT, 0); }
		public List<VariableDefContext> variableDef() {
			return getRuleContexts(VariableDefContext.class);
		}
		public VariableDefContext variableDef(int i) {
			return getRuleContext(VariableDefContext.class,i);
		}
		public StructTypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_structType; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).enterStructType(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).exitStructType(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof SeagullParserVisitor ) return ((SeagullParserVisitor<? extends T>)visitor).visitStructType(this);
			else return visitor.visitChildren(this);
		}
	}

	public final StructTypeContext structType() throws RecognitionException {
		StructTypeContext _localctx = new StructTypeContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_structType);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(151);
			((StructTypeContext)_localctx).s = match(STRUCT);
			setState(152);
			match(L_CURL);
			setState(158);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==ID) {
				{
				{
				setState(153);
				((StructTypeContext)_localctx).f = variableDef();
				 _localctx.Fields.Add(((StructTypeContext)_localctx).f.Ast); 
				}
				}
				setState(160);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(161);
			match(R_CURL);
			 ((StructTypeContext)_localctx).Ast =  new StructType(((StructTypeContext)_localctx).s.GetLine(), ((StructTypeContext)_localctx).s.GetCol(), _localctx.Fields); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PrimitiveContext extends ParserRuleContext {
		public IType Ast;
		public Token i;
		public Token c;
		public Token d;
		public Token s;
		public TerminalNode INT() { return getToken(SeagullParser.INT, 0); }
		public TerminalNode CHAR() { return getToken(SeagullParser.CHAR, 0); }
		public TerminalNode DOUBLE() { return getToken(SeagullParser.DOUBLE, 0); }
		public TerminalNode STRING() { return getToken(SeagullParser.STRING, 0); }
		public PrimitiveContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_primitive; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).enterPrimitive(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).exitPrimitive(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof SeagullParserVisitor ) return ((SeagullParserVisitor<? extends T>)visitor).visitPrimitive(this);
			else return visitor.visitChildren(this);
		}
	}

	public final PrimitiveContext primitive() throws RecognitionException {
		PrimitiveContext _localctx = new PrimitiveContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_primitive);
		try {
			setState(172);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case INT:
				enterOuterAlt(_localctx, 1);
				{
				setState(164);
				((PrimitiveContext)_localctx).i = match(INT);
				 ((PrimitiveContext)_localctx).Ast =  new IntType(((PrimitiveContext)_localctx).i.GetLine(), ((PrimitiveContext)_localctx).i.GetCol()); 
				}
				break;
			case CHAR:
				enterOuterAlt(_localctx, 2);
				{
				setState(166);
				((PrimitiveContext)_localctx).c = match(CHAR);
				 ((PrimitiveContext)_localctx).Ast =  new CharType(((PrimitiveContext)_localctx).c.GetLine(), ((PrimitiveContext)_localctx).c.GetCol()); 
				}
				break;
			case DOUBLE:
				enterOuterAlt(_localctx, 3);
				{
				setState(168);
				((PrimitiveContext)_localctx).d = match(DOUBLE);
				 ((PrimitiveContext)_localctx).Ast =  new DoubleType(((PrimitiveContext)_localctx).d.GetLine(), ((PrimitiveContext)_localctx).d.GetCol()); 
				}
				break;
			case STRING:
				enterOuterAlt(_localctx, 4);
				{
				setState(170);
				((PrimitiveContext)_localctx).s = match(STRING);
				 ((PrimitiveContext)_localctx).Ast =  new StringType(((PrimitiveContext)_localctx).s.GetLine(), ((PrimitiveContext)_localctx).s.GetCol()); 
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class VoidTypeContext extends ParserRuleContext {
		public IType Ast;
		public Token v;
		public TerminalNode VOID() { return getToken(SeagullParser.VOID, 0); }
		public VoidTypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_voidType; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).enterVoidType(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).exitVoidType(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof SeagullParserVisitor ) return ((SeagullParserVisitor<? extends T>)visitor).visitVoidType(this);
			else return visitor.visitChildren(this);
		}
	}

	public final VoidTypeContext voidType() throws RecognitionException {
		VoidTypeContext _localctx = new VoidTypeContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_voidType);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(174);
			((VoidTypeContext)_localctx).v = match(VOID);
			 ((VoidTypeContext)_localctx).Ast =  new VoidType(((VoidTypeContext)_localctx).v.GetLine(), ((VoidTypeContext)_localctx).v.GetCol()); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ProtectionLevelContext extends ParserRuleContext {
		public TerminalNode PUBLIC() { return getToken(SeagullParser.PUBLIC, 0); }
		public TerminalNode PRIVATE() { return getToken(SeagullParser.PRIVATE, 0); }
		public ProtectionLevelContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_protectionLevel; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).enterProtectionLevel(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).exitProtectionLevel(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof SeagullParserVisitor ) return ((SeagullParserVisitor<? extends T>)visitor).visitProtectionLevel(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ProtectionLevelContext protectionLevel() throws RecognitionException {
		ProtectionLevelContext _localctx = new ProtectionLevelContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_protectionLevel);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(177);
			_la = _input.LA(1);
			if ( !(_la==PUBLIC || _la==PRIVATE) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class DefinitionContext extends ParserRuleContext {
		public IDefinition Ast;
		public NamespaceDefContext namespaceDef;
		public FuctionDefContext fuctionDef;
		public VariableDefContext variableDef;
		public StructDefContext structDef;
		public NamespaceDefContext namespaceDef() {
			return getRuleContext(NamespaceDefContext.class,0);
		}
		public FuctionDefContext fuctionDef() {
			return getRuleContext(FuctionDefContext.class,0);
		}
		public ProtectionLevelContext protectionLevel() {
			return getRuleContext(ProtectionLevelContext.class,0);
		}
		public VariableDefContext variableDef() {
			return getRuleContext(VariableDefContext.class,0);
		}
		public StructDefContext structDef() {
			return getRuleContext(StructDefContext.class,0);
		}
		public DefinitionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_definition; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).enterDefinition(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).exitDefinition(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof SeagullParserVisitor ) return ((SeagullParserVisitor<? extends T>)visitor).visitDefinition(this);
			else return visitor.visitChildren(this);
		}
	}

	public final DefinitionContext definition() throws RecognitionException {
		DefinitionContext _localctx = new DefinitionContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_definition);
		int _la;
		try {
			setState(200);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,15,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(179);
				((DefinitionContext)_localctx).namespaceDef = namespaceDef();
				 ((DefinitionContext)_localctx).Ast =  ((DefinitionContext)_localctx).namespaceDef.Ast; 
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(183);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==PUBLIC || _la==PRIVATE) {
					{
					setState(182);
					protectionLevel();
					}
				}

				setState(185);
				((DefinitionContext)_localctx).fuctionDef = fuctionDef();
				 ((DefinitionContext)_localctx).Ast =  ((DefinitionContext)_localctx).fuctionDef.Ast; 
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(189);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==PUBLIC || _la==PRIVATE) {
					{
					setState(188);
					protectionLevel();
					}
				}

				setState(191);
				((DefinitionContext)_localctx).variableDef = variableDef();
				 ((DefinitionContext)_localctx).Ast =  ((DefinitionContext)_localctx).variableDef.Ast; 
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(195);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==PUBLIC || _la==PRIVATE) {
					{
					setState(194);
					protectionLevel();
					}
				}

				setState(197);
				((DefinitionContext)_localctx).structDef = structDef();
				 ((DefinitionContext)_localctx).Ast =  ((DefinitionContext)_localctx).structDef.Ast; 
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class NamespaceDefContext extends ParserRuleContext {
		public NamespaceDefinition Ast;
		public List<IDefinition> Def = new List<IDefinition>();
		public NamespaceDefinition Parent = null;
		public Token n;
		public Token p;
		public Token id;
		public DefinitionContext d;
		public TerminalNode L_CURL() { return getToken(SeagullParser.L_CURL, 0); }
		public TerminalNode R_CURL() { return getToken(SeagullParser.R_CURL, 0); }
		public TerminalNode NAMESPACE() { return getToken(SeagullParser.NAMESPACE, 0); }
		public List<TerminalNode> ID() { return getTokens(SeagullParser.ID); }
		public TerminalNode ID(int i) {
			return getToken(SeagullParser.ID, i);
		}
		public List<TerminalNode> DOT() { return getTokens(SeagullParser.DOT); }
		public TerminalNode DOT(int i) {
			return getToken(SeagullParser.DOT, i);
		}
		public List<DefinitionContext> definition() {
			return getRuleContexts(DefinitionContext.class);
		}
		public DefinitionContext definition(int i) {
			return getRuleContext(DefinitionContext.class,i);
		}
		public NamespaceDefContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_namespaceDef; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).enterNamespaceDef(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).exitNamespaceDef(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof SeagullParserVisitor ) return ((SeagullParserVisitor<? extends T>)visitor).visitNamespaceDef(this);
			else return visitor.visitChildren(this);
		}
	}

	public final NamespaceDefContext namespaceDef() throws RecognitionException {
		NamespaceDefContext _localctx = new NamespaceDefContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_namespaceDef);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(202);
			((NamespaceDefContext)_localctx).n = match(NAMESPACE);
			setState(208);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,16,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(203);
					((NamespaceDefContext)_localctx).p = match(ID);
					setState(204);
					match(DOT);
					 ((NamespaceDefContext)_localctx).Parent =  SymbolsManager.Instance.AddNamespace(((NamespaceDefContext)_localctx).n.GetLine(), ((NamespaceDefContext)_localctx).n.GetCol(), ((NamespaceDefContext)_localctx).p.GetText(), _localctx.Parent); 
					}
					} 
				}
				setState(210);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,16,_ctx);
			}
			setState(211);
			((NamespaceDefContext)_localctx).id = match(ID);
			setState(212);
			match(L_CURL);
			setState(218);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << PUBLIC) | (1L << PRIVATE) | (1L << NAMESPACE) | (1L << ID))) != 0)) {
				{
				{
				setState(213);
				((NamespaceDefContext)_localctx).d = definition();
				 _localctx.Def.Add(((NamespaceDefContext)_localctx).d.Ast); 
				}
				}
				setState(220);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(221);
			match(R_CURL);
			 ((NamespaceDefContext)_localctx).Ast =  new NamespaceDefinition(((NamespaceDefContext)_localctx).n.GetLine(), ((NamespaceDefContext)_localctx).n.GetCol(), ((NamespaceDefContext)_localctx).id.GetText(), _localctx.Parent, _localctx.Def); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class VariableDefContext extends ParserRuleContext {
		public VariableDefinition Ast;
		public Token n;
		public TypeContext t;
		public ExpressionContext e;
		public TerminalNode COL() { return getToken(SeagullParser.COL, 0); }
		public TerminalNode SEMI_COL() { return getToken(SeagullParser.SEMI_COL, 0); }
		public TerminalNode ID() { return getToken(SeagullParser.ID, 0); }
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public TerminalNode ASSIGN() { return getToken(SeagullParser.ASSIGN, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public VariableDefContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_variableDef; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).enterVariableDef(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).exitVariableDef(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof SeagullParserVisitor ) return ((SeagullParserVisitor<? extends T>)visitor).visitVariableDef(this);
			else return visitor.visitChildren(this);
		}
	}

	public final VariableDefContext variableDef() throws RecognitionException {
		VariableDefContext _localctx = new VariableDefContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_variableDef);
		try {
			setState(238);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,18,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(224);
				((VariableDefContext)_localctx).n = match(ID);
				setState(225);
				match(COL);
				setState(226);
				((VariableDefContext)_localctx).t = type(0);
				setState(227);
				match(SEMI_COL);
				 ((VariableDefContext)_localctx).Ast =  new VariableDefinition(((VariableDefContext)_localctx).t.Ast.Line, ((VariableDefContext)_localctx).t.Ast.Column, ((VariableDefContext)_localctx).n.GetText(), ((VariableDefContext)_localctx).t.Ast, null); 
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(230);
				((VariableDefContext)_localctx).n = match(ID);
				setState(231);
				match(COL);
				setState(232);
				((VariableDefContext)_localctx).t = type(0);
				setState(233);
				match(ASSIGN);
				setState(234);
				((VariableDefContext)_localctx).e = expression(0);
				setState(235);
				match(SEMI_COL);
				 ((VariableDefContext)_localctx).Ast =  new VariableDefinition(((VariableDefContext)_localctx).t.Ast.Line, ((VariableDefContext)_localctx).t.Ast.Column, ((VariableDefContext)_localctx).n.GetText(), ((VariableDefContext)_localctx).t.Ast, ((VariableDefContext)_localctx).e.Ast); 
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FuctionDefContext extends ParserRuleContext {
		public FunctionDefinition Ast;
		public IType funcType;
		public Token n;
		public FunctionTypeContext t;
		public FnBlockContext fnBlock;
		public TerminalNode COL() { return getToken(SeagullParser.COL, 0); }
		public FnBlockContext fnBlock() {
			return getRuleContext(FnBlockContext.class,0);
		}
		public TerminalNode ID() { return getToken(SeagullParser.ID, 0); }
		public FunctionTypeContext functionType() {
			return getRuleContext(FunctionTypeContext.class,0);
		}
		public FuctionDefContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_fuctionDef; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).enterFuctionDef(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).exitFuctionDef(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof SeagullParserVisitor ) return ((SeagullParserVisitor<? extends T>)visitor).visitFuctionDef(this);
			else return visitor.visitChildren(this);
		}
	}

	public final FuctionDefContext fuctionDef() throws RecognitionException {
		FuctionDefContext _localctx = new FuctionDefContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_fuctionDef);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(240);
			((FuctionDefContext)_localctx).n = match(ID);
			setState(241);
			match(COL);
			setState(242);
			((FuctionDefContext)_localctx).t = functionType();
			setState(243);
			((FuctionDefContext)_localctx).fnBlock = fnBlock();
			 ((FuctionDefContext)_localctx).Ast =  new FunctionDefinition(((FuctionDefContext)_localctx).n.GetLine(), ((FuctionDefContext)_localctx).n.GetCol(), ((FuctionDefContext)_localctx).n.GetText(), ((FuctionDefContext)_localctx).t.Ast, ((FuctionDefContext)_localctx).fnBlock.Ast); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StructDefContext extends ParserRuleContext {
		public StructDefinition Ast;
		public Token n;
		public StructTypeContext t;
		public TerminalNode COL() { return getToken(SeagullParser.COL, 0); }
		public TerminalNode ID() { return getToken(SeagullParser.ID, 0); }
		public StructTypeContext structType() {
			return getRuleContext(StructTypeContext.class,0);
		}
		public StructDefContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_structDef; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).enterStructDef(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).exitStructDef(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof SeagullParserVisitor ) return ((SeagullParserVisitor<? extends T>)visitor).visitStructDef(this);
			else return visitor.visitChildren(this);
		}
	}

	public final StructDefContext structDef() throws RecognitionException {
		StructDefContext _localctx = new StructDefContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_structDef);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(246);
			((StructDefContext)_localctx).n = match(ID);
			setState(247);
			match(COL);
			setState(248);
			((StructDefContext)_localctx).t = structType();
			 ((StructDefContext)_localctx).Ast =  new StructDefinition(((StructDefContext)_localctx).n.GetLine(), ((StructDefContext)_localctx).n.GetCol(), ((StructDefContext)_localctx).n.GetText(), ((StructDefContext)_localctx).t.Ast); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class DelegateContext extends ParserRuleContext {
		public IType Ast;
		public Token n;
		public FunctionTypeContext functionType;
		public TerminalNode DELEGATE() { return getToken(SeagullParser.DELEGATE, 0); }
		public FunctionTypeContext functionType() {
			return getRuleContext(FunctionTypeContext.class,0);
		}
		public TerminalNode ID() { return getToken(SeagullParser.ID, 0); }
		public DelegateContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_delegate; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).enterDelegate(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).exitDelegate(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof SeagullParserVisitor ) return ((SeagullParserVisitor<? extends T>)visitor).visitDelegate(this);
			else return visitor.visitChildren(this);
		}
	}

	public final DelegateContext delegate() throws RecognitionException {
		DelegateContext _localctx = new DelegateContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_delegate);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(251);
			match(DELEGATE);
			setState(252);
			((DelegateContext)_localctx).n = match(ID);
			setState(253);
			((DelegateContext)_localctx).functionType = functionType();
			 ((DelegateContext)_localctx).Ast =  ((DelegateContext)_localctx).functionType.Ast; 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FuncInvocationContext extends ParserRuleContext {
		public FunctionInvocation Ast;
		public List<IExpression> arguments = new List<IExpression>();
		public VariableContext func;
		public ExpressionContext e1;
		public ExpressionContext e2;
		public TerminalNode L_PAR() { return getToken(SeagullParser.L_PAR, 0); }
		public TerminalNode R_PAR() { return getToken(SeagullParser.R_PAR, 0); }
		public VariableContext variable() {
			return getRuleContext(VariableContext.class,0);
		}
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(SeagullParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(SeagullParser.COMMA, i);
		}
		public FuncInvocationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_funcInvocation; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).enterFuncInvocation(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).exitFuncInvocation(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof SeagullParserVisitor ) return ((SeagullParserVisitor<? extends T>)visitor).visitFuncInvocation(this);
			else return visitor.visitChildren(this);
		}
	}

	public final FuncInvocationContext funcInvocation() throws RecognitionException {
		FuncInvocationContext _localctx = new FuncInvocationContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_funcInvocation);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(256);
			((FuncInvocationContext)_localctx).func = variable();
			setState(257);
			match(L_PAR);
			setState(269);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << NEW) | (1L << MINUS) | (1L << NOT) | (1L << L_PAR) | (1L << ID) | (1L << INT_CONSTANT) | (1L << REAL_CONSTANT) | (1L << CHAR_CONSTANT) | (1L << STRING_CONSTANT) | (1L << BOOLEAN_CONSTANT))) != 0)) {
				{
				setState(258);
				((FuncInvocationContext)_localctx).e1 = expression(0);
				 _localctx.arguments.Add(((FuncInvocationContext)_localctx).e1.Ast); 
				setState(266);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(260);
					match(COMMA);
					setState(261);
					((FuncInvocationContext)_localctx).e2 = expression(0);
					 _localctx.arguments.Add(((FuncInvocationContext)_localctx).e2.Ast); 
					}
					}
					setState(268);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
			}

			setState(271);
			match(R_PAR);
			 ((FuncInvocationContext)_localctx).Ast =  new FunctionInvocation(((FuncInvocationContext)_localctx).func.Ast, _localctx.arguments); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class BlockContext extends ParserRuleContext {
		public List<IStatement> Ast = new List<IStatement>();
		public StatementContext st1;
		public StatementContext st2;
		public List<StatementContext> statement() {
			return getRuleContexts(StatementContext.class);
		}
		public StatementContext statement(int i) {
			return getRuleContext(StatementContext.class,i);
		}
		public TerminalNode L_CURL() { return getToken(SeagullParser.L_CURL, 0); }
		public TerminalNode R_CURL() { return getToken(SeagullParser.R_CURL, 0); }
		public BlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_block; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).enterBlock(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).exitBlock(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof SeagullParserVisitor ) return ((SeagullParserVisitor<? extends T>)visitor).visitBlock(this);
			else return visitor.visitChildren(this);
		}
	}

	public final BlockContext block() throws RecognitionException {
		BlockContext _localctx = new BlockContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_block);
		int _la;
		try {
			setState(287);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case IF:
			case WHILE:
			case NEW:
			case RETURN:
			case PRINT:
			case READ:
			case MINUS:
			case NOT:
			case L_PAR:
			case ID:
			case INT_CONSTANT:
			case REAL_CONSTANT:
			case CHAR_CONSTANT:
			case STRING_CONSTANT:
			case BOOLEAN_CONSTANT:
				enterOuterAlt(_localctx, 1);
				{
				setState(274);
				((BlockContext)_localctx).st1 = statement();
				 _localctx.Ast.AddRange(((BlockContext)_localctx).st1.Ast); 
				}
				break;
			case L_CURL:
				enterOuterAlt(_localctx, 2);
				{
				setState(277);
				match(L_CURL);
				setState(283);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << IF) | (1L << WHILE) | (1L << NEW) | (1L << RETURN) | (1L << PRINT) | (1L << READ) | (1L << MINUS) | (1L << NOT) | (1L << L_PAR) | (1L << ID) | (1L << INT_CONSTANT) | (1L << REAL_CONSTANT) | (1L << CHAR_CONSTANT) | (1L << STRING_CONSTANT) | (1L << BOOLEAN_CONSTANT))) != 0)) {
					{
					{
					setState(278);
					((BlockContext)_localctx).st2 = statement();
					 _localctx.Ast.AddRange(((BlockContext)_localctx).st2.Ast); 
					}
					}
					setState(285);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(286);
				match(R_CURL);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FnBlockContext extends ParserRuleContext {
		public List<IStatement> Ast = new List<IStatement>();
		public VariableDefContext variableDef;
		public StatementContext statement;
		public TerminalNode L_CURL() { return getToken(SeagullParser.L_CURL, 0); }
		public TerminalNode R_CURL() { return getToken(SeagullParser.R_CURL, 0); }
		public List<VariableDefContext> variableDef() {
			return getRuleContexts(VariableDefContext.class);
		}
		public VariableDefContext variableDef(int i) {
			return getRuleContext(VariableDefContext.class,i);
		}
		public List<StatementContext> statement() {
			return getRuleContexts(StatementContext.class);
		}
		public StatementContext statement(int i) {
			return getRuleContext(StatementContext.class,i);
		}
		public FnBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_fnBlock; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).enterFnBlock(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).exitFnBlock(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof SeagullParserVisitor ) return ((SeagullParserVisitor<? extends T>)visitor).visitFnBlock(this);
			else return visitor.visitChildren(this);
		}
	}

	public final FnBlockContext fnBlock() throws RecognitionException {
		FnBlockContext _localctx = new FnBlockContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_fnBlock);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(289);
			match(L_CURL);
			setState(298);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << IF) | (1L << WHILE) | (1L << NEW) | (1L << RETURN) | (1L << PRINT) | (1L << READ) | (1L << MINUS) | (1L << NOT) | (1L << L_PAR) | (1L << ID) | (1L << INT_CONSTANT) | (1L << REAL_CONSTANT) | (1L << CHAR_CONSTANT) | (1L << STRING_CONSTANT) | (1L << BOOLEAN_CONSTANT))) != 0)) {
				{
				setState(296);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,23,_ctx) ) {
				case 1:
					{
					{
					setState(290);
					((FnBlockContext)_localctx).variableDef = variableDef();
					 _localctx.Ast.Add(((FnBlockContext)_localctx).variableDef.Ast); 
					}
					}
					break;
				case 2:
					{
					{
					setState(293);
					((FnBlockContext)_localctx).statement = statement();
					 _localctx.Ast.AddRange(((FnBlockContext)_localctx).statement.Ast); 
					}
					}
					break;
				}
				}
				setState(300);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(301);
			match(R_CURL);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StatementContext extends ParserRuleContext {
		public List<IStatement> Ast = new List<IStatement>();
		public Token w;
		public ExpressionContext cond;
		public BlockContext b;
		public Token i;
		public BlockContext b1;
		public BlockContext b2;
		public ExpressionContext e1;
		public ExpressionContext e2;
		public Token r;
		public ExpressionContext e;
		public ReadPrintContext readPrint;
		public FuncInvocationContext funcInvocation;
		public TerminalNode L_PAR() { return getToken(SeagullParser.L_PAR, 0); }
		public TerminalNode R_PAR() { return getToken(SeagullParser.R_PAR, 0); }
		public TerminalNode WHILE() { return getToken(SeagullParser.WHILE, 0); }
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public List<BlockContext> block() {
			return getRuleContexts(BlockContext.class);
		}
		public BlockContext block(int i) {
			return getRuleContext(BlockContext.class,i);
		}
		public TerminalNode IF() { return getToken(SeagullParser.IF, 0); }
		public TerminalNode ELSE() { return getToken(SeagullParser.ELSE, 0); }
		public TerminalNode ASSIGN() { return getToken(SeagullParser.ASSIGN, 0); }
		public TerminalNode SEMI_COL() { return getToken(SeagullParser.SEMI_COL, 0); }
		public TerminalNode RETURN() { return getToken(SeagullParser.RETURN, 0); }
		public ReadPrintContext readPrint() {
			return getRuleContext(ReadPrintContext.class,0);
		}
		public FuncInvocationContext funcInvocation() {
			return getRuleContext(FuncInvocationContext.class,0);
		}
		public StatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).enterStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).exitStatement(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof SeagullParserVisitor ) return ((SeagullParserVisitor<? extends T>)visitor).visitStatement(this);
			else return visitor.visitChildren(this);
		}
	}

	public final StatementContext statement() throws RecognitionException {
		StatementContext _localctx = new StatementContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_statement);
		try {
			setState(340);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,26,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(303);
				((StatementContext)_localctx).w = match(WHILE);
				setState(304);
				match(L_PAR);
				setState(305);
				((StatementContext)_localctx).cond = expression(0);
				setState(306);
				match(R_PAR);
				setState(307);
				((StatementContext)_localctx).b = block();
				 _localctx.Ast.Add(new WhileLoop(((StatementContext)_localctx).w.GetLine(), ((StatementContext)_localctx).w.GetCol(), ((StatementContext)_localctx).cond.Ast, ((StatementContext)_localctx).b.Ast)); 
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(310);
				((StatementContext)_localctx).i = match(IF);
				setState(311);
				match(L_PAR);
				setState(312);
				((StatementContext)_localctx).cond = expression(0);
				setState(313);
				match(R_PAR);
				setState(314);
				((StatementContext)_localctx).b1 = block();
				 _localctx.Ast.Add(new IfStatement(((StatementContext)_localctx).i.GetLine(), ((StatementContext)_localctx).i.GetCol(), ((StatementContext)_localctx).cond.Ast, ((StatementContext)_localctx).b1.Ast)); 
				setState(320);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,25,_ctx) ) {
				case 1:
					{
					setState(316);
					match(ELSE);
					setState(317);
					((StatementContext)_localctx).b2 = block();
					 ((IfStatement)_localctx.Ast[0]).Else = ((StatementContext)_localctx).b2.Ast; 
					}
					break;
				}
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(322);
				((StatementContext)_localctx).e1 = expression(0);
				setState(323);
				match(ASSIGN);
				setState(324);
				((StatementContext)_localctx).e2 = expression(0);
				setState(325);
				match(SEMI_COL);
				 _localctx.Ast.Add(new Assignment(((StatementContext)_localctx).e1.Ast, ((StatementContext)_localctx).e2.Ast)); 
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(328);
				((StatementContext)_localctx).r = match(RETURN);
				setState(329);
				((StatementContext)_localctx).e = expression(0);
				setState(330);
				match(SEMI_COL);
				 _localctx.Ast.Add(new Return(((StatementContext)_localctx).r.GetLine(), ((StatementContext)_localctx).r.GetCol(), ((StatementContext)_localctx).e.Ast)); 
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(333);
				((StatementContext)_localctx).readPrint = readPrint();
				 _localctx.Ast.Add(((StatementContext)_localctx).readPrint.Ast); 
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(336);
				((StatementContext)_localctx).funcInvocation = funcInvocation();
				setState(337);
				match(SEMI_COL);
				 _localctx.Ast.Add(((StatementContext)_localctx).funcInvocation.Ast); 
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ReadPrintContext extends ParserRuleContext {
		public IStatement Ast;
		public Token p;
		public ExpressionContext e;
		public Token r;
		public TerminalNode L_PAR() { return getToken(SeagullParser.L_PAR, 0); }
		public TerminalNode R_PAR() { return getToken(SeagullParser.R_PAR, 0); }
		public TerminalNode SEMI_COL() { return getToken(SeagullParser.SEMI_COL, 0); }
		public TerminalNode PRINT() { return getToken(SeagullParser.PRINT, 0); }
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public TerminalNode READ() { return getToken(SeagullParser.READ, 0); }
		public ReadPrintContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_readPrint; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).enterReadPrint(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).exitReadPrint(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof SeagullParserVisitor ) return ((SeagullParserVisitor<? extends T>)visitor).visitReadPrint(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ReadPrintContext readPrint() throws RecognitionException {
		ReadPrintContext _localctx = new ReadPrintContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_readPrint);
		try {
			setState(356);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case PRINT:
				enterOuterAlt(_localctx, 1);
				{
				setState(342);
				((ReadPrintContext)_localctx).p = match(PRINT);
				setState(343);
				match(L_PAR);
				setState(344);
				((ReadPrintContext)_localctx).e = expression(0);
				setState(345);
				match(R_PAR);
				setState(346);
				match(SEMI_COL);
				 ((ReadPrintContext)_localctx).Ast =  new Print(((ReadPrintContext)_localctx).p.GetLine(), ((ReadPrintContext)_localctx).p.GetCol(), ((ReadPrintContext)_localctx).e.Ast); 
				}
				break;
			case READ:
				enterOuterAlt(_localctx, 2);
				{
				setState(349);
				((ReadPrintContext)_localctx).r = match(READ);
				setState(350);
				match(L_PAR);
				setState(351);
				((ReadPrintContext)_localctx).e = expression(0);
				setState(352);
				match(R_PAR);
				setState(353);
				match(SEMI_COL);
				 ((ReadPrintContext)_localctx).Ast =  new Read(((ReadPrintContext)_localctx).r.GetLine(), ((ReadPrintContext)_localctx).r.GetCol(), ((ReadPrintContext)_localctx).e.Ast); 
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ExpressionContext extends ParserRuleContext {
		public IExpression Ast;
		public ExpressionContext e1;
		public VariableContext variable;
		public LiteralContext literal;
		public FuncInvocationContext funcInvocation;
		public ExpressionContext e;
		public ExpressionContext expression;
		public VariableContext var;
		public Token att;
		public Token n;
		public Token id;
		public Token um;
		public Token not;
		public Token p;
		public PrimitiveContext t;
		public Token op;
		public ExpressionContext e2;
		public VariableContext variable() {
			return getRuleContext(VariableContext.class,0);
		}
		public LiteralContext literal() {
			return getRuleContext(LiteralContext.class,0);
		}
		public FuncInvocationContext funcInvocation() {
			return getRuleContext(FuncInvocationContext.class,0);
		}
		public TerminalNode L_PAR() { return getToken(SeagullParser.L_PAR, 0); }
		public TerminalNode R_PAR() { return getToken(SeagullParser.R_PAR, 0); }
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public TerminalNode DOT() { return getToken(SeagullParser.DOT, 0); }
		public TerminalNode ID() { return getToken(SeagullParser.ID, 0); }
		public TerminalNode NEW() { return getToken(SeagullParser.NEW, 0); }
		public TerminalNode MINUS() { return getToken(SeagullParser.MINUS, 0); }
		public TerminalNode NOT() { return getToken(SeagullParser.NOT, 0); }
		public PrimitiveContext primitive() {
			return getRuleContext(PrimitiveContext.class,0);
		}
		public TerminalNode STAR() { return getToken(SeagullParser.STAR, 0); }
		public TerminalNode SLASH() { return getToken(SeagullParser.SLASH, 0); }
		public TerminalNode PERCENT() { return getToken(SeagullParser.PERCENT, 0); }
		public TerminalNode PLUS() { return getToken(SeagullParser.PLUS, 0); }
		public TerminalNode GREATER_THAN() { return getToken(SeagullParser.GREATER_THAN, 0); }
		public TerminalNode LESS_THAN() { return getToken(SeagullParser.LESS_THAN, 0); }
		public TerminalNode GREATER_EQ_THAN() { return getToken(SeagullParser.GREATER_EQ_THAN, 0); }
		public TerminalNode LESS_EQ_THAN() { return getToken(SeagullParser.LESS_EQ_THAN, 0); }
		public TerminalNode EQUAL() { return getToken(SeagullParser.EQUAL, 0); }
		public TerminalNode NOT_EQUAL() { return getToken(SeagullParser.NOT_EQUAL, 0); }
		public TerminalNode AND() { return getToken(SeagullParser.AND, 0); }
		public TerminalNode OR() { return getToken(SeagullParser.OR, 0); }
		public TerminalNode L_BRACKET() { return getToken(SeagullParser.L_BRACKET, 0); }
		public TerminalNode R_BRACKET() { return getToken(SeagullParser.R_BRACKET, 0); }
		public ExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expression; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).enterExpression(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).exitExpression(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof SeagullParserVisitor ) return ((SeagullParserVisitor<? extends T>)visitor).visitExpression(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ExpressionContext expression() throws RecognitionException {
		return expression(0);
	}

	private ExpressionContext expression(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		ExpressionContext _localctx = new ExpressionContext(_ctx, _parentState);
		ExpressionContext _prevctx = _localctx;
		int _startState = 40;
		enterRecursionRule(_localctx, 40, RULE_expression, _p);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(395);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,28,_ctx) ) {
			case 1:
				{
				setState(359);
				((ExpressionContext)_localctx).variable = variable();
				 ((ExpressionContext)_localctx).Ast =  ((ExpressionContext)_localctx).variable.Ast; 
				}
				break;
			case 2:
				{
				setState(362);
				((ExpressionContext)_localctx).literal = literal();
				 ((ExpressionContext)_localctx).Ast =  ((ExpressionContext)_localctx).literal.Ast; 
				}
				break;
			case 3:
				{
				setState(365);
				((ExpressionContext)_localctx).funcInvocation = funcInvocation();
				 ((ExpressionContext)_localctx).Ast =  ((ExpressionContext)_localctx).funcInvocation.Ast; 
				}
				break;
			case 4:
				{
				setState(368);
				match(L_PAR);
				setState(369);
				((ExpressionContext)_localctx).e = ((ExpressionContext)_localctx).expression = expression(0);
				setState(370);
				match(R_PAR);
				 ((ExpressionContext)_localctx).Ast =  ((ExpressionContext)_localctx).e.Ast; 
				}
				break;
			case 5:
				{
				setState(373);
				((ExpressionContext)_localctx).var = ((ExpressionContext)_localctx).variable = variable();
				setState(374);
				match(DOT);
				setState(375);
				((ExpressionContext)_localctx).att = match(ID);
				 ((ExpressionContext)_localctx).Ast =  new AttributeAccess(((ExpressionContext)_localctx).var.Ast, (((ExpressionContext)_localctx).att!=null?((ExpressionContext)_localctx).att.getText():null)); 
				}
				break;
			case 6:
				{
				setState(378);
				((ExpressionContext)_localctx).n = match(NEW);
				setState(379);
				((ExpressionContext)_localctx).id = match(ID);
				 ((ExpressionContext)_localctx).Ast =  new New(((ExpressionContext)_localctx).n.GetLine(), ((ExpressionContext)_localctx).n.GetCol(), ((ExpressionContext)_localctx).id.GetText()); 
				}
				break;
			case 7:
				{
				setState(381);
				((ExpressionContext)_localctx).um = match(MINUS);
				setState(382);
				((ExpressionContext)_localctx).expression = expression(7);
				 ((ExpressionContext)_localctx).Ast =  new UnaryMinus(((ExpressionContext)_localctx).um.GetLine(), ((ExpressionContext)_localctx).um.GetCol(), ((ExpressionContext)_localctx).expression.Ast); 
				}
				break;
			case 8:
				{
				setState(385);
				((ExpressionContext)_localctx).not = match(NOT);
				setState(386);
				((ExpressionContext)_localctx).expression = expression(6);
				 ((ExpressionContext)_localctx).Ast =  new Negation(((ExpressionContext)_localctx).not.GetLine(), ((ExpressionContext)_localctx).not.GetCol(), ((ExpressionContext)_localctx).expression.Ast); 
				}
				break;
			case 9:
				{
				setState(389);
				((ExpressionContext)_localctx).p = match(L_PAR);
				setState(390);
				((ExpressionContext)_localctx).t = primitive();
				setState(391);
				match(R_PAR);
				setState(392);
				((ExpressionContext)_localctx).e = ((ExpressionContext)_localctx).expression = expression(3);
				 ((ExpressionContext)_localctx).Ast =  new Cast(((ExpressionContext)_localctx).p.GetLine(), ((ExpressionContext)_localctx).p.GetCol(), ((ExpressionContext)_localctx).t.Ast, ((ExpressionContext)_localctx).e.Ast); 
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(425);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,30,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(423);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,29,_ctx) ) {
					case 1:
						{
						_localctx = new ExpressionContext(_parentctx, _parentState);
						_localctx.e1 = _prevctx;
						_localctx.e1 = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(397);
						if (!(precpred(_ctx, 5))) throw new FailedPredicateException(this, "precpred(_ctx, 5)");
						setState(398);
						((ExpressionContext)_localctx).op = _input.LT(1);
						_la = _input.LA(1);
						if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << STAR) | (1L << SLASH) | (1L << PERCENT))) != 0)) ) {
							((ExpressionContext)_localctx).op = (Token)_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(399);
						((ExpressionContext)_localctx).e2 = ((ExpressionContext)_localctx).expression = expression(6);
						 ((ExpressionContext)_localctx).Ast =  new Arithmetic((((ExpressionContext)_localctx).op!=null?((ExpressionContext)_localctx).op.getText():null), ((ExpressionContext)_localctx).e1.Ast, ((ExpressionContext)_localctx).e2.Ast); 
						}
						break;
					case 2:
						{
						_localctx = new ExpressionContext(_parentctx, _parentState);
						_localctx.e1 = _prevctx;
						_localctx.e1 = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(402);
						if (!(precpred(_ctx, 4))) throw new FailedPredicateException(this, "precpred(_ctx, 4)");
						setState(403);
						((ExpressionContext)_localctx).op = _input.LT(1);
						_la = _input.LA(1);
						if ( !(_la==PLUS || _la==MINUS) ) {
							((ExpressionContext)_localctx).op = (Token)_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(404);
						((ExpressionContext)_localctx).e2 = ((ExpressionContext)_localctx).expression = expression(5);
						 ((ExpressionContext)_localctx).Ast =  new Arithmetic((((ExpressionContext)_localctx).op!=null?((ExpressionContext)_localctx).op.getText():null), ((ExpressionContext)_localctx).e1.Ast, ((ExpressionContext)_localctx).e2.Ast); 
						}
						break;
					case 3:
						{
						_localctx = new ExpressionContext(_parentctx, _parentState);
						_localctx.e1 = _prevctx;
						_localctx.e1 = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(407);
						if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
						setState(408);
						((ExpressionContext)_localctx).op = _input.LT(1);
						_la = _input.LA(1);
						if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << EQUAL) | (1L << NOT_EQUAL) | (1L << LESS_THAN) | (1L << GREATER_THAN) | (1L << LESS_EQ_THAN) | (1L << GREATER_EQ_THAN))) != 0)) ) {
							((ExpressionContext)_localctx).op = (Token)_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(409);
						((ExpressionContext)_localctx).e2 = ((ExpressionContext)_localctx).expression = expression(3);
						 ((ExpressionContext)_localctx).Ast =  new Comparison((((ExpressionContext)_localctx).op!=null?((ExpressionContext)_localctx).op.getText():null), ((ExpressionContext)_localctx).e1.Ast, ((ExpressionContext)_localctx).e2.Ast); 
						}
						break;
					case 4:
						{
						_localctx = new ExpressionContext(_parentctx, _parentState);
						_localctx.e1 = _prevctx;
						_localctx.e1 = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(412);
						if (!(precpred(_ctx, 1))) throw new FailedPredicateException(this, "precpred(_ctx, 1)");
						setState(413);
						((ExpressionContext)_localctx).op = _input.LT(1);
						_la = _input.LA(1);
						if ( !(_la==AND || _la==OR) ) {
							((ExpressionContext)_localctx).op = (Token)_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(414);
						((ExpressionContext)_localctx).e2 = ((ExpressionContext)_localctx).expression = expression(2);
						 ((ExpressionContext)_localctx).Ast =  new LogicalOperation((((ExpressionContext)_localctx).op!=null?((ExpressionContext)_localctx).op.getText():null), ((ExpressionContext)_localctx).e1.Ast, ((ExpressionContext)_localctx).e2.Ast); 
						}
						break;
					case 5:
						{
						_localctx = new ExpressionContext(_parentctx, _parentState);
						_localctx.e1 = _prevctx;
						_localctx.e1 = _prevctx;
						pushNewRecursionContext(_localctx, _startState, RULE_expression);
						setState(417);
						if (!(precpred(_ctx, 10))) throw new FailedPredicateException(this, "precpred(_ctx, 10)");
						setState(418);
						match(L_BRACKET);
						setState(419);
						((ExpressionContext)_localctx).e2 = ((ExpressionContext)_localctx).expression = expression(0);
						setState(420);
						match(R_BRACKET);
						 ((ExpressionContext)_localctx).Ast =  new Indexing(((ExpressionContext)_localctx).e1.Ast, ((ExpressionContext)_localctx).e2.Ast); 
						}
						break;
					}
					} 
				}
				setState(427);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,30,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public static class VariableContext extends ParserRuleContext {
		public Variable Ast;
		public Token ID;
		public TerminalNode ID() { return getToken(SeagullParser.ID, 0); }
		public VariableContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_variable; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).enterVariable(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).exitVariable(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof SeagullParserVisitor ) return ((SeagullParserVisitor<? extends T>)visitor).visitVariable(this);
			else return visitor.visitChildren(this);
		}
	}

	public final VariableContext variable() throws RecognitionException {
		VariableContext _localctx = new VariableContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_variable);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(428);
			((VariableContext)_localctx).ID = match(ID);
			 ((VariableContext)_localctx).Ast =  new Variable(((VariableContext)_localctx).ID.GetLine(), ((VariableContext)_localctx).ID.GetCol(), (((VariableContext)_localctx).ID!=null?((VariableContext)_localctx).ID.getText():null)); 
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class LiteralContext extends ParserRuleContext {
		public IExpression Ast;
		public Token i;
		public Token r;
		public Token c;
		public Token s;
		public Token b;
		public TerminalNode INT_CONSTANT() { return getToken(SeagullParser.INT_CONSTANT, 0); }
		public TerminalNode REAL_CONSTANT() { return getToken(SeagullParser.REAL_CONSTANT, 0); }
		public TerminalNode CHAR_CONSTANT() { return getToken(SeagullParser.CHAR_CONSTANT, 0); }
		public TerminalNode STRING_CONSTANT() { return getToken(SeagullParser.STRING_CONSTANT, 0); }
		public TerminalNode BOOLEAN_CONSTANT() { return getToken(SeagullParser.BOOLEAN_CONSTANT, 0); }
		public LiteralContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_literal; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).enterLiteral(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof SeagullParserListener ) ((SeagullParserListener)listener).exitLiteral(this);
		}
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof SeagullParserVisitor ) return ((SeagullParserVisitor<? extends T>)visitor).visitLiteral(this);
			else return visitor.visitChildren(this);
		}
	}

	public final LiteralContext literal() throws RecognitionException {
		LiteralContext _localctx = new LiteralContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_literal);
		try {
			setState(441);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case INT_CONSTANT:
				enterOuterAlt(_localctx, 1);
				{
				setState(431);
				((LiteralContext)_localctx).i = match(INT_CONSTANT);
				 ((LiteralContext)_localctx).Ast =  new IntLiteral(((LiteralContext)_localctx).i.GetLine(), ((LiteralContext)_localctx).i.GetCol(), LexerHelper.LexemeToInt((((LiteralContext)_localctx).i!=null?((LiteralContext)_localctx).i.getText():null))); 
				}
				break;
			case REAL_CONSTANT:
				enterOuterAlt(_localctx, 2);
				{
				setState(433);
				((LiteralContext)_localctx).r = match(REAL_CONSTANT);
				 ((LiteralContext)_localctx).Ast =  new DoubleLiteral(((LiteralContext)_localctx).r.GetLine(), ((LiteralContext)_localctx).r.GetCol(), LexerHelper.LexemeToReal((((LiteralContext)_localctx).r!=null?((LiteralContext)_localctx).r.getText():null))); 
				}
				break;
			case CHAR_CONSTANT:
				enterOuterAlt(_localctx, 3);
				{
				setState(435);
				((LiteralContext)_localctx).c = match(CHAR_CONSTANT);
				 ((LiteralContext)_localctx).Ast =  new CharLiteral(((LiteralContext)_localctx).c.GetLine(), ((LiteralContext)_localctx).c.GetCol(), LexerHelper.LexemeToChar((((LiteralContext)_localctx).c!=null?((LiteralContext)_localctx).c.getText():null))); 
				}
				break;
			case STRING_CONSTANT:
				enterOuterAlt(_localctx, 4);
				{
				setState(437);
				((LiteralContext)_localctx).s = match(STRING_CONSTANT);
				 ((LiteralContext)_localctx).Ast =  new StringLiteral(((LiteralContext)_localctx).s.GetLine(), ((LiteralContext)_localctx).s.GetCol(), (((LiteralContext)_localctx).s!=null?((LiteralContext)_localctx).s.getText():null)); 
				}
				break;
			case BOOLEAN_CONSTANT:
				enterOuterAlt(_localctx, 5);
				{
				setState(439);
				((LiteralContext)_localctx).b = match(BOOLEAN_CONSTANT);
				 ((LiteralContext)_localctx).Ast =  new BooleanLiteral(((LiteralContext)_localctx).b.GetLine(), ((LiteralContext)_localctx).b.GetCol(), LexerHelper.LexemeToBoolean((((LiteralContext)_localctx).b!=null?((LiteralContext)_localctx).b.getText():null))); 
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 2:
			return type_sempred((TypeContext)_localctx, predIndex);
		case 20:
			return expression_sempred((ExpressionContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean type_sempred(TypeContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 2);
		}
		return true;
	}
	private boolean expression_sempred(ExpressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 1:
			return precpred(_ctx, 5);
		case 2:
			return precpred(_ctx, 4);
		case 3:
			return precpred(_ctx, 2);
		case 4:
			return precpred(_ctx, 1);
		case 5:
			return precpred(_ctx, 10);
		}
		return true;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3H\u01be\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\3\2\3\2\3"+
		"\2\7\2\64\n\2\f\2\16\2\67\13\2\3\2\3\2\3\2\7\2<\n\2\f\2\16\2?\13\2\3\2"+
		"\3\2\3\2\3\3\3\3\3\3\3\3\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3"+
		"\4\5\4T\n\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\7\4_\n\4\f\4\16\4b\13"+
		"\4\7\4d\n\4\f\4\16\4g\13\4\3\5\3\5\3\5\3\5\5\5m\n\5\3\5\3\5\3\5\3\5\3"+
		"\5\3\5\3\5\3\5\3\5\5\5x\n\5\5\5z\n\5\3\5\3\5\3\6\3\6\3\6\3\6\3\6\3\6\3"+
		"\6\3\6\3\6\3\6\7\6\u0088\n\6\f\6\16\6\u008b\13\6\3\6\3\6\3\6\3\6\3\6\3"+
		"\6\3\6\3\6\7\6\u0095\n\6\f\6\16\6\u0098\13\6\3\7\3\7\3\7\3\7\3\7\7\7\u009f"+
		"\n\7\f\7\16\7\u00a2\13\7\3\7\3\7\3\7\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\b\5"+
		"\b\u00af\n\b\3\t\3\t\3\t\3\n\3\n\3\13\3\13\3\13\3\13\5\13\u00ba\n\13\3"+
		"\13\3\13\3\13\3\13\5\13\u00c0\n\13\3\13\3\13\3\13\3\13\5\13\u00c6\n\13"+
		"\3\13\3\13\3\13\5\13\u00cb\n\13\3\f\3\f\3\f\3\f\7\f\u00d1\n\f\f\f\16\f"+
		"\u00d4\13\f\3\f\3\f\3\f\3\f\3\f\7\f\u00db\n\f\f\f\16\f\u00de\13\f\3\f"+
		"\3\f\3\f\3\r\3\r\3\r\3\r\3\r\3\r\3\r\3\r\3\r\3\r\3\r\3\r\3\r\3\r\5\r\u00f1"+
		"\n\r\3\16\3\16\3\16\3\16\3\16\3\16\3\17\3\17\3\17\3\17\3\17\3\20\3\20"+
		"\3\20\3\20\3\20\3\21\3\21\3\21\3\21\3\21\3\21\3\21\3\21\7\21\u010b\n\21"+
		"\f\21\16\21\u010e\13\21\5\21\u0110\n\21\3\21\3\21\3\21\3\22\3\22\3\22"+
		"\3\22\3\22\3\22\3\22\7\22\u011c\n\22\f\22\16\22\u011f\13\22\3\22\5\22"+
		"\u0122\n\22\3\23\3\23\3\23\3\23\3\23\3\23\3\23\7\23\u012b\n\23\f\23\16"+
		"\23\u012e\13\23\3\23\3\23\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24"+
		"\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\5\24\u0143\n\24\3\24\3\24\3\24"+
		"\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24\3\24"+
		"\3\24\5\24\u0157\n\24\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25\3\25"+
		"\3\25\3\25\3\25\3\25\5\25\u0167\n\25\3\26\3\26\3\26\3\26\3\26\3\26\3\26"+
		"\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26"+
		"\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26"+
		"\3\26\3\26\5\26\u018e\n\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26"+
		"\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\26"+
		"\3\26\3\26\3\26\7\26\u01aa\n\26\f\26\16\26\u01ad\13\26\3\27\3\27\3\27"+
		"\3\30\3\30\3\30\3\30\3\30\3\30\3\30\3\30\3\30\3\30\5\30\u01bc\n\30\3\30"+
		"\2\4\6*\31\2\4\6\b\n\f\16\20\22\24\26\30\32\34\36 \"$&(*,.\2\7\3\2\31"+
		"\32\3\2$&\3\2()\3\2\638\3\2+,\2\u01dd\2\65\3\2\2\2\4C\3\2\2\2\6S\3\2\2"+
		"\2\bh\3\2\2\2\n}\3\2\2\2\f\u0099\3\2\2\2\16\u00ae\3\2\2\2\20\u00b0\3\2"+
		"\2\2\22\u00b3\3\2\2\2\24\u00ca\3\2\2\2\26\u00cc\3\2\2\2\30\u00f0\3\2\2"+
		"\2\32\u00f2\3\2\2\2\34\u00f8\3\2\2\2\36\u00fd\3\2\2\2 \u0102\3\2\2\2\""+
		"\u0121\3\2\2\2$\u0123\3\2\2\2&\u0156\3\2\2\2(\u0166\3\2\2\2*\u018d\3\2"+
		"\2\2,\u01ae\3\2\2\2.\u01bb\3\2\2\2\60\61\5\4\3\2\61\62\b\2\1\2\62\64\3"+
		"\2\2\2\63\60\3\2\2\2\64\67\3\2\2\2\65\63\3\2\2\2\65\66\3\2\2\2\66=\3\2"+
		"\2\2\67\65\3\2\2\289\5\24\13\29:\b\2\1\2:<\3\2\2\2;8\3\2\2\2<?\3\2\2\2"+
		"=;\3\2\2\2=>\3\2\2\2>@\3\2\2\2?=\3\2\2\2@A\7\2\2\3AB\b\2\1\2B\3\3\2\2"+
		"\2CD\7\33\2\2DE\7=\2\2EF\b\3\1\2F\5\3\2\2\2GH\b\4\1\2HI\5\16\b\2IJ\b\4"+
		"\1\2JT\3\2\2\2KL\5\b\5\2LM\b\4\1\2MT\3\2\2\2NO\5\f\7\2OP\b\4\1\2PT\3\2"+
		"\2\2QR\79\2\2RT\b\4\1\2SG\3\2\2\2SK\3\2\2\2SN\3\2\2\2SQ\3\2\2\2Te\3\2"+
		"\2\2UV\f\4\2\2VW\7-\2\2WX\7:\2\2XY\7.\2\2Y`\b\4\1\2Z[\7-\2\2[\\\7:\2\2"+
		"\\]\7.\2\2]_\b\4\1\2^Z\3\2\2\2_b\3\2\2\2`^\3\2\2\2`a\3\2\2\2ad\3\2\2\2"+
		"b`\3\2\2\2cU\3\2\2\2dg\3\2\2\2ec\3\2\2\2ef\3\2\2\2f\7\3\2\2\2ge\3\2\2"+
		"\2hl\7/\2\2ij\5\n\6\2jk\b\5\1\2km\3\2\2\2li\3\2\2\2lm\3\2\2\2mn\3\2\2"+
		"\2no\7\60\2\2oy\b\5\1\2pw\7\'\2\2qr\5\6\4\2rs\b\5\1\2sx\3\2\2\2tu\5\20"+
		"\t\2uv\b\5\1\2vx\3\2\2\2wq\3\2\2\2wt\3\2\2\2xz\3\2\2\2yp\3\2\2\2yz\3\2"+
		"\2\2z{\3\2\2\2{|\b\5\1\2|\t\3\2\2\2}~\79\2\2~\177\7!\2\2\177\u0080\5\6"+
		"\4\2\u0080\u0089\b\6\1\2\u0081\u0082\7 \2\2\u0082\u0083\79\2\2\u0083\u0084"+
		"\7!\2\2\u0084\u0085\5\6\4\2\u0085\u0086\b\6\1\2\u0086\u0088\3\2\2\2\u0087"+
		"\u0081\3\2\2\2\u0088\u008b\3\2\2\2\u0089\u0087\3\2\2\2\u0089\u008a\3\2"+
		"\2\2\u008a\u0096\3\2\2\2\u008b\u0089\3\2\2\2\u008c\u008d\7 \2\2\u008d"+
		"\u008e\79\2\2\u008e\u008f\7!\2\2\u008f\u0090\5\6\4\2\u0090\u0091\7#\2"+
		"\2\u0091\u0092\5.\30\2\u0092\u0093\b\6\1\2\u0093\u0095\3\2\2\2\u0094\u008c"+
		"\3\2\2\2\u0095\u0098\3\2\2\2\u0096\u0094\3\2\2\2\u0096\u0097\3\2\2\2\u0097"+
		"\13\3\2\2\2\u0098\u0096\3\2\2\2\u0099\u009a\7\t\2\2\u009a\u00a0\7\61\2"+
		"\2\u009b\u009c\5\30\r\2\u009c\u009d\b\7\1\2\u009d\u009f\3\2\2\2\u009e"+
		"\u009b\3\2\2\2\u009f\u00a2\3\2\2\2\u00a0\u009e\3\2\2\2\u00a0\u00a1\3\2"+
		"\2\2\u00a1\u00a3\3\2\2\2\u00a2\u00a0\3\2\2\2\u00a3\u00a4\7\62\2\2\u00a4"+
		"\u00a5\b\7\1\2\u00a5\r\3\2\2\2\u00a6\u00a7\7\5\2\2\u00a7\u00af\b\b\1\2"+
		"\u00a8\u00a9\7\6\2\2\u00a9\u00af\b\b\1\2\u00aa\u00ab\7\7\2\2\u00ab\u00af"+
		"\b\b\1\2\u00ac\u00ad\7\b\2\2\u00ad\u00af\b\b\1\2\u00ae\u00a6\3\2\2\2\u00ae"+
		"\u00a8\3\2\2\2\u00ae\u00aa\3\2\2\2\u00ae\u00ac\3\2\2\2\u00af\17\3\2\2"+
		"\2\u00b0\u00b1\7\4\2\2\u00b1\u00b2\b\t\1\2\u00b2\21\3\2\2\2\u00b3\u00b4"+
		"\t\2\2\2\u00b4\23\3\2\2\2\u00b5\u00b6\5\26\f\2\u00b6\u00b7\b\13\1\2\u00b7"+
		"\u00cb\3\2\2\2\u00b8\u00ba\5\22\n\2\u00b9\u00b8\3\2\2\2\u00b9\u00ba\3"+
		"\2\2\2\u00ba\u00bb\3\2\2\2\u00bb\u00bc\5\32\16\2\u00bc\u00bd\b\13\1\2"+
		"\u00bd\u00cb\3\2\2\2\u00be\u00c0\5\22\n\2\u00bf\u00be\3\2\2\2\u00bf\u00c0"+
		"\3\2\2\2\u00c0\u00c1\3\2\2\2\u00c1\u00c2\5\30\r\2\u00c2\u00c3\b\13\1\2"+
		"\u00c3\u00cb\3\2\2\2\u00c4\u00c6\5\22\n\2\u00c5\u00c4\3\2\2\2\u00c5\u00c6"+
		"\3\2\2\2\u00c6\u00c7\3\2\2\2\u00c7\u00c8\5\34\17\2\u00c8\u00c9\b\13\1"+
		"\2\u00c9\u00cb\3\2\2\2\u00ca\u00b5\3\2\2\2\u00ca\u00b9\3\2\2\2\u00ca\u00bf"+
		"\3\2\2\2\u00ca\u00c5\3\2\2\2\u00cb\25\3\2\2\2\u00cc\u00d2\7\35\2\2\u00cd"+
		"\u00ce\79\2\2\u00ce\u00cf\7\37\2\2\u00cf\u00d1\b\f\1\2\u00d0\u00cd\3\2"+
		"\2\2\u00d1\u00d4\3\2\2\2\u00d2\u00d0\3\2\2\2\u00d2\u00d3\3\2\2\2\u00d3"+
		"\u00d5\3\2\2\2\u00d4\u00d2\3\2\2\2\u00d5\u00d6\79\2\2\u00d6\u00dc\7\61"+
		"\2\2\u00d7\u00d8\5\24\13\2\u00d8\u00d9\b\f\1\2\u00d9\u00db\3\2\2\2\u00da"+
		"\u00d7\3\2\2\2\u00db\u00de\3\2\2\2\u00dc\u00da\3\2\2\2\u00dc\u00dd\3\2"+
		"\2\2\u00dd\u00df\3\2\2\2\u00de\u00dc\3\2\2\2\u00df\u00e0\7\62\2\2\u00e0"+
		"\u00e1\b\f\1\2\u00e1\27\3\2\2\2\u00e2\u00e3\79\2\2\u00e3\u00e4\7!\2\2"+
		"\u00e4\u00e5\5\6\4\2\u00e5\u00e6\7\"\2\2\u00e6\u00e7\b\r\1\2\u00e7\u00f1"+
		"\3\2\2\2\u00e8\u00e9\79\2\2\u00e9\u00ea\7!\2\2\u00ea\u00eb\5\6\4\2\u00eb"+
		"\u00ec\7#\2\2\u00ec\u00ed\5*\26\2\u00ed\u00ee\7\"\2\2\u00ee\u00ef\b\r"+
		"\1\2\u00ef\u00f1\3\2\2\2\u00f0\u00e2\3\2\2\2\u00f0\u00e8\3\2\2\2\u00f1"+
		"\31\3\2\2\2\u00f2\u00f3\79\2\2\u00f3\u00f4\7!\2\2\u00f4\u00f5\5\b\5\2"+
		"\u00f5\u00f6\5$\23\2\u00f6\u00f7\b\16\1\2\u00f7\33\3\2\2\2\u00f8\u00f9"+
		"\79\2\2\u00f9\u00fa\7!\2\2\u00fa\u00fb\5\f\7\2\u00fb\u00fc\b\17\1\2\u00fc"+
		"\35\3\2\2\2\u00fd\u00fe\7\13\2\2\u00fe\u00ff\79\2\2\u00ff\u0100\5\b\5"+
		"\2\u0100\u0101\b\20\1\2\u0101\37\3\2\2\2\u0102\u0103\5,\27\2\u0103\u010f"+
		"\7/\2\2\u0104\u0105\5*\26\2\u0105\u010c\b\21\1\2\u0106\u0107\7 \2\2\u0107"+
		"\u0108\5*\26\2\u0108\u0109\b\21\1\2\u0109\u010b\3\2\2\2\u010a\u0106\3"+
		"\2\2\2\u010b\u010e\3\2\2\2\u010c\u010a\3\2\2\2\u010c\u010d\3\2\2\2\u010d"+
		"\u0110\3\2\2\2\u010e\u010c\3\2\2\2\u010f\u0104\3\2\2\2\u010f\u0110\3\2"+
		"\2\2\u0110\u0111\3\2\2\2\u0111\u0112\7\60\2\2\u0112\u0113\b\21\1\2\u0113"+
		"!\3\2\2\2\u0114\u0115\5&\24\2\u0115\u0116\b\22\1\2\u0116\u0122\3\2\2\2"+
		"\u0117\u011d\7\61\2\2\u0118\u0119\5&\24\2\u0119\u011a\b\22\1\2\u011a\u011c"+
		"\3\2\2\2\u011b\u0118\3\2\2\2\u011c\u011f\3\2\2\2\u011d\u011b\3\2\2\2\u011d"+
		"\u011e\3\2\2\2\u011e\u0120\3\2\2\2\u011f\u011d\3\2\2\2\u0120\u0122\7\62"+
		"\2\2\u0121\u0114\3\2\2\2\u0121\u0117\3\2\2\2\u0122#\3\2\2\2\u0123\u012c"+
		"\7\61\2\2\u0124\u0125\5\30\r\2\u0125\u0126\b\23\1\2\u0126\u012b\3\2\2"+
		"\2\u0127\u0128\5&\24\2\u0128\u0129\b\23\1\2\u0129\u012b\3\2\2\2\u012a"+
		"\u0124\3\2\2\2\u012a\u0127\3\2\2\2\u012b\u012e\3\2\2\2\u012c\u012a\3\2"+
		"\2\2\u012c\u012d\3\2\2\2\u012d\u012f\3\2\2\2\u012e\u012c\3\2\2\2\u012f"+
		"\u0130\7\62\2\2\u0130%\3\2\2\2\u0131\u0132\7\20\2\2\u0132\u0133\7/\2\2"+
		"\u0133\u0134\5*\26\2\u0134\u0135\7\60\2\2\u0135\u0136\5\"\22\2\u0136\u0137"+
		"\b\24\1\2\u0137\u0157\3\2\2\2\u0138\u0139\7\16\2\2\u0139\u013a\7/\2\2"+
		"\u013a\u013b\5*\26\2\u013b\u013c\7\60\2\2\u013c\u013d\5\"\22\2\u013d\u0142"+
		"\b\24\1\2\u013e\u013f\7\17\2\2\u013f\u0140\5\"\22\2\u0140\u0141\b\24\1"+
		"\2\u0141\u0143\3\2\2\2\u0142\u013e\3\2\2\2\u0142\u0143\3\2\2\2\u0143\u0157"+
		"\3\2\2\2\u0144\u0145\5*\26\2\u0145\u0146\7#\2\2\u0146\u0147\5*\26\2\u0147"+
		"\u0148\7\"\2\2\u0148\u0149\b\24\1\2\u0149\u0157\3\2\2\2\u014a\u014b\7"+
		"\24\2\2\u014b\u014c\5*\26\2\u014c\u014d\7\"\2\2\u014d\u014e\b\24\1\2\u014e"+
		"\u0157\3\2\2\2\u014f\u0150\5(\25\2\u0150\u0151\b\24\1\2\u0151\u0157\3"+
		"\2\2\2\u0152\u0153\5 \21\2\u0153\u0154\7\"\2\2\u0154\u0155\b\24\1\2\u0155"+
		"\u0157\3\2\2\2\u0156\u0131\3\2\2\2\u0156\u0138\3\2\2\2\u0156\u0144\3\2"+
		"\2\2\u0156\u014a\3\2\2\2\u0156\u014f\3\2\2\2\u0156\u0152\3\2\2\2\u0157"+
		"\'\3\2\2\2\u0158\u0159\7\25\2\2\u0159\u015a\7/\2\2\u015a\u015b\5*\26\2"+
		"\u015b\u015c\7\60\2\2\u015c\u015d\7\"\2\2\u015d\u015e\b\25\1\2\u015e\u0167"+
		"\3\2\2\2\u015f\u0160\7\26\2\2\u0160\u0161\7/\2\2\u0161\u0162\5*\26\2\u0162"+
		"\u0163\7\60\2\2\u0163\u0164\7\"\2\2\u0164\u0165\b\25\1\2\u0165\u0167\3"+
		"\2\2\2\u0166\u0158\3\2\2\2\u0166\u015f\3\2\2\2\u0167)\3\2\2\2\u0168\u0169"+
		"\b\26\1\2\u0169\u016a\5,\27\2\u016a\u016b\b\26\1\2\u016b\u018e\3\2\2\2"+
		"\u016c\u016d\5.\30\2\u016d\u016e\b\26\1\2\u016e\u018e\3\2\2\2\u016f\u0170"+
		"\5 \21\2\u0170\u0171\b\26\1\2\u0171\u018e\3\2\2\2\u0172\u0173\7/\2\2\u0173"+
		"\u0174\5*\26\2\u0174\u0175\7\60\2\2\u0175\u0176\b\26\1\2\u0176\u018e\3"+
		"\2\2\2\u0177\u0178\5,\27\2\u0178\u0179\7\37\2\2\u0179\u017a\79\2\2\u017a"+
		"\u017b\b\26\1\2\u017b\u018e\3\2\2\2\u017c\u017d\7\22\2\2\u017d\u017e\7"+
		"9\2\2\u017e\u018e\b\26\1\2\u017f\u0180\7)\2\2\u0180\u0181\5*\26\t\u0181"+
		"\u0182\b\26\1\2\u0182\u018e\3\2\2\2\u0183\u0184\7*\2\2\u0184\u0185\5*"+
		"\26\b\u0185\u0186\b\26\1\2\u0186\u018e\3\2\2\2\u0187\u0188\7/\2\2\u0188"+
		"\u0189\5\16\b\2\u0189\u018a\7\60\2\2\u018a\u018b\5*\26\5\u018b\u018c\b"+
		"\26\1\2\u018c\u018e\3\2\2\2\u018d\u0168\3\2\2\2\u018d\u016c\3\2\2\2\u018d"+
		"\u016f\3\2\2\2\u018d\u0172\3\2\2\2\u018d\u0177\3\2\2\2\u018d\u017c\3\2"+
		"\2\2\u018d\u017f\3\2\2\2\u018d\u0183\3\2\2\2\u018d\u0187\3\2\2\2\u018e"+
		"\u01ab\3\2\2\2\u018f\u0190\f\7\2\2\u0190\u0191\t\3\2\2\u0191\u0192\5*"+
		"\26\b\u0192\u0193\b\26\1\2\u0193\u01aa\3\2\2\2\u0194\u0195\f\6\2\2\u0195"+
		"\u0196\t\4\2\2\u0196\u0197\5*\26\7\u0197\u0198\b\26\1\2\u0198\u01aa\3"+
		"\2\2\2\u0199\u019a\f\4\2\2\u019a\u019b\t\5\2\2\u019b\u019c\5*\26\5\u019c"+
		"\u019d\b\26\1\2\u019d\u01aa\3\2\2\2\u019e\u019f\f\3\2\2\u019f\u01a0\t"+
		"\6\2\2\u01a0\u01a1\5*\26\4\u01a1\u01a2\b\26\1\2\u01a2\u01aa\3\2\2\2\u01a3"+
		"\u01a4\f\f\2\2\u01a4\u01a5\7-\2\2\u01a5\u01a6\5*\26\2\u01a6\u01a7\7.\2"+
		"\2\u01a7\u01a8\b\26\1\2\u01a8\u01aa\3\2\2\2\u01a9\u018f\3\2\2\2\u01a9"+
		"\u0194\3\2\2\2\u01a9\u0199\3\2\2\2\u01a9\u019e\3\2\2\2\u01a9\u01a3\3\2"+
		"\2\2\u01aa\u01ad\3\2\2\2\u01ab\u01a9\3\2\2\2\u01ab\u01ac\3\2\2\2\u01ac"+
		"+\3\2\2\2\u01ad\u01ab\3\2\2\2\u01ae\u01af\79\2\2\u01af\u01b0\b\27\1\2"+
		"\u01b0-\3\2\2\2\u01b1\u01b2\7:\2\2\u01b2\u01bc\b\30\1\2\u01b3\u01b4\7"+
		";\2\2\u01b4\u01bc\b\30\1\2\u01b5\u01b6\7<\2\2\u01b6\u01bc\b\30\1\2\u01b7"+
		"\u01b8\7=\2\2\u01b8\u01bc\b\30\1\2\u01b9\u01ba\7>\2\2\u01ba\u01bc\b\30"+
		"\1\2\u01bb\u01b1\3\2\2\2\u01bb\u01b3\3\2\2\2\u01bb\u01b5\3\2\2\2\u01bb"+
		"\u01b7\3\2\2\2\u01bb\u01b9\3\2\2\2\u01bc/\3\2\2\2\"\65=S`elwy\u0089\u0096"+
		"\u00a0\u00ae\u00b9\u00bf\u00c5\u00ca\u00d2\u00dc\u00f0\u010c\u010f\u011d"+
		"\u0121\u012a\u012c\u0142\u0156\u0166\u018d\u01a9\u01ab\u01bb";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}