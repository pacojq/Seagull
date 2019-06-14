using Seagull.VM.Commands;
using Seagull.VM.Parser;

namespace Seagull.VM
{
    public class SVM
    {
        private CommandGenerator _generator;
        private readonly Memory _memory;

        public SVM()
        {
            // TODO variable memory?
            _memory = new Memory(1024);
            _generator = new CommandGenerator();
        }
        
        
        
        public void Run(SeagullVMProgram program)
        {
            // TODO
        }
        
    }
}