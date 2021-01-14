using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tacoFormsBot
{
	public class InfoMessages : Form
	{
		private DiscordSocketClient _client;

		private IContainer components;

		private TableLayoutPanel tableLayoutPanel1;

		private Panel panel1;

		private ListView listView1;

		private ColumnHeader columnHeader16;

		private ColumnHeader columnHeader17;

		private ComboBox comboBox2;

		private ComboBox comboBox1;

		private ColumnHeader columnHeader1;

		private ColumnHeader columnHeader2;

		private ColumnHeader columnHeader3;

		private ColumnHeader columnHeader4;

		private CheckBox checkBox1;

		private Label label2;

		private Label label1;

		private CheckBox checkBox3;

		private Label label3;

		private CheckBox checkBox2;

		private Label label4;

		private CheckBox checkBox4;

		private CheckBox checkBox5;

		private ColumnHeader columnHeader5;

		private ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem copyMessageToolStripMenuItem;

		private ToolStripMenuItem copyURLToolStripMenuItem;

		private ColumnHeader columnHeader6;

		private ColumnHeader columnHeader7;

		private CheckBox checkBox6;

		private CheckBox checkBox7;

		private Button button1;

		private CheckBox checkBox8;

		public InfoMessages(DiscordSocketClient iclient)
			: this()
		{
			_client = iclient;
			InitializeComponent();
			_client.add_MessageReceived((Func<SocketMessage, Task>)messageLog);
			_client.add_MessageUpdated((Func<Cacheable<IMessage, ulong>, SocketMessage, ISocketMessageChannel, Task>)_client_MessageUpdated);
		}

		private async Task _client_MessageUpdated(Cacheable<IMessage, ulong> arg1, SocketMessage msg, ISocketMessageChannel msgChannel)
		{
			SocketTextChannel msgChan = default(SocketTextChannel);
			ref SocketTextChannel val = ref msgChan;
			ISocketMessageChannel channel = msg.get_Channel();
			val = (channel as SocketTextChannel);
			SocketGuild msgGuild = ((SocketGuildChannel)msgChan).get_Guild();
			((Control)this).Invoke((Delegate)(Action)delegate
			{
				//IL_008f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0095: Expected O, but got Unknown
				if (checkBox5.get_Checked())
				{
					if (checkBox2.get_Checked())
					{
						if (msgGuild.get_Name().ToString() != ((Control)comboBox1).get_Text())
						{
							return;
						}
					}
					else if (checkBox3.get_Checked() && ((SocketGuildChannel)msgChan).get_Name() != ((Control)comboBox2).get_Text())
					{
						return;
					}
					ListViewItem val2 = (ListViewItem)(object)new ListViewItem(DateTime.Now.ToString());
					val2.get_SubItems().Add(((SocketEntity<ulong>)(object)msg).get_Id().ToString());
					val2.get_SubItems().Add("EDIT");
					val2.get_SubItems().Add(msgGuild.get_Name());
					val2.get_SubItems().Add(((IChannel)msg.get_Channel()).get_Name());
					val2.get_SubItems().Add(msg.get_Author().get_Username());
					val2.get_SubItems().Add(msg.get_Author().get_Discriminator().ToString());
					val2.get_SubItems().Add(msg.get_Content().ToString());
					IAttachment val3 = (IAttachment)(object)Enumerable.FirstOrDefault<Attachment>((IEnumerable<Attachment>)msg.get_Attachments());
					if (val3 == null)
					{
						val2.get_SubItems().Add("NO FILE");
					}
					else
					{
						val2.get_SubItems().Add(val3.get_Url());
					}
					listView1.get_Items().Add(val2);
				}
			});
		}

		private void InfoMessages_Load(object sender, EventArgs e)
		{
			((Control)comboBox1).set_Enabled(false);
			((Control)comboBox2).set_Enabled(false);
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				comboBox1.get_Items().Add((object)guild.get_Name());
			}
		}

		private async Task messageLog(SocketMessage msg)
		{
			SocketTextChannel msgChan = default(SocketTextChannel);
			ref SocketTextChannel val = ref msgChan;
			ISocketMessageChannel channel = msg.get_Channel();
			val = (channel as SocketTextChannel);
			SocketGuild msgGuild = ((SocketGuildChannel)msgChan).get_Guild();
			((Control)this).Invoke((Delegate)(Action)delegate
			{
				//IL_008f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0095: Expected O, but got Unknown
				//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
				if (checkBox4.get_Checked())
				{
					if (checkBox2.get_Checked())
					{
						if (msgGuild.get_Name().ToString() != ((Control)comboBox1).get_Text())
						{
							return;
						}
					}
					else if (checkBox3.get_Checked() && ((SocketGuildChannel)msgChan).get_Name() != ((Control)comboBox2).get_Text())
					{
						return;
					}
					ListViewItem val2 = (ListViewItem)(object)new ListViewItem(DateTime.Now.ToString());
					val2.get_SubItems().Add(((SocketEntity<ulong>)(object)msg).get_Id().ToString());
					ListViewSubItemCollection subItems = val2.get_SubItems();
					MessageSource source = msg.get_Source();
					subItems.Add(((object)(MessageSource)(ref source)).ToString());
					val2.get_SubItems().Add(msgGuild.get_Name());
					val2.get_SubItems().Add(((IChannel)msg.get_Channel()).get_Name());
					val2.get_SubItems().Add(msg.get_Author().get_Username());
					val2.get_SubItems().Add(msg.get_Author().get_Discriminator().ToString());
					val2.get_SubItems().Add(msg.get_Content().ToString());
					IAttachment val3 = (IAttachment)(object)Enumerable.FirstOrDefault<Attachment>((IEnumerable<Attachment>)msg.get_Attachments());
					if (val3 == null)
					{
						val2.get_SubItems().Add("NO FILE");
					}
					else
					{
						val2.get_SubItems().Add(val3.get_Url());
					}
					listView1.get_Items().Add(val2);
				}
			});
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (!checkBox1.get_Checked())
			{
				((Control)comboBox1).set_Enabled(true);
				((Control)comboBox2).set_Enabled(true);
			}
			else if (checkBox1.get_Checked())
			{
				checkBox2.set_Checked(false);
				checkBox3.set_Checked(false);
				((Control)comboBox1).set_Enabled(false);
				((Control)comboBox2).set_Enabled(false);
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			comboBox2.get_Items().Clear();
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
			}
		}

		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			if (checkBox3.get_Checked())
			{
				checkBox1.set_Checked(false);
				checkBox2.set_Checked(false);
				if (string.IsNullOrEmpty(((Control)comboBox2).get_Text()))
				{
					MessageBox.Show("Select a guild");
				}
			}
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			if (checkBox2.get_Checked())
			{
				checkBox3.set_Checked(false);
				checkBox1.set_Checked(false);
				if (string.IsNullOrEmpty(((Control)comboBox1).get_Text()))
				{
					MessageBox.Show("Select a guild");
				}
			}
		}

		private void copyMessageToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.get_SelectedItems().get_Count() == 1 && !string.IsNullOrEmpty(listView1.get_SelectedItems().get_Item(0).get_SubItems()
				.get_Item(7)
				.get_Text()))
			{
				Clipboard.SetText(listView1.get_SelectedItems().get_Item(0).get_SubItems()
					.get_Item(7)
					.get_Text());
			}
		}

		private void copyURLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.get_SelectedItems().get_Count() == 1 && !string.IsNullOrEmpty(listView1.get_SelectedItems().get_Item(0).get_SubItems()
				.get_Item(8)
				.get_Text()))
			{
				Clipboard.SetText(listView1.get_SelectedItems().get_Item(0).get_SubItems()
					.get_Item(8)
					.get_Text());
			}
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void listView1_TabIndexChanged(object sender, EventArgs e)
		{
		}

		private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
		{
			if (checkBox8.get_Checked())
			{
				listView1.get_Items().get_Item(listView1.get_Items().get_Count() - 1).EnsureVisible();
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
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Expected O, but got Unknown
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Expected O, but got Unknown
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Expected O, but got Unknown
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Expected O, but got Unknown
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected O, but got Unknown
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Expected O, but got Unknown
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Expected O, but got Unknown
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Expected O, but got Unknown
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Expected O, but got Unknown
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Expected O, but got Unknown
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Expected O, but got Unknown
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Expected O, but got Unknown
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Expected O, but got Unknown
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0134: Expected O, but got Unknown
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Expected O, but got Unknown
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Expected O, but got Unknown
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Expected O, but got Unknown
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_0160: Expected O, but got Unknown
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Expected O, but got Unknown
			//IL_01af: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b9: Expected O, but got Unknown
			//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0235: Unknown result type (might be due to invalid IL or missing references)
			//IL_023f: Expected O, but got Unknown
			//IL_0251: Unknown result type (might be due to invalid IL or missing references)
			//IL_025b: Expected O, but got Unknown
			//IL_026c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0334: Unknown result type (might be due to invalid IL or missing references)
			//IL_035e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0399: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a3: Expected O, but got Unknown
			//IL_0517: Unknown result type (might be due to invalid IL or missing references)
			//IL_053e: Unknown result type (might be due to invalid IL or missing references)
			//IL_058c: Unknown result type (might be due to invalid IL or missing references)
			//IL_071b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0742: Unknown result type (might be due to invalid IL or missing references)
			//IL_077c: Unknown result type (might be due to invalid IL or missing references)
			//IL_07a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_07ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_0810: Unknown result type (might be due to invalid IL or missing references)
			//IL_0868: Unknown result type (might be due to invalid IL or missing references)
			//IL_088c: Unknown result type (might be due to invalid IL or missing references)
			//IL_08f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0914: Unknown result type (might be due to invalid IL or missing references)
			//IL_095f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0983: Unknown result type (might be due to invalid IL or missing references)
			//IL_09db: Unknown result type (might be due to invalid IL or missing references)
			//IL_09ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a4a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a6e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0acf: Unknown result type (might be due to invalid IL or missing references)
			//IL_0af3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b32: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b56: Unknown result type (might be due to invalid IL or missing references)
			//IL_0bb4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0bd8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c14: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c38: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c8f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0cb6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d21: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d48: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d7f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0da6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0deb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e0f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e4d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e69: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e90: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e9a: Expected O, but got Unknown
			components = (IContainer)(object)new Container();
			ComponentResourceManager val = (ComponentResourceManager)(object)new ComponentResourceManager(typeof(InfoMessages));
			tableLayoutPanel1 = (TableLayoutPanel)(object)new TableLayoutPanel();
			listView1 = (ListView)(object)new ListView();
			columnHeader6 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader7 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader1 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader2 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader3 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader16 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader4 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader17 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader5 = (ColumnHeader)(object)new ColumnHeader();
			contextMenuStrip1 = (ContextMenuStrip)(object)new ContextMenuStrip(components);
			copyMessageToolStripMenuItem = (ToolStripMenuItem)(object)new ToolStripMenuItem();
			copyURLToolStripMenuItem = (ToolStripMenuItem)(object)new ToolStripMenuItem();
			panel1 = (Panel)(object)new Panel();
			checkBox7 = (CheckBox)(object)new CheckBox();
			button1 = (Button)(object)new Button();
			checkBox6 = (CheckBox)(object)new CheckBox();
			checkBox5 = (CheckBox)(object)new CheckBox();
			label4 = (Label)(object)new Label();
			checkBox4 = (CheckBox)(object)new CheckBox();
			checkBox3 = (CheckBox)(object)new CheckBox();
			label3 = (Label)(object)new Label();
			checkBox2 = (CheckBox)(object)new CheckBox();
			label2 = (Label)(object)new Label();
			label1 = (Label)(object)new Label();
			checkBox1 = (CheckBox)(object)new CheckBox();
			comboBox2 = (ComboBox)(object)new ComboBox();
			comboBox1 = (ComboBox)(object)new ComboBox();
			checkBox8 = (CheckBox)(object)new CheckBox();
			((Control)tableLayoutPanel1).SuspendLayout();
			((Control)contextMenuStrip1).SuspendLayout();
			((Control)panel1).SuspendLayout();
			((Control)this).SuspendLayout();
			tableLayoutPanel1.set_ColumnCount(1);
			tableLayoutPanel1.get_ColumnStyles().Add((ColumnStyle)(object)new ColumnStyle((SizeType)2, 100f));
			tableLayoutPanel1.get_Controls().Add((Control)(object)listView1, 0, 1);
			tableLayoutPanel1.get_Controls().Add((Control)(object)panel1, 0, 0);
			((Control)tableLayoutPanel1).set_Dock((DockStyle)5);
			((Control)tableLayoutPanel1).set_Location(new Point(0, 0));
			((Control)tableLayoutPanel1).set_Name("tableLayoutPanel1");
			tableLayoutPanel1.set_RowCount(2);
			tableLayoutPanel1.get_RowStyles().Add((RowStyle)(object)new RowStyle((SizeType)1, 70f));
			tableLayoutPanel1.get_RowStyles().Add((RowStyle)(object)new RowStyle((SizeType)2, 100f));
			((Control)tableLayoutPanel1).set_Size(new Size(1090, 592));
			((Control)tableLayoutPanel1).set_TabIndex(0);
			listView1.set_AllowColumnReorder(true);
			listView1.get_Columns().AddRange((ColumnHeader[])(object)new ColumnHeader[9]
			{
				columnHeader6,
				columnHeader7,
				columnHeader1,
				columnHeader2,
				columnHeader3,
				columnHeader16,
				columnHeader4,
				columnHeader17,
				columnHeader5
			});
			((Control)listView1).set_ContextMenuStrip(contextMenuStrip1);
			((Control)listView1).set_Dock((DockStyle)5);
			listView1.set_FullRowSelect(true);
			listView1.set_GridLines(true);
			((Control)listView1).set_Location(new Point(3, 73));
			((Control)listView1).set_Name("listView1");
			((Control)listView1).set_Size(new Size(1084, 516));
			((Control)listView1).set_TabIndex(7);
			listView1.set_UseCompatibleStateImageBehavior(false);
			listView1.set_View((View)1);
			listView1.add_DrawItem((DrawListViewItemEventHandler)(object)new DrawListViewItemEventHandler(listView1_DrawItem));
			listView1.add_SelectedIndexChanged((EventHandler)listView1_SelectedIndexChanged);
			((Control)listView1).add_TabIndexChanged((EventHandler)listView1_TabIndexChanged);
			columnHeader6.set_Text("Time");
			columnHeader6.set_Width(134);
			columnHeader7.set_Text("Message ID");
			columnHeader7.set_Width(103);
			columnHeader1.set_Text("Type");
			columnHeader1.set_Width(54);
			columnHeader2.set_Text("Server");
			columnHeader2.set_Width(89);
			columnHeader3.set_Text("Channel");
			columnHeader3.set_Width(74);
			columnHeader16.set_Text("Username");
			columnHeader16.set_Width(75);
			columnHeader4.set_Text("Discrim");
			columnHeader17.set_Text("Message");
			columnHeader17.set_Width(372);
			columnHeader5.set_Text("File URL");
			columnHeader5.set_Width(292);
			((ToolStrip)contextMenuStrip1).get_Items().AddRange((ToolStripItem[])(object)new ToolStripItem[2]
			{
				(ToolStripItem)copyMessageToolStripMenuItem,
				(ToolStripItem)copyURLToolStripMenuItem
			});
			((Control)contextMenuStrip1).set_Name("contextMenuStrip1");
			((Control)contextMenuStrip1).set_Size(new Size(152, 48));
			((ToolStripItem)copyMessageToolStripMenuItem).set_Name("copyMessageToolStripMenuItem");
			((ToolStripItem)copyMessageToolStripMenuItem).set_Size(new Size(151, 22));
			((ToolStripItem)copyMessageToolStripMenuItem).set_Text("Copy Message");
			((ToolStripItem)copyMessageToolStripMenuItem).add_Click((EventHandler)copyMessageToolStripMenuItem_Click);
			((ToolStripItem)copyURLToolStripMenuItem).set_Name("copyURLToolStripMenuItem");
			((ToolStripItem)copyURLToolStripMenuItem).set_Size(new Size(151, 22));
			((ToolStripItem)copyURLToolStripMenuItem).set_Text("Copy File URL");
			((ToolStripItem)copyURLToolStripMenuItem).add_Click((EventHandler)copyURLToolStripMenuItem_Click);
			((Control)panel1).get_Controls().Add((Control)(object)checkBox8);
			((Control)panel1).get_Controls().Add((Control)(object)checkBox7);
			((Control)panel1).get_Controls().Add((Control)(object)button1);
			((Control)panel1).get_Controls().Add((Control)(object)checkBox6);
			((Control)panel1).get_Controls().Add((Control)(object)checkBox5);
			((Control)panel1).get_Controls().Add((Control)(object)label4);
			((Control)panel1).get_Controls().Add((Control)(object)checkBox4);
			((Control)panel1).get_Controls().Add((Control)(object)checkBox3);
			((Control)panel1).get_Controls().Add((Control)(object)label3);
			((Control)panel1).get_Controls().Add((Control)(object)checkBox2);
			((Control)panel1).get_Controls().Add((Control)(object)label2);
			((Control)panel1).get_Controls().Add((Control)(object)label1);
			((Control)panel1).get_Controls().Add((Control)(object)checkBox1);
			((Control)panel1).get_Controls().Add((Control)(object)comboBox2);
			((Control)panel1).get_Controls().Add((Control)(object)comboBox1);
			((Control)panel1).set_Dock((DockStyle)5);
			((Control)panel1).set_Location(new Point(3, 3));
			((Control)panel1).set_Name("panel1");
			((Control)panel1).set_Size(new Size(1084, 64));
			((Control)panel1).set_TabIndex(1);
			((Control)checkBox7).set_AutoSize(true);
			((Control)checkBox7).set_Enabled(false);
			((Control)checkBox7).set_Location(new Point(609, 6));
			((Control)checkBox7).set_Name("checkBox7");
			((Control)checkBox7).set_Size(new Size(93, 17));
			((Control)checkBox7).set_TabIndex(13);
			((Control)checkBox7).set_Text("Auto-Save log");
			((ButtonBase)checkBox7).set_UseVisualStyleBackColor(true);
			((Control)button1).set_Enabled(false);
			((Control)button1).set_Location(new Point(609, 24));
			((Control)button1).set_Name("button1");
			((Control)button1).set_Size(new Size(81, 36));
			((Control)button1).set_TabIndex(12);
			((Control)button1).set_Text("Save Log");
			((ButtonBase)button1).set_UseVisualStyleBackColor(true);
			((Control)checkBox6).set_AutoSize(true);
			((Control)checkBox6).set_Enabled(false);
			((Control)checkBox6).set_Location(new Point(458, 44));
			((Control)checkBox6).set_Name("checkBox6");
			((Control)checkBox6).set_Size(new Size(114, 17));
			((Control)checkBox6).set_TabIndex(11);
			((Control)checkBox6).set_Text("Deleted Messages");
			((ButtonBase)checkBox6).set_UseVisualStyleBackColor(true);
			((Control)checkBox5).set_AutoSize(true);
			checkBox5.set_Checked(true);
			checkBox5.set_CheckState((CheckState)1);
			((Control)checkBox5).set_Location(new Point(458, 28));
			((Control)checkBox5).set_Name("checkBox5");
			((Control)checkBox5).set_Size(new Size(95, 17));
			((Control)checkBox5).set_TabIndex(10);
			((Control)checkBox5).set_Text("Message Edits");
			((ButtonBase)checkBox5).set_UseVisualStyleBackColor(true);
			((Control)label4).set_AutoSize(true);
			((Control)label4).set_Location(new Point(455, 0));
			((Control)label4).set_Name("label4");
			((Control)label4).set_Size(new Size(37, 13));
			((Control)label4).set_TabIndex(9);
			((Control)label4).set_Text("Show:");
			((Control)checkBox4).set_AutoSize(true);
			checkBox4.set_Checked(true);
			checkBox4.set_CheckState((CheckState)1);
			((Control)checkBox4).set_Location(new Point(458, 13));
			((Control)checkBox4).set_Name("checkBox4");
			((Control)checkBox4).set_Size(new Size(123, 17));
			((Control)checkBox4).set_TabIndex(8);
			((Control)checkBox4).set_Text("Received Messages");
			((ButtonBase)checkBox4).set_UseVisualStyleBackColor(true);
			((Control)checkBox3).set_AutoSize(true);
			((Control)checkBox3).set_Location(new Point(246, 46));
			((Control)checkBox3).set_Name("checkBox3");
			((Control)checkBox3).set_Size(new Size(99, 17));
			((Control)checkBox3).set_TabIndex(7);
			((Control)checkBox3).set_Text("Server Channel");
			((ButtonBase)checkBox3).set_UseVisualStyleBackColor(true);
			checkBox3.add_CheckedChanged((EventHandler)checkBox3_CheckedChanged);
			((Control)label3).set_AutoSize(true);
			((Control)label3).set_Location(new Point(242, 0));
			((Control)label3).set_Name("label3");
			((Control)label3).set_Size(new Size(114, 13));
			((Control)label3).set_TabIndex(6);
			((Control)label3).set_Text("Show Messages From:");
			((Control)checkBox2).set_AutoSize(true);
			((Control)checkBox2).set_Location(new Point(246, 30));
			((Control)checkBox2).set_Name("checkBox2");
			((Control)checkBox2).set_Size(new Size(118, 17));
			((Control)checkBox2).set_TabIndex(5);
			((Control)checkBox2).set_Text("All Server Channels");
			((ButtonBase)checkBox2).set_UseVisualStyleBackColor(true);
			checkBox2.add_CheckedChanged((EventHandler)checkBox2_CheckedChanged);
			((Control)label2).set_AutoSize(true);
			((Control)label2).set_Location(new Point(5, 37));
			((Control)label2).set_Name("label2");
			((Control)label2).set_Size(new Size(49, 13));
			((Control)label2).set_TabIndex(4);
			((Control)label2).set_Text("Channel:");
			((Control)label1).set_AutoSize(true);
			((Control)label1).set_Location(new Point(11, 12));
			((Control)label1).set_Name("label1");
			((Control)label1).set_Size(new Size(41, 13));
			((Control)label1).set_TabIndex(3);
			((Control)label1).set_Text("Server:");
			((Control)checkBox1).set_AutoSize(true);
			checkBox1.set_Checked(true);
			checkBox1.set_CheckState((CheckState)1);
			((Control)checkBox1).set_Location(new Point(246, 13));
			((Control)checkBox1).set_Name("checkBox1");
			((Control)checkBox1).set_Size(new Size(145, 17));
			((Control)checkBox1).set_TabIndex(2);
			((Control)checkBox1).set_Text("All Servers / All Channels");
			((ButtonBase)checkBox1).set_UseVisualStyleBackColor(true);
			checkBox1.add_CheckedChanged((EventHandler)checkBox1_CheckedChanged);
			comboBox2.set_DropDownStyle((ComboBoxStyle)2);
			((ListControl)comboBox2).set_FormattingEnabled(true);
			((Control)comboBox2).set_Location(new Point(56, 33));
			((Control)comboBox2).set_Name("comboBox2");
			((Control)comboBox2).set_Size(new Size(180, 21));
			((Control)comboBox2).set_TabIndex(1);
			comboBox1.set_DropDownStyle((ComboBoxStyle)2);
			((ListControl)comboBox1).set_FormattingEnabled(true);
			((Control)comboBox1).set_Location(new Point(56, 6));
			((Control)comboBox1).set_Name("comboBox1");
			((Control)comboBox1).set_Size(new Size(180, 21));
			((Control)comboBox1).set_TabIndex(0);
			comboBox1.add_SelectedIndexChanged((EventHandler)comboBox1_SelectedIndexChanged);
			((Control)checkBox8).set_AutoSize(true);
			((Control)checkBox8).set_Location(new Point(708, 6));
			((Control)checkBox8).set_Name("checkBox8");
			((Control)checkBox8).set_Size(new Size(96, 17));
			((Control)checkBox8).set_TabIndex(14);
			((Control)checkBox8).set_Text("Auto-Scroll List");
			((ButtonBase)checkBox8).set_UseVisualStyleBackColor(true);
			((ContainerControl)this).set_AutoScaleDimensions(new SizeF(6f, 13f));
			((ContainerControl)this).set_AutoScaleMode((AutoScaleMode)1);
			((Form)this).set_ClientSize(new Size(1090, 592));
			((Control)this).get_Controls().Add((Control)(object)tableLayoutPanel1);
			((Form)this).set_Icon((Icon)(object)(Icon)((ResourceManager)(object)val).GetObject("$this.Icon"));
			((Control)this).set_Name("InfoMessages");
			((Control)this).set_Text("Targo - Message Logs");
			((Form)this).add_Load((EventHandler)InfoMessages_Load);
			((Control)tableLayoutPanel1).ResumeLayout(false);
			((Control)contextMenuStrip1).ResumeLayout(false);
			((Control)panel1).ResumeLayout(false);
			((Control)panel1).PerformLayout();
			((Control)this).ResumeLayout(false);
		}
	}
}
