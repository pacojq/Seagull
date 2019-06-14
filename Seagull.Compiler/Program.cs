using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using CommandLine;
using Seagull.CodeGeneration;
using Seagull.Language;

namespace Seagull.Compiler
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<Options>(args)
                .WithParsed(RunCompiler)
                .WithNotParsed(HandleParseError);
        }

        
        
        
        private static void RunCompiler(Options options)
        {
            FrontEndCompiler frontEnd = new FrontEndCompiler();
		    
            Language.AST.Program program = frontEnd.Compile(options.InputFile);
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

        private static void HandleParseError(IEnumerable<Error> errors)
        {
            foreach (var error in errors)
            {
                Console.WriteLine(error);
            }
        }
    }
}