# Seagull

Seagull is a toy programming language, based in a project from the Programming 
Languages Design course at Universidad de Oviedo. The Seagull compiler is built
in C#, with the help of ANTLR for lexical and syntax analysis.

In the 70s this language would have rocked.

## Objectives

The objective of Seagull is to make a type-safe language, as friendly as C# or Java, 
which can directly output a C language program after compilation.

## Features

  - Basic types: built-in types; arrays; and named structs.
  - If/Else statements and while loops.

## Short term goals

  - Use the MAPL Virtual Machine as target platform (academic virtual machine, 
  only available for Universidad de Oviedo students).
  - "switch" statements
  - "for" loops, "break" and "continue" keywords.
  - Allow the use of namespaces in the language.
  - Add lambda expressions.
  - Allow value assignment on declaration.
  - Add Enum types to the language.
  - Basic polymorphism: interfaces and struct inheritance.

## Long term goals

  - Implicit type declarations and conversions.
  - Pointer handling and pass parameters by reference.
  - Add generics to the language.
  - Use the C language as the target compilation language.
  - Allow the use of a graphics library, such as OpenGL.
  
## Wishlist

  - Add other output languages, like Java, Javascript, etc.
  - Allow compilation to the Microsoft Common Intermediate Language.
