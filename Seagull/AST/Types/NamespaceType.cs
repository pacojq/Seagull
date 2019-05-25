using System.Collections.Generic;
using Seagull.Visitor;

namespace Seagull.AST.Types
{
	public class NamespaceType : AbstractType
	{
		public override int NumberOfBytes => 2; // A word

		//private readonly List<string> _subNamespaces;
		
		
		public NamespaceType(int line, int column) : base(line, column)
		{
			//_subNamespaces = new List<string>();
		}
		
		
		public void AddSubNamespace(string id)
		{
			//_subNamespaces.Add(id);
		}
		
		

		public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
		{
			return visitor.Visit(this, p);
		}
		
	}
}