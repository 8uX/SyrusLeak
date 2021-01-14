using Discord;
using Discord.WebSocket;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tacoFormsBot
{
	public class InfoRoleForm : Form
	{
		private DiscordSocketClient _client;

		private IContainer components;

		private TableLayoutPanel tableLayoutPanel1;

		private ListView listView1;

		private Panel panel1;

		private ComboBox comboBox1;

		private Label label1;

		private ColumnHeader columnHeader11;

		private ColumnHeader columnHeader12;

		private ColumnHeader columnHeader13;

		private ColumnHeader columnHeader14;

		private ColumnHeader columnHeader15;

		private Label label3;

		private Label label2;

		private ColumnHeader columnHeader1;

		private CheckBox checkBox1;

		private CheckBox checkBox2;

		private ColumnHeader columnHeader2;

		private ColumnHeader columnHeader3;

		private ColumnHeader columnHeader4;

		private ColumnHeader columnHeader5;

		private ColumnHeader columnHeader6;

		private ColumnHeader columnHeader7;

		private ColumnHeader columnHeader8;

		private ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem deleteRoleToolStripMenuItem;

		private Button button1;

		private Label label4;

		private Button button2;

		private ToolStripMenuItem giveAllPermsToolStripMenuItem;

		private ToolStripMenuItem adminToolStripMenuItem;

		private ToolStripMenuItem tTSToolStripMenuItem;

		private ColumnHeader columnHeader9;

		private ColumnHeader columnHeader10;

		public InfoRoleForm(DiscordSocketClient iclient)
			: this()
		{
			_client = iclient;
			InitializeComponent();
		}

		private void InfoRoleForm_Load(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				comboBox1.get_Items().Add((object)guild.get_Name());
			}
		}

		private async Task updateRoleList()
		{
			listView1.get_Items().Clear();
			try
			{
				foreach (SocketGuild guild in _client.get_Guilds())
				{
					if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
					{
						continue;
					}
					((Control)label2).set_Text("Members: " + guild.get_Users().Count);
					((Control)label3).set_Text("Owner: " + ((SocketUser)guild.get_Owner()).get_Username());
					foreach (SocketRole role in guild.get_Roles())
					{
						ListViewItem val = (ListViewItem)(object)new ListViewItem(((IEntity<ulong>)(object)role).get_Id().ToString());
						if (checkBox2.get_Checked() || !((IRole)role).get_IsManaged())
						{
							val.get_SubItems().Add(((IRole)role).get_Name());
							Color color;
							if (checkBox1.get_Checked())
							{
								color = ((IRole)role).get_Color();
								val.set_ForeColor(ColorTranslator.FromHtml(((object)(Color)(ref color)).ToString()));
							}
							ListViewSubItemCollection subItems = val.get_SubItems();
							color = ((IRole)role).get_Color();
							subItems.Add(((object)(Color)(ref color)).ToString());
							val.get_SubItems().Add(((IRole)role).get_Position().ToString());
							if (((IRole)role).get_IsManaged())
							{
								val.get_SubItems().Add("Bot");
								val.set_BackColor(Color.get_LightGray());
							}
							else if (!((IRole)role).get_IsManaged())
							{
								val.get_SubItems().Add("User");
							}
							ListViewSubItemCollection subItems2 = val.get_SubItems();
							GuildPermissions permissions = ((IRole)role).get_Permissions();
							subItems2.Add(((object)(GuildPermissions)(ref permissions)).ToString());
							permissions = ((IRole)role).get_Permissions();
							if (((GuildPermissions)(ref permissions)).get_Administrator())
							{
								val.get_SubItems().Add("True");
							}
							else
							{
								val.get_SubItems().Add("False");
							}
							permissions = ((IRole)role).get_Permissions();
							if (((GuildPermissions)(ref permissions)).get_ManageRoles())
							{
								val.get_SubItems().Add("True");
							}
							else
							{
								val.get_SubItems().Add("False");
							}
							permissions = ((IRole)role).get_Permissions();
							if (((GuildPermissions)(ref permissions)).get_ManageChannels())
							{
								val.get_SubItems().Add("True");
							}
							else
							{
								val.get_SubItems().Add("False");
							}
							permissions = ((IRole)role).get_Permissions();
							if (((GuildPermissions)(ref permissions)).get_ManageGuild())
							{
								val.get_SubItems().Add("True");
							}
							else
							{
								val.get_SubItems().Add("False");
							}
							permissions = ((IRole)role).get_Permissions();
							if (((GuildPermissions)(ref permissions)).get_KickMembers())
							{
								val.get_SubItems().Add("True");
							}
							else
							{
								val.get_SubItems().Add("False");
							}
							permissions = ((IRole)role).get_Permissions();
							if (((GuildPermissions)(ref permissions)).get_BanMembers())
							{
								val.get_SubItems().Add("True");
							}
							else
							{
								val.get_SubItems().Add("False");
							}
							permissions = ((IRole)role).get_Permissions();
							if (((GuildPermissions)(ref permissions)).get_SendTTSMessages())
							{
								val.get_SubItems().Add("True");
							}
							else
							{
								val.get_SubItems().Add("False");
							}
							permissions = ((IRole)role).get_Permissions();
							if (((GuildPermissions)(ref permissions)).get_CreateInstantInvite())
							{
								val.get_SubItems().Add("True");
							}
							else
							{
								val.get_SubItems().Add("False");
							}
							permissions = ((IRole)role).get_Permissions();
							if (((GuildPermissions)(ref permissions)).get_MoveMembers())
							{
								val.get_SubItems().Add("True");
							}
							else
							{
								val.get_SubItems().Add("False");
							}
							listView1.get_Items().Add(val);
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}

		private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			await updateRoleList();
		}

		private async void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			await updateRoleList();
		}

		private async void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			await updateRoleList();
		}

		private async void deleteRoleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				foreach (SocketRole role in guild.get_Roles())
				{
					if (listView1.get_SelectedItems().get_Count() == 0)
					{
						return;
					}
					if (((IEntity<ulong>)(object)role).get_Id().ToString() == listView1.get_SelectedItems().get_Item(0).get_SubItems()
						.get_Item(0)
						.get_Text())
					{
						try
						{
							await ((IDeletable)role).DeleteAsync((RequestOptions)null);
							await updateRoleList();
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message);
						}
					}
				}
			}
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
				{
					continue;
				}
				foreach (SocketRole role in guild.get_Roles())
				{
					try
					{
						await ((IDeletable)role).DeleteAsync((RequestOptions)null);
						await updateRoleList();
					}
					catch (Exception ex)
					{
						((Control)label4).set_Text("Log: " + ex.Message);
					}
				}
			}
		}

		private async void button2_Click(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (guild.get_Name() == ((Control)comboBox1).get_Text())
				{
					try
					{
						GuildPermissions all = GuildPermissions.All;
						await guild.CreateRoleAsync("Admin", (GuildPermissions?)all, (Color?)null, false, (RequestOptions)null);
						await updateRoleList();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}
			}
		}

		private async void giveAllPermsToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private async void adminToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GuildPermissions adminPerms;
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
				{
					continue;
				}
				foreach (SocketRole role in guild.get_Roles())
				{
					if (listView1.get_SelectedItems().get_Count() == 0)
					{
						return;
					}
					if (!(((IEntity<ulong>)(object)role).get_Id().ToString() == listView1.get_SelectedItems().get_Item(0).get_SubItems()
						.get_Item(0)
						.get_Text()))
					{
						continue;
					}
					try
					{
						adminPerms = GuildPermissions.All;
						await ((IRole)role).ModifyAsync((Action<RoleProperties>)delegate(RoleProperties x)
						{
							//IL_0002: Unknown result type (might be due to invalid IL or missing references)
							//IL_0007: Unknown result type (might be due to invalid IL or missing references)
							x.set_Permissions(Optional<GuildPermissions>.op_Implicit(adminPerms));
						}, (RequestOptions)null);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}
			}
		}

		private async void tTSToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
				{
					continue;
				}
				foreach (SocketRole role in guild.get_Roles())
				{
					if (listView1.get_SelectedItems().get_Count() == 0)
					{
						return;
					}
					if (((IEntity<ulong>)(object)role).get_Id().ToString() == listView1.get_SelectedItems().get_Item(0).get_SubItems()
						.get_Item(0)
						.get_Text())
					{
						try
						{
							MessageBox.Show("Broken fix this fuck me kms why dont you work argh");
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message);
						}
					}
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
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Expected O, but got Unknown
			//IL_0177: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Expected O, but got Unknown
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Expected O, but got Unknown
			//IL_0214: Unknown result type (might be due to invalid IL or missing references)
			//IL_024b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0255: Expected O, but got Unknown
			//IL_0267: Unknown result type (might be due to invalid IL or missing references)
			//IL_0271: Expected O, but got Unknown
			//IL_0282: Unknown result type (might be due to invalid IL or missing references)
			//IL_0386: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0600: Unknown result type (might be due to invalid IL or missing references)
			//IL_0627: Unknown result type (might be due to invalid IL or missing references)
			//IL_069d: Unknown result type (might be due to invalid IL or missing references)
			//IL_06e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0733: Unknown result type (might be due to invalid IL or missing references)
			//IL_083e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0865: Unknown result type (might be due to invalid IL or missing references)
			//IL_0888: Unknown result type (might be due to invalid IL or missing references)
			//IL_08ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_090e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0932: Unknown result type (might be due to invalid IL or missing references)
			//IL_0966: Unknown result type (might be due to invalid IL or missing references)
			//IL_098a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a01: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a25: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a9c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ac0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b21: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b45: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b83: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ba7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0be2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c09: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c4a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c6e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c9f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0cbb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ce2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0cec: Expected O, but got Unknown
			//IL_0cf7: Unknown result type (might be due to invalid IL or missing references)
			components = (IContainer)(object)new Container();
			ComponentResourceManager val = (ComponentResourceManager)(object)new ComponentResourceManager(typeof(InfoRoleForm));
			tableLayoutPanel1 = (TableLayoutPanel)(object)new TableLayoutPanel();
			listView1 = (ListView)(object)new ListView();
			columnHeader11 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader12 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader1 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader13 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader14 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader15 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader2 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader3 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader4 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader5 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader6 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader7 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader8 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader9 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader10 = (ColumnHeader)(object)new ColumnHeader();
			contextMenuStrip1 = (ContextMenuStrip)(object)new ContextMenuStrip(components);
			deleteRoleToolStripMenuItem = (ToolStripMenuItem)(object)new ToolStripMenuItem();
			giveAllPermsToolStripMenuItem = (ToolStripMenuItem)(object)new ToolStripMenuItem();
			adminToolStripMenuItem = (ToolStripMenuItem)(object)new ToolStripMenuItem();
			tTSToolStripMenuItem = (ToolStripMenuItem)(object)new ToolStripMenuItem();
			panel1 = (Panel)(object)new Panel();
			button2 = (Button)(object)new Button();
			label4 = (Label)(object)new Label();
			button1 = (Button)(object)new Button();
			checkBox2 = (CheckBox)(object)new CheckBox();
			checkBox1 = (CheckBox)(object)new CheckBox();
			label3 = (Label)(object)new Label();
			label2 = (Label)(object)new Label();
			comboBox1 = (ComboBox)(object)new ComboBox();
			label1 = (Label)(object)new Label();
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
			tableLayoutPanel1.get_RowStyles().Add((RowStyle)(object)new RowStyle((SizeType)1, 60f));
			tableLayoutPanel1.get_RowStyles().Add((RowStyle)(object)new RowStyle((SizeType)2, 100f));
			((Control)tableLayoutPanel1).set_Size(new Size(987, 506));
			((Control)tableLayoutPanel1).set_TabIndex(0);
			listView1.set_AllowColumnReorder(true);
			listView1.get_Columns().AddRange((ColumnHeader[])(object)new ColumnHeader[15]
			{
				columnHeader11,
				columnHeader12,
				columnHeader1,
				columnHeader13,
				columnHeader14,
				columnHeader15,
				columnHeader2,
				columnHeader3,
				columnHeader4,
				columnHeader5,
				columnHeader6,
				columnHeader7,
				columnHeader8,
				columnHeader9,
				columnHeader10
			});
			((Control)listView1).set_ContextMenuStrip(contextMenuStrip1);
			((Control)listView1).set_Dock((DockStyle)5);
			listView1.set_FullRowSelect(true);
			listView1.set_GridLines(true);
			((Control)listView1).set_Location(new Point(3, 63));
			((Control)listView1).set_Name("listView1");
			((Control)listView1).set_Size(new Size(981, 440));
			((Control)listView1).set_TabIndex(6);
			listView1.set_UseCompatibleStateImageBehavior(false);
			listView1.set_View((View)1);
			columnHeader11.set_Text("Role ID");
			columnHeader11.set_Width(121);
			columnHeader12.set_Text("Role Name");
			columnHeader12.set_Width(167);
			columnHeader1.set_Text("Color");
			columnHeader1.set_Width(74);
			columnHeader13.set_Text("Role Num");
			columnHeader13.set_Width(62);
			columnHeader14.set_Text("Type");
			columnHeader14.set_Width(55);
			columnHeader15.set_Text("Perm Value");
			columnHeader15.set_Width(78);
			columnHeader2.set_Text("Admin");
			columnHeader2.set_Width(50);
			columnHeader3.set_Text("Manage Roles");
			columnHeader3.set_Width(85);
			columnHeader4.set_Text("Manage Channels");
			columnHeader4.set_Width(100);
			columnHeader5.set_DisplayIndex(10);
			columnHeader5.set_Text("Kick");
			columnHeader5.set_Width(38);
			columnHeader6.set_DisplayIndex(11);
			columnHeader6.set_Text("Ban");
			columnHeader6.set_Width(42);
			columnHeader7.set_DisplayIndex(9);
			columnHeader7.set_Text("Manage Server");
			columnHeader7.set_Width(91);
			columnHeader8.set_Text("TTS");
			columnHeader8.set_Width(47);
			columnHeader9.set_Text("Create Invite");
			columnHeader9.set_Width(76);
			columnHeader10.set_Text("Move Members");
			columnHeader10.set_Width(90);
			((ToolStrip)contextMenuStrip1).get_Items().AddRange((ToolStripItem[])(object)new ToolStripItem[2]
			{
				(ToolStripItem)deleteRoleToolStripMenuItem,
				(ToolStripItem)giveAllPermsToolStripMenuItem
			});
			((Control)contextMenuStrip1).set_Name("contextMenuStrip1");
			((Control)contextMenuStrip1).set_Size(new Size(137, 48));
			((ToolStripItem)deleteRoleToolStripMenuItem).set_Name("deleteRoleToolStripMenuItem");
			((ToolStripItem)deleteRoleToolStripMenuItem).set_Size(new Size(136, 22));
			((ToolStripItem)deleteRoleToolStripMenuItem).set_Text("Delete Role");
			((ToolStripItem)deleteRoleToolStripMenuItem).add_Click((EventHandler)deleteRoleToolStripMenuItem_Click);
			((ToolStripDropDownItem)giveAllPermsToolStripMenuItem).get_DropDownItems().AddRange((ToolStripItem[])(object)new ToolStripItem[2]
			{
				(ToolStripItem)adminToolStripMenuItem,
				(ToolStripItem)tTSToolStripMenuItem
			});
			((ToolStripItem)giveAllPermsToolStripMenuItem).set_Name("giveAllPermsToolStripMenuItem");
			((ToolStripItem)giveAllPermsToolStripMenuItem).set_Size(new Size(136, 22));
			((ToolStripItem)giveAllPermsToolStripMenuItem).set_Text("Edit Role To");
			((ToolStripItem)giveAllPermsToolStripMenuItem).add_Click((EventHandler)giveAllPermsToolStripMenuItem_Click);
			((ToolStripItem)adminToolStripMenuItem).set_Name("adminToolStripMenuItem");
			((ToolStripItem)adminToolStripMenuItem).set_Size(new Size(110, 22));
			((ToolStripItem)adminToolStripMenuItem).set_Text("Admin");
			((ToolStripItem)adminToolStripMenuItem).add_Click((EventHandler)adminToolStripMenuItem_Click);
			((ToolStripItem)tTSToolStripMenuItem).set_Name("tTSToolStripMenuItem");
			((ToolStripItem)tTSToolStripMenuItem).set_Size(new Size(110, 22));
			((ToolStripItem)tTSToolStripMenuItem).set_Text("TTS");
			((ToolStripItem)tTSToolStripMenuItem).add_Click((EventHandler)tTSToolStripMenuItem_Click);
			((Control)panel1).get_Controls().Add((Control)(object)button2);
			((Control)panel1).get_Controls().Add((Control)(object)label4);
			((Control)panel1).get_Controls().Add((Control)(object)button1);
			((Control)panel1).get_Controls().Add((Control)(object)checkBox2);
			((Control)panel1).get_Controls().Add((Control)(object)checkBox1);
			((Control)panel1).get_Controls().Add((Control)(object)label3);
			((Control)panel1).get_Controls().Add((Control)(object)label2);
			((Control)panel1).get_Controls().Add((Control)(object)comboBox1);
			((Control)panel1).get_Controls().Add((Control)(object)label1);
			((Control)panel1).set_Dock((DockStyle)5);
			((Control)panel1).set_Location(new Point(3, 3));
			((Control)panel1).set_Name("panel1");
			((Control)panel1).set_Size(new Size(981, 54));
			((Control)panel1).set_TabIndex(7);
			((Control)button2).set_Location(new Point(420, 30));
			((Control)button2).set_Name("button2");
			((Control)button2).set_Size(new Size(116, 20));
			((Control)button2).set_TabIndex(11);
			((Control)button2).set_Text("Create Admin Role");
			((ButtonBase)button2).set_UseVisualStyleBackColor(true);
			((Control)button2).add_Click((EventHandler)button2_Click);
			((Control)label4).set_AutoSize(true);
			((Control)label4).set_Location(new Point(629, 6));
			((Control)label4).set_Name("label4");
			((Control)label4).set_Size(new Size(31, 13));
			((Control)label4).set_TabIndex(10);
			((Control)label4).set_Text("Log: ");
			((Control)button1).set_Location(new Point(545, 30));
			((Control)button1).set_Name("button1");
			((Control)button1).set_Size(new Size(75, 20));
			((Control)button1).set_TabIndex(9);
			((Control)button1).set_Text("Delete All");
			((ButtonBase)button1).set_UseVisualStyleBackColor(true);
			((Control)button1).add_Click((EventHandler)button1_Click);
			((Control)checkBox2).set_AutoSize(true);
			checkBox2.set_Checked(true);
			checkBox2.set_CheckState((CheckState)1);
			((Control)checkBox2).set_Location(new Point(8, 30));
			((Control)checkBox2).set_Name("checkBox2");
			((Control)checkBox2).set_Size(new Size(102, 17));
			((Control)checkBox2).set_TabIndex(8);
			((Control)checkBox2).set_Text("Show Bot Roles");
			((ButtonBase)checkBox2).set_UseVisualStyleBackColor(true);
			checkBox2.add_CheckedChanged((EventHandler)checkBox2_CheckedChanged);
			((Control)checkBox1).set_AutoSize(true);
			checkBox1.set_Checked(true);
			checkBox1.set_CheckState((CheckState)1);
			((Control)checkBox1).set_Location(new Point(113, 30));
			((Control)checkBox1).set_Name("checkBox1");
			((Control)checkBox1).set_Size(new Size(97, 17));
			((Control)checkBox1).set_TabIndex(7);
			((Control)checkBox1).set_Text("Use Role Color");
			((ButtonBase)checkBox1).set_UseVisualStyleBackColor(true);
			checkBox1.add_CheckedChanged((EventHandler)checkBox1_CheckedChanged);
			((Control)label3).set_AutoSize(true);
			((Control)label3).set_Location(new Point(396, 6));
			((Control)label3).set_Name("label3");
			((Control)label3).set_Size(new Size(44, 13));
			((Control)label3).set_TabIndex(6);
			((Control)label3).set_Text("Owner: ");
			((Control)label2).set_AutoSize(true);
			((Control)label2).set_Location(new Point(303, 6));
			((Control)label2).set_Name("label2");
			((Control)label2).set_Size(new Size(56, 13));
			((Control)label2).set_TabIndex(5);
			((Control)label2).set_Text("Members: ");
			((ListControl)comboBox1).set_FormattingEnabled(true);
			((Control)comboBox1).set_Location(new Point(47, 3));
			((Control)comboBox1).set_Name("comboBox1");
			((Control)comboBox1).set_Size(new Size(250, 21));
			((Control)comboBox1).set_TabIndex(1);
			comboBox1.add_SelectedIndexChanged((EventHandler)comboBox1_SelectedIndexChanged);
			((Control)label1).set_AutoSize(true);
			((Control)label1).set_Location(new Point(3, 6));
			((Control)label1).set_Name("label1");
			((Control)label1).set_Size(new Size(41, 13));
			((Control)label1).set_TabIndex(0);
			((Control)label1).set_Text("Server:");
			((ContainerControl)this).set_AutoScaleDimensions(new SizeF(6f, 13f));
			((ContainerControl)this).set_AutoScaleMode((AutoScaleMode)1);
			((Form)this).set_ClientSize(new Size(987, 506));
			((Control)this).get_Controls().Add((Control)(object)tableLayoutPanel1);
			((Form)this).set_Icon((Icon)(object)(Icon)((ResourceManager)(object)val).GetObject("$this.Icon"));
			((Control)this).set_MinimumSize(new Size(720, 187));
			((Control)this).set_Name("InfoRoleForm");
			((Control)this).set_Text("Role Info - Targo v0.4b");
			((Form)this).add_Load((EventHandler)InfoRoleForm_Load);
			((Control)tableLayoutPanel1).ResumeLayout(false);
			((Control)contextMenuStrip1).ResumeLayout(false);
			((Control)panel1).ResumeLayout(false);
			((Control)panel1).PerformLayout();
			((Control)this).ResumeLayout(false);
		}
	}
}
