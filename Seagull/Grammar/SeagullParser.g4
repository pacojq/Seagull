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
                List<string> Imports = new List<string>(),
                List<IDefinition> Def = new List<IDefinition>()]:
                
		(l=load { $Loads.Add($l.File); })*
		(i=imp { $Imports.Add($i.Namespace); })*
		(protectionLevel? d=definition { $Def.Add($d.Ast); })*
		EOF
		{ $Ast = new Program(0, 0, $Loads, $Imports, $Def); }
	;
	    
	    

// Imports and loads
load returns [string File]:
        LOAD p=STRING_CONSTANT { $File = $p.text; }
    ;

imp returns [string Namespace]:
        IMPORT ns1=ID { $Namespace = $ns1.GetText(); } 
        ( DOT ns2=ID { $Namespace += "." + $ns2.GetText(); } )* SEMI_COL
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
	|   userDefined=ID  { $Ast = new UnknownType($userDefined.GetLine(), $userDefined.GetCol(), $userDefined.GetText()); } 
	;
		

// (a: int, b: int) -> int
functionType returns [FunctionType Ast]
             locals [List<VariableDefinition> Params = new List<VariableDefinition>(), IType Rt]:
            
        L_PAR (p=parameters { $Params = $p.Ast;})?  par=R_PAR { $Rt=new VoidType($par.GetLine(), $par.GetCol()); } 
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



//  [struct Person] {
//      Name : string;
//      Age : int;
//  }
structType  returns [StructType Ast]
            locals [List<VariableDefinition> Fields = new List<VariableDefinition>()]:

        c=L_CURL (protectionLevel? f=variableDef { $Fields.Add($f.Ast); })* R_CURL 
        { $Ast = new StructType($c.GetLine(), $c.GetCol(), $Fields); }
    ;
    
    
    

//  [enum Types : int] {
//      TYPE_A = 0,
//      TYPE_B = 1,
//      TYPE_C = 2
//  }
enumType[IType typeOf] returns [EnumType Ast] 
            locals [List<EnumElementDefinition> defs = new List<EnumElementDefinition>()]:
 
        curl=L_CURL
        (
            d1=enumElement[$typeOf, 0] { $defs.Add($d1.Ast); }
            (COMMA d2=enumElement[$typeOf, 0] { $defs.Add($d2.Ast); })*
        )?
        R_CURL
        { $Ast = new EnumType($curl.GetLine(), $curl.GetCol(), $typeOf, $defs); }
    ;


enumElement[IType typeOf, int defaultInt] returns [EnumElementDefinition Ast]:

        id=ID ASSIGN expr=expression
        { $Ast = new EnumElementDefinition($id.GetLine(), $id.GetCol(), $id.text, $expr.Ast, $typeOf); }
        
    |   id=ID
        {
            IExpression def = new IntLiteral($id.GetLine(), $id.GetCol(), defaultInt);
            if (!($typeOf is IntType))
                def = new Default($id.GetLine(), $id.GetCol(), $typeOf);
            $Ast = new EnumElementDefinition($id.GetLine(), $id.GetCol(), $id.text, def, $typeOf); 
        }
    ;



// Primitive types
primitive returns [IType Ast]:
        ptr=PTR     { $Ast = new PointerType($ptr.GetLine(), $ptr.GetCol()); }
    |   c=CHAR      { $Ast = new CharType($c.GetLine(), $c.GetCol()); }
    |   b=BYTE      { $Ast = new ByteType($b.GetLine(), $b.GetCol()); }
	|	i=INT       { $Ast = new IntType($i.GetLine(), $i.GetCol()); }
	|   d=DOUBLE    { $Ast = new DoubleType($d.GetLine(), $d.GetCol()); }
	|   l=LONG      { $Ast = new LongType($l.GetLine(), $l.GetCol()); }
	|   s=STRING    { $Ast = new StringType($s.GetLine(), $s.GetCol()); }
	;

voidType returns [IType Ast]:
		v=VOID { $Ast = new VoidType($v.GetLine(), $v.GetCol()); }
	;













// * * * * * * * * *   DEFINITIONS   * * * * * * * * * * //



protectionLevel : (PUBLIC | PRIVATE) ;

definition returns [IDefinition Ast]:
        namespaceDef    { $Ast = $namespaceDef.Ast; }
	|   variableDef     { $Ast = $variableDef.Ast; }
    |	fuctionDef      { $Ast = $fuctionDef.Ast; }
	|   structDef       { $Ast = $structDef.Ast; }
	|   enumDef         { $Ast = $enumDef.Ast; }
	;


namespaceDef returns[NamespaceDefinition Ast]
             locals [List<IDefinition> Def = new List<IDefinition>(), 
                    NamespaceDefinition Parent = NamespaceManager.DefaultNamespace,
                    NamespaceType ParentType]:
            
        n=NAMESPACE (p=ID DOT 
            { 
                var ns = NamespaceManager.Instance.Define($n.GetLine(), $n.GetCol(), $p.GetText(), $Parent);
                $ParentType = (NamespaceType) $Parent.Type;
                $Parent = ns;
            })* 
        id=ID 
            { 
                $Ast = NamespaceManager.Instance.Define($id.GetLine(), $id.GetCol(), $id.GetText(), $Parent);
                $ParentType = (NamespaceType) $Parent.Type;
            }
        L_CURL
            (d=definition { $ParentType.AddDefinition($d.Ast); })*
        R_CURL
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
        s=STRUCT n=ID t=structType 
        { $Ast = new StructDefinition($s.GetLine(), $s.GetCol(), $n.GetText(), $t.Ast); }
    ;
    
