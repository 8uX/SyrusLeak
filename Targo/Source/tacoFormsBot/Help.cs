using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace tacoFormsBot
{
	public class Help : Form
	{
		private IContainer components;

		private Label label1;

		private PictureBox pictureBox1;

		private RichTextBox richTextBox1;

		private Label label2;

		private Label label3;

		private TableLayoutPanel tableLayoutPanel1;

		private Panel panel1;

		private Panel panel2;

		private Panel panel3;

		private Button button1;

		private Label label6;

		private Button button2;

		private Label label5;

		private Button button3;

		private Label label4;

		public Help()
			: this()
		{
			InitializeComponent();
			StreamReader streamReader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("tacoFormsBot.text4.txt"));
			((Control)richTextBox1).set_Text(streamReader.ReadToEnd());
		}

		private void label1_Click(object sender, EventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Process.Start("https://github.com/reactiflux/discord-irc/wiki/Creating-a-discord-bot-&-getting-a-token");
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Process.Start("https://github.com/TheRacingLion/Discord-SelfBot/wiki/Discord-Token-Tutorial");
		}

		private void Help_Load(object sender, EventArgs e)
		{
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Process.Start("https://discordapi.com/permissions.html");
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
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Expected O, but got Unknown
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0199: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Expected O, but got Unknown
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_021c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0226: Expected O, but got Unknown
			//IL_022e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0270: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_0325: Unknown result type (might be due to invalid IL or missing references)
			//IL_0349: Unknown result type (might be due to invalid IL or missing references)
			//IL_038c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0396: Expected O, but got Unknown
			//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_042a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0434: Expected O, but got Unknown
			//IL_0446: Unknown result type (might be due to invalid IL or missing references)
			//IL_0450: Expected O, but got Unknown
			//IL_0462: Unknown result type (might be due to invalid IL or missing references)
			//IL_046c: Expected O, but got Unknown
			//IL_047d: Unknown result type (might be due to invalid IL or missing references)
			//IL_04bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_056b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0592: Unknown result type (might be due to invalid IL or missing references)
			//IL_05b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_05d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0628: Unknown result type (might be due to invalid IL or missing references)
			//IL_064f: Unknown result type (might be due to invalid IL or missing references)
			//IL_06b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_06d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0704: Unknown result type (might be due to invalid IL or missing references)
			//IL_072b: Unknown result type (might be due to invalid IL or missing references)
			//IL_078d: Unknown result type (might be due to invalid IL or missing references)
			//IL_07b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_07ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_0815: Unknown result type (might be due to invalid IL or missing references)
			//IL_08d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_08ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0920: Unknown result type (might be due to invalid IL or missing references)
			//IL_093c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0963: Unknown result type (might be due to invalid IL or missing references)
			//IL_096d: Expected O, but got Unknown
			//IL_0986: Unknown result type (might be due to invalid IL or missing references)
			ComponentResourceManager val = (ComponentResourceManager)(object)new ComponentResourceManager(typeof(Help));
			label1 = (Label)(object)new Label();
			pictureBox1 = (PictureBox)(object)new PictureBox();
			richTextBox1 = (RichTextBox)(object)new RichTextBox();
			label2 = (Label)(object)new Label();
			label3 = (Label)(object)new Label();
			tableLayoutPanel1 = (TableLayoutPanel)(object)new TableLayoutPanel();
			panel1 = (Panel)(object)new Panel();
			panel2 = (Panel)(object)new Panel();
			button3 = (Button)(object)new Button();
			button2 = (Button)(object)new Button();
			label4 = (Label)(object)new Label();
			button1 = (Button)(object)new Button();
			label5 = (Label)(object)new Label();
			label6 = (Label)(object)new Label();
			panel3 = (Panel)(object)new Panel();
			((ISupportInitialize)pictureBox1).BeginInit();
			((Control)tableLayoutPanel1).SuspendLayout();
			((Control)panel1).SuspendLayout();
			((Control)panel2).SuspendLayout();
			((Control)panel3).SuspendLayout();
			((Control)this).SuspendLayout();
			((Control)label1).set_AutoSize(true);
			((Control)label1).set_Font((Font)(object)new Font("Microsoft Sans Serif", 14f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)label1).set_Location(new Point(73, 3));
			((Control)label1).set_Name("label1");
			((Control)label1).set_Size(new Size(218, 24));
			((Control)label1).set_TabIndex(0);
			((Control)label1).set_Text("Targo's Raid Client v0.4b");
			((Control)label1).add_Click((EventHandler)label1_Click);
			pictureBox1.set_Image((Image)(object)(Image)((ResourceManager)(object)val).GetObject("pictureBox1.Image"));
			((Control)pictureBox1).set_Location(new Point(3, 3));
			((Control)pictureBox1).set_Name("pictureBox1");
			((Control)pictureBox1).set_Size(new Size(64, 64));
			pictureBox1.set_SizeMode((PictureBoxSizeMode)1);
			pictureBox1.set_TabIndex(1);
			pictureBox1.set_TabStop(false);
			((Control)richTextBox1).set_Dock((DockStyle)5);
			((Control)richTextBox1).set_Font((Font)(object)new Font("Microsoft Sans Serif", 11f, (FontStyle)0, (GraphicsUnit)3, (byte)0));
			((Control)richTextBox1).set_Location(new Point(0, 0));
			((Control)richTextBox1).set_Name("richTextBox1");
			((TextBoxBase)richTextBox1).set_ReadOnly(true);
			richTextBox1.set_ShowSelectionMargin(true);
			((Control)richTextBox1).set_Size(new Size(552, 419));
			((Control)richTextBox1).set_TabIndex(4);
			((Control)richTextBox1).set_Text("");
			((Control)richTextBox1).add_TextChanged((EventHandler)richTextBox1_TextChanged);
			((Control)label2).set_AutoSize(true);
			((Control)label2).set_Location(new Point(73, 27));
			((Control)label2).set_Name("label2");
			((Control)label2).set_Size(new Size(280, 13));
			((Control)label2).set_TabIndex(5);
			((Control)label2).set_Text("Targo's Raid Client uses the Discord API to \"raid\" servers.\r\n");
			((Control)label3).set_AutoSize(true);
			((Control)label3).set_Location(new Point(0, 70));
			((Control)label3).set_Name("label3");
			((Control)label3).set_Size(new Size(95, 13));
			((Control)label3).set_TabIndex(6);
			((Control)label3).set_Text("Information / Help:");
			tableLayoutPanel1.set_ColumnCount(1);
			tableLayoutPanel1.get_ColumnStyles().Add((ColumnStyle)(object)new ColumnStyle((SizeType)2, 100f));
			tableLayoutPanel1.get_Controls().Add((Control)(object)panel1, 0, 1);
			tableLayoutPanel1.get_Controls().Add((Control)(object)panel2, 0, 0);
			tableLayoutPanel1.get_Controls().Add((Control)(object)panel3, 0, 2);
			((Control)tableLayoutPanel1).set_Dock((DockStyle)5);
			((Control)tableLayoutPanel1).set_Location(new Point(0, 0));
			((Control)tableLayoutPanel1).set_Name("tableLayoutPanel1");
			tableLayoutPanel1.set_RowCount(3);
			tableLayoutPanel1.get_RowStyles().Add((RowStyle)(object)new RowStyle((SizeType)1, 94f));
			tableLayoutPanel1.get_RowStyles().Add((RowStyle)(object)new RowStyle((SizeType)2, 100f));
			tableLayoutPanel1.get_RowStyles().Add((RowStyle)(object)new RowStyle((SizeType)1, 106f));
			((Control)tableLayoutPanel1).set_Size(new Size(558, 625));
			((Control)tableLayoutPanel1).set_TabIndex(13);
			((Control)panel1).get_Controls().Add((Control)(object)richTextBox1);
			((Control)panel1).set_Dock((DockStyle)5);
			((Control)panel1).set_Location(new Point(3, 97));
			((Control)panel1).set_Name("panel1");
			((Control)panel1).set_Size(new Size(552, 419));
			((Control)panel1).set_TabIndex(0);
			((Control)panel2).get_Controls().Add((Control)(object)pictureBox1);
			((Control)panel2).get_Controls().Add((Control)(object)label3);
			((Control)panel2).get_Controls().Add((Control)(object)label1);
			((Control)panel2).get_Controls().Add((Control)(object)label2);
			((Control)panel2).set_Dock((DockStyle)5);
			((Control)panel2).set_Location(new Point(3, 3));
			((Control)panel2).set_Name("panel2");
			((Control)panel2).set_Size(new Size(552, 88));
			((Control)panel2).set_TabIndex(1);
			((Control)button3).set_Location(new Point(3, 67));
			((Control)button3).set_Name("button3");
			((Control)button3).set_Size(new Size(112, 26));
			((Control)button3).set_TabIndex(9);
			((Control)button3).set_Text("Bot Invite Creator");
			((ButtonBase)button3).set_UseVisualStyleBackColor(true);
			((Control)button3).add_Click((EventHandler)button3_Click);
			((Control)button2).set_Location(new Point(3, 35));
			((Control)button2).set_Name("button2");
			((Control)button2).set_Size(new Size(153, 26));
			((Control)button2).set_TabIndex(8);
			((Control)button2).set_Text("Getting Discord User Token");
			((ButtonBase)button2).set_UseVisualStyleBackColor(true);
			((Control)button2).add_Click((EventHandler)button2_Click);
			((Control)label4).set_AutoSize(true);
			((Control)label4).set_Location(new Point(227, 10));
			((Control)label4).set_Name("label4");
			((Control)label4).set_Size(new Size(84, 13));
			((Control)label4).set_TabIndex(10);
			((Control)label4).set_Text("<- Get bot token");
			((Control)button1).set_Location(new Point(3, 3));
			((Control)button1).set_Name("button1");
			((Control)button1).set_Size(new Size(218, 26));
			((Control)button1).set_TabIndex(7);
			((Control)button1).set_Text("Creating a Discord Bot and Getting Token");
			((ButtonBase)button1).set_UseVisualStyleBackColor(true);
			((Control)button1).add_Click((EventHandler)button1_Click);
			((Control)label5).set_AutoSize(true);
			((Control)label5).set_Location(new Point(162, 42));
			((Control)label5).set_Name("label5");
			((Control)label5).set_Size(new Size(89, 13));
			((Control)label5).set_TabIndex(11);
			((Control)label5).set_Text("<- Get user token");
			((Control)label6).set_AutoSize(true);
			((Control)label6).set_Location(new Point(121, 67));
			((Control)label6).set_Name("label6");
			((Control)label6).set_Size(new Size(264, 26));
			((Control)label6).set_TabIndex(12);
			((Control)label6).set_Text("<- Create invite code \r\nMAKE SURE YOU SELECT ADMIN PERMISSIONS!!!");
			((Control)panel3).get_Controls().Add((Control)(object)button1);
			((Control)panel3).get_Controls().Add((Control)(object)label6);
			((Control)panel3).get_Controls().Add((Control)(object)button2);
			((Control)panel3).get_Controls().Add((Control)(object)label5);
			((Control)panel3).get_Controls().Add((Control)(object)button3);
			((Control)panel3).get_Controls().Add((Control)(object)label4);
			((Control)panel3).set_Dock((DockStyle)5);
			((Control)panel3).set_Location(new Point(3, 522));
			((Control)panel3).set_Name("panel3");
			((Control)panel3).set_Size(new Size(552, 100));
			((Control)panel3).set_TabIndex(2);
			((ContainerControl)this).set_AutoScaleDimensions(new SizeF(6f, 13f));
			((ContainerControl)this).set_AutoScaleMode((AutoScaleMode)1);
			((Form)this).set_ClientSize(new Size(558, 625));
			((Control)this).get_Controls().Add((Control)(object)tableLayoutPanel1);
			((Form)this).set_Icon((Icon)(object)(Icon)((ResourceManager)(object)val).GetObject("$this.Icon"));
			((Form)this).set_MaximizeBox(false);
			((Form)this).set_MinimizeBox(false);
			((Control)this).set_MinimumSize(new Size(421, 273));
			((Control)this).set_Name("Help");
			((Control)this).set_Text("Help");
			((Form)this).add_Load((EventHandler)Help_Load);
			((ISupportInitialize)pictureBox1).EndInit();
			((Control)tableLayoutPanel1).ResumeLayout(false);
			((Control)panel1).ResumeLayout(false);
			((Control)panel2).ResumeLayout(false);
			((Control)panel2).PerformLayout();
			((Control)panel3).ResumeLayout(false);
			((Control)panel3).PerformLayout();
			((Control)this).ResumeLayout(false);
		}
	}
}
