namespace SCPLogs.Sockets;

public interface ISender
{
    void Send(string data, string[] channels);
    void Reply(string data, string argument);
}