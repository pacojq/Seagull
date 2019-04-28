using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Seagull.AST;
using Seagull.Errors;

namespace Seagull.FrontEnd
{
    public class ImportsManager
    {

        private int _taskCount = 0;
        public bool Ready => _taskCount == 0;

        private FrontEndCompiler _compiler;
        
        private readonly string _mainFile;
        private readonly string _baseDir;
        
        private readonly Queue<string> _files;
        private readonly List<IDefinition> _imports;
        private readonly HashSet<string> _importedFiles;
        
        private object _queueLock = new object();
        private object _importsLock = new object();
        private object _setLock = new object();
        
        

        public ImportsManager(FrontEndCompiler compiler, string mainFile)
        {
            _compiler = compiler;
            
            _mainFile = mainFile;
            _baseDir = Path.GetDirectoryName(mainFile);
            
            _files = new Queue<string>();
            _imports = new List<IDefinition>();
            _importedFiles = new HashSet<string>();
        }
        
        
        public IEnumerable<IDefinition> GetImports()
        {
            lock(_importsLock)
                return _imports;
        }



        public void Import(string currentFile, IEnumerable<string> files)
        {
            Parallel.ForEach(files, f => Import(currentFile, f));
        }
        
        
        public void Import(string currentFile, string newFile)
        {
            Interlocked.Increment(ref _taskCount);
            
            string relative = newFile.Trim('"'); // Clean up import path
            string path = Path.Combine(_baseDir, relative);

            
            // Check if we have imported it already
            lock (_setLock)
            {
                if (_importedFiles.Contains(path))
                {
                    ErrorHandler.Instance.AddWarning(0, 0, $"In {currentFile}. Trying to import an already added file: {newFile}");
                    Interlocked.Decrement(ref _taskCount);
                    return;
                }

                _importedFiles.Add(path);
            }

            
            Program program = _compiler.Grammar.Analyze(path);
            
            if (ErrorHandler.Instance.AnyError)
            {
                Console.WriteLine(ErrorHandler.Instance.PrintErrors());
                Interlocked.Decrement(ref _taskCount);
                return;
            }
	        
            var result = program.Definitions.ToList();

            // Remove the main function
            if (program.MainFunction != null)
                result.Remove(program.MainFunction);
            
            // Add to imports
            lock(_imports)
                _imports.AddRange(result);


            // Recursive imports
            Parallel.ForEach(program.Imports, f => Import(path, f));
            Interlocked.Decrement(ref _taskCount);
        }
        

        
        
    }
}