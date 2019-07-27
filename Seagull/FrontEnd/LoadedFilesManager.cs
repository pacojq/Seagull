using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Seagull.AST;
using Seagull.AST.Statements.Definitions;
using Seagull.Errors;

namespace Seagull.FrontEnd
{
    public class LoadedFilesManager : IDisposable
    {

        private int _taskCount = 0;
        public bool Ready => _taskCount == 0;

        private FrontEndCompiler _compiler;
        
        private readonly string _mainFile;
        private readonly string _baseDir;
        
        
        private readonly HashSet<string> _loadedFiles;
        
        private readonly List<IDefinition> _definitions;
        private readonly List<NamespaceNode> _namespaces;
        
        

        public LoadedFilesManager(FrontEndCompiler compiler, string mainFile)
        {
            _compiler = compiler;
            
            _mainFile = mainFile;
            _baseDir = Path.GetDirectoryName(mainFile);
            
            _loadedFiles = new HashSet<string>();
            
            _definitions = new List<IDefinition>();
            _namespaces = new List<NamespaceNode>();
        }


        public void Dispose()
        {
            _loadedFiles.Clear();
            
            _definitions.Clear();
            _namespaces.Clear();
        }
        
        


        public void Load(string currentFile, IEnumerable<string> files)
        {
            foreach (var f in files)
                Load(currentFile, f);
        }
        
        
        /// <summary>
        /// Perform a Lexical and Syntactical analysis 
        /// </summary>
        /// <param name="currentFile"></param>
        /// <param name="newFile"></param>
        public void Load(string currentFile, string newFile)
        {
            _taskCount ++;
            
            string relative = newFile.Trim('"'); // Clean up load path
            string path = Path.Combine(_baseDir, relative);

            // TODO check if file exists and warn
            if (!File.Exists(path))
                return;
            
            // Check if we have loaded it already
            if (_loadedFiles.Contains(path))
            {
                ErrorHandler.Instance.AddWarning(0, 0, $"In {currentFile}. Trying to load an already added file: {newFile}");
                _taskCount--;
                return;
            }

            _loadedFiles.Add(path);
            
            
            ProgramNode program = _compiler.Grammar.Analyze(path);
            
            if (ErrorHandler.Instance.AnyError)
            {
                ErrorHandler.Instance.PrintErrors();
                _taskCount--;
                return;
            }
	        
            // Add new definitions and namespaces
            _definitions.AddRange(program.Definitions);
            _namespaces.AddRange(program.Namespaces);


            // Recursive imports
            foreach (var f in program.Links)
                Load(path, f);
            
            _taskCount--;
        }


        public IEnumerable<IDefinition> GetDefinitions()
        {
            return _definitions;
        }
        
        public IEnumerable<NamespaceNode> GetNamespaces()
        {
            return _namespaces;
        }
    }
}