using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Types
{
    public class DoubleType : AbstractType
    {
        
        public override int CgNumberOfBytes => 4;
        
        
        public DoubleType(int line, int column) : base(line, column)
        {
        }


        public override string ToString()
        {
            return "double";
        }
        
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}