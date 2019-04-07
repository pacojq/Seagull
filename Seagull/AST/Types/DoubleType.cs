namespace Seagull.AST.Types
{
    public class DoubleType : AbstractType
    {
        public DoubleType(int line, int column) : base(line, column)
        {
        }


        public override string ToString()
        {
            return "double";
        }
    }
}