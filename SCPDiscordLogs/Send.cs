using System;
using System.Collections.Generic;
using System.Linq;
using Qurre.API;
using QurreSocket;
namespace SCPDiscordLogs
{
    internal static class Send
    {
        #region ClosePls
        public static string AntiMD(string text)
        {
            return text.Replace("_", "\\_").Replace("*", "\\*").Replace("|", "\\|").Replace("~", "\\~").Replace("`", "\\`").Replace("<@", "\\<\\@").Replace("@", "\\@").Replace("@e", "@е").Replace("@he", "@hе");
        }
        public static bool BlockInRaLogs(string UserID) => UserIDs().Contains(UserID);
        private static List<string> UserIDs()
        {
            string _ = Cfg.BlockRa;
            string[] str = _.Split(',');
            List<string> strl = new();
            foreach (string st in str) strl.Add(st.Trim());
            return strl;
        }
        #endregion
        internal static Client Client;
        internal static string msg = "";
        internal static string last_msg = "";
        private static string GetTime => $"<t:{DateTimeOffset.Now.ToUnixTimeSeconds()}:T>";
        internal static void FatalMsg()
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
        internal static void Msg(string data)
        {
            if (msg.Length > 1500) FatalMsg();
            if (last_msg == data) return;
            last_msg = data;
            msg += $"[{GetTime}] {data}";
            msg += "\n";
        }
        internal static void PlayersInfo()
        {
            try { Client.Emit("players", new object[] { Player.List.Count() }); } catch { }
        }
        internal static void ChannelTopic(string data)
        {
            try { Client.Emit("channelstatus", new string[] { data }); } catch { }
        }
        internal static void RemoteAdmin(string data)
        {
            try { Client.Emit("ra", new string[] { $"[{GetTime}] {data}" }); }
            catch
            {
                if (Cfg.WebHook == "") return;
                Webhook webhk = new(Cfg.WebHook);
                webhk.Send($"[{GetTime}] {data}");
            }
        }
        internal static void TeamKill(string data)
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
        internal static void BanKick(string reason, string banned, string banner, string time)
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
                EmbedFooter footer = new();
                footer.Text = "© Qurre Team";
                footer.IconUrl = "https://cdn.scpsl.store/qurre/qurre_ol.png";
                var ttl = Cfg.Ban;
                var color = 16711680;
                var desc = Cfg.Ban_msg.Replace("%banned%", $"{banned}").Replace("%banner%", $"{banner}").Replace("%reason%", $"{reason}").Replace("%to%", $"{time}");
                if (time == "kick")
                {
                    ttl = Cfg.Kick;
                    color = 16776960;
                    desc = Cfg.Kick_msg.Replace("%kicked%", $"{banned}").Replace("%kicker%", $"{banner}").Replace("%reason%", $"{reason}");
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
        internal static void Reply(string data)
        {
            try { Client.Emit("reply", new string[] { $"[{GetTime}] {data}" }); }
            catch
            {
                if (Cfg.WebHook == "") return;
                Webhook webhk = new(Cfg.WebHook);
                webhk.Send($"[{GetTime}] {data}");
            }
        }
        internal static void Disconnect() => Client.Disconnect(false);
        internal static void Init()
        {
            Client = new(Cfg.Port, Cfg.Ip);
            Client.On("connect", _ => Client.Emit("send.token", new object[] { Cfg.Token }));
            Client.On("send-to-ra", (data) => { try { GameCore.Console.singleton.TypeCommand($"/{data[1]}", new BotSender($"{data[0]}")); } catch { } });
        }
    }
    internal class BotSender : CommandSender
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