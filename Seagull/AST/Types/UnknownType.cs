using Seagull.Visitor;

namespace Seagull.AST.Types
{
    public class UnknownType : AbstractType
    {
        
        public string Name { get; }
        
        public UnknownType(int line, int column, string name) : base(line, column)
        {
            Name = name;
        }

        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }

        public override int NumberOfBytes => 0;
    }
}