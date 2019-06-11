using Seagull.Language.AST;

namespace Seagull.VM
{
    public class SVM
    {

        private readonly Interpreter _interpreter;

        public SVM()
        {
            _interpreter = new Interpreter();
        }
        
        
        
        public void Run(Program program)
        {
            _interpreter.SetUp();
            program.Accept(new OffsetVisitor(), null);
            program.Accept(_interpreter, null);
        }
        
    }
}