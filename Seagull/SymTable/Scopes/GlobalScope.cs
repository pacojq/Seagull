namespace Seagull.SymTable.Scopes
{
    public class GlobalScope : BaseScope
    {
        public GlobalScope() : base(null)
        {
            Name = "global";
        }
    }
}