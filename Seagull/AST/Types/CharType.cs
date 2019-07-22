using Seagull.Visitor;

namespace Seagull.AST.Types
{
    public class CharType : AbstractType
    {
        
        public override bool IsLogical => true;
        
        
        
        public CharType(int line, int column) : base(line, column)
        {
        }


        
        
        public override IType TypeCheckArithmetic(IType other)
        {
            switch (other.ToString())
            {
                case "char":    return this;
                case "int":     return other;
                case "double":  return other;
            }
            return base.TypeCheckArithmetic(other);
        }
        
        
        public override IType TypeCheckComparison(IType other)
        {
            switch (other.ToString())
            {
                case "char":
                case "int":
                case "double":
                    return new BooleanType(Line, Column);
            }
            return base.TypeCheckArithmetic(other);
        }
        
        
        public override IType TypeCheckCast(IType other)
        {
            switch (other.ToString())
            {
                case "char":    return this;
                case "int":     return other;
                case "double":  return other;
            }
            return base.TypeCheckCast(other);
        }
        
        public override IType TypeCheckIncrement()
        {
            return this;
        }
        
        
        
        
        public override string ToString()
        {
            return "char";
        }
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}