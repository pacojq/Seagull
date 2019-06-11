using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Types
{
    public class PointerType : AbstractType
    {
        
        public PointerType(int line, int column) : base(line, column)
        {
        }


        public override string ToString()
        {
            return "ptr";
        }


        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}