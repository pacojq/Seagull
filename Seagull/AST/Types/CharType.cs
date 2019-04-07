namespace Seagull.AST.Types
{
    public class CharType : AbstractType
    {
        public CharType(int line, int column) : base(line, column)
        {
        }


        public override string ToString()
        {
            return "char";
        }
    }
}