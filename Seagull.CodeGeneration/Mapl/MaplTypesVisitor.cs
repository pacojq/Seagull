using Seagull.AST.Types;
using Seagull.Visitor;
using Void = Seagull.Visitor.Void;

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
		    return null;
	    }
    }
}