namespace Seagull.SymTable.Symbols
{
    public class FunctionSymbol : SymbolWithScope
    {
        public FunctionSymbol(string name, IScope parent) : base(name, parent)
        {
        }
    }
}