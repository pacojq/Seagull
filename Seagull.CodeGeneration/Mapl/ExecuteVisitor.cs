using System.Text;
using Seagull.Language.AST;
using Seagull.Language.AST.Expressions;
using Seagull.Language.AST.Statements;
using Seagull.Language.AST.Statements.Definitions;
using Seagull.Language.AST.Types;
using Seagull.Language.Visitor;

namespace Seagull.CodeGeneration.Mapl
{
    public class ExecuteVisitor : CgVisitor<Void, Void>
    {
        private MaplCodeGenerator _cg;
	
		private AddressVisitor _addressVisitor;
		private ValueVisitor valueVisitor;
		
		public ExecuteVisitor() {
			
			_cg = MaplCodeGenerator.Instance;
			
			_addressVisitor = new AddressVisitor();
			valueVisitor = new ValueVisitor();

			valueVisitor.addressVisitor = _addressVisitor;
			_addressVisitor.valueVisitor = valueVisitor;
		}
		
		
		public override Void Visit(Program program, Void p)
		{
			
			foreach (IDefinition def in program.Definitions)
				def.Accept(this, p);
			
			
			StringBuilder code = new StringBuilder();
			
			foreach (IDefinition def in program.Definitions)
				if (def is VariableDefinition)
					code.Append( def.cgGetExecute() );
			
			code.Append("\n' Invocation to the main function\n");
			code.Append("call main\n");
			code.Append("halt\n\n");
			
			foreach (IDefinition def in program.Definitions)
				if (def is FunctionDefinition)
					code.Append( def.cgGetExecute() );
			
			p.cgCode = code.ToString();
			
			return null;
		}
			
		
		
		// We only execute statements and definitions //
		
		
		public override Void Visit(FunctionDefinition functionDefinition, Void p)
		{
			
			functionDefinition.cgSetExecute(_cg.Function(functionDefinition));
			
			functionDefinition.cgAppendExecute(_cg.Comment("Parameters\n"));
			int argBytesSum = 0;
			FunctionType ft = (FunctionType) functionDefinition.Type;
			foreach (VariableDefinition vd in ft.Parameters) {
				vd.Accept(this, p);
				functionDefinition.cgAppendExecute(vd.cgGetExecute());
				argBytesSum += vd.Type.CgNumberOfBytes;
			}
			
			
			
			functionDefinition.cgAppendExecute(_cg.Comment("Local variables\n"));
			foreach (IStatement st in functionDefinition.Statements) {
				if (st is VariableDefinition) {
					st.Accept(this, p);
					functionDefinition.cgAppendExecute(st.cgGetExecute());
				}
			}
			
			functionDefinition.cgAppendExecute(_cg.Enter(functionDefinition.CgLocalBytesSum));
			
			foreach (IStatement st in functionDefinition.Statements) {
				if (st is VariableDefinition)
					continue;
				
				st.Accept(this, p);
				functionDefinition.cgAppendExecute(st.cgGetExecute());
			}
			
			
			//The first constant represents the bytes to return; 
			//the second one, the bytes of all the local variables; 	
			//and the last one, the bytes of all the arguments.
			functionDefinition.cgAppendExecute(_cg.Ret(
					ft.ReturnType.CgNumberOfBytes,
					functionDefinition.CgLocalBytesSum,
					argBytesSum
				));
			
			return null;
		}
		
		
		public override Void Visit(VariableDefinition variableDefinition, Void p)
		{		
			variableDefinition.cgSetExecute(_cg.Comment(variableDefinition.ToString()));
			return null;
		}
		
		
		
		
		public override Void Visit(Assignment assignment, Void p)
		{
			
			assignment.cgSetExecute(_cg.Line(assignment));
			
			assignment.Left.Accept(_addressVisitor, null);
			assignment.cgAppendExecute(assignment.Left.cgGetAddress());
			
			assignment.Right.Accept(valueVisitor, null);
			assignment.cgAppendExecute(assignment.Right.cgGetValue());
			
			assignment.cgAppendExecute(_cg.Store(assignment.Left.Type));
			return null;
		}
		
		
		public override Void Visit(IfStatement ifStatement, Void p)
		{
			ifStatement.cgSetExecute(_cg.Line(ifStatement));
			
			int labelNumber = _cg.GetLabels(2);
			
			IExpression condition = ifStatement.Condition;
			
			// Check condition
			condition.Accept(valueVisitor, null);
			ifStatement.cgAppendExecute(condition.cgGetValue());
			
			// Jump to else if false (0)
			ifStatement.cgAppendExecute(_cg.JumpZero(labelNumber));
			
			
			// Execute all the "if" part...
			ifStatement.cgAppendExecute(_cg.Comment("Body of the if branch"));
			foreach (IStatement st in ifStatement.Then) {
				st.Accept(this, p);
				ifStatement.cgAppendExecute(st.cgGetExecute());
			}
			
			// ...and jump over the else part
			ifStatement.cgAppendExecute(_cg.Jump(labelNumber + 1));
			
			
			// Execute all the "else" part
			ifStatement.cgAppendExecute(_cg.Label(labelNumber));
			ifStatement.cgAppendExecute(_cg.Comment("Body of the else branch"));
			foreach (IStatement st in ifStatement.Else) {
				st.Accept(this, p);
				ifStatement.cgAppendExecute(st.cgGetExecute());
			}
			
			// End
			ifStatement.cgAppendExecute(_cg.Label(labelNumber + 1));
			
			return null;
		}
		
