using Seagull.Visitor;

namespace Seagull.AST.Statements
{
    public abstract class AbstractStatement : AbstractAstNode, IStatement
    {
        
        public AbstractStatement(int line, int column) : base(line, column)
        {
        }

    }
}