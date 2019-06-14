using System;

namespace Seagull.VM.VMMemory
{
	public class StackException : Exception
	{
		public StackException(string message) : base(message)
		{
			
		}
	}
}