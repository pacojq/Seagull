using Seagull.AST;
using Seagull.AST.Expressions;
using Seagull.Errors;
using Seagull.Logging;
using Seagull.Semantics.Symbols;
using Void = Seagull.Visitor.Void;

namespace Seagull.Semantics.Recognition
{
	
	/// <summary>
	/// This visitor must run after we have used the DefinitionSeekVisitor.
	/// Here we'll look for variables and bind them to their declaration in the
	/// SymbolManager, so we can easily get their type later.
	/// </summary>
    public class RecognitionVisitor : AbstractSemanticVisitor<Void, Void>
	{

		private SymbolManager _manager;
	    public RecognitionVisitor(SymbolManager manager) : base(manager)
	    {
		    _manager = manager;
	    }
	    
	    
		
		public override Void Visit(Variable var, Void p)
		{
			IDefinition def = _manager.Find(var.Name);
			
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


		
		
		public override Void Visit(FunctionInvocation func, Void p)
		{
			//base.Visit(func, p);
			
			Logger.Instance.LogDebug("RecognitionVisitor visiting function invocation: " + func.Function.Name);
			
			// There's no need to call visit on func.getFunction.
			// We're gonna do that job here.
			Variable var = func.Function;
			IDefinition def = _manager.Find(var.Name);
			/*
			if (def == null)
			{
				IType t = DependencyManager.Instance.AddType(var.Line, var.Column, var.Name);
				def = new FunctionDefinition(var.Line, var.Column, var.Name, t, null);
			}
			*/
			var.Definition = def;
			
			foreach (IExpression expr in func.Arguments)
				expr.Accept(this, p);
			
			return null;
		}

		
    }
}