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
		SHARP=1, VOID=2, INT=3, CHAR=4, DOUBLE=5, STRING=6, STRUCT=7, ENUM=8, 
		DELEGATE=9, TRUE=10, FALSE=11, IF=12, ELSE=13, WHILE=14, FOR=15, NEW=16, 
		DELETE=17, RETURN=18, PRINT=19, READ=20, ASSERT=21, DELAY=22, PUBLIC=23, 
		PRIVATE=24, LOAD=25, IMPORT=26, NAMESPACE=27, DOT=28, COMMA=29, COL=30, 
		SEMI_COL=31, ASSIGN=32, STAR=33, SLASH=34, PERCENT=35, ARROW=36, PLUS=37, 
		MINUS=38, NOT=39, AND=40, OR=41, L_BRACKET=42, R_BRACKET=43, L_PAR=44, 
		R_PAR=45, L_CURL=46, R_CURL=47, EQUAL=48, NOT_EQUAL=49, LESS_THAN=50, 
		GREATER_THAN=51, LESS_EQ_THAN=52, GREATER_EQ_THAN=53, ID=54, INT_CONSTANT=55, 
		REAL_CONSTANT=56, CHAR_CONSTANT=57, STRING_CONSTANT=58, BOOLEAN_CONSTANT=59, 
		SL_COMMENT=60, ML_COMMENT=61, BLANKS=62, DIR_DEFINE=63, DIR_IF=64, DIR_ELIF=65, 
		DIR_ELSE=66, DIR_WHITESPACE=67, DIR_ML_COMMENT=68, DIR_NEWLINE=69;
	public const int
		RULE_preprocessorDirective = 0, RULE_preprocessorExpression = 1;
	public static readonly string[] ruleNames = {
		"preprocessorDirective", "preprocessorExpression"
	};

	private static readonly string[] _LiteralNames = {
		null, "'#'", "'void'", "'int'", "'char'", "'double'", "'string'", "'struct'", 
		"'enum'", "'delegate'", "'true'", "'false'", null, null, "'while'", "'for'", 
		"'new'", "'delete'", "'return'", "'print'", "'read'", "'assert'", "'delay'", 
		"'public'", "'private'", "'load'", "'import'", "'namespace'", "'.'", "','", 
		"':'", "';'", "'='", "'*'", "'/'", "'%'", "'->'", "'+'", "'-'", "'!'", 
		"'&&'", "'||'", "'['", "']'", "'('", "')'", "'{'", "'}'", "'=='", "'!='", 
		"'<'", "'>'", "'<='", "'>='", null, null, null, null, null, null, null, 
		null, null, "'define'", null, "'elif'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "SHARP", "VOID", "INT", "CHAR", "DOUBLE", "STRING", "STRUCT", "ENUM", 
		"DELEGATE", "TRUE", "FALSE", "IF", "ELSE", "WHILE", "FOR", "NEW", "DELETE", 
		"RETURN", "PRINT", "READ", "ASSERT", "DELAY", "PUBLIC", "PRIVATE", "LOAD", 
		"IMPORT", "NAMESPACE", "DOT", "COMMA", "COL", "SEMI_COL", "ASSIGN", "STAR", 
		"SLASH", "PERCENT", "ARROW", "PLUS", "MINUS", "NOT", "AND", "OR", "L_BRACKET", 
		"R_BRACKET", "L_PAR", "R_PAR", "L_CURL", "R_CURL", "EQUAL", "NOT_EQUAL", 
		"LESS_THAN", "GREATER_THAN", "LESS_EQ_THAN", "GREATER_EQ_THAN", "ID", 
		"INT_CONSTANT", "REAL_CONSTANT", "CHAR_CONSTANT", "STRING_CONSTANT", "BOOLEAN_CONSTANT", 
		"SL_COMMENT", "ML_COMMENT", "BLANKS", "DIR_DEFINE", "DIR_IF", "DIR_ELIF", 
		"DIR_ELSE", "DIR_WHITESPACE", "DIR_ML_COMMENT", "DIR_NEWLINE"
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
		'\x5964', '\x3', 'G', '\xF', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', 
		'\t', '\x3', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x5', 
		'\x2', '\v', '\n', '\x2', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x2', 
		'\x2', '\x4', '\x2', '\x4', '\x2', '\x3', '\x3', '\x2', '\f', '\r', '\x2', 
		'\r', '\x2', '\n', '\x3', '\x2', '\x2', '\x2', '\x4', '\f', '\x3', '\x2', 
		'\x2', '\x2', '\x6', '\a', '\a', '\x41', '\x2', '\x2', '\a', '\v', '\a', 
		'\x38', '\x2', '\x2', '\b', '\t', '\a', '\x42', '\x2', '\x2', '\t', '\v', 
		'\x5', '\x4', '\x3', '\x2', '\n', '\x6', '\x3', '\x2', '\x2', '\x2', '\n', 
		'\b', '\x3', '\x2', '\x2', '\x2', '\v', '\x3', '\x3', '\x2', '\x2', '\x2', 
		'\f', '\r', '\t', '\x2', '\x2', '\x2', '\r', '\x5', '\x3', '\x2', '\x2', 
		'\x2', '\x3', '\n',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
