
parser grammar SeagullPreprocessorParser;

options { tokenVocab=SeagullLexer; }



preprocessorDirective :
	    DIR_DEFINE ID
	|	DIR_IF preprocessorExpression
    ;


preprocessorExpression :
	    TRUE
	|   FALSE
	;