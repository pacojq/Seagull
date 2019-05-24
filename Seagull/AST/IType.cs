using System.Collections.Generic;

namespace Seagull.AST
{
    public interface IType : IAstNode
    {
        
	    int NumberOfBytes { get; }
	    
        
        bool IsLogical { get; }
        bool IsEnumerable { get; }
        
        bool IsEquivalent(IType other);
        
        
	
        // Type checking
        
        IType TypeCheckArithmetic(IType other);
        IType TypeCheckComparison(IType other);
        IType TypeCheckLogicalOperation(IType other);
        IType TypeCheckIndexing(IType other);
        IType TypeCheckCast(IType other);
        IType TypeCheckNew();
	
        IType TypeCheckUnaryMinus();
        IType TypeCheckNot();

        IType TypeCheckAttributeAccess(string attributeName);
        IType TypeCheckParentheses(int line, int column, IEnumerable<IType> arguments);

        
    }
}