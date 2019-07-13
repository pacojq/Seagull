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
LONG:       'long' ;
BYTE:       'byte' ;
ENUM:       'enum' ; // TODO
DELEGATE:   'delegate' ; // TODO

CLASS:      'class' ; // TODO ?

// Keywords
NULL:       'null' ; // TODO
PTR:        'ptr' ; // TODO

TRUE:       'true' ;
FALSE:      'false' ;

IF:         'if' ;
ELSE:       'else' ;
WHILE:      'while' ;

FOR:        'for' ;
IN:         'in';
SWITCH:     'switch' ; // TODO
CASE:       'case' ; // TODO
BREAK:      'break' ; 
CONTINUE:   'continue';

NEW:        'new' ;
DELETE:     'delete' ; // TODO
RETURN:     'return' ;
PRINT:      'print' ;
READ:       'read' ; 
ASSERT:     'assert' ; // TODO
DELAY:      'delay' ;

// Access modifiers
PUBLIC:     'public' ; // TODO
PROTECTED:  'protected' ; // TODO
PRIVATE:    'private' ; // TODO
// TODO friend namespaces ?
FRIEND:     'friend' ; // friend namespace 'name' { 'available access nodifiers' }

OVERRIDE:   'override' ; // TODO ?
LOCKED:     'locked' ;   // TODO ? - prevents overrides
ABSTRACT:   'abstract' ; // TODO ?


LOAD:       'load' ;
IMPORT:     'import' ;
NAMESPACE:  'namespace' ;


// TODO
OWNED:      'owned' ;  // "Imports" all namespace definitions inside 
                       // the current namespace, so we can reference them
                       // in a transparent way.
                       //
                       // Vector : struct { X: int; Y: int; Z: int; }
                       //
                       // Transform : struct {
                       //   owned Position : Vector;
                       // }
                       //
                       // ...
                       // t := new Transform;
                       // t.X += 5;
                       // print( t.Y );
                       // ...
                       //
                      
IS:         'is' ; // TODO
DEFAULT:    'default' ;



// Signs and Operators

DOT:        '.' ;
COMMA:      ',' ;
COL:        ':' ;
SEMI_COL:   ';' ;
ASSIGN:     '=' ;
STAR:       '*' ;
SLASH:      '/' ;
PERCENT:    '%' ;
ARROW:      '->' ;
QUESTION:   '?' ;

PLUS:       '+' ;
MINUS:      '-' ;

// TODO
PLUS_PLUS:      '++' ;
MINUS_MINUS:    '--' ;

//TODO compound assignments
ASSIGN_MUL:     '*=' ;
ASSIGN_DIV:     '/=' ;
ASSIGN_MOD:     '%=' ;
ASSIGN_SUM:     '+=' ;
ASSIGN_SUB:     '-=' ;


NOT:        '!' ;
AND:        '&&' ;
OR:         '||' ;

L_BRACKET:  '[' ;
R_BRACKET:  ']' ;
L_PAR:      '(' ;
R_PAR:      ')' ;
L_CURL:     '{' ;
R_CURL:     '}' ;

// TODO
BIT_AND:    '&' ;
BIT_OR:     '|' ;
BIT_XOR:    '^' ;
BIT_NOT:    '~' ;
BIT_RIGHT:  '>>' ;
BIT_LEFT:   '<<' ;

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