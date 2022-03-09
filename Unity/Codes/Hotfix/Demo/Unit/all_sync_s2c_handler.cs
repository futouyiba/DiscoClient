using System;
using UnityEngine;

namespace ET
{
    /// <summary>
    /// 现在处理的是刚进入舞池时候的all sync。后续不排除有其他时机导致的all sync，届时再作修改。
    /// </summary>
    [MessageHandler]
    public class all_sync_s2c_handler: AMHandler<all_sync_s2c>
    {
        protected override async ETTask Run(Session session, all_sync_s2c message)
        {
            Log.Info($"all sync message:{message}");
            WaitType.Wait_all_sync waitAllSync = await session.DomainScene().GetComponent<ObjectWait>().Wait<WaitType.Wait_all_sync>();
            // var all_sync = waitAllSync.Message;
            foreach (player p in message.players)
            {
                await session.DomainScene().GetComponent<UnitComponent>().CreatePlayer(p);
            }
            await ETTask.CompletedTask;
        }
    }
}