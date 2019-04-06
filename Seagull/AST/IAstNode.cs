namespace Seagull.AST
{
    public interface IAstNode
    {
        int Line { get; }
        int Column { get; }
    }
}