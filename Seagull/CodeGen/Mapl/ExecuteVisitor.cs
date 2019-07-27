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
				if (def is VariableDefinition || def is FunctionDefinition)
					def.Accept(this, p);
			
			
			StringBuilder code = new StringBuilder();
			
			foreach (IDefinition def in program.Definitions)
				if (def is VariableDefinition)
					code.Append( def.CgExecute );
			
			code.Append("\n' Invocation to the main function\n");
			code.Append("call main\n");
			code.Append("halt\n\n");
			
			foreach (IDefinition def in program.Definitions)
				if (def is FunctionDefinition)
					code.Append( def.CgExecute );
			
			program.CgCode = code.ToString();
			
			return null;
		}
			
		
		
		// We only execute statements and definitions //
		
		
		public override Void Visit(FunctionDefinition functionDefinition, Void p)
		{
			functionDefinition.CgExecute = _cg.Function(functionDefinition);
			
			functionDefinition.CgExecute += _cg.Comment("Parameters\n");
			int argBytesSum = 0;
			FunctionType ft = (FunctionType) functionDefinition.Type;
			foreach (VariableDefinition vd in ft.Parameters)
			{
				vd.Accept(this, p);
				functionDefinition.CgExecute += vd.CgExecute;
				argBytesSum += vd.Type.CgNumberOfBytes;
			}
			
			
			
			functionDefinition.CgExecute += _cg.Comment("Local variables\n");
			foreach (IStatement st in functionDefinition.Statements)
			{
				if (st is VariableDefinition)
				{
					st.Accept(this, p);
					functionDefinition.CgExecute += st.CgExecute;
				}
			}
			
			functionDefinition.CgExecute += _cg.Enter(functionDefinition.CgLocalBytesSum);
			
			foreach (IStatement st in functionDefinition.Statements)
			{
				if (st is VariableDefinition)
					continue;
				
				st.Accept(this, p);
				functionDefinition.CgExecute += st.CgExecute;
			}
			
			
			//The first constant represents the bytes to return; 
			//the second one, the bytes of all the local variables; 	
			//and the last one, the bytes of all the arguments.
			functionDefinition.CgExecute += _cg.Ret(
				ft.ReturnType.CgNumberOfBytes,
				functionDefinition.CgLocalBytesSum,
				argBytesSum
			);
			
			return null;
		}
		
		
		public override Void Visit(VariableDefinition variableDefinition, Void p)
		{
			variableDefinition.CgExecute = _cg.Comment(variableDefinition.ToString());
			return null;
		}
		
		
		
		
		public override Void Visit(Assignment assignment, Void p)
		{
			assignment.CgExecute = _cg.Line(assignment);
			
			assignment.Left.Accept(_addressVisitor, null);
			assignment.CgExecute += assignment.Left.CgAddress;
			
			assignment.Right.Accept(valueVisitor, null);
			assignment.CgExecute += assignment.Right.CgValue;
			
			assignment.CgExecute += _cg.Store(assignment.Left.Type);
			return null;
		}
		
		
		public override Void Visit(IfStatement ifStatement, Void p)
		{
			ifStatement.CgExecute = _cg.Line(ifStatement);
			
			int labelNumber = _cg.GetLabels(2);
			
			IExpression condition = ifStatement.Condition;
			
			// Check condition
			condition.Accept(valueVisitor, null);
			ifStatement.CgExecute += condition.CgValue;
			
			// Jump to else if false (0)
			ifStatement.CgExecute += _cg.JumpZero(labelNumber);
			
			
			// Execute all the "if" part...
			ifStatement.CgExecute += _cg.Comment("Body of the if branch");
			foreach (IStatement st in ifStatement.Then)
			{
				st.Accept(this, p);
				ifStatement.CgExecute += st.CgExecute;
			}
			
			// ...and jump over the else part
			ifStatement.CgExecute += _cg.Jump(labelNumber + 1);
			
			
			// Execute all the "else" part
			ifStatement.CgExecute += _cg.Label(labelNumber);
			ifStatement.CgExecute += _cg.Comment("Body of the else branch");
			foreach (IStatement st in ifStatement.Else)
			{
				st.Accept(this, p);
				ifStatement.CgExecute += st.CgExecute;
			}
			
			// End
			ifStatement.CgExecute += _cg.Label(labelNumber + 1);
			
			return null;
		}
		
		public override Void Visit(Read read, Void p)
		{
			read.CgExecute = _cg.Line(read);

			IExpression expr = read.Expression;
			read.CgExecute += _cg.Comment(" Read %s" + expr.ToString());
			expr.Accept(_addressVisitor, null);
			read.CgExecute += expr.CgAddress;
			read.CgExecute += _cg.In(expr.Type);
			read.CgExecute += _cg.Store(expr.Type);
			
			
			return null;
		}
		
		public override Void Visit(Return ret, Void p)
		{
			ret.CgExecute = _cg.Line(ret);
			ret.CgExecute += _cg.Comment("Return");
			
			// Just push the value
			ret.Value.Accept(valueVisitor, null);
			ret.CgExecute += ret.Value.CgValue;
			
			return null;
		}
		
		public override Void Visit(WhileLoop whileLoop, Void p)
		{
			whileLoop.CgExecute = _cg.Line(whileLoop);
			
			int labelNumber = _cg.GetLabels(2);
			
			// Set first label
			whileLoop.CgExecute += _cg.Label(labelNumber);
			
			
			// Check condition
			IExpression condition = whileLoop.Condition;
			condition.Accept(valueVisitor, null);
			whileLoop.CgExecute += condition.CgValue;
			
			// Jump to the end if false (0)
			whileLoop.CgExecute += _cg.JumpZero(labelNumber+1);
			whileLoop.CgExecute += _cg.Comment("Body of the while statement");
			
			
			// Execute all the loop...
			foreach (IStatement st in whileLoop.Statements)
			{
				st.Accept(this, p);
				whileLoop.CgExecute += st.CgExecute;
			}
			
			// ...and jump back to the condition check
			whileLoop.CgExecute += _cg.Jump(labelNumber);
			
			// End
			whileLoop.CgExecute += _cg.Label(labelNumber + 1);
					
			return null;
		}
		
		
		public override Void Visit(Print print, Void p)
		{
			print.CgExecute = _cg.Line(print);

			IExpression expr = print.Expression;
			
			print.CgExecute += _cg.Comment("Write");
			expr.Accept(valueVisitor, null);
			print.CgExecute += expr.CgValue;
			print.CgExecute += _cg.Out(expr.Type);
			
			return null;
		}
		
		
		public override Void Visit(FunctionInvocation funcInvocation, Void p)
		{
			funcInvocation.Accept(valueVisitor, null);
			funcInvocation.CgExecute = funcInvocation.CgValue;
			
			IDefinition def = funcInvocation.Function.Definition;
			FunctionType t = (FunctionType) def.Type;
			if (!(t.ReturnType is VoidType))
				funcInvocation.CgExecute += _cg.Pop(t.ReturnType);
			
			return null;
		}
		
		
    }
}