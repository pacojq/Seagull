using System;

namespace Seagull.VM.Commands
{
	public class CmdBinaryOperationDouble : ICommand
	{
		private readonly Func<double, double, double> _operation;

		public CmdBinaryOperationDouble(Func<double, double, double> operation)
		{
			_operation = operation;
		}
		
		/// <summary>
		/// Pops two integers from the stack. Performs
		/// an operation and pushes the result to the stack.
		/// </summary>
		public void Execute()
		{
			int count = Memory.BYTES_DOUBLE;
			byte[] a = Stack.Instance.Pop(count);
			byte[] b = Stack.Instance.Pop(count);

			double result = _operation(Util.ToDouble(a),Util.ToDouble(b));
			Stack.Instance.Push(Util.ToBytes(result));
		}
	}
}