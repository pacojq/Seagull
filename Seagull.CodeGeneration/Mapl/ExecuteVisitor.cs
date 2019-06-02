using System.Text;
using Seagull.AST;
using Seagull.AST.Expressions;
using Seagull.AST.Statements;
using Seagull.AST.Statements.Definitions;
using Seagull.AST.Types;
using Seagull.Visitor;

namespace Seagull.CodeGeneration.Mapl
{
    public class ExecuteVisitor : CgVisitor<Void, Void>
    {
        private MaplCodeGenerator cg;
	
		private AddressVisitor addressVisitor;
		private ValueVisitor valueVisitor;
		
		public ExecuteVisitor() {
			
			cg = MaplCodeGenerator.Instance;
			
			addressVisitor = new AddressVisitor();
			valueVisitor = new ValueVisitor();

			valueVisitor.addressVisitor = addressVisitor;
			addressVisitor.valueVisitor = valueVisitor;
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
			
			functionDefinition.cgSetExecute(cg.Function(functionDefinition));
			
			functionDefinition.cgAppendExecute(cg.Comment("Parameters\n"));
			int argBytesSum = 0;
			FunctionType ft = (FunctionType) functionDefinition.Type;
			foreach (VariableDefinition vd in ft.Parameters) {
				vd.Accept(this, p);
				functionDefinition.cgAppendExecute(vd.cgGetExecute());
				argBytesSum += vd.Type.CgNumberOfBytes;
			}
			
			
			
			functionDefinition.cgAppendExecute(cg.Comment("Local variables\n"));
			foreach (IStatement st in functionDefinition.Statements) {
				if (st is VariableDefinition) {
					st.Accept(this, p);
					functionDefinition.cgAppendExecute(st.cgGetExecute());
				}
			}
			
			functionDefinition.cgAppendExecute(cg.Enter(functionDefinition.CgLocalBytesSum));
			
			foreach (IStatement st in functionDefinition.Statements) {
				if (st is VariableDefinition)
					continue;
				
				st.Accept(this, p);
				functionDefinition.cgAppendExecute(st.cgGetExecute());
			}
			
			
			//The first constant represents the bytes to return; 
			//the second one, the bytes of all the local variables; 	
			//and the last one, the bytes of all the arguments.
			functionDefinition.cgAppendExecute(cg.Ret(
					ft.ReturnType.CgNumberOfBytes,
					functionDefinition.CgLocalBytesSum,
					argBytesSum
				));
			
			return null;
		}
		
		
		public override Void Visit(VariableDefinition variableDefinition, Void p)
		{		
			variableDefinition.cgSetExecute(cg.Comment(variableDefinition.ToString()));
			return null;
		}
		
		
		
		
		public override Void Visit(Assignment assignment, Void p)
		{
			
			assignment.cgSetExecute(cg.Line(assignment));
			
			assignment.Left.Accept(addressVisitor, null);
			assignment.cgAppendExecute(assignment.Left.cgGetAddress());
			
			assignment.Right.Accept(valueVisitor, null);
			assignment.cgAppendExecute(assignment.Right.cgGetValue());
			
			assignment.cgAppendExecute(cg.Store(assignment.Left.Type));
			return null;
		}
		
		
		public override Void Visit(IfStatement ifStatement, Void p)
		{
			ifStatement.cgSetExecute(cg.Line(ifStatement));
			
			int labelNumber = cg.GetLabels(2);
			
			IExpression condition = ifStatement.Condition;
			
			// Check condition
			condition.Accept(valueVisitor, null);
			ifStatement.cgAppendExecute(condition.cgGetValue());
			
			// Jump to else if false (0)
			ifStatement.cgAppendExecute(cg.JumpZero(labelNumber));
			
			
			// Execute all the "if" part...
			ifStatement.cgAppendExecute(cg.Comment("Body of the if branch"));
			foreach (IStatement st in ifStatement.Then) {
				st.Accept(this, p);
				ifStatement.cgAppendExecute(st.cgGetExecute());
			}
			
			// ...and jump over the else part
			ifStatement.cgAppendExecute(cg.Jump(labelNumber + 1));
			
			
			// Execute all the "else" part
			ifStatement.cgAppendExecute(cg.Label(labelNumber));
			ifStatement.cgAppendExecute(cg.Comment("Body of the else branch"));
			foreach (IStatement st in ifStatement.Else) {
				st.Accept(this, p);
				ifStatement.cgAppendExecute(st.cgGetExecute());
			}
			
			// End
			ifStatement.cgAppendExecute(cg.Label(labelNumber + 1));
			
			return null;
		}
		
		public override Void Visit(Read read, Void p)
		{
			read.cgSetExecute(cg.Line(read));

			IExpression expr = read.Expression;
			read.cgAppendExecute(cg.Comment(" Read %s" + expr.ToString()));
			expr.Accept(addressVisitor, null);
			read.cgAppendExecute(expr.cgGetAddress());
			read.cgAppendExecute(cg.In(expr.Type));
			
			return null;
		}
		
		public override Void Visit(Return ret, Void p)
		{
			ret.cgSetExecute(cg.Line(ret));
			ret.cgAppendExecute(cg.Comment("Return"));
			
			// Just push the value
			ret.Value.Accept(valueVisitor, null);
			ret.cgAppendExecute(ret.Value.cgGetValue());
			
			return null;
		}
		
		public override Void Visit(WhileLoop whileLoop, Void p)
		{
			whileLoop.cgSetExecute(cg.Line(whileLoop));
			
			int labelNumber = cg.GetLabels(2);
			
			// Set first label
			whileLoop.cgAppendExecute(cg.Label(labelNumber));
			
			
			// Check condition
			IExpression condition = whileLoop.Condition;
			condition.Accept(valueVisitor, null);
			whileLoop.cgAppendExecute(condition.cgGetValue());
			
			// Jump to the end if false (0)
			whileLoop.cgAppendExecute(cg.JumpZero(labelNumber+1));
			whileLoop.cgAppendExecute(cg.Comment("Body of the while statement"));
			
			
			// Execute all the loop...
			foreach (IStatement st in whileLoop.Statements)
			{
				st.Accept(this, p);
				whileLoop.cgAppendExecute(st.cgGetExecute());
			}
			
			// ...and jump back to the condition check
			whileLoop.cgAppendExecute(cg.Jump(labelNumber));
			
			// End
			whileLoop.cgAppendExecute(cg.Label(labelNumber + 1));
					
			return null;
		}
		
		
		public override Void Visit(Print print, Void p)
		{
			print.cgSetExecute(cg.Line(print));

			IExpression expr = print.Expression;
			
			print.cgAppendExecute(cg.Comment("Write"));//+ expr.toString())); comment this because write '\n' may cause problems
			expr.Accept(valueVisitor, null);
			print.cgAppendExecute(expr.cgGetValue());
			print.cgAppendExecute(cg.Out(expr.Type));
			
			return null;
		}
		
		
		public override Void Visit(FunctionInvocation funcInvocation, Void p)
		{
			funcInvocation.Accept(valueVisitor, null);
			funcInvocation.cgSetExecute(funcInvocation.cgGetValue());
			
			IDefinition def = funcInvocation.Function.Definition;
			FunctionType t = (FunctionType) def.Type;
			if (!(t.ReturnType is VoidType))
				funcInvocation.cgAppendExecute(cg.Pop(t.ReturnType));
			
			return null;
		}
		
		
    }
}