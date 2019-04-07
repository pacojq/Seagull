grammar Seagull;

@header {

    using System.Collections.Generic;
    
	using Seagull.AST;
	using Seagull.Parser;
	
	using Seagull.AST.Expressions;
	using Seagull.AST.Expressions.Binary;
	using Seagull.AST.Expressions.Literals;
	
	using Seagull.AST.Statements;
	using Seagull.AST.Statements.Definitions;
	
	using Seagull.AST.Types;
}

program returns [Program Ast, List<IDefinition> Def = new List<IDefinition>()]:
		(d=definition { $Def.AddRange($d.Ast); })* EOF
		{ $Ast = new Program(0, 0, $Def); }
	    ;
	    



// * * * * * * * * *   TYPES   * * * * * * * * * * //



type returns [IType Ast]:

        // primitives
		primitive { $Ast = $primitive.Ast; }
		
		// Arrays
		| t=type '[' i=INT_CONSTANT ']' 
				{ $Ast = ArrayType.BuildArray(int.Parse($i.text), $t.Ast); }
				('[' i2=INT_CONSTANT ']' 
				    { $Ast = ArrayType.BuildArray( int.Parse($i2.text), $Ast); } 
				)*
		//| structType { $Ast = $structType.Ast; }
		;
		
/*
structType returns [StructType Ast, List<VariableDefinition> defs=new List<VariableDefinition>()]:
		s='struct' '{' (variableDef { $defs.AddRange($variableDef.Ast); })* '}' 
				{ $Ast = new StructType($s.GetLine(), $s.GetCol(), $defs); } 
		;
*/
// Primitive types
primitive returns [IType Ast]:
		i='int' { $Ast = new IntType($i.GetLine(), $i.GetCol()); }
		| c='char' { $Ast = new CharType($c.GetLine(), $c.GetCol()); }
		| d='double' { $Ast = new DoubleType($d.GetLine(), $d.GetCol()); }
		;

voidType returns [IType Ast]:
		v='void' { $Ast = new VoidType($v.GetLine(), $v.GetCol()); }
		;








// * * * * * * * * *   DEFINITIONS   * * * * * * * * * * //


definition returns [List<IDefinition> Ast = new List<IDefinition>()]:
		//fuctionDef { $Ast.Add($fuctionDef.Ast); }
		/*|*/ variableDef { $Ast.AddRange($variableDef.Ast); }
		;


variableDef returns [List<VariableDefinition> Ast = new List<VariableDefinition>()]: 
        n=ID ':' t=type ';'
		    { $Ast.Add(new VariableDefinition($t.Ast.Line, $t.Ast.Column, $n.GetText(), $t.Ast)); }
		// TODO | ID ':=' expression
		// TODO | ID ':' type '=' expression
		;
/*		
fuctionDef returns [FunctionDefinition Ast, List<VariableDefinition> p = new List<VariableDefinition>()]: 
		t=funcReturnType ID '(' (parameters { $p.AddRange($parameters.Ast); } )? ')' fnBlock	// Function IDefinition
			{ $Ast = new FunctionDefinition($t.Ast.Line, $t.Ast.Column, $ID.text, new FunctionType($t.Ast, $p), $fnBlock.Ast); }
		;
		
parameters returns [List<VariableDefinition> Ast = new List<VariableDefinition>()]: 
		t1=primitive id1=ID 
		{$Ast.Add(new VariableDefinition($t1.Ast.Line, $t1.Ast.Column, $id1.text, $t1.Ast));}
		(',' t2=primitive id2=ID
			{$Ast.Add(new VariableDefinition($t2.Ast.Line, $t2.Ast.Column, $id2.text, $t2.Ast));}
		)*
	  	;
*/







// * * * * * * * * *   STATEMENTS   * * * * * * * * * * //


funcInvocation returns [FunctionInvocation Ast, List<IExpression> arguments = new List<IExpression>()]:
		func=variable '(' ( e1=expression { $arguments.Add($e1.Ast); } (',' e2=expression { $arguments.Add($e2.Ast); })* )? ')'
 			{ $Ast = new FunctionInvocation($func.Ast, $arguments); }
 		;
 
  	
block returns [List<IStatement> Ast = new List<IStatement>()]: 
		st1=statement { $Ast.AddRange($st1.Ast); }
		| '{' (st2=statement { $Ast.AddRange($st2.Ast); })* '}'
		;
		
