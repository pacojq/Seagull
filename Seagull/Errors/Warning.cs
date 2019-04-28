namespace Seagull.Errors
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
            return $"WARNING | line {Line}:{Column}\t{Description}";
        }
    }
}