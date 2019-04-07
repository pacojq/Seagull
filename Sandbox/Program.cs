using System;
using Seagull;

namespace Sandbox
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string filename;
                Console.WriteLine("Type an input file (or 'q' to end execution):");
                
                SeagullCompiler compiler = new SeagullCompiler();
                
                // to type the EOF character and end the input: use CTRL+D, then press <enter>
                while ((filename = Console.ReadLine()) != "q")
                {
                    bool success = compiler.Compile(filename);
                    if (success)
                        Console.WriteLine("The file is correct!");
                    
                    Console.WriteLine("Type an input file (or 'q' to end execution):");
                }
                
            }
            catch (Exception ex)
            {                
                Console.WriteLine("Error: " + ex);                
            }
        }
    }
}