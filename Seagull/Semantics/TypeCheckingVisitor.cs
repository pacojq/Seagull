using System;
using System.Collections.Generic;
using Seagull.AST;
using Seagull.AST.Expressions;
using Seagull.AST.Expressions.Binary;
using Seagull.AST.Statements;
using Seagull.AST.Statements.Definitions;
using Seagull.AST.Types;
using Seagull.Errors;
using Seagull.Semantics.Symbols;
using Seagull.Visitor;

using Void = Seagull.Visitor.Void;

namespace Seagull.Semantics
{
    public class TypeCheckingVisitor : AbstractSemanticVisitor<Void, IType>
    {
	    
	    private SymbolManager _manager;
	    public TypeCheckingVisitor(SymbolManager manager) : base(manager)
	    {
		    _manager = manager;
	    }
	    
	    
	    
	    
	    public override Void Visit(VariableDefinition variableDefinition, IType p)
	    {
		    base.Visit(variableDefinition, variableDefinition.Type);
		    if (variableDefinition.Initialization != null)
		    {
			    IExpression init = variableDefinition.Initialization;
			    if (!init.Type.IsEquivalent(variableDefinition.Type))
			    {
				    ErrorHandler.Instance.RaiseError(
					    init.Line,
					    init.Column,
					    $"Cannot assign initialize to {init.Type} a variable declared as {variableDefinition.Type}."
				    );
			    }
		    }

		    return null;
	    }
	    
	    
	    
	    
        public override Void Visit(Variable variable, IType p)
        {
			base.Visit(variable, variable.Type);
			variable.Type = variable.Definition.Type;
			return null;
		}
		
		
		public override Void Visit(FunctionInvocation functionInvocation, IType p)
		{
			base.Visit(functionInvocation, p);
			
			IDefinition def = functionInvocation.Function.Definition;
			List<IType> arguments = new List<IType>();
			foreach (IExpression expr in functionInvocation.Arguments)
				arguments.Add(expr.Type);
			
			functionInvocation.Type = def.Type.ParenthesesOperator(
							functionInvocation.Line,
							functionInvocation.Column,
							arguments
						);
			return null;
		}
		
		
		
		
		
		
		
		public override Void Visit(Arithmetic arithmetic, IType p)
		{
			base.Visit(arithmetic, p);
			arithmetic.Type = arithmetic.Left.Type.Arithmetic(arithmetic.Right.Type);		
			return null;
		}
		
		
		public override Void Visit(LogicalOperation logicalOperation, IType p)
		{
			base.Visit(logicalOperation, p);
			logicalOperation.Type = logicalOperation.Left.Type.LogicalOperation(logicalOperation.Right.Type);		
			return null;
		}
		
		
		public override Void Visit(Comparison comparison, IType p)
		{
			base.Visit(comparison, p);
			comparison.Type = comparison.Left.Type.Comparison(comparison.Right.Type);
			return null;
		}
		
		
		
		
		
		
		
		public override Void Visit(Assignment assignment, IType p)
		{
			base.Visit(assignment, p);
			IType t1 = assignment.Left.Type;
			IType t2 = assignment.Right.Type;

			if (t2.Is<ErrorType>())
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
		
		
		
		public override Void Visit(Cast cast, IType p)
		{
			base.Visit(cast, p);
			cast.Type = cast.Operand.Type.Cast(cast.TargetType);
			return null;
		}
		
		
		
		public override Void Visit(New newExpr, IType p)
		{
			base.Visit(newExpr, p);
			IDefinition def = SymbolManager.Instance.Find(newExpr.Id);
			
			if (def == null)
			{
				newExpr.Type = ErrorHandler.Instance.RaiseError(
						newExpr.Line,
						newExpr.Column,
						$"Cannot create an instance of the undefined type {newExpr.Id}."
					);
				return null;
			}
			
			newExpr.Type = def.Type.New();
			return null;
		}
		
		
		
		public override Void Visit(AttributeAccess attributeAccess, IType p)
		{
			base.Visit(attributeAccess, p);
			attributeAccess.Type = attributeAccess.Operand.Type.AttributeAccess(attributeAccess.AttributeName);
			return null;
		}
		
		
		
		public override Void Visit(Indexing indexing, IType p)
		{
			base.Visit(indexing, p);
			indexing.Type = indexing.Operand.Type.Indexing(indexing.Index.Type);
			return null;
		}
		
		
		
		
		
		
		
		
		
		
		// STATEMENTS HAVE NO TYPE!!!! WE'LL JUST CHECK, NOT ASSIGN.
		
		
		
		public override Void Visit(IfStatement ifStatement, IType p)
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
		
		
		public override Void Visit(WhileLoop whileLoop, IType p)
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
		
		
		
	
		public override Void Visit(Return returnStmnt, IType p)
		{
			base.Visit(returnStmnt, p);
			
			FunctionType ft = (FunctionType) p;
			IType retType = ft.ReturnType;
			IType actualRetType = returnStmnt.Value.Type;
			
			if (actualRetType.Is<ErrorType>())
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
		
		
		
    }
}