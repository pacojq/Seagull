
using Seagull.AST.Statements.Definitions;
using Seagull.AST.Types;
using Seagull.Errors;
using Seagull.Visitor;
using Void = Seagull.Visitor.Void;

namespace Seagull.Semantics
{
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
		
		
		
	}
}