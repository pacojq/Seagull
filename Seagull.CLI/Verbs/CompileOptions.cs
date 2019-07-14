using CommandLine;

namespace Seagull.CLI.Verbs
{
    [Verb("compile", HelpText = "Compile a Seagull file or project.")]
    public class CompileOptions
    {
        [Option('i', "input", Required = true, HelpText = "Input file to be processed.")]
        public string InputFile { get; set; }
		
        [Option('o', "output", Required = false, HelpText = "Output file with the compiled code.")]
        public string OutputFile { get; set; }
		

        // Omitting long name, defaults to name of property, ie "--verbose"
        [Option(
            Default = false,
            HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }
    }
}