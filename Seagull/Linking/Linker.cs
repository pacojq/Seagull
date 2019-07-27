using System.Collections.Generic;
using Seagull.AST;

namespace Seagull.Linking
{
    public class Linker
    {
        public static Linker Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Linker();
                return _instance;
            }
        }

        private static Linker _instance;



        private readonly Scanner _scanner;



        private Queue<string> _linkedFiles;
        
        
        /// <summary>
        /// Scanned files, which haven't been linked yet.
        /// </summary>
        private Queue<string> _filesPendingToLink;
        
        private List<Program> _loadedPrograms;

        private Linker()
        {
            _scanner = new Scanner();
            _loadedPrograms = new List<Program>();
        }


        public void SetRoot(string root)
        {
            
        }
        
    }
}