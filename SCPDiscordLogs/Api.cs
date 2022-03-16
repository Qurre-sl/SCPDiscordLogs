using Qurre.API;
namespace SCPDiscordLogs
{
    public static class Api
    {
        public static bool Connected => Send.Client.Connected;
        public static bool BlockInRaLogs(string UserID) => Send.BlockInRaLogs(UserID);
        public static string PlayerInfo(Player pl, bool role = true)
        {
            if (pl == Server.Host) return $"{pl.Nickname}";
            else
            {
                string nick = pl.Nickname.Replace("_", "\\_").Replace("*", "\\*").Replace("|", "\\|").Replace("~", "\\~")
                    .Replace("`", "\\`").Replace("<@", "\\<\\@").Replace("@", "\\@").Replace("@e", "@е").Replace("@he", "@hе");
                try
                {
                    if (role)
                    {
                        var _role = pl.Role;
                        if ((_role == RoleType.Spectator || _role == RoleType.None) && EventHandlers.Cached.TryGetValue(pl, out var __role)) _role = __role;
                        return $"{nick} - {pl.UserId} ({_role})";
                    }
                    else return $"{nick} - {pl.UserId}";
                }
                catch
                {
                    try { return $"{nick} - {pl.UserId}"; }
                    catch { return nick; }
                }
            }
        }
        public static void SendMessage(string data, Status status = Status.Standart)
        {
            if (status == Status.Standart) Send.Msg(data);
            else if (status == Status.RemoteAdmin) Send.RemoteAdmin(data);
            else if (status == Status.TeamKill) Send.TeamKill(data);
            else if (status == Status.Reply) Send.Reply(data);
        }
        public static void SendBanOrKick(string reason, string banned, string banner, string time) => Send.BanKick(reason, banned, banner, time);
        public static void SendPlayers() => Send.PlayersInfo();
        public static void SendChannelTopic(string data) => Send.ChannelTopic(data);
        public enum Status : byte
        {
            Standart,
            RemoteAdmin,
            TeamKill,
            Reply
        }
    }
}