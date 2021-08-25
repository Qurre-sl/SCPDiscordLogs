using System;
using System.Linq;
using Respawning;
using Qurre;
using Qurre.API;
using Qurre.API.Events;
using Qurre.API.Objects;
using Qurre.API.Controllers;
namespace SCPDiscordLogs
{
	public class EventHandlers
	{
		public EventHandlers() => Log.Debug("[SCPDiscordLogs.EventHandlers] successfully initialized");
		public void Waiting() => Send.Msg(Cfg.T1);
		public void RoundStart() => Send.Msg(Cfg.T2.Replace("%players%", $"{Player.List.Count()}"));
		public void RoundEnd(RoundEndEvent _) => Send.Msg(Cfg.T3.Replace("%players%", $"{Player.List.Count()}"));
		public void Drop(DropItemEvent ev) => Send.Msg(Cfg.T5.Replace("%player%", Api.PlayerInfo(ev.Player)).Replace("%item%", $"{ev.Item.Type}"));
		public void Detonation() => Send.Msg(Cfg.T6);
		public void GeneratorActivate(GeneratorActivateEvent ev) => Send.Msg(Cfg.T7);
		public void Banned(BannedEvent ev) =>Send.Msg(Cfg.T8.Replace("%player%", $"{ev.Details.OriginalName} - {ev.Details.Id}")
			.Replace("%issuer%", ev.Details.Issuer).Replace("%reason%", ev.Details.Reason).Replace("%time%", $"{new DateTime(ev.Details.Expires):dd.MM.yyyy HH:mm}"));
		public void ItemChange(ItemChangeEvent ev)
		{
			try { Send.Msg(Cfg.T4.Replace("%player%", Api.PlayerInfo(ev.Player, false)).Replace("%olditem%", $"{ev.OldItem.Type}").Replace("%newitem%", $"{ev.NewItem.Type}")); } catch { }
		}
		public void ReportCheater(ReportCheaterEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T9.Replace("%sender%", Api.PlayerInfo(ev.Sender, false)).Replace("%target%", Api.PlayerInfo(ev.Target, false)).Replace("%reason%", ev.Reason));
		}
		public void PortalCreate(PortalCreateEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T10.Replace("%player%", Api.PlayerInfo(ev.Player, false)));
		}
		public void GetEXP(GetEXPEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T11.Replace("%player%", Api.PlayerInfo(ev.Player, false)).Replace("%exp%", $"{ev.Amount}").Replace("%type%", $"{ev.Type}"));
		}
		public void GetLVL(GetLVLEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T12.Replace("%player%", Api.PlayerInfo(ev.Player, false)).Replace("%lvl%", $"{ev.NewLevel}"));
		}
		public void RechargeWeapon(RechargeWeaponEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T13.Replace("%player%", Api.PlayerInfo(ev.Player)).Replace("%weapon%", $"{ev.Player.CurrentItem.TypeId}"));
		}
		public void InteractLocker(InteractLockerEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T14.Replace("%player%", Api.PlayerInfo(ev.Player)));
		}
		public void TeslaTrigger(TeslaTriggerEvent ev)
		{
			if (ev.Triggerable) Send.Msg(Cfg.T15.Replace("%player%", Api.PlayerInfo(ev.Player)));
		}
		public void Activating(ActivatingEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T16.Replace("%player%", Api.PlayerInfo(ev.Player)).Replace("%state%", $"{Qurre.API.Controllers.Scp914.KnobState}"));
		}/*
		public void ChangeKnob(ChangeKnobEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T17.Replace("%player%", Api.PlayerInfo(ev.Player)).Replace("%setting%", $"{ev.KnobSetting}"));
		}*/
		public void PocketDimensionEnter(PocketDimensionEnterEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T18.Replace("%player%", Api.PlayerInfo(ev.Player)));
		}
		public void PocketDimensionEscape(PocketDimensionEscapeEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T19.Replace("%player%", Api.PlayerInfo(ev.Player)));
		}
		public void PortalUsing(PortalUsingEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T20.Replace("%player%", Api.PlayerInfo(ev.Player, false)));
		}
		public void Femur(FemurBreakerEnterEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T21.Replace("%player%", Api.PlayerInfo(ev.Player)));
		}
		public void Join(JoinEvent ev)
		{
			if (ev.Player.Nickname != "Dedicated Server") Send.Msg(Cfg.T22.Replace("%player%", Api.PlayerInfo(ev.Player, false)));
		}
		public void UnCuff(UnCuffEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T23.Replace("%target%", Api.PlayerInfo(ev.Target)).Replace("%uncuffer%", Api.PlayerInfo(ev.Cuffer)));
		}
		public void Cuff(CuffEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T24.Replace("%target%", Api.PlayerInfo(ev.Target)).Replace("%cuffer%", Api.PlayerInfo(ev.Cuffer)));
		}
		public void Pickup(PickupItemEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T26.Replace("%player%", Api.PlayerInfo(ev.Player)).Replace("%item%", $"{ev.Pickup.Type}"));
		}
		public void GroupChange(GroupChangeEvent ev)
		{
			if (ev.Allowed) try { Send.Msg(Cfg.T27.Replace("%player%", Api.PlayerInfo(ev.Player, false)).Replace("%group%", $"{ev.NewGroup.BadgeText} ({ev.NewGroup.BadgeColor})")); } catch { }
		}
		public void Decon(LCZDeconEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T28);
		}
		public void AlphaStart(AlphaStartEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T29.Replace("%time%", $"{Alpha.AlphaWarheadController.NetworktimeToDetonation}"));
		}
		public void AlphaStop(AlphaStopEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T30.Replace("%player%", Api.PlayerInfo(ev.Player)));
		}
		public void EnableAlphaPanel(EnableAlphaPanelEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T31.Replace("%player%", Api.PlayerInfo(ev.Player)));
		}
		public void InteractLift(InteractLiftEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T32.Replace("%player%", Api.PlayerInfo(ev.Player)));
		}
		public void Contain(ContainEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T33.Replace("%player%", Api.PlayerInfo(ev.Player)));
		}
		public void TeamRespawn(TeamRespawnEvent ev)
		{
			string msg = ev.NextKnownTeam == SpawnableTeamType.ChaosInsurgency ? $":spy: Chaos Insurgency" : $":cop: Nine-Tailed Fox";
			Send.Msg(Cfg.T34.Replace("%team%", msg).Replace("%players%", $"{ev.Players.Count}"));
		}
		public void Leave(LeaveEvent ev)
		{
			Send.Msg(Cfg.T35.Replace("%player%", Api.PlayerInfo(ev.Player, false)));
			Send.PlayersInfo();
		}
		public void ThrowItem(ThrowItemEvent ev)
		{
			if (ev.Player == null) return;
			if (ev.Allowed) Send.Msg(Cfg.T36.Replace("%player%", Api.PlayerInfo(ev.Player)));
		}
		public void ItemUsed(ItemUsedEvent ev)
		{
			if (ev.Player == null) return;
			Send.Msg(Cfg.T37.Replace("%player%", Api.PlayerInfo(ev.Player)).Replace("%item%", $"{ev.Item}"));
		}
		public void RoleChange(RoleChangeEvent ev)
		{
			if (ev.Player == null) return;
			Send.Msg(Cfg.T39.Replace("%player%", Api.PlayerInfo(ev.Player, false)).Replace("%role%", $"{ev.NewRole}"));
		}
		public void Escape(EscapeEvent ev)
        {
			Send.Msg(Cfg.T38.Replace("%player%", Api.PlayerInfo(ev.Player, false)).Replace("%role%", $"{ev.NewRole}"));
		}
		public void SendingConsole(SendingConsoleEvent ev)
		{
			if (ev.Player == null || ev.Player == Server.Host) return;
			if (ev.Player?.Id == null) return;
			Send.Msg(Cfg.T40.Replace("%player%", Api.PlayerInfo(ev.Player)).Replace("%command%", $"{Send.AntiMD(ev.Message)}"));
		}
		public void Upgrade(UpgradeEvent ev)
		{
			string players = "";
			foreach (Player player in ev.Players) players += $"\n{Api.PlayerInfo(player)}";
			string items = "";
			foreach (var item in ev.Items) items += $"\n{item.Info.ItemId}";
			Send.Msg(Cfg.T41.Replace("%players%", players).Replace("%items%", items));
		}
		public void Damage(DamageEvent ev)
		{
			if (ev.Allowed)
			{
				if (ev.Attacker.Id == ev.Target.Id) return;
				if (ev.Attacker != null && ev.Target.Team == ev.Attacker.Team && ev.Target != ev.Attacker)
					Send.Msg(Cfg.T42.Replace("%tool%", $"{ev.DamageType.Name}").Replace("%amount%", $"{ev.Amount}").Replace("%attacker%", Api.PlayerInfo(ev.Attacker)).Replace("%target%", Api.PlayerInfo(ev.Target)));
				else Send.Msg(Cfg.T43.Replace("%tool%", $"{ev.DamageType.Name}").Replace("%amount%", $"{ev.Amount}").Replace("%attacker%", $"{ev.HitInformations.Attacker}").Replace("%target%", Api.PlayerInfo(ev.Target)));
			}
		}
		public void InteractGenerator(InteractGeneratorEvent ev)
		{
			if (ev.Allowed)
			{
				if (ev.Status == GeneratorStatus.Activated) Send.Msg(Cfg.T44.Replace("%player%", Api.PlayerInfo(ev.Player)));
				else if (ev.Status == GeneratorStatus.OpenDoor) Send.Msg(Cfg.T45.Replace("%player%", Api.PlayerInfo(ev.Player)));
				else if (ev.Status == GeneratorStatus.Unlocked) Send.Msg(Cfg.T46.Replace("%player%", Api.PlayerInfo(ev.Player)));
				else if (ev.Status == GeneratorStatus.CloseDoor) Send.Msg(Cfg.T47.Replace("%player%", Api.PlayerInfo(ev.Player)));
				else if (ev.Status == GeneratorStatus.Disabled) Send.Msg(Cfg.T48.Replace("%player%", Api.PlayerInfo(ev.Player)));
			}
		}
		public void InteractDoor(InteractDoorEvent ev)
		{
			try
			{
				if (ev.Door.Name.Length < 2) return;
				if (ev.Allowed)
					Send.Msg(ev.Door.DoorVariant.NetworkTargetState
							? Cfg.T49.Replace("%player%", Api.PlayerInfo(ev.Player)).Replace("%door%", $"{ev.Door.Name}")
							: Cfg.T50.Replace("%player%", Api.PlayerInfo(ev.Player)).Replace("%door%", $"{ev.Door.Name}")
							);
			}
			catch { }
		}
		public void Dead(DiesEvent ev)
		{
			try
			{
				if (!ev.Allowed) return;
				if (ev.Killer.Id == ev.Target.Id) return;
				if (ev.Killer != null && ev.Target.Team == ev.Killer.Team)
				{
					Send.TeamKill(Cfg.T51.Replace("%killer%", Api.PlayerInfo(ev.Killer)).Replace("%target%", Api.PlayerInfo(ev.Target)).Replace("%tool%", ev.HitInfo.Tool.Name));
					Send.Msg(Cfg.T51.Replace("%killer%", Api.PlayerInfo(ev.Killer)).Replace("%target%", Api.PlayerInfo(ev.Target)).Replace("%tool%", ev.HitInfo.Tool.Name));
				}
				else Send.Msg(Cfg.T52.Replace("%killer%", Api.PlayerInfo(ev.Killer)).Replace("%target%", Api.PlayerInfo(ev.Target)).Replace("%tool%", ev.HitInfo.Tool.Name));
			}
			catch { }
		}
		public static void UpdateServerStatus()
		{
			try
			{
				int max = GameCore.ConfigFile.ServerConfig.GetInt("max_players", 35);
				int cur = Player.List.Count();
				int aliveCount = 0;
				int scpCount = 0;
				foreach (Player player in Player.List)
					if (player.ReferenceHub.characterClassManager.IsHuman()) aliveCount++;
					else if (player.ReferenceHub.characterClassManager.IsAnyScp()) scpCount++;
				string warhead = Alpha.Detonated ? Cfg.T53 : Alpha.Active ? Cfg.T54 : Cfg.T55;
				Send.ChannelTopic(Cfg.T56.Replace("%players%", $"{cur}/{max}").Replace("%time%", $"{Round.ElapsedTime.Minutes}").Replace("%alive%", $"{aliveCount}").Replace("%scps%", $"{scpCount}").Replace("%alpha%", $"{warhead}").Replace("%ip%", $"{ServerConsole.Ip}:{Server.Port}"));
			}
			catch { }
		}
		public void SendingRA(SendingRAEvent ev)
		{
			try
			{
				#region logs
				if (ev.Player == null) return;
				if (ev.Player == Server.Host) return;
				if (ev.Player.UserId == "") return;
				if (ev.Player.Nickname == "Dedicated Server") return;
				if (Send.BlockInRaLogs(ev.Player.UserId)) return;
				string Args = ev.Command.ToLower().Replace($"{ev.Name} ", "");
				string msg = "";
				string d = Cfg.Delimiter;
				try
				{
					if (ev.Name == "forceclass")
					{
						string targets = "";
						RoleType role = RoleType.None;
						var role_id = 0;
						if (ev.Args.Count() > 1)
						{
							string[] spearator = { "." };
							string[] strlist = ev.Args[0].Split(spearator, 2, StringSplitOptions.RemoveEmptyEntries);
							foreach (string s in strlist)
							{
								try { targets += $"{s}{d}{Player.Get(int.Parse(s)).Nickname}{d} "; } catch { }
							}
							try { role_id = Convert.ToInt32(ev.Args[1]); } catch { }
							try { role = (RoleType)Convert.ToInt32(ev.Args[1]); } catch { }
						}
						else
						{
							try { role_id = Convert.ToInt32(ev.Args[0]); } catch { }
							try { role = (RoleType)Convert.ToInt32(ev.Args[0]); } catch { }
						}
						msg = $"{ev.Name} {targets} {role_id}{d}{role}{d} {Args.Replace(ev.Args[0], "").Replace($"{role_id}", "")}";
					}
					else if (ev.Name == "request_data")
					{
						string targets = "";
						string[] spearator = { "." };
						string[] strlist = ev.Args[1].Split(spearator, 2, StringSplitOptions.RemoveEmptyEntries);
						foreach (string s in strlist)
						{
							targets += $"{s}{d}{Player.Get(int.Parse(s))?.Nickname}{d} ";
						}
						msg = $"{ev.Name} {ev.Args[0]} {targets} {Args.Replace(ev.Args[0].ToLower(), "").Replace(ev.Args[1].ToLower(), "")}";
					}
					else if (ev.Name == "give")
					{
						string targets = "";
						ItemType item = ItemType.Coin;
						var item_id = 0;
						if (ev.Args.Count() > 1)
						{
							string[] spearator = { "." };
							string[] strlist = ev.Args[0].Split(spearator, 2, StringSplitOptions.RemoveEmptyEntries);
							foreach (string s in strlist)
							{
								try { targets += $"{s}{d}{Player.Get(int.Parse(s)).Nickname}{d} "; } catch { }
							}
							try { item = (ItemType)Convert.ToInt32(ev.Args[1]); } catch { }
							try { item_id = Convert.ToInt32(ev.Args[1]); } catch { }
						}
						else
						{
							try { item = (ItemType)Convert.ToInt32(ev.Args[0]); } catch { }
							try { item_id = Convert.ToInt32(ev.Args[0]); } catch { }
						}
						msg = $"{ev.Name} {targets} {item_id}{d}{item}{d} {Args.Replace(ev.Args[0], "").Replace($"{item_id}", "")}";
					}
					else if (ev.Name == "overwatch" || ev.Name == "bypass" || ev.Name == "heal" || ev.Name == "god" || ev.Name == "noclip" || ev.Name == "doortp" || ev.Name == "bring"
						|| ev.Name == "mute" || ev.Name == "unmute" || ev.Name == "imute" || ev.Name == "iunmute")
					{
						string targets = "";
						string[] spearator = { "." };
						string[] strlist = ev.Args[0].Split(spearator, 2, StringSplitOptions.RemoveEmptyEntries);
						foreach (string s in strlist)
						{
							try { targets += $"{s}{d}{Player.Get(int.Parse(s))?.Nickname}{d} "; } catch { }
						}
						msg = $"{ev.Name} {targets} {Args.Replace(ev.Args[0], "")}";
					}
					else if (ev.Name == "goto")
					{
						string target = $"{ev.Args[0]}{d}{Player.Get(int.Parse(ev.Args[0]))?.Nickname}{d} ";
						msg = $"{ev.Name} {target} {Args.Replace(ev.Args[0], "")}";
					}
					else
					{
						msg = $"{ev.Command}";
					}
				}
				catch
				{
					msg = $"{ev.Command}";
				}
				Send.Msg(Cfg.T57.Replace("%command%", Send.AntiMD(msg)).Replace("%player%", Api.PlayerInfo(ev.Player, false)));
				Send.RemoteAdmin(Cfg.T57.Replace("%command%", Send.AntiMD(msg)).Replace("%player%", Api.PlayerInfo(ev.Player, false)));
				#endregion
			}
			catch { }
		}
		public void Ban(BanEvent ev) => Send.BanKick(ev.Reason, Api.PlayerInfo(ev.Target, false), Send.AntiMD(ev.Issuer.Nickname), DateTime.Now.AddSeconds(ev.Duration).ToString("dd.MM.yyyy HH:mm"));
		public void Kick(KickEvent ev) => Send.BanKick(ev.Reason, Api.PlayerInfo(ev.Target, false), Send.AntiMD(ev.Issuer.Nickname), "kick");
	}
}