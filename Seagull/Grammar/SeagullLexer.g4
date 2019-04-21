lexer grammar SeagullLexer;

// Fragments
fragment DIGIT: [0-9] ;
fragment LETTER: [a-zA-Z] ;
	  
fragment
REAL: INT_CONSTANT? '.' DIGIT+
	| INT_CONSTANT '.' DIGIT*
	;
	
fragment TAG: '#' ;
fragment NL: ('\n' | '\r' | '\r\n') ;



// TODO Compiler instructions

COMP_LOAD: '#load' ;
COMP_IMPORT: '#import' ;

COMP_DEFINE: '#define' ;
COMP_IF: '#if' ;
COMP_ELIF: '#elif' ;
COMP_ELSE: '#else' ;



// Types
VOID:       'void' ;
INT:        'int' ;
CHAR:       'char' ;
DOUBLE:     'double' ;
STRING:     'string' ;
STRUCT:     'struct' ;
ENUM:       'enum' ;

// Keywords
IF:         'if' ;
ELSE:       'else' ;
WHILE:      'while' ;
FOR:        'for' ;

DELEGATE:   'delegate' ;

NEW:        'new' ;
DELETE:     'delete' ;
RETURN:     'return' ;
PRINT:      'print' ;
READ:       'read' ;
ASSERT:     'assert' ;
DELAY:      'delay' ;



// Signs

DOT:        '.' ;
COMMA:      ',' ;
COL:        ':' ;
SEMI_COL:   ';' ;
ASSIGN:     '=' ;
STAR:       '*' ;
SLASH:      '/' ;
PERCENT:    '%' ;
ARROW:      '->' ;

PLUS:       '+' ;
MINUS:      '-' ;

NOT:        '!' ;
AND:        '&&' ;
OR:         '||' ;

L_BRACKET:  '[' ;
R_BRACKET:  ']' ;
L_PAR:      '(' ;
R_PAR:      ')' ;
L_CURL:     '{' ;
R_CURL:     '}' ;

EQUAL:              '==' ;
NOT_EQUAL:          '!=' ;
LESS_THAN:          '<' ;
GREATER_THAN:       '>' ;
LESS_EQ_THAN:       '<=' ;
GREATER_EQ_THAN:    '>=' ;






// IDs and Constants
ID: ('_' | LETTER) ('_' | DIGIT | LETTER)* ;
  		 
INT_CONSTANT: '0'
			| [1-9] [0-9]* 
            ;

REAL_CONSTANT: REAL | INT_CONSTANT
			 | (REAL | INT_CONSTANT) ('e' | 'E') '-'? INT_CONSTANT
			 ;
			 			 
CHAR_CONSTANT: '\'' . '\''
			 | '\'\\' ([tnr] | '\\' | '\'')  '\''
			 | '\'\\' INT_CONSTANT '\''
			 ;
	
STRING_CONSTANT: '"' .*? '"' ;

		 
		 	 
// Comments
SL_COMMENT: '//' .*? (NL | EOF) -> skip;
ML_COMMENT : '/*' ('/'*? ML_COMMENT | ('/'* | '*'*) ~[/*])*? '*'*? '*/' -> skip;

BLANKS: (' ' | '\t' | NL)+ -> skip;


