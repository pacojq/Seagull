using Seagull.AST;
using Seagull.AST.Statements.Definitions;
using Seagull.AST.Statements.Definitions.Namespaces;
using Seagull.Logging;
using Seagull.Semantics.Symbols;
using Seagull.Visitor;

namespace Seagull.Semantics.Recognition
{
    public class AbstractRecognitionVisitor<T> : AbstractVisitor<T, INamespaceDefinition>
    {

        private readonly string _name;
        private readonly string _description;

        public AbstractRecognitionVisitor(string name, string description)
        {
            _name = name;
            _description = description;
        }
        
        public override T Visit(Program program, INamespaceDefinition p)
        {
            Logger.Instance.LogWarning("Recognition stage. {0} | {1}.", _name, _description);
            base.Visit(program, NamespaceManager.DefaultNamespace);
            return default(T);
        }
        
        
        // ====================================== Namespaces ====================================== //
        
        public override T Visit(NamespaceDefinition namespaceDefinition, INamespaceDefinition p)
        {
            base.Visit(namespaceDefinition, namespaceDefinition);
            return default(T);
        }

        public override T Visit(StructDefinition structDefinition, INamespaceDefinition p)
        {
            base.Visit(structDefinition, structDefinition);
            return default(T);
        }
        
        public override T Visit(EnumDefinition enumDefinition, INamespaceDefinition p)
        {
            // TODO make enum a namespace ?
            base.Visit(enumDefinition, p);
            return default(T);
        }
        
        
    }
}