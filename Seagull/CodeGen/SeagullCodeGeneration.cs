using Seagull.CodeGeneration.Mapl;
using Seagull.CodeGeneration.Windows;

namespace Seagull.CodeGeneration
{
    public static class SeagullCodeGeneration
    {
        public static ICodeGenerationModule ForMapl => new CgMapl();
        
        public static ICodeGenerationModule ForWindows => new CgWindows();
    }
}