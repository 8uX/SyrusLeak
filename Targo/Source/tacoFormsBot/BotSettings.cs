using Discord;
using Discord.WebSocket;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace tacoFormsBot
{
	public class BotSettings : Form
	{
		private DiscordSocketClient _client;

		private IContainer components;

		private PictureBox pictureBox1;

		private TextBox textBox1;

		private Label label1;

		private Label label2;

		private Label label3;

		private TextBox textBox2;

		private Button button1;

		private CheckBox checkBox4;

		public BotSettings(DiscordSocketClient iclient)
			: this()
		{
			_client = iclient;
			InitializeComponent();
			pictureBox1.set_ImageLocation(((SocketUser)iclient.get_CurrentUser()).GetAvatarUrl((ImageFormat)0, (ushort)256));
			((Control)textBox1).set_Text(((SocketUser)iclient.get_CurrentUser()).get_Username());
			if (!((SocketUser)iclient.get_CurrentUser()).get_Game().HasValue)
			{
				((Control)textBox2).set_Text("Not playing any game :3");
			}
			else
			{
				((Control)textBox2).set_Text(((SocketUser)iclient.get_CurrentUser()).get_Game().ToString());
			}
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			string username = ((SocketUser)_client.get_CurrentUser()).get_Username();
			((SocketUser)_client.get_CurrentUser()).get_Game().ToString();
			if (((Control)textBox1).get_Text() != username)
			{
				if (!string.IsNullOrEmpty(((Control)textBox1).get_Text()))
				{
					await _client.get_CurrentUser().ModifyAsync((Action<SelfUserProperties>)delegate(SelfUserProperties x)
					{
						//IL_000c: Unknown result type (might be due to invalid IL or missing references)
						x.set_Username(Optional<string>.op_Implicit(((Control)textBox1).get_Text()));
					}, (RequestOptions)null);
				}
				else
				{
					MessageBox.Show("Enter text first");
				}
			}
			if (string.IsNullOrEmpty(((Control)textBox2).get_Text()))
			{
				MessageBox.Show("Enter text first");
			}
			else
			{
				await _client.SetGameAsync(((Control)textBox2).get_Text(), (string)null, (StreamType)0);
			}
		}

		private void BotSettings_Load(object sender, EventArgs e)
		{
		}

		private void checkBox4_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox4.get_Checked())
			{
				_client.SetStatusAsync((UserStatus)5);
			}
			else if (!checkBox4.get_Checked())
			{
				_client.SetStatusAsync((UserStatus)1);
			}
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
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_0210: Unknown result type (might be due to invalid IL or missing references)
			//IL_0240: Unknown result type (might be due to invalid IL or missing references)
			//IL_0267: Unknown result type (might be due to invalid IL or missing references)
			//IL_028a: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0313: Unknown result type (might be due to invalid IL or missing references)
			//IL_0337: Unknown result type (might be due to invalid IL or missing references)
			//IL_038c: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_044d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0457: Expected O, but got Unknown
			ComponentResourceManager val = (ComponentResourceManager)(object)new ComponentResourceManager(typeof(BotSettings));
			pictureBox1 = (PictureBox)(object)new PictureBox();
			textBox1 = (TextBox)(object)new TextBox();
			label1 = (Label)(object)new Label();
			label2 = (Label)(object)new Label();
			label3 = (Label)(object)new Label();
			textBox2 = (TextBox)(object)new TextBox();
			button1 = (Button)(object)new Button();
			checkBox4 = (CheckBox)(object)new CheckBox();
			((ISupportInitialize)pictureBox1).BeginInit();
			((Control)this).SuspendLayout();
			((Control)pictureBox1).set_Location(new Point(73, 75));
			((Control)pictureBox1).set_Name("pictureBox1");
			((Control)pictureBox1).set_Size(new Size(256, 256));
			pictureBox1.set_TabIndex(0);
			pictureBox1.set_TabStop(false);
			((Control)textBox1).set_Location(new Point(73, 10));
			((Control)textBox1).set_Name("textBox1");
			((Control)textBox1).set_Size(new Size(256, 20));
			((Control)textBox1).set_TabIndex(1);
			((Control)label1).set_AutoSize(true);
			((Control)label1).set_Location(new Point(29, 75));
			((Control)label1).set_Name("label1");
			((Control)label1).set_Size(new Size(41, 13));
			((Control)label1).set_TabIndex(2);
			((Control)label1).set_Text("Avatar:");
			((Control)label2).set_AutoSize(true);
			((Control)label2).set_Location(new Point(29, 43));
			((Control)label2).set_Name("label2");
			((Control)label2).set_Size(new Size(38, 13));
			((Control)label2).set_TabIndex(3);
			((Control)label2).set_Text("Game:");
			((Control)label3).set_AutoSize(true);
			((Control)label3).set_Location(new Point(9, 13));
			((Control)label3).set_Name("label3");
			((Control)label3).set_Size(new Size(58, 13));
			((Control)label3).set_TabIndex(4);
			((Control)label3).set_Text("Username:");
			((Control)textBox2).set_Location(new Point(73, 40));
			((Control)textBox2).set_Name("textBox2");
			((Control)textBox2).set_Size(new Size(256, 20));
			((Control)textBox2).set_TabIndex(5);
			((Control)button1).set_Location(new Point(73, 340));
			((Control)button1).set_Name("button1");
			((Control)button1).set_Size(new Size(256, 23));
			((Control)button1).set_TabIndex(6);
			((Control)button1).set_Text("Apply Changes");
			((ButtonBase)button1).set_UseVisualStyleBackColor(true);
			((Control)button1).add_Click((EventHandler)button1_Click);
			((Control)checkBox4).set_AutoSize(true);
			((Control)checkBox4).set_Location(new Point(73, 369));
			((Control)checkBox4).set_Name("checkBox4");
			((Control)checkBox4).set_Size(new Size(108, 17));
			((Control)checkBox4).set_TabIndex(18);
			((Control)checkBox4).set_Text("Bot Offline Status");
			((ButtonBase)checkBox4).set_UseVisualStyleBackColor(true);
			checkBox4.add_CheckedChanged((EventHandler)checkBox4_CheckedChanged);
			((ContainerControl)this).set_AutoScaleDimensions(new SizeF(6f, 13f));
			((ContainerControl)this).set_AutoScaleMode((AutoScaleMode)1);
			((Form)this).set_ClientSize(new Size(337, 395));
			((Control)this).get_Controls().Add((Control)(object)checkBox4);
			((Control)this).get_Controls().Add((Control)(object)button1);
			((Control)this).get_Controls().Add((Control)(object)textBox2);
			((Control)this).get_Controls().Add((Control)(object)label3);
			((Control)this).get_Controls().Add((Control)(object)label2);
			((Control)this).get_Controls().Add((Control)(object)label1);
			((Control)this).get_Controls().Add((Control)(object)textBox1);
			((Control)this).get_Controls().Add((Control)(object)pictureBox1);
			((Form)this).set_FormBorderStyle((FormBorderStyle)1);
			((Form)this).set_Icon((Icon)(object)(Icon)((ResourceManager)(object)val).GetObject("$this.Icon"));
			((Form)this).set_MaximizeBox(false);
			((Control)this).set_Name("BotSettings");
			((Control)this).set_Text("Bot Settings - Targo's Raid Client v0.4b");
			((Form)this).add_Load((EventHandler)BotSettings_Load);
			((ISupportInitialize)pictureBox1).EndInit();
			((Control)this).ResumeLayout(false);
			((Control)this).PerformLayout();
		}
	}
}
