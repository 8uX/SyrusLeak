using Discord.WebSocket;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using tacoFormsBot.Properties;

namespace tacoFormsBot
{
	public class Channels : Form
	{
		private DiscordSocketClient _client;

		private IContainer components;

		private ComboBox comboBox1;

		private Label label1;

		private Label label2;

		private ComboBox comboBox2;

		private Label label3;

		private ComboBox comboBox3;

		private Label label4;

		private TextBox textBox1;

		private RichTextBox richTextBox1;

		public Channels(DiscordSocketClient iclient)
			: this()
		{
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			_client = iclient;
			InitializeComponent();
			if (Settings.Default.isConnected)
			{
				foreach (SocketGuild guild in iclient.get_Guilds())
				{
					comboBox1.get_Items().Add((object)guild.get_Name());
				}
			}
			else
			{
				MessageBox.Show("Please connect first", "Forms bot ");
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
		}

		private void Channels_Load(object sender, EventArgs e)
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
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected O, but got Unknown
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Expected O, but got Unknown
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Expected O, but got Unknown
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Expected O, but got Unknown
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Expected O, but got Unknown
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Expected O, but got Unknown
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_021a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0256: Unknown result type (might be due to invalid IL or missing references)
			//IL_027a: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0300: Unknown result type (might be due to invalid IL or missing references)
			//IL_0327: Unknown result type (might be due to invalid IL or missing references)
			//IL_034a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0374: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
			comboBox1 = (ComboBox)(object)new ComboBox();
			label1 = (Label)(object)new Label();
			label2 = (Label)(object)new Label();
			comboBox2 = (ComboBox)(object)new ComboBox();
			label3 = (Label)(object)new Label();
			comboBox3 = (ComboBox)(object)new ComboBox();
			label4 = (Label)(object)new Label();
			textBox1 = (TextBox)(object)new TextBox();
			richTextBox1 = (RichTextBox)(object)new RichTextBox();
			((Control)this).SuspendLayout();
			((ListControl)comboBox1).set_FormattingEnabled(true);
			((Control)comboBox1).set_Location(new Point(104, 12));
			((Control)comboBox1).set_Name("comboBox1");
			((Control)comboBox1).set_Size(new Size(121, 21));
			((Control)comboBox1).set_TabIndex(0);
			comboBox1.add_SelectedIndexChanged((EventHandler)comboBox1_SelectedIndexChanged);
			((Control)label1).set_AutoSize(true);
			((Control)label1).set_Location(new Point(59, 15));
			((Control)label1).set_Name("label1");
			((Control)label1).set_Size(new Size(39, 13));
			((Control)label1).set_TabIndex(1);
			((Control)label1).set_Text("Guilds:");
			((Control)label2).set_AutoSize(true);
			((Control)label2).set_Location(new Point(20, 57));
			((Control)label2).set_Name("label2");
			((Control)label2).set_Size(new Size(78, 13));
			((Control)label2).set_TabIndex(2);
			((Control)label2).set_Text("Text Channels:");
			((ListControl)comboBox2).set_FormattingEnabled(true);
			((Control)comboBox2).set_Location(new Point(104, 54));
			((Control)comboBox2).set_Name("comboBox2");
			((Control)comboBox2).set_Size(new Size(121, 21));
			((Control)comboBox2).set_TabIndex(3);
			((Control)label3).set_AutoSize(true);
			((Control)label3).set_Location(new Point(14, 99));
			((Control)label3).set_Name("label3");
			((Control)label3).set_Size(new Size(84, 13));
			((Control)label3).set_TabIndex(4);
			((Control)label3).set_Text("Voice Channels:");
			((ListControl)comboBox3).set_FormattingEnabled(true);
			((Control)comboBox3).set_Location(new Point(104, 96));
			((Control)comboBox3).set_Name("comboBox3");
			((Control)comboBox3).set_Size(new Size(121, 21));
			((Control)comboBox3).set_TabIndex(5);
			((Control)label4).set_AutoSize(true);
			((Control)label4).set_Location(new Point(255, 15));
			((Control)label4).set_Name("label4");
			((Control)label4).set_Size(new Size(68, 13));
			((Control)label4).set_TabIndex(6);
			((Control)label4).set_Text("Input Field 1:");
			((Control)textBox1).set_Location(new Point(257, 35));
			((Control)textBox1).set_Name("textBox1");
			((Control)textBox1).set_Size(new Size(428, 20));
			((Control)textBox1).set_TabIndex(7);
			((Control)richTextBox1).set_Location(new Point(12, 145));
			((Control)richTextBox1).set_Name("richTextBox1");
			((Control)richTextBox1).set_Size(new Size(333, 440));
			((Control)richTextBox1).set_TabIndex(8);
			((Control)richTextBox1).set_Text("");
			((ContainerControl)this).set_AutoScaleDimensions(new SizeF(6f, 13f));
			((ContainerControl)this).set_AutoScaleMode((AutoScaleMode)1);
			((Form)this).set_ClientSize(new Size(698, 597));
			((Control)this).get_Controls().Add((Control)(object)richTextBox1);
			((Control)this).get_Controls().Add((Control)(object)textBox1);
			((Control)this).get_Controls().Add((Control)(object)label4);
			((Control)this).get_Controls().Add((Control)(object)comboBox3);
			((Control)this).get_Controls().Add((Control)(object)label3);
			((Control)this).get_Controls().Add((Control)(object)comboBox2);
			((Control)this).get_Controls().Add((Control)(object)label2);
			((Control)this).get_Controls().Add((Control)(object)label1);
			((Control)this).get_Controls().Add((Control)(object)comboBox1);
			((Control)this).set_Name("Channels");
			((Control)this).set_Text("Channel");
			((Form)this).add_Load((EventHandler)Channels_Load);
			((Control)this).ResumeLayout(false);
			((Control)this).PerformLayout();
		}
	}
}
