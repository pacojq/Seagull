using Seagull.AST.Statements.Definitions;
using Seagull.AST.Types;
using Seagull.Errors;
using Seagull.Semantics.Symbols;
using Seagull.Visitor;

namespace Seagull.Semantics
{
	public class DefinitionSeekVisitor : AbstractSemanticVisitor<Void, Void>
	{
		
		private readonly SymbolManager _manager;

		public DefinitionSeekVisitor(SymbolManager manager) : base(manager)
		{
			_manager = manager;
		}
		
		
		
		
		public override Void Visit(VariableDefinition varDefinition, Void p)
		{
			base.Visit(varDefinition, p);
			
			bool success = _manager.Insert(varDefinition);
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
			bool success = _manager.Insert(funcDefinition);
			if (!success)
			{
				ErrorHandler.Instance.RaiseError(
					funcDefinition.Line, 
					funcDefinition.Column,
					$"Trying to declare a function which already exists: {funcDefinition.Name}");
			}
			
			base.Visit(funcDefinition, p);
			return null;
		}
		
		
		
		public override Void Visit(StructDefinition structDefinition, Void p)
		{
			// Insert and set the scope
			bool success = _manager.Insert(structDefinition);
			if (!success)
			{
				ErrorHandler.Instance.RaiseError(
					structDefinition.Line, 
					structDefinition.Column,
					"Trying to declare a struct which already exists.");
			}
			((StructType) structDefinition.Type).Name = structDefinition.Name;

			base.Visit(structDefinition, p);
			return null;
		}
		
		
		
		public override Void Visit(DelegateDefinition delegateDefinition, Void p)
		{
			base.Visit(delegateDefinition, p);
			
			bool success = _manager.Insert(delegateDefinition);
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