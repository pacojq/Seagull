lexer grammar SeagullLexer;



channels { DIRECTIVE }


// Fragments
fragment DIGIT: [0-9] ;
fragment LETTER: [a-zA-Z] ;
	  
fragment
REAL: INT_CONSTANT? '.' DIGIT+
	| INT_CONSTANT '.' DIGIT*
	;
	
fragment NL: ('\n' | '\r' | '\r\n') ;



// Compiler directives
SHARP: '#'  -> mode(DIRECTIVE_MODE);


// Types
VOID:       'void' ;
INT:        'int' ;
CHAR:       'char' ;
DOUBLE:     'double' ;
STRING:     'string' ;
STRUCT:     'struct' ;
ENUM:       'enum' ;
DELEGATE:   'delegate' ;


// Keywords
TRUE:       'true' ;
FALSE:      'false' ;

IF:         'if' ;
ELSE:       'else' ;
WHILE:      'while' ;
FOR:        'for' ;

NEW:        'new' ;
DELETE:     'delete' ;
RETURN:     'return' ;
PRINT:      'print' ;
READ:       'read' ;
ASSERT:     'assert' ;
DELAY:      'delay' ;

PUBLIC:     'public' ;
PRIVATE:    'private' ;

LOAD:       'load' ;
IMPORT:     'import' ;
NAMESPACE:  'namespace' ;



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
  		 
INT_CONSTANT: 
        '0'
	|   [1-9] [0-9]* 
    ;

REAL_CONSTANT: 
        REAL 
    |   INT_CONSTANT
	|   (REAL | INT_CONSTANT) ('e' | 'E') '-'? INT_CONSTANT
    ;
			 			 
CHAR_CONSTANT: 
        '\'' . '\''
	|   '\'\\' ([tnr] | '\\' | '\'')  '\''
	|   '\'\\' INT_CONSTANT '\''
	;
	
STRING_CONSTANT: '"' .*? '"' ;

BOOLEAN_CONSTANT: TRUE | FALSE ;

		 
		 	 
// Comments
SL_COMMENT: '//' .*? (NL | EOF) -> skip;
ML_COMMENT : '/*' ('/'*? ML_COMMENT | ('/'* | '*'*) ~[/*])*? '*'*? '*/' -> skip;

BLANKS: (' ' | '\t' | NL)+ -> skip;







// ==================================================== //
//                                                      //
//                  COMPILER DIRECTIVES                 //
//                                                      //
// ==================================================== //

mode DIRECTIVE_MODE;

DIR_DEFINE:     'define' ;
DIR_IF:         'if' ;
DIR_ELIF:       'elif' ;
DIR_ELSE:       'else' ;

DIR_WHITESPACE: BLANKS -> channel(HIDDEN);
DIR_ML_COMMENT: ML_COMMENT -> channel(HIDDEN);
DIR_NEWLINE: (NL | SL_COMMENT) -> channel(HIDDEN), mode(DEFAULT_MODE);