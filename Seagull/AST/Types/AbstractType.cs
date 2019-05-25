using System.Collections.Generic;
using System.Diagnostics;
using Seagull.Errors;
using Seagull.Logging;

namespace Seagull.AST.Types
{
    public abstract class AbstractType : AbstractAstNode, IType
    {
        public abstract int NumberOfBytes { get; }
        public virtual bool IsLogical => false;
        public virtual bool IsEnumerable => false;


        protected AbstractType(int line, int column) : base(line, column)
        {
        }
        
        
        public virtual bool IsEquivalent(IType other)
        {
            return ToString().Equals(other.ToString());
        }
        

        
        
        
        
        // Helper methods
	
        private IType DefaultOperation(IType other, string description) {
            if (other is ErrorType)
            {
                return other;
            }
            return DefaultOperation(description);
        }
	
        protected virtual IType DefaultOperation(string description) {
            return ErrorHandler.Instance.RaiseError(
                    Line, Column, $"The type {ToString()} does not support {description}."
                );
        }
	
	
	
	
        // - - - - - - - - - OPERATIONS - - - - - - - - - 
        
        
        public virtual IType TypeCheckArithmetic(IType other)
        {
            return DefaultOperation(other, $"arithmetic operations with {other.ToString()}");
        }

        public virtual IType TypeCheckComparison(IType other)
        {
            return DefaultOperation(other, $"comparisons with {other.ToString()}");
        }

        public virtual IType TypeCheckLogicalOperation(IType other)
        {
            return DefaultOperation(other, $"logical operations with {other.ToString()}");
        }

        public virtual IType TypeCheckIndexing(IType other)
        {
            return DefaultOperation(other, $"indexing with {other.ToString()}");
        }

        public virtual IType TypeCheckCast(IType other)
        {
            return DefaultOperation(other, $"casts to {other.ToString()}");
        }

        public virtual IType TypeCheckNew()
        {
            return DefaultOperation($"a 'new' operation");
        }

        public virtual IType TypeCheckUnaryMinus()
        {
            return DefaultOperation($"a unary minus operation");
        }

        public virtual IType TypeCheckNot()
        {
            return DefaultOperation($"a not operation");
        }

        public virtual IType TypeCheckAttributeAccess(string attributeName)
        {
            return DefaultOperation($"attribute access");
        }

        public virtual IType TypeCheckParentheses(int line, int column, IEnumerable<IType> arguments)
        {
            return DefaultOperation($"parentheses operator");
        }
    }
}