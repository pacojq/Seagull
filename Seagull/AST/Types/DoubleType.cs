using Seagull.Visitor;

namespace Seagull.AST.Types
{
    public class DoubleType : AbstractType
    {
        
        
        public DoubleType(int line, int column) : base(line, column)
        {
        }


        public override IType TypeCheckArithmetic(IType other)
        {
            switch (other.ToString())
            {
                case "char":
                case "int":
                case "double":  
                    return this;
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
                case "char":    return other;
                case "int":     return other;
                case "double":  return this;
            }
            return base.TypeCheckCast(other);
        }
        
        public override IType TypeCheckIncrement()
        {
            return this;
        }
        
        
        
        public override string ToString()
        {
            return "double";
        }
        
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}