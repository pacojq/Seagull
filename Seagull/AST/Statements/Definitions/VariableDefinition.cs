namespace Seagull.AST.Statements.Definitions
{
    public class VariableDefinition : AbstractDefinition
    {
        
        public VariableDefinition(int line, int column, string name, IType type) 
            : base(line, column, name, type)
        {
        }
        
    }
}