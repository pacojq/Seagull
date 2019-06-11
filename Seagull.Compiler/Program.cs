using System;
using System.IO;
using Seagull.CodeGeneration;
using Seagull.Language;

namespace Seagull.Compiler
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            string inputFile = args[0];
            string outputFile = args[1];
		    
            
            FrontEndCompiler compiler = new FrontEndCompiler();
		    
            Language.AST.Program program = compiler.Compile(inputFile);
            if (program == null)
                return;
		    
            Console.WriteLine("The file is correct! Generating code...");
            
            // TODO let the user switch target
            string output = SeagullCodeGeneration.ForMapl.Generate(program, inputFile, outputFile);
            Console.WriteLine("Output file: {0}", output);

            using (StreamWriter w = new StreamWriter(outputFile))
            {
                w.Write(output);
            }
        }
    }
}