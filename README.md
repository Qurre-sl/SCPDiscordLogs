# SCPDiscordLogs
##### Sends game logs to your discord guild
## Installation
### Bot
Put [DiscordLogs.js](https://github.com/fydne/SCPDiscordLogs/blob/main/DiscordLogs.js) in `~/.config`(`%AppData%` on Windows)`/Qurre/Configs`

[DiscordLogs.js](https://github.com/fydne/SCPDiscordLogs/blob/main/DiscordLogs.js) - bot config.

Example for use on multiple servers.
```json
{
    ...
	port: 7777,
    ...
},
{
    ...
	port: 7778,
    ...
}
```
#### Launch
There is nothing difficult in launching the bot, just run the file from the archive required for your system.
### Plugin & Translation
Plugin installation is normal, put plugin in `~/.config`(`%AppData%` on Windows)`/Qurre/Plugins`

Cfg:
```yml
logs_ip: localhost
```
Translation of logs:
```yaml
/*EN*/
/*soon...*/
```
```yaml
/*RU*/
logs_waiting: :hourglass: Ожидание игроков...
logs_round_info: Игроков онлайн: %players%. Длительность раунда: %time% минут. Живых людей: %alive%. Живых scp: %scps%. %alpha% IP: %ip%
logs_round_start: :arrow_forward: Раунд запущен: %players% игроков на сервере.
logs_round_end: :stop_button: Раунд закончен: %players% игроков онлайн.
logs_item_change: :stop_button: Раунд закончен: %players% игроков онлайн.
logs_item_drop: %player% дропнул %item%.
logs_item_pickup: %player% подобрал %item%.
logs_alpha_detonated: Альфа-Боеголовка взорвана.
logs_alpha_active: Альфа-Боеголовка запущена.
logs_alpha_not_detonated: Альфа-Боеголовка не взорвана.
logs_alpha_detonation: :radioactive: **Альфа-боеголовка успешно взорвана**
logs_alpha_start: :radioactive: **Альфа-Боеголовка взорвется через %time% секунд.**
logs_alpha_stop: ***%player% выключил Альфа-Боеголовку.***
logs_alpha_panel: %player% получил доступ к крышке кнопки детонации альфа-боеголовки.
logs_generator_activate: Активировался генератор
logs_generator_inject: %player% вставил планшет в генератор.
logs_generator_open: %player% открыл генератор.
logs_generator_unlock: %player% разблокировал дверь генератора.
logs_generator_close: %player% закрыл генератор.
logs_generator_ejected: %player% достал планшет из генератора.
logs_banned: :no_entry: %player% забанен %issuer% за %reason%. До %time%
logs_report_cheater: **Отправлен репорт на читера: %sender%. Зарепорчен - %target%. Причина: %reason%.**
logs_portal_create: %player% создал портал.
logs_portal_use: %player% использовал портал.
logs_pocket_enter: %player% попал в карманное измерение.
logs_pocket_escape: %player% сбежал из карманного измерения.
logs_femur_enter: %player% пожертвовал собой в камере SCP 106.
logs_106_contain: %player% успешно восстановил условия содержания SCP 106.
logs_079_getexp: %player% получил %exp% опыта за %type%.
logs_079_getlvl: %player% получил %lvl% уровень 079.
logs_weapon_reload: %player% перезарядил оружие: %weapon%.
logs_interact_locker: %player% открыл шкафчик.
logs_interact_tesla: %player% заагрил теслу.
logs_interact_lift: %player% вызвал лифт.
logs_interact_door_close: %player% закрыл дверь: %door%.
logs_interact_door_open: %player% открыл дверь: %door%.
logs_914_activate: %player% активировал SCP 914, настройки: %state%.
logs_914_change: %player% изменил настройки SCP 914 на %setting%.
logs_914_upgrade: SCP 914 улучшил:\nИгроков:%players%.\nПредметы:%items%.
logs_join: :arrow_right: **%player% присоединился к игре.**
logs_leave: :arrow_left: **%player% ливнул с сервера.**
logs_uncuff: :unlock: %target% был освобожден %uncuffer%
logs_cuff: :lock: %target% был связан %cuffer%
logs_icom_speak: :loud_sound: %player% начал использовать интерком.
logs_group_change: %player% получил роль: **%group%**.
logs_lcz_decon: :biohazard: **Началось обеззараживание легкой зоны**
logs_team_spawn: Приехал отряд %team% в кол-ве %players% человек.
logs_grenade_throw: :bomb: %player% бросил гранату.
logs_medical_use: :medical_symbol: %player% использовал %item%.
logs_escape: %player% сбежал, новая роль: %role%.
logs_spawn: %player% появился за %role%.
logs_ra: :keyboard: %player% использовал команду: %command%
logs_console: %player% использовал команду на [ё]: %command%
logs_damage_teamkill: :crossed_swords: **%attacker% нанес %amount% урона %target% с %tool%.**
logs_damage: %attacker% нанес %amount% урона %target% с %tool%.
logs_kill_teamkill: :o: **%killer% убил %target% с %tool%.**
logs_kill: :skull_crossbones: **%killer% убил %target% с %tool%.**
```