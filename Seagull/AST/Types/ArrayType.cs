namespace Seagull.AST.Types
{
    public class ArrayType : AbstractType
    {
        public int Size { get; }
        public IType TypeOf { get; private set; }
        
       
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


        public override string ToString()
        {
            return $"{TypeOf}[{Size}]";
        }
    }
}