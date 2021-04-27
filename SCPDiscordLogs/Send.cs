using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using Qurre.API;
namespace SCPDiscordLogs
{
    public class Send
    {
        public static NetworkStream ss;
        internal static string msg = "";
        internal static string last_msg = "";
        internal static void fatalsendmsg()
        {
            try
            {
                TcpClient stcp = new TcpClient();
                stcp.Connect(Cfg.Ip, ServerConsole.Port);
                ss = stcp.GetStream();
                string str = $"msg=;={msg}";
                byte[] ba = Encoding.UTF8.GetBytes(str);
                msg = "";
                ss.Write(ba, 0, ba.Length);
                stcp.Close();
            }
            catch { }
        }
        public static void sendmsg(string cdata)
        {
            if (msg.Length > 1500)
            {
                fatalsendmsg();
            }
            if (last_msg == cdata)
            {
                last_msg = cdata;
                return;
            }
            last_msg = cdata;
            msg += $"[{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}] {cdata}";
            msg += "\n";
        }
        public static void sendplayersinfo()
        {
            try
            {
                TcpClient stcp = new TcpClient();
                stcp.Connect(Cfg.Ip, ServerConsole.Port);
                ss = stcp.GetStream();
                int players = Player.List.ToList().Count;
                string str = $"players=;={players}";
                byte[] ba = Encoding.UTF8.GetBytes(str);
                ss.Write(ba, 0, ba.Length);
                stcp.Close();
            }
            catch { }
        }
        public static void sendchanneltopic(string cdata)
        {
            try
            {
                TcpClient stcp = new TcpClient();
                stcp.Connect(Cfg.Ip, ServerConsole.Port);
                ss = stcp.GetStream();
                string str = $"channelstatus=;={cdata}";
                byte[] ba = Encoding.UTF8.GetBytes(str);

                ss.Write(ba, 0, ba.Length);
                stcp.Close();
            }
            catch { }
        }
        public static void sendra(string cdata)
        {
            try
            {
                if (Round.IsStarted)
                {
                    TcpClient stcp = new TcpClient();
                    stcp.Connect(Cfg.Ip, ServerConsole.Port);
                    ss = stcp.GetStream();
                    string str = $"ra=;=[{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}] {cdata}";
                    byte[] ba = Encoding.UTF8.GetBytes(str);

                    ss.Write(ba, 0, ba.Length);
                    stcp.Close();
                }
            }
            catch { }
        }
        public static void sendtk(string cdata)
        {
            try
            {
                if (Round.IsStarted)
                {
                    TcpClient stcp = new TcpClient();
                    stcp.Connect(Cfg.Ip, ServerConsole.Port);
                    ss = stcp.GetStream();
                    string str = $"tk=;=[{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}] {cdata}";
                    byte[] ba = Encoding.UTF8.GetBytes(str);

                    ss.Write(ba, 0, ba.Length);
                    stcp.Close();
                }
            }
            catch { }
        }
        public static void sendban(string reason, string banned, string banner, string time)
        {
            try
            {
                TcpClient stcp = new TcpClient();
                stcp.Connect(Cfg.Ip, ServerConsole.Port);
                ss = stcp.GetStream();
                string str = "";
                if (time == "kick")
                {
                    str = $"kick=;={banned}=;={banner}=;={reason}";
                }
                else
                {
                    str = $"ban=;={banned}=;={banner}=;={reason}=;={time}";
                }
                byte[] ba = Encoding.UTF8.GetBytes(str);

                ss.Write(ba, 0, ba.Length);
                stcp.Close();
            }
            catch { }
        }
        public static string PlayerInfo(Player pl, bool role = true)
        {
            if (pl == Server.Host) return $"{pl.Nickname}";
            else
            {
                if (role) return $"{pl.Nickname} - {pl.UserId} ({pl.Role})";
                else return $"{pl.Nickname} - {pl.UserId}";
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
    }
}