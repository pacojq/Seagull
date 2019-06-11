using Seagull.Language.AST.Types;
using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Statements.Definitions
{
    public class DelegateDefinition : AbstractDefinition
    {
        
        public DelegateDefinition(int line, int column, string name, FunctionType type) 
            : base(line, column, name, type)
        {
        }

        
        
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}