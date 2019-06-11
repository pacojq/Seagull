using Seagull.Language.AST;

namespace Seagull.CodeGeneration
{
    public interface ICodeGenerationModule
    {
        /// <summary>
        /// Generates the code for a given program and returns  the path to the new file
        /// </summary>
        /// <param name="program"></param>
        /// <param name="outputPath"></param>
        /// <returns></returns>
        string Generate(Program program, string outputPath);
    }
}