using System;
using System.Security.Cryptography;
using System.Text;

namespace Discord_Multitool
{
	public static class Encryption
	{
		private static byte[] key = new byte[8]
		{
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8
		};

		private static byte[] iv = new byte[8]
		{
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8
		};

		public static string Crypt(this string text)
		{
			SymmetricAlgorithm val = (SymmetricAlgorithm)(object)DES.Create();
			ICryptoTransform val2 = val.CreateEncryptor(key, iv);
			byte[] bytes = Encoding.Unicode.GetBytes(text);
			byte[] inArray = val2.TransformFinalBlock(bytes, 0, bytes.Length);
			return Convert.ToBase64String(inArray);
		}

		public static string Decrypt(this string text)
		{
			SymmetricAlgorithm val = (SymmetricAlgorithm)(object)DES.Create();
			ICryptoTransform val2 = val.CreateDecryptor(key, iv);
			byte[] array = Convert.FromBase64String(text);
			byte[] bytes = val2.TransformFinalBlock(array, 0, array.Length);
			return Encoding.Unicode.GetString(bytes);
		}
	}
}
