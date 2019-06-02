using Seagull.Visitor;

namespace Seagull.AST
{
    public interface IAstNode
    {
        int Line { get; }
        int Column { get; }
        
        
        TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p);
        
        //ICodeGenerationData CgData { get; set; }
    }
}