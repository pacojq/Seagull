using Seagull.Language.AST.Statements.Definitions;
using Seagull.Language.AST.Statements.Definitions.Namespaces;

namespace Seagull.Language.AST
{
    public interface IDefinition : IStatement
    {
        string Name { get; }
        
        IType Type { get; }
        
        int Scope { get; set; }
        
        
        INamespaceDefinition Namespace { get; set; }
        
        
        
        
        // Code Generation
        int CgOffset { get; set; }
    }
}