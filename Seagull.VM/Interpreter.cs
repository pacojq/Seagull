using System;
using System.Collections.Generic;
using Seagull.AST;
using Seagull.AST.Expressions;
using Seagull.AST.Expressions.Binary;
using Seagull.AST.Expressions.Literals;
using Seagull.AST.Statements;
using Seagull.AST.Statements.Definitions;
using Seagull.Visitor;
using Void = Seagull.Visitor.Void;

namespace Seagull.VM
{
    internal class Interpreter : AbstractVisitor<dynamic, Void>
    {

        private Dictionary<IExpression, dynamic> _values;

        public Interpreter()
        {
            _values = new Dictionary<IExpression, dynamic>();
        }

        public void SetUp()
        {
            _values.Clear();
        }
        
        
        
        
        
        
        public override dynamic Visit(AST.Program program, Void p)
        {
            program.MainFunction.Accept(this, p);
            return null;
        }

        
        
        
        
        // ====================== STATEMENTS ====================== //
        

        public override dynamic Visit(Assignment assignment, Void p)
        {
            IExpression key = assignment.Left;
            if (!_values.ContainsKey(key))
                _values.Add(key, null);

            _values[key] = assignment.Right.Accept(this, p);
            return null;
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
            while (whileLoop.Condition.Accept(this, p));
            {
                foreach (IStatement st in whileLoop.Statements)
                {
                    st.Accept(this, p);
                }
            }
            return null;
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
            var a = arithmetic.Left.Accept(this, p);
            var b = arithmetic.Right.Accept(this, p);
            switch (arithmetic.Operator)
            {
                case "+": return a + b;
                case "-": return a - b;
                case "/": return a / b;
                case "*": return a * b;
                
                default: return null;
            }
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
            // TODO arguments wtf
            
            Console.WriteLine("Visiting function invocation: " + functionInvocation.Function.Name);
            IDefinition def = functionInvocation.Function.Definition;
            Console.WriteLine("Definition: " + def.Name + " - " + def.GetType().Name);
            FunctionDefinition fDef = (FunctionDefinition) def;
            foreach (IStatement st in fDef.Statements)
            {
                if (st is Return)
                    return st.Accept(this, p);
                st.Accept(this, p);
            }
            return null;
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