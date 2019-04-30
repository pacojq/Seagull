using System;

namespace Seagull.VM
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string filename = args[0];
		    
            FrontEndCompiler compiler = new FrontEndCompiler();
		    
            Seagull.AST.Program program = compiler.Compile(filename);
            if (program == null)
            {
                Console.WriteLine("Please, solve compile errors to execute the file.");
                return;
            }

            SVM svm = new SVM();
            svm.Run(program);
        }
    }
}