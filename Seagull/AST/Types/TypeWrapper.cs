using System.Collections.Generic;
using Seagull.Errors;
using Seagull.Visitor;

namespace Seagull.AST.Types
{
    
    /// <summary>
    /// Just wraps a type.
    /// It's used by the DependencyManager.
    /// </summary>
    public class TypeWrapper : IType
    {
        
        public int Line => _type.Line;
        public int Column => _type.Column;

        public bool IsLogical => _type.IsLogical;
        
        
        
        
        
        private IType _type;

        
        public TypeWrapper(int line, int column)
        {
            _type = new VoidType(line, column);
        }

        public void SetWrappedType(IType type)
        {
            _type = type;
        }
        
        

        public bool IsEquivalent(IType other)
        {
            return _type.IsEquivalent(other);
        }
        
        
        public bool Is<T>() where T : IType
        {
            return _type is T;
        }


        public IType Arithmetic(IType other)
        {
            return _type.Arithmetic(other);
        }

        public IType Comparison(IType other)
        {
            return _type.Comparison(other);
        }

        public IType LogicalOperation(IType other)
        {
            return _type.LogicalOperation(other);
        }

        public IType Indexing(IType other)
        {
            return _type.Indexing(other);
        }

        public IType Cast(IType other)
        {
            return _type.Cast(other);
        }

        public IType New()
        {
            return _type.New();
        }

        public IType UnaryMinus()
        {
            return _type.UnaryMinus();
        }

        public IType Not()
        {
            return _type.Not();
        }

        public IType AttributeAccess(string attributeName)
        {
            return _type.AttributeAccess(attributeName);
        }

        public IType ParenthesesOperator(int line, int column, IEnumerable<IType> arguments)
        {
            return _type.ParenthesesOperator(line, column, arguments);
        }


        
        
        public override string ToString()
        {
            return _type.ToString();
        }


        public TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return _type.Accept(visitor, p);
        }


    }
}