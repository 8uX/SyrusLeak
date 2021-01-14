using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace tacoFormsBot.Commands
{
	public class Test : ModuleBase
	{
		[Command("bigtest")]
		public async Task test()
		{
			await ((ModuleBase<ICommandContext>)(object)this).ReplyAsync("test", false, (Embed)null, (RequestOptions)null);
		}

		public Test()
			: this()
		{
		}
	}
}
