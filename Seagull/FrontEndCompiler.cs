
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Antlr4.Runtime;
using Seagull.AST;
using Seagull.Errors;
using Seagull.FrontEnd;
using Seagull.Semantics;
using Seagull.Semantics.Symbols;

namespace Seagull
{
    public class FrontEndCompiler
    {
	    private bool _ready = false;

	    internal SeagullGrammar Grammar { get; }
	    internal SeagullSemantics Semantics { get; }

	    private ImportsManager _importsManager;
	    
	    
	    public FrontEndCompiler()
	    {
		    Grammar = new SeagullGrammar();
		    Semantics = new SeagullSemantics();
	    }


	    private void SetUp(string filename)
	    {
		    if (_ready)
			    return;
		    
		    ErrorHandler.Instance.Clear();
		    Semantics.SetUp();
		    _importsManager = new ImportsManager(this, filename);
	    }
	    
	    
	    
	    
        public Program Compile(string filename)
        {
	        SetUp(filename);
	        
	        
	        // Syntactic analysis //
	        
	        Program ast = Grammar.Analyze(filename);
            
	        if (ErrorHandler.Instance.AnyError)
            {
                ErrorHandler.Instance.PrintErrors();
                return null;
            }
            
            
            
            // Import needed files //
            _importsManager.Import(filename, ast.Imports);
            while (!_importsManager.Ready) { /* Wait */ }
            
            ast.AddDefinitions(_importsManager.GetImports());
            _importsManager.Dispose();
            
            if (ErrorHandler.Instance.AnyError)
				return null;
            
            
            // Semantic Analysis //

            Semantics.Analyze(ast);
            
            if (ErrorHandler.Instance.AnyError)
            {
	            ErrorHandler.Instance.PrintErrors();
				return null;
			}
            
            
            // Print warnings
            if (ErrorHandler.Instance.AnyWarning)
	            ErrorHandler.Instance.PrintWarnings();
        
            return ast;
        }
        
        
        
    }
}