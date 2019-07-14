namespace Seagull.AST
{
    public interface IExpression : IAstNode
    {
        IType Type { get; set; }
        bool LValue { get; set; }
        
        
        
        
        // Code Generation
        
        /// <summary>
        /// Code Generation: code to get the address in
        /// memory of the expression.
        /// It may only be called by L-Value expressions.
        /// </summary>
        string CgAddress { get; set; }
        
        
        /// <summary>
        /// Code Generation: code to get the value of the expression.
        /// </summary>
        string CgValue { get; set; }
    }
}