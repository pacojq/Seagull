using System;
using System.Collections.Generic;
using System.Linq;
using Seagull.AST.Statements.Definitions;
using Seagull.Visitor;

namespace Seagull.AST
{
    public class ProgramNode : IAstNode
    {
        public int Line { get; private set; }
        public int Column { get; private set; }


        // Code generation
        public string CgCode { get; set; }

        
        
        
        public IDefinition MainFunction => _definitions.Find(def => def.Name.Equals("main") && def is FunctionDefinition);
        
        
        
        /// <summary>
        /// Imported files
        /// </summary>
        private readonly List<string> _links;
        public IEnumerable<string> Links => _links;
        
        
        /// <summary>
        /// Imported namespaces
        /// </summary>
        private readonly List<string> _imports;
        public IEnumerable<string> Imports => _imports;
        
        
        
        
        public IEnumerable<IDefinition> Definitions => _definitions;
        private readonly List<IDefinition> _definitions;
        
        
        public IEnumerable<NamespaceNode> Namespaces => _namespaces;
        private readonly List<NamespaceNode> _namespaces;

        
        
        


        public ProgramNode(int line, int column, IEnumerable<string> links, IEnumerable<string> imports, 
                IEnumerable<IDefinition> definitions, IEnumerable<NamespaceNode> namespaces)
        {
            Line = line;
            Column = column;
            _links = new List<string>();
            _imports = new List<string>();
            _definitions = new List<IDefinition>();
            _namespaces = new List<NamespaceNode>();
            
            _links.AddRange(links);
            _imports.AddRange(imports);
            
            AddDefinitions(definitions);
            AddNamespaces(namespaces);
        }
	
        
        
        public void AddDefinitions(IEnumerable<IDefinition> definitions)
        {
            foreach (var def in definitions)
            {
                if (def == null)
                    throw new Exception("Cannot add null definitions to a ProgramNode.");
                //_definitions.Insert(0, def);
                _definitions.Add(def);
            }
        }
        
        public void AddNamespaces(IEnumerable<NamespaceNode> namespaces)
        {
            foreach (var ns in namespaces)
            {
                if (ns == null)
                    throw new Exception("Cannot add null namespace to a ProgramNode.");
                //_definitions.Insert(0, ns);
                _namespaces.Add(ns);
            }
        }
        
        
        public TR Accept<TR, TP>(IVisitor<TR, TP> visitor, TP p)
        {
            return visitor.Visit(this, p);
        }
    }
}