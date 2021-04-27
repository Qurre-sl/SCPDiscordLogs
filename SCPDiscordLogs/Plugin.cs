using GameCore;
using System.Collections.Generic;
using Events = Qurre.Events;
using Version = System.Version;
namespace SCPDiscordLogs
{
    public class Plugin : Qurre.Plugin
    {
        #region Peremens
        public override string Developer => "Qurre Team (fydne)";
        public override string Name => "SCP Discord Logs";
        public override Version Version => new Version(1, 0, 5);
        public override Version NeededQurreVersion => new Version(1, 2, 9);
        public override int Priority => 100000;
        public override void Enable() => RegisterEvents();
        public override void Disable() => UnregisterEvents();
        public int MaxPlayers = ConfigFile.ServerConfig.GetInt("max_players", 100);
        private EventHandlers EventHandlers;
        #endregion
        #region Events
        public void RegisterEvents()
        {
            Cfg.LoadReloadCfg();
            Events.Round.WaitingForPlayers += Cfg.LoadReloadCfg;
            MEC.Timing.RunCoroutine(Enumerator());
            EventHandlers = new EventHandlers();
            Events.Map.LCZDecon += EventHandlers.Decon;
            Events.SCPs.SCP079.GeneratorActivate += EventHandlers.GeneratorActivate;
            Events.Alpha.Starting += EventHandlers.AlphaStart;
            Events.Alpha.Stopping += EventHandlers.AlphaStop;
            Events.Alpha.Detonated += EventHandlers.Detonation;
            Events.SCPs.SCP914.Upgrade += EventHandlers.Upgrade;

            Events.Server.SendingRA += EventHandlers.SendingRA;
            Events.Round.WaitingForPlayers += EventHandlers.Waiting;
            Events.Server.SendingConsole += EventHandlers.SendingConsole;
            Events.Round.Start += EventHandlers.RoundStart;
            Events.Round.End += EventHandlers.RoundEnd;
            Events.Round.TeamRespawn += EventHandlers.TeamRespawn;
            Events.Server.Report.Cheater += EventHandlers.ReportCheater;

            Events.SCPs.SCP914.ChangeKnob += EventHandlers.ChangeKnob;
            Events.Player.MedicalUsed += EventHandlers.MedicalUsed;
            Events.Player.PickupItem += EventHandlers.Pickup;
            Events.Player.InteractGenerator += EventHandlers.InteractGenerator;
            Events.SCPs.SCP079.GetLVL += EventHandlers.GetLVL;
            Events.SCPs.SCP079.GetEXP += EventHandlers.GetEXP;
            Events.SCPs.SCP106.PocketDimensionEscape += EventHandlers.PocketDimensionEscape;
            Events.SCPs.SCP106.PocketDimensionEnter += EventHandlers.PocketDimensionEnter;
            Events.SCPs.SCP106.PortalCreate += EventHandlers.PortalCreate;
            Events.Alpha.EnablePanel += EventHandlers.EnableAlphaPanel;
            Events.Player.TeslaTrigger += EventHandlers.TeslaTrigger;
            Events.Player.ThrowGrenade += EventHandlers.ThrowGrenade;
            Events.Player.Damage += EventHandlers.Damage;
            Events.Player.Dead += EventHandlers.Dead;
            Events.Player.Banned += EventHandlers.Banned;
            Events.Player.InteractDoor += EventHandlers.InteractDoor;
            Events.Player.InteractLift += EventHandlers.InteractLift;
            Events.Player.InteractLocker += EventHandlers.InteractLocker;
            Events.Player.IcomSpeak += EventHandlers.IcomSpeak;
            Events.Player.Cuff += EventHandlers.Cuff;
            Events.Player.UnCuff += EventHandlers.UnCuff;
            Events.SCPs.SCP106.PortalUsing += EventHandlers.PortalUsing;
            Events.SCPs.SCP106.FemurBreakerEnter += EventHandlers.Femur;
            Events.Player.RechargeWeapon += EventHandlers.RechargeWeapon;
            Events.Player.DropItem += EventHandlers.Drop;
            Events.Player.Join += EventHandlers.Join;
            Events.Player.Leave += EventHandlers.Leave;
            Events.Player.RoleChange += EventHandlers.RoleChange;
            Events.Player.GroupChange += EventHandlers.GroupChange;
            Events.Player.ItemChange += EventHandlers.ItemChange;
            Events.SCPs.SCP914.Activating += EventHandlers.Activating;
            Events.SCPs.SCP106.Contain += EventHandlers.Contain;

            Events.Player.Ban += EventHandlers.Ban;
            Events.Player.Kick += EventHandlers.Kick;
        }
        public void UnregisterEvents()
        {
            Events.Round.WaitingForPlayers -= Cfg.LoadReloadCfg;

            Events.Map.LCZDecon -= EventHandlers.Decon;
            Events.SCPs.SCP079.GeneratorActivate -= EventHandlers.GeneratorActivate;
            Events.Alpha.Starting -= EventHandlers.AlphaStart;
            Events.Alpha.Stopping -= EventHandlers.AlphaStop;
            Events.Alpha.Detonated -= EventHandlers.Detonation;
            Events.SCPs.SCP914.Upgrade -= EventHandlers.Upgrade;

            Events.Server.SendingRA -= EventHandlers.SendingRA;
            Events.Round.WaitingForPlayers -= EventHandlers.Waiting;
            Events.Server.SendingConsole -= EventHandlers.SendingConsole;
            Events.Round.Start -= EventHandlers.RoundStart;
            Events.Round.End -= EventHandlers.RoundEnd;
            Events.Round.TeamRespawn -= EventHandlers.TeamRespawn;
            Events.Server.Report.Cheater -= EventHandlers.ReportCheater;

            Events.SCPs.SCP914.ChangeKnob -= EventHandlers.ChangeKnob;
            Events.Player.MedicalUsed -= EventHandlers.MedicalUsed;
            Events.Player.PickupItem -= EventHandlers.Pickup;
            Events.Player.InteractGenerator -= EventHandlers.InteractGenerator;
            Events.SCPs.SCP079.GetLVL -= EventHandlers.GetLVL;
            Events.SCPs.SCP079.GetEXP -= EventHandlers.GetEXP;
            Events.SCPs.SCP106.PocketDimensionEscape -= EventHandlers.PocketDimensionEscape;
            Events.SCPs.SCP106.PocketDimensionEnter -= EventHandlers.PocketDimensionEnter;
            Events.SCPs.SCP106.PortalCreate -= EventHandlers.PortalCreate;
            Events.Alpha.EnablePanel -= EventHandlers.EnableAlphaPanel;
            Events.Player.TeslaTrigger -= EventHandlers.TeslaTrigger;
            Events.Player.ThrowGrenade -= EventHandlers.ThrowGrenade;
            Events.Player.Damage -= EventHandlers.Damage;
            Events.Player.Dead -= EventHandlers.Dead;
            Events.Player.Banned -= EventHandlers.Banned;
            Events.Player.InteractDoor -= EventHandlers.InteractDoor;
            Events.Player.InteractLift -= EventHandlers.InteractLift;
            Events.Player.InteractLocker -= EventHandlers.InteractLocker;
            Events.Player.IcomSpeak -= EventHandlers.IcomSpeak;
            Events.Player.Cuff -= EventHandlers.Cuff;
            Events.Player.UnCuff -= EventHandlers.UnCuff;
            Events.SCPs.SCP106.PortalUsing -= EventHandlers.PortalUsing;
            Events.SCPs.SCP106.FemurBreakerEnter -= EventHandlers.Femur;
            Events.Player.RechargeWeapon -= EventHandlers.RechargeWeapon;
            Events.Player.DropItem -= EventHandlers.Drop;
            Events.Player.Join -= EventHandlers.Join;
            Events.Player.Leave -= EventHandlers.Leave;
            Events.Player.RoleChange -= EventHandlers.RoleChange;
            Events.Player.GroupChange -= EventHandlers.GroupChange;
            Events.Player.ItemChange -= EventHandlers.ItemChange;
            Events.SCPs.SCP914.Activating -= EventHandlers.Activating;
            Events.SCPs.SCP106.Contain -= EventHandlers.Contain;

            Events.Player.Ban -= EventHandlers.Ban;
            Events.Player.Kick -= EventHandlers.Kick;
            EventHandlers = null;
        }
        public IEnumerator<float> Enumerator()
        {
            for (; ; )
            {
                yield return MEC.Timing.WaitForSeconds(1f);
                try { Send.sendplayersinfo(); } catch { }
                try { EventHandlers.UpdateServerStatus(); } catch { }
                try { Send.fatalsendmsg(); } catch { }
            }
        }
        #endregion
    }
}