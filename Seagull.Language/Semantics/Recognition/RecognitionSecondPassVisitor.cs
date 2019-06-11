using Seagull.Language.AST.Statements.Definitions;
using Seagull.Language.AST.Statements.Definitions.Namespaces;
using Seagull.Language.Errors;
using Seagull.Language.Semantics.Symbols;
using Seagull.Language.Visitor;

namespace Seagull.Language.Semantics.Recognition
{
    
    /// <summary>
    /// Now that all namespaces are defined, we're gonna insert scope-zero
    /// definitions in those namespaces.
    /// </summary>
    public class RecognitionSecondPassVisitor : AbstractRecognitionVisitor<Void>
    {
	    
	    private readonly SymbolManager _sm = SymbolManager.Instance;
	    
        
	    public RecognitionSecondPassVisitor() : base("SECOND PASS", "Scope-zero definitions")
	    {
	    }
        
        
        
		
		public override Void Visit(VariableDefinition varDefinition, INamespaceDefinition p)
		{
			if (_sm.GetCurrentScope(p) != 0)
				return null;
			
			base.Visit(varDefinition, p);
			
			bool success = _sm.Insert(varDefinition, p);
			if (!success)
			{
				ErrorHandler.Instance.RaiseError(
					varDefinition.Line, 
					varDefinition.Column,
					$"Trying to declare a variable which already exists: {varDefinition.Name}");
			}
			
			return null;
		}
		
		
		
		
		public override Void Visit(FunctionDefinition funcDefinition, INamespaceDefinition p)
		{
			// Insert and set the scope
			bool success = _sm.Insert(funcDefinition, p);
			if (!success)
			{
				ErrorHandler.Instance.RaiseError(
					funcDefinition.Line, 
					funcDefinition.Column,
					$"Trying to declare a function which already exists: {funcDefinition.Name}");
			}
			
			base.Visit(funcDefinition, p);
			return null;
		}
		
		
		
		public override Void Visit(DelegateDefinition delegateDefinition, INamespaceDefinition p)
		{
			// Insert and set the scope
			bool success = _sm.Insert(delegateDefinition, p);
			if (!success)
			{
				ErrorHandler.Instance.RaiseError(
					delegateDefinition.Line, 
					delegateDefinition.Column,
					"Trying to declare a delegate which already exists.");
			}
			
			base.Visit(delegateDefinition, p);
			return null;
		}

		
    }
}