using System;
using System.Linq;
using Seagull.AST.Expressions.Binary;
using Seagull.AST.Types;
using Seagull.Visitor;
using Void = Seagull.Visitor.Void;

namespace Seagull.CodeGeneration.Mapl
{
    public class MaplTypesVisitor : AbstractVisitor<Visitor.Void, Visitor.Void>
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
		    structType.CgNumberOfBytes = structType.Fields
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
		    charType.CgNumberOfBytes = 1;
		    return null;
	    }
	    
	    public override Void Visit(IntType intType, Void p)
	    {
		    intType.CgSuffix = "i";
		    intType.CgNumberOfBytes = 2;
		    return null;
	    }
	    
	    public override Void Visit(BooleanType boolType, Void p)
	    {
		    boolType.CgSuffix = "i";
		    boolType.CgNumberOfBytes = 2;
		    return null;
	    }
	    
	    
	    public override Void Visit(DoubleType doubleType, Void p)
	    {
		    doubleType.CgSuffix = "f";
		    doubleType.CgNumberOfBytes = 4;
		    return null;
	    }
	    
	    
	    
    }
}