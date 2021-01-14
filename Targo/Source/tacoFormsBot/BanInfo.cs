using Discord;
using Discord.Rest;
using Discord.WebSocket;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tacoFormsBot
{
	public class BanInfo : Form
	{
		private DiscordSocketClient _client;

		private IContainer components;

		private TableLayoutPanel tableLayoutPanel1;

		private Panel panel1;

		private Label label1;

		private ComboBox comboBox1;

		private ListView listView1;

		private ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem unbanToolStripMenuItem;

		private Button button1;

		public BanInfo(DiscordSocketClient iclient)
			: this()
		{
			_client = iclient;
			InitializeComponent();
		}

		private void BanInfo_Load(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				comboBox1.get_Items().Add((object)guild.get_Name());
			}
		}

		private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			await updateBans();
		}

		private async Task updateBans()
		{
			listView1.get_Items().Clear();
			listView1.get_Columns().Clear();
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
				{
					continue;
				}
				try
				{
					if (guild.GetBansAsync((RequestOptions)null).Result.Count != 0)
					{
						listView1.get_Columns().Add("ID", 100);
						listView1.get_Columns().Add("Username", 300);
						listView1.get_Columns().Add("Discrim", 60);
						listView1.get_Columns().Add("Reason", 400);
						foreach (RestBan item in guild.GetBansAsync((RequestOptions)null).Result)
						{
							ListViewItem val = (ListViewItem)(object)new ListViewItem(((IEntity<ulong>)(object)((IBan)item).get_User()).get_Id().ToString());
							val.get_SubItems().Add(((IBan)item).get_User().get_Username());
							val.get_SubItems().Add(((IBan)item).get_User().get_Discriminator().ToString());
							val.get_SubItems().Add(((IBan)item).get_Reason().ToString());
							listView1.get_Items().Add(val);
						}
					}
					else if (guild.GetBansAsync((RequestOptions)null).Result.Count == 0)
					{
						listView1.get_Columns().Add("Error Message", 700);
						listView1.get_Items().Add("Server has no bans");
					}
				}
				catch (Exception ex)
				{
					listView1.get_Columns().Add("Error Message", 700);
					listView1.get_Items().Add(ex.Message);
				}
			}
		}

		private async void unbanToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (guild.get_Name() == ((Control)comboBox1).get_Text())
				{
					try
					{
						ulong num = (ulong)long.Parse(listView1.get_SelectedItems().get_Item(0).get_SubItems()
							.get_Item(0)
							.get_Text());
						_client.GetUser(num);
						await guild.RemoveBanAsync(num, (RequestOptions)null);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}
			}
			updateBans();
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (guild.get_Name() == ((Control)comboBox1).get_Text())
				{
					try
					{
						foreach (RestBan item in guild.GetBansAsync((RequestOptions)null).Result)
						{
							IUser user = ((IBan)item).get_User();
							await guild.RemoveBanAsync(user, (RequestOptions)null);
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}
				updateBans();
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
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Expected O, but got Unknown
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Expected O, but got Unknown
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Expected O, but got Unknown
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Expected O, but got Unknown
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Expected O, but got Unknown
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Expected O, but got Unknown
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Expected O, but got Unknown
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Expected O, but got Unknown
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Expected O, but got Unknown
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01da: Unknown result type (might be due to invalid IL or missing references)
			//IL_0204: Unknown result type (might be due to invalid IL or missing references)
			//IL_026b: Unknown result type (might be due to invalid IL or missing references)
			//IL_028f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0316: Unknown result type (might be due to invalid IL or missing references)
			//IL_033d: Unknown result type (might be due to invalid IL or missing references)
			//IL_035f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0383: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0406: Unknown result type (might be due to invalid IL or missing references)
			//IL_0441: Unknown result type (might be due to invalid IL or missing references)
			//IL_0468: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_04bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ed: Expected O, but got Unknown
			//IL_04f8: Unknown result type (might be due to invalid IL or missing references)
			components = (IContainer)(object)new Container();
			ComponentResourceManager val = (ComponentResourceManager)(object)new ComponentResourceManager(typeof(BanInfo));
			tableLayoutPanel1 = (TableLayoutPanel)(object)new TableLayoutPanel();
			listView1 = (ListView)(object)new ListView();
			contextMenuStrip1 = (ContextMenuStrip)(object)new ContextMenuStrip(components);
			unbanToolStripMenuItem = (ToolStripMenuItem)(object)new ToolStripMenuItem();
			panel1 = (Panel)(object)new Panel();
			button1 = (Button)(object)new Button();
			label1 = (Label)(object)new Label();
			comboBox1 = (ComboBox)(object)new ComboBox();
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
			tableLayoutPanel1.get_RowStyles().Add((RowStyle)(object)new RowStyle((SizeType)1, 40f));
			tableLayoutPanel1.get_RowStyles().Add((RowStyle)(object)new RowStyle((SizeType)2, 100f));
			((Control)tableLayoutPanel1).set_Size(new Size(789, 559));
			((Control)tableLayoutPanel1).set_TabIndex(0);
			listView1.set_AllowColumnReorder(true);
			((Control)listView1).set_ContextMenuStrip(contextMenuStrip1);
			((Control)listView1).set_Dock((DockStyle)5);
			listView1.set_FullRowSelect(true);
			listView1.set_GridLines(true);
			((Control)listView1).set_Location(new Point(3, 43));
			((Control)listView1).set_Name("listView1");
			((Control)listView1).set_Size(new Size(783, 513));
			((Control)listView1).set_TabIndex(7);
			listView1.set_UseCompatibleStateImageBehavior(false);
			listView1.set_View((View)1);
			((ToolStrip)contextMenuStrip1).get_Items().AddRange((ToolStripItem[])(object)new ToolStripItem[1]
			{
				(ToolStripItem)unbanToolStripMenuItem
			});
			((Control)contextMenuStrip1).set_Name("contextMenuStrip1");
			((Control)contextMenuStrip1).set_Size(new Size(110, 26));
			((ToolStripItem)unbanToolStripMenuItem).set_Name("unbanToolStripMenuItem");
			((ToolStripItem)unbanToolStripMenuItem).set_Size(new Size(109, 22));
			((ToolStripItem)unbanToolStripMenuItem).set_Text("Unban");
			((ToolStripItem)unbanToolStripMenuItem).add_Click((EventHandler)unbanToolStripMenuItem_Click);
			((Control)panel1).get_Controls().Add((Control)(object)button1);
			((Control)panel1).get_Controls().Add((Control)(object)label1);
			((Control)panel1).get_Controls().Add((Control)(object)comboBox1);
			((Control)panel1).set_Dock((DockStyle)5);
			((Control)panel1).set_Location(new Point(3, 3));
			((Control)panel1).set_Name("panel1");
			((Control)panel1).set_Size(new Size(783, 34));
			((Control)panel1).set_TabIndex(1);
			((Control)button1).set_Location(new Point(261, 6));
			((Control)button1).set_Name("button1");
			((Control)button1).set_Size(new Size(75, 23));
			((Control)button1).set_TabIndex(2);
			((Control)button1).set_Text("Unban All");
			((ButtonBase)button1).set_UseVisualStyleBackColor(true);
			((Control)button1).add_Click((EventHandler)button1_Click);
			((Control)label1).set_AutoSize(true);
			((Control)label1).set_Location(new Point(9, 11));
			((Control)label1).set_Name("label1");
			((Control)label1).set_Size(new Size(41, 13));
			((Control)label1).set_TabIndex(1);
			((Control)label1).set_Text("Server:");
			((ListControl)comboBox1).set_FormattingEnabled(true);
			((Control)comboBox1).set_Location(new Point(56, 8));
			((Control)comboBox1).set_Name("comboBox1");
			((Control)comboBox1).set_Size(new Size(199, 21));
			((Control)comboBox1).set_TabIndex(0);
			comboBox1.add_SelectedIndexChanged((EventHandler)comboBox1_SelectedIndexChanged);
			((ContainerControl)this).set_AutoScaleDimensions(new SizeF(6f, 13f));
			((ContainerControl)this).set_AutoScaleMode((AutoScaleMode)1);
			((Form)this).set_ClientSize(new Size(789, 559));
			((Control)this).get_Controls().Add((Control)(object)tableLayoutPanel1);
			((Form)this).set_Icon((Icon)(object)(Icon)((ResourceManager)(object)val).GetObject("$this.Icon"));
			((Control)this).set_MinimumSize(new Size(365, 150));
			((Control)this).set_Name("BanInfo");
			((Control)this).set_Text("Ban Info - Targo v0.4b");
			((Form)this).add_Load((EventHandler)BanInfo_Load);
			((Control)tableLayoutPanel1).ResumeLayout(false);
			((Control)contextMenuStrip1).ResumeLayout(false);
			((Control)panel1).ResumeLayout(false);
			((Control)panel1).PerformLayout();
			((Control)this).ResumeLayout(false);
		}
	}
}
