using System;
using System.Linq;
using Respawning;
using Qurre;
using Qurre.API;
using Qurre.API.Events;
using Qurre.API.Objects;
using Qurre.API.Controllers;
using System.Collections.Generic;
namespace SCPDiscordLogs
{
	internal class EventHandlers
	{
		internal EventHandlers() => Log.Debug("[SCPDiscordLogs.EventHandlers] successfully initialized");
		internal void Waiting() => Send.Msg(Cfg.T1);
		internal void RoundStart() => Send.Msg(Cfg.T2.Replace("%players%", $"{Player.List.Count()}"));
		internal void RoundEnd(RoundEndEvent _) => Send.Msg(Cfg.T3.Replace("%players%", $"{Player.List.Count()}"));
		internal void Drop(DropItemEvent ev) => Send.Msg(Cfg.T5.Replace("%player%", Api.PlayerInfo(ev.Player)).Replace("%item%", $"{ev.Item.Type}"));
		internal void Detonation() => Send.Msg(Cfg.T6);
		internal void GeneratorActivate(GeneratorActivateEvent _) => Send.Msg(Cfg.T7);
		internal void Banned(BannedEvent ev) => Send.Msg(Cfg.T8.Replace("%player%", $"{ev.Details.OriginalName} - {ev.Details.Id}")
			.Replace("%issuer%", ev.Details.Issuer).Replace("%reason%", ev.Details.Reason).Replace("%time%", $"{new DateTime(ev.Details.Expires):dd.MM.yyyy HH:mm}"));
		internal void ItemChange(ItemChangeEvent ev)
		{
			try { Send.Msg(Cfg.T4.Replace("%player%", Api.PlayerInfo(ev.Player)).Replace("%olditem%", $"{(ev.OldItem == null ? "None" : ev.OldItem.Type)}").Replace("%newitem%", $"{(ev.NewItem == null ? "None" : ev.NewItem.Type)}")); } catch { }
		}
		internal void ThrowItem(ThrowItemEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T36.Replace("%player%", Api.PlayerInfo(ev.Player)).Replace("%item%", $"{ev.Item.Type}"));
		}
		internal void ReportCheater(ReportCheaterEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T9.Replace("%sender%", Api.PlayerInfo(ev.Sender, false)).Replace("%target%", Api.PlayerInfo(ev.Target, false)).Replace("%reason%", ev.Reason));
		}
		internal void PortalCreate(PortalCreateEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T10.Replace("%player%", Api.PlayerInfo(ev.Player, false)));
		}
		internal void GetEXP(GetEXPEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T11.Replace("%player%", Api.PlayerInfo(ev.Player, false)).Replace("%exp%", $"{ev.Amount}").Replace("%type%", $"{ev.Type}"));
		}
		internal void GetLVL(GetLVLEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T12.Replace("%player%", Api.PlayerInfo(ev.Player, false)).Replace("%lvl%", $"{ev.NewLevel}"));
		}
		internal void RechargeWeapon(RechargeWeaponEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T13.Replace("%player%", Api.PlayerInfo(ev.Player)).Replace("%weapon%", $"{ev.Player.CurrentItem.TypeId}"));
		}
		internal void InteractLocker(InteractLockerEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T14.Replace("%player%", Api.PlayerInfo(ev.Player)).Replace("%locker%", ev.Locker.Name));
		}
		internal void TeslaTrigger(TeslaTriggerEvent ev)
		{
			if (ev.Triggerable) Send.Msg(Cfg.T15.Replace("%player%", Api.PlayerInfo(ev.Player)));
		}
		internal void Activating(ActivatingEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T16.Replace("%player%", Api.PlayerInfo(ev.Player)).Replace("%state%", $"{Qurre.API.Controllers.Scp914.KnobState}"));
		}
		internal void KnobChange(KnobChangeEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T17.Replace("%player%", Api.PlayerInfo(ev.Player)).Replace("%setting%", $"{ev.Setting}"));
		}
		internal void PocketEnter(PocketEnterEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T18.Replace("%player%", Api.PlayerInfo(ev.Player)));
		}
		internal void PocketEscape(PocketEscapeEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T19.Replace("%player%", Api.PlayerInfo(ev.Player)));
		}
		internal void PortalUsing(PortalUsingEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T20.Replace("%player%", Api.PlayerInfo(ev.Player, false)));
		}
		internal void Femur(FemurBreakerEnterEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T21.Replace("%player%", Api.PlayerInfo(ev.Player)));
		}
		internal void Join(JoinEvent ev)
		{
			if (ev.Player.Nickname != "Dedicated Server") Send.Msg(Cfg.T22.Replace("%player%", Api.PlayerInfo(ev.Player, false)));
		}
		internal void UnCuff(UnCuffEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T23.Replace("%target%", Api.PlayerInfo(ev.Target)).Replace("%uncuffer%", Api.PlayerInfo(ev.Cuffer)));
		}
		internal void Cuff(CuffEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T24.Replace("%target%", Api.PlayerInfo(ev.Target)).Replace("%cuffer%", Api.PlayerInfo(ev.Cuffer)));
		}
		internal void Pickup(PickupItemEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T26.Replace("%player%", Api.PlayerInfo(ev.Player)).Replace("%item%", $"{ev.Pickup.Type}"));
		}
		internal void GroupChange(GroupChangeEvent ev)
		{
			if (ev.Allowed) try { Send.Msg(Cfg.T27.Replace("%player%", Api.PlayerInfo(ev.Player, false)).Replace("%group%", $"{ev.NewGroup.BadgeText} ({ev.NewGroup.BadgeColor})")); } catch { }
		}
		internal void Decon(LczDeconEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T28);
		}
		internal void AlphaStart(AlphaStartEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T29.Replace("%time%", $"{Alpha.AlphaWarheadController.NetworktimeToDetonation}"));
		}
		internal void AlphaStop(AlphaStopEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T30.Replace("%player%", Api.PlayerInfo(ev.Player)));
		}
		internal void EnableAlphaPanel(EnableAlphaPanelEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T31.Replace("%player%", Api.PlayerInfo(ev.Player)));
		}
		internal void InteractLift(InteractLiftEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T32.Replace("%player%", Api.PlayerInfo(ev.Player)).Replace("%lift%", ev.Lift.Name));
		}
		internal void Contain(ContainEvent ev)
		{
			if (ev.Allowed) Send.Msg(Cfg.T33.Replace("%player%", Api.PlayerInfo(ev.Player)));
		}
		internal void Explosion(FlashExplosionEvent ev)
		{
			if (ev.Allowed) Send.Msg(Plugin.Translate.FlashExplosion.Replace("%player%", Api.PlayerInfo(ev.Thrower)));
		}
		internal void Explosion(FragExplosionEvent ev)
		{
			if (ev.Allowed) Send.Msg(Plugin.Translate.FragExplosion.Replace("%player%", Api.PlayerInfo(ev.Thrower)));
		}
		internal void Flash(FlashedEvent ev)
		{
			if (ev.Allowed) Send.Msg(Plugin.Translate.Flashed.Replace("%thrower%", Api.PlayerInfo(ev.Thrower)).Replace("%target%", Api.PlayerInfo(ev.Target)));
		}
		internal void Scp330(InteractScp330Event ev)
		{
			if (ev.Allowed) Send.Msg(Plugin.Translate.Scp330Interact.Replace("%player%", Api.PlayerInfo(ev.Player)));
		}
		internal void Scp330(EatingScp330Event ev)
		{
			if (ev.Allowed) Send.Msg(Plugin.Translate.Scp330Eat.Replace("%player%", Api.PlayerInfo(ev.Player)).Replace("%candy%", $"{ev.Candy}"));
		}
		internal void TeamRespawn(TeamRespawnEvent ev)
		{
			string msg = ev.NextKnownTeam == SpawnableTeamType.ChaosInsurgency ? $":spy: Chaos Insurgency" : $":cop: Nine-Tailed Fox";
			Send.Msg(Cfg.T34.Replace("%team%", msg).Replace("%players%", $"{ev.Players.Count}"));
		}
		internal void Leave(LeaveEvent ev)
		{
			Send.Msg(Cfg.T35.Replace("%player%", Api.PlayerInfo(ev.Player, false)));
			Send.PlayersInfo();
		}
		internal void ItemUsed(ItemUsedEvent ev)
		{
			if (ev.Player == null) return;
			Send.Msg(Cfg.T37.Replace("%player%", Api.PlayerInfo(ev.Player)).Replace("%item%", $"{ev.Item.TypeId}"));
		}
		internal void RoleChange(RoleChangeEvent ev)
		{
			if (ev.Player == null) return;
			Send.Msg(Cfg.T39.Replace("%player%", Api.PlayerInfo(ev.Player, false)).Replace("%role%", $"{ev.NewRole}"));
		}
		internal void Escape(EscapeEvent ev)
		{
			Send.Msg(Cfg.T38.Replace("%player%", Api.PlayerInfo(ev.Player, false)).Replace("%role%", $"{ev.NewRole}"));
		}
		internal void SendingConsole(SendingConsoleEvent ev)
		{
			if (ev.Player == null || ev.Player == Server.Host) return;
			Send.Msg(Cfg.T40.Replace("%player%", Api.PlayerInfo(ev.Player)).Replace("%command%", $"{Send.AntiMD(ev.Message)}"));
		}
		internal void Heal(HealEvent ev)
		{
			if (!ev.Allowed) return;
			double hp = Math.Round(ev.Hp);
			if (1 >= hp) return;
			Send.Msg(Plugin.Translate.Heal.Replace("%player%", Api.PlayerInfo(ev.Player)).Replace("%amout%", $"{hp}"));
		}
		internal void Upgrade(UpgradeEvent ev)
		{
			string players = "";
			foreach (Player player in ev.Players) players += $"\n{Api.PlayerInfo(player)}";
			string items = "";
			foreach (var item in ev.Items) items += $"\n{item.Info.ItemId}";
			Send.Msg(Cfg.T41.Replace("%players%", players).Replace("%items%", items));
		}
		internal void Damage(DamageEvent ev)
		{
			if (ev.Allowed)
			{
				if (ev.Attacker.Id == ev.Target.Id) return;
				if (ev.Attacker != null && Ally(ev.Attacker, ev.Target) && ev.Target != ev.Attacker)
					Send.Msg(Cfg.T42.Replace("%tool%", $"{ev.DamageType}").Replace("%amount%", $"{Math.Round(ev.Amount)}").Replace("%attacker%", Api.PlayerInfo(ev.Attacker)).Replace("%target%", Api.PlayerInfo(ev.Target)));
				else Send.Msg(Cfg.T43.Replace("%tool%", $"{ev.DamageType}").Replace("%amount%", $"{Math.Round(ev.Amount)}").Replace("%attacker%", Api.PlayerInfo(ev.Attacker)).Replace("%target%", Api.PlayerInfo(ev.Target)));
			}
		}
		internal void InteractGenerator(InteractGeneratorEvent ev)
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
		internal void LczAnnounce(LczAnnounceEvent ev)
		{
			if (!ev.Allowed) return;
			int mins;
			if (ev.Id == 0) mins = 15;
			else if (ev.Id == 1) mins = 10;
			else if (ev.Id == 2) mins = 5;
			else if (ev.Id == 3) mins = 1;
			else if (ev.Id == 4) mins = (int)0.5;
			else return;
			Send.Msg(Plugin.Translate.LczAnnounce.Replace("%minutes%", $"{mins}"));
		}
		internal void InteractDoor(InteractDoorEvent ev)
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
		internal static Dictionary<Player, RoleType> Cached = new();
		internal void Dies(DiesEvent ev)
		{
			if (Cached.ContainsKey(ev.Target)) Cached.Remove(ev.Target);
			Cached.Add(ev.Target, ev.Target.Role);
		}
		internal void Dead(DeadEvent ev)
		{
			try
			{
				if (ev.Killer.Id == ev.Target.Id) return;
				if (ev.Killer != null && Ally(ev.Killer, ev.Target))
				{
					Send.TeamKill(Cfg.T51.Replace("%killer%", Api.PlayerInfo(ev.Killer)).Replace("%target%", Api.PlayerInfo(ev.Target)).Replace("%tool%", $"{ev.DamageType}"));
					Send.Msg(Cfg.T51.Replace("%killer%", Api.PlayerInfo(ev.Killer)).Replace("%target%", Api.PlayerInfo(ev.Target)).Replace("%tool%", $"{ev.DamageType}"));
				}
				else Send.Msg(Cfg.T52.Replace("%killer%", Api.PlayerInfo(ev.Killer)).Replace("%target%", Api.PlayerInfo(ev.Target)).Replace("%tool%", $"{ev.DamageType}"));
			}
			catch { }
		}
		internal bool Ally(Player pl, Player target)
		{
			var targetTeam = target.Team;
			if (Cached.TryGetValue(target, out var role)) targetTeam = role.GetTeam();
			if (targetTeam == pl.Team) return true;
			if (targetTeam == Team.SCP && pl.Team == Team.SCP) return true;
			if ((targetTeam == Team.MTF || targetTeam == Team.RSC) && (pl.Team == Team.MTF || pl.Team == Team.RSC)) return true;
			if ((targetTeam == Team.CHI || targetTeam == Team.CDP) && (pl.Team == Team.CHI || pl.Team == Team.CDP)) return true;
			return false;
		}
		internal static void UpdateServerStatus()
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
		internal void SendingRA(SendingRAEvent ev)
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
		internal void Ban(BannedEvent ev) => Send.BanKick(ev.Details.Reason, Api.PlayerInfo(ev.Player, false), Send.AntiMD(ev.Details.Issuer), new DateTime(ev.Details.Expires).AddHours((DateTime.Now - DateTime.UtcNow).TotalHours).ToString("dd.MM.yyyy HH:mm"));
		internal void Kick(KickEvent ev) => Send.BanKick(ev.Reason, Api.PlayerInfo(ev.Target, false), Send.AntiMD(ev.Issuer.Nickname), "kick");
	}
}