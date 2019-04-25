
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Antlr4.Runtime;
using Seagull.AST;
using Seagull.Errors;

namespace Seagull
{
    public class FrontEndCompiler
    {

	    private SeagullGrammar _grammar;
	    private SeagullSemantics _semantics;
	    
	    
	    public FrontEndCompiler()
	    {
		    _grammar = new SeagullGrammar();
		    _semantics = new SeagullSemantics();
	    }
	    
	    
	    
	    
	    
        public Program Compile(string filename)
        {
	        ErrorHandler.Instance.Clear();
	        _semantics.SetUp();

	        
	        // Syntactic analysis //
	        
	        Program ast = _grammar.Analyze(filename);
            
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

            _semantics.Analyze(ast);
            
            if (ErrorHandler.Instance.AnyError)
            {
	            Console.WriteLine(ErrorHandler.Instance.PrintErrors());
				return null;
			}
        
		
            return ast;
        }
        
        
        
        
        
        
        
        private bool CompileLibrary(string currentFile, string import, out List<IDefinition> result)
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