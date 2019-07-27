using System.Text;
using Seagull.AST;
using Seagull.AST.Expressions;
using Seagull.AST.Statements.Definitions;
using Seagull.AST.Types;
using Seagull.Errors;
using Seagull.Logging;
using Seagull.SymTable;
using Seagull.Visitor;

namespace Seagull.Semantics.Recognition
{
	/// <summary>
	/// In this pass we're going to check for user-defined symbols.
	/// 
	/// We're gonna override any function in which we visit a IType child.
	/// We'll check if that type is user-defined and we'll find its declaration.
	///
	/// TR: bool -> returns true if we've found a user-defined symbol.
	/// </summary>
	public class DependencyRecognitionVisitor : AbstractRecognitionVisitor<bool>
	{


		public DependencyRecognitionVisitor() : base("THIRD PASS", "Check for user-defined symbols")
		{
			
		}
		
		
		
		public override bool Visit(UnknownType unknown, Void p)
		{
			Logger.Instance.LogDebug("[{0} : {1}] USER-DEFINED FOUND: {2}",
				unknown.Line,
				unknown.Column,
				unknown.Name);
			return true;
		}


		private IType Solve(IType userDefined, Void p)
		{
			UnknownType ut = (UnknownType) userDefined;
			ISymbol symbol = null;
			IScope scope = SymbolTable.Instance.CurrentScope;
			
			// Now we'll find the correct scope in which we'll look for the symbol
			
			// First, check in the current scope
			for (int i = 0; i < ut.Namespace.Count; i++)
			{
				scope = scope.SolveScope(ut.Namespace[i]);
				if (scope == null)
					break;
			}

			// If we haven't find it, find in the global scope
			if (scope == null)
			{
				scope = SymbolTable.GlobalScope;
				for (int i = 0; i < ut.Namespace.Count; i++)
				{
					scope = scope.SolveScope(ut.Namespace[i]);
					if (scope == null)
						break;
				}
			}
			
			// Okay, we couldn't find the scope. Raise an error
			if (scope == null)
			{
				StringBuilder str = new StringBuilder();
				str.Append(ut.Namespace[0]);
				for (int i = 1; i < ut.Namespace.Count; i++)
					str.Append("." + ut.Namespace[i]);
				
				return ErrorHandler.Instance.RaiseError(
					ut.Line,
					ut.Column,
					$"The namespace {str.ToString()} could not be found."
				);
			}
			
			
			// Otherwise, find it in the current namespace
			symbol = scope.Solve(ut.Name);
			if (symbol == null)
			{
				return ErrorHandler.Instance.RaiseError(
					ut.Line,
					ut.Column,
					"Symbol not found: " + ut.Name
				);
			}
			

			Logger.Instance.LogDebug("[{0} : {1}] SYMBOL SOLVED: {2}",
				ut.Line,
				ut.Column,
				ut.Name);
			
			return symbol.Definition.Type;
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
				arrayType.TypeOf = Solve(arrayType.TypeOf, p);
			
			return false;
		}
		
		
		public override bool Visit(FunctionType functionType, Void p)
		{
			bool dependency = functionType.ReturnType.Accept(this, p);
			if (dependency)
				functionType.ReturnType = Solve(functionType.ReturnType, p);
			
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
				variableDefinition.Type = Solve(variableDefinition.Type, p);
			
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
				cast.TargetType = Solve(cast.TargetType, p);
			
			cast.Operand.Accept(this, p);
			return false;
		}
		
		
		public override bool Visit(New newExpr, Void p)
		{
			bool dependency = newExpr.Type.Accept(this, p);
			if (dependency)
				newExpr.Type = Solve(newExpr.Type, p);
			
			return false;
		}
		
	}
}