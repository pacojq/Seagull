using Seagull.AST;
using Seagull.AST.Expressions;
using Seagull.AST.Statements.Definitions;
using Seagull.AST.Types;
using Seagull.Errors;
using Seagull.Logging;
using Seagull.SymTable;
using Seagull.Visitor;

namespace Seagull.Semantics.Recognition
{
	
	/// <summary>
	/// Here we'll look for not-scope-zero variables and bind them to their declaration in the
	/// SymbolManager, so we can easily get their type later.
	/// </summary>
    public class VariableRecognitionVisitor : AbstractRecognitionVisitor<Void>
	{

		public VariableRecognitionVisitor() : base("FOURTH PASS", "Variable recognition")
		{
		}

		
		
		public override Void Visit(VariableNode var, Void p)
		{
			ISymbol symbol = SymbolTable.Instance.Solve(var.Name);
			
			if (symbol == null)
			{
				ErrorHandler.Instance.RaiseError(
					var.Line, 
					var.Column,
					"Cannot use a variable which is not declared.");
			}
			else var.Definition = symbol.Definition;
			
			return null;
		}



	}
}