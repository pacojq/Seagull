namespace Seagull.AST.Statements
{
    public class AbstractDefinition : AbstractStatement, IDefinition
    {
        
        public string Name { get; }
        
        public IType Type { get; }
        
        public int Scope { get; set; }
        
        
        
        public AbstractDefinition(int line, int column, string name, IType type) : base(line, column)
        {
            Name = name;
            Type = type;
        }
    }
}