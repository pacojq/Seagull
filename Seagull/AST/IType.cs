using System.Collections.Generic;

namespace Seagull.AST
{
    public interface IType : IAstNode
    {
        
        
        // Operations
	
        bool IsLogical { get; }
        bool IsEquivalent(IType other);
        
        
	
        IType Arithmetic(IType other);
        IType Comparison(IType other);
        IType LogicalOperation(IType other);
        IType Indexing(IType other);
        IType Cast(IType other);
	
        IType UnaryMinus();
        IType Not();

        IType AttributeAccess(string attributeName);
        IType ParenthesesOperator(int line, int column, IEnumerable<IType> arguments);

        
    }
}