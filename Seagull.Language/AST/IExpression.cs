using Seagull.Language.AST.Statements.Definitions.Namespaces;

namespace Seagull.Language.AST
{
    public interface IExpression : IAstNode
    {
        IType Type { get; set; }
        bool LValue { get; set; }
    }
}