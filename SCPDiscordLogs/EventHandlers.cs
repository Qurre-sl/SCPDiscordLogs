using Qurre.API;
using Qurre.API.Attributes;
using Qurre.API.Objects;
using Qurre.Events;
using Qurre.Events.Structs;
using Qurre.API.Controllers;
using System;
using System.Linq;
using System.Collections.Generic;
using PlayerRoles;

#pragma warning disable IDE0051
namespace SCPDiscordLogs
{
	static class EventHandlers
	{
		static internal readonly Dictionary<Player, RoleTypeId> Cached = new();

		#region Round
		[EventMethod(RoundEvents.Waiting, int.MinValue)]
        static void Waiting()
        {
			Cached.Clear();
			Send.Msg(Cfg.Translate.Waiting);
		}

		[EventMethod(RoundEvents.Start, int.MinValue)]
		static void RoundStart() => Send.Msg(Cfg.Translate.RoundStart.Replace("%players%", $"{Player.List.Count()}"));

		[EventMethod(RoundEvents.End, int.MinValue)]
		static void RoundEnd() => Send.Msg(Cfg.Translate.RoundEnd.Replace("%players%", $"{Player.List.Count()}"));
		#endregion

		#region Alpha
		[EventMethod(AlphaEvents.Detonate, int.MinValue)]
		static void Detonate() => Send.Msg(Cfg.Translate.AlphaDetonation);

		[EventMethod(AlphaEvents.Start, int.MinValue)]
		static void AlphaStart(AlphaStartEvent ev)
		{
			if (!ev.Allowed)
				return;

			Send.Msg(Cfg.Translate.AlphaStart.Replace("%time%", $"{Alpha.TimeToDetonation}"));
		}

		[EventMethod(AlphaEvents.Stop, int.MinValue)]
		static void AlphaStop(AlphaStopEvent ev)
		{
			if (!ev.Allowed)
				return;

			if (Send.GLobalBypass(ev.Player.UserInformation.UserId))
				return;

			Send.Msg(Cfg.Translate.AlphaStop.Replace("%player%", Api.PlayerInfo(ev.Player)));
		}

		[EventMethod(AlphaEvents.UnlockPanel, int.MinValue)]
		static void UnlockAlphaPanel(UnlockPanelEvent ev)
		{
			if (!ev.Allowed)
				return;

			if (Send.GLobalBypass(ev.Player.UserInformation.UserId))
				return;

			Send.Msg(Cfg.Translate.AlphaPanel.Replace("%player%", Api.PlayerInfo(ev.Player)));
		}
		#endregion

		#region Player
		[EventMethod(PlayerEvents.DropItem, int.MinValue)]
		static void DropItem(DropItemEvent ev)
		{
			if (Send.GLobalBypass(ev.Player.UserInformation.UserId))
				return;

			Send.Msg(Cfg.Translate.DropItem
			.Replace("%player%", Api.PlayerInfo(ev.Player))
			.Replace("%item%", $"{ev.Item.Type}"));
		}

		[EventMethod(PlayerEvents.ChangeItem, int.MinValue)]
		static void ItemChange(ChangeItemEvent ev)
		{
			if (Send.GLobalBypass(ev.Player.UserInformation.UserId))
				return;

			Send.Msg(Cfg.Translate.ChangeItem
				.Replace("%player%", Api.PlayerInfo(ev.Player))
				.Replace("%olditem%", $"{(ev.OldItem is null ? "None" : ev.OldItem.Type)}")
				.Replace("%newitem%", $"{(ev.NewItem is null ? "None" : ev.NewItem.Type)}")
			);
		}

		[EventMethod(PlayerEvents.ThrowProjectile, int.MinValue)]
		static void ThrowItem(ThrowProjectileEvent ev)
		{
			if (!ev.Allowed)
				return;

			if (Send.GLobalBypass(ev.Player.UserInformation.UserId))
				return;

			Send.Msg(Cfg.Translate.ThrowItem
				.Replace("%player%", Api.PlayerInfo(ev.Player))
				.Replace("%item%", $"{ev.Item.Type}")
			);
		}

