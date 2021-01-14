using Discord;
using Discord.Rest;
using Discord.WebSocket;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Forms;
using tacoFormsBot.Properties;

namespace tacoFormsBot
{
	public class Tools : Form
	{
		private DiscordSocketClient _client;

		private string path;

		private IContainer components;

		private Label label1;

		private Label label2;

		private Label label3;

		private ComboBox comboBox1;

		private ComboBox comboBox2;

		private ComboBox comboBox3;

		private TextBox textBox1;

		private Label label4;

		private Button button1;

		private Button button2;

		private Button button3;

		private Button button4;

		private RichTextBox richTextBox1;

		private Button button5;

		private Button button6;

		private Label label5;

		private Button button9;

		private Button button14;

		private OpenFileDialog openFileDialog1;

		private Button button15;

		private Button button16;

		private Button button17;

		private Button button18;

		private Button button19;

		private Button button20;

		private Button button22;

		private Button button23;

		private Button button24;

		private Label label8;

		private Label label9;

		private Button button25;

		private Button button26;

		private Label label10;

		private Label label11;

		private Label label12;

		private Button button28;

		private Button button29;

		private Button button30;

		private Button button33;

		private CheckBox checkBox1;

		public Tools(DiscordSocketClient iclient)
			: this()
		{
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			_client = iclient;
			InitializeComponent();
			if (Settings.Default.isConnected)
			{
				bool ready = false;
				_client.add_Ready((Func<Task>)delegate
				{
					ready = true;
					return Task.CompletedTask;
				});
				if (!ready)
				{
					return;
				}
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

		private void Tools_Load(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				comboBox1.get_Items().Add((object)guild.get_Name());
			}
			((Control)label11).set_Text("Joined: " + _client.get_Guilds().Count + " Guilds");
		}

		private void UpdateGuilds()
		{
			comboBox1.get_Items().Clear();
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				comboBox1.get_Items().Add((object)guild.get_Name());
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

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateChannels();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			if (((Control)comboBox2).get_Text() == string.Empty)
			{
				MessageBox.Show("You must select a channel to perform this action", "Targo");
			}
			else
			{
				sendMessage();
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			((Control)new Invite(_client)).Show();
		}

		private void sendMessage()
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
				{
					continue;
				}
				foreach (SocketTextChannel textChannel in guild.get_TextChannels())
				{
					if (((SocketGuildChannel)textChannel).get_Name() == ((Control)comboBox2).get_Text())
					{
						if (!checkBox1.get_Checked())
						{
							textChannel.SendMessageAsync(((Control)textBox1).get_Text(), false, (Embed)null, (RequestOptions)null);
						}
						else if (checkBox1.get_Checked())
						{
							textChannel.SendMessageAsync(((Control)textBox1).get_Text(), true, (Embed)null, (RequestOptions)null);
						}
					}
				}
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
				{
					continue;
				}
				foreach (SocketTextChannel textChannel in guild.get_TextChannels())
				{
					if (!(((IChannel)textChannel).get_Name() == ((Control)comboBox2).get_Text()))
					{
						continue;
					}
					Task<IInviteMetadata> task = ((IGuildChannel)textChannel).CreateInviteAsync((int?)null, (int?)null, false, false, (RequestOptions)null);
					if (task != null)
					{
						try
						{
							((TextBoxBase)richTextBox1).AppendText(((IGuildChannel)textChannel).get_Guild().get_Name() + ": " + ((object)task.Result).ToString() + "\n");
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message);
						}
					}
					return;
				}
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
				{
					continue;
				}
				try
				{
					foreach (RestInviteMetadata item in guild.GetInvitesAsync((RequestOptions)null).Result)
					{
						((TextBoxBase)richTextBox1).AppendText(((IInvite)item).get_Url() + " Channel:" + ((IInvite)item).get_ChannelName() + " Guild: \n");
					}
				}
				catch (AggregateException)
				{
					((TextBoxBase)richTextBox1).AppendText("No invites available / Error \n");
				}
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (guild.get_Name() == ((Control)comboBox1).get_Text())
				{
					((TextBoxBase)richTextBox1).AppendText(guild.get_Name() + ": " + guild.get_MemberCount() + "\n");
				}
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			if (((Control)comboBox1).get_Text() == string.Empty)
			{
				MessageBox.Show("You must select a guild to perform this action", "Targo");
			}
			else
			{
				foreach (SocketGuild guild in _client.get_Guilds())
				{
					if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
					{
						continue;
					}
					foreach (SocketVoiceChannel voiceChannel in guild.get_VoiceChannels())
					{
						voiceChannel.ModifyAsync((Action<VoiceChannelProperties>)delegate(VoiceChannelProperties x)
						{
							//IL_000c: Unknown result type (might be due to invalid IL or missing references)
							((GuildChannelProperties)x).set_Name(new Optional<string>(((Control)textBox1).get_Text()));
						}, (RequestOptions)null);
					}
				}
			}
			UpdateChannels();
		}

		private void button9_Click(object sender, EventArgs e)
		{
		}

		private void button7_Click(object sender, EventArgs e)
		{
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

		private void button8_Click(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (guild.get_Name() == ((Control)comboBox1).get_Text())
				{
					guild.ModifyAsync((Action<GuildProperties>)delegate(GuildProperties x)
					{
						//IL_0003: Unknown result type (might be due to invalid IL or missing references)
						//IL_0009: Unknown result type (might be due to invalid IL or missing references)
						x.set_Icon(default(Optional<Image?>));
					}, (RequestOptions)null);
				}
			}
		}

		private void button10_Click(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				_ = (((IGuild)guild).get_Name() == ((Control)comboBox1).get_Text());
			}
		}

