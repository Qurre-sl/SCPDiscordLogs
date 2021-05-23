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
        public static string PlayerInfo(Player pl, bool role = true)
        {
            if (pl == Server.Host) return $"{pl.Nickname}";
            else
            {
                string nick = pl.Nickname.Replace("_", "\\_").Replace("*", "\\*").Replace("|", "\\|").Replace("~", "\\~").Replace("`", "\\`");
                if (role) return $"{nick} - {pl.UserId} ({pl.Role})";
                else return $"{nick} - {pl.UserId}";
            }
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
        internal static void fatalsendmsg()
        {
            try
            {
                if (msg.Length < 1) return;
                string str = $"msg=;={msg}{statre}";
                byte[] ba = Encoding.UTF8.GetBytes(str);
                msg = "";
                socket.Send(ba);
            }
            catch { }
        }
        public static void sendmsg(string cdata)
        {
            if (msg.Length > 1500)
            {
                fatalsendmsg();
            }
            if (last_msg == cdata) return;
            last_msg = cdata;
            msg += $"[{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}] {cdata}";
            msg += "\n";
        }
        public static void sendplayersinfo()
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
        public static void sendchanneltopic(string cdata)
        {
            try
            {
                string str = $"channelstatus=;={cdata}{statre}";
                byte[] ba = Encoding.UTF8.GetBytes(str);
                socket.Send(ba);
            }
            catch { }
        }
        public static void sendra(string cdata)
        {
            try
            {
                if (Round.Started)
                {
                    string str = $"ra=;=[{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}] {cdata}{statre}";
                    byte[] ba = Encoding.UTF8.GetBytes(str);
                    socket.Send(ba);
                }
            }
            catch { }
        }
        public static void sendtk(string cdata)
        {
            try
            {
                if (Round.Started)
                {
                    string str = $"tk=;=[{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}] {cdata}{statre}";
                    byte[] ba = Encoding.UTF8.GetBytes(str);
                    socket.Send(ba);
                }
            }
            catch { }
        }
        public static void sendban(string reason, string banned, string banner, string time)
        {
            try
            {
                string str = "";
                if (time == "kick") str = $"kick=;={banned}=;={banner}=;={reason}{statre}";
                else str = $"ban=;={banned}=;={banner}=;={reason}=;={time}{statre}";
                byte[] ba = Encoding.UTF8.GetBytes(str);
                socket.Send(ba);
            }
            catch { }
        }
        public static void sendreply(string cdata)
        {
            try
            {
                string str = $"reply=;=[{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}] {cdata}{statre}";
                byte[] ba = Encoding.UTF8.GetBytes(str);
                socket.Send(ba);
            }
            catch { }
        }
        public static void Disconnect() => socket.Disconnect(false);
        public static void Connect()
        {
            while (!Connected())
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
                catch
                {
                }
            }
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
                        Log.Error("An error occurred while listening to the connection:\n" + e);
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
            Send.sendreply($"{text}");
        }
        public override void Print(string text)
        {
            Send.sendreply($"{text}");
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