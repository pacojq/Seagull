namespace Seagull.AST
{
    public interface IDefinition : IAstNode
    {
        string Name { get; }
        
        IType Type { get; }
        
        int Scope { get; set; }
    }
}