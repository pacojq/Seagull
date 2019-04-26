java -jar antlr-4.7.2-complete.jar -Dlanguage=CSharp Grammar/SeagullLexer.g4 -o Grammar -no-listener
java -jar antlr-4.7.2-complete.jar -Dlanguage=CSharp Grammar/SeagullPreprocessorParser.g4 -o Grammar -no-listener
java -jar antlr-4.7.2-complete.jar -Dlanguage=CSharp Grammar/SeagullParser.g4 -o Grammar -no-listener
