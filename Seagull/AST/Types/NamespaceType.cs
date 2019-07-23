using System.Collections.Generic;
using Seagull.Errors;
using Seagull.Visitor;

namespace Seagull.AST.Types
{
	public class NamespaceType : AbstractType
	{
		
		public string Name { get; set; }


		public IEnumerable<IDefinition> Definitions => _definitions;

		private List<IDefinition> _definitions;
		
		
		public NamespaceType(int line, int col, string name) : base(line, col)
		{
			_definitions = new List<IDefinition>();
			Name = name;
		}
		
		
		/*
		public override IType TypeCheckAttributeAccess(string attribute)
		{
			// TODO use the new symbol table ?
			
			IDefinition def = FindDefinition(attribute);
			if (def == null)
			{
				return ErrorHandler.Instance.RaiseError(
					Line, 
					Column,
					$"The symbol {attribute} could not be found in the namespace {Name}."
				);
			}		
			return def.Type;
		}
		*/

		public void AddDefinition(IDefinition definition)
		{
			_definitions.Add(definition);
		}
		

		public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
		{
			return visitor.Visit(this, p);
		}
		
	}
}