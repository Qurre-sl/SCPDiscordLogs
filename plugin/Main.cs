using Qurre.API;
using Qurre.API.Addons;
using Qurre.API.Attributes;
using SCPLogs.Configs;
using SCPLogs.Sockets;

namespace SCPLogs;

[PluginInit("SCP Logs", "ZXC Team", "3.0.0")]
public static class Main
{
    internal static JsonConfig Config { get; } = new("SCPLogs");
    internal static Global GlobalConfig { get; private set; } = new();
    internal static LuaConfig LuaConfig { get; private set; } = new();
    
    public static ISender? Sender { get; private set; }
    
    [PluginEnable]
    internal static void Enable()
    {
        GlobalConfig = Config.SafeGetValue("Global", new Global());
        LuaConfig = Config.SafeGetValue("Lua", new LuaConfig());
        
        Events.Load();
        
        JsonConfig.UpdateFile();

        LuaConfig.Load(LuaConfig);

        switch (GlobalConfig.Protocol)
        {
            case Protocol.Http:
                Sender = new Sockets.Http.Client();
                break;
            
            default:
                Log.Warn($"Unknown protocol: {GlobalConfig.Protocol}");
                break;
        }
    }
}