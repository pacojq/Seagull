using Seagull.AST;
using Seagull.AST.Statements.Definitions;
using Seagull.AST.Statements.Definitions.Namespaces;
using Seagull.AST.Types.Namespaces;
using Seagull.Logging;
using Seagull.Semantics.Symbols;
using Seagull.Visitor;

namespace Seagull.Semantics.Recognition
{
    /// <summary>
    /// The First Pass only deals with INamespaceDefinitions, adding them
    /// to the SymbolManager every time we find one.
    /// </summary>
    public class RecognitionFirstPassVisitor : AbstractRecognitionVisitor<Void>
    {

        private readonly SymbolManager _sm = SymbolManager.Instance;
     
        public RecognitionFirstPassVisitor() : base("FIRST PASS", "Find namespaces")
        {
        }
        
        
        
        public override Void Visit(NamespaceDefinition namespaceDefinition, INamespaceDefinition p)
        {
            _sm.Insert(namespaceDefinition, p);
            _sm.AddNamespace(namespaceDefinition);
            
            base.Visit(namespaceDefinition, namespaceDefinition);
            return null;
        }


        public override Void Visit(StructDefinition structDefinition, INamespaceDefinition p)
        {
            _sm.Insert(structDefinition, p);
            _sm.AddNamespace(structDefinition);
            
            base.Visit(structDefinition, structDefinition);
            return null;
        }
        
        
        

        public override Void Visit(EnumDefinition enumDefinition, INamespaceDefinition p)
        {
            // TODO
            base.Visit(enumDefinition, p);
            return null;
        }

    }
}