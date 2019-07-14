using Seagull.Visitor;

namespace Seagull.AST.Types
{
    public class LongType : AbstractType
    {
        public LongType(int line, int column) : base(line, column)
        {
        }


        public override string ToString()
        {
            return "long";
        }


        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}