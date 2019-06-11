using Seagull.Language.AST.Types.Namespaces;
using Seagull.Language.Visitor;

namespace Seagull.Language.AST.Types
{
    
    /// <summary>
    /// The UnknownType represents a named type which has not been declared.
    /// After the recognition phase has been executed, there should be no Unknown
    /// Type in the AST.
    /// </summary>
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