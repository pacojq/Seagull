using System;
using Seagull.AST.Statements.Definitions;
using Seagull.AST.Types;
using Seagull.Errors;
using Seagull.Semantics.Symbols;
using Void = Seagull.Visitor.Void;

namespace Seagull.Semantics
{
	/// <summary>
	/// TR: bool -> returns true if we've found a dependency.
	///
	/// We're gonna deal with definitions, and the variables bind to them.
	/// </summary>
	public class DependencyVisitor : AbstractSemanticVisitor<bool, Void>
	{
		
		private readonly SymbolManager _manager;

		public DependencyVisitor(SymbolManager manager) : base(manager)
		{
			_manager = manager;
		}


		public override bool Visit(UnknownType unknown, Void p)
		{
			Console.WriteLine("DEPENDENCY FOUND: " + unknown.Name);
			return true;
		}
	}
}