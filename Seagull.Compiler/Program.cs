﻿using System;
using Seagull.CodeGeneration;

namespace Seagull.Compiler
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            string filename = args[0];
		    
            SeagullCompiler compiler = new SeagullCompiler();
		    
            Seagull.AST.Program program = compiler.Compile(filename);
            if (program == null)
                return;
		    
            Console.WriteLine("The file is correct! Generating code...");
            // TODO let the user switch target
            string output = SeagullCodeGeneration.ForJava.Generate(program, args[1]);
            Console.WriteLine("Output file: {0}", output);
        }
    }
}