		[EventMethod(PlayerEvents.InteractGenerator, int.MinValue)]
		static void InteractGenerator(InteractGeneratorEvent ev)
		{
			if (!ev.Allowed)
				return;

			if (Send.GLobalBypass(ev.Player.UserInformation.UserId))
				return;

			switch (ev.Status)
			{
				case GeneratorStatus.Activate:
					Send.Msg(Cfg.Translate.GeneratorInject.Replace("%player%", Api.PlayerInfo(ev.Player)));
					break;

				case GeneratorStatus.Deactivate:
					Send.Msg(Cfg.Translate.GeneratorEjected.Replace("%player%", Api.PlayerInfo(ev.Player)));
					break;

				case GeneratorStatus.Unlock:
					Send.Msg(Cfg.Translate.GeneratorUnlock.Replace("%player%", Api.PlayerInfo(ev.Player)));
					break;

				case GeneratorStatus.OpenDoor:
					Send.Msg(Cfg.Translate.GeneratorOpen.Replace("%player%", Api.PlayerInfo(ev.Player)));
					break;

				case GeneratorStatus.CloseDoor:
					Send.Msg(Cfg.Translate.GeneratorClose.Replace("%player%", Api.PlayerInfo(ev.Player)));
					break;
			}
		}

		[EventMethod(PlayerEvents.InteractDoor, int.MinValue)]
		static void InteractDoor(InteractDoorEvent ev)
		{
			if (!ev.Allowed)
				return;

			if (ev.Door.Name.Length < 2)
				return;

			if (Send.GLobalBypass(ev.Player.UserInformation.UserId))
				return;

			Send.Msg(ev.Door.DoorVariant.NetworkTargetState
					? Cfg.Translate.InteractDoorClose
						.Replace("%player%", Api.PlayerInfo(ev.Player))
						.Replace("%door%", $"{ev.Door.Name}")

					: Cfg.Translate.InteractDoorOpen
						.Replace("%player%", Api.PlayerInfo(ev.Player))
						.Replace("%door%", $"{ev.Door.Name}")
					);
		}

		[EventMethod(PlayerEvents.InteractLocker, int.MinValue)]
		static void InteractLocker(InteractLockerEvent ev)
		{
			if (!ev.Allowed)
				return;

			if (Send.GLobalBypass(ev.Player.UserInformation.UserId))
				return;

			Send.Msg(Cfg.Translate.InteractLocker
				.Replace("%player%", Api.PlayerInfo(ev.Player))
				.Replace("%locker%", ev.Locker.Name)
			);
		}

		[EventMethod(PlayerEvents.InteractLift, int.MinValue)]
		static void InteractLift(InteractLiftEvent ev)
		{
			if (!ev.Allowed)
				return;

			if (Send.GLobalBypass(ev.Player.UserInformation.UserId))
				return;

			Send.Msg(Cfg.Translate.InteractLift
				.Replace("%player%", Api.PlayerInfo(ev.Player))
				.Replace("%lift%", ev.Lift.GameObject.name)
			);
		}

		[EventMethod(PlayerEvents.InteractScp330, int.MinValue)]
		static void Scp330(InteractScp330Event ev)
		{
			if (!ev.Allowed)
				return;

			if (Send.GLobalBypass(ev.Player.UserInformation.UserId))
				return;

			Send.Msg(Cfg.Translate.Scp330Interact.Replace("%player%", Api.PlayerInfo(ev.Player)));
		}

		[EventMethod(PlayerEvents.Join, int.MinValue)]
		static void Join(JoinEvent ev)
		{
			if (Send.GLobalBypass(ev.Player.UserInformation.UserId))
				return;

			Send.Msg(Cfg.Translate.Join.Replace("%player%", Api.PlayerInfo(ev.Player, false)));
		}

		[EventMethod(PlayerEvents.Leave, int.MinValue)]
		static void Leave(LeaveEvent ev)
		{
			if (Send.GLobalBypass(ev.Player.UserInformation.UserId))
				return;

			Send.Msg(Cfg.Translate.Leave.Replace("%player%", Api.PlayerInfo(ev.Player, false)));
			Send.PlayersInfo();
		}

