using Seagull.Visitor;

namespace Seagull.AST.Types
{
    public class VoidType : AbstractType
    {
        
        public override int CgNumberOfBytes => 0;
        
        public VoidType(int line, int column) : base(line, column)
        {
        }


        public override string ToString()
        {
            return "void";
        }
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}