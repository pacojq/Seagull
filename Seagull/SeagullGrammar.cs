using System;
using System.IO;
using Antlr4.Runtime;
using Seagull.AST;
using Seagull.Errors;

namespace Seagull
{
    internal class SeagullGrammar
    {
        private ErrorListener _errorListener;


        public SeagullGrammar()
        {
            _errorListener = new ErrorListener();
        }
        
        
        public Program Analyze(string filename)
        {
            // create a lexer that feeds off of input stream
            AntlrInputStream input;
            try
            {
                input = new AntlrFileStream(filename);
            }
            catch (IOException e)
            {
                Console.WriteLine("Could not load the input file: " + filename);
                return null;
            }
            SeagullLexer lexer = new SeagullLexer(input);

            
            // create a parser that feeds off the tokens buffer
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            SeagullParser parser = new SeagullParser(tokens);
		
            parser.RemoveErrorListeners();
            lexer.RemoveErrorListeners();
            parser.AddErrorListener(_errorListener);
            lexer.AddErrorListener(_errorListener);
		
            
            
            // Parse the program and get the AST //
			
            return parser.program().Ast;
        }
        
    }
}