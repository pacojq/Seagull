using Seagull.Language.AST.Types.Namespaces;
using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Types
{
    public class UnknownType : AbstractType
    {
        
        public string Name { get; }
        public INamespaceType Namespace { get; }
        
        public UnknownType(int line, int column, string name, INamespaceType ns = null) : base(line, column)
        {
            Name = name;
            Namespace = ns;
        }

        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }

        public override int CgNumberOfBytes => 0;
    }
}