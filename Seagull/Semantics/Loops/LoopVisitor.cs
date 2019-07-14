using Seagull.AST;
using Seagull.AST.Statements;
using Seagull.Errors;
using Seagull.Visitor;

namespace Seagull.Semantics.Loops
{
    
    /// <summary>
    /// This visitor makes sure break and continue statements are only
    /// inside loops.
    /// </summary>
    public class LoopVisitor : AbstractVisitor<Void, IStatement>
    {
        
        
        public override Void Visit(Break br, IStatement p)
        {
            if (p != null)
                return null;

            ErrorHandler.Instance.RaiseError(br.Line, br.Column, "Unexpected break statement.");
            return null;
        }

        public override Void Visit(Continue cont, IStatement p)
        {
            if (p != null)
                return null;

            ErrorHandler.Instance.RaiseError(cont.Line, cont.Column, "Unexpected continue statement.");
            return null;
        }

        
        
        
        
        public override Void Visit(ForeachLoop foreachLoop, IStatement p)
        {
            foreach (IStatement st in foreachLoop.Statements)
                st.Accept(this, foreachLoop);
            return null;
        }


        public override Void Visit(ForLoop forLoop, IStatement p)
        {
            foreach (IStatement st in forLoop.Statements)
                st.Accept(this, forLoop);
            return null;
        }


        public override Void Visit(WhileLoop whileLoop, IStatement p)
        {
            foreach (IStatement st in whileLoop.Statements)
                st.Accept(this, whileLoop);
            return null;
        }
    }
}