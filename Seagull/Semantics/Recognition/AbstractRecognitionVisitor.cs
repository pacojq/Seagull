using Seagull.AST;
using Seagull.AST.Statements.Definitions;
using Seagull.Logging;
using Seagull.SymTable;
using Seagull.Visitor;

namespace Seagull.Semantics.Recognition
{
    public class AbstractRecognitionVisitor<T> : AbstractVisitor<T, Void>
    {

        private readonly string _name;
        private readonly string _description;

        public AbstractRecognitionVisitor(string name, string description)
        {
            _name = name;
            _description = description;
        }
        
        public override T Visit(Program program, Void p)
        {
            Logger.Instance.LogWarning("Symbol recognition stage: {0} | {1}.", _name, _description);
            base.Visit(program, p);
            return default(T);
        }
        
        
        
        // ====================================== SCOPES ====================================== //
        
        public override T Visit(NamespaceDefinition namespaceDefinition, Void p)
        {
            SymbolTable.Instance.Set(namespaceDefinition.Scope);
            
            base.Visit(namespaceDefinition, p);
            
            SymbolTable.Instance.Reset();
            
            return default(T);
        }

        public override T Visit(StructDefinition structDefinition, Void p)
        {
            SymbolTable.Instance.Set(structDefinition.Symbol);
            
            base.Visit(structDefinition, p);
            
            SymbolTable.Instance.Reset();
            
            return default(T);
        }
        
        public override T Visit(FunctionDefinition functionDefinition, Void p)
        {
            SymbolTable.Instance.Set(functionDefinition.Symbol);
            
            base.Visit(functionDefinition, p);
            
            SymbolTable.Instance.Reset();
            
            return default(T);
        }
        
        public override T Visit(EnumDefinition enumDefinition, Void p)
        {
            // TODO make enum a namespace ?
            base.Visit(enumDefinition, p);
            return default(T);
        }
        
        
    }
}