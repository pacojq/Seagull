using System;
using System.Collections.Generic;
using Seagull.Errors;
using Seagull.Visitor;

namespace Seagull.AST.Types.Namespaces
{
	public class NamespaceType : AbstractNamespaceType
	{
		public override int CgNumberOfBytes => 2; // A word

		
		
		public sealed override string Name { get; set; }
		
		
		
		public NamespaceType(int line, int col, string name, NamespaceType parent) : base(line, col)
		{
			Name = name;
			ParentNamespace = parent;
		}
		
		
		public override IType TypeCheckAttributeAccess(string attribute)
		{
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
		
		

		public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
		{
			return visitor.Visit(this, p);
		}
		
	}
}