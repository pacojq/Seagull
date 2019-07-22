using System;
using System.IO;
using System.Text;
using Seagull.AST;

namespace Seagull.CodeGeneration.Mapl
{
    public class CgMapl : ICodeGenerationModule
    {
        public void Generate(Program program, string inputPath, string outputPath)
        {
            program.Accept(new OffsetVisitor(), null);
            program.Accept(new MaplTypesVisitor(), null);
            program.Accept(new ExecuteVisitor(), null);

            string filename = Path.GetFileName(inputPath);
            StringBuilder str = new StringBuilder();
            
            str.Append($"#source \"{filename}\"\n");
            str.Append(program.CgCode);
            
            string result = str.ToString();
            
            Console.WriteLine("Output file: {0}", result);

            using (StreamWriter w = new StreamWriter(outputPath))
            {
                w.Write(result);
            }
        }
    }
}