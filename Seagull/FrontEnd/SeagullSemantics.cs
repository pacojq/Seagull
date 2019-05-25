using Seagull.AST;
using Seagull.Semantics;
using Seagull.Semantics.Loops;
using Seagull.Semantics.Recognition;
using Seagull.Semantics.Symbols;
using Seagull.Semantics.TypeChecking;

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
            ast.Accept(new NamespaceVisitor(), null);
            
            // Find declarations and variables, and bind them together
            ast.Accept(new DefinitionSeekVisitor(_sm), null);
            ast.Accept(new DependencyVisitor(_sm), null);
            ast.Accept(new RecognitionVisitor(_sm), null);
            
            // TODO return visitor: check all branches return
            
            // Loop visitor: check break/continue statements
            ast.Accept(new LoopVisitor(), null);
            
            // Check types
            ast.Accept(new TypeCheckingVisitor(_sm), null);
            
            // TODO Find expressions that are L-Value
            //ast.Accept(new LValueVisitor(), null);
        }

        
    }
}