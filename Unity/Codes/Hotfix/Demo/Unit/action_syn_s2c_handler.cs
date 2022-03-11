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
                    await Game.EventSystem.PublishAsync(new BecomeDJ(){Unit = playerUnit});
                    break;
                case ConstValue.ACTION_ID_SWITCH_MUSIC:
                    await Game.EventSystem.PublishAsync(new CutToMusic() { MusicId = message.int1 });
                    break;
                case ConstValue.ACTION_ID_BECOME_BIGGER:
                    await Game.EventSystem.PublishAsync(new GrowBig() { Unit = playerUnit });
                    break;
                case ConstValue.ACTION_ID_MOVE_TO:
                    await Game.EventSystem.PublishAsync(new EventType.MoveStart());
                    break;
                
            }
            await ETTask.CompletedTask;
        }
    }
}