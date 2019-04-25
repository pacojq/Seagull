using Seagull.AST;
using Seagull.Semantics;

namespace Seagull
{
    internal class SeagullSemantics
    {

        // We'll want to keep this symbol table alive if we pass more than one file
        // Meybe when we add namespaces we'll have a Dictionary<string, SymbolTable>
        private SymbolTable _symbolTable;
        
        
        public void SetUp()
        {
            _symbolTable = new SymbolTable();
        }
        
        
        
        public void Analyze(Program ast)
        {
            // First find declarations. Then find variables and bind them together.
            ast.Accept(new DeclarationVisitor(_symbolTable), null);
            ast.Accept(new RecognitionVisitor(_symbolTable), null);
            
            // TODO return visitor: check all branches return
            
            // TODO Check types
            //ast.Accept(new TypeCheckingVisitor(), null);
            
            // TODO Find expressions that are L-Value
            //ast.Accept(new LValueVisitor(), null);
        }

        
    }
}