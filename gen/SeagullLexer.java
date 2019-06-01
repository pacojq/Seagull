// Generated from D:/Dev/Seagull/Seagull/Grammar\SeagullLexer.g4 by ANTLR 4.7.2
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class SeagullLexer extends Lexer {
	static { RuntimeMetaData.checkVersion("4.7.2", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		SHARP=1, VOID=2, INT=3, CHAR=4, DOUBLE=5, STRING=6, STRUCT=7, LONG=8, 
		BYTE=9, ENUM=10, DELEGATE=11, NULL=12, PTR=13, TRUE=14, FALSE=15, IF=16, 
		ELSE=17, WHILE=18, FOR=19, IN=20, SWITCH=21, CASE=22, BREAK=23, CONTINUE=24, 
		NEW=25, DELETE=26, RETURN=27, PRINT=28, READ=29, ASSERT=30, DELAY=31, 
		PUBLIC=32, PRIVATE=33, LOAD=34, IMPORT=35, NAMESPACE=36, OWNED=37, IS=38, 
		DEFAULT=39, DOT=40, COMMA=41, COL=42, SEMI_COL=43, ASSIGN=44, STAR=45, 
		SLASH=46, PERCENT=47, ARROW=48, QUESTION=49, PLUS=50, MINUS=51, PLUS_PLUS=52, 
		MINUS_MINUS=53, ASSIGN_MUL=54, ASSIGN_DIV=55, ASSIGN_MOD=56, ASSIGN_SUM=57, 
		ASSIGN_SUB=58, NOT=59, AND=60, OR=61, L_BRACKET=62, R_BRACKET=63, L_PAR=64, 
		R_PAR=65, L_CURL=66, R_CURL=67, BIT_AND=68, BIT_OR=69, BIT_XOR=70, BIT_NOT=71, 
		BIT_RIGHT=72, BIT_LEFT=73, EQUAL=74, NOT_EQUAL=75, LESS_THAN=76, GREATER_THAN=77, 
		LESS_EQ_THAN=78, GREATER_EQ_THAN=79, ID=80, INT_CONSTANT=81, REAL_CONSTANT=82, 
		CHAR_CONSTANT=83, STRING_CONSTANT=84, BOOLEAN_CONSTANT=85, SL_COMMENT=86, 
		ML_COMMENT=87, BLANKS=88, DIR_DEFINE=89, DIR_IF=90, DIR_ELIF=91, DIR_ELSE=92, 
		DIR_WHITESPACE=93, DIR_ML_COMMENT=94, DIR_NEWLINE=95;
	public static final int
		DIRECTIVE=2;
	public static final int
		DIRECTIVE_MODE=1;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN", "DIRECTIVE"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE", "DIRECTIVE_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"DIGIT", "LETTER", "REAL", "NL", "SHARP", "VOID", "INT", "CHAR", "DOUBLE", 
			"STRING", "STRUCT", "LONG", "BYTE", "ENUM", "DELEGATE", "NULL", "PTR", 
			"TRUE", "FALSE", "IF", "ELSE", "WHILE", "FOR", "IN", "SWITCH", "CASE", 
			"BREAK", "CONTINUE", "NEW", "DELETE", "RETURN", "PRINT", "READ", "ASSERT", 
			"DELAY", "PUBLIC", "PRIVATE", "LOAD", "IMPORT", "NAMESPACE", "OWNED", 
			"IS", "DEFAULT", "DOT", "COMMA", "COL", "SEMI_COL", "ASSIGN", "STAR", 
			"SLASH", "PERCENT", "ARROW", "QUESTION", "PLUS", "MINUS", "PLUS_PLUS", 
			"MINUS_MINUS", "ASSIGN_MUL", "ASSIGN_DIV", "ASSIGN_MOD", "ASSIGN_SUM", 
			"ASSIGN_SUB", "NOT", "AND", "OR", "L_BRACKET", "R_BRACKET", "L_PAR", 
			"R_PAR", "L_CURL", "R_CURL", "BIT_AND", "BIT_OR", "BIT_XOR", "BIT_NOT", 
			"BIT_RIGHT", "BIT_LEFT", "EQUAL", "NOT_EQUAL", "LESS_THAN", "GREATER_THAN", 
			"LESS_EQ_THAN", "GREATER_EQ_THAN", "ID", "INT_CONSTANT", "REAL_CONSTANT", 
			"CHAR_CONSTANT", "STRING_CONSTANT", "BOOLEAN_CONSTANT", "SL_COMMENT", 
			"ML_COMMENT", "BLANKS", "DIR_DEFINE", "DIR_IF", "DIR_ELIF", "DIR_ELSE", 
			"DIR_WHITESPACE", "DIR_ML_COMMENT", "DIR_NEWLINE"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'#'", "'void'", "'int'", "'char'", "'double'", "'string'", "'struct'", 
			"'long'", "'byte'", "'enum'", "'delegate'", "'null'", "'ptr'", "'true'", 
			"'false'", null, null, "'while'", "'for'", "'in'", "'switch'", "'case'", 
			"'break'", "'continue'", "'new'", "'delete'", "'return'", "'print'", 
			"'read'", "'assert'", "'delay'", "'public'", "'private'", "'load'", "'import'", 
			"'namespace'", "'owned'", "'is'", "'default'", "'.'", "','", "':'", "';'", 
			"'='", "'*'", "'/'", "'%'", "'->'", "'?'", "'+'", "'-'", "'++'", "'--'", 
			"'*='", "'/='", "'%='", "'+='", "'-='", "'!'", "'&&'", "'||'", "'['", 
			"']'", "'('", "')'", "'{'", "'}'", "'&'", "'|'", "'^'", "'~'", "'>>'", 
			"'<<'", "'=='", "'!='", "'<'", "'>'", "'<='", "'>='", null, null, null, 
			null, null, null, null, null, null, "'define'", null, "'elif'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "SHARP", "VOID", "INT", "CHAR", "DOUBLE", "STRING", "STRUCT", "LONG", 
			"BYTE", "ENUM", "DELEGATE", "NULL", "PTR", "TRUE", "FALSE", "IF", "ELSE", 
			"WHILE", "FOR", "IN", "SWITCH", "CASE", "BREAK", "CONTINUE", "NEW", "DELETE", 
			"RETURN", "PRINT", "READ", "ASSERT", "DELAY", "PUBLIC", "PRIVATE", "LOAD", 
			"IMPORT", "NAMESPACE", "OWNED", "IS", "DEFAULT", "DOT", "COMMA", "COL", 
			"SEMI_COL", "ASSIGN", "STAR", "SLASH", "PERCENT", "ARROW", "QUESTION", 
			"PLUS", "MINUS", "PLUS_PLUS", "MINUS_MINUS", "ASSIGN_MUL", "ASSIGN_DIV", 
			"ASSIGN_MOD", "ASSIGN_SUM", "ASSIGN_SUB", "NOT", "AND", "OR", "L_BRACKET", 
			"R_BRACKET", "L_PAR", "R_PAR", "L_CURL", "R_CURL", "BIT_AND", "BIT_OR", 
			"BIT_XOR", "BIT_NOT", "BIT_RIGHT", "BIT_LEFT", "EQUAL", "NOT_EQUAL", 
			"LESS_THAN", "GREATER_THAN", "LESS_EQ_THAN", "GREATER_EQ_THAN", "ID", 
			"INT_CONSTANT", "REAL_CONSTANT", "CHAR_CONSTANT", "STRING_CONSTANT", 
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


	public SeagullLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "SeagullLexer.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2a\u02cf\b\1\b\1\4"+
		"\2\t\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n"+
		"\4\13\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22"+
		"\t\22\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31"+
		"\t\31\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t"+
		" \4!\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t"+
		"+\4,\t,\4-\t-\4.\t.\4/\t/\4\60\t\60\4\61\t\61\4\62\t\62\4\63\t\63\4\64"+
		"\t\64\4\65\t\65\4\66\t\66\4\67\t\67\48\t8\49\t9\4:\t:\4;\t;\4<\t<\4=\t"+
		"=\4>\t>\4?\t?\4@\t@\4A\tA\4B\tB\4C\tC\4D\tD\4E\tE\4F\tF\4G\tG\4H\tH\4"+
		"I\tI\4J\tJ\4K\tK\4L\tL\4M\tM\4N\tN\4O\tO\4P\tP\4Q\tQ\4R\tR\4S\tS\4T\t"+
		"T\4U\tU\4V\tV\4W\tW\4X\tX\4Y\tY\4Z\tZ\4[\t[\4\\\t\\\4]\t]\4^\t^\4_\t_"+
		"\4`\t`\4a\ta\4b\tb\4c\tc\4d\td\3\2\3\2\3\3\3\3\3\4\5\4\u00d0\n\4\3\4\3"+
		"\4\6\4\u00d4\n\4\r\4\16\4\u00d5\3\4\3\4\3\4\7\4\u00db\n\4\f\4\16\4\u00de"+
		"\13\4\5\4\u00e0\n\4\3\5\3\5\3\5\5\5\u00e5\n\5\3\6\3\6\3\6\3\6\3\7\3\7"+
		"\3\7\3\7\3\7\3\b\3\b\3\b\3\b\3\t\3\t\3\t\3\t\3\t\3\n\3\n\3\n\3\n\3\n\3"+
		"\n\3\n\3\13\3\13\3\13\3\13\3\13\3\13\3\13\3\f\3\f\3\f\3\f\3\f\3\f\3\f"+
		"\3\r\3\r\3\r\3\r\3\r\3\16\3\16\3\16\3\16\3\16\3\17\3\17\3\17\3\17\3\17"+
		"\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\20\3\21\3\21\3\21\3\21\3\21"+
		"\3\22\3\22\3\22\3\22\3\23\3\23\3\23\3\23\3\23\3\24\3\24\3\24\3\24\3\24"+
		"\3\24\3\25\3\25\3\25\3\26\3\26\3\26\3\26\3\26\3\27\3\27\3\27\3\27\3\27"+
		"\3\27\3\30\3\30\3\30\3\30\3\31\3\31\3\31\3\32\3\32\3\32\3\32\3\32\3\32"+
		"\3\32\3\33\3\33\3\33\3\33\3\33\3\34\3\34\3\34\3\34\3\34\3\34\3\35\3\35"+
		"\3\35\3\35\3\35\3\35\3\35\3\35\3\35\3\36\3\36\3\36\3\36\3\37\3\37\3\37"+
		"\3\37\3\37\3\37\3\37\3 \3 \3 \3 \3 \3 \3 \3!\3!\3!\3!\3!\3!\3\"\3\"\3"+
		"\"\3\"\3\"\3#\3#\3#\3#\3#\3#\3#\3$\3$\3$\3$\3$\3$\3%\3%\3%\3%\3%\3%\3"+
		"%\3&\3&\3&\3&\3&\3&\3&\3&\3\'\3\'\3\'\3\'\3\'\3(\3(\3(\3(\3(\3(\3(\3)"+
		"\3)\3)\3)\3)\3)\3)\3)\3)\3)\3*\3*\3*\3*\3*\3*\3+\3+\3+\3,\3,\3,\3,\3,"+
		"\3,\3,\3,\3-\3-\3.\3.\3/\3/\3\60\3\60\3\61\3\61\3\62\3\62\3\63\3\63\3"+
		"\64\3\64\3\65\3\65\3\65\3\66\3\66\3\67\3\67\38\38\39\39\39\3:\3:\3:\3"+
		";\3;\3;\3<\3<\3<\3=\3=\3=\3>\3>\3>\3?\3?\3?\3@\3@\3A\3A\3A\3B\3B\3B\3"+
		"C\3C\3D\3D\3E\3E\3F\3F\3G\3G\3H\3H\3I\3I\3J\3J\3K\3K\3L\3L\3M\3M\3M\3"+
		"N\3N\3N\3O\3O\3O\3P\3P\3P\3Q\3Q\3R\3R\3S\3S\3S\3T\3T\3T\3U\3U\5U\u022c"+
		"\nU\3U\3U\3U\7U\u0231\nU\fU\16U\u0234\13U\3V\3V\3V\7V\u0239\nV\fV\16V"+
		"\u023c\13V\5V\u023e\nV\3W\3W\3W\3W\5W\u0244\nW\3W\3W\5W\u0248\nW\3W\3"+
		"W\5W\u024c\nW\3X\3X\3X\3X\3X\3X\3X\5X\u0255\nX\3X\3X\3X\3X\3X\3X\3X\5"+
		"X\u025e\nX\3Y\3Y\7Y\u0262\nY\fY\16Y\u0265\13Y\3Y\3Y\3Z\3Z\5Z\u026b\nZ"+
		"\3[\3[\3[\3[\7[\u0271\n[\f[\16[\u0274\13[\3[\3[\5[\u0278\n[\3[\3[\3\\"+
		"\3\\\3\\\3\\\7\\\u0280\n\\\f\\\16\\\u0283\13\\\3\\\3\\\7\\\u0287\n\\\f"+
		"\\\16\\\u028a\13\\\3\\\7\\\u028d\n\\\f\\\16\\\u0290\13\\\5\\\u0292\n\\"+
		"\3\\\7\\\u0295\n\\\f\\\16\\\u0298\13\\\3\\\7\\\u029b\n\\\f\\\16\\\u029e"+
		"\13\\\3\\\3\\\3\\\3\\\3\\\3]\3]\6]\u02a7\n]\r]\16]\u02a8\3]\3]\3^\3^\3"+
		"^\3^\3^\3^\3^\3_\3_\3_\3`\3`\3`\3`\3`\3a\3a\3a\3a\3a\3b\3b\3b\3b\3c\3"+
		"c\3c\3c\3d\3d\5d\u02cb\nd\3d\3d\3d\7\u0263\u0272\u0281\u0296\u029c\2e"+
		"\4\2\6\2\b\2\n\2\f\3\16\4\20\5\22\6\24\7\26\b\30\t\32\n\34\13\36\f \r"+
		"\"\16$\17&\20(\21*\22,\23.\24\60\25\62\26\64\27\66\308\31:\32<\33>\34"+
		"@\35B\36D\37F H!J\"L#N$P%R&T\'V(X)Z*\\+^,`-b.d/f\60h\61j\62l\63n\64p\65"+
		"r\66t\67v8x9z:|;~<\u0080=\u0082>\u0084?\u0086@\u0088A\u008aB\u008cC\u008e"+
		"D\u0090E\u0092F\u0094G\u0096H\u0098I\u009aJ\u009cK\u009eL\u00a0M\u00a2"+
		"N\u00a4O\u00a6P\u00a8Q\u00aaR\u00acS\u00aeT\u00b0U\u00b2V\u00b4W\u00b6"+
		"X\u00b8Y\u00baZ\u00bc[\u00be\\\u00c0]\u00c2^\u00c4_\u00c6`\u00c8a\4\2"+
		"\3\n\3\2\62;\4\2C\\c|\4\2\f\f\17\17\3\2\63;\4\2GGgg\7\2))^^ppttvv\4\2"+
		",,\61\61\4\2\13\13\"\"\2\u02e8\2\f\3\2\2\2\2\16\3\2\2\2\2\20\3\2\2\2\2"+
		"\22\3\2\2\2\2\24\3\2\2\2\2\26\3\2\2\2\2\30\3\2\2\2\2\32\3\2\2\2\2\34\3"+
		"\2\2\2\2\36\3\2\2\2\2 \3\2\2\2\2\"\3\2\2\2\2$\3\2\2\2\2&\3\2\2\2\2(\3"+
		"\2\2\2\2*\3\2\2\2\2,\3\2\2\2\2.\3\2\2\2\2\60\3\2\2\2\2\62\3\2\2\2\2\64"+
		"\3\2\2\2\2\66\3\2\2\2\28\3\2\2\2\2:\3\2\2\2\2<\3\2\2\2\2>\3\2\2\2\2@\3"+
		"\2\2\2\2B\3\2\2\2\2D\3\2\2\2\2F\3\2\2\2\2H\3\2\2\2\2J\3\2\2\2\2L\3\2\2"+
		"\2\2N\3\2\2\2\2P\3\2\2\2\2R\3\2\2\2\2T\3\2\2\2\2V\3\2\2\2\2X\3\2\2\2\2"+
		"Z\3\2\2\2\2\\\3\2\2\2\2^\3\2\2\2\2`\3\2\2\2\2b\3\2\2\2\2d\3\2\2\2\2f\3"+
		"\2\2\2\2h\3\2\2\2\2j\3\2\2\2\2l\3\2\2\2\2n\3\2\2\2\2p\3\2\2\2\2r\3\2\2"+
		"\2\2t\3\2\2\2\2v\3\2\2\2\2x\3\2\2\2\2z\3\2\2\2\2|\3\2\2\2\2~\3\2\2\2\2"+
		"\u0080\3\2\2\2\2\u0082\3\2\2\2\2\u0084\3\2\2\2\2\u0086\3\2\2\2\2\u0088"+
		"\3\2\2\2\2\u008a\3\2\2\2\2\u008c\3\2\2\2\2\u008e\3\2\2\2\2\u0090\3\2\2"+
		"\2\2\u0092\3\2\2\2\2\u0094\3\2\2\2\2\u0096\3\2\2\2\2\u0098\3\2\2\2\2\u009a"+
		"\3\2\2\2\2\u009c\3\2\2\2\2\u009e\3\2\2\2\2\u00a0\3\2\2\2\2\u00a2\3\2\2"+
		"\2\2\u00a4\3\2\2\2\2\u00a6\3\2\2\2\2\u00a8\3\2\2\2\2\u00aa\3\2\2\2\2\u00ac"+
		"\3\2\2\2\2\u00ae\3\2\2\2\2\u00b0\3\2\2\2\2\u00b2\3\2\2\2\2\u00b4\3\2\2"+
		"\2\2\u00b6\3\2\2\2\2\u00b8\3\2\2\2\2\u00ba\3\2\2\2\3\u00bc\3\2\2\2\3\u00be"+
		"\3\2\2\2\3\u00c0\3\2\2\2\3\u00c2\3\2\2\2\3\u00c4\3\2\2\2\3\u00c6\3\2\2"+
		"\2\3\u00c8\3\2\2\2\4\u00ca\3\2\2\2\6\u00cc\3\2\2\2\b\u00df\3\2\2\2\n\u00e4"+
		"\3\2\2\2\f\u00e6\3\2\2\2\16\u00ea\3\2\2\2\20\u00ef\3\2\2\2\22\u00f3\3"+
		"\2\2\2\24\u00f8\3\2\2\2\26\u00ff\3\2\2\2\30\u0106\3\2\2\2\32\u010d\3\2"+
		"\2\2\34\u0112\3\2\2\2\36\u0117\3\2\2\2 \u011c\3\2\2\2\"\u0125\3\2\2\2"+
		"$\u012a\3\2\2\2&\u012e\3\2\2\2(\u0133\3\2\2\2*\u0139\3\2\2\2,\u013c\3"+
		"\2\2\2.\u0141\3\2\2\2\60\u0147\3\2\2\2\62\u014b\3\2\2\2\64\u014e\3\2\2"+
		"\2\66\u0155\3\2\2\28\u015a\3\2\2\2:\u0160\3\2\2\2<\u0169\3\2\2\2>\u016d"+
		"\3\2\2\2@\u0174\3\2\2\2B\u017b\3\2\2\2D\u0181\3\2\2\2F\u0186\3\2\2\2H"+
		"\u018d\3\2\2\2J\u0193\3\2\2\2L\u019a\3\2\2\2N\u01a2\3\2\2\2P\u01a7\3\2"+
		"\2\2R\u01ae\3\2\2\2T\u01b8\3\2\2\2V\u01be\3\2\2\2X\u01c1\3\2\2\2Z\u01c9"+
		"\3\2\2\2\\\u01cb\3\2\2\2^\u01cd\3\2\2\2`\u01cf\3\2\2\2b\u01d1\3\2\2\2"+
		"d\u01d3\3\2\2\2f\u01d5\3\2\2\2h\u01d7\3\2\2\2j\u01d9\3\2\2\2l\u01dc\3"+
		"\2\2\2n\u01de\3\2\2\2p\u01e0\3\2\2\2r\u01e2\3\2\2\2t\u01e5\3\2\2\2v\u01e8"+
		"\3\2\2\2x\u01eb\3\2\2\2z\u01ee\3\2\2\2|\u01f1\3\2\2\2~\u01f4\3\2\2\2\u0080"+
		"\u01f7\3\2\2\2\u0082\u01f9\3\2\2\2\u0084\u01fc\3\2\2\2\u0086\u01ff\3\2"+
		"\2\2\u0088\u0201\3\2\2\2\u008a\u0203\3\2\2\2\u008c\u0205\3\2\2\2\u008e"+
		"\u0207\3\2\2\2\u0090\u0209\3\2\2\2\u0092\u020b\3\2\2\2\u0094\u020d\3\2"+
		"\2\2\u0096\u020f\3\2\2\2\u0098\u0211\3\2\2\2\u009a\u0213\3\2\2\2\u009c"+
		"\u0216\3\2\2\2\u009e\u0219\3\2\2\2\u00a0\u021c\3\2\2\2\u00a2\u021f\3\2"+
		"\2\2\u00a4\u0221\3\2\2\2\u00a6\u0223\3\2\2\2\u00a8\u0226\3\2\2\2\u00aa"+
		"\u022b\3\2\2\2\u00ac\u023d\3\2\2\2\u00ae\u024b\3\2\2\2\u00b0\u025d\3\2"+
		"\2\2\u00b2\u025f\3\2\2\2\u00b4\u026a\3\2\2\2\u00b6\u026c\3\2\2\2\u00b8"+
		"\u027b\3\2\2\2\u00ba\u02a6\3\2\2\2\u00bc\u02ac\3\2\2\2\u00be\u02b3\3\2"+
		"\2\2\u00c0\u02b6\3\2\2\2\u00c2\u02bb\3\2\2\2\u00c4\u02c0\3\2\2\2\u00c6"+
		"\u02c4\3\2\2\2\u00c8\u02ca\3\2\2\2\u00ca\u00cb\t\2\2\2\u00cb\5\3\2\2\2"+
		"\u00cc\u00cd\t\3\2\2\u00cd\7\3\2\2\2\u00ce\u00d0\5\u00acV\2\u00cf\u00ce"+
		"\3\2\2\2\u00cf\u00d0\3\2\2\2\u00d0\u00d1\3\2\2\2\u00d1\u00d3\7\60\2\2"+
		"\u00d2\u00d4\5\4\2\2\u00d3\u00d2\3\2\2\2\u00d4\u00d5\3\2\2\2\u00d5\u00d3"+
		"\3\2\2\2\u00d5\u00d6\3\2\2\2\u00d6\u00e0\3\2\2\2\u00d7\u00d8\5\u00acV"+
		"\2\u00d8\u00dc\7\60\2\2\u00d9\u00db\5\4\2\2\u00da\u00d9\3\2\2\2\u00db"+
		"\u00de\3\2\2\2\u00dc\u00da\3\2\2\2\u00dc\u00dd\3\2\2\2\u00dd\u00e0\3\2"+
		"\2\2\u00de\u00dc\3\2\2\2\u00df\u00cf\3\2\2\2\u00df\u00d7\3\2\2\2\u00e0"+
		"\t\3\2\2\2\u00e1\u00e5\t\4\2\2\u00e2\u00e3\7\17\2\2\u00e3\u00e5\7\f\2"+
		"\2\u00e4\u00e1\3\2\2\2\u00e4\u00e2\3\2\2\2\u00e5\13\3\2\2\2\u00e6\u00e7"+
		"\7%\2\2\u00e7\u00e8\3\2\2\2\u00e8\u00e9\b\6\2\2\u00e9\r\3\2\2\2\u00ea"+
		"\u00eb\7x\2\2\u00eb\u00ec\7q\2\2\u00ec\u00ed\7k\2\2\u00ed\u00ee\7f\2\2"+
		"\u00ee\17\3\2\2\2\u00ef\u00f0\7k\2\2\u00f0\u00f1\7p\2\2\u00f1\u00f2\7"+
		"v\2\2\u00f2\21\3\2\2\2\u00f3\u00f4\7e\2\2\u00f4\u00f5\7j\2\2\u00f5\u00f6"+
		"\7c\2\2\u00f6\u00f7\7t\2\2\u00f7\23\3\2\2\2\u00f8\u00f9\7f\2\2\u00f9\u00fa"+
		"\7q\2\2\u00fa\u00fb\7w\2\2\u00fb\u00fc\7d\2\2\u00fc\u00fd\7n\2\2\u00fd"+
		"\u00fe\7g\2\2\u00fe\25\3\2\2\2\u00ff\u0100\7u\2\2\u0100\u0101\7v\2\2\u0101"+
		"\u0102\7t\2\2\u0102\u0103\7k\2\2\u0103\u0104\7p\2\2\u0104\u0105\7i\2\2"+
		"\u0105\27\3\2\2\2\u0106\u0107\7u\2\2\u0107\u0108\7v\2\2\u0108\u0109\7"+
		"t\2\2\u0109\u010a\7w\2\2\u010a\u010b\7e\2\2\u010b\u010c\7v\2\2\u010c\31"+
		"\3\2\2\2\u010d\u010e\7n\2\2\u010e\u010f\7q\2\2\u010f\u0110\7p\2\2\u0110"+
		"\u0111\7i\2\2\u0111\33\3\2\2\2\u0112\u0113\7d\2\2\u0113\u0114\7{\2\2\u0114"+
		"\u0115\7v\2\2\u0115\u0116\7g\2\2\u0116\35\3\2\2\2\u0117\u0118\7g\2\2\u0118"+
		"\u0119\7p\2\2\u0119\u011a\7w\2\2\u011a\u011b\7o\2\2\u011b\37\3\2\2\2\u011c"+
		"\u011d\7f\2\2\u011d\u011e\7g\2\2\u011e\u011f\7n\2\2\u011f\u0120\7g\2\2"+
		"\u0120\u0121\7i\2\2\u0121\u0122\7c\2\2\u0122\u0123\7v\2\2\u0123\u0124"+
		"\7g\2\2\u0124!\3\2\2\2\u0125\u0126\7p\2\2\u0126\u0127\7w\2\2\u0127\u0128"+
		"\7n\2\2\u0128\u0129\7n\2\2\u0129#\3\2\2\2\u012a\u012b\7r\2\2\u012b\u012c"+
		"\7v\2\2\u012c\u012d\7t\2\2\u012d%\3\2\2\2\u012e\u012f\7v\2\2\u012f\u0130"+
		"\7t\2\2\u0130\u0131\7w\2\2\u0131\u0132\7g\2\2\u0132\'\3\2\2\2\u0133\u0134"+
		"\7h\2\2\u0134\u0135\7c\2\2\u0135\u0136\7n\2\2\u0136\u0137\7u\2\2\u0137"+
		"\u0138\7g\2\2\u0138)\3\2\2\2\u0139\u013a\7k\2\2\u013a\u013b\7h\2\2\u013b"+
		"+\3\2\2\2\u013c\u013d\7g\2\2\u013d\u013e\7n\2\2\u013e\u013f\7u\2\2\u013f"+
		"\u0140\7g\2\2\u0140-\3\2\2\2\u0141\u0142\7y\2\2\u0142\u0143\7j\2\2\u0143"+
		"\u0144\7k\2\2\u0144\u0145\7n\2\2\u0145\u0146\7g\2\2\u0146/\3\2\2\2\u0147"+
		"\u0148\7h\2\2\u0148\u0149\7q\2\2\u0149\u014a\7t\2\2\u014a\61\3\2\2\2\u014b"+
		"\u014c\7k\2\2\u014c\u014d\7p\2\2\u014d\63\3\2\2\2\u014e\u014f\7u\2\2\u014f"+
		"\u0150\7y\2\2\u0150\u0151\7k\2\2\u0151\u0152\7v\2\2\u0152\u0153\7e\2\2"+
		"\u0153\u0154\7j\2\2\u0154\65\3\2\2\2\u0155\u0156\7e\2\2\u0156\u0157\7"+
		"c\2\2\u0157\u0158\7u\2\2\u0158\u0159\7g\2\2\u0159\67\3\2\2\2\u015a\u015b"+
		"\7d\2\2\u015b\u015c\7t\2\2\u015c\u015d\7g\2\2\u015d\u015e\7c\2\2\u015e"+
		"\u015f\7m\2\2\u015f9\3\2\2\2\u0160\u0161\7e\2\2\u0161\u0162\7q\2\2\u0162"+
		"\u0163\7p\2\2\u0163\u0164\7v\2\2\u0164\u0165\7k\2\2\u0165\u0166\7p\2\2"+
		"\u0166\u0167\7w\2\2\u0167\u0168\7g\2\2\u0168;\3\2\2\2\u0169\u016a\7p\2"+
		"\2\u016a\u016b\7g\2\2\u016b\u016c\7y\2\2\u016c=\3\2\2\2\u016d\u016e\7"+
		"f\2\2\u016e\u016f\7g\2\2\u016f\u0170\7n\2\2\u0170\u0171\7g\2\2\u0171\u0172"+
		"\7v\2\2\u0172\u0173\7g\2\2\u0173?\3\2\2\2\u0174\u0175\7t\2\2\u0175\u0176"+
		"\7g\2\2\u0176\u0177\7v\2\2\u0177\u0178\7w\2\2\u0178\u0179\7t\2\2\u0179"+
		"\u017a\7p\2\2\u017aA\3\2\2\2\u017b\u017c\7r\2\2\u017c\u017d\7t\2\2\u017d"+
		"\u017e\7k\2\2\u017e\u017f\7p\2\2\u017f\u0180\7v\2\2\u0180C\3\2\2\2\u0181"+
		"\u0182\7t\2\2\u0182\u0183\7g\2\2\u0183\u0184\7c\2\2\u0184\u0185\7f\2\2"+
		"\u0185E\3\2\2\2\u0186\u0187\7c\2\2\u0187\u0188\7u\2\2\u0188\u0189\7u\2"+
		"\2\u0189\u018a\7g\2\2\u018a\u018b\7t\2\2\u018b\u018c\7v\2\2\u018cG\3\2"+
		"\2\2\u018d\u018e\7f\2\2\u018e\u018f\7g\2\2\u018f\u0190\7n\2\2\u0190\u0191"+
		"\7c\2\2\u0191\u0192\7{\2\2\u0192I\3\2\2\2\u0193\u0194\7r\2\2\u0194\u0195"+
		"\7w\2\2\u0195\u0196\7d\2\2\u0196\u0197\7n\2\2\u0197\u0198\7k\2\2\u0198"+
		"\u0199\7e\2\2\u0199K\3\2\2\2\u019a\u019b\7r\2\2\u019b\u019c\7t\2\2\u019c"+
		"\u019d\7k\2\2\u019d\u019e\7x\2\2\u019e\u019f\7c\2\2\u019f\u01a0\7v\2\2"+
		"\u01a0\u01a1\7g\2\2\u01a1M\3\2\2\2\u01a2\u01a3\7n\2\2\u01a3\u01a4\7q\2"+
		"\2\u01a4\u01a5\7c\2\2\u01a5\u01a6\7f\2\2\u01a6O\3\2\2\2\u01a7\u01a8\7"+
		"k\2\2\u01a8\u01a9\7o\2\2\u01a9\u01aa\7r\2\2\u01aa\u01ab\7q\2\2\u01ab\u01ac"+
		"\7t\2\2\u01ac\u01ad\7v\2\2\u01adQ\3\2\2\2\u01ae\u01af\7p\2\2\u01af\u01b0"+
		"\7c\2\2\u01b0\u01b1\7o\2\2\u01b1\u01b2\7g\2\2\u01b2\u01b3\7u\2\2\u01b3"+
		"\u01b4\7r\2\2\u01b4\u01b5\7c\2\2\u01b5\u01b6\7e\2\2\u01b6\u01b7\7g\2\2"+
		"\u01b7S\3\2\2\2\u01b8\u01b9\7q\2\2\u01b9\u01ba\7y\2\2\u01ba\u01bb\7p\2"+
		"\2\u01bb\u01bc\7g\2\2\u01bc\u01bd\7f\2\2\u01bdU\3\2\2\2\u01be\u01bf\7"+
		"k\2\2\u01bf\u01c0\7u\2\2\u01c0W\3\2\2\2\u01c1\u01c2\7f\2\2\u01c2\u01c3"+
		"\7g\2\2\u01c3\u01c4\7h\2\2\u01c4\u01c5\7c\2\2\u01c5\u01c6\7w\2\2\u01c6"+
		"\u01c7\7n\2\2\u01c7\u01c8\7v\2\2\u01c8Y\3\2\2\2\u01c9\u01ca\7\60\2\2\u01ca"+
		"[\3\2\2\2\u01cb\u01cc\7.\2\2\u01cc]\3\2\2\2\u01cd\u01ce\7<\2\2\u01ce_"+
		"\3\2\2\2\u01cf\u01d0\7=\2\2\u01d0a\3\2\2\2\u01d1\u01d2\7?\2\2\u01d2c\3"+
		"\2\2\2\u01d3\u01d4\7,\2\2\u01d4e\3\2\2\2\u01d5\u01d6\7\61\2\2\u01d6g\3"+
		"\2\2\2\u01d7\u01d8\7\'\2\2\u01d8i\3\2\2\2\u01d9\u01da\7/\2\2\u01da\u01db"+
		"\7@\2\2\u01dbk\3\2\2\2\u01dc\u01dd\7A\2\2\u01ddm\3\2\2\2\u01de\u01df\7"+
		"-\2\2\u01dfo\3\2\2\2\u01e0\u01e1\7/\2\2\u01e1q\3\2\2\2\u01e2\u01e3\7-"+
		"\2\2\u01e3\u01e4\7-\2\2\u01e4s\3\2\2\2\u01e5\u01e6\7/\2\2\u01e6\u01e7"+
		"\7/\2\2\u01e7u\3\2\2\2\u01e8\u01e9\7,\2\2\u01e9\u01ea\7?\2\2\u01eaw\3"+
		"\2\2\2\u01eb\u01ec\7\61\2\2\u01ec\u01ed\7?\2\2\u01edy\3\2\2\2\u01ee\u01ef"+
		"\7\'\2\2\u01ef\u01f0\7?\2\2\u01f0{\3\2\2\2\u01f1\u01f2\7-\2\2\u01f2\u01f3"+
		"\7?\2\2\u01f3}\3\2\2\2\u01f4\u01f5\7/\2\2\u01f5\u01f6\7?\2\2\u01f6\177"+
		"\3\2\2\2\u01f7\u01f8\7#\2\2\u01f8\u0081\3\2\2\2\u01f9\u01fa\7(\2\2\u01fa"+
		"\u01fb\7(\2\2\u01fb\u0083\3\2\2\2\u01fc\u01fd\7~\2\2\u01fd\u01fe\7~\2"+
		"\2\u01fe\u0085\3\2\2\2\u01ff\u0200\7]\2\2\u0200\u0087\3\2\2\2\u0201\u0202"+
		"\7_\2\2\u0202\u0089\3\2\2\2\u0203\u0204\7*\2\2\u0204\u008b\3\2\2\2\u0205"+
		"\u0206\7+\2\2\u0206\u008d\3\2\2\2\u0207\u0208\7}\2\2\u0208\u008f\3\2\2"+
		"\2\u0209\u020a\7\177\2\2\u020a\u0091\3\2\2\2\u020b\u020c\7(\2\2\u020c"+
		"\u0093\3\2\2\2\u020d\u020e\7~\2\2\u020e\u0095\3\2\2\2\u020f\u0210\7`\2"+
		"\2\u0210\u0097\3\2\2\2\u0211\u0212\7\u0080\2\2\u0212\u0099\3\2\2\2\u0213"+
		"\u0214\7@\2\2\u0214\u0215\7@\2\2\u0215\u009b\3\2\2\2\u0216\u0217\7>\2"+
		"\2\u0217\u0218\7>\2\2\u0218\u009d\3\2\2\2\u0219\u021a\7?\2\2\u021a\u021b"+
		"\7?\2\2\u021b\u009f\3\2\2\2\u021c\u021d\7#\2\2\u021d\u021e\7?\2\2\u021e"+
		"\u00a1\3\2\2\2\u021f\u0220\7>\2\2\u0220\u00a3\3\2\2\2\u0221\u0222\7@\2"+
		"\2\u0222\u00a5\3\2\2\2\u0223\u0224\7>\2\2\u0224\u0225\7?\2\2\u0225\u00a7"+
		"\3\2\2\2\u0226\u0227\7@\2\2\u0227\u0228\7?\2\2\u0228\u00a9\3\2\2\2\u0229"+
		"\u022c\7a\2\2\u022a\u022c\5\6\3\2\u022b\u0229\3\2\2\2\u022b\u022a\3\2"+
		"\2\2\u022c\u0232\3\2\2\2\u022d\u0231\7a\2\2\u022e\u0231\5\4\2\2\u022f"+
		"\u0231\5\6\3\2\u0230\u022d\3\2\2\2\u0230\u022e\3\2\2\2\u0230\u022f\3\2"+
		"\2\2\u0231\u0234\3\2\2\2\u0232\u0230\3\2\2\2\u0232\u0233\3\2\2\2\u0233"+
		"\u00ab\3\2\2\2\u0234\u0232\3\2\2\2\u0235\u023e\7\62\2\2\u0236\u023a\t"+
		"\5\2\2\u0237\u0239\t\2\2\2\u0238\u0237\3\2\2\2\u0239\u023c\3\2\2\2\u023a"+
		"\u0238\3\2\2\2\u023a\u023b\3\2\2\2\u023b\u023e\3\2\2\2\u023c\u023a\3\2"+
		"\2\2\u023d\u0235\3\2\2\2\u023d\u0236\3\2\2\2\u023e\u00ad\3\2\2\2\u023f"+
		"\u024c\5\b\4\2\u0240\u024c\5\u00acV\2\u0241\u0244\5\b\4\2\u0242\u0244"+
		"\5\u00acV\2\u0243\u0241\3\2\2\2\u0243\u0242\3\2\2\2\u0244\u0245\3\2\2"+
		"\2\u0245\u0247\t\6\2\2\u0246\u0248\7/\2\2\u0247\u0246\3\2\2\2\u0247\u0248"+
		"\3\2\2\2\u0248\u0249\3\2\2\2\u0249\u024a\5\u00acV\2\u024a\u024c\3\2\2"+
		"\2\u024b\u023f\3\2\2\2\u024b\u0240\3\2\2\2\u024b\u0243\3\2\2\2\u024c\u00af"+
		"\3\2\2\2\u024d\u024e\7)\2\2\u024e\u024f\13\2\2\2\u024f\u025e\7)\2\2\u0250"+
		"\u0251\7)\2\2\u0251\u0252\7^\2\2\u0252\u0254\3\2\2\2\u0253\u0255\t\7\2"+
		"\2\u0254\u0253\3\2\2\2\u0255\u0256\3\2\2\2\u0256\u025e\7)\2\2\u0257\u0258"+
		"\7)\2\2\u0258\u0259\7^\2\2\u0259\u025a\3\2\2\2\u025a\u025b\5\u00acV\2"+
		"\u025b\u025c\7)\2\2\u025c\u025e\3\2\2\2\u025d\u024d\3\2\2\2\u025d\u0250"+
		"\3\2\2\2\u025d\u0257\3\2\2\2\u025e\u00b1\3\2\2\2\u025f\u0263\7$\2\2\u0260"+
		"\u0262\13\2\2\2\u0261\u0260\3\2\2\2\u0262\u0265\3\2\2\2\u0263\u0264\3"+
		"\2\2\2\u0263\u0261\3\2\2\2\u0264\u0266\3\2\2\2\u0265\u0263\3\2\2\2\u0266"+
		"\u0267\7$\2\2\u0267\u00b3\3\2\2\2\u0268\u026b\5&\23\2\u0269\u026b\5(\24"+
		"\2\u026a\u0268\3\2\2\2\u026a\u0269\3\2\2\2\u026b\u00b5\3\2\2\2\u026c\u026d"+
		"\7\61\2\2\u026d\u026e\7\61\2\2\u026e\u0272\3\2\2\2\u026f\u0271\13\2\2"+
		"\2\u0270\u026f\3\2\2\2\u0271\u0274\3\2\2\2\u0272\u0273\3\2\2\2\u0272\u0270"+
		"\3\2\2\2\u0273\u0277\3\2\2\2\u0274\u0272\3\2\2\2\u0275\u0278\5\n\5\2\u0276"+
		"\u0278\7\2\2\3\u0277\u0275\3\2\2\2\u0277\u0276\3\2\2\2\u0278\u0279\3\2"+
		"\2\2\u0279\u027a\b[\3\2\u027a\u00b7\3\2\2\2\u027b\u027c\7\61\2\2\u027c"+
		"\u027d\7,\2\2\u027d\u0296\3\2\2\2\u027e\u0280\7\61\2\2\u027f\u027e\3\2"+
		"\2\2\u0280\u0283\3\2\2\2\u0281\u0282\3\2\2\2\u0281\u027f\3\2\2\2\u0282"+
		"\u0284\3\2\2\2\u0283\u0281\3\2\2\2\u0284\u0295\5\u00b8\\\2\u0285\u0287"+
		"\7\61\2\2\u0286\u0285\3\2\2\2\u0287\u028a\3\2\2\2\u0288\u0286\3\2\2\2"+
		"\u0288\u0289\3\2\2\2\u0289\u0292\3\2\2\2\u028a\u0288\3\2\2\2\u028b\u028d"+
		"\7,\2\2\u028c\u028b\3\2\2\2\u028d\u0290\3\2\2\2\u028e\u028c\3\2\2\2\u028e"+
		"\u028f\3\2\2\2\u028f\u0292\3\2\2\2\u0290\u028e\3\2\2\2\u0291\u0288\3\2"+
		"\2\2\u0291\u028e\3\2\2\2\u0292\u0293\3\2\2\2\u0293\u0295\n\b\2\2\u0294"+
		"\u0281\3\2\2\2\u0294\u0291\3\2\2\2\u0295\u0298\3\2\2\2\u0296\u0297\3\2"+
		"\2\2\u0296\u0294\3\2\2\2\u0297\u029c\3\2\2\2\u0298\u0296\3\2\2\2\u0299"+
		"\u029b\7,\2\2\u029a\u0299\3\2\2\2\u029b\u029e\3\2\2\2\u029c\u029d\3\2"+
		"\2\2\u029c\u029a\3\2\2\2\u029d\u029f\3\2\2\2\u029e\u029c\3\2\2\2\u029f"+
		"\u02a0\7,\2\2\u02a0\u02a1\7\61\2\2\u02a1\u02a2\3\2\2\2\u02a2\u02a3\b\\"+
		"\3\2\u02a3\u00b9\3\2\2\2\u02a4\u02a7\t\t\2\2\u02a5\u02a7\5\n\5\2\u02a6"+
		"\u02a4\3\2\2\2\u02a6\u02a5\3\2\2\2\u02a7\u02a8\3\2\2\2\u02a8\u02a6\3\2"+
		"\2\2\u02a8\u02a9\3\2\2\2\u02a9\u02aa\3\2\2\2\u02aa\u02ab\b]\3\2\u02ab"+
		"\u00bb\3\2\2\2\u02ac\u02ad\7f\2\2\u02ad\u02ae\7g\2\2\u02ae\u02af\7h\2"+
		"\2\u02af\u02b0\7k\2\2\u02b0\u02b1\7p\2\2\u02b1\u02b2\7g\2\2\u02b2\u00bd"+
		"\3\2\2\2\u02b3\u02b4\7k\2\2\u02b4\u02b5\7h\2\2\u02b5\u00bf\3\2\2\2\u02b6"+
		"\u02b7\7g\2\2\u02b7\u02b8\7n\2\2\u02b8\u02b9\7k\2\2\u02b9\u02ba\7h\2\2"+
		"\u02ba\u00c1\3\2\2\2\u02bb\u02bc\7g\2\2\u02bc\u02bd\7n\2\2\u02bd\u02be"+
		"\7u\2\2\u02be\u02bf\7g\2\2\u02bf\u00c3\3\2\2\2\u02c0\u02c1\5\u00ba]\2"+
		"\u02c1\u02c2\3\2\2\2\u02c2\u02c3\bb\4\2\u02c3\u00c5\3\2\2\2\u02c4\u02c5"+
		"\5\u00b8\\\2\u02c5\u02c6\3\2\2\2\u02c6\u02c7\bc\4\2\u02c7\u00c7\3\2\2"+
		"\2\u02c8\u02cb\5\n\5\2\u02c9\u02cb\5\u00b6[\2\u02ca\u02c8\3\2\2\2\u02ca"+
		"\u02c9\3\2\2\2\u02cb\u02cc\3\2\2\2\u02cc\u02cd\bd\4\2\u02cd\u02ce\bd\5"+
		"\2\u02ce\u00c9\3\2\2\2!\2\3\u00cf\u00d5\u00dc\u00df\u00e4\u022b\u0230"+
		"\u0232\u023a\u023d\u0243\u0247\u024b\u0254\u025d\u0263\u026a\u0272\u0277"+
		"\u0281\u0288\u028e\u0291\u0294\u0296\u029c\u02a6\u02a8\u02ca\6\4\3\2\b"+
		"\2\2\2\3\2\4\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}