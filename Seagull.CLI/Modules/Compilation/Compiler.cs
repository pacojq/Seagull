using System;
using System.IO;
using Seagull.CLI.Verbs;
using Seagull.CodeGeneration;

namespace Seagull.CLI.Modules.Compilation
{
    public class Compiler
    {
        public static void Run(CompileOptions options)
        {
            FrontEndCompiler frontEnd = new FrontEndCompiler();
		    
            AST.Program program = frontEnd.Compile(options.InputFile);
            if (program == null)
                return;
            
            Console.WriteLine("The file is correct!");
		    
            // Stop here if the output is null
            if (options.OutputFile == null)
                return;
            
            Console.WriteLine("Generating code...");

            // TODO let the user switch target
            string output = SeagullCodeGeneration.ForMapl.Generate(program, options.InputFile, options.OutputFile);
            Console.WriteLine("Output file: {0}", output);

            using (StreamWriter w = new StreamWriter(options.OutputFile))
            {
                w.Write(output);
            }
        }
    }
}