using Seagull.AST;
using Seagull.AST.Statements.Definitions;
using Seagull.Errors;
using Seagull.Logging;
using Seagull.SymTable;
using Seagull.SymTable.Scopes;
using Seagull.SymTable.SymbolsWithScope;
using Seagull.Visitor;

namespace Seagull.Semantics.Recognition
{
    /// <summary>
    /// The First Pass only deals with definitions of <see cref="IScope"/>, adding them
    /// to the SymbolTable every time we find one.
    /// </summary>
    public class ScopeRecognitionVisitor : AbstractRecognitionVisitor<Void>
    {
        /*
         * We'll visit every node dealing with classes inheriting from IScope.
         * Children of SymbolWithScope will also be processed in this pass.
         */
        

        public ScopeRecognitionVisitor() : base("FIRST PASS", "Scope recognition")
        {
        }
        
        
        
        public override Void Visit(NamespaceNode namespaceNode, Void p)
        {
            int line = namespaceNode.Line;
            int col = namespaceNode.Column;
            
            IScope currentScope = SymbolTable.Instance.CurrentScope;
            foreach (var parent in namespaceNode.Parents)
                currentScope = EnterOrDefineNamespace(line, col, parent, currentScope);
            
            namespaceNode.Scope = EnterOrDefineNamespace(line, col, namespaceNode.Name, currentScope);
            
            base.Visit(namespaceNode, p);
            return null;
        }

        private NamespaceScope EnterOrDefineNamespace(int line, int col, string name, IScope currentScope)
        {
            IScope scope = currentScope.GetNestedScope(name);
            if (scope == null)
            {
                NamespaceScope newScope = new NamespaceScope(name, currentScope);
                SymbolTable.Instance.Nest(newScope);
                return newScope;
            }
            else if (scope is NamespaceScope)
            {
                return (NamespaceScope) scope;
            }
            
            ErrorHandler.Instance.RaiseError(line, col,
                $"Incompatible namespace name. The symbol {name} already exists in the parent namespace.");
            return new NamespaceScope(name, SymbolTable.Instance.CurrentScope);
        }
        
        
        


        public override Void Visit(StructDefinition structDefinition, Void p)
        {
            string name = structDefinition.Name;
            
            IScope scope = SymbolTable.Instance.CurrentScope.GetNestedScope(name);
            if (scope == null)
            {
                StructSymbol structSymbol = new StructSymbol(name, SymbolTable.Instance.CurrentScope);
                structSymbol.Definition = structDefinition;
                structDefinition.Symbol = structSymbol;
                
                SymbolTable.Instance.Define(structSymbol);
            }
            else if (scope is StructSymbol)
            {
                ErrorHandler.Instance.RaiseError(
                    structDefinition.Line, 
                    structDefinition.Column,
                    $"Trying to declare an already existent struct: {name}");
                
                structDefinition.Symbol = (StructSymbol) scope;
            }
            else
            {
                ErrorHandler.Instance.RaiseError(structDefinition.Line, structDefinition.Column,
                    $"The symbol {name} already exists in the parent namespace.");
                structDefinition.Symbol = new StructSymbol(name, SymbolTable.Instance.CurrentScope);
            }
            
            base.Visit(structDefinition, p);
            return null;
        }
        
        
        public override Void Visit(FunctionDefinition functionDefinition, Void p)
        {
            string name = functionDefinition.Name;
            
            IScope scope = SymbolTable.Instance.CurrentScope.GetNestedScope(name);
            if (scope == null)
            {
                FunctionSymbol functionSymbol = new FunctionSymbol(name, SymbolTable.Instance.CurrentScope);
                functionSymbol.Definition = functionDefinition;
                functionDefinition.Symbol = functionSymbol;
                
                SymbolTable.Instance.Define(functionDefinition.Symbol);
            }
            else if (scope is FunctionSymbol)
            {
                functionDefinition.Symbol = (FunctionSymbol) scope;
            }
            else
            {
                ErrorHandler.Instance.RaiseError(functionDefinition.Line, functionDefinition.Column,
                    $"The symbol {name} already exists in the parent namespace.");
                functionDefinition.Symbol = new FunctionSymbol(name, SymbolTable.Instance.CurrentScope);
            }
            
            base.Visit(functionDefinition, p);
            return null;
        }
        
        
        

        public override Void Visit(EnumDefinition enumDefinition, Void p)
        {
            // TODO
            base.Visit(enumDefinition, p);
            return null;
        }

    }
}