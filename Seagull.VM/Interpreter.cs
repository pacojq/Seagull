using System;
using Seagull.AST;
using Seagull.AST.Expressions;
using Seagull.AST.Expressions.Binary;
using Seagull.AST.Expressions.Literals;
using Seagull.AST.Statements;
using Seagull.AST.Statements.Definitions;
using Seagull.AST.Types;
using Seagull.Errors;
using Seagull.Visitor;
using Void = Seagull.Visitor.Void;

namespace Seagull.VM
{
    internal class Interpreter : AbstractVisitor<dynamic, Void>
    {
        
        
        public override dynamic Visit(AST.Program program, Void p)
        {
            throw new System.NotImplementedException();
        }

        
        
        
        
        // ====================== STATEMENTS ====================== //
        

        public override dynamic Visit(Assignment assignment, Void p)
        {
            throw new System.NotImplementedException();
        }

        public override dynamic Visit(IfStatement ifStatement, Void p)
        {
            bool value = ifStatement.Condition.Accept(this, p);
            if (value)
            {
                foreach (IStatement st in ifStatement.Then)
                {
                    st.Accept(this, p);
                }
            }
            else
            {
                foreach (IStatement st in ifStatement.Else)
                {
                    st.Accept(this, p);
                }
            }
            return null;
        }

        public override dynamic Visit(Read read, Void p)
        {
            throw new System.NotImplementedException();
        }

        public override dynamic Visit(Return returnStmnt, Void p)
        {
            return returnStmnt.Value.Accept(this, p);
        }

        public override dynamic Visit(WhileLoop whileLoop, Void p)
        {
            throw new System.NotImplementedException();
        }

        public override dynamic Visit(Print print, Void p)
        {
            string str = print.Expression.Accept(this, p).ToString();
            Console.Write(str);
            return null;
        }

        

        
        
        
        // ====================== EXPRESSIONS ====================== //

        

        public override dynamic Visit(Arithmetic arithmetic, Void p)
        {
            throw new System.NotImplementedException();
        }

        public override dynamic Visit(Comparison comparison, Void p)
        {
            throw new System.NotImplementedException();
        }

        public override dynamic Visit(LogicalOperation logicalOperation, Void p)
        {
            throw new System.NotImplementedException();
        }

        public override dynamic Visit(Indexing indexing, Void p)
        {
            throw new System.NotImplementedException();
        }

        public override dynamic Visit(AttributeAccess attributeAccess, Void p)
        {
            throw new System.NotImplementedException();
        }

        public override dynamic Visit(Cast cast, Void p)
        {
            throw new System.NotImplementedException();
        }

        public override dynamic Visit(New newExpr, Void p)
        {
            throw new System.NotImplementedException();
        }

        public override dynamic Visit(CharLiteral charLiteral, Void p)
        {
            throw new System.NotImplementedException();
        }

        public override dynamic Visit(DoubleLiteral doubleLiteral, Void p)
        {
            throw new System.NotImplementedException();
        }

        public override dynamic Visit(FunctionInvocation functionInvocation, Void p)
        {
            throw new System.NotImplementedException();
        }

        public override dynamic Visit(Negation negation, Void p)
        {
            throw new System.NotImplementedException();
        }

        public override dynamic Visit(UnaryMinus unaryMinus, Void p)
        {
            throw new System.NotImplementedException();
        }

        public override dynamic Visit(Variable variable, Void p)
        {
            throw new System.NotImplementedException();
        }

        
        
        
        public override dynamic Visit(IntLiteral intLiteral, Void p)
        {
            return intLiteral.Value;
        }
        
        public override dynamic Visit(StringLiteral stringLiteral, Void p)
        {
            return stringLiteral.Value;
        }

        public override dynamic Visit(BooleanLiteral booleanLiteral, Void p)
        {
            return booleanLiteral.Value;
        }
    }
}