using Seagull.CodeGeneration.Mapl;

namespace Seagull.CodeGeneration
{
    public static class SeagullCodeGeneration
    {
        public static ICodeGenerator ForMapl => new CgMapl();
    }
}