using Discord;
using Discord.Rest;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace tacoFormsBot
{
	public class Invite : Form
	{
		private DiscordSocketClient _client;

		private IContainer components;

		private Label label1;

		private Label label4;

		private Label label5;

		private ComboBox comboBox1;

		private ComboBox comboBox2;

		private ComboBox comboBox3;

		private Label label6;

		private Button button1;

		private RichTextBox richTextBox1;

		private Button button2;

		private Button button3;

		private NumericUpDown numericUpDown1;

		private Button button25;

		private Label label7;

		private NumericUpDown numericUpDown2;

		private Label label9;

		private Label label10;

		private CheckBox checkBox1;

		private CheckBox checkBox2;

		private BindingSource bindingSource1;

		private TableLayoutPanel tableLayoutPanel1;

		private Panel panel1;

		public Invite(DiscordSocketClient iclient)
			: this()
		{
			_client = iclient;
			InitializeComponent();
		}

		private void EmbedOptions_Load(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				comboBox1.get_Items().Add((object)guild.get_Name());
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateChannels();
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
				{
					continue;
				}
				try
				{
					IReadOnlyCollection<RestInviteMetadata> result = guild.GetInvitesAsync((RequestOptions)null).Result;
					if (guild.GetInvitesAsync((RequestOptions)null).Result.Count == 0)
					{
						((TextBoxBase)richTextBox1).AppendText($"\nNo invites for {guild.get_Name()} \n");
						return;
					}
					((TextBoxBase)richTextBox1).AppendText($"\nINVITES FOR {guild.get_Name()}\n");
					foreach (RestInviteMetadata item in result)
					{
						((TextBoxBase)richTextBox1).AppendText($"Channel: {((IInvite)item).get_ChannelName()} Code: {((IInvite)item).get_Url()} \n");
					}
				}
				catch (Exception ex)
				{
					((TextBoxBase)richTextBox1).AppendText($"{ex.Message}\n");
				}
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

		private async void button2_Click(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
				{
					continue;
				}
				try
				{
					if (guild.GetInvitesAsync((RequestOptions)null).Result.Count == 0)
					{
						((TextBoxBase)richTextBox1).AppendText($"No invites for {guild.get_Name()} \n");
						return;
					}
					foreach (RestInviteMetadata item in guild.GetInvitesAsync((RequestOptions)null).Result)
					{
						await ((IDeletable)item).DeleteAsync((RequestOptions)null);
					}
				}
				catch (Exception ex)
				{
					((TextBoxBase)richTextBox1).AppendText($"{ex.Message}\n");
				}
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			//IL_019c: Unknown result type (might be due to invalid IL or missing references)
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
				{
					continue;
				}
				foreach (SocketTextChannel textChannel in guild.get_TextChannels())
				{
					if (!(((SocketGuildChannel)textChannel).get_Name() == ((Control)comboBox2).get_Text()))
					{
						continue;
					}
					int? num = (!(numericUpDown1.get_Value() != 0m)) ? null : new int?(Convert.ToInt32(numericUpDown1.get_Value()));
					int? num2 = null;
					num2 = ((numericUpDown2.get_Value() == 0m) ? null : new int?(Convert.ToInt32(numericUpDown2.get_Value())));
					bool flag = checkBox1.get_Checked() ? true : false;
					bool flag2 = checkBox2.get_Checked() ? true : false;
					try
					{
						RestInviteMetadata result = ((SocketGuildChannel)textChannel).CreateInviteAsync(num, num2, flag, flag2, (RequestOptions)null).Result;
						if (result != null)
						{
							((TextBoxBase)richTextBox1).AppendText($"Guild: {((RestInvite)result).get_GuildName()} Channel: {((RestInvite)result).get_ChannelName()} Maxage: {result.get_MaxAge()} Maxuses: {result.get_MaxUses()} Inviter: {result.get_Inviter()}\n" + $"URL: {((RestInvite)result).get_Url()}\n");
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}
			}
		}

		private void button25_Click(object sender, EventArgs e)
		{
			UpdateChannels();
		}

		private void bindingSource1_CurrentChanged(object sender, EventArgs e)
		{
		}

		private void richTextBox1_TextChanged(object sender, EventArgs e)
		{
			((TextBoxBase)richTextBox1).set_SelectionStart(((Control)richTextBox1).get_Text().Length);
			((TextBoxBase)richTextBox1).ScrollToCaret();
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
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
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
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Expected O, but got Unknown
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Expected O, but got Unknown
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Expected O, but got Unknown
			//IL_0169: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_0229: Unknown result type (might be due to invalid IL or missing references)
			//IL_024d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0295: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_030b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0332: Unknown result type (might be due to invalid IL or missing references)
			//IL_036a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0391: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0414: Unknown result type (might be due to invalid IL or missing references)
			//IL_0438: Unknown result type (might be due to invalid IL or missing references)
			//IL_049a: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_050f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0533: Unknown result type (might be due to invalid IL or missing references)
			//IL_058d: Unknown result type (might be due to invalid IL or missing references)
			//IL_05b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_060b: Unknown result type (might be due to invalid IL or missing references)
			//IL_064d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0670: Unknown result type (might be due to invalid IL or missing references)
			//IL_0694: Unknown result type (might be due to invalid IL or missing references)
			//IL_06f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_071b: Unknown result type (might be due to invalid IL or missing references)
			//IL_074f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0791: Unknown result type (might be due to invalid IL or missing references)
			//IL_07c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_07e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0822: Unknown result type (might be due to invalid IL or missing references)
			//IL_0849: Unknown result type (might be due to invalid IL or missing references)
			//IL_0889: Unknown result type (might be due to invalid IL or missing references)
			//IL_08ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_08f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_091d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0984: Unknown result type (might be due to invalid IL or missing references)
			//IL_098e: Expected O, but got Unknown
			//IL_09d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a0a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a14: Expected O, but got Unknown
			//IL_0a26: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a30: Expected O, but got Unknown
			//IL_0a41: Unknown result type (might be due to invalid IL or missing references)
			//IL_0bf8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c22: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c43: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c5f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c86: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c90: Expected O, but got Unknown
			//IL_0c9b: Unknown result type (might be due to invalid IL or missing references)
			components = (IContainer)(object)new Container();
			ComponentResourceManager val = (ComponentResourceManager)(object)new ComponentResourceManager(typeof(Invite));
			label1 = (Label)(object)new Label();
			label4 = (Label)(object)new Label();
			label5 = (Label)(object)new Label();
			comboBox1 = (ComboBox)(object)new ComboBox();
			comboBox2 = (ComboBox)(object)new ComboBox();
			comboBox3 = (ComboBox)(object)new ComboBox();
			label6 = (Label)(object)new Label();
			button1 = (Button)(object)new Button();
			richTextBox1 = (RichTextBox)(object)new RichTextBox();
			button2 = (Button)(object)new Button();
			button3 = (Button)(object)new Button();
			numericUpDown1 = (NumericUpDown)(object)new NumericUpDown();
			button25 = (Button)(object)new Button();
			label7 = (Label)(object)new Label();
			numericUpDown2 = (NumericUpDown)(object)new NumericUpDown();
			label9 = (Label)(object)new Label();
			label10 = (Label)(object)new Label();
			checkBox1 = (CheckBox)(object)new CheckBox();
			checkBox2 = (CheckBox)(object)new CheckBox();
			bindingSource1 = (BindingSource)(object)new BindingSource(components);
			tableLayoutPanel1 = (TableLayoutPanel)(object)new TableLayoutPanel();
			panel1 = (Panel)(object)new Panel();
			((ISupportInitialize)numericUpDown1).BeginInit();
			((ISupportInitialize)numericUpDown2).BeginInit();
			((ISupportInitialize)bindingSource1).BeginInit();
			((Control)tableLayoutPanel1).SuspendLayout();
			((Control)panel1).SuspendLayout();
			((Control)this).SuspendLayout();
			((Control)label1).set_AutoSize(true);
			((Control)label1).set_Location(new Point(11, 146));
			((Control)label1).set_Name("label1");
			((Control)label1).set_Size(new Size(58, 13));
			((Control)label1).set_TabIndex(0);
			((Control)label1).set_Text("Invite Age:");
			((Control)label4).set_AutoSize(true);
			((Control)label4).set_Location(new Point(41, 36));
			((Control)label4).set_Name("label4");
			((Control)label4).set_Size(new Size(41, 13));
			((Control)label4).set_TabIndex(3);
			((Control)label4).set_Text("Server:");
			((Control)label5).set_AutoSize(true);
			((Control)label5).set_Location(new Point(10, 63));
			((Control)label5).set_Name("label5");
			((Control)label5).set_Size(new Size(73, 13));
			((Control)label5).set_TabIndex(4);
			((Control)label5).set_Text("Text Channel:");
			comboBox1.set_DropDownStyle((ComboBoxStyle)2);
			((ListControl)comboBox1).set_FormattingEnabled(true);
			((Control)comboBox1).set_Location(new Point(84, 33));
			((Control)comboBox1).set_Name("comboBox1");
			((Control)comboBox1).set_Size(new Size(216, 21));
			((Control)comboBox1).set_TabIndex(7);
			comboBox1.add_SelectedIndexChanged((EventHandler)comboBox1_SelectedIndexChanged);
			comboBox2.set_DropDownStyle((ComboBoxStyle)2);
			((ListControl)comboBox2).set_FormattingEnabled(true);
			((Control)comboBox2).set_Location(new Point(84, 60));
			((Control)comboBox2).set_Name("comboBox2");
			((Control)comboBox2).set_Size(new Size(216, 21));
			((Control)comboBox2).set_TabIndex(8);
			comboBox3.set_DropDownStyle((ComboBoxStyle)2);
			((ListControl)comboBox3).set_FormattingEnabled(true);
			((Control)comboBox3).set_Location(new Point(84, 86));
			((Control)comboBox3).set_Name("comboBox3");
			((Control)comboBox3).set_Size(new Size(216, 21));
			((Control)comboBox3).set_TabIndex(9);
			((Control)label6).set_AutoSize(true);
			((Control)label6).set_Location(new Point(4, 88));
			((Control)label6).set_Name("label6");
			((Control)label6).set_Size(new Size(79, 13));
			((Control)label6).set_TabIndex(10);
			((Control)label6).set_Text("Voice Channel:");
			((Control)button1).set_Location(new Point(7, 246));
			((Control)button1).set_Name("button1");
			((Control)button1).set_Size(new Size(75, 23));
			((Control)button1).set_TabIndex(12);
			((Control)button1).set_Text("Get Invites");
			((ButtonBase)button1).set_UseVisualStyleBackColor(true);
			((Control)button1).add_Click((EventHandler)button1_Click);
			((Control)richTextBox1).set_Dock((DockStyle)5);
			((Control)richTextBox1).set_Location(new Point(3, 285));
			((Control)richTextBox1).set_Name("richTextBox1");
			((Control)richTextBox1).set_Size(new Size(309, 261));
			((Control)richTextBox1).set_TabIndex(13);
			((Control)richTextBox1).set_Text("");
			((Control)richTextBox1).add_TextChanged((EventHandler)richTextBox1_TextChanged);
			((Control)button2).set_Location(new Point(88, 246));
			((Control)button2).set_Name("button2");
			((Control)button2).set_Size(new Size(75, 23));
			((Control)button2).set_TabIndex(14);
			((Control)button2).set_Text("Delete All");
			((ButtonBase)button2).set_UseVisualStyleBackColor(true);
			((Control)button2).add_Click((EventHandler)button2_Click);
			((Control)button3).set_Location(new Point(169, 246));
			((Control)button3).set_Name("button3");
			((Control)button3).set_Size(new Size(131, 23));
			((Control)button3).set_TabIndex(15);
			((Control)button3).set_Text("Create Invite");
			((ButtonBase)button3).set_UseVisualStyleBackColor(true);
			((Control)button3).add_Click((EventHandler)button3_Click);
			((Control)numericUpDown1).set_Location(new Point(74, 144));
			numericUpDown1.set_Maximum(new decimal(new int[4]
			{
				3600,
				0,
				0,
				0
			}));
			((Control)numericUpDown1).set_Name("numericUpDown1");
			((Control)numericUpDown1).set_Size(new Size(59, 20));
			((Control)numericUpDown1).set_TabIndex(16);
			((Control)button25).set_Location(new Point(280, 5));
			((Control)button25).set_Name("button25");
			((Control)button25).set_Size(new Size(20, 20));
			((Control)button25).set_TabIndex(42);
			((Control)button25).set_Text("\ud83d\udd04");
			((ButtonBase)button25).set_UseVisualStyleBackColor(true);
			((Control)button25).add_Click((EventHandler)button25_Click);
			((Control)label7).set_AutoSize(true);
			((Control)label7).set_Location(new Point(85, 12));
			((Control)label7).set_Name("label7");
			((Control)label7).set_Size(new Size(138, 13));
			((Control)label7).set_TabIndex(43);
			((Control)label7).set_Text("Server / Channel Selection:");
			((Control)numericUpDown2).set_Location(new Point(74, 169));
			numericUpDown2.set_Maximum(new decimal(new int[4]
			{
				3600,
				0,
				0,
				0
			}));
			((Control)numericUpDown2).set_Name("numericUpDown2");
			((Control)numericUpDown2).set_Size(new Size(59, 20));
			((Control)numericUpDown2).set_TabIndex(46);
			((Control)label9).set_AutoSize(true);
			((Control)label9).set_Location(new Point(12, 171));
			((Control)label9).set_Name("label9");
			((Control)label9).set_Size(new Size(57, 13));
			((Control)label9).set_TabIndex(45);
			((Control)label9).set_Text("Max Uses:");
			((Control)label10).set_AutoSize(true);
			((Control)label10).set_Location(new Point(11, 123));
			((Control)label10).set_Name("label10");
			((Control)label10).set_Size(new Size(165, 13));
			((Control)label10).set_TabIndex(47);
			((Control)label10).set_Text("Invite Parameters | User 0 for max");
			((Control)checkBox1).set_AutoSize(true);
			((Control)checkBox1).set_Location(new Point(13, 195));
			((Control)checkBox1).set_Name("checkBox1");
			((Control)checkBox1).set_Size(new Size(87, 17));
			((Control)checkBox1).set_TabIndex(48);
			((Control)checkBox1).set_Text("Is Temporary");
			((ButtonBase)checkBox1).set_UseVisualStyleBackColor(true);
			((Control)checkBox2).set_AutoSize(true);
			((Control)checkBox2).set_Location(new Point(13, 218));
			((Control)checkBox2).set_Name("checkBox2");
			((Control)checkBox2).set_Size(new Size(71, 17));
			((Control)checkBox2).set_TabIndex(49);
			((Control)checkBox2).set_Text("Is Unique");
			((ButtonBase)checkBox2).set_UseVisualStyleBackColor(true);
			bindingSource1.add_CurrentChanged((EventHandler)bindingSource1_CurrentChanged);
			tableLayoutPanel1.set_ColumnCount(1);
			tableLayoutPanel1.get_ColumnStyles().Add((ColumnStyle)(object)new ColumnStyle((SizeType)2, 100f));
			tableLayoutPanel1.get_Controls().Add((Control)(object)panel1, 0, 0);
			tableLayoutPanel1.get_Controls().Add((Control)(object)richTextBox1, 0, 1);
			((Control)tableLayoutPanel1).set_Dock((DockStyle)5);
			((Control)tableLayoutPanel1).set_Location(new Point(0, 0));
			((Control)tableLayoutPanel1).set_Name("tableLayoutPanel1");
			tableLayoutPanel1.set_RowCount(2);
			tableLayoutPanel1.get_RowStyles().Add((RowStyle)(object)new RowStyle((SizeType)1, 282f));
			tableLayoutPanel1.get_RowStyles().Add((RowStyle)(object)new RowStyle((SizeType)2, 100f));
			((Control)tableLayoutPanel1).set_Size(new Size(315, 549));
			((Control)tableLayoutPanel1).set_TabIndex(50);
			((Control)panel1).get_Controls().Add((Control)(object)label6);
			((Control)panel1).get_Controls().Add((Control)(object)checkBox2);
			((Control)panel1).get_Controls().Add((Control)(object)label1);
			((Control)panel1).get_Controls().Add((Control)(object)checkBox1);
			((Control)panel1).get_Controls().Add((Control)(object)label4);
			((Control)panel1).get_Controls().Add((Control)(object)label10);
			((Control)panel1).get_Controls().Add((Control)(object)label5);
			((Control)panel1).get_Controls().Add((Control)(object)numericUpDown2);
			((Control)panel1).get_Controls().Add((Control)(object)comboBox1);
			((Control)panel1).get_Controls().Add((Control)(object)label9);
			((Control)panel1).get_Controls().Add((Control)(object)comboBox2);
			((Control)panel1).get_Controls().Add((Control)(object)label7);
			((Control)panel1).get_Controls().Add((Control)(object)comboBox3);
			((Control)panel1).get_Controls().Add((Control)(object)button25);
			((Control)panel1).get_Controls().Add((Control)(object)button1);
			((Control)panel1).get_Controls().Add((Control)(object)numericUpDown1);
			((Control)panel1).get_Controls().Add((Control)(object)button2);
			((Control)panel1).get_Controls().Add((Control)(object)button3);
			((Control)panel1).set_Dock((DockStyle)5);
			((Control)panel1).set_Location(new Point(3, 3));
			((Control)panel1).set_Name("panel1");
			((Control)panel1).set_Size(new Size(309, 276));
			((Control)panel1).set_TabIndex(0);
			((ContainerControl)this).set_AutoScaleDimensions(new SizeF(6f, 13f));
			((ContainerControl)this).set_AutoScaleMode((AutoScaleMode)1);
			((Form)this).set_ClientSize(new Size(315, 549));
			((Control)this).get_Controls().Add((Control)(object)tableLayoutPanel1);
			((Form)this).set_Icon((Icon)(object)(Icon)((ResourceManager)(object)val).GetObject("$this.Icon"));
			((Control)this).set_MinimumSize(new Size(331, 353));
			((Control)this).set_Name("Invite");
			((Control)this).set_Text("Invite Builder: Targo v0.4b ");
			((Form)this).add_Load((EventHandler)EmbedOptions_Load);
			((ISupportInitialize)numericUpDown1).EndInit();
			((ISupportInitialize)numericUpDown2).EndInit();
			((ISupportInitialize)bindingSource1).EndInit();
			((Control)tableLayoutPanel1).ResumeLayout(false);
			((Control)panel1).ResumeLayout(false);
			((Control)panel1).PerformLayout();
			((Control)this).ResumeLayout(false);
		}
	}
}
