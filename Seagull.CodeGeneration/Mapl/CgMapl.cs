using System.IO;
using System.Text;
using Seagull.AST;

namespace Seagull.CodeGeneration.Mapl
{
    public class CgMapl : ICodeGenerationModule
    {
        public string Generate(Program program, string inputPath, string outputPath)
        {
            program.Accept(new OffsetVisitor(), null);
            program.Accept(new MaplTypesVisitor(), null);
            program.Accept(new ExecuteVisitor(), null);

            string filename = Path.GetFileName(inputPath);
            StringBuilder str = new StringBuilder();
            
            str.Append($"#source \"{filename}\"\n");
            str.Append(program.CgCode);
            
            return str.ToString();
        }
    }
}