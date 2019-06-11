using Seagull.CodeGeneration.Mapl;

namespace Seagull.CodeGeneration
{
    public static class SeagullCodeGeneration
    {
        public static ICodeGenerationModule ForMapl => new CgMapl();
    }
}