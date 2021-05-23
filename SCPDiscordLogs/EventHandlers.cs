using Scp914;
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
		public void Waiting() => Send.sendmsg(Cfg.T1);
		public void RoundStart() => Send.sendmsg(Cfg.T2.Replace("%players%", $"{Player.List.Count()}"));
		public void RoundEnd(RoundEndEvent ev) => Send.sendmsg(Cfg.T3.Replace("%players%", $"{Player.List.Count()}"));
		public void ItemChange(ItemChangeEvent ev) => Send.sendmsg(Cfg.T4.Replace("%player%", Send.PlayerInfo(ev.Player, false)).Replace("%olditem%", $"{ev.OldItem.id}").Replace("%newitem%", $"{ev.NewItem.id}"));
		public void Drop(DropItemEvent ev) => Send.sendmsg(Cfg.T5.Replace("%player%", Send.PlayerInfo(ev.Player)).Replace("%item%", $"{ev.Pickup.ItemId}"));
		public void Detonation() => Send.sendmsg(Cfg.T6);
		public void GeneratorActivate(GeneratorActivateEvent ev) => Send.sendmsg(Cfg.T7);
		public void Banned(BannedEvent ev) => Send.sendmsg(Cfg.T8.Replace("%player%", $"{ev.Details.OriginalName} - {ev.Details.Id}").Replace("%issuer%", ev.Details.Issuer).Replace("%reason%", ev.Details.Reason).Replace("%time%", $"{new DateTime(ev.Details.Expires).ToString("dd.MM.yyyy HH:mm")}"));
		public void ReportCheater(ReportCheaterEvent ev)
		{
			if (ev.Allowed) Send.sendmsg(Cfg.T9.Replace("%sender%", Send.PlayerInfo(ev.Sender, false)).Replace("%target%", Send.PlayerInfo(ev.Target, false)).Replace("%reason%", ev.Reason));
		}
		public void PortalCreate(PortalCreateEvent ev)
		{
			if (ev.Allowed) Send.sendmsg(Cfg.T10.Replace("%player%", Send.PlayerInfo(ev.Player, false)));
		}
		public void GetEXP(GetEXPEvent ev)
		{
			if (ev.Allowed) Send.sendmsg(Cfg.T11.Replace("%player%", Send.PlayerInfo(ev.Player, false)).Replace("%exp%", $"{ev.Amount}").Replace("%type%", $"{ev.Type}"));
		}
		public void GetLVL(GetLVLEvent ev)
		{
			if (ev.Allowed) Send.sendmsg(Cfg.T12.Replace("%player%", Send.PlayerInfo(ev.Player, false)).Replace("%lvl%", $"{ev.NewLevel}"));
		}
		public void RechargeWeapon(RechargeWeaponEvent ev)
		{
			if (ev.Allowed) Send.sendmsg(Cfg.T13.Replace("%player%", Send.PlayerInfo(ev.Player)).Replace("%weapon%", $"{ev.Player.CurrentItem.id}"));
		}
		public void InteractLocker(InteractLockerEvent ev)
		{
			if (ev.Allowed) Send.sendmsg(Cfg.T14.Replace("%player%", Send.PlayerInfo(ev.Player)));
		}
		public void TeslaTrigger(TeslaTriggerEvent ev)
		{
			if (ev.Triggerable) Send.sendmsg(Cfg.T15.Replace("%player%", Send.PlayerInfo(ev.Player)));
		}
		public void Activating(ActivatingEvent ev)
		{
			if (ev.Allowed) Send.sendmsg(Cfg.T16.Replace("%player%", Send.PlayerInfo(ev.Player)).Replace("%state%", $"{Scp914Machine.singleton.knobState}"));
		}
		public void ChangeKnob(ChangeKnobEvent ev)
		{
			if (ev.Allowed) Send.sendmsg(Cfg.T17.Replace("%player%", Send.PlayerInfo(ev.Player)).Replace("%setting%", $"{ev.KnobSetting}"));
		}
		public void PocketDimensionEnter(PocketDimensionEnterEvent ev)
		{
			if (ev.Allowed) Send.sendmsg(Cfg.T18.Replace("%player%", Send.PlayerInfo(ev.Player)));
		}
		public void PocketDimensionEscape(PocketDimensionEscapeEvent ev)
		{
			if (ev.Allowed) Send.sendmsg(Cfg.T19.Replace("%player%", Send.PlayerInfo(ev.Player)));
		}
		public void PortalUsing(PortalUsingEvent ev)
		{
			if (ev.Allowed) Send.sendmsg(Cfg.T20.Replace("%player%", Send.PlayerInfo(ev.Player, false)));
		}
		public void Femur(FemurBreakerEnterEvent ev)
		{
			if (ev.Allowed) Send.sendmsg(Cfg.T21.Replace("%player%", Send.PlayerInfo(ev.Player)));
		}
		public void Join(JoinEvent ev)
		{
			if (ev.Player.Nickname != "Dedicated Server") Send.sendmsg(Cfg.T22.Replace("%player%", Send.PlayerInfo(ev.Player, false)));
		}
		public void UnCuff(UnCuffEvent ev)
		{
			if (ev.Allowed) Send.sendmsg(Cfg.T23.Replace("%target%", Send.PlayerInfo(ev.Target)).Replace("%uncuffer%", Send.PlayerInfo(ev.Cuffer)));
		}
		public void Cuff(CuffEvent ev)
		{
			if (ev.Allowed) Send.sendmsg(Cfg.T24.Replace("%target%", Send.PlayerInfo(ev.Target)).Replace("%cuffer%", Send.PlayerInfo(ev.Cuffer)));
		}
		public void IcomSpeak(IcomSpeakEvent ev)
		{
			try { if (ev.Allowed) Send.sendmsg(Cfg.T25.Replace("%player%", Send.PlayerInfo(ev.Player))); } catch { }
		}
		public void Pickup(PickupItemEvent ev)
		{
			if (ev.Allowed) Send.sendmsg(Cfg.T26.Replace("%player%", Send.PlayerInfo(ev.Player)).Replace("%item%", $"{ev.Pickup.ItemId}"));
		}
		public void GroupChange(GroupChangeEvent ev)
		{
			if (ev.Allowed) try { Send.sendmsg(Cfg.T27.Replace("%player%", Send.PlayerInfo(ev.Player, false)).Replace("%group%", $"{ev.NewGroup.BadgeText} ({ev.NewGroup.BadgeColor})")); } catch { }
		}
		public void Decon(LCZDeconEvent ev)
		{
			if (ev.Allowed) Send.sendmsg(Cfg.T28);
		}
		public void AlphaStart(AlphaStartEvent ev)
		{
			if (ev.Allowed) Send.sendmsg(Cfg.T29.Replace("%time%", $"{Alpha.AlphaWarheadController.NetworktimeToDetonation}"));
		}
		public void AlphaStop(AlphaStopEvent ev)
		{
			if (ev.Allowed) Send.sendmsg(Cfg.T30.Replace("%player%", Send.PlayerInfo(ev.Player)));
		}
		public void EnableAlphaPanel(EnableAlphaPanelEvent ev)
		{
			if (ev.Allowed) Send.sendmsg(Cfg.T31.Replace("%player%", Send.PlayerInfo(ev.Player)));
		}
		public void InteractLift(InteractLiftEvent ev)
		{
			if (ev.Allowed) Send.sendmsg(Cfg.T32.Replace("%player%", Send.PlayerInfo(ev.Player)));
		}
		public void Contain(ContainEvent ev)
		{
			if (ev.Allowed) Send.sendmsg(Cfg.T33.Replace("%player%", Send.PlayerInfo(ev.Player)));
		}
		public void TeamRespawn(TeamRespawnEvent ev)
		{
			string msg = ev.NextKnownTeam == SpawnableTeamType.ChaosInsurgency ? $":spy: Chaos Insurgency" : $":cop: Nine-Tailed Fox";
			Send.sendmsg(Cfg.T34.Replace("%team%", msg).Replace("%players%", $"{ev.Players.Count}"));
		}
		public void Leave(LeaveEvent ev)
		{
			Send.sendmsg(Cfg.T35.Replace("%player%", Send.PlayerInfo(ev.Player, false)));
			Send.sendplayersinfo();
		}
		public void ThrowGrenade(ThrowGrenadeEvent ev)
		{
			if (ev.Player == null) return;
			if (ev.Allowed) Send.sendmsg(Cfg.T36.Replace("%player%", Send.PlayerInfo(ev.Player)));
		}
		public void MedicalUsed(MedicalUsedEvent ev)
		{
			if (ev.Player == null) return;
			Send.sendmsg(Cfg.T37.Replace("%player%", Send.PlayerInfo(ev.Player)).Replace("%item%", $"{ev.Item}"));
		}
		public void RoleChange(RoleChangeEvent ev)
		{
			if (ev.Player == null) return;
			if (ev.Escaped) Send.sendmsg(Cfg.T38.Replace("%player%", Send.PlayerInfo(ev.Player, false)).Replace("%role%", $"{ev.NewRole}"));
			else Send.sendmsg(Cfg.T39.Replace("%player%", Send.PlayerInfo(ev.Player, false)).Replace("%role%", $"{ev.NewRole}"));
		}
		public void SendingConsole(SendingConsoleEvent ev)
		{
			if (ev.Player == null || ev.Player == Server.Host) return;
			if (ev.Player?.Id == null) return;
			Send.sendmsg(Cfg.T40.Replace("%player%", Send.PlayerInfo(ev.Player)).Replace("%command%", $"{ev.Message}"));
		}
		public void Upgrade(UpgradeEvent ev)
		{
			string players = "";
			foreach (Player player in ev.Players) players += $"\n{Send.PlayerInfo(player)}";
			string items = "";
			foreach (Pickup item in ev.Items) items += $"\n{item.ItemId}";
			Send.sendmsg(Cfg.T41.Replace("%players%", players).Replace("%items%", items));
		}
		public void Damage(DamageEvent ev)
		{
			if (ev.Allowed)
			{
				if (ev.Attacker.Id == ev.Target.Id) return;
				if (ev.Attacker != null && ev.Target.Team == ev.Attacker.Team && ev.Target != ev.Attacker)
					Send.sendmsg(Cfg.T42.Replace("%tool%", $"{DamageTypes.FromIndex(ev.Tool).name}").Replace("%amount%", $"{ev.Amount}").Replace("%attacker%", Send.PlayerInfo(ev.Attacker)).Replace("%target%", Send.PlayerInfo(ev.Target)));
				else Send.sendmsg(Cfg.T43.Replace("%tool%", $"{DamageTypes.FromIndex(ev.Tool).name}").Replace("%amount%", $"{ev.Amount}").Replace("%attacker%", $"{ev.HitInformations.Attacker}").Replace("%target%", Send.PlayerInfo(ev.Target)));
			}
		}
		public void InteractGenerator(InteractGeneratorEvent ev)
		{
			if (ev.Allowed)
			{
				if (ev.Status == GeneratorStatus.TabletInjected) Send.sendmsg(Cfg.T44.Replace("%player%", Send.PlayerInfo(ev.Player)));
				else if (ev.Status == GeneratorStatus.OpenDoor) Send.sendmsg(Cfg.T45.Replace("%player%", Send.PlayerInfo(ev.Player)));
				else if (ev.Status == GeneratorStatus.Unlocked) Send.sendmsg(Cfg.T46.Replace("%player%", Send.PlayerInfo(ev.Player)));
				else if (ev.Status == GeneratorStatus.CloseDoor) Send.sendmsg(Cfg.T47.Replace("%player%", Send.PlayerInfo(ev.Player)));
				else if (ev.Status == GeneratorStatus.TabledEjected) Send.sendmsg(Cfg.T48.Replace("%player%", Send.PlayerInfo(ev.Player)));
			}
		}
		public void InteractDoor(InteractDoorEvent ev)
		{
			try
			{
				if (ev.Door.Name.Length < 2) return;
				if (ev.Allowed)
					Send.sendmsg(ev.Door.DoorVariant.NetworkTargetState
							? Cfg.T49.Replace("%player%", Send.PlayerInfo(ev.Player)).Replace("%door%", $"{ev.Door.Name}")
							: Cfg.T50.Replace("%player%", Send.PlayerInfo(ev.Player)).Replace("%door%", $"{ev.Door.Name}")
							);
			}
			catch { }
		}
		public void Dead(DeadEvent ev)
		{
			try
			{
				if (ev.Killer.Id == ev.Target.Id) return;
				if (ev.Killer != null && ev.Target.Team == ev.Killer.Team)
				{
					Send.sendtk(Cfg.T51.Replace("%killer%", Send.PlayerInfo(ev.Killer)).Replace("%target%", Send.PlayerInfo(ev.Target)).Replace("%tool%", DamageTypes.FromIndex(ev.HitInfo.Tool).name));
					Send.sendmsg(Cfg.T51.Replace("%killer%", Send.PlayerInfo(ev.Killer)).Replace("%target%", Send.PlayerInfo(ev.Target)).Replace("%tool%", DamageTypes.FromIndex(ev.HitInfo.Tool).name));
				}
				else Send.sendmsg(Cfg.T52.Replace("%killer%", Send.PlayerInfo(ev.Killer)).Replace("%target%", Send.PlayerInfo(ev.Target)).Replace("%tool%", DamageTypes.FromIndex(ev.HitInfo.Tool).name));
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
				Send.sendchanneltopic(Cfg.T56.Replace("%players%", $"{cur}/{max}").Replace("%time%", $"{Round.ElapsedTime.Minutes}").Replace("%alive%", $"{aliveCount}").Replace("%scps%", $"{scpCount}").Replace("%alpha%", $"{warhead}").Replace("%ip%", $"{ServerConsole.Ip}:{Server.Port}"));
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
				Send.sendmsg(Cfg.T57.Replace("%command%", msg).Replace("%player%", Send.PlayerInfo(ev.Player, false)));
				Send.sendra(Cfg.T57.Replace("%command%", msg).Replace("%player%", Send.PlayerInfo(ev.Player, false)));
				#endregion
			}
			catch { }
		}
		public void Ban(BanEvent ev) => Send.sendban(ev.Reason, Send.PlayerInfo(ev.Target, false), ev.Issuer.Nickname, DateTime.Now.AddSeconds(ev.Duration).ToString("dd.MM.yyyy HH:mm"));
		public void Kick(KickEvent ev) => Send.sendban(ev.Reason, ev.Target.Nickname, ev.Issuer.Nickname, "kick");
	}
}