		private void button31_Click(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
				{
					continue;
				}
				foreach (SocketGuildUser user in guild.get_Users())
				{
					((IGuildUser)user).KickAsync((string)null, (RequestOptions)null);
				}
			}
		}

		private void button13_Click_1(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				_ = (guild.get_Name() == ((Control)comboBox1).get_Text());
			}
		}

		private void button11_Click(object sender, EventArgs e)
		{
		}

		private void button12_Click(object sender, EventArgs e)
		{
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Expected O, but got Unknown
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (!(((IGuild)guild).get_Name() == ((Control)comboBox1).get_Text()))
				{
					continue;
				}
				foreach (SocketRole role in ((IGuild)guild).get_Roles())
				{
					SocketRole val = (SocketRole)(object)role;
					((TextBoxBase)richTextBox1).AppendText(val.get_Name().ToString() + " ID:" + ((SocketEntity<ulong>)(object)val).get_Id() + "\n");
				}
			}
		}

		private void richTextBox1_TextChanged(object sender, EventArgs e)
		{
			((TextBoxBase)richTextBox1).set_SelectionStart(((Control)richTextBox1).get_Text().Length);
			((TextBoxBase)richTextBox1).ScrollToCaret();
		}

		private void button13_Click(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				_ = guild;
			}
		}

		private void button9_Click_1(object sender, EventArgs e)
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			if (((Control)comboBox1).get_Text() == string.Empty)
			{
				MessageBox.Show("You must select a guild to perform this action", "Targo");
			}
			else
			{
				foreach (SocketGuild guild in _client.get_Guilds())
				{
					if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
					{
						continue;
					}
					foreach (SocketTextChannel textChannel in guild.get_TextChannels())
					{
						textChannel.ModifyAsync((Action<TextChannelProperties>)delegate(TextChannelProperties x)
						{
							//IL_000c: Unknown result type (might be due to invalid IL or missing references)
							((GuildChannelProperties)x).set_Name(new Optional<string>(((Control)textBox1).get_Text()));
						}, (RequestOptions)null);
					}
				}
			}
			UpdateChannels();
		}

		private void button14_Click(object sender, EventArgs e)
		{
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Invalid comparison between Unknown and I4
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
				{
					continue;
				}
				foreach (SocketTextChannel textChannel in guild.get_TextChannels())
				{
					if (((SocketGuildChannel)textChannel).get_Name() == ((Control)comboBox2).get_Text())
					{
						if ((int)((CommonDialog)openFileDialog1).ShowDialog() == 1)
						{
							path = ((FileDialog)openFileDialog1).get_FileName();
						}
						((Control)textBox1).get_Text();
						return;
					}
				}
			}
		}

		private void button15_Click(object sender, EventArgs e)
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			if (((Control)comboBox1).get_Text() == string.Empty)
			{
				MessageBox.Show("You must select a guild to perform this action", "Targo");
			}
			else if (path == null)
			{
				MessageBox.Show("You must load a image to perform this action", "Targo");
			}
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
				{
					continue;
				}
				foreach (SocketTextChannel textChannel in guild.get_TextChannels())
				{
					if (((SocketGuildChannel)textChannel).get_Name() == ((Control)comboBox2).get_Text())
					{
						textChannel.SendFileAsync(path, ((Control)textBox1).get_Text(), false, (RequestOptions)null);
					}
				}
			}
		}

		private void button16_Click(object sender, EventArgs e)
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			if (((Control)comboBox1).get_Text() == string.Empty)
			{
				MessageBox.Show("You must select a guild to perform this action", "Targo");
			}
			else if (((Control)textBox1).get_Text().Contains(" "))
			{
				MessageBox.Show("There cant be any spaces in a channel name");
			}
			else if (((Control)textBox1).get_Text().Length <= 2)
			{
				MessageBox.Show("Has to be longer than 2 characters");
			}
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (guild.get_Name() == ((Control)comboBox1).get_Text())
				{
					guild.CreateTextChannelAsync(((Control)textBox1).get_Text(), (RequestOptions)null);
				}
			}
			UpdateChannels();
		}

		private void button17_Click(object sender, EventArgs e)
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			if (((Control)comboBox1).get_Text() == string.Empty)
			{
				MessageBox.Show("You must select a guild to perform this action", "Targo");
			}
			else
			{
				foreach (SocketGuild guild in _client.get_Guilds())
				{
					if (guild.get_Name() == ((Control)comboBox1).get_Text())
					{
						guild.CreateVoiceChannelAsync(((Control)textBox1).get_Text(), (RequestOptions)null);
					}
				}
			}
			UpdateChannels();
		}

		private void button18_Click(object sender, EventArgs e)
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			if (((Control)comboBox1).get_Text() == string.Empty)
			{
				MessageBox.Show("You must select a guild to perform this action", "Targo");
			}
			else
			{
				foreach (SocketGuild guild in _client.get_Guilds())
				{
					if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
					{
						continue;
					}
					foreach (SocketTextChannel textChannel in guild.get_TextChannels())
					{
						((SocketGuildChannel)textChannel).DeleteAsync((RequestOptions)null);
					}
				}
			}
			UpdateChannels();
		}

		private void button19_Click(object sender, EventArgs e)
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			if (((Control)comboBox1).get_Text() == string.Empty)
			{
				MessageBox.Show("You must select a guild to perform this action", "Targo");
			}
			else
			{
				foreach (SocketGuild guild in _client.get_Guilds())
				{
					if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
					{
						continue;
					}
					foreach (SocketVoiceChannel voiceChannel in guild.get_VoiceChannels())
					{
						((SocketGuildChannel)voiceChannel).DeleteAsync((RequestOptions)null);
					}
				}
			}
			comboBox3.get_Items().Clear();
			((Control)comboBox3).set_Text(string.Empty);
			UpdateChannels();
		}

		private void button20_Click(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (guild.get_Name() == ((Control)comboBox1).get_Text())
				{
					guild.CreateTextChannelAsync("hacked", (RequestOptions)null);
					guild.CreateTextChannelAsync("by", (RequestOptions)null);
					guild.CreateTextChannelAsync("targo", (RequestOptions)null);
				}
			}
			UpdateChannels();
		}

		private void button21_Click(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (guild.get_Name() == ((Control)comboBox1).get_Text())
				{
					guild.CreateTextChannelAsync("my", (RequestOptions)null);
					guild.CreateTextChannelAsync("name", (RequestOptions)null);
					guild.CreateTextChannelAsync("is", (RequestOptions)null);
					guild.CreateTextChannelAsync("jeff", (RequestOptions)null);
				}
			}
			UpdateChannels();
		}

		private void button22_Click(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (guild.get_Name() == ((Control)comboBox1).get_Text())
				{
					guild.CreateTextChannelAsync("According ", (RequestOptions)null);
					Task.Delay(500);
					guild.CreateTextChannelAsync("to ", (RequestOptions)null);
					Task.Delay(500);
					guild.CreateTextChannelAsync("all", (RequestOptions)null);
					Task.Delay(500);
					guild.CreateTextChannelAsync("known", (RequestOptions)null);
					Task.Delay(500);
					guild.CreateTextChannelAsync("laws", (RequestOptions)null);
					Task.Delay(500);
					guild.CreateTextChannelAsync("of", (RequestOptions)null);
					Task.Delay(500);
					guild.CreateTextChannelAsync("aviation", (RequestOptions)null);
					Task.Delay(500);
					guild.CreateTextChannelAsync("there ", (RequestOptions)null);
					Task.Delay(500);
					guild.CreateTextChannelAsync("is ", (RequestOptions)null);
					Task.Delay(500);
					guild.CreateTextChannelAsync("no", (RequestOptions)null);
					Task.Delay(500);
					guild.CreateTextChannelAsync("all", (RequestOptions)null);
					Task.Delay(500);
					guild.CreateTextChannelAsync("way ", (RequestOptions)null);
					Task.Delay(500);
					guild.CreateTextChannelAsync("a ", (RequestOptions)null);
					Task.Delay(500);
					guild.CreateTextChannelAsync("should  ", (RequestOptions)null);
					Task.Delay(500);
					guild.CreateTextChannelAsync("bee ", (RequestOptions)null);
					Task.Delay(500);
					guild.CreateTextChannelAsync("able  ", (RequestOptions)null);
					Task.Delay(500);
					guild.CreateTextChannelAsync("to  ", (RequestOptions)null);
					Task.Delay(100);
					guild.CreateTextChannelAsync("fly ", (RequestOptions)null);
					Task.Delay(100);
					guild.CreateTextChannelAsync("Its  ", (RequestOptions)null);
					Task.Delay(100);
					guild.CreateTextChannelAsync("wings  ", (RequestOptions)null);
					Task.Delay(100);
					guild.CreateTextChannelAsync("are  ", (RequestOptions)null);
					Task.Delay(100);
					guild.CreateTextChannelAsync("too  ", (RequestOptions)null);
					Task.Delay(100);
					guild.CreateTextChannelAsync("small    ", (RequestOptions)null);
					Task.Delay(100);
					guild.CreateTextChannelAsync("to   ", (RequestOptions)null);
					Task.Delay(100);
					guild.CreateTextChannelAsync("get   ", (RequestOptions)null);
					Task.Delay(100);
					guild.CreateTextChannelAsync("its   ", (RequestOptions)null);
					Task.Delay(100);
					guild.CreateTextChannelAsync("fat   ", (RequestOptions)null);
					Task.Delay(100);
					guild.CreateTextChannelAsync("little   ", (RequestOptions)null);
					Task.Delay(100);
					guild.CreateTextChannelAsync("body   ", (RequestOptions)null);
					Task.Delay(100);
					guild.CreateTextChannelAsync("off   ", (RequestOptions)null);
					Task.Delay(100);
					guild.CreateTextChannelAsync("the   ", (RequestOptions)null);
					Task.Delay(100);
					guild.CreateTextChannelAsync("ground  ", (RequestOptions)null);
					Task.Delay(100);
					UpdateChannels();
				}
			}
		}

		private void button24_Click(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				((TextBoxBase)richTextBox1).AppendText(guild.get_Name() + ": " + guild.get_MemberCount() + "\n");
			}
		}

		private void button25_Click(object sender, EventArgs e)
		{
			UpdateGuilds();
			UpdateChannels();
		}

		private void button26_Click(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
				{
					continue;
				}
				foreach (SocketTextChannel textChannel in guild.get_TextChannels())
				{
					if (((SocketGuildChannel)textChannel).get_Name() == ((Control)comboBox2).get_Text())
					{
						((TextBoxBase)richTextBox1).AppendText(((SocketGuildChannel)textChannel).get_Guild().get_Name() + ": " + ((SocketGuildChannel)textChannel).get_Name() + ": " + ((SocketGuildChannel)textChannel).get_Users().Count + "\n");
					}
				}
			}
		}

		private void button23_Click(object sender, EventArgs e)
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			if (string.IsNullOrEmpty(((Control)textBox1).get_Text()))
			{
				MessageBox.Show("You need to enter text in text input for this to work");
			}
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (guild.get_Name() == ((Control)comboBox1).get_Text())
				{
					guild.CreateTextChannelAsync(((Control)textBox1).get_Text(), (RequestOptions)null);
					guild.CreateTextChannelAsync(((Control)textBox1).get_Text(), (RequestOptions)null);
					guild.CreateTextChannelAsync(((Control)textBox1).get_Text(), (RequestOptions)null);
					guild.CreateTextChannelAsync(((Control)textBox1).get_Text(), (RequestOptions)null);
					guild.CreateTextChannelAsync(((Control)textBox1).get_Text(), (RequestOptions)null);
					guild.CreateTextChannelAsync(((Control)textBox1).get_Text(), (RequestOptions)null);
					guild.CreateTextChannelAsync(((Control)textBox1).get_Text(), (RequestOptions)null);
					guild.CreateTextChannelAsync(((Control)textBox1).get_Text(), (RequestOptions)null);
					guild.CreateTextChannelAsync(((Control)textBox1).get_Text(), (RequestOptions)null);
					guild.CreateTextChannelAsync(((Control)textBox1).get_Text(), (RequestOptions)null);
				}
			}
			UpdateChannels();
		}

		private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
		{
		}

		private void button27_Click(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
				{
					continue;
				}
				foreach (SocketGuildUser user in guild.get_Users())
				{
					((TextBoxBase)richTextBox1).AppendText(((IUser)user).get_Username() + " ID: " + ((IEntity<ulong>)(object)user).get_Id() + "\n");
				}
			}
		}

		private void button28_Click(object sender, EventArgs e)
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			if (((Control)comboBox1).get_Text() == string.Empty)
			{
				MessageBox.Show("You must select a guild to perform this action", "Targo");
				return;
			}
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
				{
					continue;
				}
				foreach (SocketTextChannel textChannel in guild.get_TextChannels())
				{
					try
					{
						if (!checkBox1.get_Checked())
						{
							textChannel.SendMessageAsync(((Control)textBox1).get_Text(), false, (Embed)null, (RequestOptions)null);
						}
						else if (checkBox1.get_Checked())
						{
							textChannel.SendMessageAsync(((Control)textBox1).get_Text(), true, (Embed)null, (RequestOptions)null);
						}
					}
					catch (Exception ex)
					{
						((TextBoxBase)richTextBox1).AppendText($"{ex.Message} \n");
					}
				}
			}
		}

		private void button29_Click(object sender, EventArgs e)
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			if (((Control)comboBox1).get_Text() == string.Empty)
			{
				MessageBox.Show("You must select a guild to perform this action", "Targo");
			}
			else if (path == null)
			{
				MessageBox.Show("You must load a image to perform this action", "Targo");
			}
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
				{
					continue;
				}
				foreach (SocketTextChannel textChannel in guild.get_TextChannels())
				{
					textChannel.SendFileAsync(path, ((Control)textBox1).get_Text(), false, (RequestOptions)null);
				}
			}
		}

		private void button30_Click(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (guild.get_Name() == ((Control)comboBox1).get_Text())
				{
					guild.LeaveAsync((RequestOptions)null);
				}
			}
		}

		private async void button32_Click(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
				{
					continue;
				}
				foreach (SocketRole role in guild.get_Roles())
				{
					_ = role;
				}
			}
		}

		private async void button33_Click(object sender, EventArgs e)
		{
			foreach (SocketGuild guild in _client.get_Guilds())
			{
				if (!(guild.get_Name() == ((Control)comboBox1).get_Text()))
				{
					continue;
				}
				foreach (SocketVoiceChannel voiceChannel in guild.get_VoiceChannels())
				{
					foreach (SocketGuildUser user in ((SocketGuildChannel)voiceChannel).get_Users())
					{
						foreach (SocketVoiceChannel dst in guild.get_VoiceChannels())
						{
							try
							{
								if (((SocketGuildChannel)dst).get_Name() == ((Control)comboBox3).get_Text())
								{
									await user.ModifyAsync((Action<GuildUserProperties>)delegate(GuildUserProperties x)
									{
										//IL_0007: Unknown result type (might be due to invalid IL or missing references)
										x.set_Channel(new Optional<IVoiceChannel>((IVoiceChannel)(object)dst));
									}, (RequestOptions)null);
									((TextBoxBase)richTextBox1).AppendText($"{guild.get_Name()}: Moved: {((SocketUser)user).get_Username()}#{((SocketUser)user).get_Discriminator()} into {((SocketGuildChannel)dst).get_Name()} \n");
								}
							}
							catch (Exception ex)
							{
								((TextBoxBase)richTextBox1).AppendText(ex.Message + "\n");
							}
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
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Expected O, but got Unknown
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Expected O, but got Unknown
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Expected O, but got Unknown
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Expected O, but got Unknown
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Expected O, but got Unknown
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Expected O, but got Unknown
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Expected O, but got Unknown
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Expected O, but got Unknown
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Expected O, but got Unknown
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Expected O, but got Unknown
			//IL_015b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Expected O, but got Unknown
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Expected O, but got Unknown
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Expected O, but got Unknown
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Expected O, but got Unknown
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_0191: Expected O, but got Unknown
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_019c: Expected O, but got Unknown
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a7: Expected O, but got Unknown
			//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b2: Expected O, but got Unknown
			//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bd: Expected O, but got Unknown
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c8: Expected O, but got Unknown
			//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0208: Unknown result type (might be due to invalid IL or missing references)
			//IL_0244: Unknown result type (might be due to invalid IL or missing references)
			//IL_0268: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0310: Unknown result type (might be due to invalid IL or missing references)
			//IL_0337: Unknown result type (might be due to invalid IL or missing references)
			//IL_039d: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0423: Unknown result type (might be due to invalid IL or missing references)
			//IL_0446: Unknown result type (might be due to invalid IL or missing references)
			//IL_046d: Unknown result type (might be due to invalid IL or missing references)
			//IL_049c: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_051a: Unknown result type (might be due to invalid IL or missing references)
			//IL_057c: Unknown result type (might be due to invalid IL or missing references)
			//IL_05a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_05fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_061e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0678: Unknown result type (might be due to invalid IL or missing references)
			//IL_069c: Unknown result type (might be due to invalid IL or missing references)
			//IL_06f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_071a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0768: Unknown result type (might be due to invalid IL or missing references)
			//IL_078c: Unknown result type (might be due to invalid IL or missing references)
			//IL_07e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_080a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0870: Unknown result type (might be due to invalid IL or missing references)
			//IL_0897: Unknown result type (might be due to invalid IL or missing references)
			//IL_08ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_08f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0949: Unknown result type (might be due to invalid IL or missing references)
			//IL_096d: Unknown result type (might be due to invalid IL or missing references)
			//IL_09d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_09f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a52: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a76: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ad0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0af4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b4e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b72: Unknown result type (might be due to invalid IL or missing references)
			//IL_0bcc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0bf0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c4a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c71: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ccb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0cf2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d4c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d73: Unknown result type (might be due to invalid IL or missing references)
			//IL_0dcd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0df1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e54: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e78: Unknown result type (might be due to invalid IL or missing references)
			//IL_0eb5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0edc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f0f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f33: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f8d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0fb1: Unknown result type (might be due to invalid IL or missing references)
			//IL_1017: Unknown result type (might be due to invalid IL or missing references)
			//IL_103e: Unknown result type (might be due to invalid IL or missing references)
			//IL_1081: Unknown result type (might be due to invalid IL or missing references)
			//IL_10a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_10e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_1109: Unknown result type (might be due to invalid IL or missing references)
			//IL_113d: Unknown result type (might be due to invalid IL or missing references)
			//IL_1164: Unknown result type (might be due to invalid IL or missing references)
			//IL_11bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_11df: Unknown result type (might be due to invalid IL or missing references)
			//IL_1239: Unknown result type (might be due to invalid IL or missing references)
			//IL_125d: Unknown result type (might be due to invalid IL or missing references)
			//IL_12b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_12de: Unknown result type (might be due to invalid IL or missing references)
			//IL_1341: Unknown result type (might be due to invalid IL or missing references)
			//IL_1365: Unknown result type (might be due to invalid IL or missing references)
			//IL_13a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_13bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_1673: Unknown result type (might be due to invalid IL or missing references)
			//IL_167d: Expected O, but got Unknown
			ComponentResourceManager val = (ComponentResourceManager)(object)new ComponentResourceManager(typeof(Tools));
			label1 = (Label)(object)new Label();
			label2 = (Label)(object)new Label();
			label3 = (Label)(object)new Label();
			comboBox1 = (ComboBox)(object)new ComboBox();
			comboBox2 = (ComboBox)(object)new ComboBox();
			comboBox3 = (ComboBox)(object)new ComboBox();
			textBox1 = (TextBox)(object)new TextBox();
			label4 = (Label)(object)new Label();
			button1 = (Button)(object)new Button();
			button2 = (Button)(object)new Button();
			button3 = (Button)(object)new Button();
			button4 = (Button)(object)new Button();
			richTextBox1 = (RichTextBox)(object)new RichTextBox();
			button5 = (Button)(object)new Button();
			button6 = (Button)(object)new Button();
			label5 = (Label)(object)new Label();
			button9 = (Button)(object)new Button();
			button14 = (Button)(object)new Button();
			openFileDialog1 = (OpenFileDialog)(object)new OpenFileDialog();
			button15 = (Button)(object)new Button();
			button16 = (Button)(object)new Button();
			button17 = (Button)(object)new Button();
			button18 = (Button)(object)new Button();
			button19 = (Button)(object)new Button();
			button20 = (Button)(object)new Button();
			button22 = (Button)(object)new Button();
			button23 = (Button)(object)new Button();
			button24 = (Button)(object)new Button();
			label8 = (Label)(object)new Label();
			label9 = (Label)(object)new Label();
			button25 = (Button)(object)new Button();
			button26 = (Button)(object)new Button();
			label10 = (Label)(object)new Label();
			label11 = (Label)(object)new Label();
			label12 = (Label)(object)new Label();
			button28 = (Button)(object)new Button();
			button29 = (Button)(object)new Button();
			button30 = (Button)(object)new Button();
			button33 = (Button)(object)new Button();
			checkBox1 = (CheckBox)(object)new CheckBox();
			((Control)this).SuspendLayout();
			((Control)label1).set_AutoSize(true);
			((Control)label1).set_Location(new Point(43, 32));
			((Control)label1).set_Name("label1");
			((Control)label1).set_Size(new Size(46, 13));
			((Control)label1).set_TabIndex(0);
			((Control)label1).set_Text("Servers:");
			((Control)label2).set_AutoSize(true);
			((Control)label2).set_Location(new Point(16, 61));
			((Control)label2).set_Name("label2");
			((Control)label2).set_Size(new Size(73, 13));
			((Control)label2).set_TabIndex(1);
			((Control)label2).set_Text("Text Channel:");
			((Control)label3).set_AutoSize(true);
			((Control)label3).set_Location(new Point(10, 90));
			((Control)label3).set_Name("label3");
			((Control)label3).set_Size(new Size(79, 13));
			((Control)label3).set_TabIndex(2);
			((Control)label3).set_Text("Voice Channel:");
			comboBox1.set_DropDownStyle((ComboBoxStyle)2);
			((ListControl)comboBox1).set_FormattingEnabled(true);
			((Control)comboBox1).set_Location(new Point(95, 29));
			((Control)comboBox1).set_Name("comboBox1");
			((Control)comboBox1).set_Size(new Size(143, 21));
			((Control)comboBox1).set_TabIndex(3);
			comboBox1.add_SelectedIndexChanged((EventHandler)comboBox1_SelectedIndexChanged);
			((ListControl)comboBox1).add_SelectedValueChanged((EventHandler)comboBox1_SelectedValueChanged);
			comboBox2.set_DropDownStyle((ComboBoxStyle)2);
			((ListControl)comboBox2).set_FormattingEnabled(true);
			((Control)comboBox2).set_Location(new Point(95, 58));
			((Control)comboBox2).set_Name("comboBox2");
			((Control)comboBox2).set_Size(new Size(143, 21));
			((Control)comboBox2).set_TabIndex(4);
			comboBox3.set_DropDownStyle((ComboBoxStyle)2);
			((ListControl)comboBox3).set_FormattingEnabled(true);
			((Control)comboBox3).set_Location(new Point(95, 87));
			((Control)comboBox3).set_Name("comboBox3");
			((Control)comboBox3).set_Size(new Size(143, 21));
			((Control)comboBox3).set_TabIndex(5);
			((Control)textBox1).set_Location(new Point(309, 49));
			((Control)textBox1).set_Name("textBox1");
			((Control)textBox1).set_Size(new Size(405, 20));
			((Control)textBox1).set_TabIndex(6);
			((Control)label4).set_AutoSize(true);
			((Control)label4).set_Location(new Point(306, 29));
			((Control)label4).set_Name("label4");
			((Control)label4).set_Size(new Size(273, 13));
			((Control)label4).set_TabIndex(7);
			((Control)label4).set_Text("Text Input: - Message / Image / Channel Edit Input Field");
			((Control)button1).set_Location(new Point(621, 75));
			((Control)button1).set_Name("button1");
			((Control)button1).set_Size(new Size(93, 23));
			((Control)button1).set_TabIndex(8);
			((Control)button1).set_Text("Send Message");
			((ButtonBase)button1).set_UseVisualStyleBackColor(true);
			((Control)button1).add_Click((EventHandler)button1_Click);
			((Control)button2).set_Enabled(false);
			((Control)button2).set_Location(new Point(603, 12));
			((Control)button2).set_Name("button2");
			((Control)button2).set_Size(new Size(111, 23));
			((Control)button2).set_TabIndex(9);
			((Control)button2).set_Text("Send Embed");
			((ButtonBase)button2).set_UseVisualStyleBackColor(true);
			((Control)button2).add_Click((EventHandler)button2_Click);
			((Control)button3).set_Location(new Point(400, 287));
			((Control)button3).set_Name("button3");
			((Control)button3).set_Size(new Size(75, 23));
			((Control)button3).set_TabIndex(10);
			((Control)button3).set_Text("Create Invite");
			((ButtonBase)button3).set_UseVisualStyleBackColor(true);
			((Control)button3).add_Click((EventHandler)button3_Click);
			((Control)button4).set_Location(new Point(400, 316));
			((Control)button4).set_Name("button4");
			((Control)button4).set_Size(new Size(75, 23));
			((Control)button4).set_TabIndex(11);
			((Control)button4).set_Text("Get Invite");
			((ButtonBase)button4).set_UseVisualStyleBackColor(true);
			((Control)button4).add_Click((EventHandler)button4_Click);
			((Control)richTextBox1).set_Location(new Point(12, 125));
			((Control)richTextBox1).set_Name("richTextBox1");
			((Control)richTextBox1).set_Size(new Size(363, 365));
			((Control)richTextBox1).set_TabIndex(12);
			((Control)richTextBox1).set_Text("");
			((Control)richTextBox1).add_TextChanged((EventHandler)richTextBox1_TextChanged);
			((Control)button5).set_Location(new Point(400, 219));
			((Control)button5).set_Name("button5");
			((Control)button5).set_Size(new Size(75, 21));
			((Control)button5).set_TabIndex(13);
			((Control)button5).set_Text("Guild Count");
			((ButtonBase)button5).set_UseVisualStyleBackColor(true);
			((Control)button5).add_Click((EventHandler)button5_Click);
			((Control)button6).set_Location(new Point(621, 157));
			((Control)button6).set_Name("button6");
			((Control)button6).set_Size(new Size(95, 34));
			((Control)button6).set_TabIndex(14);
			((Control)button6).set_Text("Rename Voice Channels");
			((ButtonBase)button6).set_UseVisualStyleBackColor(true);
			((Control)button6).add_Click((EventHandler)button6_Click);
			((Control)label5).set_AutoSize(true);
			((Control)label5).set_Location(new Point(517, 141));
			((Control)label5).set_Name("label5");
			((Control)label5).set_Size(new Size(151, 13));
			((Control)label5).set_TabIndex(15);
			((Control)label5).set_Text("Channel Edit / Add / Remove:");
			((Control)button9).set_Location(new Point(520, 157));
			((Control)button9).set_Name("button9");
			((Control)button9).set_Size(new Size(95, 34));
			((Control)button9).set_TabIndex(18);
			((Control)button9).set_Text("Rename Text Channels");
			((ButtonBase)button9).set_UseVisualStyleBackColor(true);
			((Control)button9).add_Click((EventHandler)button9_Click_1);
			((Control)button14).set_Location(new Point(486, 105));
			((Control)button14).set_Name("button14");
			((Control)button14).set_Size(new Size(47, 23));
			((Control)button14).set_TabIndex(27);
			((Control)button14).set_Text("Load");
			((ButtonBase)button14).set_UseVisualStyleBackColor(true);
			((Control)button14).add_Click((EventHandler)button14_Click);
			((FileDialog)openFileDialog1).set_FileName("openFileDialog1");
			((Control)button15).set_Location(new Point(638, 105));
			((Control)button15).set_Name("button15");
			((Control)button15).set_Size(new Size(76, 23));
			((Control)button15).set_TabIndex(29);
			((Control)button15).set_Text("To Channel");
			((ButtonBase)button15).set_UseVisualStyleBackColor(true);
			((Control)button15).add_Click((EventHandler)button15_Click);
			((Control)button16).set_Location(new Point(520, 197));
			((Control)button16).set_Name("button16");
			((Control)button16).set_Size(new Size(95, 23));
			((Control)button16).set_TabIndex(30);
			((Control)button16).set_Text("Add Channel");
			((ButtonBase)button16).set_UseVisualStyleBackColor(true);
			((Control)button16).add_Click((EventHandler)button16_Click);
			((Control)button17).set_Location(new Point(621, 197));
			((Control)button17).set_Name("button17");
			((Control)button17).set_Size(new Size(95, 23));
			((Control)button17).set_TabIndex(31);
			((Control)button17).set_Text("Add Voice");
			((ButtonBase)button17).set_UseVisualStyleBackColor(true);
			((Control)button17).add_Click((EventHandler)button17_Click);
			((Control)button18).set_Location(new Point(621, 226));
			((Control)button18).set_Name("button18");
			((Control)button18).set_Size(new Size(95, 44));
			((Control)button18).set_TabIndex(32);
			((Control)button18).set_Text("Remove All Text Channels");
			((ButtonBase)button18).set_UseVisualStyleBackColor(true);
			((Control)button18).add_Click((EventHandler)button18_Click);
			((Control)button19).set_Location(new Point(520, 226));
			((Control)button19).set_Name("button19");
			((Control)button19).set_Size(new Size(95, 44));
			((Control)button19).set_TabIndex(33);
			((Control)button19).set_Text("Remove All Voice Channels");
			((ButtonBase)button19).set_UseVisualStyleBackColor(true);
			((Control)button19).add_Click((EventHandler)button19_Click);
			((Control)button20).set_Location(new Point(520, 391));
			((Control)button20).set_Name("button20");
			((Control)button20).set_Size(new Size(196, 23));
			((Control)button20).set_TabIndex(34);
			((Control)button20).set_Text("Hacked By Targo");
			((ButtonBase)button20).set_UseVisualStyleBackColor(true);
			((Control)button20).add_Click((EventHandler)button20_Click);
			((Control)button22).set_Location(new Point(520, 420));
			((Control)button22).set_Name("button22");
			((Control)button22).set_Size(new Size(196, 23));
			((Control)button22).set_TabIndex(36);
			((Control)button22).set_Text("Bee Movie Copy-Pasta");
			((ButtonBase)button22).set_UseVisualStyleBackColor(true);
			((Control)button22).add_Click((EventHandler)button22_Click);
			((Control)button23).set_Location(new Point(520, 449));
			((Control)button23).set_Name("button23");
			((Control)button23).set_Size(new Size(196, 23));
			((Control)button23).set_TabIndex(37);
			((Control)button23).set_Text("Text Input x10");
			((ButtonBase)button23).set_UseVisualStyleBackColor(true);
			((Control)button23).add_Click((EventHandler)button23_Click);
			((Control)button24).set_Location(new Point(400, 345));
			((Control)button24).set_Name("button24");
			((Control)button24).set_Size(new Size(75, 72));
			((Control)button24).set_TabIndex(38);
			((Control)button24).set_Text("Server Member Count");
			((ButtonBase)button24).set_UseVisualStyleBackColor(true);
			((Control)button24).add_Click((EventHandler)button24_Click);
			((Control)label8).set_AutoSize(true);
			((Control)label8).set_Location(new Point(413, 109));
			((Control)label8).set_Name("label8");
			((Control)label8).set_Size(new Size(67, 13));
			((Control)label8).set_TabIndex(39);
			((Control)label8).set_Text("Send Image:");
			((Control)label9).set_AutoSize(true);
			((Control)label9).set_Location(new Point(100, 9));
			((Control)label9).set_Name("label9");
			((Control)label9).set_Size(new Size(138, 13));
			((Control)label9).set_TabIndex(40);
			((Control)label9).set_Text("Server / Channel Selection:");
			((Control)button25).set_Location(new Point(244, 5));
			((Control)button25).set_Name("button25");
			((Control)button25).set_Size(new Size(20, 20));
			((Control)button25).set_TabIndex(41);
			((Control)button25).set_Text("\ud83d\udd04");
			((ButtonBase)button25).set_UseVisualStyleBackColor(true);
			((Control)button25).add_Click((EventHandler)button25_Click);
			((Control)button26).set_Location(new Point(400, 190));
			((Control)button26).set_Name("button26");
			((Control)button26).set_Size(new Size(75, 23));
			((Control)button26).set_TabIndex(42);
			((Control)button26).set_Text("Chan Count");
			((ButtonBase)button26).set_UseVisualStyleBackColor(true);
			((Control)button26).add_Click((EventHandler)button26_Click);
			((Control)label10).set_AutoSize(true);
			((Control)label10).set_Location(new Point(517, 375));
			((Control)label10).set_Name("label10");
			((Control)label10).set_Size(new Size(148, 13));
			((Control)label10).set_TabIndex(43);
			((Control)label10).set_Text("Macros - Text Channel Create");
			((Control)label11).set_AutoSize(true);
			((Control)label11).set_Location(new Point(397, 173));
			((Control)label11).set_Name("label11");
			((Control)label11).set_Size(new Size(83, 13));
			((Control)label11).set_TabIndex(45);
			((Control)label11).set_Text("Joined: # Guilds");
			((Control)label12).set_AutoSize(true);
			((Control)label12).set_Location(new Point(345, 80));
			((Control)label12).set_Name("label12");
			((Control)label12).set_Size(new Size(81, 13));
			((Control)label12).set_TabIndex(46);
			((Control)label12).set_Text("Send Message:");
			((Control)button28).set_Location(new Point(486, 75));
			((Control)button28).set_Name("button28");
			((Control)button28).set_Size(new Size(129, 23));
			((Control)button28).set_TabIndex(47);
			((Control)button28).set_Text("All Server Channels");
			((ButtonBase)button28).set_UseVisualStyleBackColor(true);
			((Control)button28).add_Click((EventHandler)button28_Click);
			((Control)button29).set_Location(new Point(539, 105));
			((Control)button29).set_Name("button29");
			((Control)button29).set_Size(new Size(93, 23));
			((Control)button29).set_TabIndex(48);
			((Control)button29).set_Text("All Channels");
			((ButtonBase)button29).set_UseVisualStyleBackColor(true);
			((Control)button29).add_Click((EventHandler)button29_Click);
			((Control)button30).set_Location(new Point(400, 442));
			((Control)button30).set_Name("button30");
			((Control)button30).set_Size(new Size(75, 23));
			((Control)button30).set_TabIndex(51);
			((Control)button30).set_Text("Leave Guild");
			((ButtonBase)button30).set_UseVisualStyleBackColor(true);
			((Control)button30).add_Click((EventHandler)button30_Click);
			((Control)button33).set_Location(new Point(520, 276));
			((Control)button33).set_Name("button33");
			((Control)button33).set_Size(new Size(194, 36));
			((Control)button33).set_TabIndex(54);
			((Control)button33).set_Text("Move Everyone Into Voice Channel");
			((ButtonBase)button33).set_UseVisualStyleBackColor(true);
			((Control)button33).add_Click((EventHandler)button33_Click);
			((Control)checkBox1).set_AutoSize(true);
			((Control)checkBox1).set_Location(new Point(434, 79));
			((Control)checkBox1).set_Name("checkBox1");
			((Control)checkBox1).set_Size(new Size(47, 17));
			((Control)checkBox1).set_TabIndex(55);
			((Control)checkBox1).set_Text("TTS");
			((ButtonBase)checkBox1).set_UseVisualStyleBackColor(true);
			((ContainerControl)this).set_AutoScaleDimensions(new SizeF(6f, 13f));
			((ContainerControl)this).set_AutoScaleMode((AutoScaleMode)1);
			((Form)this).set_ClientSize(new Size(724, 496));
			((Control)this).get_Controls().Add((Control)(object)checkBox1);
			((Control)this).get_Controls().Add((Control)(object)button33);
			((Control)this).get_Controls().Add((Control)(object)button30);
			((Control)this).get_Controls().Add((Control)(object)button29);
			((Control)this).get_Controls().Add((Control)(object)button28);
			((Control)this).get_Controls().Add((Control)(object)label12);
			((Control)this).get_Controls().Add((Control)(object)label11);
			((Control)this).get_Controls().Add((Control)(object)label10);
			((Control)this).get_Controls().Add((Control)(object)button26);
			((Control)this).get_Controls().Add((Control)(object)button25);
			((Control)this).get_Controls().Add((Control)(object)label9);
			((Control)this).get_Controls().Add((Control)(object)label8);
			((Control)this).get_Controls().Add((Control)(object)button24);
			((Control)this).get_Controls().Add((Control)(object)button23);
			((Control)this).get_Controls().Add((Control)(object)button22);
			((Control)this).get_Controls().Add((Control)(object)button20);
			((Control)this).get_Controls().Add((Control)(object)button19);
			((Control)this).get_Controls().Add((Control)(object)button18);
			((Control)this).get_Controls().Add((Control)(object)button17);
			((Control)this).get_Controls().Add((Control)(object)button16);
			((Control)this).get_Controls().Add((Control)(object)button15);
			((Control)this).get_Controls().Add((Control)(object)button14);
			((Control)this).get_Controls().Add((Control)(object)button9);
			((Control)this).get_Controls().Add((Control)(object)label5);
			((Control)this).get_Controls().Add((Control)(object)button6);
			((Control)this).get_Controls().Add((Control)(object)button5);
			((Control)this).get_Controls().Add((Control)(object)richTextBox1);
			((Control)this).get_Controls().Add((Control)(object)button4);
			((Control)this).get_Controls().Add((Control)(object)button3);
			((Control)this).get_Controls().Add((Control)(object)button2);
			((Control)this).get_Controls().Add((Control)(object)button1);
			((Control)this).get_Controls().Add((Control)(object)label4);
			((Control)this).get_Controls().Add((Control)(object)textBox1);
			((Control)this).get_Controls().Add((Control)(object)comboBox3);
			((Control)this).get_Controls().Add((Control)(object)comboBox2);
			((Control)this).get_Controls().Add((Control)(object)comboBox1);
			((Control)this).get_Controls().Add((Control)(object)label3);
			((Control)this).get_Controls().Add((Control)(object)label2);
			((Control)this).get_Controls().Add((Control)(object)label1);
			((Form)this).set_FormBorderStyle((FormBorderStyle)1);
			((Form)this).set_Icon((Icon)(object)(Icon)((ResourceManager)(object)val).GetObject("$this.Icon"));
			((Form)this).set_MaximizeBox(false);
			((Control)this).set_Name("Tools");
			((Control)this).set_Text("Channel Tools - Targo 0.4b");
			((Form)this).add_Load((EventHandler)Tools_Load);
			((Control)this).ResumeLayout(false);
			((Control)this).PerformLayout();
		}
	}
}