fnBlock returns [List<IStatement> Ast = new List<IStatement>()]: 
		'{'
			(variableDef { $Ast.AddRange($variableDef.Ast); })*
			(statement { $Ast.AddRange($statement.Ast); })*
		'}'
		;
	
	
		 
statement returns [List<IStatement> Ast = new List<IStatement>()]:
		w='while' '(' cond=expression ')' b=block  				// While loop
				{ $Ast.Add(new WhileLoop($w.GetLine(), $w.GetCol(), $cond.Ast, $b.Ast)); }
		| i='if' '(' cond=expression ')' b1=block					// If-else
				{ $Ast.Add(new IfStatement($i.GetLine(), $i.GetCol(), $cond.Ast, $b1.Ast)); }
				('else' b2=block { ((IfStatement)$Ast[0]).Else = $b2.Ast; })?	
		| e1=expression '=' e2=expression ';'					// Assignment
				{ $Ast.Add(new Assignment($e1.Ast, $e2.Ast)); }
  		| r='return' e=expression ';'							// Return statement
  				{ $Ast.Add(new Return($r.GetLine(), $r.GetCol(), $e.Ast)); }
  		| readPrint												// Read and Write
  				{ $Ast.Add($readPrint.Ast); }
  		| funcInvocation ';'
  				{ $Ast.Add($funcInvocation.Ast); }
  		;
  		


// TODO read write syntactic sugar
  		
readPrint returns [IStatement Ast]:
 		p='print' '(' e=expression ')' ';' { $Ast = new Print($p.GetLine(), $p.GetCol(), $e.Ast); }
  		| r='read' '(' e=expression ')' ';'	{ $Ast = new Read($r.GetLine(), $r.GetCol(), $e.Ast); }
  		;






// * * * * * * * * *   EXPRESSIONS   * * * * * * * * * * //

variable returns [Variable Ast]:
		ID { $Ast = new Variable($ID.GetLine(), $ID.GetCol(), $ID.text); }
		;



expression returns [IExpression Ast]:

        // Variable
		variable { $Ast = $variable.Ast; }
		
		// Literals
		| i=INT_CONSTANT { $Ast = new IntLiteral($i.GetLine(), $i.GetCol(), LexerHelper.LexemeToInt($i.text)); }
		| r=REAL_CONSTANT { $Ast = new DoubleLiteral($r.GetLine(), $r.GetCol(), LexerHelper.LexemeToReal($r.text)); }
		| c=CHAR_CONSTANT { $Ast = new CharLiteral($c.GetLine(), $c.GetCol(),LexerHelper.LexemeToChar($c.text)); }
		
		// Function invocation
		| funcInvocation { $Ast = $funcInvocation.Ast; }
		
		// Parentheses
		| '(' e=expression ')' { $Ast = $e.Ast; }
		
		// Indexing
		| e1=expression '[' e2=expression ']' { $Ast = new Indexing($e1.Ast, $e2.Ast); }
		
		// Attribute access
		| var=variable '.' att=ID { $Ast = new AttributeAccess($var.Ast, $att.text); }
		
		// Unary operations
		| um='-' expression { $Ast = new UnaryMinus($um.GetLine(), $um.GetCol(), $expression.Ast); }
		| not='!' expression { $Ast = new Negation($not.GetLine(), $not.GetCol(), $expression.Ast); }
		
		// Arithmetics
		| e1=expression op=('*'|'/'|'%') e2=expression { $Ast = new Arithmetic($op.text, $e1.Ast, $e2.Ast); }
		| e1=expression op=('+'|'-') e2=expression { $Ast = new Arithmetic($op.text, $e1.Ast, $e2.Ast); }
		
		// Cast
		| p='(' t=primitive ')' e=expression { $Ast = new Cast($p.GetLine(), $p.GetCol(), $t.Ast, $e.Ast); }
		
		// Comparisons
		| e1=expression op=('>'|'<'|'>='|'<='|'=='|'!=') e2=expression { $Ast = new Comparison($op.text, $e1.Ast, $e2.Ast); }
		
		// Logical operations
		| e1=expression op=('&&'|'||') e2=expression { $Ast = new LogicalOperation($op.text, $e1.Ast, $e2.Ast); }
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



// Nested
ML_COMMENT_N: '/*' .*? NESTED_ML_COMMENT .*? '*/' -> skip
	        ;	

fragment
NESTED_ML_COMMENT: 
                 | '/*' .*? NESTED_ML_COMMENT .*? '*/'
                 ;
      
     


	   
BLANKS: (' ' | '\t' | '\r' | '\n')+ -> skip
	   ;


