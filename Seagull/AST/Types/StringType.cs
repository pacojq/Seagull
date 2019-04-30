using Seagull.Visitor;

namespace Seagull.AST.Types
{
    public class StringType : AbstractType
    {
        
        public override int NumberOfBytes => 0; // TODO
        
        
        public StringType(int line, int column) : base(line, column)
        {
        }


        public override string ToString()
        {
            return "string";
        }
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}