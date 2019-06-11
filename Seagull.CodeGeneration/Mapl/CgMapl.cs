using System.IO;
using Seagull.Language.AST;

namespace Seagull.CodeGeneration.Mapl
{
    public class CgMapl : ICodeGenerator
    {
        public string Generate(Program program, string outputPath)
        {
            program.Accept(new MaplTypesVisitor(), null);
            program.Accept(new OffsetVisitor(), null);
            program.Accept(new ExecuteVisitor(), null);

            // TODO input path
            
            return program.CgCode;
        }
    }
}