namespace Seagull.AST.Types
{
    public class VoidType : AbstractType
    {
        public VoidType(int line, int column) : base(line, column)
        {
        }


        public override string ToString()
        {
            return "void";
        }
    }
}