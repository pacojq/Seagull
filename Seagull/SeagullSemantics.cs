using Seagull.AST;
using Seagull.Semantics;
using Seagull.Semantics.Symbols;

namespace Seagull
{
    internal class SeagullSemantics
    {

        // We'll want to keep this symbol table alive if we pass more than one file
        // Meybe when we add namespaces we'll have a Dictionary<string, SymbolTable>
        private SymbolTable _symbolTable;
        
        
        public void SetUp()
        {
            SymbolTable.Instance.Initialize();
            DependencyManager.Instance.Initialize();
            
            _symbolTable = SymbolTable.Instance;
        }
        
        
        
        public void Analyze(Program ast)
        {
            // First find declarations. Then find variables and bind them together.
            ast.Accept(new DeclarationVisitor(_symbolTable), null);
            DependencyManager.Instance.SolveDependencies(); // Solve dependencies first
            ast.Accept(new RecognitionVisitor(_symbolTable), null);
            
            // TODO return visitor: check all branches return
            
            // Check types
            ast.Accept(new TypeCheckingVisitor(), null);
            
            // TODO Find expressions that are L-Value
            //ast.Accept(new LValueVisitor(), null);
        }

        
    }
}