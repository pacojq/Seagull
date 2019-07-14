using Seagull.Visitor;

namespace Seagull.AST.Types
{
    public class ArrayType : AbstractType
    {
        
        public int Size { get; }
        public IType TypeOf { get; internal set; }
        
       
        public static ArrayType BuildArray(int size, IType typeOf)
        {
            if (typeOf is ArrayType) {			
                ArrayType other = (ArrayType) typeOf;
                other.TypeOf = BuildArray(size, other.TypeOf);
                return other;			
            }
            else return new ArrayType(size, typeOf);
        }
        
        public ArrayType(int size, IType typeOf) : base(typeOf.Line, typeOf.Column)
        {
            Size = size;
            TypeOf = typeOf;
        }

        
        
        public override IType TypeCheckIndexing(IType other)
        {
            if (other is IntType || other is CharType)
            {
                return this.TypeOf;
            }
            return base.TypeCheckIndexing(other);
        }

        
        
        

        public override string ToString()
        {
            return $"{TypeOf}[{Size}]";
        }
        
        
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}