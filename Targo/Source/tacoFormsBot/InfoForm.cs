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
	public class InfoForm : Form
	{
		private DiscordSocketClient _client;

		private IContainer components;

		private ComboBox comboBox1;

		private Label label1;

		private ListView listView1;

		private ColumnHeader columnHeader1;

		private ColumnHeader columnHeader2;

		private ColumnHeader columnHeader3;

		private TableLayoutPanel tableLayoutPanel1;

		private Panel panel1;

		private Label label3;

		private Label label2;

		private ColumnHeader columnHeader4;

		private ColumnHeader columnHeader5;

		private ColumnHeader columnHeader6;

		private ColumnHeader columnHeader7;

		private ColumnHeader columnHeader8;

		private ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem copyIDToolStripMenuItem;

		private ColumnHeader columnHeader9;

		private ColumnHeader columnHeader10;

		private ToolStripMenuItem giveRoleToolStripMenuItem;

		private ToolStripMenuItem banToolStripMenuItem;

		private ToolStripMenuItem rolesToolStripMenuItem;

		private ToolStripMenuItem giveRoleToolStripMenuItem1;

		private ToolStripMenuItem toolStripMenuItem1;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripSeparator toolStripSeparator1;

		private CheckBox checkBox1;

		private ToolStripSeparator toolStripSeparator3;

		private ToolStripMenuItem toolStripMenuItem2;

		private ToolStripMenuItem toolStripMenuItem3;

		private CheckBox checkBox2;

		public InfoForm(DiscordSocketClient iclient)
			: this()
		{
			_client = iclient;
			InitializeComponent();
		}

		private async void InfoForm_Load(object sender, EventArgs e)
		{
			await getGuilds();
		}

		private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			await getUsers();
		}

		private async Task getGuilds()
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				comboBox1.get_Items().Add((object)guild.get_Name());
			}
		}

		private async Task getUsers()
		{
			listView1.get_Items().Clear();
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
				{
					continue;
				}
				((Control)label2).set_Text("Members: " + guild.get_Users().Count);
				((Control)label3).set_Text("Owner: " + ((SocketUser)guild.get_Owner()).get_Username());
				foreach (SocketGuildUser user in guild.get_Users())
				{
					if (!checkBox2.get_Checked() && ((SocketUser)user).get_IsBot())
					{
						continue;
					}
					ListViewItem val = (ListViewItem)(object)new ListViewItem(((SocketEntity<ulong>)(object)user).get_Id().ToString());
					if (((SocketUser)user).get_IsBot())
					{
						val.set_BackColor(Color.get_LightGray());
					}
					if (((SocketEntity<ulong>)(object)user).get_Id() == ((SocketEntity<ulong>)(object)_client.get_CurrentUser()).get_Id())
					{
						val.set_BackColor(Color.get_LawnGreen());
					}
					val.get_SubItems().Add(user.get_Nickname());
					val.get_SubItems().Add(((SocketUser)user).get_Username());
					val.get_SubItems().Add(((SocketUser)user).get_Discriminator());
					ListViewSubItemCollection subItems = val.get_SubItems();
					UserStatus status = ((SocketUser)user).get_Status();
					subItems.Add(((object)(UserStatus)(ref status)).ToString());
					if (user.get_IsMuted())
					{
						val.get_SubItems().Add("true");
					}
					else if (!user.get_IsMuted())
					{
						val.get_SubItems().Add("false");
					}
					if (user.get_IsDeafened())
					{
						val.get_SubItems().Add("true");
					}
					else if (!user.get_IsDeafened())
					{
						val.get_SubItems().Add("false");
					}
					val.get_SubItems().Add(((SocketUser)user).get_Game().ToString());
					if (((SocketUser)user).get_IsBot())
					{
						val.get_SubItems().Add("Is Bot");
					}
					else if (!((SocketUser)user).get_IsBot())
					{
						val.get_SubItems().Add("User");
					}
					string text = "";
					foreach (SocketRole role in user.get_Roles())
					{
						text = text + ((IRole)role).get_Name() + ", ";
					}
					val.get_SubItems().Add(text);
					listView1.get_Items().Add(val);
				}
			}
		}

		private void copyIDToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.get_SelectedItems().get_Count() == 1)
			{
				Clipboard.SetText(listView1.get_SelectedItems().get_Item(0).get_SubItems()
					.get_Item(0)
					.get_Text());
			}
		}

		private async void giveRoleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.get_SelectedItems().get_Count() == 0)
			{
				return;
			}
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (guild.get_Name() == ((Control)comboBox1).get_Text())
				{
					ulong num = (ulong)long.Parse(listView1.get_SelectedItems().get_Item(0).get_SubItems()
						.get_Item(0)
						.get_Text());
					try
					{
						await guild.GetUser(num).KickAsync((string)null, (RequestOptions)null);
						await getUsers();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}
			}
		}

		private async void banToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listView1.get_SelectedItems().get_Count() == 0)
			{
				return;
			}
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (guild.get_Name() == ((Control)comboBox1).get_Text())
				{
					ulong num = (ulong)long.Parse(listView1.get_SelectedItems().get_Item(0).get_SubItems()
						.get_Item(0)
						.get_Text());
					try
					{
						await guild.AddBanAsync(num, 1, "Banned by Targo's Discord Raid Client", (RequestOptions)null);
						await getUsers();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}
			}
		}

		private async Task getUserRoles()
		{
			ToolStripItem obj = ((ToolStrip)contextMenuStrip1).get_Items().get_Item(6);
			((ToolStripDropDownItem)(obj as ToolStripMenuItem)).get_DropDownItems().Clear();
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
				{
					continue;
				}
				ulong num = (ulong)long.Parse(listView1.get_SelectedItems().get_Item(0).get_SubItems()
					.get_Item(0)
					.get_Text());
				foreach (SocketRole role in guild.GetUser(num).get_Roles())
				{
					ToolStripMenuItem val = (ToolStripMenuItem)(object)new ToolStripMenuItem();
					((ToolStripItem)val).set_Text(((IRole)role).get_Name());
					Color color = ((IRole)role).get_Color();
					((ToolStripItem)val).set_ForeColor(ColorTranslator.FromHtml(((object)(Color)(ref color)).ToString()));
					if (!checkBox1.get_Checked())
					{
						if (((IRole)role).get_IsManaged())
						{
							continue;
						}
					}
					else if (checkBox1.get_Checked() && ((IRole)role).get_IsManaged())
					{
						((ToolStripItem)val).set_BackColor(Color.get_LightCyan());
						((ToolStripItem)val).set_Enabled(false);
					}
					ToolStripItem obj2 = ((ToolStrip)contextMenuStrip1).get_Items().get_Item(6);
					((ToolStripDropDownItem)(obj2 as ToolStripMenuItem)).get_DropDownItems().Add((ToolStripItem)(object)val);
				}
			}
		}

		private async Task GetGuildRoles()
		{
			ToolStripItem obj = ((ToolStrip)contextMenuStrip1).get_Items().get_Item(7);
			((ToolStripDropDownItem)(obj as ToolStripMenuItem)).get_DropDownItems().Clear();
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
				{
					continue;
				}
				ulong num = (ulong)long.Parse(listView1.get_SelectedItems().get_Item(0).get_SubItems()
					.get_Item(0)
					.get_Text());
				guild.GetUser(num);
				ToolStripMenuItem val = (ToolStripMenuItem)(object)new ToolStripMenuItem();
				((ToolStripItem)val).set_Text("All Roles");
				((ToolStripItem)val).set_BackColor(Color.get_LightSteelBlue());
				((ToolStripItem)val).add_Click((EventHandler)allRolesToolStripMenuItem_Click);
				ToolStripItem obj2 = ((ToolStrip)contextMenuStrip1).get_Items().get_Item(7);
				((ToolStripDropDownItem)(obj2 as ToolStripMenuItem)).get_DropDownItems().Add((ToolStripItem)(object)val);
				foreach (SocketRole role in guild.get_Roles())
				{
					ToolStripMenuItem val2 = (ToolStripMenuItem)(object)new ToolStripMenuItem();
					((ToolStripItem)val2).set_Text(((IRole)role).get_Name());
					Color color = ((IRole)role).get_Color();
					((ToolStripItem)val2).set_ForeColor(ColorTranslator.FromHtml(((object)(Color)(ref color)).ToString()));
					if (!checkBox1.get_Checked())
					{
						if (((IRole)role).get_IsManaged())
						{
							continue;
						}
					}
					else if (checkBox1.get_Checked() && ((IRole)role).get_IsManaged())
					{
						((ToolStripItem)val2).set_BackColor(Color.get_LightCyan());
						((ToolStripItem)val2).set_Enabled(false);
					}
					((ToolStripItem)val2).add_Click((EventHandler)delegate(object sender2, EventArgs e2)
					{
						guildRole_Click(sender2, e2, ((IEntity<ulong>)(object)role).get_Id());
					});
					ToolStripItem obj3 = ((ToolStrip)contextMenuStrip1).get_Items().get_Item(7);
					((ToolStripDropDownItem)(obj3 as ToolStripMenuItem)).get_DropDownItems().Add((ToolStripItem)(object)val2);
				}
			}
		}

		private async void guildRole_Click(object sender, EventArgs e, ulong roleId)
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
						SocketGuildUser user = guild.GetUser(num);
						IRole role = (IRole)(object)guild.GetRole(roleId);
						await user.AddRoleAsync(role, (RequestOptions)null);
						MessageBox.Show(role.get_Name());
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}
			}
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private async void rolesToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private async void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{
			await getUserRoles();
			await GetGuildRoles();
		}

		private async void allRolesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
				{
					continue;
				}
				ulong num = (ulong)long.Parse(listView1.get_SelectedItems().get_Item(0).get_SubItems()
					.get_Item(0)
					.get_Text());
				SocketGuildUser roleUser = guild.GetUser(num);
				foreach (SocketRole role in guild.get_Roles())
				{
					if (((IRole)role).get_IsManaged())
					{
						return;
					}
					try
					{
						await roleUser.AddRoleAsync((IRole)(object)role, (RequestOptions)null);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message + "\nRole: " + ((IRole)role).get_Name());
					}
				}
			}
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (guild.get_Name() == ((Control)comboBox1).get_Text())
				{
					ulong num = (ulong)long.Parse(listView1.get_SelectedItems().get_Item(0).get_SubItems()
						.get_Item(0)
						.get_Text());
					SocketGuildUser user = guild.GetUser(num);
					MessageBox.Show(string.Concat("User Info: ", ((SocketUser)user).get_Username(), "#", ((SocketUser)user).get_Discriminator(), "\nNickname: ", user.get_Nickname(), "\nJoined: ", guild.get_Name(), " At: ", user.get_JoinedAt().ToString(), "\nCreated Account At: ", ((SocketUser)user).get_CreatedAt(), "\nIs Bot: ", ((SocketUser)user).get_IsBot().ToString(), "\nStatus: ", ((SocketUser)user).get_Status(), "\nGame: ", ((SocketUser)user).get_Game(), "\nHierarchy Position: ", user.get_Hierarchy()));
				}
			}
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (guild.get_Name() == ((Control)comboBox1).get_Text())
				{
					ulong num = (ulong)long.Parse(listView1.get_SelectedItems().get_Item(0).get_SubItems()
						.get_Item(0)
						.get_Text());
					guild.GetUser(num);
				}
			}
		}

		private async void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			await getUsers();
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
			//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_020f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0233: Unknown result type (might be due to invalid IL or missing references)
			//IL_0315: Unknown result type (might be due to invalid IL or missing references)
			//IL_033f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0507: Unknown result type (might be due to invalid IL or missing references)
			//IL_051e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0528: Expected O, but got Unknown
			//IL_0545: Unknown result type (might be due to invalid IL or missing references)
			//IL_0593: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0607: Unknown result type (might be due to invalid IL or missing references)
			//IL_0655: Unknown result type (might be due to invalid IL or missing references)
			//IL_06a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_06c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0717: Unknown result type (might be due to invalid IL or missing references)
			//IL_074d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0774: Unknown result type (might be due to invalid IL or missing references)
			//IL_07c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_07cc: Expected O, but got Unknown
			//IL_0811: Unknown result type (might be due to invalid IL or missing references)
			//IL_0848: Unknown result type (might be due to invalid IL or missing references)
			//IL_0852: Expected O, but got Unknown
			//IL_0864: Unknown result type (might be due to invalid IL or missing references)
			//IL_086e: Expected O, but got Unknown
			//IL_087f: Unknown result type (might be due to invalid IL or missing references)
			//IL_092d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0954: Unknown result type (might be due to invalid IL or missing references)
			//IL_099a: Unknown result type (might be due to invalid IL or missing references)
			//IL_09be: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a1f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a46: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a90: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ab4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0af2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b16: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b47: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b63: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b8a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b94: Expected O, but got Unknown
			components = (IContainer)(object)new Container();
			ComponentResourceManager val = (ComponentResourceManager)(object)new ComponentResourceManager(typeof(InfoForm));
			comboBox1 = (ComboBox)(object)new ComboBox();
			label1 = (Label)(object)new Label();
			listView1 = (ListView)(object)new ListView();
			columnHeader9 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader1 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader2 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader3 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader4 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader5 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader6 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader7 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader8 = (ColumnHeader)(object)new ColumnHeader();
			columnHeader10 = (ColumnHeader)(object)new ColumnHeader();
			contextMenuStrip1 = (ContextMenuStrip)(object)new ContextMenuStrip(components);
			copyIDToolStripMenuItem = (ToolStripMenuItem)(object)new ToolStripMenuItem();
			toolStripMenuItem1 = (ToolStripMenuItem)(object)new ToolStripMenuItem();
			toolStripSeparator2 = (ToolStripSeparator)(object)new ToolStripSeparator();
			giveRoleToolStripMenuItem = (ToolStripMenuItem)(object)new ToolStripMenuItem();
			banToolStripMenuItem = (ToolStripMenuItem)(object)new ToolStripMenuItem();
			toolStripSeparator1 = (ToolStripSeparator)(object)new ToolStripSeparator();
			rolesToolStripMenuItem = (ToolStripMenuItem)(object)new ToolStripMenuItem();
			giveRoleToolStripMenuItem1 = (ToolStripMenuItem)(object)new ToolStripMenuItem();
			toolStripSeparator3 = (ToolStripSeparator)(object)new ToolStripSeparator();
			toolStripMenuItem2 = (ToolStripMenuItem)(object)new ToolStripMenuItem();
			tableLayoutPanel1 = (TableLayoutPanel)(object)new TableLayoutPanel();
			panel1 = (Panel)(object)new Panel();
			checkBox2 = (CheckBox)(object)new CheckBox();
			checkBox1 = (CheckBox)(object)new CheckBox();
			label3 = (Label)(object)new Label();
			label2 = (Label)(object)new Label();
			((Control)contextMenuStrip1).SuspendLayout();
			((Control)tableLayoutPanel1).SuspendLayout();
			((Control)panel1).SuspendLayout();
			((Control)this).SuspendLayout();
			((ListControl)comboBox1).set_FormattingEnabled(true);
			((Control)comboBox1).set_Location(new Point(47, 2));
			((Control)comboBox1).set_Name("comboBox1");
			((Control)comboBox1).set_Size(new Size(260, 21));
			((Control)comboBox1).set_TabIndex(1);
			comboBox1.add_SelectedIndexChanged((EventHandler)comboBox1_SelectedIndexChanged);
			((Control)label1).set_AutoSize(true);
			((Control)label1).set_Location(new Point(4, 6));
			((Control)label1).set_Name("label1");
			((Control)label1).set_Size(new Size(41, 13));
			((Control)label1).set_TabIndex(2);
			((Control)label1).set_Text("Server:");
			listView1.set_AllowColumnReorder(true);
			listView1.get_Columns().AddRange((ColumnHeader[])(object)new ColumnHeader[10]
			{
				columnHeader9,
				columnHeader1,
				columnHeader2,
				columnHeader3,
				columnHeader4,
				columnHeader5,
				columnHeader6,
				columnHeader7,
				columnHeader8,
				columnHeader10
			});
			((Control)listView1).set_ContextMenuStrip(contextMenuStrip1);
			((Control)listView1).set_Dock((DockStyle)5);
			listView1.set_FullRowSelect(true);
			listView1.set_GridLines(true);
			((Control)listView1).set_Location(new Point(3, 33));
			((Control)listView1).set_Name("listView1");
			((Control)listView1).set_Size(new Size(874, 508));
			((Control)listView1).set_TabIndex(4);
			listView1.set_UseCompatibleStateImageBehavior(false);
			listView1.set_View((View)1);
			listView1.add_SelectedIndexChanged((EventHandler)listView1_SelectedIndexChanged);
			columnHeader9.set_Text("User ID");
			columnHeader1.set_Text("Nickname");
			columnHeader1.set_Width(117);
			columnHeader2.set_Text("Username");
			columnHeader2.set_Width(127);
			columnHeader3.set_Text("Discrim");
			columnHeader3.set_Width(50);
			columnHeader4.set_Text("Status");
			columnHeader4.set_Width(104);
			columnHeader5.set_Text("Muted");
			columnHeader6.set_Text("Deafened");
			columnHeader7.set_Text("Game");
			columnHeader8.set_Text("Type");
			columnHeader8.set_Width(56);
			columnHeader10.set_Text("Roles");
			columnHeader10.set_Width(174);
			((ToolStrip)contextMenuStrip1).get_Items().AddRange((ToolStripItem[])(object)new ToolStripItem[10]
			{
				(ToolStripItem)copyIDToolStripMenuItem,
				(ToolStripItem)toolStripMenuItem1,
				(ToolStripItem)toolStripSeparator2,
				(ToolStripItem)giveRoleToolStripMenuItem,
				(ToolStripItem)banToolStripMenuItem,
				(ToolStripItem)toolStripSeparator1,
				(ToolStripItem)rolesToolStripMenuItem,
				(ToolStripItem)giveRoleToolStripMenuItem1,
				(ToolStripItem)toolStripSeparator3,
				(ToolStripItem)toolStripMenuItem2
			});
			((Control)contextMenuStrip1).set_Name("contextMenuStrip1");
			((Control)contextMenuStrip1).set_Size(new Size(173, 176));
			((ToolStripDropDown)contextMenuStrip1).add_Opening((CancelEventHandler)(object)new CancelEventHandler(contextMenuStrip1_Opening));
			((ToolStripItem)copyIDToolStripMenuItem).set_Name("copyIDToolStripMenuItem");
			((ToolStripItem)copyIDToolStripMenuItem).set_Size(new Size(172, 22));
			((ToolStripItem)copyIDToolStripMenuItem).set_Text("Copy ID");
			((ToolStripItem)copyIDToolStripMenuItem).add_Click((EventHandler)copyIDToolStripMenuItem_Click);
			((ToolStripItem)toolStripMenuItem1).set_Name("toolStripMenuItem1");
			((ToolStripItem)toolStripMenuItem1).set_Size(new Size(172, 22));
			((ToolStripItem)toolStripMenuItem1).set_Text("User Info");
			((ToolStripItem)toolStripMenuItem1).add_Click((EventHandler)toolStripMenuItem1_Click);
			((ToolStripItem)toolStripSeparator2).set_Name("toolStripSeparator2");
			((ToolStripItem)toolStripSeparator2).set_Size(new Size(169, 6));
			((ToolStripItem)giveRoleToolStripMenuItem).set_Name("giveRoleToolStripMenuItem");
			((ToolStripItem)giveRoleToolStripMenuItem).set_Size(new Size(172, 22));
			((ToolStripItem)giveRoleToolStripMenuItem).set_Text("Kick");
			((ToolStripItem)giveRoleToolStripMenuItem).add_Click((EventHandler)giveRoleToolStripMenuItem_Click);
			((ToolStripItem)banToolStripMenuItem).set_Name("banToolStripMenuItem");
			((ToolStripItem)banToolStripMenuItem).set_Size(new Size(172, 22));
			((ToolStripItem)banToolStripMenuItem).set_Text("Ban");
			((ToolStripItem)banToolStripMenuItem).add_Click((EventHandler)banToolStripMenuItem_Click);
			((ToolStripItem)toolStripSeparator1).set_Name("toolStripSeparator1");
			((ToolStripItem)toolStripSeparator1).set_Size(new Size(169, 6));
			((ToolStripItem)rolesToolStripMenuItem).set_Name("rolesToolStripMenuItem");
			((ToolStripItem)rolesToolStripMenuItem).set_Size(new Size(172, 22));
			((ToolStripItem)rolesToolStripMenuItem).set_Text("User Roles");
			((ToolStripItem)rolesToolStripMenuItem).add_Click((EventHandler)rolesToolStripMenuItem_Click);
			((ToolStripItem)giveRoleToolStripMenuItem1).set_Name("giveRoleToolStripMenuItem1");
			((ToolStripItem)giveRoleToolStripMenuItem1).set_Size(new Size(172, 22));
			((ToolStripItem)giveRoleToolStripMenuItem1).set_Text("Give Role");
			((ToolStripItem)toolStripSeparator3).set_Name("toolStripSeparator3");
			((ToolStripItem)toolStripSeparator3).set_Size(new Size(169, 6));
			((ToolStripItem)toolStripMenuItem2).set_Name("toolStripMenuItem2");
			((ToolStripItem)toolStripMenuItem2).set_Size(new Size(172, 22));
			((ToolStripItem)toolStripMenuItem2).set_Text("Change Nickname");
			((ToolStripItem)toolStripMenuItem2).add_Click((EventHandler)toolStripMenuItem2_Click);
			tableLayoutPanel1.set_ColumnCount(1);
			tableLayoutPanel1.get_ColumnStyles().Add((ColumnStyle)(object)new ColumnStyle((SizeType)2, 100f));
			tableLayoutPanel1.get_Controls().Add((Control)(object)panel1, 0, 0);
			tableLayoutPanel1.get_Controls().Add((Control)(object)listView1, 0, 1);
			((Control)tableLayoutPanel1).set_Dock((DockStyle)5);
			((Control)tableLayoutPanel1).set_Location(new Point(0, 0));
			((Control)tableLayoutPanel1).set_Name("tableLayoutPanel1");
			tableLayoutPanel1.set_RowCount(2);
			tableLayoutPanel1.get_RowStyles().Add((RowStyle)(object)new RowStyle((SizeType)1, 30f));
			tableLayoutPanel1.get_RowStyles().Add((RowStyle)(object)new RowStyle((SizeType)2, 100f));
			((Control)tableLayoutPanel1).set_Size(new Size(880, 544));
			((Control)tableLayoutPanel1).set_TabIndex(5);
			((Control)panel1).get_Controls().Add((Control)(object)checkBox2);
			((Control)panel1).get_Controls().Add((Control)(object)checkBox1);
			((Control)panel1).get_Controls().Add((Control)(object)label3);
			((Control)panel1).get_Controls().Add((Control)(object)label2);
			((Control)panel1).get_Controls().Add((Control)(object)label1);
			((Control)panel1).get_Controls().Add((Control)(object)comboBox1);
			((Control)panel1).set_Dock((DockStyle)5);
			((Control)panel1).set_Location(new Point(3, 3));
			((Control)panel1).set_Name("panel1");
			((Control)panel1).set_Size(new Size(874, 24));
			((Control)panel1).set_TabIndex(0);
			((Control)checkBox2).set_AutoSize(true);
			checkBox2.set_Checked(true);
			checkBox2.set_CheckState((CheckState)1);
			((Control)checkBox2).set_Location(new Point(659, 3));
			((Control)checkBox2).set_Name("checkBox2");
			((Control)checkBox2).set_Size(new Size(77, 17));
			((Control)checkBox2).set_TabIndex(6);
			((Control)checkBox2).set_Text("Show Bots");
			((ButtonBase)checkBox2).set_UseVisualStyleBackColor(true);
			checkBox2.add_CheckedChanged((EventHandler)checkBox2_CheckedChanged);
			((Control)checkBox1).set_AutoSize(true);
			((Control)checkBox1).set_Location(new Point(740, 3));
			((Control)checkBox1).set_Name("checkBox1");
			((Control)checkBox1).set_Size(new Size(131, 17));
			((Control)checkBox1).set_TabIndex(5);
			((Control)checkBox1).set_Text("Show Bot 'Give' Roles");
			((ButtonBase)checkBox1).set_UseVisualStyleBackColor(true);
			((Control)label3).set_AutoSize(true);
			((Control)label3).set_Location(new Point(406, 6));
			((Control)label3).set_Name("label3");
			((Control)label3).set_Size(new Size(44, 13));
			((Control)label3).set_TabIndex(4);
			((Control)label3).set_Text("Owner: ");
			((Control)label2).set_AutoSize(true);
			((Control)label2).set_Location(new Point(313, 6));
			((Control)label2).set_Name("label2");
			((Control)label2).set_Size(new Size(56, 13));
			((Control)label2).set_TabIndex(3);
			((Control)label2).set_Text("Members: ");
			((ContainerControl)this).set_AutoScaleDimensions(new SizeF(6f, 13f));
			((ContainerControl)this).set_AutoScaleMode((AutoScaleMode)1);
			((Form)this).set_ClientSize(new Size(880, 544));
			((Control)this).get_Controls().Add((Control)(object)tableLayoutPanel1);
			((Form)this).set_Icon((Icon)(object)(Icon)((ResourceManager)(object)val).GetObject("$this.Icon"));
			((Control)this).set_Name("InfoForm");
			((Control)this).set_Text("User Info - Targo v0.4b");
			((Form)this).add_Load((EventHandler)InfoForm_Load);
			((Control)contextMenuStrip1).ResumeLayout(false);
			((Control)tableLayoutPanel1).ResumeLayout(false);
			((Control)panel1).ResumeLayout(false);
			((Control)panel1).PerformLayout();
			((Control)this).ResumeLayout(false);
		}
	}
}