		[EventMethod(PlayerEvents.UnCuff, int.MinValue)]
		static void UnCuff(UnCuffEvent ev)
		{
			if (!ev.Allowed)
				return;

			if (Send.GLobalBypass(ev.Target.UserInformation.UserId) ||
				Send.GLobalBypass(ev.Cuffer.UserInformation.UserId))
				return;

			Send.Msg(Cfg.Translate.UnCuff
				.Replace("%target%", Api.PlayerInfo(ev.Target))
				.Replace("%uncuffer%", Api.PlayerInfo(ev.Cuffer))
			);
		}

		[EventMethod(PlayerEvents.Cuff, int.MinValue)]
		static void Cuff(CuffEvent ev)
		{
			if (!ev.Allowed)
				return;

			if (Send.GLobalBypass(ev.Target.UserInformation.UserId) ||
				Send.GLobalBypass(ev.Cuffer.UserInformation.UserId))
				return;

			Send.Msg(Cfg.Translate.Cuff
				.Replace("%target%", Api.PlayerInfo(ev.Target))
				.Replace("%cuffer%", Api.PlayerInfo(ev.Cuffer))
			);
		}

		[EventMethod(PlayerEvents.PickupItem, int.MinValue)]
		static void Pickup(PickupItemEvent ev)
		{
			if (!ev.Allowed)
				return;

			if (Send.GLobalBypass(ev.Player.UserInformation.UserId))
				return;

			Send.Msg(Cfg.Translate.PickupItem
				.Replace("%player%", Api.PlayerInfo(ev.Player))
				.Replace("%item%", $"{ev.Pickup.Type}")
			);
		}

		[EventMethod(PlayerEvents.PickupArmor, int.MinValue)]
		static void Pickup(PickupArmorEvent ev)
		{
			if (!ev.Allowed)
				return;

			if (Send.GLobalBypass(ev.Player.UserInformation.UserId))
				return;

			Send.Msg(Cfg.Translate.PickupItem
				.Replace("%player%", Api.PlayerInfo(ev.Player))
				.Replace("%item%", $"{ev.Pickup.Type}")
			);
		}

		[EventMethod(PlayerEvents.UsedItem, int.MinValue)]
		static void UsedItem(UsedItemEvent ev)
		{
			if (ev.Item is null)
				return;

			if (Send.GLobalBypass(ev.Player.UserInformation.UserId))
				return;

			Send.Msg(Cfg.Translate.UseItem
				.Replace("%player%", Api.PlayerInfo(ev.Player))
				.Replace("%item%", $"{ev.Item.Type}")
			);
		}

		[EventMethod(EffectEvents.Flashed, int.MinValue)]
		static void Flash(PlayerFlashedEvent ev)
		{
			if (!ev.Allowed)
				return;

			if (Send.GLobalBypass(ev.Thrower.UserInformation.UserId) ||
                Send.GLobalBypass(ev.Player.UserInformation.UserId))
				return;

			Send.Msg(Cfg.Translate.Flashed
				.Replace("%thrower%", Api.PlayerInfo(ev.Thrower))
				.Replace("%target%", Api.PlayerInfo(ev.Player))
			);
		}

		[EventMethod(PlayerEvents.ChangeGroup, int.MinValue)]
		static void ChangeGroup(ChangeGroupEvent ev)
		{
			if (!ev.Allowed)
				return;

			if (ev.Group is null)
				return;

			if (ev.Player is null)
				return;

			if (Send.GLobalBypass(ev.Player.UserInformation.UserId))
				return;

			Send.Msg(Cfg.Translate.AdminRoleChange
				.Replace("%player%", Api.PlayerInfo(ev.Player, false))
				.Replace("%group%", $"{ev.Group.BadgeText} ({ev.Group.BadgeColor})")
			);
		}

		[EventMethod(PlayerEvents.ChangeRole, int.MinValue)]
		static void ChangeRole(ChangeRoleEvent ev)
		{
			if (!ev.Allowed)
				return;

			if (Send.GLobalBypass(ev.Player.UserInformation.UserId))
				return;

			Send.Msg(Cfg.Translate.Spawn
				.Replace("%player%", Api.PlayerInfo(ev.Player, false))
				.Replace("%role%", $"{ev.Role}")
			);
		}

		[EventMethod(PlayerEvents.Escape, int.MinValue)]
		static void Escape(EscapeEvent ev)
		{
			if (!ev.Allowed)
				return;

			if (Send.GLobalBypass(ev.Player.UserInformation.UserId))
				return;

			Send.Msg(Cfg.Translate.Escape
				.Replace("%player%", Api.PlayerInfo(ev.Player, false))
				.Replace("%role%", $"{ev.Role}")
			);
		}

