using System;
using System.IO;
using System.Text;

namespace Discord_Multitool.SpookyDiscord
{
	internal class Misc_Functions
	{
		public static void Load_Config()
		{
			try
			{
				string text = File.ReadAllText("Config.ini");
				Form1.Config.Last_Dir = text.Split(new string[1]
				{
					"Last token directory="
				}, StringSplitOptions.None)[1].Split(new char[1]
				{
					'\n'
				})[0];
			}
			catch
			{
			}
		}

		public static bool LoadHttps()
		{
			try
			{
				foreach (string item in File.ReadLines("./Proxies/https proxies.txt", Encoding.UTF8))
				{
					Form1._Proxies.Https.Add(item);
				}
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Could not load proxies : " + ex.Message);
				return false;
			}
		}

		public static bool LoadSocks4()
		{
			try
			{
				foreach (string item in File.ReadLines("./Proxies/socks4 proxies.txt", Encoding.UTF8))
				{
					Form1._Proxies.Socks4.Add(item);
				}
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Could not load proxies : " + ex.Message);
			}
			return false;
		}

		public static bool LoadSocks5()
		{
			try
			{
				foreach (string item in File.ReadLines("./Proxies/socks5 proxies.txt", Encoding.UTF8))
				{
					Form1._Proxies.Socks5.Add(item);
				}
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Could not load proxies : " + ex.Message);
			}
			return false;
		}

		public static bool LoadCHttps()
		{
			try
			{
				foreach (string item in File.ReadLines("./Proxies/Checked_Https.txt", Encoding.UTF8))
				{
					Form1._Proxies.Https.Add(item);
				}
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Could not load proxies : " + ex.Message);
				return false;
			}
		}

		public static bool LoadCSocks4()
		{
			try
			{
				foreach (string item in File.ReadLines("./Proxies/Checked_Socks4.txt", Encoding.UTF8))
				{
					Form1._Proxies.Socks4.Add(item);
				}
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Could not load proxies : " + ex.Message);
			}
			return false;
		}

		public static bool LoadCSocks5()
		{
			try
			{
				foreach (string item in File.ReadLines("./Proxies/Checked_Socks5.txt", Encoding.UTF8))
				{
					Form1._Proxies.Socks5.Add(item);
				}
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Could not load proxies : " + ex.Message);
			}
			return false;
		}
	}
}
