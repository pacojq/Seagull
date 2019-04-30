namespace Seagull.AST
{
    public interface IDefinition : IStatement
    {
        string Name { get; }
        
        IType Type { get; }
        
        int Scope { get; set; }
        int Offset { get; set; }
    }
}