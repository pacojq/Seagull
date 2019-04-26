
using Seagull.AST.Statements.Definitions;
using Seagull.AST.Types;
using Seagull.Errors;
using Seagull.Semantics.Symbols;
using Seagull.Visitor;
using Void = Seagull.Visitor.Void;

namespace Seagull.Semantics
{
	
	/// <summary>
	/// This visitor goes through the AST finding IDefinition nodes.
	/// When it finds any of them, it adds it to the SymbolTable.
	/// </summary>
    public class DeclarationVisitor : AbstractVisitor<Void, Void>
    {
        private readonly SymbolTable _table;
	
		
		public DeclarationVisitor(SymbolTable table)
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
		
		
	}
}