		[EventMethod(PlayerEvents.Damage, int.MinValue)]
		static void Damage(DamageEvent ev)
		{
			if (!ev.Allowed)
				return;

			if (ev.Attacker.UserInformation.Id == ev.Target.UserInformation.Id)
				return;

			if (Send.GLobalBypass(ev.Attacker.UserInformation.UserId) ||
				Send.GLobalBypass(ev.Target.UserInformation.UserId))
				return;

			if (Ally(ev.Attacker, ev.Target))
				Send.Msg(Cfg.Translate.TeamDamage
					.Replace("%tool%", $"{ev.DamageType}")
					.Replace("%amount%", $"{Math.Round(ev.Damage)}")
					.Replace("%attacker%", Api.PlayerInfo(ev.Attacker))
					.Replace("%target%", Api.PlayerInfo(ev.Target)));
			else
				Send.Msg(Cfg.Translate.Damage
					.Replace("%tool%", $"{ev.DamageType}")
					.Replace("%amount%", $"{Math.Round(ev.Damage)}")
					.Replace("%attacker%", Api.PlayerInfo(ev.Attacker))
					.Replace("%target%", Api.PlayerInfo(ev.Target)));
		}

		[EventMethod(PlayerEvents.Dies, int.MinValue)]
		static void Dies(DiesEvent ev)
		{
			if (Cached.ContainsKey(ev.Target))
				Cached.Remove(ev.Target);

			Cached.Add(ev.Target, ev.Target.RoleInformation.Role);
		}

		[EventMethod(PlayerEvents.Dead, int.MinValue)]
		static void Dead(DeadEvent ev)
		{
			if (ev.Attacker is null || ev.Target is null)
				return;

			if (ev.Attacker.UserInformation.Id == ev.Target.UserInformation.Id)
				return;

			if (Send.GLobalBypass(ev.Attacker.UserInformation.UserId) ||
				Send.GLobalBypass(ev.Target.UserInformation.UserId))
				return;

			if (!Ally(ev.Attacker, ev.Target))
			{
				Send.Msg(Cfg.Translate.Kill
					.Replace("%killer%", Api.PlayerInfo(ev.Attacker))
					.Replace("%target%", Api.PlayerInfo(ev.Target))
					.Replace("%tool%", $"{ev.DamageType}"));
				return;
			}

			string message = Cfg.Translate.TeamKill
				.Replace("%killer%", Api.PlayerInfo(ev.Attacker))
				.Replace("%target%", Api.PlayerInfo(ev.Target))
				.Replace("%tool%", $"{ev.DamageType}");

			Send.Msg(message);
			if (!Round.Ended)
				Send.TeamKill(message);
		}
		#endregion

		#region SCPs
		[EventMethod(ScpEvents.ActivateGenerator, int.MinValue)]
		static void ActivateGenerator()
			=> Send.Msg(Cfg.Translate.GeneratorActivate);

		[EventMethod(ScpEvents.Scp079GetExp, int.MinValue)]
		static void GetEXP(Scp079GetExpEvent ev)
		{
			if (!ev.Allowed)
				return;

			if (Send.GLobalBypass(ev.Player.UserInformation.UserId))
				return;

			Send.Msg(Cfg.Translate.GetXp079
				.Replace("%player%", Api.PlayerInfo(ev.Player, false))
				.Replace("%exp%", $"{ev.Amount}")
				.Replace("%type%", $"{ev.Type}")
				);
		}

		[EventMethod(ScpEvents.Scp079NewLvl, int.MinValue)]
		static void NewLvl(Scp079NewLvlEvent ev)
		{
			if (!ev.Allowed)
				return;

			if (Send.GLobalBypass(ev.Player.UserInformation.UserId))
				return;

			Send.Msg(Cfg.Translate.GetLvl079
				.Replace("%player%", Api.PlayerInfo(ev.Player, false))
				.Replace("%lvl%", $"{ev.Level}")
				);
		}
		#endregion

