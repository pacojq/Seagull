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
	
		
		public RecognitionVisitor()
		{
			_table = new SymbolTable();
		}
		
		
		public override Void Visit(VariableDefinition varDefinition, Void p)
		{
			base.Visit(varDefinition, p);
			
			bool success = _table.Insert(varDefinition);
			if (!success)
			{
				ErrorHandler.Instance.RaiseError(
						varDefinition.Line, 
						varDefinition.Column,
						"Trying to declare a variable which already exists.");
			}
			return null;
		}
		
		
		
		public override Void Visit(FunctionDefinition funcDefinition, Void p)
		{
			// Insert and set the scope
			bool success = _table.Insert(funcDefinition);
			if (!success)
			{
				ErrorHandler.Instance.RaiseError(
						funcDefinition.Line, 
						funcDefinition.Column,
						"Trying to declare a function which already exists.");
			}
			_table.Set();
			
			// Normal visitor stuff
			base.Visit(funcDefinition, p);
			
			// Reset the scope
			_table.Reset();
			
			return null;
		}
		
		
		
		
		
		public override Void Visit(StructType structType, Void p)
		{
			_table.Set();
			
			// Kinda like base.Visit(). We just change the error message.
			foreach (VariableDefinition def in structType.Fields)
			{
				base.Visit(def, p);
				bool success = _table.Insert(def);
				if (!success)
				{
					ErrorHandler.Instance.RaiseError(
							def.Line, 
							def.Column,
							"Trying to declare an already existing struct field.");
				}
			}
			
			_table.Reset();
			
			return null;
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