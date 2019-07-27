using Seagull.AST;
using Seagull.Semantics.Loops;
using Seagull.Semantics.Recognition;
using Seagull.Semantics.TypeChecking;
using Seagull.SymTable;

namespace Seagull.FrontEnd
{
    internal class SeagullSemantics
    {
        
        
        public void Analyze(ProgramNode ast)
        {
            // Sets up namespaces
            SymbolTable.Init();
            ast.Accept(new ScopeRecognitionVisitor(), null);
            ast.Accept(new SymbolDefinitionVisitor(), null);
            ast.Accept(new DependencyRecognitionVisitor(), null);
            ast.Accept(new VariableRecognitionVisitor(), null);
            
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