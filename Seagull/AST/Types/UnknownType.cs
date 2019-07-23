using Seagull.Visitor;

namespace Seagull.AST.Types
{
    
    /// <summary>
    /// The UnknownType represents a named type which has not been declared.
    /// After the recognition phase has been executed, there should be no Unknown
    /// Type in the AST.
    /// </summary>
    public class UnknownType : AbstractType
    {
        
        public string Name { get; }
        
        public NamespaceType Namespace { get; } // TODO find it
        
        public UnknownType(int line, int column, string name, NamespaceType ns = null) : base(line, column)
        {
            Name = name;
            Namespace = ns;
        }

        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }

    }
}