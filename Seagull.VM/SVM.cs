namespace Seagull.VM
{
    public class SVM
    {

        private Interpreter _interpreter;

        public SVM()
        {
            _interpreter = new Interpreter();
        }
        
        
        
        public void Run(AST.Program program)
        {
            _interpreter.SetUp();
            program.Accept(_interpreter, null);
        }
        
    }
}