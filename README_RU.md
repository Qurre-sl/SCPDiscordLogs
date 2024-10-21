<p align="center">
   <a href="https://discord.gg/zGUqfJQebn">
      <img src="https://discord.com/api/guilds/779412392651653130/embed.png" alt="Discord"/>
   </a>
   <a href="https://github.com/Qurre-sl/SCPLogs/releases">
      <img src="https://img.shields.io/github/downloads/Qurre-sl/SCPLogs/total?color=%2300b813&style=plastic" alt="Downloads"/>
   </a>
   <a href="https://github.com/Qurre-sl/SCPLogs/releases">
      <img src="https://img.shields.io/github/v/release/Qurre-sl/SCPLogs.svg?style=plastic" alt="Release"/>
   </a>
</p>

<h1 align="center">SCPLogs</h1>
<p align="center">
<img src="https://readme-typing-svg.herokuapp.com/?font=Fira+Code&pause=1000&color=3FF781&center=true&vCenter=true&width=435&lines=U+want?+Just+do+it.;Are+you+lazy?+Use+one+command.;Specific+needs?+We're+on+our+way.">
</p>
<p align="center">
Первый плагин в своем роде, предоставляющий максимально возможную кастомизацию.
</p>

<h1 align="center">Конфиги</h1>
<p align="center">
Все ивенты подгружаются динамически и создают свою копию в конфигах Qurre, поэтому вам нет нужды ждать, пока обновится плагин и добавятся новые ивенты - они появятся автоматически при обновлении Qurre.
</p>
<h2 align="center">Конфиги плагина</h2>
<h3 align="center">Global</h3>
<p align="center">
"Global" namespace содержит в себе следующие параметры:

| Название    | Значение по умолчанию                                              | Тип переменной | Описание                                                                                                                                                                                                                                                     |
|-------------|--------------------------------------------------------------------|----------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Ip          | 127.0.0.1                                                          | string         | IP-адрес клиента. Если установлен на том же хосте, тогда `127.0.0.1`, если нет - указанный в конфиге клиента.                                                                                                                                                |
| Port        | 8080                                                               | uint           | Порт клиента. Должен совпадать с конфигом клиента.                                                                                                                                                                                                           |
| Protocol    | 0 _(TCP)_                                                          | Protocol       | Используемый протокол для обмена сообщениями между клиентом и плагином.<br/>Актуальные значения можно посмотреть в /plugin/Sockets/Protocol.cs<br/>TCP = 0,<br/>UDP = 1,<br/>HTTP = 2,<br/>WebSocket = 3,<br/>RabbitMQ = 4                                   |
| ClientToken | GENERATE RANDOM                                                    | string         | Токен авторизации на клиенте. Должен совпадать с токеном сокета на клиенте.                                                                                                                                                                                  |
| BadgeOnline | reply = string.format(<br/>"%s/%s players", <br/>Count, Slots)     | string *(Lua)* | Lua script для установки статуса бота.<br/>Переданные переменные в среду Lua:<br/>"Count" (int) - текущее количество игроков;<br/>"Slots" (int) - количество слотов на сервере<br/>Необходимо установить глобальную переменную "reply" с текстом для вывода. |

</p>
<h3 align="center">Translations</h3>
<p align="center">
Содержат в себе массив объектов перевода, которые обновляются динамически с изменением Qurre.
</p>
<p align="center">
Примерный вид:
</p>

```js
"AlphaStartEvent": {
    "Description": "Available arguments: {Player} (Qurre.API.Player); {Automatic} (System.Boolean); {Allowed} (System.Boolean);",
    "LuaScript": "",
    "Channels": [],
    "Enabled": false
},
```

| Название    | Тип переменной | Описание                                                                                          |
|-------------|----------------|---------------------------------------------------------------------------------------------------|
| Description | string         | Описание ивента. В общем, содержит себе перечень аргументов, передаваемых в среду Lua при вызове. |
| LuaScript   | string         | Lua script, который вызывается при срабатывании ивента. Подробнее ниже.                           |
| Channels    | string[]       | Массив с ID каналами/группами для отправки логов. Подробнее ниже.                                 |
| Enabled     | bool           | Определяет, включен ли лог. Если переменная "LuaScript" пуста, то ивент будет выключен.           |

<h3 align="center">Lua</h3>
<p align="center">
Содержит в себе настройки для окружения Lua

| Название         | Тип переменной | Описание                                                                      |
|------------------|----------------|-------------------------------------------------------------------------------|
| DeclareTypes     | DeclareType[]  | Массив с типами, которые будут объявлены в окружении Lua.<br/>Подробнее ниже. |