		#region Administration
		[EventMethod(PlayerEvents.Banned, int.MinValue)]
		static void Banned(BannedEvent ev)
			=> Send.Msg(Cfg.Translate.Banned.Replace("%player%", $"{ev.Details.OriginalName} - {ev.Details.Id}")
			.Replace("%issuer%", ev.Details.Issuer)
				.Replace("%reason%", ev.Details.Reason)
				.Replace("%time%", $"{new DateTime(ev.Details.Expires):dd.MM.yyyy HH:mm}"));

		[EventMethod(PlayerEvents.Banned, int.MinValue)]
		static void Ban(BannedEvent ev)
		{
			if (ev.Type == BanHandler.BanType.IP)
				return;

			Send.BanKick(ev.Details.Reason, Api.PlayerInfo(ev.Player, false), Api.AntiMD(ev.Details.Issuer),
				$"<t:{new DateTimeOffset(new DateTime(ev.Details.Expires).AddHours((DateTime.Now - DateTime.UtcNow).TotalHours)).ToUnixTimeSeconds()}:f>");
		}

		[EventMethod(PlayerEvents.Kick, int.MinValue)]
		static void Kick(KickEvent ev)
		{
			if (!ev.Allowed)
				return;

			Send.BanKick(ev.Reason, Api.PlayerInfo(ev.Player, false), Api.AntiMD(ev.Issuer.UserInformation.Nickname), "kick");
		}
		#endregion

		#region Server
		[EventMethod(ServerEvents.CheaterReport, int.MinValue)]
		static void ReportCheater(CheaterReportEvent ev)
		{
			if (!ev.Allowed)
				return;

			Send.Msg(Cfg.Translate.ReportCheater
				.Replace("%sender%", Api.PlayerInfo(ev.Issuer, false))
				.Replace("%target%", Api.PlayerInfo(ev.Target, false))
				.Replace("%reason%", ev.Reason));
		}

		[EventMethod(ServerEvents.GameConsoleCommand, int.MinValue)]
		static void SendingConsole(GameConsoleCommandEvent ev)
		{
			if (ev.Player is null || ev.Player == Server.Host)
				return;

			if (Send.GLobalBypass(ev.Player.UserInformation.UserId))
				return;

			Send.Msg(Cfg.Translate.Console
				.Replace("%player%", Api.PlayerInfo(ev.Player))
				.Replace("%command%", $"{Api.AntiMD(ev.Command)}")
			);
		}

