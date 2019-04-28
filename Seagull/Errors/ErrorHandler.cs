using System.Collections.Generic;
using System.Text;

namespace Seagull.Errors
{
    public class ErrorHandler
    {

        private static ErrorHandler _instance;
        public static ErrorHandler Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ErrorHandler();
                return _instance;
            }
        }


        public bool AnyError => _errors.Count > 0;
        public bool AnyWarning => _warnings.Count > 0;


        private readonly List<ErrorType> _errors;
        private readonly List<Warning> _warnings;


        private ErrorHandler()
        {
            _errors = new List<ErrorType>();
            _warnings = new List<Warning>();
        }
        
        
        
        
        public ErrorType RaiseError(int line, int column, string message)
        {
            ErrorType error = new ErrorType(line, column, message);
            _errors.Add(error);
            return error;
        }
        
        
        public void AddWarning(int line, int column, string message)
        {
            Warning warning = new Warning(line, column, message);
            _warnings.Add(warning);
        }
        
        
        
        
        
	
        public string PrintErrors()
        {
            StringBuilder str = new StringBuilder();
            
            str.AppendLine($"[ {_errors.Count} Error(s) found ]"); 
            _errors.Sort((e1, e2) => e1.Line - e2.Line);
		
            foreach (ErrorType e in _errors)
                str.AppendLine(e.ToString());

            return str.ToString();
        }
        
        public string PrintWarnings()
        {
            StringBuilder str = new StringBuilder();
            
            str.AppendLine($"[ {_warnings.Count} Warnings(s) appeared ]"); 
            _warnings.Sort((e1, e2) => e1.Line - e2.Line);
		
            foreach (Warning w in _warnings)
                str.AppendLine(w.ToString());

            return str.ToString();
        }

        
        

        public void Clear()
        {
            _errors.Clear();
            _warnings.Clear();
        }
    }
}