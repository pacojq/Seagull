
namespace Seagull.CodeGeneration
{
    public static class SeagullCodeGeneration
    {
        public static ICodeGenerator ForJava => new CgJava();
    }
}