using Discord;
using Discord.WebSocket;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tacoFormsBot
{
	public class DM : Form
	{
		public string messageText;

		private DiscordSocketClient _client;

		private IContainer components;

		private Label label1;

		private Label label2;

		private Label label3;

		private ComboBox comboBox1;

		private ComboBox comboBox2;

		private ComboBox comboBox3;

		private Button button1;

		private TextBox textBox1;

		private Label label5;

		private CheckBox checkBox1;

		private CheckBox checkBox2;

		private CheckBox checkBox3;

		private Label label4;

		private CheckBox checkBox4;

		private CheckBox checkBox5;

		private RichTextBox richTextBox1;

		private RichTextBox richTextBox2;

		private Label label6;

		private Label label7;

		private NumericUpDown numericUpDown1;

		private Label label8;

		private Label label9;

		private Label label10;

		private Label label11;

		public DM(DiscordSocketClient iclient)
			: this()
		{
			_client = iclient;
			InitializeComponent();
		}

		private void DM_Load(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				comboBox1.get_Items().Add((object)guild.get_Name());
			}
		}

		private void UpdateChannels()
		{
			comboBox2.get_Items().Clear();
			comboBox3.get_Items().Clear();
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
				{
					continue;
				}
				foreach (SocketTextChannel textChannel in guild.get_TextChannels())
				{
					comboBox2.get_Items().Add((object)((SocketGuildChannel)textChannel).get_Name());
				}
				foreach (SocketVoiceChannel voiceChannel in guild.get_VoiceChannels())
				{
					comboBox3.get_Items().Add((object)((SocketGuildChannel)voiceChannel).get_Name());
				}
			}
			if (comboBox2.get_Items().get_Count() != 0)
			{
				int selectedIndex = 0;
				((ListControl)comboBox2).set_SelectedIndex(selectedIndex);
			}
			if (comboBox3.get_Items().get_Count() != 0)
			{
				int selectedIndex2 = 0;
				((ListControl)comboBox3).set_SelectedIndex(selectedIndex2);
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateChannels();
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.get_Checked())
			{
				checkBox2.set_Checked(false);
				checkBox3.set_Checked(false);
			}
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox2.get_Checked())
			{
				checkBox1.set_Checked(false);
				checkBox3.set_Checked(false);
			}
		}

		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox3.get_Checked())
			{
				checkBox1.set_Checked(false);
				checkBox2.set_Checked(false);
			}
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			decimal value = numericUpDown1.get_Value();
			int timeDelay = Convert.ToInt32(value);
			if (checkBox4.get_Checked())
			{
				messageText = ((Control)textBox1).get_Text();
			}
			else if (checkBox5.get_Checked())
			{
				string[] lines = ((TextBoxBase)richTextBox2).get_Lines();
				foreach (string text in lines)
				{
					((TextBoxBase)richTextBox1).AppendText(text + "\n");
					stringBuilder.Append(text);
					stringBuilder.AppendLine();
				}
				messageText = stringBuilder.ToString();
			}
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
				{
					continue;
				}
				if (checkBox1.get_Checked())
				{
					((TextBoxBase)richTextBox1).AppendText("ATTEMPTING TO SEND DM TO ALL MEMBERS OF " + guild.get_Name() + "\n");
					((TextBoxBase)richTextBox1).AppendText("MESSAGE: " + messageText + "\n");
					foreach (SocketGuildUser user3 in guild.get_Users())
					{
						try
						{
							IDMChannel _DM3 = await ((SocketUser)user3).GetOrCreateDMChannelAsync((RequestOptions)null);
							if (!((SocketUser)user3).get_IsBot())
							{
								await ((IMessageChannel)_DM3).SendMessageAsync(messageText, false, (Embed)null, (RequestOptions)null);
								await Task.Delay(timeDelay);
								((TextBoxBase)richTextBox1).AppendText(string.Concat("[", DateTime.Now, "] SUCCESSFULLY SENT TO:", _DM3.get_Recipient(), "\n"));
							}
						}
						catch (Exception ex)
						{
							Exception errorDM3 = ex;
							await Task.Delay(timeDelay);
							((TextBoxBase)richTextBox1).AppendText(errorDM3.Message + "\n");
						}
					}
				}
				else if (checkBox2.get_Checked())
				{
					foreach (SocketTextChannel textChannel in guild.get_TextChannels())
					{
						if (!(((SocketGuildChannel)textChannel).get_Name() == ((Control)comboBox2).get_Text()))
						{
							continue;
						}
						((TextBoxBase)richTextBox1).AppendText("ATTEMPTING TO SEND DM TO ALL USERS IN " + ((SocketGuildChannel)textChannel).get_Name() + "\n");
						((TextBoxBase)richTextBox1).AppendText("MESSAGE: " + messageText + "\n");
						foreach (SocketGuildUser user2 in ((SocketGuildChannel)textChannel).get_Users())
						{
							try
							{
								IDMChannel _DM2 = await ((SocketUser)user2).GetOrCreateDMChannelAsync((RequestOptions)null);
								if (!((SocketUser)user2).get_IsBot())
								{
									await ((IMessageChannel)_DM2).SendMessageAsync(messageText, false, (Embed)null, (RequestOptions)null);
									await Task.Delay(timeDelay);
									((TextBoxBase)richTextBox1).AppendText(string.Concat("[", DateTime.Now, "] SUCCESSFULLY SENT TO:", _DM2.get_Recipient(), "\n"));
								}
							}
							catch (Exception)
							{
								Exception errorDM2 = ex;
								await Task.Delay(timeDelay);
								((TextBoxBase)richTextBox1).AppendText("[" + errorDM2.Message + "] USER:\n");
							}
						}
					}
				}
				else
				{
					if (!checkBox3.get_Checked())
					{
						continue;
					}
					foreach (SocketVoiceChannel voiceChannel in guild.get_VoiceChannels())
					{
						if (!(((SocketGuildChannel)voiceChannel).get_Name() == ((Control)comboBox3).get_Text()))
						{
							continue;
						}
						((TextBoxBase)richTextBox1).AppendText("ATTEMPTING TO SEND DM TO ALL USERS IN " + ((SocketGuildChannel)voiceChannel).get_Name() + "\n");
						((TextBoxBase)richTextBox1).AppendText("MESSAGE: " + messageText + "\n");
						foreach (SocketGuildUser user in ((SocketGuildChannel)voiceChannel).get_Users())
						{
							try
							{
								IDMChannel _DM = await ((SocketUser)user).GetOrCreateDMChannelAsync((RequestOptions)null);
								if (!((SocketUser)user).get_IsBot())
								{
									await Task.Delay(timeDelay);
									await ((IMessageChannel)_DM).SendMessageAsync(messageText, false, (Embed)null, (RequestOptions)null);
									((TextBoxBase)richTextBox1).AppendText(string.Concat("[", DateTime.Now, "] SUCCESSFULLY SENT TO:", _DM.get_Recipient(), "\n"));
								}
							}
							catch (Exception)
							{
								Exception errorDM = ex;
								await Task.Delay(timeDelay);
								((TextBoxBase)richTextBox1).AppendText("[" + errorDM.Message + "] USER:\n");
							}
						}
					}
				}
			}
		}

		private void checkBox4_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox4.get_Checked())
			{
				((Control)textBox1).get_Text();
				checkBox5.set_Checked(false);
			}
			else if (!checkBox5.get_Checked())
			{
				checkBox4.set_Checked(true);
			}
		}

		private void checkBox5_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox5.get_Checked())
			{
				checkBox4.set_Checked(false);
			}
			else if (!checkBox4.get_Checked())
			{
				checkBox5.set_Checked(true);
			}
		}

		private void richTextBox1_TextChanged(object sender, EventArgs e)
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
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0223: Unknown result type (might be due to invalid IL or missing references)
			//IL_026b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0292: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0308: Unknown result type (might be due to invalid IL or missing references)
			//IL_0340: Unknown result type (might be due to invalid IL or missing references)
			//IL_0367: Unknown result type (might be due to invalid IL or missing references)
			//IL_038d: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0404: Unknown result type (might be due to invalid IL or missing references)
			//IL_042b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0456: Unknown result type (might be due to invalid IL or missing references)
			//IL_047a: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0559: Unknown result type (might be due to invalid IL or missing references)
			//IL_0580: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_060a: Unknown result type (might be due to invalid IL or missing references)
			//IL_066d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0691: Unknown result type (might be due to invalid IL or missing references)
			//IL_06d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_06f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0770: Unknown result type (might be due to invalid IL or missing references)
			//IL_0794: Unknown result type (might be due to invalid IL or missing references)
			//IL_07eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0821: Unknown result type (might be due to invalid IL or missing references)
			//IL_086f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0899: Unknown result type (might be due to invalid IL or missing references)
			//IL_08d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_08fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0940: Unknown result type (might be due to invalid IL or missing references)
			//IL_0964: Unknown result type (might be due to invalid IL or missing references)
			//IL_099b: Unknown result type (might be due to invalid IL or missing references)
			//IL_09dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a0d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a34: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a77: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a9b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ae1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0aeb: Expected O, but got Unknown
			//IL_0af1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b08: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b2f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b6f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b96: Unknown result type (might be due to invalid IL or missing references)
			//IL_0bc8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0be4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d99: Unknown result type (might be due to invalid IL or missing references)
			//IL_0da3: Expected O, but got Unknown
			ComponentResourceManager val = (ComponentResourceManager)(object)new ComponentResourceManager(typeof(DM));
			label1 = (Label)(object)new Label();
			label2 = (Label)(object)new Label();
			label3 = (Label)(object)new Label();
			comboBox1 = (ComboBox)(object)new ComboBox();
			comboBox2 = (ComboBox)(object)new ComboBox();
			comboBox3 = (ComboBox)(object)new ComboBox();
			button1 = (Button)(object)new Button();
			textBox1 = (TextBox)(object)new TextBox();
			label5 = (Label)(object)new Label();
			checkBox1 = (CheckBox)(object)new CheckBox();
			checkBox2 = (CheckBox)(object)new CheckBox();
			checkBox3 = (CheckBox)(object)new CheckBox();
			label4 = (Label)(object)new Label();
			checkBox4 = (CheckBox)(object)new CheckBox();
			checkBox5 = (CheckBox)(object)new CheckBox();
			richTextBox1 = (RichTextBox)(object)new RichTextBox();
			richTextBox2 = (RichTextBox)(object)new RichTextBox();
			label6 = (Label)(object)new Label();
			label7 = (Label)(object)new Label();
			numericUpDown1 = (NumericUpDown)(object)new NumericUpDown();
			label8 = (Label)(object)new Label();
			label9 = (Label)(object)new Label();
			label10 = (Label)(object)new Label();
			label11 = (Label)(object)new Label();
			((ISupportInitialize)numericUpDown1).BeginInit();
			((Control)this).SuspendLayout();
			((Control)label1).set_AutoSize(true);
			((Control)label1).set_Location(new Point(47, 54));
			((Control)label1).set_Name("label1");
			((Control)label1).set_Size(new Size(41, 13));
			((Control)label1).set_TabIndex(0);
			((Control)label1).set_Text("Server:");
			((Control)label2).set_AutoSize(true);
			((Control)label2).set_Location(new Point(15, 81));
			((Control)label2).set_Name("label2");
			((Control)label2).set_Size(new Size(73, 13));
			((Control)label2).set_TabIndex(1);
			((Control)label2).set_Text("Text Channel:");
			((Control)label3).set_AutoSize(true);
			((Control)label3).set_Location(new Point(9, 108));
			((Control)label3).set_Name("label3");
			((Control)label3).set_Size(new Size(79, 13));
			((Control)label3).set_TabIndex(2);
			((Control)label3).set_Text("Voice Channel:");
			comboBox1.set_DropDownStyle((ComboBoxStyle)2);
			((ListControl)comboBox1).set_FormattingEnabled(true);
			((Control)comboBox1).set_Location(new Point(94, 51));
			((Control)comboBox1).set_Name("comboBox1");
			((Control)comboBox1).set_Size(new Size(196, 21));
			((Control)comboBox1).set_TabIndex(3);
			comboBox1.add_SelectedIndexChanged((EventHandler)comboBox1_SelectedIndexChanged);
			comboBox2.set_DropDownStyle((ComboBoxStyle)2);
			((ListControl)comboBox2).set_FormattingEnabled(true);
			((Control)comboBox2).set_Location(new Point(94, 78));
			((Control)comboBox2).set_Name("comboBox2");
			((Control)comboBox2).set_Size(new Size(196, 21));
			((Control)comboBox2).set_TabIndex(4);
			comboBox3.set_DropDownStyle((ComboBoxStyle)2);
			((ListControl)comboBox3).set_FormattingEnabled(true);
			((Control)comboBox3).set_Location(new Point(94, 105));
			((Control)comboBox3).set_Name("comboBox3");
			((Control)comboBox3).set_Size(new Size(196, 21));
			((Control)comboBox3).set_TabIndex(5);
			((Control)button1).set_Location(new Point(500, 155));
			((Control)button1).set_Name("button1");
			((Control)button1).set_Size(new Size(75, 23));
			((Control)button1).set_TabIndex(6);
			((Control)button1).set_Text("Send");
			((ButtonBase)button1).set_UseVisualStyleBackColor(true);
			((Control)button1).add_Click((EventHandler)button1_Click);
			((Control)textBox1).set_Location(new Point(9, 25));
			((Control)textBox1).set_Name("textBox1");
			((Control)textBox1).set_Size(new Size(668, 20));
			((Control)textBox1).set_TabIndex(8);
			((Control)label5).set_AutoSize(true);
			((Control)label5).set_Location(new Point(6, 9));
			((Control)label5).set_Name("label5");
			((Control)label5).set_Size(new Size(73, 13));
			((Control)label5).set_TabIndex(9);
			((Control)label5).set_Text("DM Message:");
			((Control)checkBox1).set_AutoSize(true);
			checkBox1.set_Checked(true);
			checkBox1.set_CheckState((CheckState)1);
			((Control)checkBox1).set_Location(new Point(328, 77));
			((Control)checkBox1).set_Name("checkBox1");
			((Control)checkBox1).set_Size(new Size(103, 17));
			((Control)checkBox1).set_TabIndex(10);
			((Control)checkBox1).set_Text("Server Members");
			((ButtonBase)checkBox1).set_UseVisualStyleBackColor(true);
			checkBox1.add_CheckedChanged((EventHandler)checkBox1_CheckedChanged);
			((Control)checkBox2).set_AutoSize(true);
			((Control)checkBox2).set_Location(new Point(328, 100));
			((Control)checkBox2).set_Name("checkBox2");
			((Control)checkBox2).set_Size(new Size(135, 17));
			((Control)checkBox2).set_TabIndex(11);
			((Control)checkBox2).set_Text("Text Channel Members");
			((ButtonBase)checkBox2).set_UseVisualStyleBackColor(true);
			checkBox2.add_CheckedChanged((EventHandler)checkBox2_CheckedChanged);
			((Control)checkBox3).set_AutoSize(true);
			((Control)checkBox3).set_Location(new Point(328, 123));
			((Control)checkBox3).set_Name("checkBox3");
			((Control)checkBox3).set_Size(new Size(141, 17));
			((Control)checkBox3).set_TabIndex(12);
			((Control)checkBox3).set_Text("Voice Channel Members");
			((ButtonBase)checkBox3).set_UseVisualStyleBackColor(true);
			checkBox3.add_CheckedChanged((EventHandler)checkBox3_CheckedChanged);
			((Control)label4).set_AutoSize(true);
			((Control)label4).set_Location(new Point(325, 59));
			((Control)label4).set_Name("label4");
			((Control)label4).set_Size(new Size(97, 13));
			((Control)label4).set_TabIndex(13);
			((Control)label4).set_Text("Send Message To:");
			((Control)checkBox4).set_AutoSize(true);
			((Control)checkBox4).set_Location(new Point(501, 59));
			((Control)checkBox4).set_Name("checkBox4");
			((Control)checkBox4).set_Size(new Size(74, 17));
			((Control)checkBox4).set_TabIndex(14);
			((Control)checkBox4).set_Text("Text Input");
			((ButtonBase)checkBox4).set_UseVisualStyleBackColor(true);
			checkBox4.add_CheckedChanged((EventHandler)checkBox4_CheckedChanged);
			((Control)checkBox5).set_AutoSize(true);
			checkBox5.set_Checked(true);
			checkBox5.set_CheckState((CheckState)1);
			((Control)checkBox5).set_Location(new Point(501, 82));
			((Control)checkBox5).set_Name("checkBox5");
			((Control)checkBox5).set_Size(new Size(85, 17));
			((Control)checkBox5).set_TabIndex(15);
			((Control)checkBox5).set_Text("Custom Text");
			((ButtonBase)checkBox5).set_UseVisualStyleBackColor(true);
			checkBox5.add_CheckedChanged((EventHandler)checkBox5_CheckedChanged);
			((Control)richTextBox1).set_Location(new Point(12, 246));
			((Control)richTextBox1).set_Name("richTextBox1");
			((TextBoxBase)richTextBox1).set_ReadOnly(true);
			((Control)richTextBox1).set_Size(new Size(330, 365));
			((Control)richTextBox1).set_TabIndex(16);
			((Control)richTextBox1).set_Text("");
			((Control)richTextBox1).add_TextChanged((EventHandler)richTextBox1_TextChanged);
			((Control)richTextBox2).set_Location(new Point(353, 246));
			((Control)richTextBox2).set_Name("richTextBox2");
			((Control)richTextBox2).set_Size(new Size(349, 365));
			((Control)richTextBox2).set_TabIndex(17);
			((Control)richTextBox2).set_Text("");
			((Control)label6).set_AutoSize(true);
			((Control)label6).set_Location(new Point(12, 230));
			((Control)label6).set_Name("label6");
			((Control)label6).set_Size(new Size(28, 13));
			((Control)label6).set_TabIndex(18);
			((Control)label6).set_Text("Log:");
			((Control)label7).set_AutoSize(true);
			((Control)label7).set_Location(new Point(356, 230));
			((Control)label7).set_Name("label7");
			((Control)label7).set_Size(new Size(66, 13));
			((Control)label7).set_TabIndex(19);
			((Control)label7).set_Text("Custom Text");
			((Control)numericUpDown1).set_Location(new Point(565, 129));
			numericUpDown1.set_Maximum(new decimal(new int[4]
			{
				1000000,
				0,
				0,
				0
			}));
			((Control)numericUpDown1).set_Name("numericUpDown1");
			((Control)numericUpDown1).set_Size(new Size(69, 20));
			((Control)numericUpDown1).set_TabIndex(20);
			((Control)label8).set_AutoSize(true);
			((Control)label8).set_Location(new Point(498, 113));
			((Control)label8).set_Name("label8");
			((Control)label8).set_Size(new Size(133, 13));
			((Control)label8).set_TabIndex(21);
			((Control)label8).set_Text("Delay Between Messages:");
			((Control)label9).set_AutoSize(true);
			((Control)label9).set_Location(new Point(498, 131));
			((Control)label9).set_Name("label9");
			((Control)label9).set_Size(new Size(67, 13));
			((Control)label9).set_TabIndex(22);
			((Control)label9).set_Text("Milliseconds:");
			((Control)label10).set_AutoSize(true);
			((Control)label10).set_Font((Font)(object)new Font("Microsoft Sans Serif", 14f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)label10).set_ForeColor(Color.get_Red());
			((Control)label10).set_Location(new Point(15, 140));
			((Control)label10).set_Name("label10");
			((Control)label10).set_Size(new Size(275, 24));
			((Control)label10).set_TabIndex(23);
			((Control)label10).set_Text("DM Command's Are Still In Beta");
			((Control)label11).set_AutoSize(true);
			((Control)label11).set_Location(new Point(16, 164));
			((Control)label11).set_Name("label11");
			((Control)label11).set_Size(new Size(266, 52));
			((Control)label11).set_TabIndex(24);
			((Control)label11).set_Text("Be careful, using these commands on a user token will\r\n100% get you rate-limited and than get your account\r\ndeactivated. ONLY USE THESE COMMANDS IF YOU\r\nUSING A BOT TOKEN");
			((ContainerControl)this).set_AutoScaleDimensions(new SizeF(6f, 13f));
			((ContainerControl)this).set_AutoScaleMode((AutoScaleMode)1);
			((Form)this).set_ClientSize(new Size(714, 623));
			((Control)this).get_Controls().Add((Control)(object)label11);
			((Control)this).get_Controls().Add((Control)(object)label10);
			((Control)this).get_Controls().Add((Control)(object)label9);
			((Control)this).get_Controls().Add((Control)(object)label8);
			((Control)this).get_Controls().Add((Control)(object)numericUpDown1);
			((Control)this).get_Controls().Add((Control)(object)label7);
			((Control)this).get_Controls().Add((Control)(object)label6);
			((Control)this).get_Controls().Add((Control)(object)richTextBox2);
			((Control)this).get_Controls().Add((Control)(object)richTextBox1);
			((Control)this).get_Controls().Add((Control)(object)checkBox5);
			((Control)this).get_Controls().Add((Control)(object)checkBox4);
			((Control)this).get_Controls().Add((Control)(object)label4);
			((Control)this).get_Controls().Add((Control)(object)checkBox3);
			((Control)this).get_Controls().Add((Control)(object)checkBox2);
			((Control)this).get_Controls().Add((Control)(object)checkBox1);
			((Control)this).get_Controls().Add((Control)(object)label5);
			((Control)this).get_Controls().Add((Control)(object)textBox1);
			((Control)this).get_Controls().Add((Control)(object)button1);
			((Control)this).get_Controls().Add((Control)(object)comboBox3);
			((Control)this).get_Controls().Add((Control)(object)comboBox2);
			((Control)this).get_Controls().Add((Control)(object)comboBox1);
			((Control)this).get_Controls().Add((Control)(object)label3);
			((Control)this).get_Controls().Add((Control)(object)label2);
			((Control)this).get_Controls().Add((Control)(object)label1);
			((Form)this).set_FormBorderStyle((FormBorderStyle)2);
			((Form)this).set_Icon((Icon)(object)(Icon)((ResourceManager)(object)val).GetObject("$this.Icon"));
			((Control)this).set_Name("DM");
			((Control)this).set_Text("DM Tools - Targo 0.4b");
			((Form)this).add_Load((EventHandler)DM_Load);
			((ISupportInitialize)numericUpDown1).EndInit();
			((Control)this).ResumeLayout(false);
			((Control)this).PerformLayout();
		}
	}
}
