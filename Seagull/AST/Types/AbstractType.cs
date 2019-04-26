using System.Collections.Generic;
using Seagull.Errors;

namespace Seagull.AST.Types
{
    public abstract class AbstractType : AbstractAstNode, IType
    {

        public virtual bool IsLogical => false;
        
        
        protected AbstractType(int line, int column) : base(line, column)
        {
        }
        
        
        public bool IsEquivalent(IType other)
        {
            return ToString().Equals(other.ToString());
        }
        
        public bool Is<T>() where T : IType
        {
            return this is T;
        }

        
        
        
        
        // Helper methods
	
        private IType DefaultOperation(IType other, string description) {
            if (other.Is<ErrorType>())
                return other;
            return DefaultOperation(description);
        }
	
        private IType DefaultOperation(string description) {
            return ErrorHandler.Instance.RaiseError(
                    Line, Column, $"The type {ToString()} does not support {description}."
                );
        }
	
	
	
	
        // - - - - - - - - - OPERATIONS - - - - - - - - - 
        
        
        public virtual IType Arithmetic(IType other)
        {
            return DefaultOperation(other, $"arithmetic operations with {other.ToString()}");
        }

        public virtual IType Comparison(IType other)
        {
            return DefaultOperation(other, $"comparisons with {other.ToString()}");
        }

        public virtual IType LogicalOperation(IType other)
        {
            return DefaultOperation(other, $"logical operations with {other.ToString()}");
        }

        public virtual IType Indexing(IType other)
        {
            return DefaultOperation(other, $"indexing with {other.ToString()}");
        }

        public virtual IType Cast(IType other)
        {
            return DefaultOperation(other, $"casts to {other.ToString()}");
        }

        public virtual IType New()
        {
            return DefaultOperation($"a 'new' operation");
        }

        public virtual IType UnaryMinus()
        {
            return DefaultOperation($"a unary minus operation");
        }

        public virtual IType Not()
        {
            return DefaultOperation($"a not operation");
        }

        public virtual IType AttributeAccess(string attributeName)
        {
            return DefaultOperation($"attribute access");
        }

        public virtual IType ParenthesesOperator(int line, int column, IEnumerable<IType> arguments)
        {
            return DefaultOperation($"parentheses operator");
        }
    }
}