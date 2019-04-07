namespace Seagull.AST.Types
{
    public static class Extensions
    {
        public static bool IsEquivalent(this IType t, IType other)
        {
            return t.ToString().Equals(other.ToString());
        }
        
    }
}