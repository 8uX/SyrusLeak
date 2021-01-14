using Discord;
using Discord.WebSocket;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace tacoFormsBot
{
	public class ToolsGuild : Form
	{
		private DiscordSocketClient _client;

		private IContainer components;

		private Label label1;

		private Label label2;

		private PictureBox pictureBox1;

		private ComboBox comboBox1;

		private OpenFileDialog openFileDialog1;

		private Button button1;

		private TextBox textBox1;

		private Label label3;

		public ToolsGuild(DiscordSocketClient iclient)
			: this()
		{
			_client = iclient;
			InitializeComponent();
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				comboBox1.get_Items().Add((object)guild.get_Name());
			}
		}

		private void ToolsGuild_Load(object sender, EventArgs e)
		{
		}

		private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			pictureBox1.set_Image((Image)null);
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (guild.get_Name() == ((Control)comboBox1).get_Text())
				{
					if (string.IsNullOrEmpty(guild.get_IconUrl()))
					{
						MessageBox.Show($"{guild.get_Name()} is missing a icon");
					}
					else
					{
						pictureBox1.set_ImageLocation(guild.get_IconUrl().ToString());
					}
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Invalid comparison between Unknown and I4
			if ((int)((CommonDialog)openFileDialog1).ShowDialog() == 1)
			{
				string fileName = ((FileDialog)openFileDialog1).get_FileName();
				pictureBox1.set_ImageLocation(fileName);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(((Control)textBox1).get_Text()))
			{
				return;
			}
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (guild.get_Name() == ((Control)comboBox1).get_Text())
				{
					guild.ModifyAsync((Action<GuildProperties>)delegate(GuildProperties x)
					{
						//IL_000c: Unknown result type (might be due to invalid IL or missing references)
						x.set_Name(new Optional<string>(((Control)textBox1).get_Text()));
					}, (RequestOptions)null);
				}
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
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0222: Unknown result type (might be due to invalid IL or missing references)
			//IL_0249: Unknown result type (might be due to invalid IL or missing references)
			//IL_029f: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0319: Unknown result type (might be due to invalid IL or missing references)
			//IL_034a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0366: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0404: Expected O, but got Unknown
			ComponentResourceManager val = (ComponentResourceManager)(object)new ComponentResourceManager(typeof(ToolsGuild));
			comboBox1 = (ComboBox)(object)new ComboBox();
			label1 = (Label)(object)new Label();
			label2 = (Label)(object)new Label();
			pictureBox1 = (PictureBox)(object)new PictureBox();
			openFileDialog1 = (OpenFileDialog)(object)new OpenFileDialog();
			button1 = (Button)(object)new Button();
			textBox1 = (TextBox)(object)new TextBox();
			label3 = (Label)(object)new Label();
			((ISupportInitialize)pictureBox1).BeginInit();
			((Control)this).SuspendLayout();
			((ListControl)comboBox1).set_FormattingEnabled(true);
			((Control)comboBox1).set_Location(new Point(59, 12));
			((Control)comboBox1).set_Name("comboBox1");
			((Control)comboBox1).set_Size(new Size(256, 21));
			((Control)comboBox1).set_TabIndex(1);
			comboBox1.add_SelectedIndexChanged((EventHandler)comboBox1_SelectedIndexChanged_1);
			((Control)label1).set_AutoSize(true);
			((Control)label1).set_Location(new Point(12, 15));
			((Control)label1).set_Name("label1");
			((Control)label1).set_Size(new Size(41, 13));
			((Control)label1).set_TabIndex(2);
			((Control)label1).set_Text("Server:");
			((Control)label2).set_AutoSize(true);
			((Control)label2).set_Location(new Point(19, 39));
			((Control)label2).set_Name("label2");
			((Control)label2).set_Size(new Size(31, 13));
			((Control)label2).set_TabIndex(3);
			((Control)label2).set_Text("Icon:");
			((Control)pictureBox1).set_Location(new Point(59, 39));
			((Control)pictureBox1).set_Name("pictureBox1");
			((Control)pictureBox1).set_Size(new Size(256, 256));
			pictureBox1.set_SizeMode((PictureBoxSizeMode)1);
			pictureBox1.set_TabIndex(4);
			pictureBox1.set_TabStop(false);
			((FileDialog)openFileDialog1).set_FileName("openFileDialog1");
			((Control)button1).set_Location(new Point(59, 327));
			((Control)button1).set_Name("button1");
			((Control)button1).set_Size(new Size(256, 23));
			((Control)button1).set_TabIndex(5);
			((Control)button1).set_Text("Apply Changes");
			((ButtonBase)button1).set_UseVisualStyleBackColor(true);
			((Control)button1).add_Click((EventHandler)button1_Click);
			((Control)textBox1).set_Location(new Point(59, 301));
			((Control)textBox1).set_Name("textBox1");
			((Control)textBox1).set_Size(new Size(256, 20));
			((Control)textBox1).set_TabIndex(6);
			((Control)label3).set_AutoSize(true);
			((Control)label3).set_Location(new Point(15, 304));
			((Control)label3).set_Name("label3");
			((Control)label3).set_Size(new Size(35, 13));
			((Control)label3).set_TabIndex(7);
			((Control)label3).set_Text("New: ");
			((ContainerControl)this).set_AutoScaleDimensions(new SizeF(6f, 13f));
			((ContainerControl)this).set_AutoScaleMode((AutoScaleMode)1);
			((Form)this).set_ClientSize(new Size(321, 357));
			((Control)this).get_Controls().Add((Control)(object)label3);
			((Control)this).get_Controls().Add((Control)(object)textBox1);
			((Control)this).get_Controls().Add((Control)(object)button1);
			((Control)this).get_Controls().Add((Control)(object)pictureBox1);
			((Control)this).get_Controls().Add((Control)(object)label2);
			((Control)this).get_Controls().Add((Control)(object)label1);
			((Control)this).get_Controls().Add((Control)(object)comboBox1);
			((Form)this).set_FormBorderStyle((FormBorderStyle)1);
			((Form)this).set_Icon((Icon)(object)(Icon)((ResourceManager)(object)val).GetObject("$this.Icon"));
			((Control)this).set_Name("ToolsGuild");
			((Control)this).set_Text("Server Tools - Targo v0.4b");
			((Form)this).add_Load((EventHandler)ToolsGuild_Load);
			((ISupportInitialize)pictureBox1).EndInit();
			((Control)this).ResumeLayout(false);
			((Control)this).PerformLayout();
		}
	}
}
