
parser grammar SeagullPreprocessorParser;

options { tokenVocab=SeagullLexer; }



preprocessorDirective :
	    DIR_DEFINE ID
	|	DIR_IF preprocessorExpression
    ;


preprocessorExpression :
	    BOOLEAN_CONSTANT
	;