using Qurre.API;
namespace SCPDiscordLogs
{
	public static class Cfg
	{
		public static string Ip { get; private set; }
		public static string Delimiter { get; private set; }
		public static string BlockRa { get; private set; }
		public static string ServerName { get; private set; }
		public static string Avatar { get; private set; }
		internal static string WebHook { get; private set; }
		internal static string WebHookBans { get; private set; }
		internal static string Kick => Plugin.Translate.Kick;
		internal static string Ban => Plugin.Translate.Ban;
		internal static string Kick_msg => Plugin.Translate.KickWebHook;
		internal static string Ban_msg => Plugin.Translate.BanWebHook;
		internal static string T1 => Plugin.Translate.Waiting;
		internal static string T2 => Plugin.Translate.RoundStart;
		internal static string T3 => Plugin.Translate.RoundEnd;
		internal static string T4 => Plugin.Translate.ChangeItem;
		internal static string T5 => Plugin.Translate.DropItem;
		internal static string T6 => Plugin.Translate.AlphaDetonation;
		internal static string T7 => Plugin.Translate.GeneratorActivate;
		internal static string T8 => Plugin.Translate.Banned;
		internal static string T9 => Plugin.Translate.ReportCheater;
		internal static string T10 => Plugin.Translate.PortalCreate;
		internal static string T11 => Plugin.Translate.GetXp079;
		internal static string T12 => Plugin.Translate.GetLvl079;
		internal static string T13 => Plugin.Translate.WeaponReload;
		internal static string T14 => Plugin.Translate.InteractLocker;
		internal static string T15 => Plugin.Translate.InteractTesla;
		internal static string T16 => Plugin.Translate.Activate914;
		internal static string T17 => Plugin.Translate.Change914;
		internal static string T18 => Plugin.Translate.PocketEnter;
		internal static string T19 => Plugin.Translate.PocketEscape;
		internal static string T20 => Plugin.Translate.PortalUse;
		internal static string T21 => Plugin.Translate.FemurEnter;
		internal static string T22 => Plugin.Translate.Join;
		internal static string T23 => Plugin.Translate.UnCuff;
		internal static string T24 => Plugin.Translate.Cuff;
		internal static string T26 => Plugin.Translate.PickupItem;
		internal static string T27 => Plugin.Translate.AdminRoleChange;
		internal static string T28 => Plugin.Translate.LczDecon;
		internal static string T29 => Plugin.Translate.AlphaStart;
		internal static string T30 => Plugin.Translate.AlphaStop;
		internal static string T31 => Plugin.Translate.AlphaPanel;
		internal static string T32 => Plugin.Translate.InteractLift;
		internal static string T33 => Plugin.Translate.Contain106;
		internal static string T34 => Plugin.Translate.TeamSpawn;
		internal static string T35 => Plugin.Translate.Leave;
		internal static string T36 => Plugin.Translate.ThrowItem;
		internal static string T37 => Plugin.Translate.UseItem;
		internal static string T38 => Plugin.Translate.Escape;
		internal static string T39 => Plugin.Translate.Spawn;
		internal static string T40 => Plugin.Translate.Console;
		internal static string T41 => Plugin.Translate.Upgrade914;
		internal static string T42 => Plugin.Translate.TeamDamage;
		internal static string T43 => Plugin.Translate.Damage;
		internal static string T44 => Plugin.Translate.GeneratorInject;
		internal static string T45 => Plugin.Translate.GeneratorOpen;
		internal static string T46 => Plugin.Translate.GeneratorUnlock;
		internal static string T47 => Plugin.Translate.GeneratorClose;
		internal static string T48 => Plugin.Translate.GeneratorEjected;
		internal static string T49 => Plugin.Translate.InteractDoorClose;
		internal static string T50 => Plugin.Translate.InteractDoorOpen;
		internal static string T51 => Plugin.Translate.TeamKill;
		internal static string T52 => Plugin.Translate.Kill;
		internal static string T53 => Plugin.Translate.AlphaDetonated;
		internal static string T54 => Plugin.Translate.AlphaActive;
		internal static string T55 => Plugin.Translate.AlphaNotDetonated;
		internal static string T56 => Plugin.Translate.RoundInfo;
		internal static string T57 => Plugin.Translate.Ra;
		internal static void LoadReloadCfg()
		{
			Plugin.Translate.Reload();
			Cfg.Ip = Plugin.Config.GetString("logs_ip", "localhost", "ip specified in a bot config");
			Cfg.Delimiter = Plugin.Config.GetString("logs_delimiter", "^", "delimiter between id and nickname in ra");
			Cfg.BlockRa = Plugin.Config.GetString("logs_block_ra_logs", "7654@steam, 444@discord,1337@steam", "Those who will not be logged in ra logs");
			Cfg.ServerName = Plugin.Config.GetString("logs_server_name", "Qurre", "server name");
			Cfg.Avatar = Plugin.Config.GetString("logs_avatar", "https://cdn.scpsl.store/qurre/qurre_ol.png", "webhook avatar");
			Cfg.WebHook = Plugin.Config.GetString("logs_webhook", "", "logs will be sent to webhook if bot is dead");
			Cfg.WebHookBans = Plugin.Config.GetString("logs_webhook_bans_kicks", "", "bans and kicks will be sent to the webhook if the bot is dead");
		}
	}
}