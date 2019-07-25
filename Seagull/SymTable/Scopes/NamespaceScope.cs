namespace Seagull.SymTable.Scopes
{
    public class NamespaceScope : BaseScope
    {
        public NamespaceScope(string name, IScope parent) : base(parent)
        {
            Name = name;
        }
    }
}