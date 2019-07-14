using System;
using Seagull.VM.VMMemory;

namespace Seagull.VM.Commands
{
	public class CmdBinaryOperationInt : ICommand
	{
		private readonly Func<int, int, int> _operation;

		public CmdBinaryOperationInt(Func<int, int, int> operation)
		{
			_operation = operation;
		}
		
		/// <summary>
		/// Pops two integers from the stack. Performs
		/// an operation and pushes the result to the stack.
		/// </summary>
		public void Execute()
		{
			int count = Memory.BYTES_INT;
			byte[] a = Stack.Instance.Pop(count);
			byte[] b = Stack.Instance.Pop(count);

			int result = _operation(Util.ToInt(a),Util.ToInt(b));
			Stack.Instance.Push(Util.ToBytes(result));
		}
	}
}