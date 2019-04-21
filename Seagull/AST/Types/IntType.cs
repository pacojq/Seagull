using Seagull.Visitor;

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
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}