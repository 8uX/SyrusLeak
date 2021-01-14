using System;
using System.Net;
using System.Windows.Forms;

namespace Discord_Multitool
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			ServicePointManager.set_DefaultConnectionLimit(100000000);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run((Form)(object)new Form1());
		}
	}
}
