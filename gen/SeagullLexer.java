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
			"STRING", "STRUCT", "ENUM", "DELEGATE", "TRUE", "FALSE", "IF", "ELSE", 
			"WHILE", "FOR", "NEW", "DELETE", "RETURN", "PRINT", "READ", "ASSERT", 
			"DELAY", "PUBLIC", "PRIVATE", "LOAD", "IMPORT", "NAMESPACE", "USING", 
			"DOT", "COMMA", "COL", "SEMI_COL", "ASSIGN", "STAR", "SLASH", "PERCENT", 
			"ARROW", "PLUS", "MINUS", "NOT", "AND", "OR", "L_BRACKET", "R_BRACKET", 
			"L_PAR", "R_PAR", "L_CURL", "R_CURL", "EQUAL", "NOT_EQUAL", "LESS_THAN", 
			"GREATER_THAN", "LESS_EQ_THAN", "GREATER_EQ_THAN", "ID", "INT_CONSTANT", 
			"REAL_CONSTANT", "CHAR_CONSTANT", "STRING_CONSTANT", "BOOLEAN_CONSTANT", 
			"SL_COMMENT", "ML_COMMENT", "BLANKS", "DIR_DEFINE", "DIR_IF", "DIR_ELIF", 
			"DIR_ELSE", "DIR_WHITESPACE", "DIR_ML_COMMENT", "DIR_NEWLINE"
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2H\u023c\b\1\b\1\4"+
		"\2\t\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n"+
		"\4\13\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22"+
		"\t\22\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31"+
		"\t\31\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t"+
		" \4!\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t"+
		"+\4,\t,\4-\t-\4.\t.\4/\t/\4\60\t\60\4\61\t\61\4\62\t\62\4\63\t\63\4\64"+
		"\t\64\4\65\t\65\4\66\t\66\4\67\t\67\48\t8\49\t9\4:\t:\4;\t;\4<\t<\4=\t"+
		"=\4>\t>\4?\t?\4@\t@\4A\tA\4B\tB\4C\tC\4D\tD\4E\tE\4F\tF\4G\tG\4H\tH\4"+
		"I\tI\4J\tJ\4K\tK\3\2\3\2\3\3\3\3\3\4\5\4\u009e\n\4\3\4\3\4\6\4\u00a2\n"+
		"\4\r\4\16\4\u00a3\3\4\3\4\3\4\7\4\u00a9\n\4\f\4\16\4\u00ac\13\4\5\4\u00ae"+
		"\n\4\3\5\3\5\3\5\5\5\u00b3\n\5\3\6\3\6\3\6\3\6\3\7\3\7\3\7\3\7\3\7\3\b"+
		"\3\b\3\b\3\b\3\t\3\t\3\t\3\t\3\t\3\n\3\n\3\n\3\n\3\n\3\n\3\n\3\13\3\13"+
		"\3\13\3\13\3\13\3\13\3\13\3\f\3\f\3\f\3\f\3\f\3\f\3\f\3\r\3\r\3\r\3\r"+
		"\3\r\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\17\3\17\3\17\3\17"+
		"\3\17\3\20\3\20\3\20\3\20\3\20\3\20\3\21\3\21\3\21\3\22\3\22\3\22\3\22"+
		"\3\22\3\23\3\23\3\23\3\23\3\23\3\23\3\24\3\24\3\24\3\24\3\25\3\25\3\25"+
		"\3\25\3\26\3\26\3\26\3\26\3\26\3\26\3\26\3\27\3\27\3\27\3\27\3\27\3\27"+
		"\3\27\3\30\3\30\3\30\3\30\3\30\3\30\3\31\3\31\3\31\3\31\3\31\3\32\3\32"+
		"\3\32\3\32\3\32\3\32\3\32\3\33\3\33\3\33\3\33\3\33\3\33\3\34\3\34\3\34"+
		"\3\34\3\34\3\34\3\34\3\35\3\35\3\35\3\35\3\35\3\35\3\35\3\35\3\36\3\36"+
		"\3\36\3\36\3\36\3\37\3\37\3\37\3\37\3\37\3\37\3\37\3 \3 \3 \3 \3 \3 \3"+
		" \3 \3 \3 \3!\3!\3!\3!\3!\3!\3\"\3\"\3#\3#\3$\3$\3%\3%\3&\3&\3\'\3\'\3"+
		"(\3(\3)\3)\3*\3*\3*\3+\3+\3,\3,\3-\3-\3.\3.\3.\3/\3/\3/\3\60\3\60\3\61"+
		"\3\61\3\62\3\62\3\63\3\63\3\64\3\64\3\65\3\65\3\66\3\66\3\66\3\67\3\67"+
		"\3\67\38\38\39\39\3:\3:\3:\3;\3;\3;\3<\3<\5<\u0199\n<\3<\3<\3<\7<\u019e"+
		"\n<\f<\16<\u01a1\13<\3=\3=\3=\7=\u01a6\n=\f=\16=\u01a9\13=\5=\u01ab\n"+
		"=\3>\3>\3>\3>\5>\u01b1\n>\3>\3>\5>\u01b5\n>\3>\3>\5>\u01b9\n>\3?\3?\3"+
		"?\3?\3?\3?\3?\5?\u01c2\n?\3?\3?\3?\3?\3?\3?\3?\5?\u01cb\n?\3@\3@\7@\u01cf"+
		"\n@\f@\16@\u01d2\13@\3@\3@\3A\3A\5A\u01d8\nA\3B\3B\3B\3B\7B\u01de\nB\f"+
		"B\16B\u01e1\13B\3B\3B\5B\u01e5\nB\3B\3B\3C\3C\3C\3C\7C\u01ed\nC\fC\16"+
		"C\u01f0\13C\3C\3C\7C\u01f4\nC\fC\16C\u01f7\13C\3C\7C\u01fa\nC\fC\16C\u01fd"+
		"\13C\5C\u01ff\nC\3C\7C\u0202\nC\fC\16C\u0205\13C\3C\7C\u0208\nC\fC\16"+
		"C\u020b\13C\3C\3C\3C\3C\3C\3D\3D\6D\u0214\nD\rD\16D\u0215\3D\3D\3E\3E"+
		"\3E\3E\3E\3E\3E\3F\3F\3F\3G\3G\3G\3G\3G\3H\3H\3H\3H\3H\3I\3I\3I\3I\3J"+
		"\3J\3J\3J\3K\3K\5K\u0238\nK\3K\3K\3K\7\u01d0\u01df\u01ee\u0203\u0209\2"+
		"L\4\2\6\2\b\2\n\2\f\3\16\4\20\5\22\6\24\7\26\b\30\t\32\n\34\13\36\f \r"+
		"\"\16$\17&\20(\21*\22,\23.\24\60\25\62\26\64\27\66\308\31:\32<\33>\34"+
		"@\35B\36D\37F H!J\"L#N$P%R&T\'V(X)Z*\\+^,`-b.d/f\60h\61j\62l\63n\64p\65"+
		"r\66t\67v8x9z:|;~<\u0080=\u0082>\u0084?\u0086@\u0088A\u008aB\u008cC\u008e"+
		"D\u0090E\u0092F\u0094G\u0096H\4\2\3\n\3\2\62;\4\2C\\c|\4\2\f\f\17\17\3"+
		"\2\63;\4\2GGgg\7\2))^^ppttvv\4\2,,\61\61\4\2\13\13\"\"\2\u0255\2\f\3\2"+
		"\2\2\2\16\3\2\2\2\2\20\3\2\2\2\2\22\3\2\2\2\2\24\3\2\2\2\2\26\3\2\2\2"+
		"\2\30\3\2\2\2\2\32\3\2\2\2\2\34\3\2\2\2\2\36\3\2\2\2\2 \3\2\2\2\2\"\3"+
		"\2\2\2\2$\3\2\2\2\2&\3\2\2\2\2(\3\2\2\2\2*\3\2\2\2\2,\3\2\2\2\2.\3\2\2"+
		"\2\2\60\3\2\2\2\2\62\3\2\2\2\2\64\3\2\2\2\2\66\3\2\2\2\28\3\2\2\2\2:\3"+
		"\2\2\2\2<\3\2\2\2\2>\3\2\2\2\2@\3\2\2\2\2B\3\2\2\2\2D\3\2\2\2\2F\3\2\2"+
		"\2\2H\3\2\2\2\2J\3\2\2\2\2L\3\2\2\2\2N\3\2\2\2\2P\3\2\2\2\2R\3\2\2\2\2"+
		"T\3\2\2\2\2V\3\2\2\2\2X\3\2\2\2\2Z\3\2\2\2\2\\\3\2\2\2\2^\3\2\2\2\2`\3"+
		"\2\2\2\2b\3\2\2\2\2d\3\2\2\2\2f\3\2\2\2\2h\3\2\2\2\2j\3\2\2\2\2l\3\2\2"+
		"\2\2n\3\2\2\2\2p\3\2\2\2\2r\3\2\2\2\2t\3\2\2\2\2v\3\2\2\2\2x\3\2\2\2\2"+
		"z\3\2\2\2\2|\3\2\2\2\2~\3\2\2\2\2\u0080\3\2\2\2\2\u0082\3\2\2\2\2\u0084"+
		"\3\2\2\2\2\u0086\3\2\2\2\2\u0088\3\2\2\2\3\u008a\3\2\2\2\3\u008c\3\2\2"+
		"\2\3\u008e\3\2\2\2\3\u0090\3\2\2\2\3\u0092\3\2\2\2\3\u0094\3\2\2\2\3\u0096"+
		"\3\2\2\2\4\u0098\3\2\2\2\6\u009a\3\2\2\2\b\u00ad\3\2\2\2\n\u00b2\3\2\2"+
		"\2\f\u00b4\3\2\2\2\16\u00b8\3\2\2\2\20\u00bd\3\2\2\2\22\u00c1\3\2\2\2"+
		"\24\u00c6\3\2\2\2\26\u00cd\3\2\2\2\30\u00d4\3\2\2\2\32\u00db\3\2\2\2\34"+
		"\u00e0\3\2\2\2\36\u00e9\3\2\2\2 \u00ee\3\2\2\2\"\u00f4\3\2\2\2$\u00f7"+
		"\3\2\2\2&\u00fc\3\2\2\2(\u0102\3\2\2\2*\u0106\3\2\2\2,\u010a\3\2\2\2."+
		"\u0111\3\2\2\2\60\u0118\3\2\2\2\62\u011e\3\2\2\2\64\u0123\3\2\2\2\66\u012a"+
		"\3\2\2\28\u0130\3\2\2\2:\u0137\3\2\2\2<\u013f\3\2\2\2>\u0144\3\2\2\2@"+
		"\u014b\3\2\2\2B\u0155\3\2\2\2D\u015b\3\2\2\2F\u015d\3\2\2\2H\u015f\3\2"+
		"\2\2J\u0161\3\2\2\2L\u0163\3\2\2\2N\u0165\3\2\2\2P\u0167\3\2\2\2R\u0169"+
		"\3\2\2\2T\u016b\3\2\2\2V\u016e\3\2\2\2X\u0170\3\2\2\2Z\u0172\3\2\2\2\\"+
		"\u0174\3\2\2\2^\u0177\3\2\2\2`\u017a\3\2\2\2b\u017c\3\2\2\2d\u017e\3\2"+
		"\2\2f\u0180\3\2\2\2h\u0182\3\2\2\2j\u0184\3\2\2\2l\u0186\3\2\2\2n\u0189"+
		"\3\2\2\2p\u018c\3\2\2\2r\u018e\3\2\2\2t\u0190\3\2\2\2v\u0193\3\2\2\2x"+
		"\u0198\3\2\2\2z\u01aa\3\2\2\2|\u01b8\3\2\2\2~\u01ca\3\2\2\2\u0080\u01cc"+
		"\3\2\2\2\u0082\u01d7\3\2\2\2\u0084\u01d9\3\2\2\2\u0086\u01e8\3\2\2\2\u0088"+
		"\u0213\3\2\2\2\u008a\u0219\3\2\2\2\u008c\u0220\3\2\2\2\u008e\u0223\3\2"+
		"\2\2\u0090\u0228\3\2\2\2\u0092\u022d\3\2\2\2\u0094\u0231\3\2\2\2\u0096"+
		"\u0237\3\2\2\2\u0098\u0099\t\2\2\2\u0099\5\3\2\2\2\u009a\u009b\t\3\2\2"+
		"\u009b\7\3\2\2\2\u009c\u009e\5z=\2\u009d\u009c\3\2\2\2\u009d\u009e\3\2"+
		"\2\2\u009e\u009f\3\2\2\2\u009f\u00a1\7\60\2\2\u00a0\u00a2\5\4\2\2\u00a1"+
		"\u00a0\3\2\2\2\u00a2\u00a3\3\2\2\2\u00a3\u00a1\3\2\2\2\u00a3\u00a4\3\2"+
		"\2\2\u00a4\u00ae\3\2\2\2\u00a5\u00a6\5z=\2\u00a6\u00aa\7\60\2\2\u00a7"+
		"\u00a9\5\4\2\2\u00a8\u00a7\3\2\2\2\u00a9\u00ac\3\2\2\2\u00aa\u00a8\3\2"+
		"\2\2\u00aa\u00ab\3\2\2\2\u00ab\u00ae\3\2\2\2\u00ac\u00aa\3\2\2\2\u00ad"+
		"\u009d\3\2\2\2\u00ad\u00a5\3\2\2\2\u00ae\t\3\2\2\2\u00af\u00b3\t\4\2\2"+
		"\u00b0\u00b1\7\17\2\2\u00b1\u00b3\7\f\2\2\u00b2\u00af\3\2\2\2\u00b2\u00b0"+
		"\3\2\2\2\u00b3\13\3\2\2\2\u00b4\u00b5\7%\2\2\u00b5\u00b6\3\2\2\2\u00b6"+
		"\u00b7\b\6\2\2\u00b7\r\3\2\2\2\u00b8\u00b9\7x\2\2\u00b9\u00ba\7q\2\2\u00ba"+
		"\u00bb\7k\2\2\u00bb\u00bc\7f\2\2\u00bc\17\3\2\2\2\u00bd\u00be\7k\2\2\u00be"+
		"\u00bf\7p\2\2\u00bf\u00c0\7v\2\2\u00c0\21\3\2\2\2\u00c1\u00c2\7e\2\2\u00c2"+
		"\u00c3\7j\2\2\u00c3\u00c4\7c\2\2\u00c4\u00c5\7t\2\2\u00c5\23\3\2\2\2\u00c6"+
		"\u00c7\7f\2\2\u00c7\u00c8\7q\2\2\u00c8\u00c9\7w\2\2\u00c9\u00ca\7d\2\2"+
		"\u00ca\u00cb\7n\2\2\u00cb\u00cc\7g\2\2\u00cc\25\3\2\2\2\u00cd\u00ce\7"+
		"u\2\2\u00ce\u00cf\7v\2\2\u00cf\u00d0\7t\2\2\u00d0\u00d1\7k\2\2\u00d1\u00d2"+
		"\7p\2\2\u00d2\u00d3\7i\2\2\u00d3\27\3\2\2\2\u00d4\u00d5\7u\2\2\u00d5\u00d6"+
		"\7v\2\2\u00d6\u00d7\7t\2\2\u00d7\u00d8\7w\2\2\u00d8\u00d9\7e\2\2\u00d9"+
		"\u00da\7v\2\2\u00da\31\3\2\2\2\u00db\u00dc\7g\2\2\u00dc\u00dd\7p\2\2\u00dd"+
		"\u00de\7w\2\2\u00de\u00df\7o\2\2\u00df\33\3\2\2\2\u00e0\u00e1\7f\2\2\u00e1"+
		"\u00e2\7g\2\2\u00e2\u00e3\7n\2\2\u00e3\u00e4\7g\2\2\u00e4\u00e5\7i\2\2"+
		"\u00e5\u00e6\7c\2\2\u00e6\u00e7\7v\2\2\u00e7\u00e8\7g\2\2\u00e8\35\3\2"+
		"\2\2\u00e9\u00ea\7v\2\2\u00ea\u00eb\7t\2\2\u00eb\u00ec\7w\2\2\u00ec\u00ed"+
		"\7g\2\2\u00ed\37\3\2\2\2\u00ee\u00ef\7h\2\2\u00ef\u00f0\7c\2\2\u00f0\u00f1"+
		"\7n\2\2\u00f1\u00f2\7u\2\2\u00f2\u00f3\7g\2\2\u00f3!\3\2\2\2\u00f4\u00f5"+
		"\7k\2\2\u00f5\u00f6\7h\2\2\u00f6#\3\2\2\2\u00f7\u00f8\7g\2\2\u00f8\u00f9"+
		"\7n\2\2\u00f9\u00fa\7u\2\2\u00fa\u00fb\7g\2\2\u00fb%\3\2\2\2\u00fc\u00fd"+
		"\7y\2\2\u00fd\u00fe\7j\2\2\u00fe\u00ff\7k\2\2\u00ff\u0100\7n\2\2\u0100"+
		"\u0101\7g\2\2\u0101\'\3\2\2\2\u0102\u0103\7h\2\2\u0103\u0104\7q\2\2\u0104"+
		"\u0105\7t\2\2\u0105)\3\2\2\2\u0106\u0107\7p\2\2\u0107\u0108\7g\2\2\u0108"+
		"\u0109\7y\2\2\u0109+\3\2\2\2\u010a\u010b\7f\2\2\u010b\u010c\7g\2\2\u010c"+
		"\u010d\7n\2\2\u010d\u010e\7g\2\2\u010e\u010f\7v\2\2\u010f\u0110\7g\2\2"+
		"\u0110-\3\2\2\2\u0111\u0112\7t\2\2\u0112\u0113\7g\2\2\u0113\u0114\7v\2"+
		"\2\u0114\u0115\7w\2\2\u0115\u0116\7t\2\2\u0116\u0117\7p\2\2\u0117/\3\2"+
		"\2\2\u0118\u0119\7r\2\2\u0119\u011a\7t\2\2\u011a\u011b\7k\2\2\u011b\u011c"+
		"\7p\2\2\u011c\u011d\7v\2\2\u011d\61\3\2\2\2\u011e\u011f\7t\2\2\u011f\u0120"+
		"\7g\2\2\u0120\u0121\7c\2\2\u0121\u0122\7f\2\2\u0122\63\3\2\2\2\u0123\u0124"+
		"\7c\2\2\u0124\u0125\7u\2\2\u0125\u0126\7u\2\2\u0126\u0127\7g\2\2\u0127"+
		"\u0128\7t\2\2\u0128\u0129\7v\2\2\u0129\65\3\2\2\2\u012a\u012b\7f\2\2\u012b"+
		"\u012c\7g\2\2\u012c\u012d\7n\2\2\u012d\u012e\7c\2\2\u012e\u012f\7{\2\2"+
		"\u012f\67\3\2\2\2\u0130\u0131\7r\2\2\u0131\u0132\7w\2\2\u0132\u0133\7"+
		"d\2\2\u0133\u0134\7n\2\2\u0134\u0135\7k\2\2\u0135\u0136\7e\2\2\u01369"+
		"\3\2\2\2\u0137\u0138\7r\2\2\u0138\u0139\7t\2\2\u0139\u013a\7k\2\2\u013a"+
		"\u013b\7x\2\2\u013b\u013c\7c\2\2\u013c\u013d\7v\2\2\u013d\u013e\7g\2\2"+
		"\u013e;\3\2\2\2\u013f\u0140\7n\2\2\u0140\u0141\7q\2\2\u0141\u0142\7c\2"+
		"\2\u0142\u0143\7f\2\2\u0143=\3\2\2\2\u0144\u0145\7k\2\2\u0145\u0146\7"+
		"o\2\2\u0146\u0147\7r\2\2\u0147\u0148\7q\2\2\u0148\u0149\7t\2\2\u0149\u014a"+
		"\7v\2\2\u014a?\3\2\2\2\u014b\u014c\7p\2\2\u014c\u014d\7c\2\2\u014d\u014e"+
		"\7o\2\2\u014e\u014f\7g\2\2\u014f\u0150\7u\2\2\u0150\u0151\7r\2\2\u0151"+
		"\u0152\7c\2\2\u0152\u0153\7e\2\2\u0153\u0154\7g\2\2\u0154A\3\2\2\2\u0155"+
		"\u0156\7w\2\2\u0156\u0157\7u\2\2\u0157\u0158\7k\2\2\u0158\u0159\7p\2\2"+
		"\u0159\u015a\7i\2\2\u015aC\3\2\2\2\u015b\u015c\7\60\2\2\u015cE\3\2\2\2"+
		"\u015d\u015e\7.\2\2\u015eG\3\2\2\2\u015f\u0160\7<\2\2\u0160I\3\2\2\2\u0161"+
		"\u0162\7=\2\2\u0162K\3\2\2\2\u0163\u0164\7?\2\2\u0164M\3\2\2\2\u0165\u0166"+
		"\7,\2\2\u0166O\3\2\2\2\u0167\u0168\7\61\2\2\u0168Q\3\2\2\2\u0169\u016a"+
		"\7\'\2\2\u016aS\3\2\2\2\u016b\u016c\7/\2\2\u016c\u016d\7@\2\2\u016dU\3"+
		"\2\2\2\u016e\u016f\7-\2\2\u016fW\3\2\2\2\u0170\u0171\7/\2\2\u0171Y\3\2"+
		"\2\2\u0172\u0173\7#\2\2\u0173[\3\2\2\2\u0174\u0175\7(\2\2\u0175\u0176"+
		"\7(\2\2\u0176]\3\2\2\2\u0177\u0178\7~\2\2\u0178\u0179\7~\2\2\u0179_\3"+
		"\2\2\2\u017a\u017b\7]\2\2\u017ba\3\2\2\2\u017c\u017d\7_\2\2\u017dc\3\2"+
		"\2\2\u017e\u017f\7*\2\2\u017fe\3\2\2\2\u0180\u0181\7+\2\2\u0181g\3\2\2"+
		"\2\u0182\u0183\7}\2\2\u0183i\3\2\2\2\u0184\u0185\7\177\2\2\u0185k\3\2"+
		"\2\2\u0186\u0187\7?\2\2\u0187\u0188\7?\2\2\u0188m\3\2\2\2\u0189\u018a"+
		"\7#\2\2\u018a\u018b\7?\2\2\u018bo\3\2\2\2\u018c\u018d\7>\2\2\u018dq\3"+
		"\2\2\2\u018e\u018f\7@\2\2\u018fs\3\2\2\2\u0190\u0191\7>\2\2\u0191\u0192"+
		"\7?\2\2\u0192u\3\2\2\2\u0193\u0194\7@\2\2\u0194\u0195\7?\2\2\u0195w\3"+
		"\2\2\2\u0196\u0199\7a\2\2\u0197\u0199\5\6\3\2\u0198\u0196\3\2\2\2\u0198"+
		"\u0197\3\2\2\2\u0199\u019f\3\2\2\2\u019a\u019e\7a\2\2\u019b\u019e\5\4"+
		"\2\2\u019c\u019e\5\6\3\2\u019d\u019a\3\2\2\2\u019d\u019b\3\2\2\2\u019d"+
		"\u019c\3\2\2\2\u019e\u01a1\3\2\2\2\u019f\u019d\3\2\2\2\u019f\u01a0\3\2"+
		"\2\2\u01a0y\3\2\2\2\u01a1\u019f\3\2\2\2\u01a2\u01ab\7\62\2\2\u01a3\u01a7"+
		"\t\5\2\2\u01a4\u01a6\t\2\2\2\u01a5\u01a4\3\2\2\2\u01a6\u01a9\3\2\2\2\u01a7"+
		"\u01a5\3\2\2\2\u01a7\u01a8\3\2\2\2\u01a8\u01ab\3\2\2\2\u01a9\u01a7\3\2"+
		"\2\2\u01aa\u01a2\3\2\2\2\u01aa\u01a3\3\2\2\2\u01ab{\3\2\2\2\u01ac\u01b9"+
		"\5\b\4\2\u01ad\u01b9\5z=\2\u01ae\u01b1\5\b\4\2\u01af\u01b1\5z=\2\u01b0"+
		"\u01ae\3\2\2\2\u01b0\u01af\3\2\2\2\u01b1\u01b2\3\2\2\2\u01b2\u01b4\t\6"+
		"\2\2\u01b3\u01b5\7/\2\2\u01b4\u01b3\3\2\2\2\u01b4\u01b5\3\2\2\2\u01b5"+
		"\u01b6\3\2\2\2\u01b6\u01b7\5z=\2\u01b7\u01b9\3\2\2\2\u01b8\u01ac\3\2\2"+
		"\2\u01b8\u01ad\3\2\2\2\u01b8\u01b0\3\2\2\2\u01b9}\3\2\2\2\u01ba\u01bb"+
		"\7)\2\2\u01bb\u01bc\13\2\2\2\u01bc\u01cb\7)\2\2\u01bd\u01be\7)\2\2\u01be"+
		"\u01bf\7^\2\2\u01bf\u01c1\3\2\2\2\u01c0\u01c2\t\7\2\2\u01c1\u01c0\3\2"+
		"\2\2\u01c2\u01c3\3\2\2\2\u01c3\u01cb\7)\2\2\u01c4\u01c5\7)\2\2\u01c5\u01c6"+
		"\7^\2\2\u01c6\u01c7\3\2\2\2\u01c7\u01c8\5z=\2\u01c8\u01c9\7)\2\2\u01c9"+
		"\u01cb\3\2\2\2\u01ca\u01ba\3\2\2\2\u01ca\u01bd\3\2\2\2\u01ca\u01c4\3\2"+
		"\2\2\u01cb\177\3\2\2\2\u01cc\u01d0\7$\2\2\u01cd\u01cf\13\2\2\2\u01ce\u01cd"+
		"\3\2\2\2\u01cf\u01d2\3\2\2\2\u01d0\u01d1\3\2\2\2\u01d0\u01ce\3\2\2\2\u01d1"+
		"\u01d3\3\2\2\2\u01d2\u01d0\3\2\2\2\u01d3\u01d4\7$\2\2\u01d4\u0081\3\2"+
		"\2\2\u01d5\u01d8\5\36\17\2\u01d6\u01d8\5 \20\2\u01d7\u01d5\3\2\2\2\u01d7"+
		"\u01d6\3\2\2\2\u01d8\u0083\3\2\2\2\u01d9\u01da\7\61\2\2\u01da\u01db\7"+
		"\61\2\2\u01db\u01df\3\2\2\2\u01dc\u01de\13\2\2\2\u01dd\u01dc\3\2\2\2\u01de"+
		"\u01e1\3\2\2\2\u01df\u01e0\3\2\2\2\u01df\u01dd\3\2\2\2\u01e0\u01e4\3\2"+
		"\2\2\u01e1\u01df\3\2\2\2\u01e2\u01e5\5\n\5\2\u01e3\u01e5\7\2\2\3\u01e4"+
		"\u01e2\3\2\2\2\u01e4\u01e3\3\2\2\2\u01e5\u01e6\3\2\2\2\u01e6\u01e7\bB"+
		"\3\2\u01e7\u0085\3\2\2\2\u01e8\u01e9\7\61\2\2\u01e9\u01ea\7,\2\2\u01ea"+
		"\u0203\3\2\2\2\u01eb\u01ed\7\61\2\2\u01ec\u01eb\3\2\2\2\u01ed\u01f0\3"+
		"\2\2\2\u01ee\u01ef\3\2\2\2\u01ee\u01ec\3\2\2\2\u01ef\u01f1\3\2\2\2\u01f0"+
		"\u01ee\3\2\2\2\u01f1\u0202\5\u0086C\2\u01f2\u01f4\7\61\2\2\u01f3\u01f2"+
		"\3\2\2\2\u01f4\u01f7\3\2\2\2\u01f5\u01f3\3\2\2\2\u01f5\u01f6\3\2\2\2\u01f6"+
		"\u01ff\3\2\2\2\u01f7\u01f5\3\2\2\2\u01f8\u01fa\7,\2\2\u01f9\u01f8\3\2"+
		"\2\2\u01fa\u01fd\3\2\2\2\u01fb\u01f9\3\2\2\2\u01fb\u01fc\3\2\2\2\u01fc"+
		"\u01ff\3\2\2\2\u01fd\u01fb\3\2\2\2\u01fe\u01f5\3\2\2\2\u01fe\u01fb\3\2"+
		"\2\2\u01ff\u0200\3\2\2\2\u0200\u0202\n\b\2\2\u0201\u01ee\3\2\2\2\u0201"+
		"\u01fe\3\2\2\2\u0202\u0205\3\2\2\2\u0203\u0204\3\2\2\2\u0203\u0201\3\2"+
		"\2\2\u0204\u0209\3\2\2\2\u0205\u0203\3\2\2\2\u0206\u0208\7,\2\2\u0207"+
		"\u0206\3\2\2\2\u0208\u020b\3\2\2\2\u0209\u020a\3\2\2\2\u0209\u0207\3\2"+
		"\2\2\u020a\u020c\3\2\2\2\u020b\u0209\3\2\2\2\u020c\u020d\7,\2\2\u020d"+
		"\u020e\7\61\2\2\u020e\u020f\3\2\2\2\u020f\u0210\bC\3\2\u0210\u0087\3\2"+
		"\2\2\u0211\u0214\t\t\2\2\u0212\u0214\5\n\5\2\u0213\u0211\3\2\2\2\u0213"+
		"\u0212\3\2\2\2\u0214\u0215\3\2\2\2\u0215\u0213\3\2\2\2\u0215\u0216\3\2"+
		"\2\2\u0216\u0217\3\2\2\2\u0217\u0218\bD\3\2\u0218\u0089\3\2\2\2\u0219"+
		"\u021a\7f\2\2\u021a\u021b\7g\2\2\u021b\u021c\7h\2\2\u021c\u021d\7k\2\2"+
		"\u021d\u021e\7p\2\2\u021e\u021f\7g\2\2\u021f\u008b\3\2\2\2\u0220\u0221"+
		"\7k\2\2\u0221\u0222\7h\2\2\u0222\u008d\3\2\2\2\u0223\u0224\7g\2\2\u0224"+
		"\u0225\7n\2\2\u0225\u0226\7k\2\2\u0226\u0227\7h\2\2\u0227\u008f\3\2\2"+
		"\2\u0228\u0229\7g\2\2\u0229\u022a\7n\2\2\u022a\u022b\7u\2\2\u022b\u022c"+
		"\7g\2\2\u022c\u0091\3\2\2\2\u022d\u022e\5\u0088D\2\u022e\u022f\3\2\2\2"+
		"\u022f\u0230\bI\4\2\u0230\u0093\3\2\2\2\u0231\u0232\5\u0086C\2\u0232\u0233"+
		"\3\2\2\2\u0233\u0234\bJ\4\2\u0234\u0095\3\2\2\2\u0235\u0238\5\n\5\2\u0236"+
		"\u0238\5\u0084B\2\u0237\u0235\3\2\2\2\u0237\u0236\3\2\2\2\u0238\u0239"+
		"\3\2\2\2\u0239\u023a\bK\4\2\u023a\u023b\bK\5\2\u023b\u0097\3\2\2\2!\2"+
		"\3\u009d\u00a3\u00aa\u00ad\u00b2\u0198\u019d\u019f\u01a7\u01aa\u01b0\u01b4"+
		"\u01b8\u01c1\u01ca\u01d0\u01d7\u01df\u01e4\u01ee\u01f5\u01fb\u01fe\u0201"+
		"\u0203\u0209\u0213\u0215\u0237\6\4\3\2\b\2\2\2\3\2\4\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}