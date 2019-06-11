using System;
using System.Globalization;

namespace Seagull.Language.Grammar
{
    public static class LexerHelper
    {
        public static int LexemeToInt(string str)
        {
            try
            {
                return int.Parse(str);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
            }
            catch (OverflowException e)
            {
                // TODO return LexemeToLong(str);
            }
            catch (ArgumentNullException e)
            {
            }
            return -1;
        }

        
        public static bool LexemeToBoolean(string str)
        {
            try
            {
                return bool.Parse(str);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
            }
            return false;
        }
        
	
        public static char LexemeToChar(String str) {
		
            // When we have 'a', '8'...
            if (str.Length == 3)
                return str[1];
		
            // When we have '\t', '\n'...
            switch (str) {
                case "'\\t'": return '\t';
                case "'\\n'": return '\n';
                case "'\\r'": return '\r';
                case "'\''": return '\'';
                case "'\\'": return '\\';
            }
		
            // When we have '\126'
            str = str.Replace("'", "");
            str = str.Substring(1);	
            return (char) int.Parse(str);
        }
	
	
        
        public static double LexemeToReal(String str)
        {
            
            Console.WriteLine("LexemeToReal: " + str);
            
            try
            {			
                // Exponential
                String[] split = str.ToLower().Split('e');
			
                double numb = double.Parse(split[0], CultureInfo.InvariantCulture);
                if (split.Length == 1)
                {
                    Console.WriteLine($"LexemeToReal: {str} = {numb}");
                    return numb;
                }
                    
			
                return numb * Math.Pow(10, double.Parse(split[1]));
            }
            catch(FormatException e)
            {
                Console.WriteLine(e);
            }
            return -1;
        }
    }
}