using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Types
{
    public class BooleanType : AbstractType
    {
        
        public override int CgNumberOfBytes => 1;
        
        public override bool IsLogical => true;

        public BooleanType(int line, int column) : base(line, column)
        {
        }


        public override IType TypeCheckLogicalOperation(IType other)
        {
            if (IsEquivalent(other))
                return this;
            return base.TypeCheckLogicalOperation(other);
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