		public override Void Visit(Read read, Void p)
		{
			read.cgSetExecute(_cg.Line(read));

			IExpression expr = read.Expression;
			read.cgAppendExecute(_cg.Comment(" Read %s" + expr.ToString()));
			expr.Accept(_addressVisitor, null);
			read.cgAppendExecute(expr.cgGetAddress());
			read.cgAppendExecute(_cg.In(expr.Type));
			
			return null;
		}
		
		public override Void Visit(Return ret, Void p)
		{
			ret.cgSetExecute(_cg.Line(ret));
			ret.cgAppendExecute(_cg.Comment("Return"));
			
			// Just push the value
			ret.Value.Accept(valueVisitor, null);
			ret.cgAppendExecute(ret.Value.cgGetValue());
			
			return null;
		}
		
		public override Void Visit(WhileLoop whileLoop, Void p)
		{
			whileLoop.cgSetExecute(_cg.Line(whileLoop));
			
			int labelNumber = _cg.GetLabels(2);
			
			// Set first label
			whileLoop.cgAppendExecute(_cg.Label(labelNumber));
			
			
			// Check condition
			IExpression condition = whileLoop.Condition;
			condition.Accept(valueVisitor, null);
			whileLoop.cgAppendExecute(condition.cgGetValue());
			
			// Jump to the end if false (0)
			whileLoop.cgAppendExecute(_cg.JumpZero(labelNumber+1));
			whileLoop.cgAppendExecute(_cg.Comment("Body of the while statement"));
			
			
			// Execute all the loop...
			foreach (IStatement st in whileLoop.Statements)
			{
				st.Accept(this, p);
				whileLoop.cgAppendExecute(st.cgGetExecute());
			}
			
			// ...and jump back to the condition check
			whileLoop.cgAppendExecute(_cg.Jump(labelNumber));
			
			// End
			whileLoop.cgAppendExecute(_cg.Label(labelNumber + 1));
					
			return null;
		}
		
		
		public override Void Visit(Print print, Void p)
		{
			print.cgSetExecute(_cg.Line(print));

			IExpression expr = print.Expression;
			
			print.cgAppendExecute(_cg.Comment("Write"));//+ expr.toString())); comment this because write '\n' may cause problems
			expr.Accept(valueVisitor, null);
			print.cgAppendExecute(expr.cgGetValue());
			print.cgAppendExecute(_cg.Out(expr.Type));
			
			return null;
		}
		
		
		public override Void Visit(FunctionInvocation funcInvocation, Void p)
		{
			funcInvocation.Accept(valueVisitor, null);
			funcInvocation.cgSetExecute(funcInvocation.cgGetValue());
			
			IDefinition def = funcInvocation.Function.Definition;
			FunctionType t = (FunctionType) def.Type;
			if (!(t.ReturnType is VoidType))
				funcInvocation.cgAppendExecute(_cg.Pop(t.ReturnType));
			
			return null;
		}
		
		
    }
}