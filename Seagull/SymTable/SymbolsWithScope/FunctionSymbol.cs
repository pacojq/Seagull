namespace Seagull.SymTable.SymbolsWithScope
{
    public class FunctionSymbol : SymbolWithScope
    {
        public FunctionSymbol(string name, IScope parent) : base(name, parent)
        {
        }
    }
}