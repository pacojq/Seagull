using System.Collections.Generic;

namespace Seagull.AST.Statements.Definitions
{
    public interface INamespaceDefinition : IDefinition
    {
        
        string Fullname { get; }
        
        
        IEnumerable<IDefinition> Definitions { get; }
        
        void AddDefinition(IDefinition definition);
    }
}