parser grammar SeagullParser;

options { tokenVocab = SeagullLexer; }

@header {

    using System.Collections.Generic;
    
	using Seagull.AST;
	using Seagull.Grammar;
	
	using Seagull.AST.Expressions;
	using Seagull.AST.Expressions.Binary;
	using Seagull.AST.Expressions.Literals;
	
	using Seagull.AST.Statements;
	using Seagull.AST.Statements.Definitions;
	
	using Seagull.AST.Types;
}



program returns [Program Ast, 
                List<string> Loads = new List<string>(), 
                List<IDefinition> Def = new List<IDefinition>()]:
                
		(l=load { $Loads.Add($l.File); })*
		(d=definition { $Def.AddRange($d.Ast); })*
		EOF
		{ $Ast = new Program(0, 0, $Loads, $Def); }
	    ;
	    
	    

// Imports and loads
load returns [string File]:
    COMP_LOAD p=STRING_CONSTANT { $File = $p.text; }
    ;





// * * * * * * * * *   TYPES   * * * * * * * * * * //



type returns [IType Ast]:

        // primitives
		primitive { $Ast = $primitive.Ast; }
		
		// Arrays
		| t=type L_BRACKET i=INT_CONSTANT R_BRACKET 
				{ $Ast = ArrayType.BuildArray(int.Parse($i.text), $t.Ast); }
				(L_BRACKET i2=INT_CONSTANT R_BRACKET 
				    { $Ast = ArrayType.BuildArray( int.Parse($i2.text), $Ast); } 
				)*
		//| structType { $Ast = $structType.Ast; }
		;
		
/*
structType returns [StructType Ast, List<VariableDefinition> defs=new List<VariableDefinition>()]:
		s='struct' L_CURL (variableDef { $defs.AddRange($variableDef.Ast); })* R_CURL 
				{ $Ast = new StructType($s.GetLine(), $s.GetCol(), $defs); } 
		;
*/
// Primitive types
primitive returns [IType Ast]:
		i=INT { $Ast = new IntType($i.GetLine(), $i.GetCol()); }
		| c=CHAR { $Ast = new CharType($c.GetLine(), $c.GetCol()); }
		| d=DOUBLE { $Ast = new DoubleType($d.GetLine(), $d.GetCol()); }
		;

voidType returns [IType Ast]:
		v=VOID { $Ast = new VoidType($v.GetLine(), $v.GetCol()); }
		;








// * * * * * * * * *   DEFINITIONS   * * * * * * * * * * //


definition returns [List<IDefinition> Ast = new List<IDefinition>()]:
		//fuctionDef { $Ast.Add($fuctionDef.Ast); }
		/*|*/ variableDef { $Ast.AddRange($variableDef.Ast); }
		;


variableDef returns [List<VariableDefinition> Ast = new List<VariableDefinition>()]: 
        n=ID COL t=type SEMI_COL
		    { $Ast.Add(new VariableDefinition($t.Ast.Line, $t.Ast.Column, $n.GetText(), $t.Ast)); }
		// TODO | ID ':=' expression
		// TODO | ID COL type ASSIGN expression
		;
