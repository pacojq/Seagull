using System.Text;
using Seagull.Language.AST;
using Seagull.Language.AST.Expressions;
using Seagull.Language.AST.Expressions.Binary;
using Seagull.Language.AST.Statements.Definitions;


namespace Seagull.CodeGeneration.Mapl
{
	public class MaplCodeGenerator
	{
		private static MaplCodeGenerator _instance;

		public static MaplCodeGenerator Instance
		{
			get
			{
				if (_instance == null)
					_instance = new MaplCodeGenerator();
				return _instance;
			}
		}
		



		private int _label;


		private MaplCodeGenerator()
		{
			_label = 0;
		}


		public int GetLabels(int numberOfLabels)
		{
			int temp = _label;
			_label += numberOfLabels;
			return temp;
		}









		public string Comment(string comment)
		{
			return "\t' * " + comment;
		}



		public string Line(IStatement st)
		{
			return $"\n#line\t{st.Line}";
		}

		public string Line(IDefinition def)
		{
			return $"\n#line\t{def.Line}";
		}




		// ========================= Jumping ========================= //

		public string Label(int label)
		{
			return $"label{label}:";
		}

		public string Jump(int toLabel)
		{
			return $"\tjmp\tlabel{toLabel}";
		}

		public string JumpZero(int toLabel)
		{
			return $"\tjz\tlabel{toLabel}";
		}







		// ===================== In/Out Store/Load ===================== //

		public string Out(IType type)
		{
			return $"\tout{type.CgSuffix}";
		}

		public string In(IType type)
		{
			return $"\tin{type.CgSuffix}";
		}




		public string Store(IType type)
		{
			return $"\tstore{type.CgSuffix}";
		}

		public string Load(IType type)
		{
			return $"\tload{type.CgSuffix}";
		}






		// ====================== Pushing/Popping ====================== //



		public string Pop(IType type)
		{
			return $"\tpop{type.CgSuffix}";
		}





		public string PushBp()
		{
			return "\tpush\tbp";
		}

		public string Push(string type, int value)
		{
			return $"\tpush{type}\t{value}";
		}

		public string Push(IType type, int value)
		{
			return $"\tpush{type.CgSuffix}\t{value}";
		}

		public string Push(IType type, double value)
		{
			return $"\tpush{type.CgSuffix}\t{value}";
		}






		// ======================= Arithmetics ======================= //

		public string Arithmetic(Arithmetic arithmetic)
		{
			IType t = arithmetic.Type;

			StringBuilder str = new StringBuilder();

			str.Append(arithmetic.Left.CgValue);
			str.Append(arithmetic.Left.Type.CgConvert(t));

			str.Append(arithmetic.Right.CgValue);
			str.Append(arithmetic.Right.Type.CgConvert(t));

			switch (arithmetic.Operator)
			{
				case "+":
					str.Append(this.Add(t));
					break;
				case "-":
					str.Append(this.Sub(t));
					break;
				case "*":
					str.Append(this.Mul(t));
					break;
				case "/":
					str.Append(this.Div(t));
					break;

				default: return "INVALID ARITHMETIC OPERATOR " + arithmetic.Operator;
			}

			return str.ToString();
		}

		public string Add(IType type)
		{
			return $"\tadd{type.CgSuffix}";
		}

		public string Add(string type)
		{
			return $"\tadd{type}";
		}

		public string Sub(IType type)
		{
			return $"\tsub{type.CgSuffix}";
		}

		public string Mul(IType type)
		{
			return $"\tmul{type.CgSuffix}";
		}

		public string Mul(string type)
		{
			return $"\tmul{type}";
		}

		public string Div(IType type)
		{
			return $"\tdiv{type.CgSuffix}";
		}




		// ======================= Comparisons ======================= //


		public string Comparison(Comparison comparison)
		{
			IType t = comparison.Type;

			StringBuilder str = new StringBuilder();

			str.Append(comparison.Left.CgValue);
			str.Append(comparison.Left.Type.CgConvert(t));

			str.Append(comparison.Right.CgValue);
			str.Append(comparison.Right.Type.CgConvert(t));

			switch (comparison.Operator)
			{
				case ">":
					str.Append(this.Gt(t));
					break;
				case "<":
					str.Append(this.Lt(t));
					break;
				case ">=":
					str.Append(this.Ge(t));
					break;
				case "<=":
					str.Append(this.Le(t));
					break;
				case "==":
					str.Append(this.Eq(t));
					break;
				case "!=":
					str.Append(this.Ne(t));
					break;

				default: return "INVALID COMPARISON OPERATOR " + comparison.Operator;
			}

			return str.ToString();
		}

		// Greater than
		public string Gt(IType type)
		{
			return $"\tgt{type.CgSuffix}";
		}

		// Less than
		public string Lt(IType type)
		{
			return $"\tlt{type.CgSuffix}";
		}

		// Greater or equal than
		public string Ge(IType type)
		{
			return $"\tge{type.CgSuffix}";
		}

		// Less or equal than
		public string Le(IType type)
		{
			return $"\tle{type.CgSuffix}";
		}

		// Equal to
		public string Eq(IType type)
		{
			return $"\teq{type.CgSuffix}";
		}

		// Not equal to
		public string Ne(IType type)
		{
			return $"\tne{type.CgSuffix}";
		}





		// ==================== Logical Operations ==================== //


		public string LogicalOperation(LogicalOperation logicalOperation)
		{
			StringBuilder str = new StringBuilder();
		
			str.Append( logicalOperation.Left.CgValue );
			str.Append( logicalOperation.Right.CgValue );
		
			switch (logicalOperation.Operator) {
				case "&&": 	str.Append(this.And()); break;
				case "||": 	str.Append(this.Or()); break;
		
				default: return "INVALID LOGICAL OPERATOR " + logicalOperation.Operator;
			}
		
			return str.ToString();
		}

		public string And() {
			return string.Format("\tand");
		}
	
		public string Or() {
			return string.Format("\tor");
		}
	
		public string Not() {
			return string.Format("\tnot");
		}

	
	
	
	
	
		// ======================= Functions ======================= //
	
	
		public string Function(FunctionDefinition functionDefinition) {
			return $"{this.Line(functionDefinition)}\n {functionDefinition.Name}:\n\n";
		}

		public string Enter(int localBytesSum) {
			return $"\tenter\t{localBytesSum}";
		}


		public string Ret(int bytesReturn, int bytesLocals, int bytesArgs) {
			return $"\tret\t{bytesReturn}, {bytesLocals}, {bytesArgs}";
		}

	
		public string Call(FunctionInvocation functionInvocation) {
			return $"\tcall\t{functionInvocation.Function.Definition.Name}";
		}
	
	
	
	
		// ======================= Type Conversion ======================= //

		
		public string F2I()
		{
			return "\tf2i\n";
		}
	
		public string I2F()
		{
			return "\ti2f\n";
		}
	
	
		public string B2I()
		{
			return "\tb2i\n";
		}
	
		public string I2B()
		{
			return "\ti2b\n";
		}

		
    }
}