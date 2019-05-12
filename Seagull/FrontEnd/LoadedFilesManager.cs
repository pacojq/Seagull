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
    public class LoadedFilesManager : IDisposable
    {

        private int _taskCount = 0;
        public bool Ready => _taskCount == 0;

        private FrontEndCompiler _compiler;
        
        private readonly string _mainFile;
        private readonly string _baseDir;
        
        private readonly List<IDefinition> _loads;
        private readonly HashSet<string> _loadedFiles;
        
        private readonly object _loadsLock = new object();
        private readonly object _setLock = new object();
        
        

        public LoadedFilesManager(FrontEndCompiler compiler, string mainFile)
        {
            _compiler = compiler;
            
            _mainFile = mainFile;
            _baseDir = Path.GetDirectoryName(mainFile);
            
            _loads = new List<IDefinition>();
            _loadedFiles = new HashSet<string>();
        }


        public void Dispose()
        {
            lock(_loadsLock)
                _loads.Clear();
            lock(_setLock)
                _loadedFiles.Clear();
        }
        
        
        public IEnumerable<IDefinition> GetImports()
        {
            lock(_loadsLock)
                return _loads;
        }



        public void Load(string currentFile, IEnumerable<string> files)
        {
            Parallel.ForEach(files, f => Load(currentFile, f));
        }
        
        
        public void Load(string currentFile, string newFile)
        {
            Interlocked.Increment(ref _taskCount);
            
            string relative = newFile.Trim('"'); // Clean up load path
            string path = Path.Combine(_baseDir, relative);

            
            // Check if we have loaded it already
            lock (_setLock)
            {
                if (_loadedFiles.Contains(path))
                {
                    ErrorHandler.Instance.AddWarning(0, 0, $"In {currentFile}. Trying to load an already added file: {newFile}");
                    Interlocked.Decrement(ref _taskCount);
                    return;
                }

                _loadedFiles.Add(path);
            }

            
            Program program = _compiler.Grammar.Analyze(path);
            
            if (ErrorHandler.Instance.AnyError)
            {
                ErrorHandler.Instance.PrintErrors();
                Interlocked.Decrement(ref _taskCount);
                return;
            }
	        
            var result = program.Definitions.ToList();

            // Remove the main function
            if (program.MainFunction != null)
                result.Remove(program.MainFunction);
            
            // Add to imports
            lock(_loads)
                _loads.AddRange(result);


            // Recursive imports
            Parallel.ForEach(program.Loads, f => Load(path, f));
            Interlocked.Decrement(ref _taskCount);
        }


    }
}