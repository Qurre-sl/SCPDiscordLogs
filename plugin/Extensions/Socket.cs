using System.Linq;
using MoonSharp.Interpreter;
using Qurre.API;

namespace SCPLogs.Extensions;

internal static class SocketExtensions
{
    internal static string GetOnline()
    {
        Script luaScript = new();
        Lua.Internal.PrepareTable(luaScript.Globals);

        luaScript.Globals["Count"] = Player.List.Count();
        luaScript.Globals["Slots"] = CustomNetworkManager.slots;

        luaScript.DoString(Main.GlobalConfig.BadgeOnline);
        DynValue reply = luaScript.Globals.Get("reply");

        if (reply.IsNil())
            return string.Empty;

        return reply.Type == DataType.String ? reply.String : reply.ToString();
    }
}