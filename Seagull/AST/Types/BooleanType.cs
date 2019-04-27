using Seagull.Visitor;

namespace Seagull.AST.Types
{
    public class BooleanType : AbstractType
    {
        public BooleanType(int line, int column) : base(line, column)
        {
        }


        public override string ToString()
        {
            return "bool";
        }
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}