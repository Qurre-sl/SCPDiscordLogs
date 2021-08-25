using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Qurre;
using Qurre.API;
namespace SCPDiscordLogs
{
    internal class Send
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
            List<string> strl = new List<string>();
            foreach (string st in str) strl.Add(st.Trim());
            return strl;
        }
        #endregion
        internal static string msg = "";
        internal static string last_msg = "";
        private const string statre = "⋠";
        internal static void FatalMsg()
        {
            try
            {
                if (msg.Length < 1) return;
                string str = $"msg=;={msg}{statre}";
                byte[] ba = Encoding.UTF8.GetBytes(str);
                msg = "";
                socket.Send(ba);
            }
            catch
            {
                if (Cfg.WebHook == "") return;
                Webhook webhk = new Webhook(Cfg.WebHook);
                webhk.Send(msg);
                msg = "";
            }
        }
        internal static void Msg(string data)
        {
            if (msg.Length > 1500) FatalMsg();
            if (last_msg == data) return;
            last_msg = data;
            msg += $"[{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}] {data}";
            msg += "\n";
        }
        internal static void PlayersInfo()
        {
            try
            {
                int players = Player.List.ToList().Count;
                string str = $"players=;={players}{statre}";
                byte[] ba = Encoding.UTF8.GetBytes(str);
                socket.Send(ba);
            }
            catch { }
        }
        internal static void ChannelTopic(string data)
        {
            try
            {
                string str = $"channelstatus=;={data}{statre}";
                byte[] ba = Encoding.UTF8.GetBytes(str);
                socket.Send(ba);
            }
            catch { }
        }
        internal static void RemoteAdmin(string data)
        {
            if (Round.Started)
            {
                try
                {
                    string str = $"ra=;=[{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}] {data}{statre}";
                    byte[] ba = Encoding.UTF8.GetBytes(str);
                    socket.Send(ba);
                }
                catch
                {
                    if (Cfg.WebHook == "") return;
                    Webhook webhk = new Webhook(Cfg.WebHook);
                    webhk.Send($"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}] {data}");
                }
            }
        }
        internal static void TeamKill(string data)
        {
            if (Round.Started)
            {
                try
                {
                    string str = $"tk=;=[{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}] {data}{statre}";
                    byte[] ba = Encoding.UTF8.GetBytes(str);
                    socket.Send(ba);
                }
                catch
                {
                    if (Cfg.WebHook == "") return;
                    Webhook webhk = new Webhook(Cfg.WebHook);
                    webhk.Send($"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}] {data}");
                }
            }
        }
        internal static void BanKick(string reason, string banned, string banner, string time)
        {
            try
            {
                string str = "";
                if (time == "kick") str = $"kick=;={banned}=;={banner}=;={reason}{statre}";
                else str = $"ban=;={banned}=;={banner}=;={reason}=;={time}{statre}";
                byte[] ba = Encoding.UTF8.GetBytes(str);
                socket.Send(ba);
            }
            catch
            {
                if (Cfg.WebHookBans == "") return;
                Webhook webhk = new Webhook(Cfg.WebHookBans);
                List<Embed> listEmbed = new List<Embed>();
                Embed embed = new Embed();
                var author = new EmbedAuthor();
                var footer = new EmbedFooter();
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
            try
            {
                string str = $"reply=;=[{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}] {data}{statre}";
                byte[] ba = Encoding.UTF8.GetBytes(str);
                socket.Send(ba);
            }
            catch
            {
                if (Cfg.WebHook == "") return;
                Webhook webhk = new Webhook(Cfg.WebHook);
                webhk.Send($"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}] {data}");
            }
        }
        internal static void CheckConnect()
        {
            if (!Connected())
            {
                try
                {
                    if (socket != null && socket.IsBound)
                    {
                        socket.Shutdown(SocketShutdown.Both);
                        socket.Close();
                    }
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect(Cfg.Ip, Server.Port);
                }
                catch { }
            }
        }
        internal static void Disconnect() => socket.Disconnect(false);
        internal static void Connect()
        {
            try
            {
                if (socket != null && socket.IsBound)
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(Cfg.Ip, Server.Port);
            }
            catch { }
            Thread messageThread = new Thread(() => BotListener());
            messageThread.Start();
        }
        private static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static bool Connected()
        {
            if (socket == null) return false;
            try { return !((socket.Poll(1000, SelectMode.SelectRead) && (socket.Available == 0)) || !socket.Connected); }
            catch { return false; }
        }
        private static void BotListener()
        {
            while (true)
            {
                if (Connected())
                {
                    try
                    {
                        byte[] data = new byte[1000];
                        int dataLength = socket.Receive(data);
                        string incomingData = Encoding.UTF8.GetString(data, 0, dataLength);
                        List<string> messages = new List<string>(incomingData.Split('\n'));
                        while (messages.Count > 0)
                        {
                            if (messages[0].Length == 0)
                            {
                                messages.RemoveAt(0);
                                continue;
                            }
                            var array = messages[0].Split('⋠');
                            GameCore.Console.singleton.TypeCommand($"/{array[1]}", new BotSender($"{array[0]}"));
                            messages.RemoveAt(0);
                        }
                    }
                    catch (Exception e)
                    {
                        if (Connected()) Log.Error("An error occurred while listening to the connection:\n" + e);
                    }
                }
                Thread.Sleep(1000);
            }
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