enumDef returns [EnumDefinition Ast] locals[IType typeOf]: 
        e=ENUM n=ID { $typeOf = new IntType($n.GetLine(), $n.GetCol()); }  // Default type is int
            (COL t=type { $typeOf = $t.Ast; })? enumType[$typeOf]
            { $Ast = new EnumDefinition($e.GetLine(), $e.GetCol(), $n.GetText(), $enumType.Ast); }
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
 

// A function block is different than a simple statement block, since it might contain variable definitions.
fnBlock returns [List<IStatement> Ast = new List<IStatement>()]: 
		
		L_CURL
		    { List<IStatement> delayed = new List<IStatement>(); } // Statements might be delayed
        (
            (c1=fnBlockContent { $Ast.AddRange($c1.Ast); })
          | (DELAY c2=fnBlockContent { delayed.AddRange($c2.Ast); })
        )*
			{ $Ast.AddRange(delayed); }
		R_CURL
	;
	
fnBlockContent returns [List<IStatement> Ast = new List<IStatement>()]: 
        variableDef { $Ast.Add($variableDef.Ast); } 
    |   block=statement { $Ast.AddRange($block.Ast); }
    ;
	
	
	
	
	
		 
statement returns [List<IStatement> Ast = new List<IStatement>()]:
		
		// Block of statements
		L_CURL
            { List<IStatement> delayed = new List<IStatement>(); } // Statements might be delayed
            (
                (st1=statement { $Ast.AddRange($st1.Ast); })
              | (DELAY st2=statement { delayed.AddRange($st2.Ast); })
            )*
            { $Ast.AddRange(delayed); }
        R_CURL
		
		// While loop
	|	w=WHILE L_PAR cond=expression R_PAR st=statement
		    { $Ast.Add(new WhileLoop($w.GetLine(), $w.GetCol(), $cond.Ast, $st.Ast)); }
		    
        // For / Foreach loop
    |   f=FOR L_PAR init=statement cond=expression SEMI_COL incr=statement R_PAR st=statement
            { $Ast.Add(new ForLoop($f.GetLine(), $f.GetCol(), $init.Ast[0], $cond.Ast, $incr.Ast[0], $st.Ast)); }
    |   f=FOR L_PAR e=variable IN col=expression R_PAR st=statement
            { $Ast.Add(new ForeachLoop($f.GetLine(), $f.GetCol(), $e.Ast, $col.Ast, $st.Ast)); }
	
	    // Continue / Break
	|   c=CONTINUE SEMI_COL { $Ast.Add(new Continue($c.GetLine(), $c.GetCol())); }
	|   br=BREAK SEMI_COL   { $Ast.Add(new Break($br.GetLine(), $br.GetCol())); }
	
	    // If / Else
	|   i=IF L_PAR cond=expression R_PAR st1=statement
            { $Ast.Add(new IfStatement($i.GetLine(), $i.GetCol(), $cond.Ast, $st1.Ast)); }
            (ELSE st2=statement  { ((IfStatement)$Ast[0]).Else = $st2.Ast; })?	
	
	    // Assignment
	|   e1=expression ASSIGN e2=expression SEMI_COL	{ $Ast.Add(new Assignment($e1.Ast, $e2.Ast)); }
  	
  	    // Return statement
  	|   r=RETURN expr=expression SEMI_COL  { $Ast.Add(new Return($r.GetLine(), $r.GetCol(), $expr.Ast)); }
  	|   r=RETURN SEMI_COL               { $Ast.Add(new Return($r.GetLine(), $r.GetCol(), null)); }
  	
  	    // Read / Print
  	|   readPrint { $Ast.Add($readPrint.Ast); }
  	
  	    // Function invocation
  	|   funcInvocation SEMI_COL { $Ast.Add($funcInvocation.Ast); }
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
	|   funcInvocation { $Ast = $funcInvocation.Ast; }
		
		// Parentheses
	|   L_PAR e=expression R_PAR { $Ast = $e.Ast; }
		
		// Indexing
	|   e1=expression L_BRACKET e2=expression R_BRACKET { $Ast = new Indexing($e1.Ast, $e2.Ast); }
		
		// Attribute access
	|   e=expression DOT att=ID { $Ast = new AttributeAccess($e.Ast, $att.text); }
		
		// New
	|   n=NEW id=ID { $Ast = new New($n.GetLine(), $n.GetCol(), $id.GetText()); }
	
	    // Default TODO: primitive or ID
	|   def=DEFAULT L_PAR type R_PAR { $Ast = new Default($def.GetLine(), $def.GetCol(), $type.Ast); }
		
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
	
	    // Ternary operator
	|   e1=expression QUESTION e2=expression COL e3=expression { $Ast = new TernaryOperator($e1.Ast, $e2.Ast, $e3.Ast); }
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



