namespace Seagull.VM.Commands.Arithmetics
{
	public class CmdAddInt : CmdBinaryOperationInt
	{
		public CmdAddInt() : base((a, b) => a + b)
		{
		}
	}
	
	public class CmdAddDouble : CmdBinaryOperationDouble
	{
		public CmdAddDouble() : base((a, b) => a + b)
		{
		}
	}
}