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


		private IType Solve(IType userDefined, Void inNamespace)
		{
			UnknownType ut = (UnknownType) userDefined;
			ISymbol symbol = null;
			
			// Find it in its namespace, if we're told so
			if (ut.Namespace != null)
			{
				// TODO
				/*
				def = SymbolTable.Instance.Find(ut.Name, ut.Namespace);
				if (def == null)
				{
					return ErrorHandler.Instance.RaiseError(
						ut.Line,
						ut.Column,
						"Symbol not found: " + ut.Namespace.Name + "." + ut.Name
					);
				}
				*/
			}
			// Otherwise, find it in the current namespace
			else
			{
				symbol = SymbolTable.Instance.Solve(ut.Name);
				if (symbol == null)
				{
					return ErrorHandler.Instance.RaiseError(
						ut.Line,
						ut.Column,
						"Symbol not found: " + ut.Name
					);
				}
			}

			Logger.Instance.LogDebug("[{0} : {1}] SYMBOL FOUND: {2}",
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