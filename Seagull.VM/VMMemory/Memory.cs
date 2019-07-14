using System;

namespace Seagull.VM.VMMemory
{
	public class Memory
	{
		public static int BYTES_BOOL => BitConverter.GetBytes(false).Length;
		public static int BYTES_CHAR = 2;
		public static int BYTES_INT = 4;
		public static int BYTES_DOUBLE = 8;
		public static int BYTES_FLOAT => BitConverter.GetBytes(0f).Length;
		
		
		private struct Slot
		{
			public byte Data;
			public bool Busy;
		}
		
		private int Size { get; }
		private readonly Slot[] _memory;

		public Memory(int numberOfBytes)
		{
			_memory = new Slot[numberOfBytes];
			Size = numberOfBytes;

			BitConverter.GetBytes(0f);
		}


		private byte[] Get(int address, int numberOfBytes)
		{
			byte[] bytes = new byte[numberOfBytes];
			for (int i = 0; i < numberOfBytes; i++)
				bytes[i] = _memory[address + i].Data;
			return bytes;
		}
		
		private bool CanSet(int address, int numberOfBytes)
		{
			for (int i = 0; i < numberOfBytes; i++)
				if (_memory[address + i].Busy)
					return false;
			return true;
		}


		private int _firstFreeAddress;
		public int Alloc(int numberOfBytes)
		{
			int result = -1;
			int i = _firstFreeAddress;
			while (i < Size - numberOfBytes)
			{
				if (CanSet(i, numberOfBytes))
				{
					Alloc(i, numberOfBytes);
					return _firstFreeAddress;
				}
				i++;
			}
			return result;
		}

		private void Alloc(int address, int numberOfBytes)
		{
			for (int i = 0; i < numberOfBytes; i++)
			{
				if (i <= _firstFreeAddress)
					_firstFreeAddress = i + 1;
				
				Slot slot = _memory[address + i];
				if (slot.Busy)
					throw new Exception("Cannot alloc. A slot is busy.");
				slot.Busy = true;
			}
		}
		
		private void Free()
		{
			// TODO free memory
		}



		private bool Set(int address, byte[] bytes)
		{
			if (!CanSet(address, bytes.Length))
				return false;
			
			Alloc(address, bytes.Length);
			for (int i = 0; i < bytes.Length; i++)
				_memory[address + i].Data = bytes[i];
			
			return true;
		}
		
		
		
		
		
		
		
		
		
		
		
		
		

		public int GetInt(int address)
		{
			byte[] bytes = Get(address, BYTES_INT);
			return Util.ToInt(bytes);
		}
		
		public bool SetInt(int address, int value)
		{
			return Set(address, BitConverter.GetBytes(value));
		}
		
		
		
		public double GetDouble(int address)
		{
			byte[] bytes = Get(address, BYTES_DOUBLE);
			return Util.ToDouble(bytes);
		}
		
		public bool SetDouble(int address, double value)
		{
			return Set(address, BitConverter.GetBytes(value));
		}
		
		
		
		
		
		
		
	}
}