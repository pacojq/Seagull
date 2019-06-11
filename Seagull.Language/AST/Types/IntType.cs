using System;
using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Types
{
    public class IntType : AbstractType
    {
        
        public override bool IsLogical => true;
        
        
        public IntType(int line, int column) : base(line, column)
        {
        }


        public override string ToString()
        {
            return "int";
        }


        public override IType TypeCheckArithmetic(IType other)
        {
            switch (other.ToString())
            {
                case "char":    return this;
                case "int":     return this;
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
                case "char":    return other;
                case "int":     return this;
                case "double":  return other;
            }
            return base.TypeCheckCast(other);
        }
        
        
        


        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}