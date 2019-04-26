
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Antlr4.Runtime;
using Seagull.AST;
using Seagull.Errors;
using Seagull.Semantics;
using Seagull.Semantics.Symbols;

namespace Seagull
{
    public class FrontEndCompiler
    {
	    private bool _ready = false;

	    private SeagullGrammar _grammar;
	    private SeagullSemantics _semantics;
	    
	    
	    public FrontEndCompiler()
	    {
		    _grammar = new SeagullGrammar();
		    _semantics = new SeagullSemantics();
	    }


	    private void SetUp()
	    {
		    if (_ready)
			    return;
		    
		    ErrorHandler.Instance.Clear();
		    _semantics.SetUp();
	    }
	    
	    
	    
	    
        public Program Compile(string filename)
        {
	        SetUp();
	        
	        
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

	        //Program program = Compile(path);
	        
	        Program program = _grammar.Analyze(path);
            
	        if (ErrorHandler.Instance.AnyError)
	        {
		        Console.WriteLine(ErrorHandler.Instance.PrintErrors());
		        result = new List<IDefinition>();
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