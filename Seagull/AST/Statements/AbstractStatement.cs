namespace Seagull.AST.Statements
{
    public class AbstractStatement : AbstractAstNode, IStatement
    {
        
        public AbstractStatement(int line, int column) : base(line, column)
        {
        }
        
        
    }
}