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
			"STRING", "STRUCT", "LONG", "BYTE", "ENUM", "DELEGATE", "NULL", "TRUE", 
			"FALSE", "IF", "ELSE", "WHILE", "FOR", "IN", "SWITCH", "CASE", "BREAK", 
			"CONTINUE", "NEW", "DELETE", "RETURN", "PRINT", "READ", "ASSERT", "DELAY", 
			"PUBLIC", "PRIVATE", "LOAD", "IMPORT", "NAMESPACE", "USING", "IS", "DOT", 
			"COMMA", "COL", "SEMI_COL", "ASSIGN", "STAR", "SLASH", "PERCENT", "ARROW", 
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
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
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
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "SHARP", "VOID", "INT", "CHAR", "DOUBLE", "STRING", "STRUCT", "LONG", 
			"BYTE", "ENUM", "DELEGATE", "NULL", "TRUE", "FALSE", "IF", "ELSE", "WHILE", 
			"FOR", "IN", "SWITCH", "CASE", "BREAK", "CONTINUE", "NEW", "DELETE", 
			"RETURN", "PRINT", "READ", "ASSERT", "DELAY", "PUBLIC", "PRIVATE", "LOAD", 
			"IMPORT", "NAMESPACE", "USING", "IS", "DOT", "COMMA", "COL", "SEMI_COL", 
			"ASSIGN", "STAR", "SLASH", "PERCENT", "ARROW", "PLUS", "MINUS", "PLUS_PLUS", 
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2^\u02bb\b\1\b\1\4"+
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
		"\4`\t`\4a\ta\3\2\3\2\3\3\3\3\3\4\5\4\u00ca\n\4\3\4\3\4\6\4\u00ce\n\4\r"+
		"\4\16\4\u00cf\3\4\3\4\3\4\7\4\u00d5\n\4\f\4\16\4\u00d8\13\4\5\4\u00da"+
		"\n\4\3\5\3\5\3\5\5\5\u00df\n\5\3\6\3\6\3\6\3\6\3\7\3\7\3\7\3\7\3\7\3\b"+
		"\3\b\3\b\3\b\3\t\3\t\3\t\3\t\3\t\3\n\3\n\3\n\3\n\3\n\3\n\3\n\3\13\3\13"+
		"\3\13\3\13\3\13\3\13\3\13\3\f\3\f\3\f\3\f\3\f\3\f\3\f\3\r\3\r\3\r\3\r"+
		"\3\r\3\16\3\16\3\16\3\16\3\16\3\17\3\17\3\17\3\17\3\17\3\20\3\20\3\20"+
		"\3\20\3\20\3\20\3\20\3\20\3\20\3\21\3\21\3\21\3\21\3\21\3\22\3\22\3\22"+
		"\3\22\3\22\3\23\3\23\3\23\3\23\3\23\3\23\3\24\3\24\3\24\3\25\3\25\3\25"+
		"\3\25\3\25\3\26\3\26\3\26\3\26\3\26\3\26\3\27\3\27\3\27\3\27\3\30\3\30"+
		"\3\30\3\31\3\31\3\31\3\31\3\31\3\31\3\31\3\32\3\32\3\32\3\32\3\32\3\33"+
		"\3\33\3\33\3\33\3\33\3\33\3\34\3\34\3\34\3\34\3\34\3\34\3\34\3\34\3\34"+
		"\3\35\3\35\3\35\3\35\3\36\3\36\3\36\3\36\3\36\3\36\3\36\3\37\3\37\3\37"+
		"\3\37\3\37\3\37\3\37\3 \3 \3 \3 \3 \3 \3!\3!\3!\3!\3!\3\"\3\"\3\"\3\""+
		"\3\"\3\"\3\"\3#\3#\3#\3#\3#\3#\3$\3$\3$\3$\3$\3$\3$\3%\3%\3%\3%\3%\3%"+
		"\3%\3%\3&\3&\3&\3&\3&\3\'\3\'\3\'\3\'\3\'\3\'\3\'\3(\3(\3(\3(\3(\3(\3"+
		"(\3(\3(\3(\3)\3)\3)\3)\3)\3)\3*\3*\3*\3+\3+\3,\3,\3-\3-\3.\3.\3/\3/\3"+
		"\60\3\60\3\61\3\61\3\62\3\62\3\63\3\63\3\63\3\64\3\64\3\65\3\65\3\66\3"+
		"\66\3\66\3\67\3\67\3\67\38\38\38\39\39\39\3:\3:\3:\3;\3;\3;\3<\3<\3<\3"+
		"=\3=\3>\3>\3>\3?\3?\3?\3@\3@\3A\3A\3B\3B\3C\3C\3D\3D\3E\3E\3F\3F\3G\3"+
		"G\3H\3H\3I\3I\3J\3J\3J\3K\3K\3K\3L\3L\3L\3M\3M\3M\3N\3N\3O\3O\3P\3P\3"+
		"P\3Q\3Q\3Q\3R\3R\5R\u0218\nR\3R\3R\3R\7R\u021d\nR\fR\16R\u0220\13R\3S"+
		"\3S\3S\7S\u0225\nS\fS\16S\u0228\13S\5S\u022a\nS\3T\3T\3T\3T\5T\u0230\n"+
		"T\3T\3T\5T\u0234\nT\3T\3T\5T\u0238\nT\3U\3U\3U\3U\3U\3U\3U\5U\u0241\n"+
		"U\3U\3U\3U\3U\3U\3U\3U\5U\u024a\nU\3V\3V\7V\u024e\nV\fV\16V\u0251\13V"+
		"\3V\3V\3W\3W\5W\u0257\nW\3X\3X\3X\3X\7X\u025d\nX\fX\16X\u0260\13X\3X\3"+
		"X\5X\u0264\nX\3X\3X\3Y\3Y\3Y\3Y\7Y\u026c\nY\fY\16Y\u026f\13Y\3Y\3Y\7Y"+
		"\u0273\nY\fY\16Y\u0276\13Y\3Y\7Y\u0279\nY\fY\16Y\u027c\13Y\5Y\u027e\n"+
		"Y\3Y\7Y\u0281\nY\fY\16Y\u0284\13Y\3Y\7Y\u0287\nY\fY\16Y\u028a\13Y\3Y\3"+
		"Y\3Y\3Y\3Y\3Z\3Z\6Z\u0293\nZ\rZ\16Z\u0294\3Z\3Z\3[\3[\3[\3[\3[\3[\3[\3"+
		"\\\3\\\3\\\3]\3]\3]\3]\3]\3^\3^\3^\3^\3^\3_\3_\3_\3_\3`\3`\3`\3`\3a\3"+
		"a\5a\u02b7\na\3a\3a\3a\7\u024f\u025e\u026d\u0282\u0288\2b\4\2\6\2\b\2"+
		"\n\2\f\3\16\4\20\5\22\6\24\7\26\b\30\t\32\n\34\13\36\f \r\"\16$\17&\20"+
		"(\21*\22,\23.\24\60\25\62\26\64\27\66\308\31:\32<\33>\34@\35B\36D\37F"+
		" H!J\"L#N$P%R&T\'V(X)Z*\\+^,`-b.d/f\60h\61j\62l\63n\64p\65r\66t\67v8x"+
		"9z:|;~<\u0080=\u0082>\u0084?\u0086@\u0088A\u008aB\u008cC\u008eD\u0090"+
		"E\u0092F\u0094G\u0096H\u0098I\u009aJ\u009cK\u009eL\u00a0M\u00a2N\u00a4"+
		"O\u00a6P\u00a8Q\u00aaR\u00acS\u00aeT\u00b0U\u00b2V\u00b4W\u00b6X\u00b8"+
		"Y\u00baZ\u00bc[\u00be\\\u00c0]\u00c2^\4\2\3\n\3\2\62;\4\2C\\c|\4\2\f\f"+
		"\17\17\3\2\63;\4\2GGgg\7\2))^^ppttvv\4\2,,\61\61\4\2\13\13\"\"\2\u02d4"+
		"\2\f\3\2\2\2\2\16\3\2\2\2\2\20\3\2\2\2\2\22\3\2\2\2\2\24\3\2\2\2\2\26"+
		"\3\2\2\2\2\30\3\2\2\2\2\32\3\2\2\2\2\34\3\2\2\2\2\36\3\2\2\2\2 \3\2\2"+
		"\2\2\"\3\2\2\2\2$\3\2\2\2\2&\3\2\2\2\2(\3\2\2\2\2*\3\2\2\2\2,\3\2\2\2"+
		"\2.\3\2\2\2\2\60\3\2\2\2\2\62\3\2\2\2\2\64\3\2\2\2\2\66\3\2\2\2\28\3\2"+
		"\2\2\2:\3\2\2\2\2<\3\2\2\2\2>\3\2\2\2\2@\3\2\2\2\2B\3\2\2\2\2D\3\2\2\2"+
		"\2F\3\2\2\2\2H\3\2\2\2\2J\3\2\2\2\2L\3\2\2\2\2N\3\2\2\2\2P\3\2\2\2\2R"+
		"\3\2\2\2\2T\3\2\2\2\2V\3\2\2\2\2X\3\2\2\2\2Z\3\2\2\2\2\\\3\2\2\2\2^\3"+
		"\2\2\2\2`\3\2\2\2\2b\3\2\2\2\2d\3\2\2\2\2f\3\2\2\2\2h\3\2\2\2\2j\3\2\2"+
		"\2\2l\3\2\2\2\2n\3\2\2\2\2p\3\2\2\2\2r\3\2\2\2\2t\3\2\2\2\2v\3\2\2\2\2"+
		"x\3\2\2\2\2z\3\2\2\2\2|\3\2\2\2\2~\3\2\2\2\2\u0080\3\2\2\2\2\u0082\3\2"+
		"\2\2\2\u0084\3\2\2\2\2\u0086\3\2\2\2\2\u0088\3\2\2\2\2\u008a\3\2\2\2\2"+
		"\u008c\3\2\2\2\2\u008e\3\2\2\2\2\u0090\3\2\2\2\2\u0092\3\2\2\2\2\u0094"+
		"\3\2\2\2\2\u0096\3\2\2\2\2\u0098\3\2\2\2\2\u009a\3\2\2\2\2\u009c\3\2\2"+
		"\2\2\u009e\3\2\2\2\2\u00a0\3\2\2\2\2\u00a2\3\2\2\2\2\u00a4\3\2\2\2\2\u00a6"+
		"\3\2\2\2\2\u00a8\3\2\2\2\2\u00aa\3\2\2\2\2\u00ac\3\2\2\2\2\u00ae\3\2\2"+
		"\2\2\u00b0\3\2\2\2\2\u00b2\3\2\2\2\2\u00b4\3\2\2\2\3\u00b6\3\2\2\2\3\u00b8"+
		"\3\2\2\2\3\u00ba\3\2\2\2\3\u00bc\3\2\2\2\3\u00be\3\2\2\2\3\u00c0\3\2\2"+
		"\2\3\u00c2\3\2\2\2\4\u00c4\3\2\2\2\6\u00c6\3\2\2\2\b\u00d9\3\2\2\2\n\u00de"+
		"\3\2\2\2\f\u00e0\3\2\2\2\16\u00e4\3\2\2\2\20\u00e9\3\2\2\2\22\u00ed\3"+
		"\2\2\2\24\u00f2\3\2\2\2\26\u00f9\3\2\2\2\30\u0100\3\2\2\2\32\u0107\3\2"+
		"\2\2\34\u010c\3\2\2\2\36\u0111\3\2\2\2 \u0116\3\2\2\2\"\u011f\3\2\2\2"+
		"$\u0124\3\2\2\2&\u0129\3\2\2\2(\u012f\3\2\2\2*\u0132\3\2\2\2,\u0137\3"+
		"\2\2\2.\u013d\3\2\2\2\60\u0141\3\2\2\2\62\u0144\3\2\2\2\64\u014b\3\2\2"+
		"\2\66\u0150\3\2\2\28\u0156\3\2\2\2:\u015f\3\2\2\2<\u0163\3\2\2\2>\u016a"+
		"\3\2\2\2@\u0171\3\2\2\2B\u0177\3\2\2\2D\u017c\3\2\2\2F\u0183\3\2\2\2H"+
		"\u0189\3\2\2\2J\u0190\3\2\2\2L\u0198\3\2\2\2N\u019d\3\2\2\2P\u01a4\3\2"+
		"\2\2R\u01ae\3\2\2\2T\u01b4\3\2\2\2V\u01b7\3\2\2\2X\u01b9\3\2\2\2Z\u01bb"+
		"\3\2\2\2\\\u01bd\3\2\2\2^\u01bf\3\2\2\2`\u01c1\3\2\2\2b\u01c3\3\2\2\2"+
		"d\u01c5\3\2\2\2f\u01c7\3\2\2\2h\u01ca\3\2\2\2j\u01cc\3\2\2\2l\u01ce\3"+
		"\2\2\2n\u01d1\3\2\2\2p\u01d4\3\2\2\2r\u01d7\3\2\2\2t\u01da\3\2\2\2v\u01dd"+
		"\3\2\2\2x\u01e0\3\2\2\2z\u01e3\3\2\2\2|\u01e5\3\2\2\2~\u01e8\3\2\2\2\u0080"+
		"\u01eb\3\2\2\2\u0082\u01ed\3\2\2\2\u0084\u01ef\3\2\2\2\u0086\u01f1\3\2"+
		"\2\2\u0088\u01f3\3\2\2\2\u008a\u01f5\3\2\2\2\u008c\u01f7\3\2\2\2\u008e"+
		"\u01f9\3\2\2\2\u0090\u01fb\3\2\2\2\u0092\u01fd\3\2\2\2\u0094\u01ff\3\2"+
		"\2\2\u0096\u0202\3\2\2\2\u0098\u0205\3\2\2\2\u009a\u0208\3\2\2\2\u009c"+
		"\u020b\3\2\2\2\u009e\u020d\3\2\2\2\u00a0\u020f\3\2\2\2\u00a2\u0212\3\2"+
		"\2\2\u00a4\u0217\3\2\2\2\u00a6\u0229\3\2\2\2\u00a8\u0237\3\2\2\2\u00aa"+
		"\u0249\3\2\2\2\u00ac\u024b\3\2\2\2\u00ae\u0256\3\2\2\2\u00b0\u0258\3\2"+
		"\2\2\u00b2\u0267\3\2\2\2\u00b4\u0292\3\2\2\2\u00b6\u0298\3\2\2\2\u00b8"+
		"\u029f\3\2\2\2\u00ba\u02a2\3\2\2\2\u00bc\u02a7\3\2\2\2\u00be\u02ac\3\2"+
		"\2\2\u00c0\u02b0\3\2\2\2\u00c2\u02b6\3\2\2\2\u00c4\u00c5\t\2\2\2\u00c5"+
		"\5\3\2\2\2\u00c6\u00c7\t\3\2\2\u00c7\7\3\2\2\2\u00c8\u00ca\5\u00a6S\2"+
		"\u00c9\u00c8\3\2\2\2\u00c9\u00ca\3\2\2\2\u00ca\u00cb\3\2\2\2\u00cb\u00cd"+
		"\7\60\2\2\u00cc\u00ce\5\4\2\2\u00cd\u00cc\3\2\2\2\u00ce\u00cf\3\2\2\2"+
		"\u00cf\u00cd\3\2\2\2\u00cf\u00d0\3\2\2\2\u00d0\u00da\3\2\2\2\u00d1\u00d2"+
		"\5\u00a6S\2\u00d2\u00d6\7\60\2\2\u00d3\u00d5\5\4\2\2\u00d4\u00d3\3\2\2"+
		"\2\u00d5\u00d8\3\2\2\2\u00d6\u00d4\3\2\2\2\u00d6\u00d7\3\2\2\2\u00d7\u00da"+
		"\3\2\2\2\u00d8\u00d6\3\2\2\2\u00d9\u00c9\3\2\2\2\u00d9\u00d1\3\2\2\2\u00da"+
		"\t\3\2\2\2\u00db\u00df\t\4\2\2\u00dc\u00dd\7\17\2\2\u00dd\u00df\7\f\2"+
		"\2\u00de\u00db\3\2\2\2\u00de\u00dc\3\2\2\2\u00df\13\3\2\2\2\u00e0\u00e1"+
		"\7%\2\2\u00e1\u00e2\3\2\2\2\u00e2\u00e3\b\6\2\2\u00e3\r\3\2\2\2\u00e4"+
		"\u00e5\7x\2\2\u00e5\u00e6\7q\2\2\u00e6\u00e7\7k\2\2\u00e7\u00e8\7f\2\2"+
		"\u00e8\17\3\2\2\2\u00e9\u00ea\7k\2\2\u00ea\u00eb\7p\2\2\u00eb\u00ec\7"+
		"v\2\2\u00ec\21\3\2\2\2\u00ed\u00ee\7e\2\2\u00ee\u00ef\7j\2\2\u00ef\u00f0"+
		"\7c\2\2\u00f0\u00f1\7t\2\2\u00f1\23\3\2\2\2\u00f2\u00f3\7f\2\2\u00f3\u00f4"+
		"\7q\2\2\u00f4\u00f5\7w\2\2\u00f5\u00f6\7d\2\2\u00f6\u00f7\7n\2\2\u00f7"+
		"\u00f8\7g\2\2\u00f8\25\3\2\2\2\u00f9\u00fa\7u\2\2\u00fa\u00fb\7v\2\2\u00fb"+
		"\u00fc\7t\2\2\u00fc\u00fd\7k\2\2\u00fd\u00fe\7p\2\2\u00fe\u00ff\7i\2\2"+
		"\u00ff\27\3\2\2\2\u0100\u0101\7u\2\2\u0101\u0102\7v\2\2\u0102\u0103\7"+
		"t\2\2\u0103\u0104\7w\2\2\u0104\u0105\7e\2\2\u0105\u0106\7v\2\2\u0106\31"+
		"\3\2\2\2\u0107\u0108\7n\2\2\u0108\u0109\7q\2\2\u0109\u010a\7p\2\2\u010a"+
		"\u010b\7i\2\2\u010b\33\3\2\2\2\u010c\u010d\7d\2\2\u010d\u010e\7{\2\2\u010e"+
		"\u010f\7v\2\2\u010f\u0110\7g\2\2\u0110\35\3\2\2\2\u0111\u0112\7g\2\2\u0112"+
		"\u0113\7p\2\2\u0113\u0114\7w\2\2\u0114\u0115\7o\2\2\u0115\37\3\2\2\2\u0116"+
		"\u0117\7f\2\2\u0117\u0118\7g\2\2\u0118\u0119\7n\2\2\u0119\u011a\7g\2\2"+
		"\u011a\u011b\7i\2\2\u011b\u011c\7c\2\2\u011c\u011d\7v\2\2\u011d\u011e"+
		"\7g\2\2\u011e!\3\2\2\2\u011f\u0120\7p\2\2\u0120\u0121\7w\2\2\u0121\u0122"+
		"\7n\2\2\u0122\u0123\7n\2\2\u0123#\3\2\2\2\u0124\u0125\7v\2\2\u0125\u0126"+
		"\7t\2\2\u0126\u0127\7w\2\2\u0127\u0128\7g\2\2\u0128%\3\2\2\2\u0129\u012a"+
		"\7h\2\2\u012a\u012b\7c\2\2\u012b\u012c\7n\2\2\u012c\u012d\7u\2\2\u012d"+
		"\u012e\7g\2\2\u012e\'\3\2\2\2\u012f\u0130\7k\2\2\u0130\u0131\7h\2\2\u0131"+
		")\3\2\2\2\u0132\u0133\7g\2\2\u0133\u0134\7n\2\2\u0134\u0135\7u\2\2\u0135"+
		"\u0136\7g\2\2\u0136+\3\2\2\2\u0137\u0138\7y\2\2\u0138\u0139\7j\2\2\u0139"+
		"\u013a\7k\2\2\u013a\u013b\7n\2\2\u013b\u013c\7g\2\2\u013c-\3\2\2\2\u013d"+
		"\u013e\7h\2\2\u013e\u013f\7q\2\2\u013f\u0140\7t\2\2\u0140/\3\2\2\2\u0141"+
		"\u0142\7k\2\2\u0142\u0143\7p\2\2\u0143\61\3\2\2\2\u0144\u0145\7u\2\2\u0145"+
		"\u0146\7y\2\2\u0146\u0147\7k\2\2\u0147\u0148\7v\2\2\u0148\u0149\7e\2\2"+
		"\u0149\u014a\7j\2\2\u014a\63\3\2\2\2\u014b\u014c\7e\2\2\u014c\u014d\7"+
		"c\2\2\u014d\u014e\7u\2\2\u014e\u014f\7g\2\2\u014f\65\3\2\2\2\u0150\u0151"+
		"\7d\2\2\u0151\u0152\7t\2\2\u0152\u0153\7g\2\2\u0153\u0154\7c\2\2\u0154"+
		"\u0155\7m\2\2\u0155\67\3\2\2\2\u0156\u0157\7e\2\2\u0157\u0158\7q\2\2\u0158"+
		"\u0159\7p\2\2\u0159\u015a\7v\2\2\u015a\u015b\7k\2\2\u015b\u015c\7p\2\2"+
		"\u015c\u015d\7w\2\2\u015d\u015e\7g\2\2\u015e9\3\2\2\2\u015f\u0160\7p\2"+
		"\2\u0160\u0161\7g\2\2\u0161\u0162\7y\2\2\u0162;\3\2\2\2\u0163\u0164\7"+
		"f\2\2\u0164\u0165\7g\2\2\u0165\u0166\7n\2\2\u0166\u0167\7g\2\2\u0167\u0168"+
		"\7v\2\2\u0168\u0169\7g\2\2\u0169=\3\2\2\2\u016a\u016b\7t\2\2\u016b\u016c"+
		"\7g\2\2\u016c\u016d\7v\2\2\u016d\u016e\7w\2\2\u016e\u016f\7t\2\2\u016f"+
		"\u0170\7p\2\2\u0170?\3\2\2\2\u0171\u0172\7r\2\2\u0172\u0173\7t\2\2\u0173"+
		"\u0174\7k\2\2\u0174\u0175\7p\2\2\u0175\u0176\7v\2\2\u0176A\3\2\2\2\u0177"+
		"\u0178\7t\2\2\u0178\u0179\7g\2\2\u0179\u017a\7c\2\2\u017a\u017b\7f\2\2"+
		"\u017bC\3\2\2\2\u017c\u017d\7c\2\2\u017d\u017e\7u\2\2\u017e\u017f\7u\2"+
		"\2\u017f\u0180\7g\2\2\u0180\u0181\7t\2\2\u0181\u0182\7v\2\2\u0182E\3\2"+
		"\2\2\u0183\u0184\7f\2\2\u0184\u0185\7g\2\2\u0185\u0186\7n\2\2\u0186\u0187"+
		"\7c\2\2\u0187\u0188\7{\2\2\u0188G\3\2\2\2\u0189\u018a\7r\2\2\u018a\u018b"+
		"\7w\2\2\u018b\u018c\7d\2\2\u018c\u018d\7n\2\2\u018d\u018e\7k\2\2\u018e"+
		"\u018f\7e\2\2\u018fI\3\2\2\2\u0190\u0191\7r\2\2\u0191\u0192\7t\2\2\u0192"+
		"\u0193\7k\2\2\u0193\u0194\7x\2\2\u0194\u0195\7c\2\2\u0195\u0196\7v\2\2"+
		"\u0196\u0197\7g\2\2\u0197K\3\2\2\2\u0198\u0199\7n\2\2\u0199\u019a\7q\2"+
		"\2\u019a\u019b\7c\2\2\u019b\u019c\7f\2\2\u019cM\3\2\2\2\u019d\u019e\7"+
		"k\2\2\u019e\u019f\7o\2\2\u019f\u01a0\7r\2\2\u01a0\u01a1\7q\2\2\u01a1\u01a2"+
		"\7t\2\2\u01a2\u01a3\7v\2\2\u01a3O\3\2\2\2\u01a4\u01a5\7p\2\2\u01a5\u01a6"+
		"\7c\2\2\u01a6\u01a7\7o\2\2\u01a7\u01a8\7g\2\2\u01a8\u01a9\7u\2\2\u01a9"+
		"\u01aa\7r\2\2\u01aa\u01ab\7c\2\2\u01ab\u01ac\7e\2\2\u01ac\u01ad\7g\2\2"+
		"\u01adQ\3\2\2\2\u01ae\u01af\7w\2\2\u01af\u01b0\7u\2\2\u01b0\u01b1\7k\2"+
		"\2\u01b1\u01b2\7p\2\2\u01b2\u01b3\7i\2\2\u01b3S\3\2\2\2\u01b4\u01b5\7"+
		"k\2\2\u01b5\u01b6\7u\2\2\u01b6U\3\2\2\2\u01b7\u01b8\7\60\2\2\u01b8W\3"+
		"\2\2\2\u01b9\u01ba\7.\2\2\u01baY\3\2\2\2\u01bb\u01bc\7<\2\2\u01bc[\3\2"+
		"\2\2\u01bd\u01be\7=\2\2\u01be]\3\2\2\2\u01bf\u01c0\7?\2\2\u01c0_\3\2\2"+
		"\2\u01c1\u01c2\7,\2\2\u01c2a\3\2\2\2\u01c3\u01c4\7\61\2\2\u01c4c\3\2\2"+
		"\2\u01c5\u01c6\7\'\2\2\u01c6e\3\2\2\2\u01c7\u01c8\7/\2\2\u01c8\u01c9\7"+
		"@\2\2\u01c9g\3\2\2\2\u01ca\u01cb\7-\2\2\u01cbi\3\2\2\2\u01cc\u01cd\7/"+
		"\2\2\u01cdk\3\2\2\2\u01ce\u01cf\7-\2\2\u01cf\u01d0\7-\2\2\u01d0m\3\2\2"+
		"\2\u01d1\u01d2\7/\2\2\u01d2\u01d3\7/\2\2\u01d3o\3\2\2\2\u01d4\u01d5\7"+
		",\2\2\u01d5\u01d6\7?\2\2\u01d6q\3\2\2\2\u01d7\u01d8\7\61\2\2\u01d8\u01d9"+
		"\7?\2\2\u01d9s\3\2\2\2\u01da\u01db\7\'\2\2\u01db\u01dc\7?\2\2\u01dcu\3"+
		"\2\2\2\u01dd\u01de\7-\2\2\u01de\u01df\7?\2\2\u01dfw\3\2\2\2\u01e0\u01e1"+
		"\7/\2\2\u01e1\u01e2\7?\2\2\u01e2y\3\2\2\2\u01e3\u01e4\7#\2\2\u01e4{\3"+
		"\2\2\2\u01e5\u01e6\7(\2\2\u01e6\u01e7\7(\2\2\u01e7}\3\2\2\2\u01e8\u01e9"+
		"\7~\2\2\u01e9\u01ea\7~\2\2\u01ea\177\3\2\2\2\u01eb\u01ec\7]\2\2\u01ec"+
		"\u0081\3\2\2\2\u01ed\u01ee\7_\2\2\u01ee\u0083\3\2\2\2\u01ef\u01f0\7*\2"+
		"\2\u01f0\u0085\3\2\2\2\u01f1\u01f2\7+\2\2\u01f2\u0087\3\2\2\2\u01f3\u01f4"+
		"\7}\2\2\u01f4\u0089\3\2\2\2\u01f5\u01f6\7\177\2\2\u01f6\u008b\3\2\2\2"+
		"\u01f7\u01f8\7(\2\2\u01f8\u008d\3\2\2\2\u01f9\u01fa\7~\2\2\u01fa\u008f"+
		"\3\2\2\2\u01fb\u01fc\7`\2\2\u01fc\u0091\3\2\2\2\u01fd\u01fe\7\u0080\2"+
		"\2\u01fe\u0093\3\2\2\2\u01ff\u0200\7@\2\2\u0200\u0201\7@\2\2\u0201\u0095"+
		"\3\2\2\2\u0202\u0203\7>\2\2\u0203\u0204\7>\2\2\u0204\u0097\3\2\2\2\u0205"+
		"\u0206\7?\2\2\u0206\u0207\7?\2\2\u0207\u0099\3\2\2\2\u0208\u0209\7#\2"+
		"\2\u0209\u020a\7?\2\2\u020a\u009b\3\2\2\2\u020b\u020c\7>\2\2\u020c\u009d"+
		"\3\2\2\2\u020d\u020e\7@\2\2\u020e\u009f\3\2\2\2\u020f\u0210\7>\2\2\u0210"+
		"\u0211\7?\2\2\u0211\u00a1\3\2\2\2\u0212\u0213\7@\2\2\u0213\u0214\7?\2"+
		"\2\u0214\u00a3\3\2\2\2\u0215\u0218\7a\2\2\u0216\u0218\5\6\3\2\u0217\u0215"+
		"\3\2\2\2\u0217\u0216\3\2\2\2\u0218\u021e\3\2\2\2\u0219\u021d\7a\2\2\u021a"+
		"\u021d\5\4\2\2\u021b\u021d\5\6\3\2\u021c\u0219\3\2\2\2\u021c\u021a\3\2"+
		"\2\2\u021c\u021b\3\2\2\2\u021d\u0220\3\2\2\2\u021e\u021c\3\2\2\2\u021e"+
		"\u021f\3\2\2\2\u021f\u00a5\3\2\2\2\u0220\u021e\3\2\2\2\u0221\u022a\7\62"+
		"\2\2\u0222\u0226\t\5\2\2\u0223\u0225\t\2\2\2\u0224\u0223\3\2\2\2\u0225"+
		"\u0228\3\2\2\2\u0226\u0224\3\2\2\2\u0226\u0227\3\2\2\2\u0227\u022a\3\2"+
		"\2\2\u0228\u0226\3\2\2\2\u0229\u0221\3\2\2\2\u0229\u0222\3\2\2\2\u022a"+
		"\u00a7\3\2\2\2\u022b\u0238\5\b\4\2\u022c\u0238\5\u00a6S\2\u022d\u0230"+
		"\5\b\4\2\u022e\u0230\5\u00a6S\2\u022f\u022d\3\2\2\2\u022f\u022e\3\2\2"+
		"\2\u0230\u0231\3\2\2\2\u0231\u0233\t\6\2\2\u0232\u0234\7/\2\2\u0233\u0232"+
		"\3\2\2\2\u0233\u0234\3\2\2\2\u0234\u0235\3\2\2\2\u0235\u0236\5\u00a6S"+
		"\2\u0236\u0238\3\2\2\2\u0237\u022b\3\2\2\2\u0237\u022c\3\2\2\2\u0237\u022f"+
		"\3\2\2\2\u0238\u00a9\3\2\2\2\u0239\u023a\7)\2\2\u023a\u023b\13\2\2\2\u023b"+
		"\u024a\7)\2\2\u023c\u023d\7)\2\2\u023d\u023e\7^\2\2\u023e\u0240\3\2\2"+
		"\2\u023f\u0241\t\7\2\2\u0240\u023f\3\2\2\2\u0241\u0242\3\2\2\2\u0242\u024a"+
		"\7)\2\2\u0243\u0244\7)\2\2\u0244\u0245\7^\2\2\u0245\u0246\3\2\2\2\u0246"+
		"\u0247\5\u00a6S\2\u0247\u0248\7)\2\2\u0248\u024a\3\2\2\2\u0249\u0239\3"+
		"\2\2\2\u0249\u023c\3\2\2\2\u0249\u0243\3\2\2\2\u024a\u00ab\3\2\2\2\u024b"+
		"\u024f\7$\2\2\u024c\u024e\13\2\2\2\u024d\u024c\3\2\2\2\u024e\u0251\3\2"+
		"\2\2\u024f\u0250\3\2\2\2\u024f\u024d\3\2\2\2\u0250\u0252\3\2\2\2\u0251"+
		"\u024f\3\2\2\2\u0252\u0253\7$\2\2\u0253\u00ad\3\2\2\2\u0254\u0257\5$\22"+
		"\2\u0255\u0257\5&\23\2\u0256\u0254\3\2\2\2\u0256\u0255\3\2\2\2\u0257\u00af"+
		"\3\2\2\2\u0258\u0259\7\61\2\2\u0259\u025a\7\61\2\2\u025a\u025e\3\2\2\2"+
		"\u025b\u025d\13\2\2\2\u025c\u025b\3\2\2\2\u025d\u0260\3\2\2\2\u025e\u025f"+
		"\3\2\2\2\u025e\u025c\3\2\2\2\u025f\u0263\3\2\2\2\u0260\u025e\3\2\2\2\u0261"+
		"\u0264\5\n\5\2\u0262\u0264\7\2\2\3\u0263\u0261\3\2\2\2\u0263\u0262\3\2"+
		"\2\2\u0264\u0265\3\2\2\2\u0265\u0266\bX\3\2\u0266\u00b1\3\2\2\2\u0267"+
		"\u0268\7\61\2\2\u0268\u0269\7,\2\2\u0269\u0282\3\2\2\2\u026a\u026c\7\61"+
		"\2\2\u026b\u026a\3\2\2\2\u026c\u026f\3\2\2\2\u026d\u026e\3\2\2\2\u026d"+
		"\u026b\3\2\2\2\u026e\u0270\3\2\2\2\u026f\u026d\3\2\2\2\u0270\u0281\5\u00b2"+
		"Y\2\u0271\u0273\7\61\2\2\u0272\u0271\3\2\2\2\u0273\u0276\3\2\2\2\u0274"+
		"\u0272\3\2\2\2\u0274\u0275\3\2\2\2\u0275\u027e\3\2\2\2\u0276\u0274\3\2"+
		"\2\2\u0277\u0279\7,\2\2\u0278\u0277\3\2\2\2\u0279\u027c\3\2\2\2\u027a"+
		"\u0278\3\2\2\2\u027a\u027b\3\2\2\2\u027b\u027e\3\2\2\2\u027c\u027a\3\2"+
		"\2\2\u027d\u0274\3\2\2\2\u027d\u027a\3\2\2\2\u027e\u027f\3\2\2\2\u027f"+
		"\u0281\n\b\2\2\u0280\u026d\3\2\2\2\u0280\u027d\3\2\2\2\u0281\u0284\3\2"+
		"\2\2\u0282\u0283\3\2\2\2\u0282\u0280\3\2\2\2\u0283\u0288\3\2\2\2\u0284"+
		"\u0282\3\2\2\2\u0285\u0287\7,\2\2\u0286\u0285\3\2\2\2\u0287\u028a\3\2"+
		"\2\2\u0288\u0289\3\2\2\2\u0288\u0286\3\2\2\2\u0289\u028b\3\2\2\2\u028a"+
		"\u0288\3\2\2\2\u028b\u028c\7,\2\2\u028c\u028d\7\61\2\2\u028d\u028e\3\2"+
		"\2\2\u028e\u028f\bY\3\2\u028f\u00b3\3\2\2\2\u0290\u0293\t\t\2\2\u0291"+
		"\u0293\5\n\5\2\u0292\u0290\3\2\2\2\u0292\u0291\3\2\2\2\u0293\u0294\3\2"+
		"\2\2\u0294\u0292\3\2\2\2\u0294\u0295\3\2\2\2\u0295\u0296\3\2\2\2\u0296"+
		"\u0297\bZ\3\2\u0297\u00b5\3\2\2\2\u0298\u0299\7f\2\2\u0299\u029a\7g\2"+
		"\2\u029a\u029b\7h\2\2\u029b\u029c\7k\2\2\u029c\u029d\7p\2\2\u029d\u029e"+
		"\7g\2\2\u029e\u00b7\3\2\2\2\u029f\u02a0\7k\2\2\u02a0\u02a1\7h\2\2\u02a1"+
		"\u00b9\3\2\2\2\u02a2\u02a3\7g\2\2\u02a3\u02a4\7n\2\2\u02a4\u02a5\7k\2"+
		"\2\u02a5\u02a6\7h\2\2\u02a6\u00bb\3\2\2\2\u02a7\u02a8\7g\2\2\u02a8\u02a9"+
		"\7n\2\2\u02a9\u02aa\7u\2\2\u02aa\u02ab\7g\2\2\u02ab\u00bd\3\2\2\2\u02ac"+
		"\u02ad\5\u00b4Z\2\u02ad\u02ae\3\2\2\2\u02ae\u02af\b_\4\2\u02af\u00bf\3"+
		"\2\2\2\u02b0\u02b1\5\u00b2Y\2\u02b1\u02b2\3\2\2\2\u02b2\u02b3\b`\4\2\u02b3"+
		"\u00c1\3\2\2\2\u02b4\u02b7\5\n\5\2\u02b5\u02b7\5\u00b0X\2\u02b6\u02b4"+
		"\3\2\2\2\u02b6\u02b5\3\2\2\2\u02b7\u02b8\3\2\2\2\u02b8\u02b9\ba\4\2\u02b9"+
		"\u02ba\ba\5\2\u02ba\u00c3\3\2\2\2!\2\3\u00c9\u00cf\u00d6\u00d9\u00de\u0217"+
		"\u021c\u021e\u0226\u0229\u022f\u0233\u0237\u0240\u0249\u024f\u0256\u025e"+
		"\u0263\u026d\u0274\u027a\u027d\u0280\u0282\u0288\u0292\u0294\u02b6\6\4"+
		"\3\2\b\2\2\2\3\2\4\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}