//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Grammar/SeagullPreprocessorParser.g4 by ANTLR 4.7.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public partial class SeagullPreprocessorParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		SHARP=1, VOID=2, INT=3, CHAR=4, DOUBLE=5, STRING=6, STRUCT=7, LONG=8, 
		BYTE=9, ENUM=10, DELEGATE=11, NULL=12, TRUE=13, FALSE=14, IF=15, ELSE=16, 
		WHILE=17, FOR=18, IN=19, SWITCH=20, CASE=21, BREAK=22, CONTINUE=23, NEW=24, 
		DELETE=25, RETURN=26, PRINT=27, READ=28, ASSERT=29, DELAY=30, PUBLIC=31, 
		PRIVATE=32, LOAD=33, IMPORT=34, NAMESPACE=35, USING=36, IS=37, DOT=38, 
		COMMA=39, COL=40, SEMI_COL=41, ASSIGN=42, STAR=43, SLASH=44, PERCENT=45, 
		ARROW=46, PLUS=47, MINUS=48, PLUS_PLUS=49, MINUS_MINUS=50, ASSIGN_MUL=51, 
		ASSIGN_DIV=52, ASSIGN_MOD=53, ASSIGN_SUM=54, ASSIGN_SUB=55, NOT=56, AND=57, 
		OR=58, L_BRACKET=59, R_BRACKET=60, L_PAR=61, R_PAR=62, L_CURL=63, R_CURL=64, 
		BIT_AND=65, BIT_OR=66, BIT_XOR=67, BIT_NOT=68, BIT_RIGHT=69, BIT_LEFT=70, 
		EQUAL=71, NOT_EQUAL=72, LESS_THAN=73, GREATER_THAN=74, LESS_EQ_THAN=75, 
		GREATER_EQ_THAN=76, ID=77, INT_CONSTANT=78, REAL_CONSTANT=79, CHAR_CONSTANT=80, 
		STRING_CONSTANT=81, BOOLEAN_CONSTANT=82, SL_COMMENT=83, ML_COMMENT=84, 
		BLANKS=85, DIR_DEFINE=86, DIR_IF=87, DIR_ELIF=88, DIR_ELSE=89, DIR_WHITESPACE=90, 
		DIR_ML_COMMENT=91, DIR_NEWLINE=92;
	public const int
		RULE_preprocessorDirective = 0, RULE_preprocessorExpression = 1;
	public static readonly string[] ruleNames = {
		"preprocessorDirective", "preprocessorExpression"
	};

	private static readonly string[] _LiteralNames = {
		null, "'#'", "'void'", "'int'", "'char'", "'double'", "'string'", "'struct'", 
		"'long'", "'byte'", "'enum'", "'delegate'", "'null'", "'true'", "'false'", 
		null, null, "'while'", "'for'", "'in'", "'switch'", "'case'", "'break'", 
		"'continue'", "'new'", "'delete'", "'return'", "'print'", "'read'", "'assert'", 
		"'delay'", "'public'", "'private'", "'load'", "'import'", "'namespace'", 
		"'using'", "'is'", "'.'", "','", "':'", "';'", "'='", "'*'", "'/'", "'%'", 
		"'->'", "'+'", "'-'", "'++'", "'--'", "'*='", "'/='", "'%='", "'+='", 
		"'-='", "'!'", "'&&'", "'||'", "'['", "']'", "'('", "')'", "'{'", "'}'", 
		"'&'", "'|'", "'^'", "'~'", "'>>'", "'<<'", "'=='", "'!='", "'<'", "'>'", 
		"'<='", "'>='", null, null, null, null, null, null, null, null, null, 
		"'define'", null, "'elif'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "SHARP", "VOID", "INT", "CHAR", "DOUBLE", "STRING", "STRUCT", "LONG", 
		"BYTE", "ENUM", "DELEGATE", "NULL", "TRUE", "FALSE", "IF", "ELSE", "WHILE", 
		"FOR", "IN", "SWITCH", "CASE", "BREAK", "CONTINUE", "NEW", "DELETE", "RETURN", 
		"PRINT", "READ", "ASSERT", "DELAY", "PUBLIC", "PRIVATE", "LOAD", "IMPORT", 
		"NAMESPACE", "USING", "IS", "DOT", "COMMA", "COL", "SEMI_COL", "ASSIGN", 
		"STAR", "SLASH", "PERCENT", "ARROW", "PLUS", "MINUS", "PLUS_PLUS", "MINUS_MINUS", 
		"ASSIGN_MUL", "ASSIGN_DIV", "ASSIGN_MOD", "ASSIGN_SUM", "ASSIGN_SUB", 
		"NOT", "AND", "OR", "L_BRACKET", "R_BRACKET", "L_PAR", "R_PAR", "L_CURL", 
		"R_CURL", "BIT_AND", "BIT_OR", "BIT_XOR", "BIT_NOT", "BIT_RIGHT", "BIT_LEFT", 
		"EQUAL", "NOT_EQUAL", "LESS_THAN", "GREATER_THAN", "LESS_EQ_THAN", "GREATER_EQ_THAN", 
		"ID", "INT_CONSTANT", "REAL_CONSTANT", "CHAR_CONSTANT", "STRING_CONSTANT", 
		"BOOLEAN_CONSTANT", "SL_COMMENT", "ML_COMMENT", "BLANKS", "DIR_DEFINE", 
		"DIR_IF", "DIR_ELIF", "DIR_ELSE", "DIR_WHITESPACE", "DIR_ML_COMMENT", 
		"DIR_NEWLINE"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "SeagullPreprocessorParser.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static SeagullPreprocessorParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public SeagullPreprocessorParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public SeagullPreprocessorParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class PreprocessorDirectiveContext : ParserRuleContext {
		public ITerminalNode DIR_DEFINE() { return GetToken(SeagullPreprocessorParser.DIR_DEFINE, 0); }
		public ITerminalNode ID() { return GetToken(SeagullPreprocessorParser.ID, 0); }
		public ITerminalNode DIR_IF() { return GetToken(SeagullPreprocessorParser.DIR_IF, 0); }
		public PreprocessorExpressionContext preprocessorExpression() {
			return GetRuleContext<PreprocessorExpressionContext>(0);
		}
		public PreprocessorDirectiveContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_preprocessorDirective; } }
	}

	[RuleVersion(0)]
	public PreprocessorDirectiveContext preprocessorDirective() {
		PreprocessorDirectiveContext _localctx = new PreprocessorDirectiveContext(Context, State);
		EnterRule(_localctx, 0, RULE_preprocessorDirective);
		try {
			State = 8;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case DIR_DEFINE:
				EnterOuterAlt(_localctx, 1);
				{
				State = 4; Match(DIR_DEFINE);
				State = 5; Match(ID);
				}
				break;
			case DIR_IF:
				EnterOuterAlt(_localctx, 2);
				{
				State = 6; Match(DIR_IF);
				State = 7; preprocessorExpression();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class PreprocessorExpressionContext : ParserRuleContext {
		public ITerminalNode TRUE() { return GetToken(SeagullPreprocessorParser.TRUE, 0); }
		public ITerminalNode FALSE() { return GetToken(SeagullPreprocessorParser.FALSE, 0); }
		public PreprocessorExpressionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_preprocessorExpression; } }
	}

	[RuleVersion(0)]
	public PreprocessorExpressionContext preprocessorExpression() {
		PreprocessorExpressionContext _localctx = new PreprocessorExpressionContext(Context, State);
		EnterRule(_localctx, 2, RULE_preprocessorExpression);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 10;
			_la = TokenStream.LA(1);
			if ( !(_la==TRUE || _la==FALSE) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '^', '\xF', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x5', 
		'\x2', '\v', '\n', '\x2', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x2', 
		'\x2', '\x4', '\x2', '\x4', '\x2', '\x3', '\x3', '\x2', '\xF', '\x10', 
		'\x2', '\r', '\x2', '\n', '\x3', '\x2', '\x2', '\x2', '\x4', '\f', '\x3', 
		'\x2', '\x2', '\x2', '\x6', '\a', '\a', 'X', '\x2', '\x2', '\a', '\v', 
		'\a', 'O', '\x2', '\x2', '\b', '\t', '\a', 'Y', '\x2', '\x2', '\t', '\v', 
		'\x5', '\x4', '\x3', '\x2', '\n', '\x6', '\x3', '\x2', '\x2', '\x2', '\n', 
		'\b', '\x3', '\x2', '\x2', '\x2', '\v', '\x3', '\x3', '\x2', '\x2', '\x2', 
		'\f', '\r', '\t', '\x2', '\x2', '\x2', '\r', '\x5', '\x3', '\x2', '\x2', 
		'\x2', '\x3', '\n',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
