using System;
using Seagull.CodeGeneration;

namespace Seagull
{
    public class Compiler
    {
        public int CompileProject(string project)
        {
            // TODO

            return 0;
        }
        
        public int CompileFile(string inputFile, string outputFile)
        {
            FrontEndCompiler frontEnd = new FrontEndCompiler();
		    
            AST.ProgramNode program = frontEnd.Compile(inputFile);
            if (program == null)
                return -1;
            
            Console.WriteLine("The file is correct!");
		    
            // Stop here if the output is null
            if (outputFile == null)
                return 0;
            
            Console.WriteLine("Generating code...");

            // TODO let the user switch target
            SeagullCodeGeneration.ForWindows.Generate(program, inputFile, outputFile);
               
            Console.WriteLine("Code generated!");

            return 0;
        }
    }
}