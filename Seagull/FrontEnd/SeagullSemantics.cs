using Seagull.AST;
using Seagull.Semantics;
using Seagull.Semantics.Symbols;

namespace Seagull.FrontEnd
{
    internal class SeagullSemantics
    {
        private SymbolManager _sm;
        
        public void SetUp()
        {
            _sm = SymbolManager.Instance;
        }
        
        
        
        public void Analyze(Program ast)
        {
            // Find declarations and variables, and bind them together
            ast.Accept(new DefinitionSeekVisitor(_sm), null);
            ast.Accept(new DependencyVisitor(_sm), null);
            ast.Accept(new RecognitionVisitor(_sm), null);
            
            // TODO return visitor: check all branches return
            
            // Check types
            ast.Accept(new TypeCheckingVisitor(_sm), null);
            
            // TODO Find expressions that are L-Value
            //ast.Accept(new LValueVisitor(), null);
        }

        
    }
}