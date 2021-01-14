using Discord;
using Discord.Rest;
using Discord.WebSocket;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Multitool.SpookyDiscord
{
	internal class Functions
	{
		public static bool Join(string invite, string token)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Expected O, but got Unknown
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Expected O, but got Unknown
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Expected O, but got Unknown
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Expected O, but got Unknown
			//IL_00dc: Expected O, but got Unknown
			CookieContainer cookieContainer = (CookieContainer)(object)new CookieContainer();
			try
			{
				HttpWebRequest val = (HttpWebRequest)(object)(HttpWebRequest)WebRequest.Create("https://discord.gg/" + invite);
				((NameValueCollection)((WebRequest)val).get_Headers()).set_Item("authorization", token);
				val.set_CookieContainer(cookieContainer);
				HttpWebResponse val2 = (HttpWebResponse)(object)(HttpWebResponse)((WebRequest)val).GetResponse();
				string text = new StreamReader(((WebResponse)val2).GetResponseStream()).ReadToEnd();
				HttpWebRequest val3 = (HttpWebRequest)(object)(HttpWebRequest)WebRequest.Create("https://discordapp.com/api/v6/invites/" + invite);
				((NameValueCollection)((WebRequest)val3).get_Headers()).set_Item("authorization", token);
				((WebRequest)val3).set_Method("POST");
				((WebRequest)val3).set_ContentType("application/json");
				val3.set_CookieContainer(cookieContainer);
				((WebRequest)val3).set_ContentLength(0L);
				HttpWebResponse val4 = (HttpWebResponse)(object)(HttpWebResponse)((WebRequest)val3).GetResponse();
				string text2 = new StreamReader(((WebResponse)val4).GetResponseStream()).ReadToEnd();
				Console.WriteLine(text2);
				return true;
			}
			catch (WebException val5)
			{
				WebException val6 = (WebException)(object)val5;
				string text3 = new StreamReader(val6.get_Response().GetResponseStream()).ReadToEnd();
				Console.WriteLine(text3);
				return false;
			}
		}

		public static bool Add_Friend(string id, string token)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Expected O, but got Unknown
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Expected O, but got Unknown
			//IL_00c2: Expected O, but got Unknown
			CookieContainer cookieContainer = (CookieContainer)(object)new CookieContainer();
			try
			{
				HttpWebRequest val = (HttpWebRequest)(object)(HttpWebRequest)WebRequest.Create("https://discordapp.com/api/v6/users/@me/relationships/" + id);
				string s = "{}";
				byte[] bytes = Encoding.ASCII.GetBytes(s);
				((NameValueCollection)((WebRequest)val).get_Headers()).set_Item("authorization", token);
				((WebRequest)val).set_Method("PUT");
				((WebRequest)val).set_ContentType("application/json");
				((WebRequest)val).set_ContentLength((long)bytes.Length);
				val.set_CookieContainer(cookieContainer);
				using (Stream stream = ((WebRequest)val).GetRequestStream())
				{
					stream.Write(bytes, 0, bytes.Length);
				}
				HttpWebResponse val2 = (HttpWebResponse)(object)(HttpWebResponse)((WebRequest)val).GetResponse();
				string text = new StreamReader(((WebResponse)val2).GetResponseStream()).ReadToEnd();
				Console.WriteLine(text);
				return true;
			}
			catch (WebException val3)
			{
				WebException val4 = (WebException)(object)val3;
				string text2 = new StreamReader(val4.get_Response().GetResponseStream()).ReadToEnd();
				Console.WriteLine(text2);
				return false;
			}
		}

		public static string sendMessaage(string id, string content, string token)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Expected O, but got Unknown
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			//IL_00dc: Expected O, but got Unknown
			CookieContainer val = (CookieContainer)(object)new CookieContainer();
			try
			{
				string text = "{\"content\":\"" + content + "\",\"tts\":false}";
				HttpWebRequest val2 = (HttpWebRequest)(object)(HttpWebRequest)WebRequest.Create("https://discordapp.com/api/v6/channels/" + id + "/messages");
				val2.set_Accept("application/json, text/javascript, */*; q=0.01");
				string s = text;
				byte[] bytes = Encoding.ASCII.GetBytes(s);
				((NameValueCollection)((WebRequest)val2).get_Headers()).set_Item("authorization", token);
				((WebRequest)val2).set_Method("POST");
				((WebRequest)val2).set_ContentType("application/json");
				val2.set_UserAgent("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.75 Safari/537.36");
				((WebRequest)val2).set_ContentLength((long)bytes.Length);
				using (Stream stream = ((WebRequest)val2).GetRequestStream())
				{
					stream.Write(bytes, 0, bytes.Length);
				}
				WebResponse response = ((WebRequest)val2).GetResponse();
				return new StreamReader(response.GetResponseStream()).ReadToEnd();
			}
			catch (WebException val3)
			{
				WebException val4 = (WebException)(object)val3;
				WebResponse response2 = val4.get_Response();
				return new StreamReader(response2.GetResponseStream()).ReadToEnd();
			}
			catch
			{
				return "";
			}
		}

		public static bool AddReaction(string C_ID, string M_ID, string emoji, string token)
		{
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Expected O, but got Unknown
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Expected O, but got Unknown
			//IL_00a9: Expected O, but got Unknown
			try
			{
				emoji = Uri.EscapeUriString(emoji);
				HttpWebRequest val = (HttpWebRequest)(object)(HttpWebRequest)WebRequest.Create("https://discordapp.com/api/v6/channels/" + C_ID + "/messages/" + M_ID + "/reactions/" + emoji + "/%40me");
				((NameValueCollection)((WebRequest)val).get_Headers()).set_Item("authorization", token);
				((WebRequest)val).set_Method("PUT");
				((WebRequest)val).set_ContentType("application/json");
				((WebRequest)val).set_ContentLength(0L);
				HttpWebResponse val2 = (HttpWebResponse)(object)(HttpWebResponse)((WebRequest)val).GetResponse();
				string text = new StreamReader(((WebResponse)val2).GetResponseStream()).ReadToEnd();
				Console.WriteLine(text);
				return true;
			}
			catch (WebException val3)
			{
				WebException val4 = (WebException)(object)val3;
				string text2 = new StreamReader(val4.get_Response().GetResponseStream()).ReadToEnd();
				Console.WriteLine(text2);
				return false;
			}
		}

		public static bool RemoveReaction(string C_ID, string M_ID, string emoji, string token)
		{
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Expected O, but got Unknown
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Expected O, but got Unknown
			//IL_00a9: Expected O, but got Unknown
			try
			{
				emoji = Uri.EscapeUriString(emoji);
				HttpWebRequest val = (HttpWebRequest)(object)(HttpWebRequest)WebRequest.Create("https://discordapp.com/api/v6/channels/" + C_ID + "/messages/" + M_ID + "/reactions/" + emoji + "/%40me");
				((NameValueCollection)((WebRequest)val).get_Headers()).set_Item("authorization", token);
				((WebRequest)val).set_Method("DELETE");
				((WebRequest)val).set_ContentType("application/json");
				((WebRequest)val).set_ContentLength(0L);
				HttpWebResponse val2 = (HttpWebResponse)(object)(HttpWebResponse)((WebRequest)val).GetResponse();
				string text = new StreamReader(((WebResponse)val2).GetResponseStream()).ReadToEnd();
				Console.WriteLine(text);
				return true;
			}
			catch (WebException val3)
			{
				WebException val4 = (WebException)(object)val3;
				string text2 = new StreamReader(val4.get_Response().GetResponseStream()).ReadToEnd();
				Console.WriteLine(text2);
				return false;
			}
		}

		public static string GetDM(string U_id, string token)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected O, but got Unknown
			//IL_00bd: Expected O, but got Unknown
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Expected O, but got Unknown
			//IL_01ee: Expected O, but got Unknown
			string text = "";
			string text2 = "";
			try
			{
				HttpWebRequest val = (HttpWebRequest)(object)(HttpWebRequest)WebRequest.Create("https://discordapp.com/api/v7/users/@me");
				((NameValueCollection)((WebRequest)val).get_Headers()).set_Item("authorization", token);
				val.set_AutomaticDecompression((DecompressionMethods)1);
				HttpWebResponse val2 = (HttpWebResponse)(object)(HttpWebResponse)((WebRequest)val).GetResponse();
				string text3;
				try
				{
					using (Stream stream = ((WebResponse)val2).GetResponseStream())
					{
						using (StreamReader streamReader = new StreamReader(stream))
						{
							text3 = streamReader.ReadToEnd();
						}
					}
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
				text = text3.Split(new string[1]
				{
					"\"id\": \""
				}, StringSplitOptions.None)[1].Split(new char[1]
				{
					'"'
				})[0];
			}
			catch (WebException val3)
			{
				WebException val4 = (WebException)(object)val3;
				WebResponse response = val4.get_Response();
				return new StreamReader(response.GetResponseStream()).ReadToEnd();
			}
			try
			{
				string text4 = "{\"recipients\":[\"" + U_id + "\"]}";
				HttpWebRequest val5 = (HttpWebRequest)(object)(HttpWebRequest)WebRequest.Create("https://discordapp.com/api/v6/users/" + text + "/channels");
				val5.set_Accept("application/json, text/javascript, */*; q=0.01");
				string s = text4;
				byte[] bytes = Encoding.ASCII.GetBytes(s);
				((NameValueCollection)((WebRequest)val5).get_Headers()).set_Item("authorization", token);
				((WebRequest)val5).set_Method("POST");
				((WebRequest)val5).set_ContentType("application/json");
				val5.set_UserAgent("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.75 Safari/537.36");
				((WebRequest)val5).set_ContentLength((long)bytes.Length);
				using (Stream stream2 = ((WebRequest)val5).GetRequestStream())
				{
					stream2.Write(bytes, 0, bytes.Length);
				}
				WebResponse response2 = ((WebRequest)val5).GetResponse();
				string text5 = new StreamReader(response2.GetResponseStream()).ReadToEnd();
				return text5.Split(new string[1]
				{
					"\"id\": \""
				}, StringSplitOptions.None)[1].Split(new char[1]
				{
					'"'
				})[0];
			}
			catch (WebException val6)
			{
				WebException val7 = (WebException)(object)val6;
				WebResponse response3 = val7.get_Response();
				return new StreamReader(response3.GetResponseStream()).ReadToEnd();
			}
		}

		public static bool QuitGuild(string id, string token)
		{
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Expected O, but got Unknown
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Invalid comparison between Unknown and I4
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Invalid comparison between Unknown and I4
			//IL_0069: Expected O, but got Unknown
			try
			{
				WebRequest val = WebRequest.Create("https://discordapp.com/api/v6/users/@me/guilds/" + id);
				val.set_Method("DELETE");
				((NameValueCollection)val.get_Headers()).set_Item("authorization", token);
				HttpWebResponse val2 = (HttpWebResponse)(object)(HttpWebResponse)val.GetResponse();
				if ((int)val2.get_StatusCode() == 204 || (int)val2.get_StatusCode() == 200)
				{
					return true;
				}
				return false;
			}
			catch (WebException val3)
			{
				WebException val4 = (WebException)(object)val3;
				WebResponse response = val4.get_Response();
				string text = new StreamReader(response.GetResponseStream()).ReadToEnd();
				Console.WriteLine(text);
				return false;
			}
		}

		public static async Task<DiscordSocketClient> Revive_Bot(string token)
		{
			try
			{
				DiscordSocketClient _client = (DiscordSocketClient)(object)new DiscordSocketClient();
				await ((BaseDiscordClient)_client).LoginAsync((TokenType)0, token, true);
				await _client.StartAsync();
				await _client.SetGameAsync("Alpha spammer <3", (string)null, (StreamType)1);
				await _client.SetStatusAsync((UserStatus)4);
				return _client;
			}
			catch (Exception ex)
			{
				Exception e = ex;
				Console.WriteLine(e.Message);
				return null;
			}
		}

		public static string GetAllUsers(string token, string C_ID)
		{
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Expected O, but got Unknown
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			string result = "";
			try
			{
				HttpWebRequest val = (HttpWebRequest)(object)(HttpWebRequest)WebRequest.Create("https://discordapp.com/api/v6/channels/" + C_ID + "/messages?limit=50");
				((NameValueCollection)((WebRequest)val).get_Headers()).set_Item("authorization", token);
				HttpWebResponse val2 = (HttpWebResponse)(object)(HttpWebResponse)((WebRequest)val).GetResponse();
				string text = new StreamReader(((WebResponse)val2).GetResponseStream()).ReadToEnd();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return result;
		}
	}
}
