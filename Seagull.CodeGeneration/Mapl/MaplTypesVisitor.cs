using System;
using Seagull.Language.AST.Types;
using Seagull.Language.Visitor;
using Void = Seagull.Language.Visitor.Void;

namespace Seagull.CodeGeneration.Mapl
{
    public class MaplTypesVisitor : AbstractVisitor<Void, Void>
    {
	    public override Void Visit(CharType charType, Void p)
	    {
		    charType.CgSuffix = "b";
		    return null;
	    }
	    
	    public override Void Visit(IntType intType, Void p)
	    {
		    intType.CgSuffix = "i";
		    return null;
	    }
	    
	    
	    public override Void Visit(DoubleType doubleType, Void p)
	    {
		    doubleType.CgSuffix = "f";
		    Console.WriteLine("DOUBLE TYPE CG SUFFIX: "+ doubleType.CgSuffix);
		    return null;
	    }
    }
}