		[EventMethod(ServerEvents.RemoteAdminCommand, int.MinValue)]
		static void RemoteAdminCommand(RemoteAdminCommandEvent ev)
		{
			try
			{
				#region logs
				if (ev.Name.StartsWith("$"))
					return;
				if (ev.Player == null)
					return;
				if (ev.Player == Server.Host)
					return;
				if (ev.Player.UserInformation.UserId == "")
					return;
				if (ev.Player.UserInformation.Nickname == "Dedicated Server")
					return;
				if (Send.GLobalBypass(ev.Player.UserInformation.UserId))
					return;
				if (Send.BlockInRaLogs(ev.Player.UserInformation.UserId))
					return;

				string Args = string.Join(" ", ev.Args);
				string msg = "";
				string d = Cfg.Delimiter;

				try
				{
					switch (ev.Name)
					{
						case "forceclass":
							{
								string targets = "";

								string role = ev.Args.Length > 1 ? ev.Args[1] : ev.Args[0];
								if (ev.Args.Count() > 1)
								{
									string[] spearator = { "." };
									string[] strlist = ev.Args[0].Split(spearator, 2, StringSplitOptions.RemoveEmptyEntries);
									foreach (string s in strlist)
									{
										try { targets += $"{s}{d}{int.Parse(s).GetPlayer()?.UserInformation.Nickname}{d} "; } catch { }
									}
								}
								msg = $"{ev.Name} {targets} {role} {Args.Replace(ev.Args[0], "").Replace($"{role}", "")}";
								break;
							}
						case "request_data":
							{
								string targets = "";
								string[] spearator = { "." };
								string[] strlist = ev.Args[1].Split(spearator, 2, StringSplitOptions.RemoveEmptyEntries);
								foreach (string s in strlist)
								{
									targets += $"{s}{d}{int.Parse(s).GetPlayer()?.UserInformation.Nickname}{d} ";
								}
								msg = $"{ev.Name} {ev.Args[0]} {targets} {Args.Replace(ev.Args[0].ToLower(), "").Replace(ev.Args[1].ToLower(), "")}";
								break;
							}
						case "give":
							{
								string targets = "";
								string itemsstr = "";
								string itemsoriginal = "";

								if (ev.Args.Count() > 1)
								{
									string[] spearator = { "." };
									string[] strlist = ev.Args[0].Split(spearator, 2, StringSplitOptions.RemoveEmptyEntries);
									foreach (string s in strlist)
									{
										try { targets += $"{s}{d}{int.Parse(s).GetPlayer()?.UserInformation.Nickname}{d} "; } catch { }
									}

									string[] items = ev.Args[1].Split(spearator, 2, StringSplitOptions.RemoveEmptyEntries);
									foreach (string s in items)
									{
										try { itemsstr += $"{s}{d}{(ItemType)int.Parse(s)}{d}"; } catch { }
									}

									itemsoriginal = ev.Args[1];
								}
								else
								{
									string[] spearator = { "." };
									string[] items = ev.Args[0].Split(spearator, 2, StringSplitOptions.RemoveEmptyEntries);
									foreach (string s in items)
									{
										try { itemsstr += $"{s}{d}{(ItemType)int.Parse(s)}{d}"; } catch { }
									}

									itemsoriginal = ev.Args[0];
								}
								msg = $"{ev.Name} {targets} {itemsstr} {Args.Replace(ev.Args[0], "").Replace($"{itemsoriginal}", "")}";
								break;
							}
						case "overwatch" or "bypass" or "heal" or "god" or "noclip" or "doortp" or "bring"
							or "mute" or "unmute" or "imute" or "iunmute" or "goto":
							{
								string targets = "";
								string[] spearator = { "." };
								string[] strlist = ev.Args[0].Split(spearator, 2, StringSplitOptions.RemoveEmptyEntries);
								foreach (string s in strlist)
								{
									try { targets += $"{s}{d}{int.Parse(s).GetPlayer()?.UserInformation.Nickname}{d} "; } catch { }
								}
								msg = $"{ev.Name} {targets} {Args.Replace(ev.Args[0], "")}";
								break;
							}
						default:
							{
								msg = $"{ev.Command}";
								break;
							}

					}
				}
				catch
				{
					msg = $"{ev.Command}";
				}
				Send.Msg(Cfg.Translate.Ra.Replace("%command%", Api.AntiMD(msg)).Replace("%player%", Api.PlayerInfo(ev.Player, false)));
				Send.RemoteAdmin(Cfg.Translate.Ra.Replace("%command%", Api.AntiMD(msg)).Replace("%player%", Api.PlayerInfo(ev.Player, false)));
				#endregion
			}
			catch { }
		}
		#endregion


		internal static void UpdateServerStatus()
		{
			try
			{
				int max = GameCore.ConfigFile.ServerConfig.GetInt("max_players", 35);
				int cur = Player.List.Count();

				int aliveCount = 0;
				int scpCount = 0;

				foreach (Player player in Player.List)
					if (player.RoleInformation.IsHuman)
						aliveCount++;
					else if (player.RoleInformation.IsScp)
						scpCount++;

				string warhead = Alpha.Detonated ? Cfg.Translate.AlphaDetonated :
					(Alpha.Active ? Cfg.Translate.AlphaActive :
					Cfg.Translate.AlphaNotDetonated);

				Send.ChannelTopic(Cfg.Translate.RoundInfo.Replace("%players%", $"{cur}/{max}")
					.Replace("%time%", $"{Round.ElapsedTime.Minutes}")
					.Replace("%alive%", $"{aliveCount}")
					.Replace("%scps%", $"{scpCount}")
					.Replace("%alpha%", $"{warhead}")
					.Replace("%ip%", $"{ServerConsole.Ip}:{Server.Port}")
					.Replace("%date%", Send.GetTime));
			}
			catch { }
		}

		static bool Ally(Player pl1, Player pl2)
		{
			if (Cached.TryGetValue(pl2, out var role))
				return pl1.RoleInformation.Faction == role.GetFaction();

			return pl1.RoleInformation.Faction == pl2.RoleInformation.Faction;
		}
	}
}
#pragma warning restore IDE0051