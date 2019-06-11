using Seagull.Language.AST;
using Seagull.VM.Visitors;

namespace Seagull.VM
{
    public class SVM
    {

        private readonly Memory _memory;

        public SVM()
        {
            // TODO variable memory?
            _memory = new Memory(1024);
        }
        
        
        
        public void Run(Program program)
        {
            program.Accept(new NumberOfBytesVisitor(), null);
            program.Accept(new OffsetVisitor(), null);

            SeagullVMAction execute = program.Accept(new ExecuteVisitor(_memory), null);

            execute();
        }
        
    }
}