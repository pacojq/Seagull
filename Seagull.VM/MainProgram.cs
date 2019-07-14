using System;
using Seagull.AST;

namespace Seagull.VM
{
    internal class MainProgram
    {
        public static void Main(string[] args)
        {
            string filename = args[0];
		    
            FrontEndCompiler compiler = new FrontEndCompiler();
		    
            Program program = compiler.Compile(filename);
            if (program == null)
            {
                Console.WriteLine("Please, solve compile errors to execute the file.");
                return;
            }

            SVM svm = new SVM();
            // TODO
            //svm.Run(program);
        }
    }
}