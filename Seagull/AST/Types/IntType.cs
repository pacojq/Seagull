using System;
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


        public override IType Arithmetic(IType other)
        {
            switch (other.ToString())
            {
                case "char":    return this;
                case "int":     return this;
                case "double":  return other;
            }
            return base.Arithmetic(other);
        }
        
        
        public override IType Comparison(IType other)
        {
            switch (other.ToString())
            {
                case "char":
                case "int":
                case "double":
                    return new BooleanType(Line, Column);
            }
            return base.Arithmetic(other);
        }
        
        
        


        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}