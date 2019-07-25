using Seagull.AST.Statements.Definitions;
using Seagull.Errors;
using Seagull.SymTable;
using Seagull.SymTable.Symbols;
using Seagull.Visitor;

namespace Seagull.Semantics.Recognition
{
    
    /// <summary>
    /// Now that all namespaces are defined, we're gonna insert scope-zero
    /// definitions in those namespaces.
    /// </summary>
    public class SymbolDefinitionVisitor : AbstractRecognitionVisitor<Void>
    {
	    
	    
        
	    public SymbolDefinitionVisitor() : base("SECOND PASS", "Symbol recognition")
	    {
	    }
        
        
        
		
		public override Void Visit(VariableDefinition varDefinition, Void p)
		{
			base.Visit(varDefinition, p);

			VariableSymbol symbol = new VariableSymbol(varDefinition.Name);
			
			bool success = SymbolTable.Instance.Define(symbol);
			if (!success)
			{
				ErrorHandler.Instance.RaiseError(
					varDefinition.Line, 
					varDefinition.Column,
					$"Trying to declare a variable which already exists: {varDefinition.Name}");
			}
			else
			{
				varDefinition.Symbol = symbol;
				symbol.Definition = varDefinition;
			}
			
			return null;
		}
		
		
		
		/*
		 
		 TODO
		
		public override Void Visit(DelegateDefinition delegateDefinition, Void p)
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
		
		*/

		
    }
}