using Seagull.AST;
using Seagull.AST.Expressions;
using Seagull.AST.Statements.Definitions;
using Seagull.AST.Types;
using Seagull.Errors;
using Seagull.Visitor;
using Void = Seagull.Visitor.Void;

namespace Seagull.Semantics
{
    public class RecognitionVisitor : AbstractVisitor<Void, Void>
    {
        private readonly SymbolTable _table;
	
		
		public RecognitionVisitor(SymbolTable table)
		{
			_table = table;
		}
		
		
		
		
		public override Void Visit(Variable var, Void p)
		{
			IDefinition def = _table.Find(var.Name);
			
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
			
			// There's no need to call visit on func.getFunction.
			// We're gonna do that job here.
			Variable var = func.Function;
			IDefinition def = _table.Find(var.Name);
			
			if (def == null)
			{
				IType err = ErrorHandler.Instance.RaiseError(
						var.Line, 
						var.Column,
						"Cannot invoke a function which is not declared.");
				def = new VariableDefinition(var.Line, var.Column, var.Name, err);
			}
			var.Definition = def;
			
			foreach (IExpression expr in func.Arguments)
				expr.Accept(this, p);
			
			return null;
		}
		
		
	}
}