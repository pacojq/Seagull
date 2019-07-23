using Seagull.SymTable.Symbols;
using Seagull.Visitor;

namespace Seagull.AST.Statements.Definitions
{
    public class VariableDefinition : AbstractDefinition
    {
        
        public VariableSymbol Symbol { get; set; }
        
        
        public IExpression Initialization { get; }
        
        public VariableDefinition(int line, int column, string name, IType type, IExpression initialization) 
            : base(line, column, name, type) // TODO base access
        {
            Initialization = initialization;
        }



        public override string ToString()
        {
            return $"var {Name} : {Type}";
        }
        
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
        
    }
}