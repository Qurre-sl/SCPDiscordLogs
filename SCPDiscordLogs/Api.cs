namespace SCPDiscordLogs
{
    public static class Api
    {
        public static bool Connected => Send.Connected();
        public static bool BlockInRaLogs(string UserID) => Send.BlockInRaLogs(UserID);
        public static void SendMessage(string data, Status status = Status.Standart)
        {
            if(status == Status.Standart) Send.sendmsg(data);
            else if (status == Status.RemoteAdmin) Send.sendra(data);
            else if (status == Status.TeamKill) Send.sendtk(data);
            else if (status == Status.Reply) Send.sendreply(data);
        }
        public static void SendBanOrKick(string reason, string banned, string banner, string time) => Send.sendban(reason, banned, banner, time);
        public static void SendPlayers() => Send.sendplayersinfo();
        public static void SendChannelTopic(string data) => Send.sendchanneltopic(data);
        public enum Status : byte
        {
            Standart,
            RemoteAdmin,
            TeamKill,
            Reply
        }
    }
}