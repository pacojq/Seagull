using System;
using System.Collections.Generic;
using Seagull.Language.AST.Types;
using Seagull.Language.AST.Types.Namespaces;
using Seagull.Language.AST;
using Seagull.Language.AST.Expressions;
using Seagull.Language.AST.Expressions.Binary;
using Seagull.Language.AST.Statements;
using Seagull.Language.AST.Statements.Definitions;
using Seagull.Language.Errors;
using Seagull.Language.Visitor;
using Seagull.Logging;
using Seagull.Language.Semantics.Symbols;
using Void = Seagull.Language.Visitor.Void;

namespace Seagull.Language.Semantics.TypeChecking
{
    public class TypeCheckingVisitor : AbstractVisitor<Visitor.Void, IType>
    {
	    
	    public override Visitor.Void Visit(VariableDefinition variableDefinition, IType p)
	    {
		    base.Visit(variableDefinition, variableDefinition.Type);
		    if (variableDefinition.Initialization != null)
		    {
			    IExpression init = variableDefinition.Initialization;
			    
			    // We already have an error. Don't rise a new one
			    if (init.Type is ErrorType)
				    return null;
			    
			    if (!init.Type.IsEquivalent(variableDefinition.Type))
			    {
				    ErrorHandler.Instance.RaiseError(
					    init.Line,
					    init.Column,
					    $"Cannot initialize to {init.Type} a variable declared as {variableDefinition.Type}."
				    );
			    }
		    }

		    return null;
	    }
	    
	    
	    
	    
	    
        public override Visitor.Void Visit(Variable variable, IType p)
        {
			base.Visit(variable, variable.Type);
			if (variable.Definition == null)
				throw new Exception($"Variable {variable.Name} has no definition");
			variable.Type = variable.Definition.Type;
			return null;
		}
		
		
		public override Visitor.Void Visit(FunctionInvocation functionInvocation, IType p)
		{
			base.Visit(functionInvocation, p);
			
			IDefinition def = functionInvocation.Function.Definition;
			List<IType> arguments = new List<IType>();
			foreach (IExpression expr in functionInvocation.Arguments)
				arguments.Add(expr.Type);
			
			functionInvocation.Type = def.Type.TypeCheckParentheses(
							functionInvocation.Line,
							functionInvocation.Column,
							arguments
						);
			return null;
		}
		
		
		
		
		
		
		
		public override Visitor.Void Visit(Arithmetic arithmetic, IType p)
		{
			base.Visit(arithmetic, p);
			arithmetic.Type = arithmetic.Left.Type.TypeCheckArithmetic(arithmetic.Right.Type);		
			return null;
		}
		
		
		public override Visitor.Void Visit(LogicalOperation logicalOperation, IType p)
		{
			base.Visit(logicalOperation, p);
			logicalOperation.Type = logicalOperation.Left.Type.TypeCheckLogicalOperation(logicalOperation.Right.Type);		
			return null;
		}
		
		
		public override Visitor.Void Visit(Comparison comparison, IType p)
		{
			base.Visit(comparison, p);
			comparison.Type = comparison.Left.Type.TypeCheckComparison(comparison.Right.Type);
			return null;
		}
		
		
		
		
		
		
		
		public override Visitor.Void Visit(Assignment assignment, IType p)
		{
			base.Visit(assignment, p);
			IType t1 = assignment.Left.Type;
			IType t2 = assignment.Right.Type;

			if (t2 is ErrorType)
				return null;
			
			if (!t1.IsEquivalent(t2))
			{
				ErrorHandler.Instance.RaiseError(
					assignment.Line, 
					assignment.Column,
					$"Cannot assign type {t2} to an expression declared as {t1}."
				);
			}
			return null;
		}
		
		
		
		public override Visitor.Void Visit(Cast cast, IType p)
		{
			base.Visit(cast, p);
			cast.Type = cast.Operand.Type.TypeCheckCast(cast.TargetType);
			return null;
		}
		
		
		
		public override Visitor.Void Visit(New newExpr, IType p)
		{
			base.Visit(newExpr, p);
			newExpr.Type = newExpr.Type.TypeCheckNew();
			return null;
		}
		
		
		
		public override Visitor.Void Visit(AttributeAccess attributeAccess, IType p)
		{
			base.Visit(attributeAccess, p);
			attributeAccess.Type = attributeAccess.Operand.Type.TypeCheckAttributeAccess(attributeAccess.AttributeName);
			return null;
		}
		
		
		
		public override Visitor.Void Visit(Indexing indexing, IType p)
		{
			base.Visit(indexing, p);
			indexing.Type = indexing.Operand.Type.TypeCheckIndexing(indexing.Index.Type);
			return null;
		}
		
		
		
		
		
		
		
		
		
		
		// STATEMENTS HAVE NO TYPE!!!! WE'LL JUST CHECK, NOT ASSIGN.
		
		
		
		public override Visitor.Void Visit(IfStatement ifStatement, IType p)
		{
			base.Visit(ifStatement, p);
			IType t = ifStatement.Condition.Type;
			if (!t.IsLogical)
			{
				ErrorHandler.Instance.RaiseError(
						ifStatement.Line, 
						ifStatement.Column,
						$"Cannot evaluate the type {t} as a logical expression."
				);
			}
			return null;
		}
		
		
		public override Visitor.Void Visit(WhileLoop whileLoop, IType p)
		{
			base.Visit(whileLoop, p);
			IType t = whileLoop.Condition.Type;
			if (!t.IsLogical)
			{
				ErrorHandler.Instance.RaiseError(
						whileLoop.Line, 
						whileLoop.Column,
						$"Cannot evaluate the type {t} as a logical expression."
				);
			}
			return null;
		}
		
		
		/*
	
		public override Void Visit(Return returnStmnt, IType p)
		{
			base.Visit(returnStmnt, p);
			
			FunctionType ft = (FunctionType) p;
			IType retType = ft.ReturnType;
			IType actualRetType = returnStmnt.Value.Type;
			
			if (actualRetType is ErrorType)
				return null; // We already have an error
			
			if (!actualRetType.IsEquivalent(retType))
			{
				ErrorHandler.Instance.RaiseError(
						returnStmnt.Line, 
						returnStmnt.Column,
						$"Inconsistent return type. Actual: {actualRetType}; Expected: {retType}"
					);	
			}
			
			return null;
		}
		
		*/
		
    }
}