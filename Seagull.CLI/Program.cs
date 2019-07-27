using System;
using System.Collections.Generic;
using CommandLine;
using Seagull.CLI.Verbs;

namespace Seagull.CLI
{
    internal static class Program
    {
        public static int Main(string[] args)
        {
            return CommandLine.Parser.Default
                .ParseArguments<CompileOptions, NewOptions, int>(args)
                .MapResult(
                    (CompileOptions opts) => RunCompiler(opts),
                    (NewOptions opts) => RunNew(opts),
                    errs => 1
                    );
        }

        
        
        
        private static int RunCompiler(CompileOptions options)
        {
            Compiler compiler = new Compiler();
            compiler.CompileFile(options.InputFile, options.OutputFile);
            return 0;
        }
        
        private static int RunNew(NewOptions options)
        {
            
            return 0;
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