using Seagull.AST;
using Seagull.Errors;
using Seagull.FrontEnd;

namespace Seagull
{
    public class FrontEndCompiler
    {
	    private bool _ready = false;

	    internal SeagullGrammar Grammar { get; }
	    internal SeagullSemantics Semantics { get; }

	    private LoadedFilesManager _loadedFilesManager;
	    
	    
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
		    _loadedFilesManager = new LoadedFilesManager(this, filename);
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
            
            
            
            // Load needed files //
            
            // Perform a grammatical analysis
            _loadedFilesManager.Load(filename, ast.Loads);
            while (!_loadedFilesManager.Ready) { /* Wait */ }
            
            // ... and add to the Ast before the Semantic analysis
            ast.AddDefinitions(_loadedFilesManager.GetDefinitions());
            ast.AddNamespaces(_loadedFilesManager.GetNamespaces());
            
            _loadedFilesManager.Dispose();
            
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