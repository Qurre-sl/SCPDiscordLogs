using Qurre.API.Attributes;
using System.Threading;

namespace SCPDiscordLogs
{
    [PluginInit("SCP Discord Logs", "Qurre Team (fydne)", "2.0.0")]
    static public class Plugin
    {
        #region Peremens
        static bool FirstEnable = true;
        #endregion

        #region Events
        [PluginEnable]
        static public void Enable()
        {
            Cfg.LoadReloadCfg();
            if (FirstEnable)
            {
                new Thread(() => Enumerator()).Start();
                new Thread(() => ThreadSendMsg()).Start();
                FirstEnable = false;
            }

            new Thread(() => Send.Init()).Start();
        }

        [PluginDisable]
        static public void Disable()
        {
            Send.Disconnect();
        }

        static void Enumerator()
        {
            Thread.Sleep(1000);
            for (; ; )
            {
                try { Send.PlayersInfo(); } catch { }
                try { EventHandlers.UpdateServerStatus(); } catch { }
                Thread.Sleep(60000);
            }
        }
        static void ThreadSendMsg()
        {
            Thread.Sleep(1000);
            for (; ; )
            {
                try { Send.FatalMsg(); } catch { }
                Thread.Sleep(5000);
            }
        }
        #endregion
    }
}