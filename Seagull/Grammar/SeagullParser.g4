parser grammar SeagullParser;

options { tokenVocab = SeagullLexer; }

@header {

    using System.Collections.Generic;
    
	using Seagull.AST;
	using Seagull.Grammar;
	
	using Seagull.Semantics.Symbols;
	
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
		(d=definition { $Def.Add($d.Ast); })*
		EOF
		{ $Ast = new Program(0, 0, $Loads, $Def); }
	;
	    
	    

// Imports and loads
load returns [string File]:
        LOAD p=STRING_CONSTANT { $File = $p.text; }
    ;





// * * * * * * * * *   TYPES   * * * * * * * * * * //



type returns [IType Ast]:
        primitive       { $Ast = $primitive.Ast; }
	|   functionType    { $Ast = $functionType.Ast; }
    |   structType      { $Ast = $structType.Ast; }

	    // Array type
	|   t=type L_BRACKET i=INT_CONSTANT R_BRACKET  
				{ $Ast = ArrayType.BuildArray(int.Parse($i.text), $t.Ast); }
				(L_BRACKET i2=INT_CONSTANT R_BRACKET 
				    { $Ast = ArrayType.BuildArray( int.Parse($i2.text), $Ast); } 
				)*
		
		// Custom type
	|   userDefined=ID  { $Ast = DependencyManager.Instance.AddType($userDefined.GetLine(), $userDefined.GetCol(), $userDefined.GetText()); } 
	;
		

// (a: int, b: int) -> int
functionType returns [FunctionType Ast, 
            List<VariableDefinition> Params = new List<VariableDefinition>(),
            IType Rt]:
            
        L_PAR (p=parameters { $Params = $p.Ast;})?  R_PAR t=type { $Rt=new VoidType($t.GetLine(), $t.GetCol()); } 
            (ARROW ((t=type { $Rt=$t.Ast; }) | (vt=voidType{ $Rt=$vt.Ast; })) )? // if we donot specify '-> returnType', it's void
            { $Ast = new FunctionType($Rt, $Params); }
    ;
    
parameters returns [List<VariableDefinition> Ast = new List<VariableDefinition>()]: 
		id1=ID COL t1=type  { $Ast.Add(new VariableDefinition($id1.GetLine(), $id1.GetCol(), $id1.GetText(), $t1.Ast, null)); }
		(COMMA id2=ID COL t2=type
			{ $Ast.Add(new VariableDefinition($id2.GetLine(), $id2.GetCol(), $id2.GetText(), $t2.Ast, null)); }
		)*
		(COMMA id2=ID COL t2=type ASSIGN l=literal
            { $Ast.Add(new VariableDefinition($id2.GetLine(), $id2.GetCol(), $id2.GetText(), $t2.Ast, $l.Ast)); }
        )*
    ;



//  struct {
//      ...
//  }
structType returns [StructType Ast,
            List<VariableDefinition> Fields = new List<VariableDefinition>()]:

        s=STRUCT L_CURL (f=variableDef { $Fields.Add($f.Ast); })* R_CURL 
        { $Ast = new StructType($s.GetLine(), $s.GetCol(), $Fields); }
    ;



// Primitive types
primitive returns [IType Ast]:
		i=INT { $Ast = new IntType($i.GetLine(), $i.GetCol()); }
	|   c=CHAR { $Ast = new CharType($c.GetLine(), $c.GetCol()); }
	|   d=DOUBLE { $Ast = new DoubleType($d.GetLine(), $d.GetCol()); }
	|   s=STRING { $Ast = new StringType($s.GetLine(), $s.GetCol()); }
	;

voidType returns [IType Ast]:
		v=VOID { $Ast = new VoidType($v.GetLine(), $v.GetCol()); }
	;













// * * * * * * * * *   DEFINITIONS   * * * * * * * * * * //



protectionLevel : (PUBLIC | PRIVATE) ;

definition returns [IDefinition Ast]:
        namespaceDef                    { $Ast = $namespaceDef.Ast; }
    |	protectionLevel? fuctionDef     { $Ast = $fuctionDef.Ast; }
	|   protectionLevel? variableDef    { $Ast = $variableDef.Ast; }
	|   protectionLevel? structDef      { $Ast = $structDef.Ast; }
	;


namespaceDef returns[NamespaceDefinition Ast,
            List<IDefinition> Def = new List<IDefinition>(),
            NamespaceDefinition Parent = null]:
            
        n=NAMESPACE ( p=ID DOT { $Parent = SymbolsManager.Instance.AddNamespace($n.GetLine(), $n.GetCol(), $p.GetText(), $Parent); })* 
        id=ID 
        L_CURL
            (d=definition { $Def.Add($d.Ast); })*
        R_CURL
        { $Ast = new NamespaceDefinition($n.GetLine(), $n.GetCol(), $id.GetText(), $Parent, $Def); }
    ;


/*
    a : int;
    b : double = 3.0;
    c := 1f;
*/
variableDef returns [VariableDefinition Ast]: 
        n=ID COL t=type SEMI_COL { $Ast = new VariableDefinition($t.Ast.Line, $t.Ast.Column, $n.GetText(), $t.Ast, null); }
    |   n=ID COL t=type ASSIGN e=expression SEMI_COL { $Ast = new VariableDefinition($t.Ast.Line, $t.Ast.Column, $n.GetText(), $t.Ast, $e.Ast); }
		// TODO ID ':=' expression
	;


/*
    method: () -> void { ... }
    public sum: (a: int, b: int) -> int { ... }
*/
fuctionDef returns [FunctionDefinition Ast, IType funcType]: 
        n=ID COL t=functionType fnBlock 
        { $Ast = new FunctionDefinition($n.GetLine(), $n.GetCol(), $n.GetText(), $t.Ast, $fnBlock.Ast); }
    ;
    
    
structDef returns [StructDefinition Ast]: 
        n=ID COL t=structType 
        { $Ast = new StructDefinition($n.GetLine(), $n.GetCol(), $n.GetText(), $t.Ast); }
    ;
    

// TODO create a type with the delegate name
delegate returns [IType Ast]:
        DELEGATE n=ID functionType { $Ast = $functionType.Ast; }
    ;





// * * * * * * * * *   STATEMENTS   * * * * * * * * * * //


funcInvocation returns [FunctionInvocation Ast, List<IExpression> arguments = new List<IExpression>()]:
		func=variable L_PAR ( e1=expression { $arguments.Add($e1.Ast); } (COMMA e2=expression { $arguments.Add($e2.Ast); })* )? R_PAR
 			{ $Ast = new FunctionInvocation($func.Ast, $arguments); }
 	;
 
  	
block returns [List<IStatement> Ast = new List<IStatement>()]: 
		st1=statement { $Ast.AddRange($st1.Ast); }
	|   L_CURL (st2=statement { $Ast.AddRange($st2.Ast); })* R_CURL
	;
		
fnBlock returns [List<IStatement> Ast = new List<IStatement>()]: 
		L_CURL
			((variableDef { $Ast.Add($variableDef.Ast); }) | (statement { $Ast.AddRange($statement.Ast); }))*
		R_CURL
	;
	
	
		 
statement returns [List<IStatement> Ast = new List<IStatement>()]:
		w=WHILE L_PAR cond=expression R_PAR b=block  				// While loop
				{ $Ast.Add(new WhileLoop($w.GetLine(), $w.GetCol(), $cond.Ast, $b.Ast)); }
	|   i=IF L_PAR cond=expression R_PAR b1=block					// If-else
				{ $Ast.Add(new IfStatement($i.GetLine(), $i.GetCol(), $cond.Ast, $b1.Ast)); }
				(ELSE b2=block { ((IfStatement)$Ast[0]).Else = $b2.Ast; })?	
	|   e1=expression ASSIGN e2=expression SEMI_COL					// Assignment
				{ $Ast.Add(new Assignment($e1.Ast, $e2.Ast)); }
  	|   r=RETURN e=expression SEMI_COL							// Return statement
  				{ $Ast.Add(new Return($r.GetLine(), $r.GetCol(), $e.Ast)); }
  	|   readPrint												// Read and Write
  				{ $Ast.Add($readPrint.Ast); }
  	|   funcInvocation SEMI_COL
  				{ $Ast.Add($funcInvocation.Ast); }
  	;
  		


// TODO read write syntactic sugar
  		
readPrint returns [IStatement Ast]:
 		p=PRINT L_PAR e=expression R_PAR SEMI_COL { $Ast = new Print($p.GetLine(), $p.GetCol(), $e.Ast); }
  	|   r=READ L_PAR e=expression R_PAR SEMI_COL	{ $Ast = new Read($r.GetLine(), $r.GetCol(), $e.Ast); }
  	;










// * * * * * * * * *   EXPRESSIONS   * * * * * * * * * * //


expression returns [IExpression Ast]:

        variable { $Ast = $variable.Ast; }
	|   literal { $Ast = $literal.Ast; }
		
		// Function invocation
	|   funcInvocation      { $Ast = $funcInvocation.Ast; }
		
		// Parentheses
	|   L_PAR e=expression R_PAR { $Ast = $e.Ast; }
		
		// Indexing
	|   e1=expression L_BRACKET e2=expression R_BRACKET { $Ast = new Indexing($e1.Ast, $e2.Ast); }
		
		// Attribute access
	|   var=variable DOT att=ID { $Ast = new AttributeAccess($var.Ast, $att.text); }
		
		// New
	|   n=NEW id=ID         { $Ast = new New($n.GetLine(), $n.GetCol(), $id.GetText()); }
		
		// Unary operations
	|   um=MINUS expression { $Ast = new UnaryMinus($um.GetLine(), $um.GetCol(), $expression.Ast); }
	|   not=NOT expression { $Ast = new Negation($not.GetLine(), $not.GetCol(), $expression.Ast); }
		
		// Arithmetics
	|   e1=expression op=(STAR|SLASH|PERCENT) e2=expression { $Ast = new Arithmetic($op.text, $e1.Ast, $e2.Ast); }
	|   e1=expression op=(PLUS|MINUS) e2=expression { $Ast = new Arithmetic($op.text, $e1.Ast, $e2.Ast); }
		
		// Cast
	|   p=L_PAR t=primitive R_PAR e=expression { $Ast = new Cast($p.GetLine(), $p.GetCol(), $t.Ast, $e.Ast); }
		
		// Comparisons
	|   e1=expression op=(GREATER_THAN|LESS_THAN|GREATER_EQ_THAN|LESS_EQ_THAN|EQUAL|NOT_EQUAL) e2=expression { $Ast = new Comparison($op.text, $e1.Ast, $e2.Ast); }
		
		// Logical operations
	|   e1=expression op=(AND|OR) e2=expression { $Ast = new LogicalOperation($op.text, $e1.Ast, $e2.Ast); }
	;



variable returns [Variable Ast]:
		ID { $Ast = new Variable($ID.GetLine(), $ID.GetCol(), $ID.text); }
		;



literal returns [IExpression Ast]:
	    i=INT_CONSTANT      { $Ast = new IntLiteral($i.GetLine(), $i.GetCol(), LexerHelper.LexemeToInt($i.text)); }
	|   r=REAL_CONSTANT     { $Ast = new DoubleLiteral($r.GetLine(), $r.GetCol(), LexerHelper.LexemeToReal($r.text)); }
	|   c=CHAR_CONSTANT     { $Ast = new CharLiteral($c.GetLine(), $c.GetCol(), LexerHelper.LexemeToChar($c.text)); }
	|   s=STRING_CONSTANT   { $Ast = new StringLiteral($s.GetLine(), $s.GetCol(), $s.text); }
	|   b=BOOLEAN_CONSTANT  { $Ast = new BooleanLiteral($b.GetLine(), $b.GetCol(), LexerHelper.LexemeToBoolean($b.text)); }
	;



