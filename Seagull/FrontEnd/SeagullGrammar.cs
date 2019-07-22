using System.Collections.Generic;
using System.IO;
using Antlr4.Runtime;
using Seagull.AST;
using Seagull.Errors;
using Seagull.Grammar;
using Seagull.Logging;

namespace Seagull.FrontEnd
{
    internal class SeagullGrammar
    {
        private readonly ErrorListener _errorListener;


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
                Logger.Instance.LogError("Could not load the input file: " + filename);
                return null;
            }
            SeagullLexer lexer = new SeagullLexer(input);

            // Look for errors in the lexer
            CheckLexer(lexer);
            
            
            // create a parser that feeds off the tokens buffer
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            SeagullPreprocessorParser preprocessor = new SeagullPreprocessorParser(tokens);
            SeagullParser parser = new SeagullParser(preprocessor.TokenStream);
		
            parser.RemoveErrorListeners();
            lexer.RemoveErrorListeners();
            parser.AddErrorListener(_errorListener);
            lexer.AddErrorListener(_errorListener);
		
            
            
            // Parse the program and get the AST //
			
            return parser.program().Ast;
        }



        private int CheckLexer(SeagullLexer lexer)
        {
            IToken token;
            token = lexer.NextToken();
            while (token.Type != SeagullLexer.Eof)
            {
                token = lexer.NextToken();
            }
            lexer.Reset();
            
            return 0;
        }

        
    }
}