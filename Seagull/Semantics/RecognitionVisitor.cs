
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Seagull.AST;
using Seagull.AST.Expressions;
using Seagull.AST.Statements.Definitions;
using Seagull.AST.Types;
using Seagull.Errors;
using Seagull.Semantics.Symbols;
using Seagull.Visitor;
using Void = Seagull.Visitor.Void;

namespace Seagull.Semantics
{
	
	/// <summary>
	/// This visitor must run after we have used the DeclarationVisitor and solved
	/// all type dependencies.
	/// Here we'll look for variables and bind them to their declaration in the
	/// SymbolTable, so we can easily get their type later.
	/// </summary>
    public class RecognitionVisitor : AbstractVisitor<Void, Void>
    {
        private readonly SymbolTable _table;
	
		
		public RecognitionVisitor(SymbolTable table)
		{
			_table = table;
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
						$"Trying to declare a variable which already exists: {varDefinition.Name}");
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
						$"Trying to declare a function which already exists: {funcDefinition.Name}");
			}
			_table.Set();
			
			// Normal visitor stuff
			base.Visit(funcDefinition, p);
			
			// Reset the scope
			_table.Reset();
			
			return null;
		}
		
		
		
		
		public override Void Visit(StructDefinition structDefinition, Void p)
		{
			// Insert and set the scope
			bool success = _table.Insert(structDefinition);
			if (!success)
			{
				ErrorHandler.Instance.RaiseError(
					structDefinition.Line, 
					structDefinition.Column,
					"Trying to declare a struct which already exists.");
			}
			_table.Set();
			
			// Normal visitor stuff
			base.Visit(structDefinition, p);
			
			// Reset the scope
			_table.Reset();
			
			((StructType) structDefinition.Type).Name = structDefinition.Name;
			
			return null;
		}
		
		
		
		
		
		public override Void Visit(DelegateDefinition delegateDefinition, Void p)
		{
			base.Visit(delegateDefinition, p);
			
			bool success = _table.Insert(delegateDefinition);
			if (!success)
			{
				ErrorHandler.Instance.RaiseError(
					delegateDefinition.Line, 
					delegateDefinition.Column,
					"Trying to declare a delegate which already exists.");
			}
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
				IType t = DependencyManager.Instance.AddType(var.Line, var.Column, var.Name);
				def = new VariableDefinition(var.Line, var.Column, var.Name, t, null);
			}
			var.Definition = def;
			
			foreach (IExpression expr in func.Arguments)
				expr.Accept(this, p);
			
			return null;
		}
		
		
	}
}