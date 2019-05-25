using Seagull.AST.Statements.Definitions.Namespaces;

namespace Seagull.AST
{
    public interface IExpression : IAstNode
    {
        IType Type { get; set; }
        bool LValue { get; set; }
    }
}