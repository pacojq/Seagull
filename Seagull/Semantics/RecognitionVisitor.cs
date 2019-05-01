
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
		
		
		
		
		public override Void Visit(FunctionDefinition funcDefinition, Void p)
		{
			_table.Set();
			base.Visit(funcDefinition, p);
			_table.Reset();
			
			return null;
		}
		
		
		
		
		public override Void Visit(StructDefinition structDefinition, Void p)
		{
			_table.Set();
			base.Visit(structDefinition, p);
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
				IType t = DependencyManager.Instance.AddType(var.Line, var.Column, var.Name);
				def = new FunctionDefinition(var.Line, var.Column, var.Name, t, null);
			}
			var.Definition = def;
			
			foreach (IExpression expr in func.Arguments)
				expr.Accept(this, p);
			
			return null;
		}
		
		
	}
}