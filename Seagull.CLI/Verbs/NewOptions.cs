using CommandLine;

namespace Seagull.CLI.Verbs
{
    [Verb("new", HelpText = "Create a Seagull project.")]
    public class NewOptions
    {
        [Value(0, 
            HelpText = "The name of the new project.", MetaName = "name", 
            Required = true )]
        public string Name { get; set; }
    }
}