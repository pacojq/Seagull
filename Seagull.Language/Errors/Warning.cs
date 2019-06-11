namespace Seagull.Language.Errors
{
    public class Warning
    {
        
        public int Line { get; }
        public int Column { get; }
        public string Description { get; }
        
        
        public Warning(int line, int column, string description)
        {
            Line = line;
            Column = column;
            Description = description;
        }
        
        public override string ToString()
        {
            return $"WARNING | {GetDetails()}";
        }
        
        public string GetDetails()
        {
            return $"Line {Line}:{Column}\t{Description}";
        }
    }
}