/*		
fuctionDef returns [FunctionDefinition Ast, List<VariableDefinition> p = new List<VariableDefinition>()]: 
		t=funcReturnType ID L_PAR (parameters { $p.AddRange($parameters.Ast); } )? R_PAR fnBlock	// Function IDefinition
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
		func=variable L_PAR ( e1=expression { $arguments.Add($e1.Ast); } (COMMA e2=expression { $arguments.Add($e2.Ast); })* )? R_PAR
 			{ $Ast = new FunctionInvocation($func.Ast, $arguments); }
 		;
 
  	
block returns [List<IStatement> Ast = new List<IStatement>()]: 
		st1=statement { $Ast.AddRange($st1.Ast); }
		| L_CURL (st2=statement { $Ast.AddRange($st2.Ast); })* R_CURL
		;
		
fnBlock returns [List<IStatement> Ast = new List<IStatement>()]: 
		L_CURL
			(variableDef { $Ast.AddRange($variableDef.Ast); })*
			(statement { $Ast.AddRange($statement.Ast); })*
		R_CURL
		;
	
	
		 
statement returns [List<IStatement> Ast = new List<IStatement>()]:
		w=WHILE L_PAR cond=expression R_PAR b=block  				// While loop
				{ $Ast.Add(new WhileLoop($w.GetLine(), $w.GetCol(), $cond.Ast, $b.Ast)); }
		| i=IF L_PAR cond=expression R_PAR b1=block					// If-else
				{ $Ast.Add(new IfStatement($i.GetLine(), $i.GetCol(), $cond.Ast, $b1.Ast)); }
				(ELSE b2=block { ((IfStatement)$Ast[0]).Else = $b2.Ast; })?	
		| e1=expression ASSIGN e2=expression SEMI_COL					// Assignment
				{ $Ast.Add(new Assignment($e1.Ast, $e2.Ast)); }
  		| r=RETURN e=expression SEMI_COL							// Return statement
  				{ $Ast.Add(new Return($r.GetLine(), $r.GetCol(), $e.Ast)); }
  		| readPrint												// Read and Write
  				{ $Ast.Add($readPrint.Ast); }
  		| funcInvocation SEMI_COL
  				{ $Ast.Add($funcInvocation.Ast); }
  		;
  		


// TODO read write syntactic sugar
  		
readPrint returns [IStatement Ast]:
 		p=PRINT L_PAR e=expression R_PAR SEMI_COL { $Ast = new Print($p.GetLine(), $p.GetCol(), $e.Ast); }
  		| r=READ L_PAR e=expression R_PAR SEMI_COL	{ $Ast = new Read($r.GetLine(), $r.GetCol(), $e.Ast); }
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
		| s=STRING_CONSTANT { $Ast = new CharLiteral($c.GetLine(), $c.GetCol(),LexerHelper.LexemeToChar($c.text)); } // TODO
		
		// Function invocation
		| funcInvocation { $Ast = $funcInvocation.Ast; }
		
		// Parentheses
		| L_PAR e=expression R_PAR { $Ast = $e.Ast; }
		
		// Indexing
		| e1=expression L_BRACKET e2=expression R_BRACKET { $Ast = new Indexing($e1.Ast, $e2.Ast); }
		
		// Attribute access
		| var=variable DOT att=ID { $Ast = new AttributeAccess($var.Ast, $att.text); }
		
		// Unary operations
		| um=MINUS expression { $Ast = new UnaryMinus($um.GetLine(), $um.GetCol(), $expression.Ast); }
		| not=NOT expression { $Ast = new Negation($not.GetLine(), $not.GetCol(), $expression.Ast); }
		
		// Arithmetics
		| e1=expression op=(STAR|SLASH|PERCENT) e2=expression { $Ast = new Arithmetic($op.text, $e1.Ast, $e2.Ast); }
		| e1=expression op=(PLUS|MINUS) e2=expression { $Ast = new Arithmetic($op.text, $e1.Ast, $e2.Ast); }
		
		// Cast
		| p=L_PAR t=primitive R_PAR e=expression { $Ast = new Cast($p.GetLine(), $p.GetCol(), $t.Ast, $e.Ast); }
		
		// Comparisons
		| e1=expression op=(GREATER_THAN|LESS_THAN|GREATER_EQ_THAN|LESS_EQ_THAN|EQUAL|NOT_EQUAL) e2=expression { $Ast = new Comparison($op.text, $e1.Ast, $e2.Ast); }
		
		// Logical operations
		| e1=expression op=(AND|OR) e2=expression { $Ast = new LogicalOperation($op.text, $e1.Ast, $e2.Ast); }
		;





