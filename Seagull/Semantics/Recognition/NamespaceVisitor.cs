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
    /// The goal of this visitor is to assign a parent namespace to all the definitions
    /// </summary>
    public class NamespaceVisitor : AbstractVisitor<Void, INamespaceDefinition>
    {
        
        public override Void Visit(Program program, INamespaceDefinition p)
        {
            base.Visit(program, NamespaceManager.DefaultNamespace);
            return null;
        }
        
        
        public override Void Visit(NamespaceDefinition namespaceDefinition, INamespaceDefinition p)
        {
            base.Visit(namespaceDefinition, namespaceDefinition);
            return null;
        }


        public override Void Visit(StructDefinition structDefinition, INamespaceDefinition p)
        {
            base.Visit(structDefinition, structDefinition);
            structDefinition.Namespace = p;
            
            if (p.Type == null)
                Logger.Instance.LogError("Oh no");
            
            ((INamespaceType)p.Type).AddDefinition(structDefinition);
            return null;
        }
        
        public override Void Visit(FunctionDefinition functionDefinition, INamespaceDefinition p)
        {
            base.Visit(functionDefinition, p);
            functionDefinition.Namespace = p;
            ((INamespaceType)p.Type).AddDefinition(functionDefinition);
            return null;
        }

        public override Void Visit(VariableDefinition variableDefinition, INamespaceDefinition p)
        {
            base.Visit(variableDefinition, p);
            variableDefinition.Namespace = p;
            ((INamespaceType)p.Type).AddDefinition(variableDefinition);
            return null;
        }

        public override Void Visit(EnumDefinition enumDefinition, INamespaceDefinition p)
        {
            base.Visit(enumDefinition, p);
            enumDefinition.Namespace = p;
            ((INamespaceType)p.Type).AddDefinition(enumDefinition);
            return null;
        }

        public override Void Visit(DelegateDefinition delegateDefinition, INamespaceDefinition p)
        {
            base.Visit(delegateDefinition, p);
            delegateDefinition.Namespace = p;
            ((INamespaceType)p.Type).AddDefinition(delegateDefinition);
            return null;
        }
    }
}