using Seagull.AST;
using Seagull.AST.Types;
using Seagull.Visitor;

namespace Seagull.Errors
{
    public class ErrorType : AbstractType
    {

        public override int NumberOfBytes => 0;
        
        public string Description { get; private set; }
        
        public ErrorType(int line, int column, string description) : base(line, column)
        {
            Description = description;
        }
	

        public override string ToString()
        {
            return $"ERROR | line {Line}:{Column}\t{Description}";
        }
        
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}