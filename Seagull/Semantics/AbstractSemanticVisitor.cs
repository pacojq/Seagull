using Seagull.AST.Statements.Definitions;
using Seagull.AST.Statements.Definitions.Namespaces;
using Seagull.AST.Types;
using Seagull.Semantics.Symbols;
using Seagull.Visitor;

namespace Seagull.Semantics
{
    public abstract class AbstractSemanticVisitor<TR, TP> : AbstractVisitor<TR, TP>
    {
        protected readonly SymbolManager SymbolManager;
	
		
        public AbstractSemanticVisitor(SymbolManager manager)
        {
	        SymbolManager = manager;
        }
		
		
		
        public override TR Visit(NamespaceDefinition namespaceDefinition, TP p)
        {
	        SymbolManager.PushNamespace(namespaceDefinition);
            base.Visit(namespaceDefinition, p);
            SymbolManager.PopNamespace();
            
            return default(TR);
        }
		
		
        public override TR Visit(FunctionDefinition funcDefinition, TP p)
        {
	        //SymbolManager.PushNamespace(funcDefinition);
	        SymbolManager.Set();
            base.Visit(funcDefinition, p);
            SymbolManager.Reset();
            //SymbolManager.PopNamespace();
			
            return default(TR);
        }
		
		
        public override TR Visit(StructDefinition structDefinition, TP p)
        {
	        SymbolManager.PushNamespace(structDefinition);
            base.Visit(structDefinition, p);
            SymbolManager.PopNamespace();
			
            return default(TR);
        }
        
    }
}