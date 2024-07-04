using System;
using System.Collections.Generic;
using System.Linq;
using Qurre.API;
using QurreSocket;

namespace SCPDiscordLogs
{
    static class Send
    {
        #region ClosePls
        static internal bool BlockInRaLogs(string UserID) => Cfg.BlockRa.Contains(UserID);
        static internal bool GLobalBypass(string UserID) => Cfg.GlobalInvisible.Contains(UserID);
        #endregion
        static internal Client Client;
        static internal string msg = "";
        static internal string last_msg = "";

        static internal string GetTime => $"<t:{DateTimeOffset.Now.ToUnixTimeSeconds()}:T>";

        static internal void FatalMsg()
        {
            try
            {
                if (msg.Length < 1) return;
                Client.Emit("msg", new string[] { msg });
                msg = "";
            }
            catch
            {
                if (Cfg.WebHook == "") return;
                Webhook webhk = new(Cfg.WebHook);
                webhk.Send(msg);
                msg = "";
            }
        }
        static internal void Msg(string data)
        {
            if (last_msg == data) return;
            if (msg.Length > 1500) FatalMsg();
            last_msg = data;
            msg += $"[{GetTime}] {data}";
            msg += "\n";
        }

        static internal void PlayersInfo()
        {
            try { Client.Emit("players", new object[] { Player.List.Count() }); } catch { }
        }
        static internal void ChannelTopic(string data)
        {
            if (!Cfg.EnablesSetTopic)
                return;

            try { Client.Emit("channelstatus", new string[] { data }); } catch { }
        }

        static internal void RemoteAdmin(string data)
        {
            try { Client.Emit("ra", new string[] { $"[{GetTime}] {data}" }); }
            catch
            {
                if (Cfg.WebHook == "") return;
                Webhook webhk = new(Cfg.WebHook);
                webhk.Send($"[{GetTime}] {data}");
            }
        }

        static internal void TeamKill(string data)
        {
            if (Round.Started)
            {
                try { Client.Emit("tk", new string[] { $"[{GetTime}] {data}" }); }
                catch
                {
                    if (Cfg.WebHook == "") return;
                    Webhook webhk = new(Cfg.WebHook);
                    webhk.Send($"[{GetTime}] {data}");
                }
            }
        }

        static internal void BanKick(string reason, string banned, string banner, string time)
        {
            try
            {
                if (time == "kick") Client.Emit("kick", new string[] { banned, banner, reason });
                else Client.Emit("ban", new string[] { banned, banner, reason, time });
            }
            catch
            {
                if (Cfg.WebHookBans == "") return;
                Webhook webhk = new(Cfg.WebHookBans);
                List<Embed> listEmbed = new();
                Embed embed = new();
                EmbedAuthor author = new();
                EmbedFooter footer = new()
                {
                    Text = "© Qurre Team",
                    IconUrl = "https://cdn.scpsl.store/qurre/qurre_ol.png"
                };
                var ttl = Cfg.Translate.Ban;
                var color = 16711680;
                var desc = Cfg.Translate.BanWebHook.Replace("%banned%", $"{banned}").Replace("%banner%", $"{banner}").Replace("%reason%", $"{reason}").Replace("%to%", $"{time}");
                if (time == "kick")
                {
                    ttl = Cfg.Translate.Kick;
                    color = 16776960;
                    desc = Cfg.Translate.KickWebHook.Replace("%kicked%", $"{banned}").Replace("%kicker%", $"{banner}").Replace("%reason%", $"{reason}");
                }
                author.Name = Cfg.ServerName;
                author.IconUrl = Cfg.Avatar;
                embed.Author = author;
                embed.Title = ttl;
                embed.Color = color;
                embed.Description = desc;
                embed.Footer = footer;
                listEmbed.Add(embed);
                webhk.Send("", embeds: listEmbed);
            }
        }

        static internal void Reply(string data)
        {
            try { Client.Emit("reply", new string[] { $"[{GetTime}] {data}" }); }
            catch
            {
                if (Cfg.WebHook == "") return;
                Webhook webhk = new(Cfg.WebHook);
                webhk.Send($"[{GetTime}] {data}");
            }
        }

        static internal void Disconnect() => Client.Disconnect(false);
        static internal void Init()
        {
            Client = new(Cfg.Port, Cfg.Ip);
            Client.On("connect", _ => Client.Emit("send.token", new object[] { Cfg.Token }));
            Client.On("send-to-ra", (data) =>
            {
                try
                {
                    GameCore.Console.singleton.TypeCommand($"/{data[1]}", new BotSender($"{data[0]}"));
                }
                catch (Exception e)
                {
                    Log.Debug(e);
                }
            });
        }
    }

    class BotSender : CommandSender
    {
        public override void RaReply(string text, bool success, bool logToConsole, string overrideDisplay)
        {
            Send.Reply($"{text}");
        }
        public override void Print(string text)
        {
            Send.Reply($"{text}");
        }

        public string Name;
        public BotSender(string name) => Name = name;

        public override string SenderId => "SERVER CONSOLE";
        public override string Nickname => Name;
        public override ulong Permissions => ServerStatic.GetPermissionsHandler().FullPerm;
        public override byte KickPower => byte.MaxValue;
        public override bool FullPermissions => true;
    }
}