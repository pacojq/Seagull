using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using Seagull.AST;

namespace Seagull.CodeGeneration.Windows
{
    public class CgWindows : ICodeGenerationModule
    {
        private string _outputPath;
        private string _programName;
        private string _fullName;
        
        private AssemblyName _assemblyName;
        private AssemblyBuilder _assemblyBuilder;
        private ModuleBuilder _moduleBuilder;
        
        public void Generate(Program program, string inputPath, string outputPath)
        {
            _programName = Path.GetFileNameWithoutExtension(outputPath);
            
            // Generate assembly
            _assemblyName = new AssemblyName();
            _assemblyName.Name = _programName;
            _assemblyName.ProcessorArchitecture = ProcessorArchitecture.X86; // TODO change in the future
            
            _assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(_assemblyName, AssemblyBuilderAccess.Save);
            _moduleBuilder = _assemblyBuilder.DefineDynamicModule(_programName + ".mod", _programName + ".exe", false);

            
            //TODO all the stuff
            
            // Define classes
            //program.Accept(new ClassDefinitionVisitor(), null);
            
            
            
            // For now, let's create a dummy Hello World
            
            // Dummy class
            TypeBuilder typeBuilder = _moduleBuilder.DefineType("Class1");
            
            // Main method
            MethodBuilder methodBuilder = typeBuilder.DefineMethod("Main",
                MethodAttributes.Private | MethodAttributes.Static | MethodAttributes.HideBySig,
                CallingConventions.Standard, typeof(void),
                new Type[]{typeof(string[])});
            
            _assemblyBuilder.SetEntryPoint(methodBuilder);
            
            // Write the lines of code
            HelloWorld(methodBuilder);
            
            // Create the type
            typeBuilder.CreateType();
            
            // Save the assembly
            Console.WriteLine("Generating " + Path.GetFullPath(_programName) + ".exe");
            _assemblyBuilder.Save(_programName + ".exe");
        }
        
        private void HelloWorld(MethodBuilder builder)
        {
            ILGenerator generator = builder.GetILGenerator();
            generator.Emit(OpCodes.Ldstr, "Hello world");

            MethodInfo methodInfo = typeof(System.Console).GetMethod(
                "WriteLine",
                BindingFlags.Public | BindingFlags.Static, null,
                new Type[]{typeof(string)}, null);

            generator.Emit(OpCodes.Call, methodInfo);
            generator.Emit(OpCodes.Ret);
        }
        
       
    }
}