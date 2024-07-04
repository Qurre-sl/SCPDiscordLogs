using PlayerRoles;
using Qurre.API;

namespace SCPDiscordLogs
{
    static public class Api
    {
        static public bool Connected => Send.Client.Connected;

        static public string AntiMD(string text)
        {
            return text.Replace("_", "\\_").Replace("*", "\\*").Replace("|", "\\|").Replace("~", "\\~").Replace("`", "\\`").Replace("<@", "\\<\\@").Replace("@", "\\@").Replace("@e", "@е").Replace("@he", "@hе");
        }
        static public bool BlockInRaLogs(string UserID) => Send.BlockInRaLogs(UserID);
        static public bool GLobalBypass(string UserID) => Send.GLobalBypass(UserID);
        static public string PlayerInfo(Player pl, bool role = true)
        {
            if (pl == Server.Host) return $"{pl.UserInformation.Nickname}";
            else
            {
                string nick = pl.UserInformation.Nickname.Replace("_", "\\_").Replace("*", "\\*").Replace("|", "\\|").Replace("~", "\\~")
                    .Replace("`", "\\`").Replace("<@", "\\<\\@").Replace("@", "\\@").Replace("@e", "@е").Replace("@he", "@hе");
                try
                {
                    if (role)
                    {
                        var _role = pl.RoleInformation.Role;
                        if ((_role is RoleTypeId.Spectator or RoleTypeId.None) && EventHandlers.Cached.TryGetValue(pl, out var __role))
                            _role = __role;
                        return $"{nick} - {pl.UserInformation.UserId} ({_role})";
                    }
                    else return $"{nick} - {pl.UserInformation.UserId}";
                }
                catch
                {
                    try { return $"{nick} - {pl.UserInformation.UserId}"; }
                    catch { return nick; }
                }
            }
        }

        static public void SendMessage(string data, Status status = Status.Standart)
        {
            switch (status)
            {
                case Status.Standart:
                    Send.Msg(data);
                    break;

                case Status.RemoteAdmin:
                    Send.RemoteAdmin(data);
                    break;

                case Status.TeamKill:
                    Send.TeamKill(data);
                    break;

                case Status.Reply:
                    Send.Reply(data);
                    break;
            }
        }

        static public void SendBanOrKick(string reason, string banned, string banner, string time)
            => Send.BanKick(reason, banned, banner, time);

        static public void SendPlayers()
            => Send.PlayersInfo();

        static public void SendChannelTopic(string data)
            => Send.ChannelTopic(data);

        public enum Status : byte
        {
            Standart,
            RemoteAdmin,
            TeamKill,
            Reply
        }
    }
}