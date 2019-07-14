using Seagull.AST;
using Seagull.AST.Expressions;
using Seagull.AST.Statements.Definitions;
using Seagull.AST.Statements.Definitions.Namespaces;
using Seagull.AST.Types;
using Seagull.Errors;
using Seagull.Logging;
using Seagull.Semantics.Symbols;

namespace Seagull.Semantics.Recognition
{
	
	/// <summary>
	/// Here we'll look for not-scope-zero variables and bind them to their declaration in the
	/// SymbolManager, so we can easily get their type later.
	/// </summary>
    public class RecognitionFourthPassVisitor : AbstractRecognitionVisitor<Visitor.Void>
	{

		private readonly SymbolManager _sm = SymbolManager.Instance;
	    
		
		public RecognitionFourthPassVisitor() : base("FOURTH PASS", "Variable recognition")
		{
		}

		
		
		
		public override Visitor.Void Visit(FunctionDefinition funcDefinition, INamespaceDefinition p)
		{
			SymbolManager.Instance.Set(p);
			
			FunctionType ft = (FunctionType) funcDefinition.Type;
			foreach (VariableDefinition def in ft.Parameters)
				def.Accept(this, p);
			
			foreach (IStatement st in funcDefinition.Statements)
				st.Accept(this, p);
			
			SymbolManager.Instance.Reset(p);
			return null;
		}
		
		
		
		
		
		
		
		public override Visitor.Void Visit(VariableDefinition varDefinition, INamespaceDefinition p)
		{
			if (_sm.GetCurrentScope(p) == 0)
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
		
		
		public override Visitor.Void Visit(Variable var, INamespaceDefinition p)
		{
			IDefinition def = _sm.Find(var.Name, p);
			
			if (def == null)
			{
				ErrorHandler.Instance.RaiseError(
					var.Line, 
					var.Column,
					"Cannot use a variable which is not declared.");
			}
			var.Definition = def;		
			return null;
		}


		
		
		public override Visitor.Void Visit(FunctionInvocation func, INamespaceDefinition p)
		{
			//base.Visit(func, p);
			
			Logger.Instance.LogDebug("RecognitionVisitor visiting function invocation: " + func.Function.Name);
			
			// There's no need to call visit on func.getFunction.
			// We're gonna do that job here.
			Variable var = func.Function;
			IDefinition def = _sm.Find(var.Name, p);
			var.Definition = def;
			
			foreach (IExpression expr in func.Arguments)
				expr.Accept(this, p);
			
			return null;
		}


	}
}