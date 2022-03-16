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
#ip specified in a bot config
logs_ip: localhost
#port specified in a bot config
logs_port: 7777 #default server port
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
```
Translation of logs:

*Located in `~/.config`(`%AppData%` on Windows)`/Qurre/Configs/Custom/SCPDiscordLogs-Translate.yaml`
```yaml
#EN
#translated by [NPG] nekto™#0021
Name: SCPDiscordLogs-Translate
Kick: Kick
Ban: Ban
KickWebHook: '%kicked% has been kicked by %kicker%. Reason: %reason%'
BanWebHook: '%banned% has been banned by %banner%. Reason: %reason%\nUntil %to%'
RoundInfo: 'Players online: %players%. Round duration: %time% min. Players alive: %alive%. SCPs alive: %scps%. %alpha% IP: %ip%'
PickupItem: '%player% picked up %item%'
DropItem: '%player% dropped %item%'
ChangeItem: '%player% changed the item in hand: %olditem% -> %newitem%'
RoundEnd: ':stop_button: Round ended: %players% players online.'
RoundStart: ':arrow_forward: Round started: %players% players online.'
Waiting: ':hourglass: Waiting for players...'
Kill: ':skull_crossbones: **%killer% killed %target% using %tool%**'
TeamKill: ':o: **%killer% teamkilled %target% using %tool%**'
Damage: '%attacker% damaged %target% for %amount%, using %tool%'
TeamDamage: ':crossed_swords: **%attacker% damaged teamate %target% for %amount%, using %tool%**'
Console: '%player% used console command [`]: %command%'
Ra: ':keyboard: %player% used command: %command%'
Spawn: '%player% spawned as %role%'
Escape: '%player% has escaped, his new role is: %role%'
UseItem: '%player% used %item%'
ThrowItem: '%player% threw the %item%'
TeamSpawn: '%team% team arrived with number of %players% units.'
LczDecon: ':biohazard: **Light Containment zone decontamination sequence has been started**'
AdminRoleChange: '%player% has changed his role to: **%group%**'
Cuff: ':lock: %target% has been cuffed by %cuffer%'
UnCuff: ':unlock: %target% has been uncuffed by %uncuffer%'
Leave: ':arrow_left: **%player% leaved from the server.**'
Join: ':arrow_right: **%player% connected to the server.**'
Upgrade914: 'SCP 914 upgraded:\nPlayers:%players%.\nItems:%items%'
Change914: '%player% changed SCP 914 settings to %setting%'
Activate914: '%player% activated SCP 914, on settings: %state%'
InteractDoorOpen: '%player% opened door: %door%'
InteractDoorClose: '%player% close door: %door%'
InteractLift: '%player% called elevator.'
InteractTesla: '%player% trigered tesla gate.'
InteractLocker: '%player% оpened locker %locker%'
WeaponReload: '%player% reloaded weapon: %weapon%'
GetLvl079: '%player% get %lvl% SCP 079 level.'
GetXp079: '%player% get %exp% for %type%'
Contain106: '%player% succesfuly recontained SCP 106.'
FemurEnter: '%player% sacrificed himself in SCP 106 cell.'
PocketEscape: '%player% escaped from pocket dimension.'
PocketEnter: '%player% hit the pocket dimension.'
PortalUse: '%player% used portal.'
PortalCreate: '%player% created portal.'
ReportCheater: '**Cheater has been reported  by: %sender%. Reported player - %target%. Reason: %reason%**'
Banned: ':no_entry: %player% was banned %issuer% for %reason%. Until: %time%'
GeneratorEjected: '%player% ejected weapon tablet from generator.'
GeneratorClose: '%player% closed generator.'
GeneratorUnlock: '%player% unlocked generator.'
GeneratorOpen: '%player% opened generator.'
GeneratorInject: '%player% insert weapon tablet to generator.'
GeneratorActivate: Generator has been activated
AlphaPanel: '%player% got access to the alpha warhead detonation button cover.'
AlphaStop: '***%player% actvivated the Alpha-warhead.***'
AlphaStart: ':radioactive: **Alpha-warhed has been activated, %time% seconds to detonation.**'
AlphaDetonation: ':radioactive: **The Alpha warhead was successfully detonated**'
AlphaNotDetonated: Alpha-warhead not detonated.
AlphaActive: Alpha-warhead has been activated.
AlphaDetonated: Alpha-warhead has been detonated.
LczAnnounce: '**Decontamination of the light zone will begin in %minutes% minutes**'
Heal: '%player% recovered %amout%HP'
FlashExplosion: '%player% exploded flash grenade'
FragExplosion: '%player% exploded frag grenade'
Flashed: '%target% was blinded by %thrower%'
Scp330Interact: '%player% picked up SCP-330'
Scp330Eat: '%player% eat SCP-330 %candy%'
```
```yaml
#RU
Name: SCPDiscordLogs-Translate
Kick: Кик
Ban: Бан
KickWebHook: 'Кикнут: %kicked%\nКикнул: %kicker%\nПричина: %reason%'
BanWebHook: 'Забанен: %banned%\nЗабанил: %banner%\nПричина: %reason%\nДо %to%'
RoundInfo: 'Игроков онлайн: %players%. Длительность раунда: %time% минут. Живых людей: %alive%. Живых scp: %scps%. %alpha% IP: %ip%'
PickupItem: '%player% подобрал %item%'
DropItem: '%player% дропнул %item%'
ChangeItem: '%player% поменял предмет в руке: %olditem% -> %newitem%'
RoundEnd: ':stop_button: Раунд закончен: %players% игроков онлайн.'
RoundStart: ':arrow_forward: Раунд запущен: %players% игроков на сервере.'
Waiting: ':hourglass: Ожидание игроков...'
Kill: ':skull_crossbones: **%killer% убил %target% с %tool%**'
TeamKill: ':o: **%killer% убил %target% с %tool%**'
Damage: '%attacker% нанес %amount% урона %target% с %tool%'
TeamDamage: ':crossed_swords: **%attacker% нанес %amount% урона %target% с %tool%**'
Console: '%player% использовал команду на [ё]: %command%'
Ra: ':keyboard: %player% использовал команду: %command%'
Spawn: '%player% появился за %role%'
Escape: '%player% сбежал, новая роль: %role%'
UseItem: '%player% использовал %item%'
ThrowItem: '%player% бросил %item%'
TeamSpawn: 'Приехал отряд %team% в кол-ве %players% человек.'
LczDecon: ':biohazard: **Началось обеззараживание легкой зоны**'
AdminRoleChange: '%player% получил роль: **%group%**'
Cuff: ':lock: %target% был связан %cuffer%'
UnCuff: ':unlock: %target% был освобожден %uncuffer%'
Leave: ':arrow_left: **%player% ливнул с сервера.**'
Join: ':arrow_right: **%player% присоединился к игре.**'
Upgrade914: 'SCP 914 улучшил:\nИгроков:%players%.\nПредметы:%items%'
Change914: '%player% изменил настройки SCP 914 на %setting%'
Activate914: '%player% активировал SCP 914, настройки: %state%'
InteractDoorOpen: '%player% открыл дверь: %door%'
InteractDoorClose: '%player% закрыл дверь: %door%'
InteractLift: '%player% вызвал лифт.'
InteractTesla: '%player% заагрил теслу.'
InteractLocker: '%player% открыл шкафчик %locker%'
WeaponReload: '%player% перезарядил оружие: %weapon%'
GetLvl079: '%player% получил %lvl% уровень 079.'
GetXp079: '%player% получил %exp% опыта за %type%'
Contain106: '%player% успешно восстановил условия содержания SCP 106.'
FemurEnter: '%player% пожертвовал собой в камере SCP 106.'
PocketEscape: '%player% сбежал из карманного измерения.'
PocketEnter: '%player% попал в карманное измерение.'
PortalUse: '%player% использовал портал.'
PortalCreate: '%player% создал портал.'
ReportCheater: '**Отправлен репорт на читера: %sender%. Зарепорчен - %target%. Причина: %reason%**'
Banned: ':no_entry: %player% забанен %issuer% за %reason%. До %time%'
GeneratorEjected: '%player% достал планшет из генератора.'
GeneratorClose: '%player% закрыл генератор.'
GeneratorUnlock: '%player% разблокировал дверь генератора.'
GeneratorOpen: '%player% открыл генератор.'
GeneratorInject: '%player% вставил планшет в генератор.'
GeneratorActivate: Активировался генератор
AlphaPanel: '%player% получил доступ к крышке кнопки детонации альфа-боеголовки.'
AlphaStop: '***%player% выключил Альфа-Боеголовку.***'
AlphaStart: ':radioactive: **Альфа-Боеголовка взорвется через %time% секунд.**'
AlphaDetonation: ':radioactive: **Альфа-боеголовка успешно взорвана**'
AlphaNotDetonated: Альфа-Боеголовка не взорвана.
AlphaActive: Альфа-Боеголовка запущена.
AlphaDetonated: Альфа-Боеголовка взорвана.
LczAnnounce: '**До обеззараживания лайт-зоны осталось %minutes% минут**'
Heal: '%player% восстановил %amout%HP'
FlashExplosion: '%player% взорвал светошумовую гранату'
FragExplosion: '%player% взорвал осколочную гранату'
Flashed: '%thrower% ослепил %target%'
Scp330Interact: '%player% подобрал SCP-330'
Scp330Eat: '%player% съел SCP-330 %candy%'
```
