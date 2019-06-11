using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Types
{
    public class CharType : AbstractType
    {
        
        public override int CgNumberOfBytes => 1;
        
        
        public CharType(int line, int column) : base(line, column)
        {
        }


        public override string ToString()
        {
            return "char";
        }
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}