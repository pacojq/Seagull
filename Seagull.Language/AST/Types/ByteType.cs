using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Types
{
    public class ByteType : AbstractType
    {
        
        public override bool IsLogical => true;
        
        
        public ByteType(int line, int column) : base(line, column)
        {
        }


        public override string ToString()
        {
            return "byte";
        }


        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}