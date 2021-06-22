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
#delimiter between id and nickname in ra
#Example: [14:9:50] ⌨️ fydne - [data deleted]@steam used command: forceclass 2^fydne^ 1^ClassD^
# ^ - delimiter
logs_delimiter: ^
#Those who will not be logged in ra logs
logs_block_ra_logs: 7654@steam, 444@discord,1337@steam
#server name
logs_server_name: Qurre
#webhook avatar
logs_avatar: https://cdn.scpsl.store/qurre/qurre_ol.png
#logs will be sent to webhook if bot is dead
logs_webhook: 
#bans and kicks will be sent to the webhook if the bot is dead
logs_webhook_bans_kicks: 

logs_kick: Kick
logs_ban: Ban
logs_kick_msg: %kicked% has been kicked by %kicker%. Reason: %reason%
logs_kick_msg: %banned% has been banned by %banner%. Reason: %reason%\nUntil %to%
```
Translation of logs:
```yaml
#EN
#translated by [NPG] nekto™#0021
logs_waiting: :hourglass: Waiting for players...
logs_round_info: Players online: %players%. Round duration: %time% min. Players alive: %alive%. SCPs alive: %scps%. %alpha% IP: %ip%
logs_round_start: :arrow_forward: Round started: %players% players online.
logs_round_end: :stop_button: Round ended: %players% players online.
logs_item_change: %player% changed the item in hand: %olditem% -> %newitem%.
logs_item_drop: %player% dropped %item%.
logs_item_pickup: %player% picked up %item%.
logs_alpha_detonated: Alpha-warhead has been detonated.
logs_alpha_active: Alpha-warhead has been activated.
logs_alpha_not_detonated: Alpha-warhead not detonated.
logs_alpha_detonation: :radioactive: **The Alpha warhead was successfully detonated**
logs_alpha_start: :radioactive: **Alpha-warhed has been activated, %time% seconds to detonation.**
logs_alpha_stop: ***%player% actvivated the Alpha-warhead.***
logs_alpha_panel: %player% got access to the alpha warhead detonation button cover.
logs_generator_activate: Generator has been activated.
logs_generator_inject: %player% insert weapon tablet to generator.
logs_generator_open: %player% opened generator.
logs_generator_unlock: %player% unlocked generator.
logs_generator_close: %player% closed generator.
logs_generator_ejected: %player% ejected weapon tablet from generator.
logs_banned: :no_entry: %player% was banned %issuer% for %reason%. Ban expires: %time%
logs_report_cheater: **Cheater has been reported  by: %sender%. Reported player - %target%. Reason: %reason%.**
logs_portal_create: %player% Created portal.
logs_portal_use: %player% Used portal.
logs_pocket_enter: %player% hit the pocket dimension.
logs_pocket_escape: %player% escaped from pocket dimension.
logs_femur_enter: %player% sacrificed himself in SCP 106 cell.
logs_106_contain: %player% succesfuly recontained SCP 106.
logs_079_getexp: %player% get %exp% for %type%.
logs_079_getlvl: %player% get %lvl% SCP 079 level.
logs_weapon_reload: %player% reloaded weapon: %weapon%.
logs_interact_locker: %player% оpened locker.
logs_interact_tesla: %player% trigered tesla gate.
logs_interact_lift: %player% called elevator.
logs_interact_door_close: %player% close door: %door%.
logs_interact_door_open: %player% opened: %door%.
logs_914_activate: %player% activated SCP 914, on settings: %state%.
logs_914_change: %player% changed SCP 914 settings to %setting%.
logs_914_upgrade: SCP 914 upgraded:\nPlayers:%players%.\nItems:%items%.
logs_join: :arrow_right: **%player% connected to the server.**
logs_leave: :arrow_left: **%player% left the server.**
logs_uncuff: :unlock: %target% has been uncuffed by %uncuffer%
logs_cuff: :lock: %target% has been cuffed by %cuffer%
logs_group_change: %player% has changed his role to: **%group%**.
logs_lcz_decon: :biohazard: **Light Containment zone decontamination sequence has been started**
logs_team_spawn: %team% team arrived with number of %players% units.
logs_grenade_throw: :bomb: %player% threw a grenade.
logs_medical_use: :medical_symbol: %player% used %item%.
logs_escape: %player% has escaped, his new role is: %role%.
logs_spawn: %player% spawned as %role%.
logs_ra: :keyboard: %player% used command: %command%
logs_console: %player% used ingame command [`]: %command%
logs_damage_teamkill: :crossed_swords: **%attacker% damaged teamate %target% for %amount%, using %tool%.**
logs_damage: %attacker% damaged %target% for %amount%, using %tool%.
logs_kill_teamkill: :o: **%killer% teamkilled %target% using %tool%.**
logs_kill: :skull_crossbones: **%killer% killed %target% using %tool%.**
```
```yaml
#RU
logs_waiting: :hourglass: Ожидание игроков...
logs_round_info: Игроков онлайн: %players%. Длительность раунда: %time% минут. Живых людей: %alive%. Живых scp: %scps%. %alpha% IP: %ip%
logs_round_start: :arrow_forward: Раунд запущен: %players% игроков на сервере.
logs_round_end: :stop_button: Раунд закончен: %players% игроков онлайн.
logs_item_change: %player% поменял предмет в руке: %olditem% -> %newitem%.
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
