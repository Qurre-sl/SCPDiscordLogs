using Qurre.API;
using Qurre.API.Addons;
using Qurre.API.Attributes;
using Qurre.Events;
using System.Collections.Generic;
using System.Linq;

namespace SCPDiscordLogs
{
	static public class Cfg
	{
		static internal JsonConfig Config { get; private set; }
		static internal Translate Translate { get; private set; }

		static public string Token { get; private set; }
		static public string Ip { get; private set; }
		static public ushort Port { get; private set; }
		static public string Delimiter { get; private set; }
		static public List<string> BlockRa { get; private set; }
		static public List<string> GlobalInvisible { get; private set; }
		static public string ServerName { get; private set; }
		static public string Avatar { get; private set; }
		static internal string WebHook { get; private set; }
		static internal string WebHookBans { get; private set; }
		static internal bool EnablesSetTopic { get; private set; }

		[EventMethod(RoundEvents.Waiting)]
		static internal void LoadReloadCfg()
		{
			Config ??= new("SCPDiscordLogs");

			Token = Config.SafeGetValue("Token", "YourTokenChangeThisForSafety", "The token for the executable application. " +
				"If you are using localhost, you can use empty token.\nMust match the token from the executable application's config");
			Ip = Config.SafeGetValue("Ip", "localhost", "ip specified in a bot config");
			Port = Config.SafeGetValue("Port", Server.Port, "port specified in a bot config");
			Delimiter = Config.SafeGetValue("delimiter", "^", "delimiter between id and nickname in ra");
			BlockRa = Config.SafeGetValue("InvisibleRa", new string[] { "7654@steam", "444@discord", "1337@steam" },
				"Those who will not be logged in ra logs").Select(x => x.Trim()).ToList();
			GlobalInvisible = Config.SafeGetValue("GlobalInvisible", new string[] { "7654@steam", "444@discord", "1337@steam" },
				"Those who will not be logged").Select(x => x.Trim()).ToList();
			ServerName = Config.SafeGetValue("ServerName", "Qurre", "server name");
			Avatar = Config.SafeGetValue("Avatar", "https://example.com", "webhook avatar");
			WebHook = Config.SafeGetValue("WebHook", "", "logs will be sent to webhook if bot is dead");
			WebHookBans = Config.SafeGetValue("WebHookForBansAndKicks", "", "bans and kicks will be sent to the webhook if the bot is dead");
			EnablesSetTopic = Config.SafeGetValue("EnablesSetTopic", true);

			Translate = Config.SafeGetValue("Translate", new Translate(), "Translations");

			JsonConfig.UpdateFile();
		}
	}
}