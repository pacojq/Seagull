using Seagull.AST;
using Seagull.AST.Expressions;
using Seagull.AST.Statements.Definitions;
using Seagull.AST.Statements.Definitions.Namespaces;
using Seagull.AST.Types;
using Seagull.AST.Types.Namespaces;
using Seagull.Errors;
using Seagull.Logging;
using Seagull.Semantics.Symbols;
using Seagull.Visitor;
using Void = Seagull.Visitor.Void;

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
	public class RecognitionThirdPassVisitor : AbstractRecognitionVisitor<bool>
	{


		public RecognitionThirdPassVisitor() : base("THIRD PASS", "Check for user-defined symbols")
		{
			
		}
		
		
		
		public override bool Visit(UnknownType unknown, INamespaceDefinition p)
		{
			Logger.Instance.LogDebug("[{0} : {1}] USER-DEFINED FOUND: {2}",
				unknown.Line,
				unknown.Column,
				unknown.Name);
			return true;
		}


		private IType Solve(IType userDefined, INamespaceDefinition inNamespace)
		{
			UnknownType ut = (UnknownType) userDefined;
			IDefinition def;
			
			// Find it in its namespace, if we're told so
			if (ut.Namespace != null)
			{
				def = SymbolManager.Instance.Find(ut.Name, ut.Namespace);
				if (def == null)
				{
					return ErrorHandler.Instance.RaiseError(
						ut.Line,
						ut.Column,
						"Symbol not found: " + ut.Namespace.Name + "." + ut.Name
					);
				}
			}
			// Otherwise, find it in the current namespace
			else
			{
				def = SymbolManager.Instance.Find(ut.Name, inNamespace);
				if (def == null)
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
			
			return def.Type;
		}
		
		
		
		
		
		
		
		
		
		
		
		
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		/*														 */
		/*						  TYPES							 */
		/*														 */
		/* * * * * * * * * * * * * * * * * * * * * * * * * * * * */
		
		
		
		public override bool Visit(ArrayType arrayType, INamespaceDefinition p)
		{
			bool dependency = arrayType.TypeOf.Accept(this, p);
			if (dependency)
				arrayType.TypeOf = Solve(arrayType.TypeOf, p);
			
			return false;
		}
		
		
		public override bool Visit(FunctionType functionType, INamespaceDefinition p)
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
		
		
		public override bool Visit(VariableDefinition variableDefinition, INamespaceDefinition p)
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
		
		
		public override bool Visit(Cast cast, INamespaceDefinition p)
		{
			bool dependency = cast.TargetType.Accept(this, p);
			if (dependency)
				cast.TargetType = Solve(cast.TargetType, p);
			
			cast.Operand.Accept(this, p);
			return false;
		}
		
		
		public override bool Visit(New newExpr, INamespaceDefinition p)
		{
			base.Visit(newExpr, p);
			IDefinition def = SymbolManager.Instance.Find(newExpr.Id, p);
			
			if (def == null)
			{
				newExpr.Type = ErrorHandler.Instance.RaiseError(
					newExpr.Line,
					newExpr.Column,
					$"Unknown symbol {newExpr.Id}."
				);
				return false;
			}
			return false;
		}
		
	}
}