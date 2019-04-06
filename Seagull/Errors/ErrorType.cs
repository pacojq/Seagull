using Seagull.AST;
using Seagull.AST.Types;

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
            return $"ERROR | line {Line}:{Column}\t{Description}";
        }
    }
}