using System;
using Seagull.Visitor;

namespace Seagull.AST.Types
{
    public class IntType : AbstractType
    {
        
        public override int NumberOfBytes => 2;
        
        
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
        
        
        


        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}