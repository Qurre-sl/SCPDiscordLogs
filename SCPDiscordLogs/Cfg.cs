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
		internal static string Kick { get; private set; }
		internal static string Ban { get; private set; }
		internal static string Kick_msg { get; private set; }
		internal static string Ban_msg { get; private set; }
		internal static string T1 { get; private set; }
		internal static string T2 { get; private set; }
		internal static string T3 { get; private set; }
		internal static string T4 { get; private set; }
		internal static string T5 { get; private set; }
		internal static string T6 { get; private set; }
		internal static string T7 { get; private set; }
		internal static string T8 { get; private set; }
		internal static string T9 { get; private set; }
		internal static string T10 { get; private set; }
		internal static string T11 { get; private set; }
		internal static string T12 { get; private set; }
		internal static string T13 { get; private set; }
		internal static string T14 { get; private set; }
		internal static string T15 { get; private set; }
		internal static string T16 { get; private set; }
		//internal static string T17 { get; private set; }
		internal static string T18 { get; private set; }
		internal static string T19 { get; private set; }
		internal static string T20 { get; private set; }
		internal static string T21 { get; private set; }
		internal static string T22 { get; private set; }
		internal static string T23 { get; private set; }
		internal static string T24 { get; private set; }
		internal static string T26 { get; private set; }
		internal static string T27 { get; private set; }
		internal static string T28 { get; private set; }
		internal static string T29 { get; private set; }
		internal static string T30 { get; private set; }
		internal static string T31 { get; private set; }
		internal static string T32 { get; private set; }
		internal static string T33 { get; private set; }
		internal static string T34 { get; private set; }
		internal static string T35 { get; private set; }
		internal static string T36 { get; private set; }
		internal static string T37 { get; private set; }
		internal static string T38 { get; private set; }
		internal static string T39 { get; private set; }
		internal static string T40 { get; private set; }
		internal static string T41 { get; private set; }
		internal static string T42 { get; private set; }
		internal static string T43 { get; private set; }
		internal static string T44 { get; private set; }
		internal static string T45 { get; private set; }
		internal static string T46 { get; private set; }
		internal static string T47 { get; private set; }
		internal static string T48 { get; private set; }
		internal static string T49 { get; private set; }
		internal static string T50 { get; private set; }
		internal static string T51 { get; private set; }
		internal static string T52 { get; private set; }
		internal static string T53 { get; private set; }
		internal static string T54 { get; private set; }
		internal static string T55 { get; private set; }
		internal static string T56 { get; private set; }
		internal static string T57 { get; private set; }
		internal static void LoadReloadCfg()
		{
			Cfg.Ip = Plugin.Config.GetString("logs_ip", "localhost", "ip specified in a bot config");
			Cfg.Delimiter = Plugin.Config.GetString("logs_delimiter", "^", "delimiter between id and nickname in ra");
			Cfg.BlockRa = Plugin.Config.GetString("logs_block_ra_logs", "7654@steam, 444@discord,1337@steam", "Those who will not be logged in ra logs");
			Cfg.ServerName = Plugin.Config.GetString("logs_server_name", "Qurre", "server name");
			Cfg.Avatar = Plugin.Config.GetString("logs_avatar", "https://cdn.scpsl.store/qurre/qurre_ol.png", "webhook avatar");
			Cfg.WebHook = Plugin.Config.GetString("logs_webhook", "", "logs will be sent to webhook if bot is dead");
			Cfg.WebHookBans = Plugin.Config.GetString("logs_webhook_bans_kicks", "", "bans and kicks will be sent to the webhook if the bot is dead");

			Cfg.Kick = Plugin.Config.GetString("logs_kick", "Kick");
			Cfg.Ban = Plugin.Config.GetString("logs_ban", "Ban");
			Cfg.Kick_msg = Plugin.Config.GetString("logs_kick_msg", "%kicked% has been kicked by %kicker%. Reason: %reason%");
			Cfg.Ban_msg = Plugin.Config.GetString("logs_kick_msg", "%banned% has been banned by %banner%. Reason: %reason%\nUntil %to%");

			Cfg.T1 = Plugin.Config.GetString("logs_waiting", ":hourglass: Waiting for players...");
			Cfg.T56 = Plugin.Config.GetString("logs_round_info", "Players online: %players%. Round duration: %time% min. Players alive: %alive%. SCPs alive: %scps%. %alpha% IP: %ip%");
			Cfg.T2 = Plugin.Config.GetString("logs_round_start", ":arrow_forward: Round started: %players% players online.");
			Cfg.T3 = Plugin.Config.GetString("logs_round_end", ":stop_button: Round ended: %players% players online.");
			Cfg.T4 = Plugin.Config.GetString("logs_item_change", "%player% changed the item in hand: %olditem% -> %newitem%.");
			Cfg.T5 = Plugin.Config.GetString("logs_item_drop", "%player% dropped %item%.");
			Cfg.T26 = Plugin.Config.GetString("logs_item_pickup", "%player% picked up %item%.");
			Cfg.T53 = Plugin.Config.GetString("logs_alpha_detonated", "Alpha-warhead has been detonated.");
			Cfg.T54 = Plugin.Config.GetString("logs_alpha_active", "Alpha-warhead has been activated.");
			Cfg.T55 = Plugin.Config.GetString("logs_alpha_not_detonated", "Alpha-warhead not detonated.");
			Cfg.T6 = Plugin.Config.GetString("logs_alpha_detonation", ":radioactive: **The Alpha warhead was successfully detonated**");
			Cfg.T29 = Plugin.Config.GetString("logs_alpha_start", ":radioactive: **Alpha-warhed has been activated, %time% seconds to detonation.**");
			Cfg.T30 = Plugin.Config.GetString("logs_alpha_stop", "***%player% actvivated the Alpha-warhead.***");
			Cfg.T31 = Plugin.Config.GetString("logs_alpha_panel", "%player% got access to the alpha warhead detonation button cover.");
			Cfg.T7 = Plugin.Config.GetString("logs_generator_activate", "Generator has been activated");
			Cfg.T44 = Plugin.Config.GetString("logs_generator_inject", "%player% insert weapon tablet to generator.");
			Cfg.T45 = Plugin.Config.GetString("logs_generator_open", "%player% opened generator.");
			Cfg.T46 = Plugin.Config.GetString("logs_generator_unlock", "%player% unlocked generator.");
			Cfg.T47 = Plugin.Config.GetString("logs_generator_close", "%player% closed generator.");
			Cfg.T48 = Plugin.Config.GetString("logs_generator_ejected", "%player% ejected weapon tablet from generator.");
			Cfg.T8 = Plugin.Config.GetString("logs_banned", ":no_entry: %player% was banned %issuer% for %reason%. Until: %time%");
			Cfg.T9 = Plugin.Config.GetString("logs_report_cheater", "**Cheater has been reported  by: %sender%. Reported player - %target%. Reason: %reason%.**");
			Cfg.T10 = Plugin.Config.GetString("logs_portal_create", "%player% created portal.");
			Cfg.T20 = Plugin.Config.GetString("logs_portal_use", "%player% used portal.");
			Cfg.T18 = Plugin.Config.GetString("logs_pocket_enter", "%player% hit the pocket dimension.");
			Cfg.T19 = Plugin.Config.GetString("logs_pocket_escape", "%player% escaped from pocket dimension.");
			Cfg.T21 = Plugin.Config.GetString("logs_femur_enter", "%player% sacrificed himself in SCP 106 cell.");
			Cfg.T33 = Plugin.Config.GetString("logs_106_contain", "%player% succesfuly recontained SCP 106.");
			Cfg.T11 = Plugin.Config.GetString("logs_079_getexp", "%player% get %exp% for %type%.");
			Cfg.T12 = Plugin.Config.GetString("logs_079_getlvl", "%player% get %lvl% SCP 079 level.");
			Cfg.T13 = Plugin.Config.GetString("logs_weapon_reload", "%player% reloaded weapon: %weapon%.");
			Cfg.T14 = Plugin.Config.GetString("logs_interact_locker", "%player% оpened locker.");
			Cfg.T15 = Plugin.Config.GetString("logs_interact_tesla", "%player% trigered tesla gate.");
			Cfg.T32 = Plugin.Config.GetString("logs_interact_lift", "%player% called elevator.");
			Cfg.T49 = Plugin.Config.GetString("logs_interact_door_close", "%player% close door: %door%.");
			Cfg.T50 = Plugin.Config.GetString("logs_interact_door_open", "%player% opened door: %door%.");
			Cfg.T16 = Plugin.Config.GetString("logs_914_activate", "%player% activated SCP 914, on settings: %state%.");
			//Cfg.T17 = Plugin.Config.GetString("logs_914_change", "%player% changed SCP 914 settings to %setting%.");
			Cfg.T41 = Plugin.Config.GetString("logs_914_upgrade", "SCP 914 upgraded:\nPlayers:%players%.\nItems:%items%.");
			Cfg.T22 = Plugin.Config.GetString("logs_join", ":arrow_right: **%player% connected to the server.**");
			Cfg.T35 = Plugin.Config.GetString("logs_leave", ":arrow_left: **%player% left the server.**");
			Cfg.T23 = Plugin.Config.GetString("logs_uncuff", ":unlock: %target% has been uncuffed by %uncuffer%");
			Cfg.T24 = Plugin.Config.GetString("logs_cuff", ":lock: %target% has been cuffed by %cuffer%");
			Cfg.T27 = Plugin.Config.GetString("logs_group_change", "%player% has changed his role to: **%group%**.");
			Cfg.T28 = Plugin.Config.GetString("logs_lcz_decon", ":biohazard: **Light Containment zone decontamination sequence has been started**");
			Cfg.T34 = Plugin.Config.GetString("logs_team_spawn", "%team% team arrived with number of %players% units.");
			Cfg.T36 = Plugin.Config.GetString("logs_grenade_throw", ":bomb: %player% threw a grenade.");
			Cfg.T37 = Plugin.Config.GetString("logs_medical_use", ":medical_symbol: %player% used %item%.");
			Cfg.T38 = Plugin.Config.GetString("logs_escape", "%player% has escaped, his new role is: %role%.");
			Cfg.T39 = Plugin.Config.GetString("logs_spawn", "%player% spawned as %role%.");
			Cfg.T57 = Plugin.Config.GetString("logs_ra", ":keyboard: %player% used command: %command%");
			Cfg.T40 = Plugin.Config.GetString("logs_console", "%player% used ingame command [`]: %command%");
			Cfg.T42 = Plugin.Config.GetString("logs_damage_teamkill", ":crossed_swords: **%attacker% damaged teamate %target% for %amount%, using %tool%.**");
			Cfg.T43 = Plugin.Config.GetString("logs_damage", "%attacker% damaged %target% for %amount%, using %tool%.");
			Cfg.T51 = Plugin.Config.GetString("logs_kill_teamkill", ":o: **%killer% teamkilled %target% using %tool%.**");
			Cfg.T52 = Plugin.Config.GetString("logs_kill", ":skull_crossbones: **%killer% killed %target% using %tool%.**");
		}
	}
}