using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Statements
{
    public abstract class AbstractStatement : AbstractAstNode, IStatement
    {
        public string CgExecute { get; set; }
        
        
        public AbstractStatement(int line, int column) : base(line, column)
        {
            CgExecute = "CG-EXECUTE-PLACEHOLDER";
        }
        
    }
}