namespace SCPDiscordLogs
{
	public static class Cfg
	{
		public static string Ip { get; private set; }
		public static string Delimiter { get; private set; }
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
		internal static string T17 { get; private set; }
		internal static string T18 { get; private set; }
		internal static string T19 { get; private set; }
		internal static string T20 { get; private set; }
		internal static string T21 { get; private set; }
		internal static string T22 { get; private set; }
		internal static string T23 { get; private set; }
		internal static string T24 { get; private set; }
		internal static string T25 { get; private set; }
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
			Cfg.Ip = Plugin.Config.GetString("logs_ip", "localhost");
			Cfg.Delimiter = Plugin.Config.GetString("logs_delimiter", "^");
			Cfg.T1 = Plugin.Config.GetString("logs_waiting", ":hourglass: Ожидание игроков...");
			Cfg.T56 = Plugin.Config.GetString("logs_round_info", "Игроков онлайн: %players%. Длительность раунда: %time% минут. Живых людей: %alive%. Живых scp: %scps%. %alpha% IP: %ip%");
			Cfg.T2 = Plugin.Config.GetString("logs_round_start", ":arrow_forward: Раунд запущен: %players% игроков на сервере.");
			Cfg.T3 = Plugin.Config.GetString("logs_round_end", ":stop_button: Раунд закончен: %players% игроков онлайн.");
			Cfg.T4 = Plugin.Config.GetString("logs_item_change", "%player% поменял предмет в руке: %olditem% -> %newitem%.");
			Cfg.T5 = Plugin.Config.GetString("logs_item_drop", "%player% дропнул %item%.");
			Cfg.T26 = Plugin.Config.GetString("logs_item_pickup", "%player% подобрал %item%.");
			Cfg.T53 = Plugin.Config.GetString("logs_alpha_detonated", "Альфа-Боеголовка взорвана.");
			Cfg.T54 = Plugin.Config.GetString("logs_alpha_active", "Альфа-Боеголовка запущена.");
			Cfg.T55 = Plugin.Config.GetString("logs_alpha_not_detonated", "Альфа-Боеголовка не взорвана.");
			Cfg.T6 = Plugin.Config.GetString("logs_alpha_detonation", ":radioactive: **Альфа-боеголовка успешно взорвана**");
			Cfg.T29 = Plugin.Config.GetString("logs_alpha_start", ":radioactive: **Альфа-Боеголовка взорвется через %time% секунд.**");
			Cfg.T30 = Plugin.Config.GetString("logs_alpha_stop", "***%player% выключил Альфа-Боеголовку.***");
			Cfg.T31 = Plugin.Config.GetString("logs_alpha_panel", "%player% получил доступ к крышке кнопки детонации альфа-боеголовки.");
			Cfg.T7 = Plugin.Config.GetString("logs_generator_activate", "Активировался генератор");
			Cfg.T44 = Plugin.Config.GetString("logs_generator_inject", "%player% вставил планшет в генератор.");
			Cfg.T45 = Plugin.Config.GetString("logs_generator_open", "%player% открыл генератор.");
			Cfg.T46 = Plugin.Config.GetString("logs_generator_unlock", "%player% разблокировал дверь генератора.");
			Cfg.T47 = Plugin.Config.GetString("logs_generator_close", "%player% закрыл генератор.");
			Cfg.T48 = Plugin.Config.GetString("logs_generator_ejected", "%player% достал планшет из генератора.");
			Cfg.T8 = Plugin.Config.GetString("logs_banned", ":no_entry: %player% забанен %issuer% за %reason%. До %time%");
			Cfg.T9 = Plugin.Config.GetString("logs_report_cheater", "**Отправлен репорт на читера: %sender%. Зарепорчен - %target%. Причина: %reason%.**");
			Cfg.T10 = Plugin.Config.GetString("logs_portal_create", "%player% создал портал.");
			Cfg.T20 = Plugin.Config.GetString("logs_portal_use", "%player% использовал портал.");
			Cfg.T18 = Plugin.Config.GetString("logs_pocket_enter", "%player% попал в карманное измерение.");
			Cfg.T19 = Plugin.Config.GetString("logs_pocket_escape", "%player% сбежал из карманного измерения.");
			Cfg.T21 = Plugin.Config.GetString("logs_femur_enter", "%player% пожертвовал собой в камере SCP 106.");
			Cfg.T33 = Plugin.Config.GetString("logs_106_contain", "%player% успешно восстановил условия содержания SCP 106.");
			Cfg.T11 = Plugin.Config.GetString("logs_079_getexp", "%player% получил %exp% опыта за %type%.");
			Cfg.T12 = Plugin.Config.GetString("logs_079_getlvl", "%player% получил %lvl% уровень 079.");
			Cfg.T13 = Plugin.Config.GetString("logs_weapon_reload", "%player% перезарядил оружие: %weapon%.");
			Cfg.T14 = Plugin.Config.GetString("logs_interact_locker", "%player% открыл шкафчик.");
			Cfg.T15 = Plugin.Config.GetString("logs_interact_tesla", "%player% заагрил теслу.");
			Cfg.T32 = Plugin.Config.GetString("logs_interact_lift", "%player% вызвал лифт.");
			Cfg.T49 = Plugin.Config.GetString("logs_interact_door_close", "%player% закрыл дверь: %door%.");
			Cfg.T50 = Plugin.Config.GetString("logs_interact_door_open", "%player% открыл дверь: %door%.");
			Cfg.T16 = Plugin.Config.GetString("logs_914_activate", "%player% активировал SCP 914, настройки: %state%.");
			Cfg.T17 = Plugin.Config.GetString("logs_914_change", "%player% изменил настройки SCP 914 на %setting%.");
			Cfg.T41 = Plugin.Config.GetString("logs_914_upgrade", "SCP 914 улучшил:\nИгроков:%players%.\nПредметы:%items%.");
			Cfg.T22 = Plugin.Config.GetString("logs_join", ":arrow_right: **%player% присоединился к игре.**");
			Cfg.T35 = Plugin.Config.GetString("logs_leave", ":arrow_left: **%player% ливнул с сервера.**");
			Cfg.T23 = Plugin.Config.GetString("logs_uncuff", ":unlock: %target% был освобожден %uncuffer%");
			Cfg.T24 = Plugin.Config.GetString("logs_cuff", ":lock: %target% был связан %cuffer%");
			Cfg.T25 = Plugin.Config.GetString("logs_icom_speak", ":loud_sound: %player% начал использовать интерком.");
			Cfg.T27 = Plugin.Config.GetString("logs_group_change", "%player% получил роль: **%group%**.");
			Cfg.T28 = Plugin.Config.GetString("logs_lcz_decon", ":biohazard: **Началось обеззараживание легкой зоны**");
			Cfg.T34 = Plugin.Config.GetString("logs_team_spawn", "Приехал отряд %team% в кол-ве %players% человек.");
			Cfg.T36 = Plugin.Config.GetString("logs_grenade_throw", ":bomb: %player% бросил гранату.");
			Cfg.T37 = Plugin.Config.GetString("logs_medical_use", ":medical_symbol: %player% использовал %item%.");
			Cfg.T38 = Plugin.Config.GetString("logs_escape", "%player% сбежал, новая роль: %role%.");
			Cfg.T39 = Plugin.Config.GetString("logs_spawn", "%player% появился за %role%.");
			Cfg.T57 = Plugin.Config.GetString("logs_ra", ":keyboard: %player% использовал команду: %command%");
			Cfg.T40 = Plugin.Config.GetString("logs_console", "%player% использовал команду на [ё]: %command%");
			Cfg.T42 = Plugin.Config.GetString("logs_damage_teamkill", ":crossed_swords: **%attacker% нанес %amount% урона %target% с %tool%.**");
			Cfg.T43 = Plugin.Config.GetString("logs_damage", "%attacker% нанес %amount% урона %target% с %tool%.");
			Cfg.T51 = Plugin.Config.GetString("logs_kill_teamkill", ":o: **%killer% убил %target% с %tool%.**");
			Cfg.T52 = Plugin.Config.GetString("logs_kill", ":skull_crossbones: **%killer% убил %target% с %tool%.**");
		}
	}
}