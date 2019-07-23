using Seagull.SymTable.Symbols;
using Seagull.SymTable.SymbolsWithScope;
using Seagull.Visitor;

namespace Seagull.AST.Statements.Definitions
{
    public class StructDefinition : AbstractDefinition
    {
        
        public StructSymbol Symbol { get; set; }
        
        
        public StructDefinition(int line, int column, string name, IType type) : base(line, column, name, type)
        {
            
        }

        
        public override string ToString()
        {
            // TODO Maybe add full name with symbol table
            return "struct " + Name;
        }

        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}