using System;
using ET.EventType;
using UnityEngine;

namespace ET
{
    /// <summary>
    /// 现在处理的是刚进入舞池时候的all sync。后续不排除有其他时机导致的all sync，届时再作修改。
    /// </summary>
    [MessageHandler]
    public class action_syn_s2c_handler: AMHandler<action_syn_s2c>
    {

        protected override async ETTask Run(Session session, action_syn_s2c message)
        {
            Log.Info($"action sync s2c message:{message}");
            UnitComponent unitComponent = session.ZoneScene().CurrentScene().GetComponent<UnitComponent>();
            Unit playerUnit;
            if (unitComponent.PlayerUnits.ContainsKey(message.player_id))
            {
                playerUnit = unitComponent.PlayerUnits[message.player_id];
            }
            else
            {
                return;
            }
            switch (message.action_id)
            {
                case ConstValue.ACTION_ID_BECOME_DJ:
                    player playerData = playerUnit.GetComponent<CharComp>().playerData;
                    playerData.is_dj = message.int1;
                    await Game.EventSystem.PublishAsync(new BecomeDJ(){Unit = playerUnit});
                    break;
                case ConstValue.ACTION_ID_SWITCH_MUSIC:
                    session.ZoneScene().CurrentScene().GetComponent<HouseComponent>().HouseStatusData.music_id = message.int1;
                    await Game.EventSystem.PublishAsync(new CutToMusic() { MusicId = message.int1, ZoneScene = session.ZoneScene()});
                    break;
                case ConstValue.ACTION_ID_BECOME_BIGGER:
                    await Game.EventSystem.PublishAsync(new GrowBig() { Unit = playerUnit });
                    break;
                case ConstValue.ACTION_ID_MOVE_TO:
                    await Game.EventSystem.PublishAsync(new EventType.MoveStart(){Unit = playerUnit, x = message.float1, y = message.float2});
                    break;
                case ConstValue.ACTION_ID_CONTROL_LIGHTING:
                    await Game.EventSystem.PublishAsync(new EventType.ControlLight() { LightId = message.int1 });
                    break;
                case ConstValue.ACTION_ID_CHANGE_FIGURE:
                    await Game.EventSystem.PublishAsync(new EventType.ChangeFigure() { FigureId = message.int1 });
                    break;
                case ConstValue.ACTION_ID_TAKE_SEAT:
                    await Game.EventSystem.PublishAsync(new EventType.TakeSeat(){Unit = playerUnit, SeatId = message.int1});
                    break;
                case ConstValue.ACTION_ID_SHOUT_SLOGAN:
                    await Game.EventSystem.PublishAsync(new EventType.ShoutSlogan() { Unit = playerUnit, SloganToShout = message.str1 });
                    break;
                case ConstValue.ACTION_ID_CHAT:
                    await Game.EventSystem.PublishAsync(new EventType.Chat() { Unit = playerUnit, Content = message.str1 });
                    break;
                default:
                    Log.Warning("action sync message not handled, message:" + message);
                    break;
            }
            await ETTask.CompletedTask;
        }
    }
}