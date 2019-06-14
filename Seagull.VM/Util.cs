using System;

namespace Seagull.VM
{
	public static class Util
	{
		public static int ToInt(byte[] bytes)
		{
			return BitConverter.ToInt32(bytes, 0);
		}
		
		public static byte[] ToBytes(int n)
		{
			return BitConverter.GetBytes(n);
		}

		public static double ToDouble(byte[] bytes)
		{
			return BitConverter.ToDouble(bytes, 0);
		}
		
		public static byte[] ToBytes(double n)
		{
			return BitConverter.GetBytes(n);
		}
	}
}