</p>

<h4 align="center">DeclareType</h4>
<p align="center">

| Название | Тип переменной | Пример         | Описание                                                                       |
|----------|----------------|----------------|--------------------------------------------------------------------------------|
| TypeName | string         | System.IO.Path | Полное название типа для вложения.<br/>Содержит в себе namespace + class name. |
| LuaName  | string         | System_Path    | Название типа, которое будет определено в глобальном окружении Lua.            |

</p>
<h6>Если вы хотите проиндексировать тип, но не хотите добавлять его в глобальное окружение Lua, то в "LuaName" укажите пустую строку ("").</h6>

<h1 align="center">Lua Scripts</h1>
<p align="center">
В этом плагине вы не встретите привычных жестко закодированных конфигов и переводов. Вы вправе сами выбирать, какие логи выводить.
</p><p align="center">
В глобальную среду Lua передаются все значения, указанные в описании ивента (`Description`), а также следующие:

| Название    | Значение по умолчанию | Тип переменной               | Описание                                                                                                                                                                                                                                                                          |
|-------------|-----------------------|------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| SendLog     | method                | Action < string, string[]? > | Вызывает метод отправки лога.<br/>При его вызове, объявлять глобальную переменную "reply" не обязательно.<br/>Переменная string - текст лога.<br/>Переменная string[] - id каналов, в которые будет отправлен лог.<br/>Может быть null, тогда лог отправится в каналы из конфига. |
| PrintPlayer | string                | Action < Player, bool? >     | Возвращает читаемый формат игрока [ nickname - userid (role) ]<br/>Является методом. Переменная bool (printRole) по умолчанию `false`                                                                                                                                             |
|             |                       |                              |                                                                                                                                                                                                                                                                                   |
| API_Server  | Class                 | Qurre.API.Server             | Содержит в себе класс Server от Qurre API.                                                                                                                                                                                                                                        |
| API_{Type}  | Class                 | Qurre.API.{Type}             | Содержит в себе статический класс Qurre API.<br/>Чтобы увидеть полный список, включите "Debug" в конфигах Qurre.<br/>Логи выведут список всех добавленных API в среду Lua.                                                                                                        |

Плагины могут добавлять собственные переменные. Для этого обратитесь к документации соответствующих плагинов.
</p><p align="center">
Если вы не знаете основ Lua, то можете воспользоваться [конвертерами кода](https://www.codeconvert.ai/csharp-to-lua-converter), либо изучить синтаксис Lua.
</p><p align="center">
При объявлении глобальной переменной [`reply`], плагин ее обработает и отправит клиенту.
</p><p align="center">
Примерный вид:

```lua
-- JoinEvent (это писать не обязательно)

reply = string.format("✨ Присоединился игрок **%s**, IP: %s", PrintPlayer(Player), Player.UserInformation.Ip)
```
</p><p align="center">
Что-нибудь посложнее:

```lua
-- RoundEndEvent
-- Необходимо объявить "System.IO.Path" (TypeName) с именем "System_Path" (LuaName) в конфиге "Lua.DeclareTypes"

SendLog(string.format("✨ Победила команда %s, раунд начнется через %s секунд. Текущий раунд: %s", Winner, ToRestart, API_Round.CurrentRound))

API_GlobalLights.TurnOff(100)

if Winner == 0 then
    API_AudioExtensions.PlayInIntercom(System_Path.Combine(API_Paths.Plugins, "Audio/BackupPower.raw"))
elseif Winner == 1 then
    API_AudioExtensions.PlayInIntercom(System_Path.Combine(API_Paths.Plugins, "Audio/NuclearAttack.raw"))
else
    API_AudioExtensions.PlayInIntercom(System_Path.Combine(API_Paths.Plugins, "Audio/RoundStart/cutscene.raw"))
end
```
</p>
<hr>

<h1 align="center">Установка</h1>
<h2 align="center">Установка плагина</h2>
<h3 align="center">Автоматическая</h3>
/ потом придумаю /
<h3 align="center">Ручная</h3>

1. Перейдите в релизы и скачайте архив plugin.zip
2. Откройте архив, и перенесите файлы в папку %appdata%/Qurre/Plugins
    1. SCPLogs перенесите в папку "Plugins"
    2. Файлы из папки "Dependencies" перенесите в соответствующую папку.

<h2 align="center">Установка клиента</h2>
<h3 align="center">Автоматическая</h3>
/ гайд для развертывания докера /
<h3 align="center">Ручная</h3>
/ в процессе /

<p align="center"><img src="https://count.getloli.com/get/@SCPLogs"></p>
