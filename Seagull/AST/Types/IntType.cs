namespace Seagull.AST.Types
{
    public class IntType : AbstractType
    {
        public IntType(int line, int column) : base(line, column)
        {
        }


        public override string ToString()
        {
            return "int";
        }
    }
}