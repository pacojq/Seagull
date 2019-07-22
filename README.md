<h1 align="center" >Seagull</h1>

<p align="center">
  <img src="https://img.shields.io/github/license/pacojq/Seagull.svg?style=flat-square" />
  <img src="https://img.shields.io/badge/version-0.0.1-9cf.svg?style=flat-square" />
  <img src="https://img.shields.io/github/stars/pacojq/Seagull.svg?style=flat-square" />
</p>

> As I watched the seagulls, I thought: That's the road to take;
> find the absolute rhythm and follow it with absolute trust.
>
> ~ Nikos Kazantzakis



## Description

Seagull is a toy programming language, based in a project from the Programming 
Languages Design course at Universidad de Oviedo. The Seagull compiler is built
in C#, with the help of ANTLR for lexical and syntax analysis.

In the 70s this language would have rocked.

## Objectives

The objective of Seagull is to make a type-safe language, as friendly as C# or Java, 
which can directly output a C language program after compilation.

## Features

  - Basic types: built-in types; arrays; and named structs.
  - ```if```/```else``` statements and ```while``` loops.
  - Target MAPL Virtual Machine as target platform (academic virtual machine, 
  only available for Universidad de Oviedo students).
  - Using basic namespace functionality.

## Short term goals

  - ```switch``` statements
  - ```for``` loops, ```break``` and ```continue``` keywords.
  - Add lambda expressions.
  - Allow value assignment on declaration.
  - Add ```Enum``` types to the language.
  - Basic polymorphism: interfaces and struct inheritance.

## Long term goals

  - Implicit type declarations and conversions.
  - Pointer handling and pass parameters by reference.
  - Add generics to the language.
  - Use the C language as the target compilation language.
  - Allow the use of a graphics library, such as OpenGL.
  - Language server protocol (https://langserver.org) implementation.
  
## Wishlist

  - Add other output languages, like Java, Javascript, etc.
  - Allow compilation to the Microsoft Common Intermediate Language.
