using System;
using Seagull.AST;
using Seagull.AST.Expressions;
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
	/// We're gonna override any function in which we visit a IType child.
	/// We'll check if that type has a dependency and we'll solve it.
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
			Console.WriteLine("[{0} : {1}] DEPENDENCY FOUND: {2}",
				unknown.Line,
				unknown.Column,
				unknown.Name);
			return true;
		}


		private IType Solve(IType dependency)
		{
			UnknownType ut = (UnknownType) dependency;
			IType result = _manager.Find(ut.Name).Type;
			if (!(result is ErrorType))
			{
				Console.WriteLine("[{0} : {1}] DEPENDENCY SOLVED: {2}",
					ut.Line,
					ut.Column,
					ut.Name);
			}
			return result;
		}
		
		
		
		
		
		
		
		
		
		
		
		
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		/*														 */
		/*						  TYPES							 */
		/*														 */
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		
		
		
		public override bool Visit(ArrayType arrayType, Void p)
		{
			bool dependency = arrayType.TypeOf.Accept(this, p);
			if (dependency)
				arrayType.TypeOf = Solve(arrayType.TypeOf);
			
			return false;
		}
		
		
		public override bool Visit(FunctionType functionType, Void p)
		{
			bool dependency = functionType.ReturnType.Accept(this, p);
			if (dependency)
				functionType.ReturnType = Solve(functionType.ReturnType);
			
			foreach (VariableDefinition def in functionType.Parameters)
				def.Accept(this, p);
			return false;
		}
		
		
		
		
		
		
		
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		/*														 */
		/*					   STATEMENTS						 */
		/*														 */
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		
		
		public override bool Visit(VariableDefinition variableDefinition, Void p)
		{
			bool dependency =  variableDefinition.Type.Accept(this, p);
			if (dependency)
				variableDefinition.Type = Solve(variableDefinition.Type);
			
			if (variableDefinition.Initialization != null)
				variableDefinition.Initialization.Accept(this, p);
			
			return false;
		}
		
		
		
		
		
		
		
		
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		/*														 */
		/*					   EXPRESSIONS						 */
		/*														 */
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		
		
		public override bool Visit(Cast cast, Void p)
		{
			bool dependency = cast.TargetType.Accept(this, p);
			if (dependency)
				cast.TargetType = Solve(cast.TargetType);
			
			cast.Operand.Accept(this, p);
			return false;
		}
		
		
	}
}