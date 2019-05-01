using System.Collections.Generic;
using Seagull.AST;
using Seagull.AST.Statements.Definitions;
using Seagull.AST.Types;

namespace Seagull.Semantics.Symbols
{
    public class SymbolManager
    {
        
        private static SymbolManager _instance;
        public static SymbolManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SymbolManager();
                return _instance;
            }
        }


        private SymbolTable CurrentSymbolTable => _symbolTables[_currentNamespace];
        
        /// <summary>
        /// Here we store the SymbolTable for each Namespace
        /// </summary>
        private readonly Dictionary<string, SymbolTable> _symbolTables;

        
        private string _currentNamespace;
        




        private SymbolManager()
        {
            _symbolTables = new Dictionary<string, SymbolTable>();
            _currentNamespace = "";
            _symbolTables.Add("", new SymbolTable());
        }
        
        
        
        


        public void Set()
        {
            CurrentSymbolTable.Set();
        }
        
        public void Set()
        {
            CurrentSymbolTable.Set();
        }
        
        public bool Insert(IDefinition definition)
        {
            return CurrentSymbolTable.Insert(definition);
        }
    }
}