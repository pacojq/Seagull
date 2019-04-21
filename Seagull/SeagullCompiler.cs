
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Antlr4.Runtime;
using Seagull.AST;
using Seagull.AST.Statements.Definitions;
using Seagull.Errors;
using Seagull.Grammar;
using Seagull.Semantics;

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
		
            
            
			// Parse the program and get the AST //
			
            Program ast = parser.program().Ast;
            
            if (ErrorHandler.Instance.AnyError)
            {
                Console.WriteLine(ErrorHandler.Instance.PrintErrors());
                return null;
            }
            
            
            
            // Import needed files //
            
            foreach (string import in ast.Imports)
            {
	            List<IDefinition> definitions;
	            bool success = CompileLibrary(filename, import, out definitions);
	            if (!success)
		            return null;
	            ast.AddLibrary(definitions);
            }
            
            
            
            // Semantic Analysis //
		
            ast.Accept(new RecognitionVisitor(), null);
            //ast.Accept(new TypeCheckingVisitor(), null);
            //ast.Accept(new LValueVisitor(), null);
		
            if (ErrorHandler.Instance.AnyError)
            {
	            Console.WriteLine(ErrorHandler.Instance.PrintErrors());
				return null;
			}
        
		
            return ast;
        }
        
        
        
        

        public bool CompileLibrary(string currentFile, string import, out List<IDefinition> result)
        {
	        // TODO relative path for the import file
	        string dir = Path.GetDirectoryName(currentFile);
	        string relative = import.Trim('"');
	        string path = Path.Combine(dir, relative);

	        Program program = Compile(path);
	        
	        if (ErrorHandler.Instance.AnyError)
	        {
		        Console.WriteLine(ErrorHandler.Instance.PrintErrors());
		        result = null;
		        return false;
	        }

	        if (program == null)
	        {
		        result = null;
		        return false;
	        }
		        
	        
	        result = program.Definitions.ToList();

	        // Remove the main function
	        if (program.MainFunction != null)
				result.Remove(program.MainFunction);

	        return true;
        }
        
        
        
    }
}