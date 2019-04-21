
using System;
using System.IO;
using Antlr4.Runtime;
using Seagull.AST;
using Seagull.Errors;

namespace Seagull
{
    public class SeagullCompiler
    {
	    
	    private ErrorListener _errorListener;

	    public SeagullCompiler()
	    {
		    _errorListener = new ErrorListener();
	    }
	    
	    
        public Program Compile(string filename)
        {
	        ErrorHandler.Instance.Clear();
	        
	        // create a lexer that feeds off of input stream
	        AntlrInputStream input;
	        try
	        {
		        input = new AntlrFileStream(filename);
	        }
	        catch (IOException e)
	        {
		        Console.WriteLine("Could not load the input file: " + filename);
		        return null;
	        }
            SeagullLexer lexer = new SeagullLexer(input);

            
            
            // create a parser that feeds off the tokens buffer
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            SeagullParser parser = new SeagullParser(tokens);
		
            parser.RemoveErrorListeners();
            lexer.RemoveErrorListeners();
            parser.AddErrorListener(_errorListener);
            lexer.AddErrorListener(_errorListener);
		
	    
            Program ast = parser.program().Ast;
		
		
            if (ErrorHandler.Instance.AnyError) {
                Console.WriteLine(ErrorHandler.Instance.PrintErrors());
                return null;
            }
		
		/*
            new SemanticAnalysis(ast).run();
		
            if (ErrorHandler.getInstance().anyError())
                ErrorHandler.getInstance().showErrors(System.err);
        */
		
            return ast;
        }
        
    }
}