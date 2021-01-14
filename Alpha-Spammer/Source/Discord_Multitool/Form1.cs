using Discord_Multitool.Properties;
using Discord_Multitool.SpookyDiscord;
using Discord.WebSocket;
using MetroFramework;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Discord_Multitool
{
	public class Form1 : Form
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct Config
		{
			public static string Last_Dir = null;
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct Attacks_Stats
		{
			public static int Joined = 0;

			public static int Join_Errors = 0;

			public static int Join_Waiting = 0;

			public static int Left = 0;

			public static int Leave_Errors = 0;

			public static int Leave_Waiting = 0;

			public static bool Spam = true;

			public static bool CFMad = false;

			public static int Sent = 0;

			public static int Sent_Errors = 0;

			public static int AddFriend = 0;

			public static int Friend_Error = 0;

			public static int Reacted = 0;

			public static int ReactErrors = 0;
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct _Proxies
		{
			public static List<string> Https = new List<string>();

			public static List<string> Socks4 = new List<string>();

			public static List<string> Socks5 = new List<string>();

			public static List<string> C_Https = new List<string>();

			public static List<string> C_Socks4 = new List<string>();

			public static List<string> C_Socks5 = new List<string>();

			public static int proxytype = 0;

			public static int Bad_Proxies = 0;

			public static int Good_Https = 0;

			public static int Good_Socks4 = 0;

			public static int Good_Socks5 = 0;
		}

		public static List<string> Tokens = new List<string>();

		public static List<DiscordSocketClient> Clients = new List<DiscordSocketClient>();

		public static Thread Workerthread = null;

		public static Thread ProxyCheckerThread;

		public static bool AreTokensAlive = false;

		public static List<Thread> Working_Threads = new List<Thread>();

		public static List<Thread> Alive_Bots = new List<Thread>();

		public static Random rnd = new Random();

		public IContainer components = null;

		private MetroTabControl metroTabControl1;

		private MetroTabPage Settings;

		private MetroTabPage Floods;

		private Panel panel1;

		private MetroTextBox metroTextBox1;

		private MetroButton StartJoinFlood;

		private Label label1;

		private Label label2;

		private MetroButton metroButton1;

		private Panel panel2;

		private Label label5;

		private Label label4;

		private Label label3;

		private MetroButton metroButton2;

		private Panel panel3;

		private Panel panel4;

		private Label label9;

		private MetroButton metroButton3;

		private MetroButton metroButton4;

		private Label label10;

		private MetroTextBox metroTextBox2;

		private Label label6;

		private Label label7;

		private Label label8;

		private Panel panel7;

		private Panel panel8;

		private Label label11;

		private Label label16;

		private Label label17;

		private Label label18;

		private MetroButton metroButton7;

		private MetroButton metroButton8;

		private Label label19;

		private MetroTextBox metroTextBox5;

		private Panel panel5;

		private Panel panel9;

		private RichTextBox richTextBox1;

		private MetroTextBox metroTextBox4;

		private Panel panel6;

		private Label label12;

		private Label label13;

		private Label label14;

		private MetroButton metroButton5;

		private Label label15;

		private MetroTextBox metroTextBox3;

		private MetroButton metroButton6;

		private Panel panel10;

		private Panel panel11;

		private Label label23;

		private Label label24;

		private Label label25;

		private MetroButton metroButton9;

		private MetroButton metroButton10;

		private Label label26;

		private MetroTextBox metroTextBox6;

		private Label label27;

		private Label label29;

		private MetroTextBox metroTextBox7;

		private Label label28;

		private MetroTextBox metroTextBox8;

		private Label label30;

		private Label label22;

		private Button button1;

		private TextBox textBox1;

		private Panel panel12;

		private Panel panel13;

		private Label label20;

		private Label label21;

		private Label label31;

		private MetroButton metroButton11;

		private MetroButton metroButton12;

		public Form1()
			: this()
		{
			InitializeComponent();
			if (Discord_Multitool.Properties.Settings.Default.Code == null)
			{
				Discord_Multitool.Properties.Settings.Default.Code = "code";
			}
			try
			{
				string text = File.ReadAllText("./key.txt");
				string code = text.Decrypt();
				Authorise(code);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			((Control)label30).set_Text("Authorised: " + Discord_Multitool.Properties.Settings.Default.Authorised);
			((Control)textBox1).set_Text(Discord_Multitool.Properties.Settings.Default.Code);
			ServicePointManager.set_DefaultConnectionLimit(99999);
			foreach (string item in File.ReadLines("tokens.txt", Encoding.UTF8))
			{
				Tokens.Add(item);
			}
			((Control)metroButton2).set_Text("Tokens: " + Enumerable.Count<string>((IEnumerable<string>)Tokens));
			((TabControl)metroTabControl1).set_SelectedIndex(0);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void metroButton2_Click(object sender, EventArgs e)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Expected O, but got Unknown
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			OpenFileDialog val = (OpenFileDialog)(object)new OpenFileDialog();
			((FileDialog)val).set_Filter("txt files (*.txt)|*.txt|All files (*.*)|*.*");
			((FileDialog)val).set_CheckFileExists(true);
			((FileDialog)val).set_CheckPathExists(true);
			((CommonDialog)val).ShowDialog();
			try
			{
				foreach (string item in File.ReadLines(((FileDialog)val).get_FileName(), Encoding.UTF8))
				{
					Tokens.Add(item);
				}
				((Control)metroButton2).set_Text("Tokens: " + Enumerable.Count<string>((IEnumerable<string>)Tokens));
			}
			catch
			{
			}
		}

		private void StartJoinFlood_Click(object sender, EventArgs e)
		{
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			Workerthread = null;
			Workerthread = new Thread((ThreadStart)delegate
			{
				Attacks_Stats.Joined = 0;
				Attacks_Stats.Join_Errors = 0;
				Attacks_Stats.Join_Waiting = 0;
				Attacks_Stats.Join_Waiting = Enumerable.Count<string>((IEnumerable<string>)Tokens);
				foreach (string token in Tokens)
				{
					new Thread((ThreadStart)delegate
					{
						//IL_005d: Unknown result type (might be due to invalid IL or missing references)
						//IL_0067: Expected O, but got Unknown
						if (Functions.Join(((Control)metroTextBox1).get_Text(), token))
						{
							Attacks_Stats.Joined++;
						}
						else
						{
							Attacks_Stats.Join_Errors++;
						}
						Attacks_Stats.Join_Waiting--;
						((Control)label3).Invoke((Delegate)(MethodInvoker)delegate
						{
							((Control)label3).set_Text("Joined: " + Attacks_Stats.Joined);
							((Control)label4).set_Text("Errors: " + Attacks_Stats.Join_Errors);
							((Control)label5).set_Text("Waiting: " + Attacks_Stats.Join_Waiting);
						});
					}).Start();
					Thread.Sleep(50);
				}
			});
			if (!Discord_Multitool.Properties.Settings.Default.Authorised)
			{
				MessageBox.Show("Program has not been authorised, DM Draco For An Auth", "Alert");
			}
			else
			{
				Workerthread.Start();
			}
		}

		private void metroButton1_Click(object sender, EventArgs e)
		{
			Workerthread.Abort();
		}

		private void metroButton4_Click(object sender, EventArgs e)
		{
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				Workerthread = null;
				Workerthread = new Thread((ThreadStart)delegate
				{
					Attacks_Stats.Left = 0;
					Attacks_Stats.Leave_Errors = 0;
					Attacks_Stats.Leave_Waiting = 0;
					Attacks_Stats.Leave_Waiting = Enumerable.Count<string>((IEnumerable<string>)Tokens);
					foreach (string token in Tokens)
					{
						new Thread((ThreadStart)delegate
						{
							//IL_005d: Unknown result type (might be due to invalid IL or missing references)
							//IL_0067: Expected O, but got Unknown
							if (Functions.QuitGuild(((Control)metroTextBox2).get_Text(), token))
							{
								Attacks_Stats.Left++;
							}
							else
							{
								Attacks_Stats.Leave_Errors++;
							}
							Attacks_Stats.Leave_Waiting--;
							((Control)label6).Invoke((Delegate)(MethodInvoker)delegate
							{
								((Control)label6).set_Text("Left: " + Attacks_Stats.Left);
								((Control)label7).set_Text("Errors: " + Attacks_Stats.Leave_Errors);
								((Control)label8).set_Text("Waiting: " + Attacks_Stats.Leave_Waiting);
							});
						}).Start();
					}
				});
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			if (!Discord_Multitool.Properties.Settings.Default.Authorised)
			{
				MessageBox.Show("Program has not been authorised, DM Draco For An Auth", "Alert");
			}
			else
			{
				Workerthread.Start();
			}
		}

		private void metroButton6_Click(object sender, EventArgs e)
		{
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				Workerthread = null;
				Attacks_Stats.Spam = true;
				Attacks_Stats.CFMad = false;
				Log("[+] Initializing spammer :)");
				Workerthread = new Thread((ThreadStart)delegate
				{
					//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
					//IL_00bb: Expected O, but got Unknown
					Attacks_Stats.Sent = 0;
					Attacks_Stats.Sent_Errors = 0;
					foreach (string token in Tokens)
					{
						Thread thread = new Thread((ThreadStart)delegate
						{
							//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
							//IL_01b7: Expected O, but got Unknown
							string token2 = token;
							while (true)
							{
								if (!Attacks_Stats.Spam)
								{
									return;
								}
								string text = Functions.sendMessaage(((Control)metroTextBox3).get_Text(), ((Control)metroTextBox4).get_Text(), token2);
								Console.WriteLine(text);
								if (text.Contains("The owner of this website (discordapp.com) has banned you temporarily from accessing this website."))
								{
									Attacks_Stats.Spam = false;
									Attacks_Stats.CFMad = true;
									Thread.Sleep(100);
									stopMessageSpam();
								}
								if (text.Contains("Unauthorized") || text.Contains("You need to verify your account in order to perform this action") || text.Contains("Missing Access"))
								{
									break;
								}
								if (text.Contains("attachments"))
								{
									Log("[+] Successfully sent " + ((Control)metroTextBox4).get_Text() + " to " + ((Control)metroTextBox3).get_Text());
									Attacks_Stats.Sent++;
								}
								if (text.Contains("\"retry_after\": "))
								{
									int millisecondsTimeout = Convert.ToInt32(text.Split(new string[1]
									{
										"\"retry_after\": "
									}, StringSplitOptions.None)[1].Split(new char[1]
									{
										'}'
									})[0]);
									Log("[!] Rate limited, waiting " + millisecondsTimeout + " ms");
									Thread.Sleep(millisecondsTimeout);
								}
								((Control)label13).Invoke((Delegate)(MethodInvoker)delegate
								{
									((Control)label13).set_Text("Sent: " + Attacks_Stats.Sent);
									((Control)label12).set_Text("Errors: " + Attacks_Stats.Sent_Errors);
								});
								Thread.Sleep(150);
							}
							Attacks_Stats.Sent_Errors++;
							Log("[!] Could not join/send message leaving...");
						});
						thread.Start();
						Working_Threads.Add(thread);
						Thread.Sleep(15);
					}
					int lastnumofmessages = default(int);
					while (true)
					{
						lastnumofmessages = Attacks_Stats.Sent;
						Thread.Sleep(1000);
						((Control)label27).Invoke((Delegate)(MethodInvoker)delegate
						{
							((Control)label27).set_Text("MPS: " + (Attacks_Stats.Sent - lastnumofmessages));
						});
					}
				});
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			if (!Discord_Multitool.Properties.Settings.Default.Authorised)
			{
				MessageBox.Show("Program has not been authorised, DM Draco For An Auth", "Alert");
			}
			else
			{
				Workerthread.Start();
			}
		}

		private void metroButton5_Click(object sender, EventArgs e)
		{
			stopMessageSpam();
		}

		private void stopMessageSpam()
		{
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				Attacks_Stats.Spam = false;
				Workerthread.Abort();
				foreach (Thread working_Thread in Working_Threads)
				{
					try
					{
						working_Thread.Abort();
					}
					catch
					{
					}
				}
				Working_Threads.Clear();
				if (Attacks_Stats.CFMad)
				{
					MessageBox.Show("Cloudflare limited :(", "Alert");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private void metroButton8_Click(object sender, EventArgs e)
		{
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			Workerthread = null;
			Workerthread = new Thread((ThreadStart)delegate
			{
				Attacks_Stats.AddFriend = 0;
				Attacks_Stats.Friend_Error = 0;
				Attacks_Stats.Leave_Waiting = Enumerable.Count<string>((IEnumerable<string>)Tokens);
				foreach (string token in Tokens)
				{
					new Thread((ThreadStart)delegate
					{
						//IL_0051: Unknown result type (might be due to invalid IL or missing references)
						//IL_005b: Expected O, but got Unknown
						if (Functions.Add_Friend(((Control)metroTextBox5).get_Text(), token))
						{
							Attacks_Stats.AddFriend++;
						}
						else
						{
							Attacks_Stats.Friend_Error++;
						}
						((Control)label16).Invoke((Delegate)(MethodInvoker)delegate
						{
							((Control)label17).set_Text("Added: " + Attacks_Stats.AddFriend);
							((Control)label16).set_Text("Errors: " + Attacks_Stats.Friend_Error);
						});
					}).Start();
				}
			});
			if (!Discord_Multitool.Properties.Settings.Default.Authorised)
			{
				MessageBox.Show("Program has not been authorised, DM Draco For An Auth", "Alert");
			}
			else
			{
				Workerthread.Start();
			}
		}

		private void metroButton7_Click(object sender, EventArgs e)
		{
			Workerthread.Abort();
		}

		private void Proxies_Click(object sender, EventArgs e)
		{
		}

		private void Log(string text)
		{
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			((Control)richTextBox1).Invoke((Delegate)(MethodInvoker)delegate
			{
				((TextBoxBase)richTextBox1).AppendText(text + "\r\n");
				((TextBoxBase)richTextBox1).ScrollToCaret();
			});
		}

		private void metroButton10_Click(object sender, EventArgs e)
		{
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			Workerthread = null;
			Workerthread = new Thread((ThreadStart)delegate
			{
				Attacks_Stats.Reacted = 0;
				Attacks_Stats.ReactErrors = 0;
				foreach (string token in Tokens)
				{
					new Thread((ThreadStart)delegate
					{
						//IL_0071: Unknown result type (might be due to invalid IL or missing references)
						//IL_007b: Expected O, but got Unknown
						if (Functions.AddReaction(((Control)metroTextBox6).get_Text(), ((Control)metroTextBox7).get_Text(), ((Control)metroTextBox8).get_Text(), token))
						{
							Attacks_Stats.Reacted++;
						}
						else
						{
							Attacks_Stats.ReactErrors++;
						}
						((Control)label16).Invoke((Delegate)(MethodInvoker)delegate
						{
							((Control)label24).set_Text("Reacted: " + Attacks_Stats.Reacted);
							((Control)label16).set_Text("Errors: " + Attacks_Stats.Friend_Error);
						});
					}).Start();
				}
			});
			if (!Discord_Multitool.Properties.Settings.Default.Authorised)
			{
				MessageBox.Show("Program has not been authorised, DM Draco For An Auth", "Alert");
			}
			else
			{
				Workerthread.Start();
			}
		}

		private void metroButton9_Click(object sender, EventArgs e)
		{
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			Workerthread = null;
			Workerthread = new Thread((ThreadStart)delegate
			{
				Attacks_Stats.Reacted = 0;
				Attacks_Stats.ReactErrors = 0;
				foreach (string token in Tokens)
				{
					new Thread((ThreadStart)delegate
					{
						//IL_0071: Unknown result type (might be due to invalid IL or missing references)
						//IL_007b: Expected O, but got Unknown
						if (Functions.RemoveReaction(((Control)metroTextBox6).get_Text(), ((Control)metroTextBox7).get_Text(), ((Control)metroTextBox8).get_Text(), token))
						{
							Attacks_Stats.Reacted++;
						}
						else
						{
							Attacks_Stats.ReactErrors++;
						}
						((Control)label16).Invoke((Delegate)(MethodInvoker)delegate
						{
							((Control)label24).set_Text("Removed: " + Attacks_Stats.Reacted);
							((Control)label16).set_Text("Errors: " + Attacks_Stats.Friend_Error);
						});
					}).Start();
				}
			});
			if (!Discord_Multitool.Properties.Settings.Default.Authorised)
			{
				MessageBox.Show("Program has not been authorised, DM Draco For An Auth", "Alert");
			}
			else
			{
				Workerthread.Start();
			}
		}

		private void Floods_Click(object sender, EventArgs e)
		{
		}

		private void metroTextBox10_Click(object sender, EventArgs e)
		{
		}

		private void Authorise(string code)
		{
			try
			{
				string[] array = code.Split(new char[1]
				{
					'-'
				});
				ulong num = 0uL;
				string[] array2 = array;
				foreach (string text in array2)
				{
					Console.WriteLine(text);
					byte[] bytes = Encoding.Default.GetBytes(text);
					string text2 = BitConverter.ToString(bytes);
					text2 = text2.Replace("-", "");
					ulong num2 = ulong.Parse(text2, NumberStyles.HexNumber);
					num += num2;
				}
				Console.WriteLine("total " + num);
				if (num == 2349400061u)
				{
					Discord_Multitool.Properties.Settings.Default.Authorised = true;
					((Control)label30).set_Text("Authorised: " + Discord_Multitool.Properties.Settings.Default.Authorised);
					string text3 = code.Crypt();
					File.WriteAllText("./key.txt", text3);
				}
				else
				{
					Discord_Multitool.Properties.Settings.Default.Authorised = false;
					((Control)label30).set_Text("Authorised: " + Discord_Multitool.Properties.Settings.Default.Authorised);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			string text = ((Control)textBox1).get_Text();
			Authorise(text);
		}

		private void metroButton12_Click(object sender, EventArgs e)
		{
			foreach (string token in Tokens)
			{
				Thread thread = new Thread((ThreadStart)async delegate
				{
					DiscordSocketClient client = await Functions.Revive_Bot(token);
					if (!Clients.Contains(client))
					{
						Clients.Add(client);
					}
					Thread.Sleep(-1);
				});
				thread.Start();
				Alive_Bots.Add(thread);
			}
			AreTokensAlive = true;
		}

		private void metroButton11_Click(object sender, EventArgs e)
		{
			foreach (Thread alive_Bot in Alive_Bots)
			{
				alive_Bot.Abort();
			}
		}

		private void metroButton13_Click(object sender, EventArgs e)
		{
			stopMessageSpam();
		}

		private void label32_Click(object sender, EventArgs e)
		{
		}

		private void metroTextBox9_Click(object sender, EventArgs e)
		{
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				((IDisposable)components).Dispose();
			}
			((Form)this).Dispose(disposing);
		}

		public void InitializeComponent()
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Expected O, but got Unknown
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Expected O, but got Unknown
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Expected O, but got Unknown
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Expected O, but got Unknown
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Expected O, but got Unknown
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Expected O, but got Unknown
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Expected O, but got Unknown
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Expected O, but got Unknown
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Expected O, but got Unknown
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Expected O, but got Unknown
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Expected O, but got Unknown
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Expected O, but got Unknown
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Expected O, but got Unknown
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Expected O, but got Unknown
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Expected O, but got Unknown
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Expected O, but got Unknown
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Expected O, but got Unknown
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Expected O, but got Unknown
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Expected O, but got Unknown
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Expected O, but got Unknown
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Expected O, but got Unknown
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Expected O, but got Unknown
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Expected O, but got Unknown
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Expected O, but got Unknown
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Expected O, but got Unknown
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_015b: Expected O, but got Unknown
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Expected O, but got Unknown
			//IL_0167: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Expected O, but got Unknown
			//IL_0172: Unknown result type (might be due to invalid IL or missing references)
			//IL_017c: Expected O, but got Unknown
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Expected O, but got Unknown
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Expected O, but got Unknown
			//IL_0193: Unknown result type (might be due to invalid IL or missing references)
			//IL_019d: Expected O, but got Unknown
			//IL_019e: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a8: Expected O, but got Unknown
			//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b3: Expected O, but got Unknown
			//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Expected O, but got Unknown
			//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c9: Expected O, but got Unknown
			//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d4: Expected O, but got Unknown
			//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01df: Expected O, but got Unknown
			//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ea: Expected O, but got Unknown
			//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f5: Expected O, but got Unknown
			//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0200: Expected O, but got Unknown
			//IL_0201: Unknown result type (might be due to invalid IL or missing references)
			//IL_020b: Expected O, but got Unknown
			//IL_020c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0216: Expected O, but got Unknown
			//IL_0217: Unknown result type (might be due to invalid IL or missing references)
			//IL_0221: Expected O, but got Unknown
			//IL_0222: Unknown result type (might be due to invalid IL or missing references)
			//IL_022c: Expected O, but got Unknown
			//IL_022d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0237: Expected O, but got Unknown
			//IL_0238: Unknown result type (might be due to invalid IL or missing references)
			//IL_0242: Expected O, but got Unknown
			//IL_0243: Unknown result type (might be due to invalid IL or missing references)
			//IL_024d: Expected O, but got Unknown
			//IL_024e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0258: Expected O, but got Unknown
			//IL_0259: Unknown result type (might be due to invalid IL or missing references)
			//IL_0263: Expected O, but got Unknown
			//IL_0264: Unknown result type (might be due to invalid IL or missing references)
			//IL_026e: Expected O, but got Unknown
			//IL_026f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0279: Expected O, but got Unknown
			//IL_027a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0284: Expected O, but got Unknown
			//IL_0285: Unknown result type (might be due to invalid IL or missing references)
			//IL_028f: Expected O, but got Unknown
			//IL_0290: Unknown result type (might be due to invalid IL or missing references)
			//IL_029a: Expected O, but got Unknown
			//IL_029b: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a5: Expected O, but got Unknown
			//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b0: Expected O, but got Unknown
			//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bb: Expected O, but got Unknown
			//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c6: Expected O, but got Unknown
			//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d1: Expected O, but got Unknown
			//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02dc: Expected O, but got Unknown
			//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e7: Expected O, but got Unknown
			//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f2: Expected O, but got Unknown
			//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fd: Expected O, but got Unknown
			//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0308: Expected O, but got Unknown
			//IL_0309: Unknown result type (might be due to invalid IL or missing references)
			//IL_0313: Expected O, but got Unknown
			//IL_0314: Unknown result type (might be due to invalid IL or missing references)
			//IL_031e: Expected O, but got Unknown
			//IL_0428: Unknown result type (might be due to invalid IL or missing references)
			//IL_0461: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_0572: Unknown result type (might be due to invalid IL or missing references)
			//IL_059e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0676: Unknown result type (might be due to invalid IL or missing references)
			//IL_069f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0715: Unknown result type (might be due to invalid IL or missing references)
			//IL_073b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0773: Unknown result type (might be due to invalid IL or missing references)
			//IL_077d: Expected O, but got Unknown
			//IL_0784: Unknown result type (might be due to invalid IL or missing references)
			//IL_0798: Unknown result type (might be due to invalid IL or missing references)
			//IL_07be: Unknown result type (might be due to invalid IL or missing references)
			//IL_0807: Unknown result type (might be due to invalid IL or missing references)
			//IL_0811: Expected O, but got Unknown
			//IL_0818: Unknown result type (might be due to invalid IL or missing references)
			//IL_082c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0852: Unknown result type (might be due to invalid IL or missing references)
			//IL_089b: Unknown result type (might be due to invalid IL or missing references)
			//IL_08a5: Expected O, but got Unknown
			//IL_08ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_08bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_08e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0917: Unknown result type (might be due to invalid IL or missing references)
			//IL_0940: Unknown result type (might be due to invalid IL or missing references)
			//IL_09a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_09cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b2a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b56: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b8e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0bbe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c2f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c56: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ce2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d2e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d4b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d55: Expected O, but got Unknown
			//IL_0d76: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d80: Expected O, but got Unknown
			//IL_0d87: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d9c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0dc2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e0b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e3b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0eac: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ed3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f5f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0faa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0fc7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0fd1: Expected O, but got Unknown
			//IL_0ff2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ffc: Expected O, but got Unknown
			//IL_1003: Unknown result type (might be due to invalid IL or missing references)
			//IL_1017: Unknown result type (might be due to invalid IL or missing references)
			//IL_103d: Unknown result type (might be due to invalid IL or missing references)
			//IL_10ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_10d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_110c: Unknown result type (might be due to invalid IL or missing references)
			//IL_1116: Expected O, but got Unknown
			//IL_111d: Unknown result type (might be due to invalid IL or missing references)
			//IL_1131: Unknown result type (might be due to invalid IL or missing references)
			//IL_1157: Unknown result type (might be due to invalid IL or missing references)
			//IL_11a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_11ab: Expected O, but got Unknown
			//IL_11b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_11c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_11eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_1235: Unknown result type (might be due to invalid IL or missing references)
			//IL_123f: Expected O, but got Unknown
			//IL_1246: Unknown result type (might be due to invalid IL or missing references)
			//IL_125a: Unknown result type (might be due to invalid IL or missing references)
			//IL_1280: Unknown result type (might be due to invalid IL or missing references)
			//IL_12b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_12df: Unknown result type (might be due to invalid IL or missing references)
			//IL_1344: Unknown result type (might be due to invalid IL or missing references)
			//IL_136d: Unknown result type (might be due to invalid IL or missing references)
			//IL_13e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_13f2: Expected O, but got Unknown
			//IL_13f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_140d: Unknown result type (might be due to invalid IL or missing references)
			//IL_1433: Unknown result type (might be due to invalid IL or missing references)
			//IL_147c: Unknown result type (might be due to invalid IL or missing references)
			//IL_14ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_151d: Unknown result type (might be due to invalid IL or missing references)
			//IL_1544: Unknown result type (might be due to invalid IL or missing references)
			//IL_15d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_161b: Unknown result type (might be due to invalid IL or missing references)
			//IL_1638: Unknown result type (might be due to invalid IL or missing references)
			//IL_1642: Expected O, but got Unknown
			//IL_16e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_1713: Unknown result type (might be due to invalid IL or missing references)
			//IL_174e: Unknown result type (might be due to invalid IL or missing references)
			//IL_177e: Unknown result type (might be due to invalid IL or missing references)
			//IL_17ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_1816: Unknown result type (might be due to invalid IL or missing references)
			//IL_18a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_18ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_190a: Unknown result type (might be due to invalid IL or missing references)
			//IL_1914: Expected O, but got Unknown
			//IL_1974: Unknown result type (might be due to invalid IL or missing references)
			//IL_199a: Unknown result type (might be due to invalid IL or missing references)
			//IL_19d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_19dc: Expected O, but got Unknown
			//IL_19e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_19f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_1a1d: Unknown result type (might be due to invalid IL or missing references)
			//IL_1a67: Unknown result type (might be due to invalid IL or missing references)
			//IL_1a71: Expected O, but got Unknown
			//IL_1a78: Unknown result type (might be due to invalid IL or missing references)
			//IL_1a8c: Unknown result type (might be due to invalid IL or missing references)
			//IL_1ab2: Unknown result type (might be due to invalid IL or missing references)
			//IL_1afc: Unknown result type (might be due to invalid IL or missing references)
			//IL_1b06: Expected O, but got Unknown
			//IL_1b0d: Unknown result type (might be due to invalid IL or missing references)
			//IL_1b20: Unknown result type (might be due to invalid IL or missing references)
			//IL_1b46: Unknown result type (might be due to invalid IL or missing references)
			//IL_1b90: Unknown result type (might be due to invalid IL or missing references)
			//IL_1b9a: Expected O, but got Unknown
			//IL_1ba1: Unknown result type (might be due to invalid IL or missing references)
			//IL_1bb5: Unknown result type (might be due to invalid IL or missing references)
			//IL_1bdb: Unknown result type (might be due to invalid IL or missing references)
			//IL_1c0e: Unknown result type (might be due to invalid IL or missing references)
			//IL_1c37: Unknown result type (might be due to invalid IL or missing references)
			//IL_1c9c: Unknown result type (might be due to invalid IL or missing references)
			//IL_1cc5: Unknown result type (might be due to invalid IL or missing references)
			//IL_1d40: Unknown result type (might be due to invalid IL or missing references)
			//IL_1d4a: Expected O, but got Unknown
			//IL_1d51: Unknown result type (might be due to invalid IL or missing references)
			//IL_1d65: Unknown result type (might be due to invalid IL or missing references)
			//IL_1d8b: Unknown result type (might be due to invalid IL or missing references)
			//IL_1e85: Unknown result type (might be due to invalid IL or missing references)
			//IL_1eb1: Unknown result type (might be due to invalid IL or missing references)
			//IL_1eec: Unknown result type (might be due to invalid IL or missing references)
			//IL_1f1c: Unknown result type (might be due to invalid IL or missing references)
			//IL_1f8d: Unknown result type (might be due to invalid IL or missing references)
			//IL_1fb4: Unknown result type (might be due to invalid IL or missing references)
			//IL_2040: Unknown result type (might be due to invalid IL or missing references)
			//IL_208b: Unknown result type (might be due to invalid IL or missing references)
			//IL_20a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_20b2: Expected O, but got Unknown
			//IL_20e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_210f: Unknown result type (might be due to invalid IL or missing references)
			//IL_2134: Unknown result type (might be due to invalid IL or missing references)
			//IL_215f: Unknown result type (might be due to invalid IL or missing references)
			//IL_2169: Expected O, but got Unknown
			//IL_2170: Unknown result type (might be due to invalid IL or missing references)
			//IL_2184: Unknown result type (might be due to invalid IL or missing references)
			//IL_21bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_2209: Unknown result type (might be due to invalid IL or missing references)
			//IL_2239: Unknown result type (might be due to invalid IL or missing references)
			//IL_22aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_22d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_2369: Unknown result type (might be due to invalid IL or missing references)
			//IL_23b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_23d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_23db: Expected O, but got Unknown
			//IL_243b: Unknown result type (might be due to invalid IL or missing references)
			//IL_2461: Unknown result type (might be due to invalid IL or missing references)
			//IL_2499: Unknown result type (might be due to invalid IL or missing references)
			//IL_24a3: Expected O, but got Unknown
			//IL_24aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_24be: Unknown result type (might be due to invalid IL or missing references)
			//IL_24e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_252d: Unknown result type (might be due to invalid IL or missing references)
			//IL_2537: Expected O, but got Unknown
			//IL_253e: Unknown result type (might be due to invalid IL or missing references)
			//IL_2552: Unknown result type (might be due to invalid IL or missing references)
			//IL_2578: Unknown result type (might be due to invalid IL or missing references)
			//IL_25c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_25cb: Expected O, but got Unknown
			//IL_25d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_25e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_260b: Unknown result type (might be due to invalid IL or missing references)
			//IL_2654: Unknown result type (might be due to invalid IL or missing references)
			//IL_265e: Expected O, but got Unknown
			//IL_2665: Unknown result type (might be due to invalid IL or missing references)
			//IL_2678: Unknown result type (might be due to invalid IL or missing references)
			//IL_26a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_26da: Unknown result type (might be due to invalid IL or missing references)
			//IL_2703: Unknown result type (might be due to invalid IL or missing references)
			//IL_276a: Unknown result type (might be due to invalid IL or missing references)
			//IL_2793: Unknown result type (might be due to invalid IL or missing references)
			//IL_280e: Unknown result type (might be due to invalid IL or missing references)
			//IL_2818: Expected O, but got Unknown
			//IL_281f: Unknown result type (might be due to invalid IL or missing references)
			//IL_2833: Unknown result type (might be due to invalid IL or missing references)
			//IL_2859: Unknown result type (might be due to invalid IL or missing references)
			//IL_2926: Unknown result type (might be due to invalid IL or missing references)
			//IL_2952: Unknown result type (might be due to invalid IL or missing references)
			//IL_298d: Unknown result type (might be due to invalid IL or missing references)
			//IL_29bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_2a2e: Unknown result type (might be due to invalid IL or missing references)
			//IL_2a55: Unknown result type (might be due to invalid IL or missing references)
			//IL_2ae1: Unknown result type (might be due to invalid IL or missing references)
			//IL_2b2c: Unknown result type (might be due to invalid IL or missing references)
			//IL_2b49: Unknown result type (might be due to invalid IL or missing references)
			//IL_2b53: Expected O, but got Unknown
			//IL_2bb3: Unknown result type (might be due to invalid IL or missing references)
			//IL_2bd9: Unknown result type (might be due to invalid IL or missing references)
			//IL_2c11: Unknown result type (might be due to invalid IL or missing references)
			//IL_2c1b: Expected O, but got Unknown
			//IL_2c22: Unknown result type (might be due to invalid IL or missing references)
			//IL_2c36: Unknown result type (might be due to invalid IL or missing references)
			//IL_2c5c: Unknown result type (might be due to invalid IL or missing references)
			//IL_2ca6: Unknown result type (might be due to invalid IL or missing references)
			//IL_2cb0: Expected O, but got Unknown
			//IL_2cb7: Unknown result type (might be due to invalid IL or missing references)
			//IL_2ccb: Unknown result type (might be due to invalid IL or missing references)
			//IL_2cf1: Unknown result type (might be due to invalid IL or missing references)
			//IL_2d3b: Unknown result type (might be due to invalid IL or missing references)
			//IL_2d45: Expected O, but got Unknown
			//IL_2d4c: Unknown result type (might be due to invalid IL or missing references)
			//IL_2d5f: Unknown result type (might be due to invalid IL or missing references)
			//IL_2d85: Unknown result type (might be due to invalid IL or missing references)
			//IL_2dcf: Unknown result type (might be due to invalid IL or missing references)
			//IL_2dd9: Expected O, but got Unknown
			//IL_2de0: Unknown result type (might be due to invalid IL or missing references)
			//IL_2df4: Unknown result type (might be due to invalid IL or missing references)
			//IL_2e1a: Unknown result type (might be due to invalid IL or missing references)
			//IL_2e4d: Unknown result type (might be due to invalid IL or missing references)
			//IL_2e76: Unknown result type (might be due to invalid IL or missing references)
			//IL_2ec3: Unknown result type (might be due to invalid IL or missing references)
			//IL_2eec: Unknown result type (might be due to invalid IL or missing references)
			//IL_2f67: Unknown result type (might be due to invalid IL or missing references)
			//IL_2f71: Expected O, but got Unknown
			//IL_2f78: Unknown result type (might be due to invalid IL or missing references)
			//IL_2f8c: Unknown result type (might be due to invalid IL or missing references)
			//IL_2fb2: Unknown result type (might be due to invalid IL or missing references)
			//IL_307c: Unknown result type (might be due to invalid IL or missing references)
			//IL_30a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_311f: Unknown result type (might be due to invalid IL or missing references)
			//IL_3145: Unknown result type (might be due to invalid IL or missing references)
			//IL_317d: Unknown result type (might be due to invalid IL or missing references)
			//IL_3187: Expected O, but got Unknown
			//IL_318e: Unknown result type (might be due to invalid IL or missing references)
			//IL_31a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_31c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_3211: Unknown result type (might be due to invalid IL or missing references)
			//IL_321b: Expected O, but got Unknown
			//IL_3222: Unknown result type (might be due to invalid IL or missing references)
			//IL_3236: Unknown result type (might be due to invalid IL or missing references)
			//IL_325c: Unknown result type (might be due to invalid IL or missing references)
			//IL_32a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_32af: Expected O, but got Unknown
			//IL_32b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_32c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_32ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_3338: Unknown result type (might be due to invalid IL or missing references)
			//IL_3342: Expected O, but got Unknown
			//IL_3349: Unknown result type (might be due to invalid IL or missing references)
			//IL_335d: Unknown result type (might be due to invalid IL or missing references)
			//IL_3383: Unknown result type (might be due to invalid IL or missing references)
			//IL_33b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_33df: Unknown result type (might be due to invalid IL or missing references)
			//IL_3444: Unknown result type (might be due to invalid IL or missing references)
			//IL_346d: Unknown result type (might be due to invalid IL or missing references)
			//IL_34e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_34f2: Expected O, but got Unknown
			//IL_34f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_350d: Unknown result type (might be due to invalid IL or missing references)
			//IL_3533: Unknown result type (might be due to invalid IL or missing references)
			//IL_357c: Unknown result type (might be due to invalid IL or missing references)
			//IL_35ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_361d: Unknown result type (might be due to invalid IL or missing references)
			//IL_3644: Unknown result type (might be due to invalid IL or missing references)
			//IL_36d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_371b: Unknown result type (might be due to invalid IL or missing references)
			//IL_3738: Unknown result type (might be due to invalid IL or missing references)
			//IL_3742: Expected O, but got Unknown
			//IL_374f: Unknown result type (might be due to invalid IL or missing references)
			//IL_37d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_37fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_386a: Unknown result type (might be due to invalid IL or missing references)
			//IL_3893: Unknown result type (might be due to invalid IL or missing references)
			//IL_38f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_38ff: Expected O, but got Unknown
			//IL_3910: Unknown result type (might be due to invalid IL or missing references)
			//IL_3939: Unknown result type (might be due to invalid IL or missing references)
			//IL_396d: Unknown result type (might be due to invalid IL or missing references)
			//IL_3996: Unknown result type (might be due to invalid IL or missing references)
			//IL_3a11: Unknown result type (might be due to invalid IL or missing references)
			//IL_3a1b: Expected O, but got Unknown
			//IL_3a22: Unknown result type (might be due to invalid IL or missing references)
			//IL_3a3a: Unknown result type (might be due to invalid IL or missing references)
			//IL_3a60: Unknown result type (might be due to invalid IL or missing references)
			//IL_3aaa: Unknown result type (might be due to invalid IL or missing references)
			//IL_3ab4: Expected O, but got Unknown
			//IL_3abb: Unknown result type (might be due to invalid IL or missing references)
			//IL_3ad6: Unknown result type (might be due to invalid IL or missing references)
			//IL_3aff: Unknown result type (might be due to invalid IL or missing references)
			//IL_3b34: Unknown result type (might be due to invalid IL or missing references)
			//IL_3b4e: Unknown result type (might be due to invalid IL or missing references)
			//IL_3b64: Unknown result type (might be due to invalid IL or missing references)
			//IL_3bb9: Unknown result type (might be due to invalid IL or missing references)
			//IL_3bc3: Expected O, but got Unknown
			ComponentResourceManager val = (ComponentResourceManager)(object)new ComponentResourceManager(typeof(Form1));
			metroTabControl1 = (MetroTabControl)(object)new MetroTabControl();
			Floods = (MetroTabPage)(object)new MetroTabPage();
			panel12 = (Panel)(object)new Panel();
			panel13 = (Panel)(object)new Panel();
			label20 = (Label)(object)new Label();
			label21 = (Label)(object)new Label();
			label31 = (Label)(object)new Label();
			metroButton11 = (MetroButton)(object)new MetroButton();
			metroButton12 = (MetroButton)(object)new MetroButton();
			panel10 = (Panel)(object)new Panel();
			metroTextBox8 = (MetroTextBox)(object)new MetroTextBox();
			label29 = (Label)(object)new Label();
			metroTextBox7 = (MetroTextBox)(object)new MetroTextBox();
			label28 = (Label)(object)new Label();
			panel11 = (Panel)(object)new Panel();
			label23 = (Label)(object)new Label();
			label24 = (Label)(object)new Label();
			label25 = (Label)(object)new Label();
			metroButton9 = (MetroButton)(object)new MetroButton();
			metroButton10 = (MetroButton)(object)new MetroButton();
			label26 = (Label)(object)new Label();
			metroTextBox6 = (MetroTextBox)(object)new MetroTextBox();
			panel7 = (Panel)(object)new Panel();
			metroTextBox5 = (MetroTextBox)(object)new MetroTextBox();
			panel8 = (Panel)(object)new Panel();
			label11 = (Label)(object)new Label();
			label16 = (Label)(object)new Label();
			label17 = (Label)(object)new Label();
			label18 = (Label)(object)new Label();
			metroButton7 = (MetroButton)(object)new MetroButton();
			metroButton8 = (MetroButton)(object)new MetroButton();
			label19 = (Label)(object)new Label();
			panel5 = (Panel)(object)new Panel();
			metroTextBox3 = (MetroTextBox)(object)new MetroTextBox();
			panel9 = (Panel)(object)new Panel();
			richTextBox1 = (RichTextBox)(object)new RichTextBox();
			metroTextBox4 = (MetroTextBox)(object)new MetroTextBox();
			panel6 = (Panel)(object)new Panel();
			label27 = (Label)(object)new Label();
			label12 = (Label)(object)new Label();
			label13 = (Label)(object)new Label();
			label14 = (Label)(object)new Label();
			metroButton5 = (MetroButton)(object)new MetroButton();
			metroButton6 = (MetroButton)(object)new MetroButton();
			label15 = (Label)(object)new Label();
			panel3 = (Panel)(object)new Panel();
			metroTextBox2 = (MetroTextBox)(object)new MetroTextBox();
			panel4 = (Panel)(object)new Panel();
			label8 = (Label)(object)new Label();
			label7 = (Label)(object)new Label();
			label6 = (Label)(object)new Label();
			label9 = (Label)(object)new Label();
			metroButton3 = (MetroButton)(object)new MetroButton();
			metroButton4 = (MetroButton)(object)new MetroButton();
			label10 = (Label)(object)new Label();
			panel1 = (Panel)(object)new Panel();
			panel2 = (Panel)(object)new Panel();
			label5 = (Label)(object)new Label();
			label4 = (Label)(object)new Label();
			label3 = (Label)(object)new Label();
			label2 = (Label)(object)new Label();
			metroButton1 = (MetroButton)(object)new MetroButton();
			StartJoinFlood = (MetroButton)(object)new MetroButton();
			label1 = (Label)(object)new Label();
			metroTextBox1 = (MetroTextBox)(object)new MetroTextBox();
			Settings = (MetroTabPage)(object)new MetroTabPage();
			button1 = (Button)(object)new Button();
			textBox1 = (TextBox)(object)new TextBox();
			metroButton2 = (MetroButton)(object)new MetroButton();
			label30 = (Label)(object)new Label();
			label22 = (Label)(object)new Label();
			((Control)metroTabControl1).SuspendLayout();
			((Control)Floods).SuspendLayout();
			((Control)panel12).SuspendLayout();
			((Control)panel13).SuspendLayout();
			((Control)panel10).SuspendLayout();
			((Control)panel11).SuspendLayout();
			((Control)panel7).SuspendLayout();
			((Control)panel8).SuspendLayout();
			((Control)panel5).SuspendLayout();
			((Control)panel9).SuspendLayout();
			((Control)panel6).SuspendLayout();
			((Control)panel3).SuspendLayout();
			((Control)panel4).SuspendLayout();
			((Control)panel1).SuspendLayout();
			((Control)panel2).SuspendLayout();
			((Control)Settings).SuspendLayout();
			((Control)this).SuspendLayout();
			((Control)metroTabControl1).get_Controls().Add((Control)(object)Floods);
			((Control)metroTabControl1).get_Controls().Add((Control)(object)Settings);
			metroTabControl1.set_FontWeight((MetroTabControlWeight)2);
			((Control)metroTabControl1).set_Location(new Point(-1, 0));
			((Control)metroTabControl1).set_Name("metroTabControl1");
			((TabControl)metroTabControl1).set_SelectedIndex(0);
			((Control)metroTabControl1).set_Size(new Size(961, 500));
			metroTabControl1.set_Style((MetroColorStyle)3);
			((Control)metroTabControl1).set_TabIndex(0);
			metroTabControl1.set_Theme((MetroThemeStyle)2);
			metroTabControl1.set_UseSelectable(true);
			((Control)Floods).set_BackColor(Color.FromArgb(31, 31, 31));
			((Control)Floods).get_Controls().Add((Control)(object)panel12);
			((Control)Floods).get_Controls().Add((Control)(object)panel10);
			((Control)Floods).get_Controls().Add((Control)(object)panel7);
			((Control)Floods).get_Controls().Add((Control)(object)panel5);
			((Control)Floods).get_Controls().Add((Control)(object)panel3);
			((Control)Floods).get_Controls().Add((Control)(object)panel1);
			Floods.set_HorizontalScrollbarBarColor(true);
			Floods.set_HorizontalScrollbarHighlightOnWheel(false);
			Floods.set_HorizontalScrollbarSize(10);
			((TabPage)Floods).set_Location(new Point(4, 38));
			((Control)Floods).set_Name("Floods");
			((Control)Floods).set_Size(new Size(953, 458));
			((TabPage)Floods).set_TabIndex(1);
			((Control)Floods).set_Text("Floods");
			Floods.set_UseCustomBackColor(true);
			Floods.set_VerticalScrollbarBarColor(true);
			Floods.set_VerticalScrollbarHighlightOnWheel(false);
			Floods.set_VerticalScrollbarSize(10);
			((Control)Floods).add_Click((EventHandler)Floods_Click);
			panel12.set_BorderStyle((BorderStyle)1);
			((Control)panel12).get_Controls().Add((Control)(object)panel13);
			((Control)panel12).get_Controls().Add((Control)(object)metroButton11);
			((Control)panel12).get_Controls().Add((Control)(object)metroButton12);
			((Control)panel12).set_Location(new Point(554, 207));
			((Control)panel12).set_Name("panel12");
			((Control)panel12).set_Size(new Size(285, 73));
			((Control)panel12).set_TabIndex(6);
			panel13.set_BorderStyle((BorderStyle)1);
			((Control)panel13).get_Controls().Add((Control)(object)label20);
			((Control)panel13).get_Controls().Add((Control)(object)label21);
			((Control)panel13).get_Controls().Add((Control)(object)label31);
			((Control)panel13).set_Location(new Point(144, 8));
			((Control)panel13).set_Name("panel13");
			((Control)panel13).set_Size(new Size(91, 52));
			((Control)panel13).set_TabIndex(5);
			((Control)label20).set_AutoSize(true);
			((Control)label20).set_Font((Font)(object)new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)label20).set_ForeColor(Color.get_White());
			((Control)label20).set_Location(new Point(3, 33));
			((Control)label20).set_Name("label20");
			((Control)label20).set_Size(new Size(56, 14));
			((Control)label20).set_TabIndex(8);
			((Control)label20).set_Text("Waiting: ");
			((Control)label21).set_AutoSize(true);
			((Control)label21).set_Font((Font)(object)new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)label21).set_ForeColor(Color.get_White());
			((Control)label21).set_Location(new Point(3, 17));
			((Control)label21).set_Name("label21");
			((Control)label21).set_Size(new Size(46, 14));
			((Control)label21).set_TabIndex(7);
			((Control)label21).set_Text("Errors: ");
			((Control)label31).set_AutoSize(true);
			((Control)label31).set_Font((Font)(object)new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)label31).set_ForeColor(Color.get_White());
			((Control)label31).set_Location(new Point(3, 3));
			((Control)label31).set_Name("label31");
			((Control)label31).set_Size(new Size(40, 14));
			((Control)label31).set_TabIndex(6);
			((Control)label31).set_Text("Alive: ");
			((Control)metroButton11).set_Location(new Point(3, 37));
			((Control)metroButton11).set_Name("metroButton11");
			((Control)metroButton11).set_Size(new Size(135, 23));
			((Control)metroButton11).set_TabIndex(3);
			((Control)metroButton11).set_Text("Kill Bots");
			metroButton11.set_Theme((MetroThemeStyle)2);
			metroButton11.set_UseSelectable(true);
			((Control)metroButton11).add_Click((EventHandler)metroButton11_Click);
			((Control)metroButton12).set_Location(new Point(3, 8));
			((Control)metroButton12).set_Name("metroButton12");
			((Control)metroButton12).set_Size(new Size(135, 23));
			((Control)metroButton12).set_TabIndex(2);
			((Control)metroButton12).set_Text("Revive Bots");
			metroButton12.set_Theme((MetroThemeStyle)2);
			metroButton12.set_UseSelectable(true);
			((Control)metroButton12).add_Click((EventHandler)metroButton12_Click);
			panel10.set_BorderStyle((BorderStyle)1);
			((Control)panel10).get_Controls().Add((Control)(object)metroTextBox8);
			((Control)panel10).get_Controls().Add((Control)(object)label29);
			((Control)panel10).get_Controls().Add((Control)(object)metroTextBox7);
			((Control)panel10).get_Controls().Add((Control)(object)label28);
			((Control)panel10).get_Controls().Add((Control)(object)panel11);
			((Control)panel10).get_Controls().Add((Control)(object)label25);
			((Control)panel10).get_Controls().Add((Control)(object)metroButton9);
			((Control)panel10).get_Controls().Add((Control)(object)metroButton10);
			((Control)panel10).get_Controls().Add((Control)(object)label26);
			((Control)panel10).get_Controls().Add((Control)(object)metroTextBox6);
			((Control)panel10).set_Location(new Point(297, 207));
			((Control)panel10).set_Name("panel10");
			((Control)panel10).set_Size(new Size(247, 180));
			((Control)panel10).set_TabIndex(8);
			metroTextBox8.get_CustomButton().set_Image((Image)null);
			((Control)metroTextBox8.get_CustomButton()).set_Location(new Point(123, 1));
			((Control)metroTextBox8.get_CustomButton()).set_Name("");
			((Control)metroTextBox8.get_CustomButton()).set_Size(new Size(21, 21));
			metroTextBox8.get_CustomButton().set_Style((MetroColorStyle)4);
			((Control)metroTextBox8.get_CustomButton()).set_TabIndex(1);
			metroTextBox8.get_CustomButton().set_Theme((MetroThemeStyle)1);
			metroTextBox8.get_CustomButton().set_UseSelectable(true);
			((Control)metroTextBox8.get_CustomButton()).set_Visible(false);
			((Control)metroTextBox8).set_ForeColor(Color.FromArgb(31, 31, 31));
			metroTextBox8.set_Lines(new string[0]);
			((Control)metroTextBox8).set_Location(new Point(91, 85));
			metroTextBox8.set_MaxLength(32767);
			((Control)metroTextBox8).set_Name("metroTextBox8");
			metroTextBox8.set_PasswordChar('\0');
			metroTextBox8.set_ScrollBars((ScrollBars)0);
			metroTextBox8.set_SelectedText("");
			metroTextBox8.set_SelectionLength(0);
			metroTextBox8.set_SelectionStart(0);
			metroTextBox8.set_ShortcutsEnabled(true);
			((Control)metroTextBox8).set_Size(new Size(145, 23));
			metroTextBox8.set_Style((MetroColorStyle)1);
			((Control)metroTextBox8).set_TabIndex(9);
			metroTextBox8.set_Theme((MetroThemeStyle)2);
			metroTextBox8.set_UseSelectable(true);
			metroTextBox8.set_WaterMarkColor(Color.FromArgb(109, 109, 109));
			metroTextBox8.set_WaterMarkFont((Font)(object)new Font("Segoe UI", 12f, (FontStyle)2, (GraphicsUnit)2));
			((Control)label29).set_AutoSize(true);
			((Control)label29).set_Font((Font)(object)new Font("Tahoma", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)label29).set_ForeColor(Color.get_White());
			((Control)label29).set_Location(new Point(12, 90));
			((Control)label29).set_Name("label29");
			((Control)label29).set_Size(new Size(73, 18));
			((Control)label29).set_TabIndex(8);
			((Control)label29).set_Text("Reaction: ");
			metroTextBox7.get_CustomButton().set_Image((Image)null);
			((Control)metroTextBox7.get_CustomButton()).set_Location(new Point(123, 1));
			((Control)metroTextBox7.get_CustomButton()).set_Name("");
			((Control)metroTextBox7.get_CustomButton()).set_Size(new Size(21, 21));
			metroTextBox7.get_CustomButton().set_Style((MetroColorStyle)4);
			((Control)metroTextBox7.get_CustomButton()).set_TabIndex(1);
			metroTextBox7.get_CustomButton().set_Theme((MetroThemeStyle)1);
			metroTextBox7.get_CustomButton().set_UseSelectable(true);
			((Control)metroTextBox7.get_CustomButton()).set_Visible(false);
			((Control)metroTextBox7).set_ForeColor(Color.FromArgb(31, 31, 31));
			metroTextBox7.set_Lines(new string[0]);
			((Control)metroTextBox7).set_Location(new Point(91, 62));
			metroTextBox7.set_MaxLength(32767);
			((Control)metroTextBox7).set_Name("metroTextBox7");
			metroTextBox7.set_PasswordChar('\0');
			metroTextBox7.set_ScrollBars((ScrollBars)0);
			metroTextBox7.set_SelectedText("");
			metroTextBox7.set_SelectionLength(0);
			metroTextBox7.set_SelectionStart(0);
			metroTextBox7.set_ShortcutsEnabled(true);
			((Control)metroTextBox7).set_Size(new Size(145, 23));
			metroTextBox7.set_Style((MetroColorStyle)1);
			((Control)metroTextBox7).set_TabIndex(6);
			metroTextBox7.set_Theme((MetroThemeStyle)2);
			metroTextBox7.set_UseSelectable(true);
			metroTextBox7.set_WaterMarkColor(Color.FromArgb(109, 109, 109));
			metroTextBox7.set_WaterMarkFont((Font)(object)new Font("Segoe UI", 12f, (FontStyle)2, (GraphicsUnit)2));
			((Control)label28).set_AutoSize(true);
			((Control)label28).set_Font((Font)(object)new Font("Tahoma", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)label28).set_ForeColor(Color.get_White());
			((Control)label28).set_Location(new Point(3, 62));
			((Control)label28).set_Name("label28");
			((Control)label28).set_Size(new Size(97, 18));
			((Control)label28).set_TabIndex(7);
			((Control)label28).set_Text("Message ID: ");
			panel11.set_BorderStyle((BorderStyle)1);
			((Control)panel11).get_Controls().Add((Control)(object)label23);
			((Control)panel11).get_Controls().Add((Control)(object)label24);
			((Control)panel11).set_Location(new Point(150, 115));
			((Control)panel11).set_Name("panel11");
			((Control)panel11).set_Size(new Size(86, 52));
			((Control)panel11).set_TabIndex(5);
			((Control)label23).set_AutoSize(true);
			((Control)label23).set_Font((Font)(object)new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)label23).set_ForeColor(Color.get_White());
			((Control)label23).set_Location(new Point(3, 28));
			((Control)label23).set_Name("label23");
			((Control)label23).set_Size(new Size(46, 14));
			((Control)label23).set_TabIndex(9);
			((Control)label23).set_Text("Errors: ");
			((Control)label24).set_AutoSize(true);
			((Control)label24).set_Font((Font)(object)new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)label24).set_ForeColor(Color.get_White());
			((Control)label24).set_Location(new Point(3, 8));
			((Control)label24).set_Name("label24");
			((Control)label24).set_Size(new Size(60, 14));
			((Control)label24).set_TabIndex(9);
			((Control)label24).set_Text("Reacted: ");
			((Control)label25).set_AutoSize(true);
			((Control)label25).set_Font((Font)(object)new Font("Tahoma", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0));
			((Control)label25).set_ForeColor(Color.get_White());
			((Control)label25).set_Location(new Point(50, 8));
			((Control)label25).set_Name("label25");
			((Control)label25).set_Size(new Size(119, 18));
			((Control)label25).set_TabIndex(4);
			((Control)label25).set_Text("Reaction Flood");
			((Control)metroButton9).set_Location(new Point(9, 144));
			((Control)metroButton9).set_Name("metroButton9");
			((Control)metroButton9).set_Size(new Size(135, 23));
			((Control)metroButton9).set_TabIndex(3);
			((Control)metroButton9).set_Text("Remove");
			metroButton9.set_Theme((MetroThemeStyle)2);
			metroButton9.set_UseSelectable(true);
			((Control)metroButton9).add_Click((EventHandler)metroButton9_Click);
			((Control)metroButton10).set_Location(new Point(9, 115));
			((Control)metroButton10).set_Name("metroButton10");
			((Control)metroButton10).set_Size(new Size(135, 23));
			((Control)metroButton10).set_TabIndex(2);
			((Control)metroButton10).set_Text("Add");
			metroButton10.set_Theme((MetroThemeStyle)2);
			metroButton10.set_UseSelectable(true);
			((Control)metroButton10).add_Click((EventHandler)metroButton10_Click);
			((Control)label26).set_AutoSize(true);
			((Control)label26).set_Font((Font)(object)new Font("Tahoma", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)label26).set_ForeColor(Color.get_White());
			((Control)label26).set_Location(new Point(6, 33));
			((Control)label26).set_Name("label26");
			((Control)label26).set_Size(new Size(85, 18));
			((Control)label26).set_TabIndex(1);
			((Control)label26).set_Text("Channel ID:");
			metroTextBox6.get_CustomButton().set_Image((Image)null);
			((Control)metroTextBox6.get_CustomButton()).set_Location(new Point(120, 1));
			((Control)metroTextBox6.get_CustomButton()).set_Name("");
			((Control)metroTextBox6.get_CustomButton()).set_Size(new Size(21, 21));
			metroTextBox6.get_CustomButton().set_Style((MetroColorStyle)4);
			((Control)metroTextBox6.get_CustomButton()).set_TabIndex(1);
			metroTextBox6.get_CustomButton().set_Theme((MetroThemeStyle)1);
			metroTextBox6.get_CustomButton().set_UseSelectable(true);
			((Control)metroTextBox6.get_CustomButton()).set_Visible(false);
			((Control)metroTextBox6).set_ForeColor(Color.FromArgb(31, 31, 31));
			metroTextBox6.set_Lines(new string[0]);
			((Control)metroTextBox6).set_Location(new Point(94, 33));
			metroTextBox6.set_MaxLength(32767);
			((Control)metroTextBox6).set_Name("metroTextBox6");
			metroTextBox6.set_PasswordChar('\0');
			metroTextBox6.set_ScrollBars((ScrollBars)0);
			metroTextBox6.set_SelectedText("");
			metroTextBox6.set_SelectionLength(0);
			metroTextBox6.set_SelectionStart(0);
			metroTextBox6.set_ShortcutsEnabled(true);
			((Control)metroTextBox6).set_Size(new Size(142, 23));
			metroTextBox6.set_Style((MetroColorStyle)1);
			((Control)metroTextBox6).set_TabIndex(0);
			metroTextBox6.set_Theme((MetroThemeStyle)2);
			metroTextBox6.set_UseSelectable(true);
			metroTextBox6.set_WaterMarkColor(Color.FromArgb(109, 109, 109));
			metroTextBox6.set_WaterMarkFont((Font)(object)new Font("Segoe UI", 12f, (FontStyle)2, (GraphicsUnit)2));
			panel7.set_BorderStyle((BorderStyle)1);
			((Control)panel7).get_Controls().Add((Control)(object)metroTextBox5);
			((Control)panel7).get_Controls().Add((Control)(object)panel8);
			((Control)panel7).get_Controls().Add((Control)(object)label18);
			((Control)panel7).get_Controls().Add((Control)(object)metroButton7);
			((Control)panel7).get_Controls().Add((Control)(object)metroButton8);
			((Control)panel7).get_Controls().Add((Control)(object)label19);
			((Control)panel7).set_Location(new Point(9, 283));
			((Control)panel7).set_Name("panel7");
			((Control)panel7).set_Size(new Size(282, 129));
			((Control)panel7).set_TabIndex(7);
			metroTextBox5.get_CustomButton().set_Image((Image)null);
			((Control)metroTextBox5.get_CustomButton()).set_Location(new Point(158, 1));
			((Control)metroTextBox5.get_CustomButton()).set_Name("");
			((Control)metroTextBox5.get_CustomButton()).set_Size(new Size(21, 21));
			metroTextBox5.get_CustomButton().set_Style((MetroColorStyle)4);
			((Control)metroTextBox5.get_CustomButton()).set_TabIndex(1);
			metroTextBox5.get_CustomButton().set_Theme((MetroThemeStyle)1);
			metroTextBox5.get_CustomButton().set_UseSelectable(true);
			((Control)metroTextBox5.get_CustomButton()).set_Visible(false);
			((Control)metroTextBox5).set_ForeColor(Color.FromArgb(31, 31, 31));
			metroTextBox5.set_Lines(new string[0]);
			((Control)metroTextBox5).set_Location(new Point(86, 29));
			metroTextBox5.set_MaxLength(32767);
			((Control)metroTextBox5).set_Name("metroTextBox5");
			metroTextBox5.set_PasswordChar('\0');
			metroTextBox5.set_ScrollBars((ScrollBars)0);
			metroTextBox5.set_SelectedText("");
			metroTextBox5.set_SelectionLength(0);
			metroTextBox5.set_SelectionStart(0);
			metroTextBox5.set_ShortcutsEnabled(true);
			((Control)metroTextBox5).set_Size(new Size(180, 23));
			metroTextBox5.set_Style((MetroColorStyle)1);
			((Control)metroTextBox5).set_TabIndex(0);
			metroTextBox5.set_Theme((MetroThemeStyle)2);
			metroTextBox5.set_UseSelectable(true);
			metroTextBox5.set_WaterMarkColor(Color.FromArgb(109, 109, 109));
			metroTextBox5.set_WaterMarkFont((Font)(object)new Font("Segoe UI", 12f, (FontStyle)2, (GraphicsUnit)2));
			panel8.set_BorderStyle((BorderStyle)1);
			((Control)panel8).get_Controls().Add((Control)(object)label11);
			((Control)panel8).get_Controls().Add((Control)(object)label16);
			((Control)panel8).get_Controls().Add((Control)(object)label17);
			((Control)panel8).set_Location(new Point(150, 58));
			((Control)panel8).set_Name("panel8");
			((Control)panel8).set_Size(new Size(116, 61));
			((Control)panel8).set_TabIndex(5);
			((Control)label11).set_AutoSize(true);
			((Control)label11).set_Font((Font)(object)new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)label11).set_ForeColor(Color.get_White());
			((Control)label11).set_Location(new Point(3, 36));
			((Control)label11).set_Name("label11");
			((Control)label11).set_Size(new Size(56, 14));
			((Control)label11).set_TabIndex(9);
			((Control)label11).set_Text("Waiting: ");
			((Control)label16).set_AutoSize(true);
			((Control)label16).set_Font((Font)(object)new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)label16).set_ForeColor(Color.get_White());
			((Control)label16).set_Location(new Point(3, 22));
			((Control)label16).set_Name("label16");
			((Control)label16).set_Size(new Size(46, 14));
			((Control)label16).set_TabIndex(9);
			((Control)label16).set_Text("Errors: ");
			((Control)label17).set_AutoSize(true);
			((Control)label17).set_Font((Font)(object)new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)label17).set_ForeColor(Color.get_White());
			((Control)label17).set_Location(new Point(3, 8));
			((Control)label17).set_Name("label17");
			((Control)label17).set_Size(new Size(51, 14));
			((Control)label17).set_TabIndex(9);
			((Control)label17).set_Text("Added: ");
			((Control)label18).set_AutoSize(true);
			((Control)label18).set_Font((Font)(object)new Font("Tahoma", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0));
			((Control)label18).set_ForeColor(Color.get_White());
			((Control)label18).set_Location(new Point(64, 6));
			((Control)label18).set_Name("label18");
			((Control)label18).set_Size(new Size(127, 18));
			((Control)label18).set_TabIndex(4);
			((Control)label18).set_Text("Add friend flood");
			((Control)metroButton7).set_Location(new Point(9, 96));
			((Control)metroButton7).set_Name("metroButton7");
			((Control)metroButton7).set_Size(new Size(135, 23));
			((Control)metroButton7).set_TabIndex(3);
			((Control)metroButton7).set_Text("Stop");
			metroButton7.set_Theme((MetroThemeStyle)2);
			metroButton7.set_UseSelectable(true);
			((Control)metroButton7).add_Click((EventHandler)metroButton7_Click);
			((Control)metroButton8).set_Location(new Point(9, 67));
			((Control)metroButton8).set_Name("metroButton8");
			((Control)metroButton8).set_Size(new Size(135, 23));
			((Control)metroButton8).set_TabIndex(2);
			((Control)metroButton8).set_Text("Start");
			metroButton8.set_Theme((MetroThemeStyle)2);
			metroButton8.set_UseSelectable(true);
			((Control)metroButton8).add_Click((EventHandler)metroButton8_Click);
			((Control)label19).set_AutoSize(true);
			((Control)label19).set_Font((Font)(object)new Font("Tahoma", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)label19).set_ForeColor(Color.get_White());
			((Control)label19).set_Location(new Point(7, 29));
			((Control)label19).set_Name("label19");
			((Control)label19).set_Size(new Size(78, 18));
			((Control)label19).set_TabIndex(1);
			((Control)label19).set_Text("Friend ID: ");
			panel5.set_BorderStyle((BorderStyle)1);
			((Control)panel5).get_Controls().Add((Control)(object)metroTextBox3);
			((Control)panel5).get_Controls().Add((Control)(object)panel9);
			((Control)panel5).get_Controls().Add((Control)(object)metroTextBox4);
			((Control)panel5).get_Controls().Add((Control)(object)panel6);
			((Control)panel5).get_Controls().Add((Control)(object)label14);
			((Control)panel5).get_Controls().Add((Control)(object)metroButton5);
			((Control)panel5).get_Controls().Add((Control)(object)metroButton6);
			((Control)panel5).get_Controls().Add((Control)(object)label15);
			((Control)panel5).set_Location(new Point(297, 3));
			((Control)panel5).set_Name("panel5");
			((Control)panel5).set_Size(new Size(644, 194));
			((Control)panel5).set_TabIndex(6);
			metroTextBox3.get_CustomButton().set_Image((Image)null);
			((Control)metroTextBox3.get_CustomButton()).set_Location(new Point(158, 1));
			((Control)metroTextBox3.get_CustomButton()).set_Name("");
			((Control)metroTextBox3.get_CustomButton()).set_Size(new Size(21, 21));
			metroTextBox3.get_CustomButton().set_Style((MetroColorStyle)4);
			((Control)metroTextBox3.get_CustomButton()).set_TabIndex(1);
			metroTextBox3.get_CustomButton().set_Theme((MetroThemeStyle)1);
			metroTextBox3.get_CustomButton().set_UseSelectable(true);
			((Control)metroTextBox3.get_CustomButton()).set_Visible(false);
			((Control)metroTextBox3).set_ForeColor(Color.FromArgb(31, 31, 31));
			metroTextBox3.set_Lines(new string[0]);
			((Control)metroTextBox3).set_Location(new Point(91, 117));
			metroTextBox3.set_MaxLength(32767);
			((Control)metroTextBox3).set_Name("metroTextBox3");
			metroTextBox3.set_PasswordChar('\0');
			metroTextBox3.set_ScrollBars((ScrollBars)0);
			metroTextBox3.set_SelectedText("");
			metroTextBox3.set_SelectionLength(0);
			metroTextBox3.set_SelectionStart(0);
			metroTextBox3.set_ShortcutsEnabled(true);
			((Control)metroTextBox3).set_Size(new Size(180, 23));
			metroTextBox3.set_Style((MetroColorStyle)1);
			((Control)metroTextBox3).set_TabIndex(0);
			metroTextBox3.set_Theme((MetroThemeStyle)2);
			metroTextBox3.set_UseSelectable(true);
			metroTextBox3.set_WaterMarkColor(Color.FromArgb(109, 109, 109));
			metroTextBox3.set_WaterMarkFont((Font)(object)new Font("Segoe UI", 12f, (FontStyle)2, (GraphicsUnit)2));
			panel9.set_BorderStyle((BorderStyle)1);
			((Control)panel9).get_Controls().Add((Control)(object)richTextBox1);
			((Control)panel9).set_Location(new Point(382, 3));
			((Control)panel9).set_Name("panel9");
			((Control)panel9).set_Size(new Size(257, 184));
			((Control)panel9).set_TabIndex(9);
			((Control)richTextBox1).set_BackColor(Color.FromArgb(25, 25, 25));
			((TextBoxBase)richTextBox1).set_BorderStyle((BorderStyle)0);
			((Control)richTextBox1).set_Font((Font)(object)new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)richTextBox1).set_ForeColor(SystemColors.get_Info());
			((Control)richTextBox1).set_Location(new Point(-1, -2));
			((Control)richTextBox1).set_Name("richTextBox1");
			((TextBoxBase)richTextBox1).set_ReadOnly(true);
			((Control)richTextBox1).set_Size(new Size(257, 185));
			((Control)richTextBox1).set_TabIndex(8);
			((Control)richTextBox1).set_Text("");
			metroTextBox4.get_CustomButton().set_Image((Image)null);
			((Control)metroTextBox4.get_CustomButton()).set_Location(new Point(298, 2));
			((Control)metroTextBox4.get_CustomButton()).set_Name("");
			((Control)metroTextBox4.get_CustomButton()).set_Size(new Size(69, 69));
			metroTextBox4.get_CustomButton().set_Style((MetroColorStyle)4);
			((Control)metroTextBox4.get_CustomButton()).set_TabIndex(1);
			metroTextBox4.get_CustomButton().set_Theme((MetroThemeStyle)1);
			metroTextBox4.get_CustomButton().set_UseSelectable(true);
			((Control)metroTextBox4.get_CustomButton()).set_Visible(false);
			((Control)metroTextBox4).set_ForeColor(Color.FromArgb(31, 31, 31));
			metroTextBox4.set_Lines(new string[0]);
			((Control)metroTextBox4).set_Location(new Point(6, 31));
			metroTextBox4.set_MaxLength(32767);
			metroTextBox4.set_Multiline(true);
			((Control)metroTextBox4).set_Name("metroTextBox4");
			metroTextBox4.set_PasswordChar('\0');
			metroTextBox4.set_ScrollBars((ScrollBars)0);
			metroTextBox4.set_SelectedText("");
			metroTextBox4.set_SelectionLength(0);
			metroTextBox4.set_SelectionStart(0);
			metroTextBox4.set_ShortcutsEnabled(true);
			((Control)metroTextBox4).set_Size(new Size(370, 74));
			metroTextBox4.set_Style((MetroColorStyle)1);
			((Control)metroTextBox4).set_TabIndex(6);
			metroTextBox4.set_Theme((MetroThemeStyle)2);
			metroTextBox4.set_UseSelectable(true);
			metroTextBox4.set_WaterMarkColor(Color.FromArgb(109, 109, 109));
			metroTextBox4.set_WaterMarkFont((Font)(object)new Font("Segoe UI", 12f, (FontStyle)2, (GraphicsUnit)2));
			panel6.set_BorderStyle((BorderStyle)1);
			((Control)panel6).get_Controls().Add((Control)(object)label27);
			((Control)panel6).get_Controls().Add((Control)(object)label12);
			((Control)panel6).get_Controls().Add((Control)(object)label13);
			((Control)panel6).set_Location(new Point(277, 117));
			((Control)panel6).set_Name("panel6");
			((Control)panel6).set_Size(new Size(99, 70));
			((Control)panel6).set_TabIndex(5);
			((Control)label27).set_AutoSize(true);
			((Control)label27).set_Font((Font)(object)new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)label27).set_ForeColor(Color.get_White());
			((Control)label27).set_Location(new Point(3, 47));
			((Control)label27).set_Name("label27");
			((Control)label27).set_Size(new Size(38, 14));
			((Control)label27).set_TabIndex(8);
			((Control)label27).set_Text("MPS: ");
			((Control)label12).set_AutoSize(true);
			((Control)label12).set_Font((Font)(object)new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)label12).set_ForeColor(Color.get_White());
			((Control)label12).set_Location(new Point(3, 24));
			((Control)label12).set_Name("label12");
			((Control)label12).set_Size(new Size(46, 14));
			((Control)label12).set_TabIndex(7);
			((Control)label12).set_Text("Errors: ");
			((Control)label13).set_AutoSize(true);
			((Control)label13).set_Font((Font)(object)new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)label13).set_ForeColor(Color.get_White());
			((Control)label13).set_Location(new Point(3, 6));
			((Control)label13).set_Name("label13");
			((Control)label13).set_Size(new Size(41, 14));
			((Control)label13).set_TabIndex(6);
			((Control)label13).set_Text("Sent: ");
			((Control)label14).set_AutoSize(true);
			((Control)label14).set_Font((Font)(object)new Font("Tahoma", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0));
			((Control)label14).set_ForeColor(Color.get_White());
			((Control)label14).set_Location(new Point(3, 3));
			((Control)label14).set_Name("label14");
			((Control)label14).set_Size(new Size(147, 18));
			((Control)label14).set_TabIndex(4);
			((Control)label14).set_Text("Message Spammer");
			((Control)metroButton5).set_Location(new Point(141, 152));
			((Control)metroButton5).set_Name("metroButton5");
			((Control)metroButton5).set_Size(new Size(130, 32));
			((Control)metroButton5).set_TabIndex(3);
			((Control)metroButton5).set_Text("Stop");
			metroButton5.set_Theme((MetroThemeStyle)2);
			metroButton5.set_UseSelectable(true);
			((Control)metroButton5).add_Click((EventHandler)metroButton5_Click);
			((Control)metroButton6).set_Location(new Point(6, 152));
			((Control)metroButton6).set_Name("metroButton6");
			((Control)metroButton6).set_Size(new Size(128, 32));
			((Control)metroButton6).set_TabIndex(2);
			((Control)metroButton6).set_Text("Start");
			metroButton6.set_Theme((MetroThemeStyle)2);
			metroButton6.set_UseSelectable(true);
			((Control)metroButton6).add_Click((EventHandler)metroButton6_Click);
			((Control)label15).set_AutoSize(true);
			((Control)label15).set_Font((Font)(object)new Font("Tahoma", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)label15).set_ForeColor(Color.get_White());
			((Control)label15).set_Location(new Point(3, 120));
			((Control)label15).set_Name("label15");
			((Control)label15).set_Size(new Size(90, 18));
			((Control)label15).set_TabIndex(1);
			((Control)label15).set_Text("Channel ID :");
			panel3.set_BorderStyle((BorderStyle)1);
			((Control)panel3).get_Controls().Add((Control)(object)metroTextBox2);
			((Control)panel3).get_Controls().Add((Control)(object)panel4);
			((Control)panel3).get_Controls().Add((Control)(object)label9);
			((Control)panel3).get_Controls().Add((Control)(object)metroButton3);
			((Control)panel3).get_Controls().Add((Control)(object)metroButton4);
			((Control)panel3).get_Controls().Add((Control)(object)label10);
			((Control)panel3).set_Location(new Point(9, 148));
			((Control)panel3).set_Name("panel3");
			((Control)panel3).set_Size(new Size(282, 129));
			((Control)panel3).set_TabIndex(6);
			metroTextBox2.get_CustomButton().set_Image((Image)null);
			((Control)metroTextBox2.get_CustomButton()).set_Location(new Point(158, 1));
			((Control)metroTextBox2.get_CustomButton()).set_Name("");
			((Control)metroTextBox2.get_CustomButton()).set_Size(new Size(21, 21));
			metroTextBox2.get_CustomButton().set_Style((MetroColorStyle)4);
			((Control)metroTextBox2.get_CustomButton()).set_TabIndex(1);
			metroTextBox2.get_CustomButton().set_Theme((MetroThemeStyle)1);
			metroTextBox2.get_CustomButton().set_UseSelectable(true);
			((Control)metroTextBox2.get_CustomButton()).set_Visible(false);
			((Control)metroTextBox2).set_ForeColor(Color.FromArgb(31, 31, 31));
			metroTextBox2.set_Lines(new string[0]);
			((Control)metroTextBox2).set_Location(new Point(86, 29));
			metroTextBox2.set_MaxLength(32767);
			((Control)metroTextBox2).set_Name("metroTextBox2");
			metroTextBox2.set_PasswordChar('\0');
			metroTextBox2.set_ScrollBars((ScrollBars)0);
			metroTextBox2.set_SelectedText("");
			metroTextBox2.set_SelectionLength(0);
			metroTextBox2.set_SelectionStart(0);
			metroTextBox2.set_ShortcutsEnabled(true);
			((Control)metroTextBox2).set_Size(new Size(180, 23));
			metroTextBox2.set_Style((MetroColorStyle)1);
			((Control)metroTextBox2).set_TabIndex(0);
			metroTextBox2.set_Theme((MetroThemeStyle)2);
			metroTextBox2.set_UseSelectable(true);
			metroTextBox2.set_WaterMarkColor(Color.FromArgb(109, 109, 109));
			metroTextBox2.set_WaterMarkFont((Font)(object)new Font("Segoe UI", 12f, (FontStyle)2, (GraphicsUnit)2));
			panel4.set_BorderStyle((BorderStyle)1);
			((Control)panel4).get_Controls().Add((Control)(object)label8);
			((Control)panel4).get_Controls().Add((Control)(object)label7);
			((Control)panel4).get_Controls().Add((Control)(object)label6);
			((Control)panel4).set_Location(new Point(150, 58));
			((Control)panel4).set_Name("panel4");
			((Control)panel4).set_Size(new Size(116, 61));
			((Control)panel4).set_TabIndex(5);
			((Control)label8).set_AutoSize(true);
			((Control)label8).set_Font((Font)(object)new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)label8).set_ForeColor(Color.get_White());
			((Control)label8).set_Location(new Point(3, 36));
			((Control)label8).set_Name("label8");
			((Control)label8).set_Size(new Size(56, 14));
			((Control)label8).set_TabIndex(9);
			((Control)label8).set_Text("Waiting: ");
			((Control)label7).set_AutoSize(true);
			((Control)label7).set_Font((Font)(object)new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)label7).set_ForeColor(Color.get_White());
			((Control)label7).set_Location(new Point(3, 22));
			((Control)label7).set_Name("label7");
			((Control)label7).set_Size(new Size(46, 14));
			((Control)label7).set_TabIndex(9);
			((Control)label7).set_Text("Errors: ");
			((Control)label6).set_AutoSize(true);
			((Control)label6).set_Font((Font)(object)new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)label6).set_ForeColor(Color.get_White());
			((Control)label6).set_Location(new Point(3, 8));
			((Control)label6).set_Name("label6");
			((Control)label6).set_Size(new Size(37, 14));
			((Control)label6).set_TabIndex(9);
			((Control)label6).set_Text("Left: ");
			((Control)label9).set_AutoSize(true);
			((Control)label9).set_Font((Font)(object)new Font("Tahoma", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0));
			((Control)label9).set_ForeColor(Color.get_White());
			((Control)label9).set_Location(new Point(84, 3));
			((Control)label9).set_Name("label9");
			((Control)label9).set_Size(new Size(98, 18));
			((Control)label9).set_TabIndex(4);
			((Control)label9).set_Text("Leave Flood");
			((Control)metroButton3).set_Location(new Point(9, 96));
			((Control)metroButton3).set_Name("metroButton3");
			((Control)metroButton3).set_Size(new Size(135, 23));
			((Control)metroButton3).set_TabIndex(3);
			((Control)metroButton3).set_Text("Stop");
			metroButton3.set_Theme((MetroThemeStyle)2);
			metroButton3.set_UseSelectable(true);
			((Control)metroButton4).set_Location(new Point(9, 67));
			((Control)metroButton4).set_Name("metroButton4");
			((Control)metroButton4).set_Size(new Size(135, 23));
			((Control)metroButton4).set_TabIndex(2);
			((Control)metroButton4).set_Text("Start");
			metroButton4.set_Theme((MetroThemeStyle)2);
			metroButton4.set_UseSelectable(true);
			((Control)metroButton4).add_Click((EventHandler)metroButton4_Click);
			((Control)label10).set_AutoSize(true);
			((Control)label10).set_Font((Font)(object)new Font("Tahoma", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)label10).set_ForeColor(Color.get_White());
			((Control)label10).set_Location(new Point(7, 29));
			((Control)label10).set_Name("label10");
			((Control)label10).set_Size(new Size(81, 18));
			((Control)label10).set_TabIndex(1);
			((Control)label10).set_Text("Server ID :");
			panel1.set_BorderStyle((BorderStyle)1);
			((Control)panel1).get_Controls().Add((Control)(object)panel2);
			((Control)panel1).get_Controls().Add((Control)(object)label2);
			((Control)panel1).get_Controls().Add((Control)(object)metroButton1);
			((Control)panel1).get_Controls().Add((Control)(object)StartJoinFlood);
			((Control)panel1).get_Controls().Add((Control)(object)label1);
			((Control)panel1).get_Controls().Add((Control)(object)metroTextBox1);
			((Control)panel1).set_Location(new Point(9, 13));
			((Control)panel1).set_Name("panel1");
			((Control)panel1).set_Size(new Size(282, 129));
			((Control)panel1).set_TabIndex(3);
			panel2.set_BorderStyle((BorderStyle)1);
			((Control)panel2).get_Controls().Add((Control)(object)label5);
			((Control)panel2).get_Controls().Add((Control)(object)label4);
			((Control)panel2).get_Controls().Add((Control)(object)label3);
			((Control)panel2).set_Location(new Point(150, 58));
			((Control)panel2).set_Name("panel2");
			((Control)panel2).set_Size(new Size(87, 61));
			((Control)panel2).set_TabIndex(5);
			((Control)label5).set_AutoSize(true);
			((Control)label5).set_Font((Font)(object)new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)label5).set_ForeColor(Color.get_White());
			((Control)label5).set_Location(new Point(3, 37));
			((Control)label5).set_Name("label5");
			((Control)label5).set_Size(new Size(56, 14));
			((Control)label5).set_TabIndex(8);
			((Control)label5).set_Text("Waiting: ");
			((Control)label4).set_AutoSize(true);
			((Control)label4).set_Font((Font)(object)new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)label4).set_ForeColor(Color.get_White());
			((Control)label4).set_Location(new Point(3, 22));
			((Control)label4).set_Name("label4");
			((Control)label4).set_Size(new Size(46, 14));
			((Control)label4).set_TabIndex(7);
			((Control)label4).set_Text("Errors: ");
			((Control)label3).set_AutoSize(true);
			((Control)label3).set_Font((Font)(object)new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)label3).set_ForeColor(Color.get_White());
			((Control)label3).set_Location(new Point(3, 8));
			((Control)label3).set_Name("label3");
			((Control)label3).set_Size(new Size(50, 14));
			((Control)label3).set_TabIndex(6);
			((Control)label3).set_Text("Joined: ");
			((Control)label2).set_AutoSize(true);
			((Control)label2).set_Font((Font)(object)new Font("Tahoma", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0));
			((Control)label2).set_ForeColor(Color.get_White());
			((Control)label2).set_Location(new Point(64, 0));
			((Control)label2).set_Name("label2");
			((Control)label2).set_Size(new Size(84, 18));
			((Control)label2).set_TabIndex(4);
			((Control)label2).set_Text("Join Flood");
			((Control)metroButton1).set_Location(new Point(9, 96));
			((Control)metroButton1).set_Name("metroButton1");
			((Control)metroButton1).set_Size(new Size(135, 23));
			((Control)metroButton1).set_TabIndex(3);
			((Control)metroButton1).set_Text("Stop");
			metroButton1.set_Theme((MetroThemeStyle)2);
			metroButton1.set_UseSelectable(true);
			((Control)metroButton1).add_Click((EventHandler)metroButton1_Click);
			((Control)StartJoinFlood).set_Location(new Point(9, 67));
			((Control)StartJoinFlood).set_Name("StartJoinFlood");
			((Control)StartJoinFlood).set_Size(new Size(135, 23));
			((Control)StartJoinFlood).set_TabIndex(2);
			((Control)StartJoinFlood).set_Text("Start");
			StartJoinFlood.set_Theme((MetroThemeStyle)2);
			StartJoinFlood.set_UseSelectable(true);
			((Control)StartJoinFlood).add_Click((EventHandler)StartJoinFlood_Click);
			((Control)label1).set_AutoSize(true);
			((Control)label1).set_Font((Font)(object)new Font("Tahoma", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)label1).set_ForeColor(Color.get_White());
			((Control)label1).set_Location(new Point(7, 31));
			((Control)label1).set_Name("label1");
			((Control)label1).set_Size(new Size(91, 18));
			((Control)label1).set_TabIndex(1);
			((Control)label1).set_Text("Invite code :");
			metroTextBox1.get_CustomButton().set_Image((Image)null);
			((Control)metroTextBox1.get_CustomButton()).set_Location(new Point(114, 1));
			((Control)metroTextBox1.get_CustomButton()).set_Name("");
			((Control)metroTextBox1.get_CustomButton()).set_Size(new Size(21, 21));
			metroTextBox1.get_CustomButton().set_Style((MetroColorStyle)4);
			((Control)metroTextBox1.get_CustomButton()).set_TabIndex(1);
			metroTextBox1.get_CustomButton().set_Theme((MetroThemeStyle)1);
			metroTextBox1.get_CustomButton().set_UseSelectable(true);
			((Control)metroTextBox1.get_CustomButton()).set_Visible(false);
			((Control)metroTextBox1).set_ForeColor(Color.FromArgb(31, 31, 31));
			metroTextBox1.set_Lines(new string[0]);
			((Control)metroTextBox1).set_Location(new Point(101, 29));
			metroTextBox1.set_MaxLength(32767);
			((Control)metroTextBox1).set_Name("metroTextBox1");
			metroTextBox1.set_PasswordChar('\0');
			metroTextBox1.set_ScrollBars((ScrollBars)0);
			metroTextBox1.set_SelectedText("");
			metroTextBox1.set_SelectionLength(0);
			metroTextBox1.set_SelectionStart(0);
			metroTextBox1.set_ShortcutsEnabled(true);
			((Control)metroTextBox1).set_Size(new Size(136, 23));
			metroTextBox1.set_Style((MetroColorStyle)1);
			((Control)metroTextBox1).set_TabIndex(0);
			metroTextBox1.set_Theme((MetroThemeStyle)2);
			metroTextBox1.set_UseSelectable(true);
			metroTextBox1.set_WaterMarkColor(Color.FromArgb(109, 109, 109));
			metroTextBox1.set_WaterMarkFont((Font)(object)new Font("Segoe UI", 12f, (FontStyle)2, (GraphicsUnit)2));
			((Control)Settings).set_BackColor(Color.FromArgb(31, 31, 31));
			((Control)Settings).get_Controls().Add((Control)(object)button1);
			((Control)Settings).get_Controls().Add((Control)(object)textBox1);
			((Control)Settings).get_Controls().Add((Control)(object)metroButton2);
			Settings.set_HorizontalScrollbarBarColor(true);
			Settings.set_HorizontalScrollbarHighlightOnWheel(false);
			Settings.set_HorizontalScrollbarSize(10);
			((TabPage)Settings).set_Location(new Point(4, 38));
			((Control)Settings).set_Name("Settings");
			((Control)Settings).set_Size(new Size(953, 458));
			((TabPage)Settings).set_TabIndex(2);
			((Control)Settings).set_Text("Settings");
			Settings.set_UseCustomBackColor(true);
			Settings.set_VerticalScrollbarBarColor(true);
			Settings.set_VerticalScrollbarHighlightOnWheel(false);
			Settings.set_VerticalScrollbarSize(10);
			((Control)button1).set_Location(new Point(641, 218));
			((Control)button1).set_Name("button1");
			((Control)button1).set_Size(new Size(145, 23));
			((Control)button1).set_TabIndex(17);
			((Control)button1).set_Text("Authorise");
			((ButtonBase)button1).set_UseVisualStyleBackColor(true);
			((Control)button1).add_Click((EventHandler)button1_Click_1);
			((Control)textBox1).set_Font((Font)(object)new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)textBox1).set_Location(new Point(167, 218));
			((Control)textBox1).set_Name("textBox1");
			((Control)textBox1).set_Size(new Size(468, 23));
			((Control)textBox1).set_TabIndex(16);
			((Control)textBox1).set_Text("Authorisation Code");
			((Control)metroButton2).set_Location(new Point(9, 16));
			((Control)metroButton2).set_Name("metroButton2");
			((Control)metroButton2).set_Size(new Size(181, 30));
			((Control)metroButton2).set_TabIndex(2);
			((Control)metroButton2).set_Text("Load Tokens");
			metroButton2.set_Theme((MetroThemeStyle)2);
			metroButton2.set_UseSelectable(true);
			((Control)metroButton2).add_Click((EventHandler)metroButton2_Click);
			((Control)label30).set_AutoSize(true);
			((Control)label30).set_Font((Font)(object)new Font("Tahoma", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)label30).set_ForeColor(SystemColors.get_ButtonFace());
			((Control)label30).set_Location(new Point(12, 503));
			((Control)label30).set_Name("label30");
			((Control)label30).set_Size(new Size(97, 19));
			((Control)label30).set_TabIndex(16);
			((Control)label30).set_Text("Authorised: ");
			((Control)label22).set_AutoSize(true);
			((Control)label22).set_Font((Font)(object)new Font("Tahoma", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0));
			((Control)label22).set_ForeColor(Color.get_White());
			((Control)label22).set_Location(new Point(587, 504));
			((Control)label22).set_Name("label22");
			((Control)label22).set_Size(new Size(369, 18));
			((Control)label22).set_TabIndex(13);
			((Control)label22).set_Text("Alpha Spammer, Spammer for discord by Sheepy");
			((ContainerControl)this).set_AutoScaleDimensions(new SizeF(6f, 13f));
			((ContainerControl)this).set_AutoScaleMode((AutoScaleMode)1);
			((Control)this).set_BackColor(Color.FromArgb(31, 31, 31));
			((Form)this).set_ClientSize(new Size(960, 530));
			((Control)this).get_Controls().Add((Control)(object)metroTabControl1);
			((Control)this).get_Controls().Add((Control)(object)label30);
			((Control)this).get_Controls().Add((Control)(object)label22);
			((Form)this).set_FormBorderStyle((FormBorderStyle)1);
			((Form)this).set_Icon((Icon)(object)(Icon)((ResourceManager)(object)val).GetObject("$this.Icon"));
			((Control)this).set_Name("Form1");
			((Control)this).set_Text("Alpha Spammer Release v 3 |  Sheepy");
			((Form)this).add_Load((EventHandler)Form1_Load);
			((Control)metroTabControl1).ResumeLayout(false);
			((Control)Floods).ResumeLayout(false);
			((Control)panel12).ResumeLayout(false);
			((Control)panel13).ResumeLayout(false);
			((Control)panel13).PerformLayout();
			((Control)panel10).ResumeLayout(false);
			((Control)panel10).PerformLayout();
			((Control)panel11).ResumeLayout(false);
			((Control)panel11).PerformLayout();
			((Control)panel7).ResumeLayout(false);
			((Control)panel7).PerformLayout();
			((Control)panel8).ResumeLayout(false);
			((Control)panel8).PerformLayout();
			((Control)panel5).ResumeLayout(false);
			((Control)panel5).PerformLayout();
			((Control)panel9).ResumeLayout(false);
			((Control)panel6).ResumeLayout(false);
			((Control)panel6).PerformLayout();
			((Control)panel3).ResumeLayout(false);
			((Control)panel3).PerformLayout();
			((Control)panel4).ResumeLayout(false);
			((Control)panel4).PerformLayout();
			((Control)panel1).ResumeLayout(false);
			((Control)panel1).PerformLayout();
			((Control)panel2).ResumeLayout(false);
			((Control)panel2).PerformLayout();
			((Control)Settings).ResumeLayout(false);
			((Control)Settings).PerformLayout();
			((Control)this).ResumeLayout(false);
			((Control)this).PerformLayout();
		}
	}
}
