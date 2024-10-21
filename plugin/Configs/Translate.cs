namespace SCPLogs.Configs;

public class Translate(string desc, string lua, string[] channels, bool enabled = false)
{
    // ReSharper disable once UnusedMember.Global
    public string Description { get; set; } = desc;
    public string LuaScript { get; set; } = lua;
    public string[] Channels { get; set; } = channels;
    public bool Enabled { get; set; } = enabled;
}