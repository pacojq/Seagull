grammar SVML;


program returns [SeagullVMProgram Ast] 
        locals [ List<ICommand> commands]:
        NL?
        (c=command { $commands.Add($c.Cmd); } NL)*
        EOF
        { $Ast = new SeagullVMProgram(commands); }
    ;
    


command returns [ICommand Cmd]:
        ' '
    ;
    
    
    


// PUSH INSTRUCTIONS

cmdPush returns [ICommand Cmd]:

        'pushb' BLANK
    |   'pushi' BLANK
    |   'pushf' BLANK
    ;

    
    
   
   
   
   
   
   
   
    
    
// * * * * * * * * * * * * * * * * * * * * * * * * * * * * //
// 														   // 	
// 						LEXER RULES 					   //
// 														   //	
// * * * * * * * * * * * * * * * * * * * * * * * * * * * * //
         
fragment
DIGIT:      [0-9] ;

fragment
LETTER:     [a-zA-Z] ;
  
fragment
REAL:       INT_CONSTANT? '.' DIGIT+
        |   INT_CONSTANT '.' DIGIT*
        ;  

    
NL:         ('\r' | '\n')+ ;
BLANK:      (' ' | '\t') ;

INT_CONSTANT: '0'
			| [1-9] [0-9]* 
            ;
            
REAL_CONSTANT: REAL | INT_CONSTANT
			 | (REAL | INT_CONSTANT) ('e' | 'E') '-'? INT_CONSTANT
			 ;