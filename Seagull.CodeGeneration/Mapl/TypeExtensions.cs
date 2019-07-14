using System;
using Seagull.AST;
using Seagull.AST.Types;

namespace Seagull.CodeGeneration.Mapl
{
	public static class TypeExtensions
	{
		public static string CgConvert(this IType t, IType other)
		{
			return _CgConvert(t, other);
		}
		
		private static string _CgConvert(dynamic t, IType other)
		{
			return CgConvertImpl(t, other);
		}
		
		
		
		
		private static string CgConvertImpl(object t, IType other)
		{
			throw new InvalidOperationException($"Cannot convert {t} to {other}");
		}
		
		private static string CgConvertImpl(CharType t, IType other)
		{
			switch (other.ToString())
			{
				case "int":
				case "bool":
					return MaplCodeGenerator.Instance.B2I();
				case "double":
					return MaplCodeGenerator.Instance.B2I()
					       + MaplCodeGenerator.Instance.I2F();
				case "char": return "";
			}
			throw new InvalidOperationException($"Cannot convert char to {other}");
		}
		
		private static string CgConvertImpl(IntType t, IType other)
		{
			switch (other.ToString())
			{
				case "char":
					return MaplCodeGenerator.Instance.I2B();
				case "double":
					return MaplCodeGenerator.Instance.I2F();
				case "int":
				case "bool":
					return "";
			}
			throw new InvalidOperationException($"Cannot convert int to {other}");
		}
		
		private static string CgConvertImpl(DoubleType t, IType other)
		{
			switch (other.ToString())
			{
				case "int":
				case "bool":
					return MaplCodeGenerator.Instance.F2I();
				case "char":
					return MaplCodeGenerator.Instance.F2I()
					       + MaplCodeGenerator.Instance.I2B();
				case "double": return "";
			}
			throw new InvalidOperationException($"Cannot convert double to {other}");
		}
	}
}