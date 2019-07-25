using Seagull.AST.AccessModifiers;

namespace Seagull.AST
{
    public interface IDefinition : IStatement
    {
        string Name { get; }
        
        IType Type { get; }
        
        int Scope { get; set; }
        
        IAccessModifier AccessModifier { get; set; }
        
        
        // Code Generation
        int CgOffset { get; set; }
    }
}