namespace Seagull.VM.VMMemory
{
	public class Stack
	{
		public static Stack Instance
		{
			get
			{
				if (_instance == null)
					_instance = new Stack();
				return _instance;
			}
		}
		private static Stack _instance;



		public const int NumberOfBytes = 256;
		private byte[] _stack;

		public int Top { get; private set; }
		
		

		public Stack()
		{
			Top = 0;
			_stack = new byte[NumberOfBytes];
		}
		


		public void Push(byte[] bytes)
		{
			// TODO exception if overflow
			
			for (int i = 0; i < bytes.Length; i++)
			{
				Top++;
				_stack[Top] = bytes[i];
			}
		}
		
		public byte[] Pop(int numberOfBytes)
		{
			if (numberOfBytes <= 0)
				throw new StackException("Pop must take more than 0 bytes from the stack");
				
			if (numberOfBytes > Top)
			{
				string msg = $"Cannot pop {numberOfBytes} when the Top is at {Top}";
				throw new StackException(msg);
			}

			byte[] result = new byte[numberOfBytes];
			for (int i = 0; i < numberOfBytes; i++)
			{
				result[0] = _stack[Top];
				Top--;
			}

			return result;
		}
		
		
	}
}