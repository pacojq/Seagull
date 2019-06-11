using System.Linq;
using Seagull.Language.AST.Expressions.Binary;
using Seagull.Language.AST.Types;
using Seagull.Language.AST.Types.Namespaces;
using Seagull.Language.Visitor;
using Void = Seagull.Language.Visitor.Void;

namespace Seagull.VM.Visitors
{
    public class NumberOfBytesVisitor : AbstractVisitor<Void, Void>
    {
	    
	    public override Void Visit(Comparison comparison, Void p)
	    {
		    base.Visit(comparison, p);
		    comparison.Type.Accept(this, p);
		    return null;
	    }
	
		
	    public override Void Visit(LogicalOperation logicalOperation, Void p)
	    {
		    base.Visit(logicalOperation, p);
		    logicalOperation.Type.Accept(this, p);
		    return null;
	    }
	    
	    
	    
	    
	    
	    
	    
	    public override Void Visit(StructType structType, Void p)
	    {
		    base.Visit(structType, p);
		    structType.CgNumberOfBytes = structType.Definitions
			    .Select(f => f.Type)
			    .Sum(t => t.CgNumberOfBytes);
		    return null;
	    }
	    
	    public override Void Visit(ArrayType arrayType, Void p)
	    {
		    base.Visit(arrayType, p);
		    arrayType.CgNumberOfBytes = arrayType.Size * arrayType.TypeOf.CgNumberOfBytes;
		    return null;
	    }
	    
	    public override Void Visit(CharType charType, Void p)
	    {
		    charType.CgSuffix = "b";
		    charType.CgNumberOfBytes = Memory.BYTES_CHAR;
		    return null;
	    }
	    
	    public override Void Visit(IntType intType, Void p)
	    {
		    intType.CgSuffix = "i";
		    intType.CgNumberOfBytes = Memory.BYTES_INT;
		    return null;
	    }
	    
	    public override Void Visit(BooleanType boolType, Void p)
	    {
		    boolType.CgSuffix = "i";
		    boolType.CgNumberOfBytes = Memory.BYTES_BOOL;
		    return null;
	    }
	    
	    
	    public override Void Visit(DoubleType doubleType, Void p)
	    {
		    doubleType.CgSuffix = "f";
		    doubleType.CgNumberOfBytes = Memory.BYTES_DOUBLE;
		    return null;
	    }
	    
	    
	    
    }
}