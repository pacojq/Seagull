namespace Seagull.AST.Types.Namespaces
{
    public interface INamespaceType : IType
    {
        
        string Name { get; }
        
        string Fullname { get; }
        
        INamespaceType ParentNamespace { get; set; }

        bool AddDefinition(IDefinition definition);

        IDefinition FindDefinition(string name);
    }
}