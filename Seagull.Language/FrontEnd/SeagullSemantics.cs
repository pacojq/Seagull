using Seagull.Language.AST;
using Seagull.Language.Semantics.Loops;
using Seagull.Language.Semantics.Recognition;
using Seagull.Language.Semantics.Symbols;
using Seagull.Language.Semantics.TypeChecking;
using Seagull.Language.Semantics;

namespace Seagull.Language.FrontEnd
{
    internal class SeagullSemantics
    {
        
        
        public void Analyze(Program ast)
        {
            // Sets up namespaces
            SymbolManager.Instance.Init();
            ast.Accept(new RecognitionFirstPassVisitor(), null);
            ast.Accept(new RecognitionSecondPassVisitor(), null);
            ast.Accept(new RecognitionThirdPassVisitor(), null);
            ast.Accept(new RecognitionFourthPassVisitor(), null);
            
            // TODO return visitor: check all branches return
            
            // Loop visitor: check break/continue statements
            ast.Accept(new LoopVisitor(), null);
            
            // Check types
            ast.Accept(new TypeCheckingVisitor(), null);
            
            // TODO Find expressions that are L-Value
            //ast.Accept(new LValueVisitor(), null);
        }

        
    }
}