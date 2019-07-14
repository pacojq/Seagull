using Seagull.AST;
using Seagull.AST.Types;
using Seagull.Visitor;

namespace Seagull.Errors
{
    public class ErrorType : AbstractType
    {
        
        public string Description { get; private set; }
        
        public ErrorType(int line, int column, string description) : base(line, column)
        {
            Description = description;
        }
	

        
        public override string ToString()
        {
            return $"ERROR | {GetDetails()}";
        }
        
        public string GetDetails()
        {
            return $"Line {Line}:{Column}\t{Description}";
        }
        
        
        protected override IType DefaultOperation(string description)
        {
            return this;
        }
        
        public override TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}