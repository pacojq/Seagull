namespace Seagull.SymTable.Scopes
{
    /// <summary>
    /// Used for { ... } code blocks.
    /// </summary>
    public class LocalScope : BaseScope
    {
        public LocalScope(IScope parent) : base(parent)
        {
            Name = "local";
        }
    }
}