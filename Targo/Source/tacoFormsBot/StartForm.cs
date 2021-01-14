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
	public class StartForm : Form
	{
		private IContainer components;

		private Button button1;

		private Button button2;

		private RichTextBox richTextBox1;

		private Label label1;

		public StartForm()
			: this()
		{
			InitializeComponent();
			StreamReader streamReader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("tacoFormsBot.textTerms.txt"));
			((Control)richTextBox1).set_Text(streamReader.ReadToEnd());
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			((Control)this).Hide();
			((Form)new Main1()).ShowDialog();
			((Form)this).Close();
		}

		private void StartForm_Load(object sender, EventArgs e)
		{
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Process.Start("https://goo.gl/zE3jmp");
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
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Expected O, but got Unknown
			//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_022c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0248: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b3: Expected O, but got Unknown
			ComponentResourceManager val = (ComponentResourceManager)(object)new ComponentResourceManager(typeof(StartForm));
			button1 = (Button)(object)new Button();
			button2 = (Button)(object)new Button();
			richTextBox1 = (RichTextBox)(object)new RichTextBox();
			label1 = (Label)(object)new Label();
			((Control)this).SuspendLayout();
			((Control)button1).set_Location(new Point(12, 200));
			((Control)button1).set_Name("button1");
			((Control)button1).set_Size(new Size(81, 24));
			((Control)button1).set_TabIndex(0);
			((Control)button1).set_Text("Continue");
			((ButtonBase)button1).set_UseVisualStyleBackColor(true);
			((Control)button1).add_Click((EventHandler)button1_Click);
			((Control)button2).set_Location(new Point(284, 200));
			((Control)button2).set_Name("button2");
			((Control)button2).set_Size(new Size(146, 24));
			((Control)button2).set_TabIndex(1);
			((Control)button2).set_Text("Join Discord Server");
			((ButtonBase)button2).set_UseVisualStyleBackColor(true);
			((Control)button2).add_Click((EventHandler)button2_Click);
			((Control)richTextBox1).set_Location(new Point(12, 33));
			((Control)richTextBox1).set_Name("richTextBox1");
			((TextBoxBase)richTextBox1).set_ReadOnly(true);
			((Control)richTextBox1).set_Size(new Size(418, 161));
			((Control)richTextBox1).set_TabIndex(3);
			((Control)richTextBox1).set_Text("");
			((Control)label1).set_AutoSize(true);
			((Control)label1).set_Font((Font)(object)new Font("Microsoft Sans Serif", 13.6f, (FontStyle)1, (GraphicsUnit)3, (byte)0));
			((Control)label1).set_Location(new Point(12, 6));
			((Control)label1).set_Name("label1");
			((Control)label1).set_Size(new Size(242, 24));
			((Control)label1).set_TabIndex(4);
			((Control)label1).set_Text("Targo 0.4b - Tacotad.xyz");
			((ContainerControl)this).set_AutoScaleDimensions(new SizeF(6f, 13f));
			((ContainerControl)this).set_AutoScaleMode((AutoScaleMode)1);
			((Form)this).set_ClientSize(new Size(436, 230));
			((Control)this).get_Controls().Add((Control)(object)label1);
			((Control)this).get_Controls().Add((Control)(object)richTextBox1);
			((Control)this).get_Controls().Add((Control)(object)button2);
			((Control)this).get_Controls().Add((Control)(object)button1);
			((Form)this).set_FormBorderStyle((FormBorderStyle)2);
			((Form)this).set_Icon((Icon)(object)(Icon)((ResourceManager)(object)val).GetObject("$this.Icon"));
			((Form)this).set_MaximizeBox(false);
			((Form)this).set_MinimizeBox(false);
			((Control)this).set_Name("StartForm");
			((Control)this).set_RightToLeft((RightToLeft)0);
			((Control)this).set_Text("Targo v0.4b");
			((Form)this).add_Load((EventHandler)StartForm_Load);
			((Control)this).ResumeLayout(false);
			((Control)this).PerformLayout();
		}
	}
}
