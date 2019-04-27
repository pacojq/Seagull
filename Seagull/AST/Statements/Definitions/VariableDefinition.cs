using Seagull.Visitor;

namespace Seagull.AST.Statements.Definitions
{
    public class VariableDefinition : AbstractDefinition
    {
        
        public IExpression Initialization { get; }
        
        public VariableDefinition(int line, int column, string name, IType type, IExpression initialization) 
            : base(line, column, name, type)
        {
            Initialization = initialization;
        }



        public override string ToString()
        {
            return $"{Name} : {Type}";
        }
        
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
        
    }
}