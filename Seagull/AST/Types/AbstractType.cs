namespace Seagull.AST.Types
{
    public abstract class AbstractType : AbstractAstNode, IType
    {
        protected AbstractType(int line, int column) : base(line, column)
        {
        }
    }
}