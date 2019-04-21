lexer grammar SeagullLexer;

// Fragments
fragment DIGIT: [0-9] ;
fragment LETTER: [a-zA-Z] ;
	  
fragment
REAL: INT_CONSTANT? '.' DIGIT+
	| INT_CONSTANT '.' DIGIT*
	;
	
fragment TAG : '#' ;
fragment NL : ('\n' | '\r' | '\r\n') ;



// TODO Compiler instructions
COMP_DEFINE: '#define' ;
COMP_IF: '#if' ;
COMP_ELIF: '#elif' ;
COMP_ELSE: '#else' ;


// Types
VOID: 'void' ;
INT: 'int' ;
CHAR: 'char' ;
DOUBLE: 'double' ;
STRING: 'string' ;


// Keywords
IF: 'if' ;
ELSE: 'else' ;
WHILE: 'while' ;
FOR: 'for' ;

NEW: 'new' ;
DELETE: 'delete' ;
RETURN: 'return' ;

PRINT: 'print' ;
READ: 'read' ;

ASSERT: 'assert' ;
DELAY: 'delay' ;



// Signs

DOT: '.' ;
COMMA: ',' ;
COL: ':' ;
SEMI_COL: ';' ;
ASSIGN: '=' ;
STAR: '*' ;
SLASH: '/';
PERCENT: '%';

EQUAL: '==' ;
NOT_EQUAL: '!=' ;
LESS_THAN: '<' ;
GREATER_THAN: '>' ;
LESS_EQ_THAN: '<=' ;
GREATER_EQ_THAN: '>=' ;

PLUS: '+' ;
MINUS: '-' ;

NOT: '!' ;
AND: '&&' ;
OR: '||' ;

L_BRACKET: '[' ;
R_BRACKET: ']' ;
L_PAR: '(' ;
R_PAR: ')' ;
L_CURL: '{' ;
R_CURL: '}' ;





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
	
		 
		 
		 	 
// Comments
SL_COMMENT: '//' .*? (NL | EOF) -> skip;
ML_COMMENT : '/*' ('/'*? ML_COMMENT | ('/'* | '*'*) ~[/*])*? '*'*? '*/' -> skip;

BLANKS: (' ' | '\t' | NL)+ -> skip;


