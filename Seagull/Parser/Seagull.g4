grammar Seagull;

@header {

    using System.Collections.Generic;
    
	using Seagull.AST;
}

program returns [Program Ast, List<IDefinition> Def = new List<IDefinition>()]:
		INT_CONSTANT EOF
		{ $Ast = new Program(0, 0, $Def); }
	    ;


// * * * * * * * * * * * * * * * * * * * * * * * * * * * * //
// 														   // 	
// 						LEXER RULES 					   //
// 														   //	
// * * * * * * * * * * * * * * * * * * * * * * * * * * * * //
  		 
fragment
DIGIT: [0-9]
	 ;

fragment
LETTER: [a-zA-Z]
	  ;
	  
fragment
REAL: INT_CONSTANT? '.' DIGIT+
	| INT_CONSTANT '.' DIGIT*
	;


ID: ('_' | LETTER) ('_' | DIGIT | LETTER)*
  ;

  		 
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
			 	 
			 
SL_COMMENT: '//' .*? ('\r' | '\n' | EOF) -> skip
	      ;
	   
ML_COMMENT: '/*' .*? '*/' -> skip
	      ;
	   
BLANKS: (' ' | '\t' | '\r' | '\n')+ -> skip
	   ;


